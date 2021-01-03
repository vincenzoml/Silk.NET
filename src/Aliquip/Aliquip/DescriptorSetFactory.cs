// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using Silk.NET.Vulkan;

namespace Aliquip
{
    internal class DescriptorSetFactory : IDescriptorSetFactory
    {
        private readonly Vk _vk;
        private readonly ILogicalDeviceProvider _logicalDeviceProvider;

        public DescriptorSetFactory
        (
            Vk vk, ILogicalDeviceProvider logicalDeviceProvider
        )
        {
            _vk = vk;
            _logicalDeviceProvider = logicalDeviceProvider;
        }

        public unsafe DescriptorSet[] CreateDescriptorSets(DescriptorPool descriptorPool, int count, DescriptorSetLayout layout)
        {
            var v = new Span<DescriptorSetLayout>(new DescriptorSetLayout[count]);
            v.Fill(layout);
            fixed (DescriptorSetLayout* layouts = v)
            {
                var allocInfo = new DescriptorSetAllocateInfo
                    (descriptorPool: descriptorPool, descriptorSetCount: (uint) count, pSetLayouts: layouts);

                var descriptorSets = new DescriptorSet[count];
                fixed (DescriptorSet* pDescriptorSets = descriptorSets)
                    _vk.AllocateDescriptorSets(_logicalDeviceProvider.LogicalDevice, allocInfo, pDescriptorSets).ThrowCode();
                
                return descriptorSets;
            }
        }
    }
}
