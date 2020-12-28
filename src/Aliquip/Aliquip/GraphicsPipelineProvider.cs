// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;
using Silk.NET.Core.Native;
using Silk.NET.Maths;
using Silk.NET.Vulkan;
using Buffer = Silk.NET.Vulkan.Buffer;

namespace Aliquip
{
    internal sealed class GraphicsPipelineProvider : IGraphicsPipelineProvider, IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = sizeof(float) * 5)]
        private struct Vertex
        {
            [FieldOffset(0)]
            public Vector2D<float> Position;
            [FieldOffset(sizeof(float) * 2)]
            public Vector3D<float> Color;

            public Vertex(Vector2D<float> position, Vector3D<float> color)
            {
                Position = position;
                Color = color;
            }

            public static unsafe VertexInputBindingDescription BindingDescription
            {
                get
                {
                    var bindingDescription = new VertexInputBindingDescription();
                    bindingDescription.Binding = 0;
                    bindingDescription.Stride = (uint) sizeof(Vertex);
                    bindingDescription.InputRate = VertexInputRate.Vertex;
                    
                    return bindingDescription;
                }
            }
            
            public static VertexInputAttributeDescription[] AttributeDescriptions
            {
                get
                {
                    var attributeDescriptions = new VertexInputAttributeDescription[2];

                    attributeDescriptions[0].Binding = 0;
                    attributeDescriptions[0].Location = 0;
                    attributeDescriptions[0].Format = Format.R32G32Sfloat;
                    attributeDescriptions[0].Offset = 0; // offset of Position

                    attributeDescriptions[1].Binding = 0;
                    attributeDescriptions[1].Location = 1;
                    attributeDescriptions[1].Format = Format.R32G32B32Sfloat;
                    attributeDescriptions[1].Offset = sizeof(float) * 2; // offset of Color

                    return attributeDescriptions;
                }
            }
        }

        private static readonly Vertex[] vertices = new Vertex[]
        {
            new(new(0.0f, -0.5f), new(1.0f, 1.0f, 1.0f)),
            new(new(0.5f, 0.5f), new(0.0f, 1.0f, 0.0f)),
            new(new(-0.5f, 0.5f), new(0.0f, 0.0f, 1.0f)),
        };

        private readonly Vk _vk;
        private readonly ILogicalDeviceProvider _logicalDeviceProvider;
        private readonly ISwapchainProvider _swapchainProvider;
        private readonly IPipelineLayoutProvider _pipelineLayoutProvider;
        private readonly IRenderPassProvider _renderPassProvider;
        private readonly IResourceProvider _resourceProvider;
        private readonly IPhysicalDeviceProvider _physicalDeviceProvider;
        private readonly IBufferFactory _bufferFactory;
        private readonly IGraphicsQueueProvider _graphicsQueueProvider;
        private readonly ITransferQueueProvider _transferQueueProvider;
        private readonly ICommandBufferFactory _commandBufferFactory;
        public Buffer VertexBuffer { get; private set; }
        private DeviceMemory _vertexBufferMemory;
        public Pipeline GraphicsPipeline { get; private set; }

        public GraphicsPipelineProvider(Vk vk, ILogicalDeviceProvider logicalDeviceProvider, ISwapchainProvider swapchainProvider,
            IPipelineLayoutProvider pipelineLayoutProvider, IRenderPassProvider renderPassProvider, IResourceProvider resourceProvider, IPhysicalDeviceProvider physicalDeviceProvider, IBufferFactory bufferFactory,
            IGraphicsQueueProvider graphicsQueueProvider, ITransferQueueProvider transferQueueProvider, ICommandBufferFactory commandBufferFactory)
        {
            _vk = vk;
            _logicalDeviceProvider = logicalDeviceProvider;
            _swapchainProvider = swapchainProvider;
            _pipelineLayoutProvider = pipelineLayoutProvider;
            _renderPassProvider = renderPassProvider;
            _resourceProvider = resourceProvider;
            _physicalDeviceProvider = physicalDeviceProvider;
            _bufferFactory = bufferFactory;
            _graphicsQueueProvider = graphicsQueueProvider;
            _transferQueueProvider = transferQueueProvider;
            _commandBufferFactory = commandBufferFactory;

            RecreateGraphicsPipeline();
        }

        private unsafe void CopyBuffer(Buffer srcBuffer, Buffer dstBuffer, ulong size)
        {
            var cbs = _commandBufferFactory.CreateCommandBuffers(1, _transferQueueProvider.TransferQueueIndex, new CommandBufferBeginInfo(flags: CommandBufferUsageFlags.CommandBufferUsageOneTimeSubmitBit),
                (commandBuffer, _) =>
                {
                    var region = new BufferCopy(0, 0, size);
                    _vk.CmdCopyBuffer(commandBuffer, srcBuffer, dstBuffer, 1, &region);
                });

            var c = cbs[0];
            var submitInfo = new SubmitInfo(commandBufferCount: 1, pCommandBuffers: &c);
            _vk.QueueSubmit(_transferQueueProvider.TransferQueue, 1, submitInfo, default);
            _vk.QueueWaitIdle(_transferQueueProvider.TransferQueue);
            
            _commandBufferFactory.FreeCommandBuffers(cbs, _transferQueueProvider.TransferQueueIndex);
        }
        
        public unsafe void RecreateGraphicsPipeline()
        {
            var bufferSize = (ulong) (sizeof(Vertex) * vertices.Length);
            var (stagingBuffer, stagingBufferMemory) = _bufferFactory.CreateBuffer
            (
                bufferSize, BufferUsageFlags.BufferUsageTransferSrcBit,
                MemoryPropertyFlags.MemoryPropertyHostVisibleBit | MemoryPropertyFlags.MemoryPropertyHostCoherentBit,
                stackalloc[] {_transferQueueProvider.TransferQueueIndex, _graphicsQueueProvider.GraphicsQueueIndex}
            );
            
            void* data = default;
            _vk.MapMemory(_logicalDeviceProvider.LogicalDevice, stagingBufferMemory, 0, bufferSize, 0, ref data);
            var span = new Span<Vertex>(data, vertices.Length);
            vertices.AsSpan().CopyTo(span);
            _vk.UnmapMemory(_logicalDeviceProvider.LogicalDevice, stagingBufferMemory);

            (VertexBuffer, _vertexBufferMemory) = _bufferFactory.CreateBuffer
            (
                bufferSize, BufferUsageFlags.BufferUsageVertexBufferBit | BufferUsageFlags.BufferUsageTransferDstBit,
                MemoryPropertyFlags.MemoryPropertyDeviceLocalBit,
                stackalloc uint[] {_graphicsQueueProvider.GraphicsQueueIndex, _transferQueueProvider.TransferQueueIndex}
            );

            CopyBuffer(stagingBuffer, VertexBuffer, bufferSize);

            _vk.DestroyBuffer(_logicalDeviceProvider.LogicalDevice, stagingBuffer, null);
            _vk.FreeMemory(_logicalDeviceProvider.LogicalDevice, stagingBufferMemory, null);

            ShaderModule CreateShaderModule(string path)
            {
                var fileContents = _resourceProvider[path];
                fixed (byte* pFile = fileContents)
                {
                    var createInfo = new ShaderModuleCreateInfo
                    (
                        codeSize: (UIntPtr) fileContents.Length,
                        pCode: (uint*) pFile
                    );
                    _vk!.CreateShaderModule(_logicalDeviceProvider.LogicalDevice, &createInfo, null, out var module).ThrowCode();
                    return module;
                }
            }

            var vertModule = CreateShaderModule("shaders.vert.spv");
            var fragModule = CreateShaderModule("shaders.frag.spv");

            using var mainMem = SilkMarshal.StringToMemory("main");
            fixed (byte* pMain = mainMem)
            {
                var vertShaderStageInfo = new PipelineShaderStageCreateInfo
                (
                    stage: ShaderStageFlags.ShaderStageVertexBit,
                    module: vertModule,
                    pName: pMain
                );

                var fragShaderStageInfo = new PipelineShaderStageCreateInfo
                (
                    stage: ShaderStageFlags.ShaderStageFragmentBit,
                    module: fragModule,
                    pName: pMain
                );

                // var shaderStages = stackalloc[] {vertShaderStageInfo, fragShaderStageInfo};
                var shaderStages = stackalloc PipelineShaderStageCreateInfo[2];
                shaderStages[0] = vertShaderStageInfo;
                shaderStages[1] = fragShaderStageInfo;

                var bindingDescription = Vertex.BindingDescription;
                var attributeDescriptions = Vertex.AttributeDescriptions;

                fixed (VertexInputAttributeDescription* pAttributeDescriptions = attributeDescriptions)
                {
                    var vertexInputInfo = new PipelineVertexInputStateCreateInfo
                    (
                        vertexBindingDescriptionCount: 1,
                        pVertexBindingDescriptions: &bindingDescription,
                        vertexAttributeDescriptionCount: (uint) attributeDescriptions.Length,
                        pVertexAttributeDescriptions: pAttributeDescriptions
                    );

                    var inputAssembly = new PipelineInputAssemblyStateCreateInfo
                        (topology: PrimitiveTopology.TriangleList, primitiveRestartEnable: false);

                    var viewport = new Viewport
                    (
                        0, 0, _swapchainProvider.SwapchainExtent.Width, _swapchainProvider.SwapchainExtent.Height, 0f,
                        1f
                    );

                    var scissor = new Rect2D(new Offset2D(0, 0), _swapchainProvider.SwapchainExtent);

                    var viewportState = new PipelineViewportStateCreateInfo
                        (viewportCount: 1, pViewports: &viewport, scissorCount: 1, pScissors: &scissor);

                    var rasterizer = new PipelineRasterizationStateCreateInfo
                    (
                        depthClampEnable: false, rasterizerDiscardEnable: false, polygonMode: PolygonMode.Fill,
                        lineWidth: 1f, cullMode: CullModeFlags.CullModeBackBit, frontFace: FrontFace.Clockwise,
                        depthBiasEnable: false
                    );

                    var multisampling = new PipelineMultisampleStateCreateInfo
                        (sampleShadingEnable: false, rasterizationSamples: SampleCountFlags.SampleCount1Bit);

                    var colorBlendAttachment = new PipelineColorBlendAttachmentState
                    (
                        colorWriteMask: ColorComponentFlags.ColorComponentRBit |
                                        ColorComponentFlags.ColorComponentGBit |
                                        ColorComponentFlags.ColorComponentBBit | ColorComponentFlags.ColorComponentABit,
                        blendEnable: false
                    );

                    var colorBlending = new PipelineColorBlendStateCreateInfo
                    (
                        logicOpEnable: false, logicOp: LogicOp.Copy, attachmentCount: 1,
                        pAttachments: &colorBlendAttachment
                    );
                    colorBlending.BlendConstants[0] = 0.0f;
                    colorBlending.BlendConstants[1] = 0.0f;
                    colorBlending.BlendConstants[2] = 0.0f;
                    colorBlending.BlendConstants[3] = 0.0f;

                    var pipelineInfo = new GraphicsPipelineCreateInfo
                    (
                        stageCount: 2, pStages: shaderStages, pVertexInputState: &vertexInputInfo,
                        pInputAssemblyState: &inputAssembly, pViewportState: &viewportState,
                        pRasterizationState: &rasterizer, pMultisampleState: &multisampling,
                        pColorBlendState: &colorBlending, layout: _pipelineLayoutProvider.PipelineLayout,
                        renderPass: _renderPassProvider.RenderPass, subpass: 0, basePipelineHandle: null
                    );

                    _vk.CreateGraphicsPipelines
                        (
                            _logicalDeviceProvider.LogicalDevice, default, 1, &pipelineInfo, null,
                            out var graphicsPipeline
                        )
                        .ThrowCode();
                    GraphicsPipeline = graphicsPipeline;
                }
            }
            
            _vk.DestroyShaderModule(_logicalDeviceProvider.LogicalDevice, vertModule, null);
            _vk.DestroyShaderModule(_logicalDeviceProvider.LogicalDevice, fragModule, null);
        }

        public unsafe void Dispose()
        {
            _vk.DestroyBuffer(_logicalDeviceProvider.LogicalDevice, VertexBuffer, null);
            _vk.FreeMemory(_logicalDeviceProvider.LogicalDevice, _vertexBufferMemory, null);
            _vk.DestroyPipeline(_logicalDeviceProvider.LogicalDevice, GraphicsPipeline, null);
        }
    }
}
