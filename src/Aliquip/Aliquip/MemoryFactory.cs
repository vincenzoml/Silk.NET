// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Silk.NET.Vulkan;

namespace Aliquip
{
    internal sealed class MemoryFactory : IMemoryFactory, IDisposable
    {
        private readonly ILogicalDeviceProvider _logicalDeviceProvider;
        private readonly Vk _vk;
        private readonly ILogger _logger;
        private readonly IPhysicalDeviceProvider _physicalDeviceProvider;
        private Dictionary<uint, ulong> _memoryTypeCounts = new();
        private ulong _total = 0;
        private int _allocationCount = 0;
        private readonly ulong _blockSize;
        private readonly Dictionary<uint, MemoryTypeInfo> _memoryTypeInfos = new();

        private class MemoryTypeInfo
        {
            public readonly List<AllocInfo> Retired = new();
            public  readonly List<AllocInfo> Active = new();
        }
        
        private class AllocInfo
        {
            public DeviceMemory Memory;
            public ulong Size;
            public ulong RunningOffset;
        }

        public MemoryFactory(ILogicalDeviceProvider logicalDeviceProvider, Vk vk, ILogger<MemoryFactory> logger, IPhysicalDeviceProvider physicalDeviceProvider)
        {
            _logicalDeviceProvider = logicalDeviceProvider;
            _vk = vk;
            _logger = logger;
            _physicalDeviceProvider = physicalDeviceProvider;

            _blockSize = 1 << 13; // 8192
        }
        
        public unsafe (DeviceMemory, ulong) Allocate(ulong size, uint memoryTypeIndex)
        {
            if (!_memoryTypeInfos.TryGetValue(memoryTypeIndex, out var info))
            {
                info = new MemoryTypeInfo();
                _memoryTypeInfos[memoryTypeIndex] = info;
            }

            (DeviceMemory, ulong) SubAllocate(AllocInfo active)
            {
                var offset = active.RunningOffset;
                active.RunningOffset += size;

                if (active.Size - active.RunningOffset < 30)
                {
                    info.Active.Remove(active);
                    info.Retired.Add(active);
                }

                return (active.Memory, offset);
            }

            if (size > _blockSize)
                return (CoreAllocate(size, memoryTypeIndex), 0);

            foreach (var active in info.Active)
            {
                if (active.Size - active.RunningOffset > size)
                {
                    return SubAllocate(active);
                }
            }

            var v = AddNewBlock(memoryTypeIndex, info);
            return SubAllocate(v);
        }

        private unsafe AllocInfo AddNewBlock(uint index, MemoryTypeInfo memoryTypeInfo)
        {
            var memory = CoreAllocate(_blockSize, index);
            var v = new AllocInfo()
            {
                Memory = memory,
                RunningOffset = 0,
                Size = _blockSize
            };
            memoryTypeInfo.Active.Add(v);
            return v;
        }

        private unsafe DeviceMemory CoreAllocate(ulong size, uint memoryTypeIndex)
        {
            if (!_memoryTypeCounts.TryGetValue(memoryTypeIndex, out var v))
                v = 0;
            v += size;
            _memoryTypeCounts[memoryTypeIndex] = v;
            _allocationCount++;
            _total += size;
            
            _logger.LogDebug("Allocated {0} on {1} | total allocated: {2} | of same type: {3}", size, memoryTypeIndex, _total, v);
            var allocInfo = new MemoryAllocateInfo(allocationSize: size, memoryTypeIndex: memoryTypeIndex);
            _vk.AllocateMemory(_logicalDeviceProvider.LogicalDevice, allocInfo, null, out var mem).ThrowCode();
            return mem;
        }

        public unsafe void Dispose()
        {
            foreach (var memoryTypeInfo in _memoryTypeInfos)
            {
                foreach (var retired in memoryTypeInfo.Value.Retired)
                    _vk.FreeMemory(_logicalDeviceProvider.LogicalDevice, retired.Memory, null);
                
                foreach (var retired in memoryTypeInfo.Value.Active)
                    _vk.FreeMemory(_logicalDeviceProvider.LogicalDevice, retired.Memory, null);
            }
        }
    }
}
