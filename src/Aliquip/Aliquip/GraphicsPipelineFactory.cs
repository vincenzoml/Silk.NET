// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.IO;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;
using Silk.NET.Core.Native;
using Silk.NET.Maths;
using Silk.NET.Vulkan;
using Silk.NET.Vulkan.Extensions.KHR;
using Buffer = Silk.NET.Vulkan.Buffer;

namespace Aliquip
{
    internal sealed class GraphicsPipelineFactory : IGraphicsPipelineFactory
    {
        private readonly Vk _vk;
        private readonly ILogicalDeviceProvider _logicalDeviceProvider;
        private readonly ISwapchainProvider _swapchainProvider;
        private readonly IPipelineLayoutFactory _pipelineLayoutFactory;
        private readonly IRenderPassProvider _renderPassProvider;
        private readonly IMsaaProvider _msaaProvider;
        private readonly IPhysicalDeviceProvider _physicalDeviceProvider;
        private readonly ISampleShadingProvider _sampleShadingProvider;

        public GraphicsPipelineFactory
        (
            Vk vk,
            ILogicalDeviceProvider logicalDeviceProvider,
            ISwapchainProvider swapchainProvider,
            IPipelineLayoutFactory pipelineLayoutFactory,
            IRenderPassProvider renderPassProvider,
            IMsaaProvider msaaProvider,
            IPhysicalDeviceProvider physicalDeviceProvider,
            ISampleShadingProvider sampleShadingProvider
        )
        {
            _vk = vk;
            _logicalDeviceProvider = logicalDeviceProvider;
            _swapchainProvider = swapchainProvider;
            _pipelineLayoutFactory = pipelineLayoutFactory;
            _renderPassProvider = renderPassProvider;
            _msaaProvider = msaaProvider;
            _physicalDeviceProvider = physicalDeviceProvider;
            _sampleShadingProvider = sampleShadingProvider;
        }

        public unsafe Pipeline CreatePipeline(PipelineLayout pipelineLayout, ShaderModule vertShader, VertexInputAttributeDescription[] vertexInputAttributeDescriptions, VertexInputBindingDescription vertexInputBindingDescription, ShaderModule fragShader)
        {
            using var mainMem = SilkMarshal.StringToMemory("main");
            fixed (byte* pMain = mainMem)
            fixed (VertexInputAttributeDescription* pVertexInputAttributeDescriptions = vertexInputAttributeDescriptions)
            {
                var vertShaderStageInfo = new PipelineShaderStageCreateInfo
                    (stage: ShaderStageFlags.ShaderStageVertexBit, module: vertShader, pName: pMain);

                var fragShaderStageInfo = new PipelineShaderStageCreateInfo
                    (stage: ShaderStageFlags.ShaderStageFragmentBit, module: fragShader, pName: pMain);

                // var shaderStages = stackalloc[] {vertShaderStageInfo, fragShaderStageInfo};
                var shaderStages = stackalloc PipelineShaderStageCreateInfo[2];
                shaderStages[0] = vertShaderStageInfo;
                shaderStages[1] = fragShaderStageInfo;

                var attributeDescriptions = Vertex.AttributeDescriptions;

                var vertexInputInfo = new PipelineVertexInputStateCreateInfo
                (
                    vertexBindingDescriptionCount: 1, pVertexBindingDescriptions: &vertexInputBindingDescription,
                    vertexAttributeDescriptionCount: (uint) attributeDescriptions.Length,
                    pVertexAttributeDescriptions: pVertexInputAttributeDescriptions
                );

                var inputAssembly = new PipelineInputAssemblyStateCreateInfo
                    (topology: PrimitiveTopology.TriangleList, primitiveRestartEnable: false);

                var viewport = new Viewport
                    (0, 0, _swapchainProvider.SwapchainExtent.Width, _swapchainProvider.SwapchainExtent.Height, 0f, 1f);

                var scissor = new Rect2D(new Offset2D(0, 0), _swapchainProvider.SwapchainExtent);

                var viewportState = new PipelineViewportStateCreateInfo
                    (viewportCount: 1, pViewports: &viewport, scissorCount: 1, pScissors: &scissor);

                var rasterizer = new PipelineRasterizationStateCreateInfo
                (
                    depthClampEnable: false, rasterizerDiscardEnable: false, polygonMode: PolygonMode.Fill, lineWidth: 1f,
                    cullMode: CullModeFlags.CullModeNone, frontFace: FrontFace.CounterClockwise, depthBiasEnable: false
                );

                var multisampling = new PipelineMultisampleStateCreateInfo
                (
                    sampleShadingEnable: _sampleShadingProvider.UseSampleShading, minSampleShading: 0.2f,
                    rasterizationSamples: _msaaProvider.MsaaSamples(_physicalDeviceProvider.Device)
                );

                var colorBlendAttachment = new PipelineColorBlendAttachmentState
                (
                    colorWriteMask: ColorComponentFlags.ColorComponentRBit | ColorComponentFlags.ColorComponentGBit |
                                    ColorComponentFlags.ColorComponentBBit | ColorComponentFlags.ColorComponentABit,
                    blendEnable: false
                );

                var colorBlending = new PipelineColorBlendStateCreateInfo
                    (logicOpEnable: false, logicOp: LogicOp.Copy, attachmentCount: 1, pAttachments: &colorBlendAttachment);
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
                    pInputAssemblyState: &inputAssembly, pViewportState: &viewportState, pRasterizationState: &rasterizer,
                    pMultisampleState: &multisampling, pColorBlendState: &colorBlending,
                    pDepthStencilState: &depthStencilState, layout: pipelineLayout,
                    renderPass: _renderPassProvider.RenderPass, subpass: 0, basePipelineHandle: null
                );

                _vk.CreateGraphicsPipelines
                        (_logicalDeviceProvider.LogicalDevice, default, 1, &pipelineInfo, null, out var graphicsPipeline)
                    .ThrowCode();
                return graphicsPipeline;
            }
        }
    }
}