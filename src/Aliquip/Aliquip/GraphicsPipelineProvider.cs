// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Logging;
using Silk.NET.Core.Native;
using Silk.NET.Vulkan;

namespace Aliquip
{
    internal sealed class GraphicsPipelineProvider : IGraphicsPipelineProvider, IDisposable
    {
        private readonly Vk _vk;
        private readonly ILogicalDeviceProvider _logicalDeviceProvider;
        private readonly ISwapchainProvider _swapchainProvider;
        private readonly IPipelineLayoutProvider _pipelineLayoutProvider;
        private readonly IRenderPassProvider _renderPassProvider;
        private readonly IResourceProvider _resourceProvider;
        public Pipeline GraphicsPipeline { get; private set; }

        public GraphicsPipelineProvider(Vk vk, ILogicalDeviceProvider logicalDeviceProvider, ISwapchainProvider swapchainProvider,
            IPipelineLayoutProvider pipelineLayoutProvider, IRenderPassProvider renderPassProvider, IResourceProvider resourceProvider)
        {
            _vk = vk;
            _logicalDeviceProvider = logicalDeviceProvider;
            _swapchainProvider = swapchainProvider;
            _pipelineLayoutProvider = pipelineLayoutProvider;
            _renderPassProvider = renderPassProvider;
            _resourceProvider = resourceProvider;
            
            RecreateGraphicsPipeline();
        }

        public unsafe void RecreateGraphicsPipeline()
        {
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
                
                var vertexInputInfo = new PipelineVertexInputStateCreateInfo
                (
                    vertexBindingDescriptionCount: 0,
                    vertexAttributeDescriptionCount: 0
                );

                var inputAssembly = new PipelineInputAssemblyStateCreateInfo
                (
                    topology: PrimitiveTopology.TriangleList,
                    primitiveRestartEnable: false
                );

                var viewport = new Viewport
                (
                    0,
                    0,
                    _swapchainProvider.SwapchainExtent.Width,
                    _swapchainProvider.SwapchainExtent.Height,
                    0f,
                    1f
                );

                var scissor = new Rect2D(new Offset2D(0, 0), _swapchainProvider.SwapchainExtent);

                var viewportState = new PipelineViewportStateCreateInfo
                (
                    viewportCount: 1,
                    pViewports: &viewport,
                    scissorCount: 1,
                    pScissors: &scissor
                );

                var rasterizer = new PipelineRasterizationStateCreateInfo
                (
                    depthClampEnable: false,
                    rasterizerDiscardEnable: false,
                    polygonMode: PolygonMode.Fill,
                    lineWidth: 1f,
                    cullMode: CullModeFlags.CullModeBackBit,
                    frontFace: FrontFace.Clockwise,
                    depthBiasEnable: false
                );

                var multisampling = new PipelineMultisampleStateCreateInfo
                (
                    sampleShadingEnable: false,
                    rasterizationSamples: SampleCountFlags.SampleCount1Bit
                );

                var colorBlendAttachment = new PipelineColorBlendAttachmentState
                (
                    colorWriteMask: ColorComponentFlags.ColorComponentRBit | ColorComponentFlags.ColorComponentGBit | ColorComponentFlags.ColorComponentBBit | ColorComponentFlags.ColorComponentABit,
                    blendEnable: false
                );

                var colorBlending = new PipelineColorBlendStateCreateInfo
                (
                    logicOpEnable: false, logicOp: LogicOp.Copy, attachmentCount: 1, pAttachments: &colorBlendAttachment
                );
                colorBlending.BlendConstants[0] = 0.0f;
                colorBlending.BlendConstants[1] = 0.0f;
                colorBlending.BlendConstants[2] = 0.0f;
                colorBlending.BlendConstants[3] = 0.0f;

                var pipelineInfo = new GraphicsPipelineCreateInfo
                (
                    stageCount: 2,
                    pStages: shaderStages,
                    pVertexInputState: &vertexInputInfo,
                    pInputAssemblyState: &inputAssembly,
                    pViewportState: &viewportState,
                    pRasterizationState: &rasterizer,
                    pMultisampleState: &multisampling,
                    pColorBlendState: &colorBlending,
                    layout: _pipelineLayoutProvider.PipelineLayout,
                    renderPass: _renderPassProvider.RenderPass,
                    subpass: 0,
                    basePipelineHandle: null
                );

                _vk.CreateGraphicsPipelines(_logicalDeviceProvider.LogicalDevice, default, 1, &pipelineInfo, null, out var graphicsPipeline).ThrowCode();
                GraphicsPipeline = graphicsPipeline;
            }
            
            _vk.DestroyShaderModule(_logicalDeviceProvider.LogicalDevice, vertModule, null);
            _vk.DestroyShaderModule(_logicalDeviceProvider.LogicalDevice, fragModule, null);
        }

        public unsafe void Dispose()
        {
            _vk.DestroyPipeline(_logicalDeviceProvider.LogicalDevice, GraphicsPipeline, null);
        }
    }
}
