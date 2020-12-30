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
        private readonly ITextureFactory _textureFactory;
        public DescriptorSet[] DescriptorSets { get; private set; }

        public DescriptorSetProvider
        (
            Vk vk,
            IDescriptorSetLayoutProvider descriptorSetLayoutProvider,
            ISwapchainProvider swapchainProvider,
            IDescriptorPoolProvider descriptorPoolProvider, ILogicalDeviceProvider logicalDeviceProvider,
            IGraphicsPipelineProvider graphicsPipelineProvider,
            ITextureFactory textureFactory
        )
        {
            _vk = vk;
            _descriptorSetLayoutProvider = descriptorSetLayoutProvider;
            _swapchainProvider = swapchainProvider;
            _descriptorPoolProvider = descriptorPoolProvider;
            _logicalDeviceProvider = logicalDeviceProvider;
            _graphicsPipelineProvider = graphicsPipelineProvider;
            _textureFactory = textureFactory;

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

            var image = _textureFactory["viking_room.png"];
            for (int i = 0; i < count; i++)
            {
                var bufferInfo = _graphicsPipelineProvider.GetDescriptorBufferInfo(i);
                var imageInfo = new DescriptorImageInfo
                (
                    imageLayout: ImageLayout.ShaderReadOnlyOptimal, imageView: image.ImageView, sampler: image.Sampler
                );
                Span<WriteDescriptorSet> descriptorWrites = stackalloc[]
                {
                    new WriteDescriptorSet
                    (
                        dstSet: DescriptorSets[i], dstBinding: 0, dstArrayElement: 0,
                        descriptorType: DescriptorType.UniformBuffer, descriptorCount: 1, pBufferInfo: &bufferInfo
                    ),
                    new WriteDescriptorSet
                    (
                        dstSet: DescriptorSets[i], dstBinding: 1, dstArrayElement: 0,
                        descriptorType: DescriptorType.CombinedImageSampler, descriptorCount: 1,
                        pImageInfo: &imageInfo
                    )
                };

                fixed(WriteDescriptorSet* p = descriptorWrites)
                    _vk.UpdateDescriptorSets(_logicalDeviceProvider.LogicalDevice, (uint) descriptorWrites.Length, p, 0, null);
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
