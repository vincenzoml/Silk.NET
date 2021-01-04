// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using Silk.NET.Vulkan;

namespace Aliquip
{
    internal sealed class DescriptorSetLayoutFactory : IDescriptorSetLayoutFactory
    {
        private readonly Vk _vk;
        private readonly ILogicalDeviceProvider _logicalDeviceProvider;
        private readonly IAllocationCallbacksProvider _allocationCallbacksProvider;

        public unsafe DescriptorSetLayoutFactory(Vk vk, ILogicalDeviceProvider logicalDeviceProvider, IAllocationCallbacksProvider allocationCallbacksProvider)
        {
            _vk = vk;
            _logicalDeviceProvider = logicalDeviceProvider;
            _allocationCallbacksProvider = allocationCallbacksProvider;
        }

        public unsafe DescriptorSetLayout CreateDescriptorSetLayout(DescriptorSetLayoutBinding[] bindings)
        {
            fixed (DescriptorSetLayoutBinding* pBindings = bindings)
            {
                var layoutInfo = new DescriptorSetLayoutCreateInfo(bindingCount: (uint) bindings.Length, pBindings: pBindings);
                _vk.CreateDescriptorSetLayout
                        (_logicalDeviceProvider.LogicalDevice, &layoutInfo, null, out var descriptorSetLayout)
                    .ThrowCode();
                return descriptorSetLayout;
            }
        }
    }
}
