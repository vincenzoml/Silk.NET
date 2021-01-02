// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Silk.NET.Vulkan;

namespace Aliquip
{
    internal sealed class MemoryFactory : IMemoryFactory
    {
        private readonly ILogicalDeviceProvider _logicalDeviceProvider;
        private readonly Vk _vk;
        private readonly ILogger _logger;
        private Dictionary<uint, ulong> _memoryTypeCounts = new();
        private ulong _total = 0;
        private int _allocationCount = 0;

        public MemoryFactory(ILogicalDeviceProvider logicalDeviceProvider, Vk vk, ILogger<MemoryFactory> logger)
        {
            _logicalDeviceProvider = logicalDeviceProvider;
            _vk = vk;
            _logger = logger;
        }
        
        public unsafe DeviceMemory Allocate(ulong size, uint memoryTypeIndex)
        {
            if (!_memoryTypeCounts.TryGetValue(memoryTypeIndex, out var v))
                v = 0;
            v += size;
            _memoryTypeCounts[memoryTypeIndex] = v;
            _allocationCount++;
            _total += size;
            
            _logger.LogInformation("Allocated {0} on {1} | total allocated: {2} | of same type: {3}", size, memoryTypeIndex, _total, v);
            var allocInfo = new MemoryAllocateInfo(allocationSize: size, memoryTypeIndex: memoryTypeIndex);
            _vk.AllocateMemory(_logicalDeviceProvider.LogicalDevice, allocInfo, null, out var mem).ThrowCode();
            return mem;
        }
    }
}
