// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Linq;
using Silk.NET.Vulkan;

namespace Aliquip
{
    internal sealed class DescriptorPoolFactory : IDescriptorPoolFactory
    {
        private readonly Vk _vk;
        private readonly ISwapchainProvider _swapchainProvider;
        private readonly ILogicalDeviceProvider _logicalDeviceProvider;
        private readonly IAllocationCallbacksProvider _allocationCallbacksProvider;

        public DescriptorPoolFactory(Vk vk, ISwapchainProvider swapchainProvider, ILogicalDeviceProvider logicalDeviceProvider, IAllocationCallbacksProvider allocationCallbacksProvider)
        {
            _vk = vk;
            _swapchainProvider = swapchainProvider;
            _logicalDeviceProvider = logicalDeviceProvider;
            _allocationCallbacksProvider = allocationCallbacksProvider;
        }

        public unsafe DescriptorPool CreateDescriptorPool(DescriptorPoolSize[] descriptorPoolSizes)
        {
            DescriptorPoolCreateInfo poolInfo;
            fixed (DescriptorPoolSize* pPoolSizes = descriptorPoolSizes)
                poolInfo = new DescriptorPoolCreateInfo
                (
                    poolSizeCount: (uint)descriptorPoolSizes.Length, pPoolSizes: pPoolSizes, maxSets: (uint) descriptorPoolSizes.Sum(x => x.DescriptorCount)
                );

            _vk.CreateDescriptorPool(_logicalDeviceProvider.LogicalDevice, &poolInfo, null, out var descriptorPool).ThrowCode();
            return descriptorPool;
        }
    }
}
