// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.IO;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Silk.NET.Core.Native;
using Silk.NET.Maths;
using Silk.NET.Vulkan;
using Silk.NET.Vulkan.Extensions.KHR;
using Buffer = Silk.NET.Vulkan.Buffer;

namespace Aliquip
{
    internal sealed class GraphicsPipelineProvider : IGraphicsPipelineProvider, IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = sizeof(float) * 5)]
        private struct Vertex
        {
            private const int PositionOffset = 0;
            [FieldOffset(PositionOffset)]
            public Vector3D<float> Position;
            private const int ColorOffset = sizeof(float) * 3;
            [FieldOffset(ColorOffset)]
            public Vector3D<float> Color;
            private const int TextureCoordinateOffset = sizeof(float) * 6;
            [FieldOffset(TextureCoordinateOffset)] 
            public Vector2D<float> TextureCoordinate;

            public Vertex(Vector3D<float> position, Vector3D<float> color, Vector2D<float> textureCoordinate)
            {
                Position = position;
                Color = color;
                TextureCoordinate = textureCoordinate;
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
                    var attributeDescriptions = new VertexInputAttributeDescription[3];

                    attributeDescriptions[0].Binding = 0;
                    attributeDescriptions[0].Location = 0;
                    attributeDescriptions[0].Format = Format.R32G32B32Sfloat;
                    attributeDescriptions[0].Offset = PositionOffset;

                    attributeDescriptions[1].Binding = 0;
                    attributeDescriptions[1].Location = 1;
                    attributeDescriptions[1].Format = Format.R32G32B32Sfloat;
                    attributeDescriptions[1].Offset = ColorOffset;
                    
                    attributeDescriptions[2].Binding = 0;
                    attributeDescriptions[2].Location = 2;
                    attributeDescriptions[2].Format = Format.R32G32Sfloat;
                    attributeDescriptions[2].Offset = TextureCoordinateOffset;

                    return attributeDescriptions;
                }
            }
        }

        private static readonly Vertex[] vertices =
        {
            new(new(-0.5f, -0.5f, 0.0f), new(1.0f, 0.0f, 0.0f), new(1.0f, 0.0f)),
            new(new(0.5f, -0.5f, 0.0f), new(0.0f, 1.0f, 0.0f), new(0.0f, 0.0f)),
            new(new(0.5f, 0.5f, 0.0f), new(0.0f, 0.0f, 1.0f), new(0.0f, 1.0f)),
            new(new(-0.5f, 0.5f, 0.0f), new(1.0f, 1.0f, 1.0f), new(1.0f, 1.0f)),
            
            new(new(-0.5f, -0.5f, -0.5f), new(1.0f, 0.0f, 0.0f), new(1.0f, 0.0f)),
            new(new(0.5f, -0.5f, -0.5f), new(0.0f, 1.0f, 0.0f), new(0.0f, 0.0f)),
            new(new(0.5f, 0.5f, -0.5f), new(0.0f, 0.0f, 1.0f), new(0.0f, 1.0f)),
            new(new(-0.5f, 0.5f, -0.5f), new(1.0f, 1.0f, 1.0f), new(1.0f, 1.0f)),
        };

        private static readonly ushort[] indices =
        {
            0, 1, 2, 2, 3, 0,
            4, 5, 6, 6, 7, 4
        };
        
        private readonly Vk _vk;
        private readonly ILogicalDeviceProvider _logicalDeviceProvider;
        private readonly ISwapchainProvider _swapchainProvider;
        private readonly IPipelineLayoutProvider _pipelineLayoutProvider;
        private readonly IRenderPassProvider _renderPassProvider;
        private readonly IResourceProvider _resourceProvider;
        private readonly IBufferFactory _bufferFactory;
        private readonly IGraphicsQueueProvider _graphicsQueueProvider;
        private readonly ITransferQueueProvider _transferQueueProvider;
        private readonly ICommandBufferFactory _commandBufferFactory;
        private readonly IConfiguration _configuration;
        private readonly ICameraProvider _cameraProvider;

        private Buffer _buffer;
        private DeviceMemory _bufferMemory;
        private ulong _vertexOffset;
        private ulong _indexOffset;
        private Pipeline _graphicsPipeline;
        private Buffer _uniformBuffer;
        private DeviceMemory _uniformBufferMemory;
        private ulong[] _uniformOffsets;

        public uint IndexCount => (uint) indices.Length;
        public GraphicsPipelineProvider(Vk vk, ILogicalDeviceProvider logicalDeviceProvider, ISwapchainProvider swapchainProvider,
            IPipelineLayoutProvider pipelineLayoutProvider, IRenderPassProvider renderPassProvider, IResourceProvider resourceProvider, IBufferFactory bufferFactory,
            IGraphicsQueueProvider graphicsQueueProvider, ITransferQueueProvider transferQueueProvider, ICommandBufferFactory commandBufferFactory, IConfiguration configuration, ICameraProvider cameraProvider)
        {
            _vk = vk;
            _logicalDeviceProvider = logicalDeviceProvider;
            _swapchainProvider = swapchainProvider;
            _pipelineLayoutProvider = pipelineLayoutProvider;
            _renderPassProvider = renderPassProvider;
            _resourceProvider = resourceProvider;
            _bufferFactory = bufferFactory;
            _graphicsQueueProvider = graphicsQueueProvider;
            _transferQueueProvider = transferQueueProvider;
            _commandBufferFactory = commandBufferFactory;
            _configuration = configuration;
            _cameraProvider = cameraProvider;

            Recreate();
        }

        private unsafe void CopyDataToBufferViaStaging<T>(Span<T> src, Buffer dstBuffer, ulong dstOffset) where T : unmanaged
        {
            var bufferSize = (ulong)(sizeof(T) * src.Length);
            
            var (stagingBuffer, stagingBufferMemory) = _bufferFactory.CreateBuffer
            (
                bufferSize, BufferUsageFlags.BufferUsageTransferSrcBit,
                MemoryPropertyFlags.MemoryPropertyHostVisibleBit |
                MemoryPropertyFlags.MemoryPropertyHostCoherentBit,
                stackalloc[] {_transferQueueProvider.TransferQueueIndex, _graphicsQueueProvider.GraphicsQueueIndex}
            );

            void* data = default;
            _vk.MapMemory(_logicalDeviceProvider.LogicalDevice, stagingBufferMemory, 0, bufferSize, 0, ref data);
            var span = new Span<T>(data, src.Length);
            src.CopyTo(span);
            _vk.UnmapMemory(_logicalDeviceProvider.LogicalDevice, stagingBufferMemory);

            _commandBufferFactory.RunSingleTime(_transferQueueProvider.TransferQueueIndex, _transferQueueProvider.TransferQueue,
                (commandBuffer) =>
                {
                    var region = new BufferCopy(0, dstOffset, bufferSize);
                    _vk.CmdCopyBuffer(commandBuffer, stagingBuffer, dstBuffer, 1, &region);   
                });
        }

        public unsafe void Bind(CommandBuffer commandBuffer)
        {
            _vk.CmdBindPipeline
                (commandBuffer, PipelineBindPoint.Graphics, _graphicsPipeline);

            var vertexBuffers = stackalloc[] {_buffer};
            var offsets = stackalloc[] {_vertexOffset};
            _vk.CmdBindVertexBuffers(commandBuffer, 0, 1, vertexBuffers, offsets);
            _vk.CmdBindIndexBuffer(commandBuffer, _buffer, _indexOffset, IndexType.Uint16);
        }
        
        public unsafe void Recreate()
        {
            (_buffer, _bufferMemory) = _bufferFactory.CreateBuffer
            (
                (ulong) (sizeof(Vertex) * vertices.Length + sizeof(ushort) * indices.Length),
                BufferUsageFlags.BufferUsageIndexBufferBit | BufferUsageFlags.BufferUsageVertexBufferBit | BufferUsageFlags.BufferUsageTransferDstBit,
                MemoryPropertyFlags.MemoryPropertyDeviceLocalBit,
                stackalloc uint[]
                    {_graphicsQueueProvider.GraphicsQueueIndex, _transferQueueProvider.TransferQueueIndex}
            );

            _vertexOffset = 0;
            _indexOffset = (ulong) (sizeof(Vertex) * vertices.Length);
            
            CopyDataToBufferViaStaging<Vertex>(vertices, _buffer, _vertexOffset);
            CopyDataToBufferViaStaging<ushort>(indices, _buffer, _indexOffset);

            void CreateUniformBuffers()
            {
                _uniformOffsets = new ulong[_swapchainProvider.SwapchainImages.Length];
                for (int i = 0; i < _uniformOffsets.Length; i++)
                    _uniformOffsets[i] = (ulong) (sizeof(UniformBufferObject) * i);

                var totalSize = (ulong) (sizeof(UniformBufferObject) * _uniformOffsets.Length);

                (_uniformBuffer, _uniformBufferMemory) = _bufferFactory.CreateBuffer
                (
                    totalSize, BufferUsageFlags.BufferUsageUniformBufferBit,
                    MemoryPropertyFlags.MemoryPropertyHostVisibleBit |
                    MemoryPropertyFlags.MemoryPropertyHostCoherentBit,
                    stackalloc[] {_graphicsQueueProvider.GraphicsQueueIndex}
                );
            }
            
            CreateUniformBuffers();
            
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
                        lineWidth: 1f, cullMode: CullModeFlags.CullModeNone, frontFace: FrontFace.CounterClockwise,
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

                    var depthStencilState = new PipelineDepthStencilStateCreateInfo
                    (
                        depthTestEnable: true, depthWriteEnable: true, depthCompareOp: CompareOp.Less,
                        depthBoundsTestEnable: false, stencilTestEnable: false
                    );

                    var pipelineInfo = new GraphicsPipelineCreateInfo
                    (
                        stageCount: 2, pStages: shaderStages, pVertexInputState: &vertexInputInfo,
                        pInputAssemblyState: &inputAssembly, pViewportState: &viewportState,
                        pRasterizationState: &rasterizer, pMultisampleState: &multisampling,
                        pColorBlendState: &colorBlending, pDepthStencilState: &depthStencilState, layout: _pipelineLayoutProvider.PipelineLayout,
                        renderPass: _renderPassProvider.RenderPass, subpass: 0, basePipelineHandle: null
                    );

                    _vk.CreateGraphicsPipelines
                        (
                            _logicalDeviceProvider.LogicalDevice, default, 1, &pipelineInfo, null,
                            out var graphicsPipeline
                        )
                        .ThrowCode();
                    _graphicsPipeline = graphicsPipeline;
                }
            }
            
            _vk.DestroyShaderModule(_logicalDeviceProvider.LogicalDevice, vertModule, null);
            _vk.DestroyShaderModule(_logicalDeviceProvider.LogicalDevice, fragModule, null);
        }

        private DateTime _start = DateTime.UtcNow;
        public unsafe void UpdateUBO(uint currentImage, double delta)
        {
            var timeDiff = DateTime.UtcNow - _start;

            var ubo = new UniformBufferObject(
                model: Matrix4X4.CreateRotationZ((float) ((timeDiff.TotalMilliseconds / 10) * MathF.PI / 180f)),
                view: _cameraProvider.ViewMatrix,
                projection: _cameraProvider.ProjectionMatrix
            );
            // Vulkan has the inverse Y
            ubo.Projection.M22 *= -1;

            void* data = default;
            _vk.MapMemory(_logicalDeviceProvider.LogicalDevice, _uniformBufferMemory, _uniformOffsets[currentImage], (ulong) sizeof(UniformBufferObject), 0, ref data);
            *((UniformBufferObject*)data) = ubo;
            _vk.UnmapMemory(_logicalDeviceProvider.LogicalDevice, _uniformBufferMemory);
        }

        public unsafe DescriptorBufferInfo GetDescriptorBufferInfo(int index)
        {
            return new DescriptorBufferInfo(_uniformBuffer, _uniformOffsets[index], (ulong) sizeof(UniformBufferObject));
        }

        public unsafe void Dispose()
        {
            _vk.DestroyBuffer(_logicalDeviceProvider.LogicalDevice, _buffer, null);
            _vk.FreeMemory(_logicalDeviceProvider.LogicalDevice, _bufferMemory, null);
            _vk.DestroyBuffer(_logicalDeviceProvider.LogicalDevice, _uniformBuffer, null);
            _vk.FreeMemory(_logicalDeviceProvider.LogicalDevice, _uniformBufferMemory, null);
            _vk.DestroyPipeline(_logicalDeviceProvider.LogicalDevice, _graphicsPipeline, null);
        }
    }
}
