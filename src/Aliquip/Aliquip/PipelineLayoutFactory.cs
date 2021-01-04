// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using Silk.NET.Maths;
using Silk.NET.Vulkan;

namespace Aliquip
{
    internal sealed class PipelineLayoutFactory : IPipelineLayoutFactory, IDisposable
    {
        private readonly Vk _vk;
        private readonly ILogicalDeviceProvider _logicalDeviceProvider;
        private readonly IAllocationCallbacksProvider _allocationCallbacksProvider;
        public PipelineLayout PipelineLayout { get; private set; }

        public PipelineLayoutFactory(Vk vk, ILogicalDeviceProvider logicalDeviceProvider, IDescriptorSetLayoutFactory descriptorSetLayoutFactory, IAllocationCallbacksProvider allocationCallbacksProvider)
        {
            _vk = vk;
            _logicalDeviceProvider = logicalDeviceProvider;
            _allocationCallbacksProvider = allocationCallbacksProvider;
        }

        public unsafe PipelineLayout CreatePipelineLayout(DescriptorSetLayout descriptorSetLayout, PushConstantRange[] pushConstantRanges)
        {
            PipelineLayout pipelineLayout;
            fixed (PushConstantRange* pPushConstantRanges = pushConstantRanges)
            {
                var createInfo = new PipelineLayoutCreateInfo
                (
                    setLayoutCount: 1, pSetLayouts: &descriptorSetLayout,
                    pushConstantRangeCount: (uint) pushConstantRanges.Length,
                    pPushConstantRanges: pPushConstantRanges
                );
                _vk.CreatePipelineLayout
                        (_logicalDeviceProvider.LogicalDevice, &createInfo, null, out pipelineLayout)
                    .ThrowCode();
            }

            return pipelineLayout;
        }

        public unsafe void Dispose()
        {
            _vk.DestroyPipelineLayout(_logicalDeviceProvider.LogicalDevice, PipelineLayout, null);
        }
    }
}
