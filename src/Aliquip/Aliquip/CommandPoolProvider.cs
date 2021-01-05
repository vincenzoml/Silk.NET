// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Collections.Generic;
using Silk.NET.Vulkan;

namespace Aliquip
{
    internal sealed class CommandPoolProvider : ICommandPoolProvider, IDisposable
    {
        private readonly Vk _vk;
        private readonly ILogicalDeviceProvider _logicalDeviceProvider;
        private readonly IAllocationCallbacksProvider _allocationCallbacksProvider;
        private readonly Dictionary<uint, CommandPool> _pools = new();

        public unsafe CommandPoolProvider(Vk vk, ILogicalDeviceProvider logicalDeviceProvider, IAllocationCallbacksProvider allocationCallbacksProvider)
        {
            _vk = vk;
            _logicalDeviceProvider = logicalDeviceProvider;
            _allocationCallbacksProvider = allocationCallbacksProvider;
        }

        public unsafe void Dispose()
        {
            foreach (var cp in _pools.Values)
                _vk.DestroyCommandPool(_logicalDeviceProvider.LogicalDevice, cp, null);
            _pools.Clear();
        }

        public unsafe CommandPool this[uint queueFamilyIndex]
        {
            get
            {
                if (_pools.TryGetValue(queueFamilyIndex, out var cp))
                    return cp;
                
                var createInfo = new CommandPoolCreateInfo(queueFamilyIndex: queueFamilyIndex);

                _vk.CreateCommandPool(_logicalDeviceProvider.LogicalDevice, &createInfo, null, out cp).ThrowCode();
                _pools[queueFamilyIndex] = cp;
                return cp;
            }
        }
    }
}
