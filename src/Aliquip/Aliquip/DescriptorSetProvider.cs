// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using Silk.NET.Vulkan;

namespace Aliquip
{
    internal class DescriptorSetProvider : IDescriptorSetProvider
    {
        private readonly Vk _vk;
        private readonly IDescriptorSetLayoutProvider _descriptorSetLayoutProvider;
        private readonly ISwapchainProvider _swapchainProvider;
        private readonly IDescriptorPoolProvider _descriptorPoolProvider;
        private readonly ILogicalDeviceProvider _logicalDeviceProvider;
        private readonly IGraphicsPipelineProvider _graphicsPipelineProvider;
        public DescriptorSet[] DescriptorSets { get; private set; }

        public DescriptorSetProvider
        (
            Vk vk,
            IDescriptorSetLayoutProvider descriptorSetLayoutProvider,
            ISwapchainProvider swapchainProvider,
            IDescriptorPoolProvider descriptorPoolProvider, ILogicalDeviceProvider logicalDeviceProvider,
            IGraphicsPipelineProvider graphicsPipelineProvider
        )
        {
            _vk = vk;
            _descriptorSetLayoutProvider = descriptorSetLayoutProvider;
            _swapchainProvider = swapchainProvider;
            _descriptorPoolProvider = descriptorPoolProvider;
            _logicalDeviceProvider = logicalDeviceProvider;
            _graphicsPipelineProvider = graphicsPipelineProvider;
            
            Recreate();
        }

        public unsafe void Recreate()
        {
            var count = _swapchainProvider.SwapchainImages.Length;
            
            var layouts = stackalloc DescriptorSetLayout[count];
            new Span<DescriptorSetLayout>(layouts, count).Fill(_descriptorSetLayoutProvider.DescriptorSetLayout);

            var allocInfo = new DescriptorSetAllocateInfo
            (
                descriptorPool: _descriptorPoolProvider.DescriptorPool, descriptorSetCount: (uint) count,
                pSetLayouts: layouts
            );

            DescriptorSets = new DescriptorSet[count];
            fixed (DescriptorSet* pDescriptorSets = DescriptorSets)
                _vk.AllocateDescriptorSets(_logicalDeviceProvider.LogicalDevice, allocInfo, pDescriptorSets);

            for (int i = 0; i < count; i++)
            {
                var bufferInfo = _graphicsPipelineProvider.GetDescriptorBufferInfo(i);
                var descriptorWrite = new WriteDescriptorSet
                (
                    dstSet: DescriptorSets[i], dstBinding: 0, dstArrayElement: 0,
                    descriptorType: DescriptorType.UniformBuffer, descriptorCount: 1, pBufferInfo: &bufferInfo
                );

                _vk.UpdateDescriptorSets(_logicalDeviceProvider.LogicalDevice, 1, descriptorWrite, 0, null);
            }
        }
        
        public void Dispose()
        {
            // _vk.FreeDescriptorSets
            // (
            //     _logicalDeviceProvider.LogicalDevice, _descriptorPoolProvider.DescriptorPool,
            //     (uint) DescriptorSets.Length, DescriptorSets
            // );
            DescriptorSets = null;
        }
    }
}
