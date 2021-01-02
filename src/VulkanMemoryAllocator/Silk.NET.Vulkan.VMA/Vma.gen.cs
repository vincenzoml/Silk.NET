// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.
using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Text;
using Silk.NET.Core;
using Silk.NET.Core.Native;
using Silk.NET.Core.Attributes;
using Silk.NET.Core.Contexts;
using Silk.NET.Core.Loader;

#pragma warning disable 1591

namespace Silk.NET.Vulkan.VMA
{
    public unsafe partial class Vma : NativeAPI
    {

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2476, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateAllocator")]
        public unsafe partial Result CreateAllocator(AllocatorCreateInfo* pCreateInfo, AllocatorT** pAllocator);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2476, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateAllocator")]
        public unsafe partial Result CreateAllocator(AllocatorCreateInfo* pCreateInfo, ref AllocatorT* pAllocator);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2476, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateAllocator")]
        public unsafe partial Result CreateAllocator(ref AllocatorCreateInfo pCreateInfo, AllocatorT** pAllocator);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2476, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateAllocator")]
        public unsafe partial Result CreateAllocator(ref AllocatorCreateInfo pCreateInfo, ref AllocatorT* pAllocator);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2481, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDestroyAllocator")]
        public unsafe partial void DestroyAllocator(AllocatorT* allocator);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2481, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDestroyAllocator")]
        public partial void DestroyAllocator(ref AllocatorT allocator);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2510, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetAllocatorInfo")]
        public unsafe partial void GetAllocatorInfo(AllocatorT* allocator, AllocatorInfo* pAllocatorInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2510, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetAllocatorInfo")]
        public unsafe partial void GetAllocatorInfo(AllocatorT* allocator, ref AllocatorInfo pAllocatorInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2510, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetAllocatorInfo")]
        public unsafe partial void GetAllocatorInfo(ref AllocatorT allocator, AllocatorInfo* pAllocatorInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2510, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetAllocatorInfo")]
        public partial void GetAllocatorInfo(ref AllocatorT allocator, ref AllocatorInfo pAllocatorInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2516, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetPhysicalDeviceProperties")]
        public unsafe partial void GetPhysicalDeviceProperties(AllocatorT* allocator, PhysicalDeviceProperties** ppPhysicalDeviceProperties);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2516, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetPhysicalDeviceProperties")]
        public unsafe partial void GetPhysicalDeviceProperties(AllocatorT* allocator, ref PhysicalDeviceProperties* ppPhysicalDeviceProperties);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2516, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetPhysicalDeviceProperties")]
        public unsafe partial void GetPhysicalDeviceProperties(ref AllocatorT allocator, PhysicalDeviceProperties** ppPhysicalDeviceProperties);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2516, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetPhysicalDeviceProperties")]
        public unsafe partial void GetPhysicalDeviceProperties(ref AllocatorT allocator, ref PhysicalDeviceProperties* ppPhysicalDeviceProperties);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2524, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetMemoryProperties")]
        public unsafe partial void GetMemoryProperties(AllocatorT* allocator, PhysicalDeviceMemoryProperties** ppPhysicalDeviceMemoryProperties);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2524, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetMemoryProperties")]
        public unsafe partial void GetMemoryProperties(AllocatorT* allocator, ref PhysicalDeviceMemoryProperties* ppPhysicalDeviceMemoryProperties);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2524, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetMemoryProperties")]
        public unsafe partial void GetMemoryProperties(ref AllocatorT allocator, PhysicalDeviceMemoryProperties** ppPhysicalDeviceMemoryProperties);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2524, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetMemoryProperties")]
        public unsafe partial void GetMemoryProperties(ref AllocatorT allocator, ref PhysicalDeviceMemoryProperties* ppPhysicalDeviceMemoryProperties);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2534, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetMemoryTypeProperties")]
        public unsafe partial void GetMemoryTypeProperties(AllocatorT* allocator, uint memoryTypeIndex, uint* pFlags);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2534, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetMemoryTypeProperties")]
        public unsafe partial void GetMemoryTypeProperties(AllocatorT* allocator, uint memoryTypeIndex, ref uint pFlags);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2534, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetMemoryTypeProperties")]
        public unsafe partial void GetMemoryTypeProperties(ref AllocatorT allocator, uint memoryTypeIndex, uint* pFlags);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2534, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetMemoryTypeProperties")]
        public partial void GetMemoryTypeProperties(ref AllocatorT allocator, uint memoryTypeIndex, ref uint pFlags);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2547, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaSetCurrentFrameIndex")]
        public unsafe partial void SetCurrentFrameIndex(AllocatorT* allocator, uint frameIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2547, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaSetCurrentFrameIndex")]
        public partial void SetCurrentFrameIndex(ref AllocatorT allocator, uint frameIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2586, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCalculateStats")]
        public unsafe partial void CalculateStats(AllocatorT* allocator, Stats* pStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2586, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCalculateStats")]
        public unsafe partial void CalculateStats(AllocatorT* allocator, ref Stats pStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2586, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCalculateStats")]
        public unsafe partial void CalculateStats(ref AllocatorT allocator, Stats* pStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2586, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCalculateStats")]
        public partial void CalculateStats(ref AllocatorT allocator, ref Stats pStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2641, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetBudget")]
        public unsafe partial void GetBudget(AllocatorT* allocator, Budget* pBudget);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2641, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetBudget")]
        public unsafe partial void GetBudget(AllocatorT* allocator, ref Budget pBudget);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2641, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetBudget")]
        public unsafe partial void GetBudget(ref AllocatorT allocator, Budget* pBudget);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2641, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetBudget")]
        public partial void GetBudget(ref AllocatorT allocator, ref Budget pBudget);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2654, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaBuildStatsString")]
        public unsafe partial void BuildStatsString(AllocatorT* allocator, byte** ppStatsString, uint detailedMap);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2654, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaBuildStatsString")]
        public unsafe partial void BuildStatsString(AllocatorT* allocator, ref byte* ppStatsString, uint detailedMap);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2654, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaBuildStatsString")]
        public unsafe partial void BuildStatsString(ref AllocatorT allocator, byte** ppStatsString, uint detailedMap);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2654, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaBuildStatsString")]
        public unsafe partial void BuildStatsString(ref AllocatorT allocator, ref byte* ppStatsString, uint detailedMap);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2659, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFreeStatsString")]
        public unsafe partial void FreeStatsString(AllocatorT* allocator, byte* pStatsString);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2659, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFreeStatsString")]
        public unsafe partial void FreeStatsString(AllocatorT* allocator, ref byte pStatsString);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2659, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFreeStatsString")]
        public unsafe partial void FreeStatsString(AllocatorT* allocator, string pStatsString);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2659, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFreeStatsString")]
        public unsafe partial void FreeStatsString(ref AllocatorT allocator, byte* pStatsString);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2659, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFreeStatsString")]
        public partial void FreeStatsString(ref AllocatorT allocator, ref byte pStatsString);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2659, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFreeStatsString")]
        public partial void FreeStatsString(ref AllocatorT allocator, string pStatsString);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2913, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFindMemoryTypeIndex")]
        public unsafe partial Result FindMemoryTypeIndex(AllocatorT* allocator, uint memoryTypeBits, AllocationCreateInfo* pAllocationCreateInfo, uint* pMemoryTypeIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2913, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFindMemoryTypeIndex")]
        public unsafe partial Result FindMemoryTypeIndex(AllocatorT* allocator, uint memoryTypeBits, AllocationCreateInfo* pAllocationCreateInfo, ref uint pMemoryTypeIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2913, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFindMemoryTypeIndex")]
        public unsafe partial Result FindMemoryTypeIndex(AllocatorT* allocator, uint memoryTypeBits, ref AllocationCreateInfo pAllocationCreateInfo, uint* pMemoryTypeIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2913, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFindMemoryTypeIndex")]
        public unsafe partial Result FindMemoryTypeIndex(AllocatorT* allocator, uint memoryTypeBits, ref AllocationCreateInfo pAllocationCreateInfo, ref uint pMemoryTypeIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2913, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFindMemoryTypeIndex")]
        public unsafe partial Result FindMemoryTypeIndex(ref AllocatorT allocator, uint memoryTypeBits, AllocationCreateInfo* pAllocationCreateInfo, uint* pMemoryTypeIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2913, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFindMemoryTypeIndex")]
        public unsafe partial Result FindMemoryTypeIndex(ref AllocatorT allocator, uint memoryTypeBits, AllocationCreateInfo* pAllocationCreateInfo, ref uint pMemoryTypeIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2913, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFindMemoryTypeIndex")]
        public unsafe partial Result FindMemoryTypeIndex(ref AllocatorT allocator, uint memoryTypeBits, ref AllocationCreateInfo pAllocationCreateInfo, uint* pMemoryTypeIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2913, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFindMemoryTypeIndex")]
        public partial Result FindMemoryTypeIndex(ref AllocatorT allocator, uint memoryTypeBits, ref AllocationCreateInfo pAllocationCreateInfo, ref uint pMemoryTypeIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2931, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFindMemoryTypeIndexForBufferInfo")]
        public unsafe partial Result FindMemoryTypeIndexForBufferInfo(AllocatorT* allocator, BufferCreateInfo* pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, uint* pMemoryTypeIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2931, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFindMemoryTypeIndexForBufferInfo")]
        public unsafe partial Result FindMemoryTypeIndexForBufferInfo(AllocatorT* allocator, BufferCreateInfo* pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ref uint pMemoryTypeIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2931, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFindMemoryTypeIndexForBufferInfo")]
        public unsafe partial Result FindMemoryTypeIndexForBufferInfo(AllocatorT* allocator, BufferCreateInfo* pBufferCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, uint* pMemoryTypeIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2931, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFindMemoryTypeIndexForBufferInfo")]
        public unsafe partial Result FindMemoryTypeIndexForBufferInfo(AllocatorT* allocator, BufferCreateInfo* pBufferCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ref uint pMemoryTypeIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2931, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFindMemoryTypeIndexForBufferInfo")]
        public unsafe partial Result FindMemoryTypeIndexForBufferInfo(AllocatorT* allocator, ref BufferCreateInfo pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, uint* pMemoryTypeIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2931, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFindMemoryTypeIndexForBufferInfo")]
        public unsafe partial Result FindMemoryTypeIndexForBufferInfo(AllocatorT* allocator, ref BufferCreateInfo pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ref uint pMemoryTypeIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2931, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFindMemoryTypeIndexForBufferInfo")]
        public unsafe partial Result FindMemoryTypeIndexForBufferInfo(AllocatorT* allocator, ref BufferCreateInfo pBufferCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, uint* pMemoryTypeIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2931, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFindMemoryTypeIndexForBufferInfo")]
        public unsafe partial Result FindMemoryTypeIndexForBufferInfo(AllocatorT* allocator, ref BufferCreateInfo pBufferCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ref uint pMemoryTypeIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2931, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFindMemoryTypeIndexForBufferInfo")]
        public unsafe partial Result FindMemoryTypeIndexForBufferInfo(ref AllocatorT allocator, BufferCreateInfo* pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, uint* pMemoryTypeIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2931, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFindMemoryTypeIndexForBufferInfo")]
        public unsafe partial Result FindMemoryTypeIndexForBufferInfo(ref AllocatorT allocator, BufferCreateInfo* pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ref uint pMemoryTypeIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2931, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFindMemoryTypeIndexForBufferInfo")]
        public unsafe partial Result FindMemoryTypeIndexForBufferInfo(ref AllocatorT allocator, BufferCreateInfo* pBufferCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, uint* pMemoryTypeIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2931, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFindMemoryTypeIndexForBufferInfo")]
        public unsafe partial Result FindMemoryTypeIndexForBufferInfo(ref AllocatorT allocator, BufferCreateInfo* pBufferCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ref uint pMemoryTypeIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2931, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFindMemoryTypeIndexForBufferInfo")]
        public unsafe partial Result FindMemoryTypeIndexForBufferInfo(ref AllocatorT allocator, ref BufferCreateInfo pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, uint* pMemoryTypeIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2931, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFindMemoryTypeIndexForBufferInfo")]
        public unsafe partial Result FindMemoryTypeIndexForBufferInfo(ref AllocatorT allocator, ref BufferCreateInfo pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ref uint pMemoryTypeIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2931, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFindMemoryTypeIndexForBufferInfo")]
        public unsafe partial Result FindMemoryTypeIndexForBufferInfo(ref AllocatorT allocator, ref BufferCreateInfo pBufferCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, uint* pMemoryTypeIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2931, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFindMemoryTypeIndexForBufferInfo")]
        public partial Result FindMemoryTypeIndexForBufferInfo(ref AllocatorT allocator, ref BufferCreateInfo pBufferCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ref uint pMemoryTypeIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2949, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFindMemoryTypeIndexForImageInfo")]
        public unsafe partial Result FindMemoryTypeIndexForImageInfo(AllocatorT* allocator, ImageCreateInfo* pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, uint* pMemoryTypeIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2949, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFindMemoryTypeIndexForImageInfo")]
        public unsafe partial Result FindMemoryTypeIndexForImageInfo(AllocatorT* allocator, ImageCreateInfo* pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ref uint pMemoryTypeIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2949, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFindMemoryTypeIndexForImageInfo")]
        public unsafe partial Result FindMemoryTypeIndexForImageInfo(AllocatorT* allocator, ImageCreateInfo* pImageCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, uint* pMemoryTypeIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2949, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFindMemoryTypeIndexForImageInfo")]
        public unsafe partial Result FindMemoryTypeIndexForImageInfo(AllocatorT* allocator, ImageCreateInfo* pImageCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ref uint pMemoryTypeIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2949, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFindMemoryTypeIndexForImageInfo")]
        public unsafe partial Result FindMemoryTypeIndexForImageInfo(AllocatorT* allocator, ref ImageCreateInfo pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, uint* pMemoryTypeIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2949, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFindMemoryTypeIndexForImageInfo")]
        public unsafe partial Result FindMemoryTypeIndexForImageInfo(AllocatorT* allocator, ref ImageCreateInfo pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ref uint pMemoryTypeIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2949, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFindMemoryTypeIndexForImageInfo")]
        public unsafe partial Result FindMemoryTypeIndexForImageInfo(AllocatorT* allocator, ref ImageCreateInfo pImageCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, uint* pMemoryTypeIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2949, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFindMemoryTypeIndexForImageInfo")]
        public unsafe partial Result FindMemoryTypeIndexForImageInfo(AllocatorT* allocator, ref ImageCreateInfo pImageCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ref uint pMemoryTypeIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2949, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFindMemoryTypeIndexForImageInfo")]
        public unsafe partial Result FindMemoryTypeIndexForImageInfo(ref AllocatorT allocator, ImageCreateInfo* pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, uint* pMemoryTypeIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2949, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFindMemoryTypeIndexForImageInfo")]
        public unsafe partial Result FindMemoryTypeIndexForImageInfo(ref AllocatorT allocator, ImageCreateInfo* pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ref uint pMemoryTypeIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2949, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFindMemoryTypeIndexForImageInfo")]
        public unsafe partial Result FindMemoryTypeIndexForImageInfo(ref AllocatorT allocator, ImageCreateInfo* pImageCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, uint* pMemoryTypeIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2949, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFindMemoryTypeIndexForImageInfo")]
        public unsafe partial Result FindMemoryTypeIndexForImageInfo(ref AllocatorT allocator, ImageCreateInfo* pImageCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ref uint pMemoryTypeIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2949, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFindMemoryTypeIndexForImageInfo")]
        public unsafe partial Result FindMemoryTypeIndexForImageInfo(ref AllocatorT allocator, ref ImageCreateInfo pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, uint* pMemoryTypeIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2949, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFindMemoryTypeIndexForImageInfo")]
        public unsafe partial Result FindMemoryTypeIndexForImageInfo(ref AllocatorT allocator, ref ImageCreateInfo pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ref uint pMemoryTypeIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2949, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFindMemoryTypeIndexForImageInfo")]
        public unsafe partial Result FindMemoryTypeIndexForImageInfo(ref AllocatorT allocator, ref ImageCreateInfo pImageCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, uint* pMemoryTypeIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2949, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFindMemoryTypeIndexForImageInfo")]
        public partial Result FindMemoryTypeIndexForImageInfo(ref AllocatorT allocator, ref ImageCreateInfo pImageCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ref uint pMemoryTypeIndex);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3094, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreatePool")]
        public unsafe partial Result CreatePool(AllocatorT* allocator, PoolCreateInfo* pCreateInfo, PoolT** pPool);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3094, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreatePool")]
        public unsafe partial Result CreatePool(AllocatorT* allocator, PoolCreateInfo* pCreateInfo, ref PoolT* pPool);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3094, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreatePool")]
        public unsafe partial Result CreatePool(AllocatorT* allocator, ref PoolCreateInfo pCreateInfo, PoolT** pPool);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3094, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreatePool")]
        public unsafe partial Result CreatePool(AllocatorT* allocator, ref PoolCreateInfo pCreateInfo, ref PoolT* pPool);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3094, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreatePool")]
        public unsafe partial Result CreatePool(ref AllocatorT allocator, PoolCreateInfo* pCreateInfo, PoolT** pPool);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3094, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreatePool")]
        public unsafe partial Result CreatePool(ref AllocatorT allocator, PoolCreateInfo* pCreateInfo, ref PoolT* pPool);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3094, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreatePool")]
        public unsafe partial Result CreatePool(ref AllocatorT allocator, ref PoolCreateInfo pCreateInfo, PoolT** pPool);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3094, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreatePool")]
        public unsafe partial Result CreatePool(ref AllocatorT allocator, ref PoolCreateInfo pCreateInfo, ref PoolT* pPool);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3101, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDestroyPool")]
        public unsafe partial void DestroyPool(AllocatorT* allocator, PoolT* pool);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3101, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDestroyPool")]
        public unsafe partial void DestroyPool(AllocatorT* allocator, ref PoolT pool);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3101, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDestroyPool")]
        public unsafe partial void DestroyPool(ref AllocatorT allocator, PoolT* pool);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3101, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDestroyPool")]
        public partial void DestroyPool(ref AllocatorT allocator, ref PoolT pool);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3111, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetPoolStats")]
        public unsafe partial void GetPoolStats(AllocatorT* allocator, PoolT* pool, PoolStats* pPoolStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3111, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetPoolStats")]
        public unsafe partial void GetPoolStats(AllocatorT* allocator, PoolT* pool, ref PoolStats pPoolStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3111, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetPoolStats")]
        public unsafe partial void GetPoolStats(AllocatorT* allocator, ref PoolT pool, PoolStats* pPoolStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3111, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetPoolStats")]
        public unsafe partial void GetPoolStats(AllocatorT* allocator, ref PoolT pool, ref PoolStats pPoolStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3111, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetPoolStats")]
        public unsafe partial void GetPoolStats(ref AllocatorT allocator, PoolT* pool, PoolStats* pPoolStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3111, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetPoolStats")]
        public unsafe partial void GetPoolStats(ref AllocatorT allocator, PoolT* pool, ref PoolStats pPoolStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3111, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetPoolStats")]
        public unsafe partial void GetPoolStats(ref AllocatorT allocator, ref PoolT pool, PoolStats* pPoolStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3111, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetPoolStats")]
        public partial void GetPoolStats(ref AllocatorT allocator, ref PoolT pool, ref PoolStats pPoolStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3122, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaMakePoolAllocationsLost")]
        public unsafe partial void MakePoolAllocationsLost(AllocatorT* allocator, PoolT* pool, uint* pLostAllocationCount);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3122, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaMakePoolAllocationsLost")]
        public unsafe partial void MakePoolAllocationsLost(AllocatorT* allocator, PoolT* pool, ref uint pLostAllocationCount);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3122, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaMakePoolAllocationsLost")]
        public unsafe partial void MakePoolAllocationsLost(AllocatorT* allocator, ref PoolT pool, uint* pLostAllocationCount);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3122, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaMakePoolAllocationsLost")]
        public unsafe partial void MakePoolAllocationsLost(AllocatorT* allocator, ref PoolT pool, ref uint pLostAllocationCount);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3122, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaMakePoolAllocationsLost")]
        public unsafe partial void MakePoolAllocationsLost(ref AllocatorT allocator, PoolT* pool, uint* pLostAllocationCount);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3122, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaMakePoolAllocationsLost")]
        public unsafe partial void MakePoolAllocationsLost(ref AllocatorT allocator, PoolT* pool, ref uint pLostAllocationCount);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3122, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaMakePoolAllocationsLost")]
        public unsafe partial void MakePoolAllocationsLost(ref AllocatorT allocator, ref PoolT pool, uint* pLostAllocationCount);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3122, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaMakePoolAllocationsLost")]
        public partial void MakePoolAllocationsLost(ref AllocatorT allocator, ref PoolT pool, ref uint pLostAllocationCount);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3141, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCheckPoolCorruption")]
        public unsafe partial Result CheckPoolCorruption(AllocatorT* allocator, PoolT* pool);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3141, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCheckPoolCorruption")]
        public unsafe partial Result CheckPoolCorruption(AllocatorT* allocator, ref PoolT pool);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3141, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCheckPoolCorruption")]
        public unsafe partial Result CheckPoolCorruption(ref AllocatorT allocator, PoolT* pool);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3141, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCheckPoolCorruption")]
        public partial Result CheckPoolCorruption(ref AllocatorT allocator, ref PoolT pool);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3149, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetPoolName")]
        public unsafe partial void GetPoolName(AllocatorT* allocator, PoolT* pool, byte** ppName);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3149, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetPoolName")]
        public unsafe partial void GetPoolName(AllocatorT* allocator, PoolT* pool, ref byte* ppName);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3149, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetPoolName")]
        public unsafe partial void GetPoolName(AllocatorT* allocator, ref PoolT pool, byte** ppName);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3149, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetPoolName")]
        public unsafe partial void GetPoolName(AllocatorT* allocator, ref PoolT pool, ref byte* ppName);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3149, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetPoolName")]
        public unsafe partial void GetPoolName(ref AllocatorT allocator, PoolT* pool, byte** ppName);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3149, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetPoolName")]
        public unsafe partial void GetPoolName(ref AllocatorT allocator, PoolT* pool, ref byte* ppName);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3149, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetPoolName")]
        public unsafe partial void GetPoolName(ref AllocatorT allocator, ref PoolT pool, byte** ppName);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3149, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetPoolName")]
        public unsafe partial void GetPoolName(ref AllocatorT allocator, ref PoolT pool, ref byte* ppName);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3159, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaSetPoolName")]
        public unsafe partial void SetPoolName(AllocatorT* allocator, PoolT* pool, byte* pName);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3159, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaSetPoolName")]
        public unsafe partial void SetPoolName(AllocatorT* allocator, PoolT* pool, ref byte pName);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3159, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaSetPoolName")]
        public unsafe partial void SetPoolName(AllocatorT* allocator, PoolT* pool, string pName);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3159, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaSetPoolName")]
        public unsafe partial void SetPoolName(AllocatorT* allocator, ref PoolT pool, byte* pName);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3159, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaSetPoolName")]
        public unsafe partial void SetPoolName(AllocatorT* allocator, ref PoolT pool, ref byte pName);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3159, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaSetPoolName")]
        public unsafe partial void SetPoolName(AllocatorT* allocator, ref PoolT pool, string pName);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3159, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaSetPoolName")]
        public unsafe partial void SetPoolName(ref AllocatorT allocator, PoolT* pool, byte* pName);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3159, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaSetPoolName")]
        public unsafe partial void SetPoolName(ref AllocatorT allocator, PoolT* pool, ref byte pName);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3159, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaSetPoolName")]
        public unsafe partial void SetPoolName(ref AllocatorT allocator, PoolT* pool, string pName);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3159, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaSetPoolName")]
        public unsafe partial void SetPoolName(ref AllocatorT allocator, ref PoolT pool, byte* pName);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3159, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaSetPoolName")]
        public partial void SetPoolName(ref AllocatorT allocator, ref PoolT pool, ref byte pName);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3159, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaSetPoolName")]
        public partial void SetPoolName(ref AllocatorT allocator, ref PoolT pool, string pName);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemory")]
        public unsafe partial Result AllocateMemory(AllocatorT* allocator, MemoryRequirements* pMemoryRequirements, AllocationCreateInfo* pCreateInfo, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemory")]
        public unsafe partial Result AllocateMemory(AllocatorT* allocator, MemoryRequirements* pMemoryRequirements, AllocationCreateInfo* pCreateInfo, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemory")]
        public unsafe partial Result AllocateMemory(AllocatorT* allocator, MemoryRequirements* pMemoryRequirements, AllocationCreateInfo* pCreateInfo, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemory")]
        public unsafe partial Result AllocateMemory(AllocatorT* allocator, MemoryRequirements* pMemoryRequirements, AllocationCreateInfo* pCreateInfo, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemory")]
        public unsafe partial Result AllocateMemory(AllocatorT* allocator, MemoryRequirements* pMemoryRequirements, ref AllocationCreateInfo pCreateInfo, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemory")]
        public unsafe partial Result AllocateMemory(AllocatorT* allocator, MemoryRequirements* pMemoryRequirements, ref AllocationCreateInfo pCreateInfo, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemory")]
        public unsafe partial Result AllocateMemory(AllocatorT* allocator, MemoryRequirements* pMemoryRequirements, ref AllocationCreateInfo pCreateInfo, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemory")]
        public unsafe partial Result AllocateMemory(AllocatorT* allocator, MemoryRequirements* pMemoryRequirements, ref AllocationCreateInfo pCreateInfo, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemory")]
        public unsafe partial Result AllocateMemory(AllocatorT* allocator, ref MemoryRequirements pMemoryRequirements, AllocationCreateInfo* pCreateInfo, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemory")]
        public unsafe partial Result AllocateMemory(AllocatorT* allocator, ref MemoryRequirements pMemoryRequirements, AllocationCreateInfo* pCreateInfo, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemory")]
        public unsafe partial Result AllocateMemory(AllocatorT* allocator, ref MemoryRequirements pMemoryRequirements, AllocationCreateInfo* pCreateInfo, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemory")]
        public unsafe partial Result AllocateMemory(AllocatorT* allocator, ref MemoryRequirements pMemoryRequirements, AllocationCreateInfo* pCreateInfo, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemory")]
        public unsafe partial Result AllocateMemory(AllocatorT* allocator, ref MemoryRequirements pMemoryRequirements, ref AllocationCreateInfo pCreateInfo, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemory")]
        public unsafe partial Result AllocateMemory(AllocatorT* allocator, ref MemoryRequirements pMemoryRequirements, ref AllocationCreateInfo pCreateInfo, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemory")]
        public unsafe partial Result AllocateMemory(AllocatorT* allocator, ref MemoryRequirements pMemoryRequirements, ref AllocationCreateInfo pCreateInfo, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemory")]
        public unsafe partial Result AllocateMemory(AllocatorT* allocator, ref MemoryRequirements pMemoryRequirements, ref AllocationCreateInfo pCreateInfo, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemory")]
        public unsafe partial Result AllocateMemory(ref AllocatorT allocator, MemoryRequirements* pMemoryRequirements, AllocationCreateInfo* pCreateInfo, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemory")]
        public unsafe partial Result AllocateMemory(ref AllocatorT allocator, MemoryRequirements* pMemoryRequirements, AllocationCreateInfo* pCreateInfo, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemory")]
        public unsafe partial Result AllocateMemory(ref AllocatorT allocator, MemoryRequirements* pMemoryRequirements, AllocationCreateInfo* pCreateInfo, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemory")]
        public unsafe partial Result AllocateMemory(ref AllocatorT allocator, MemoryRequirements* pMemoryRequirements, AllocationCreateInfo* pCreateInfo, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemory")]
        public unsafe partial Result AllocateMemory(ref AllocatorT allocator, MemoryRequirements* pMemoryRequirements, ref AllocationCreateInfo pCreateInfo, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemory")]
        public unsafe partial Result AllocateMemory(ref AllocatorT allocator, MemoryRequirements* pMemoryRequirements, ref AllocationCreateInfo pCreateInfo, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemory")]
        public unsafe partial Result AllocateMemory(ref AllocatorT allocator, MemoryRequirements* pMemoryRequirements, ref AllocationCreateInfo pCreateInfo, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemory")]
        public unsafe partial Result AllocateMemory(ref AllocatorT allocator, MemoryRequirements* pMemoryRequirements, ref AllocationCreateInfo pCreateInfo, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemory")]
        public unsafe partial Result AllocateMemory(ref AllocatorT allocator, ref MemoryRequirements pMemoryRequirements, AllocationCreateInfo* pCreateInfo, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemory")]
        public unsafe partial Result AllocateMemory(ref AllocatorT allocator, ref MemoryRequirements pMemoryRequirements, AllocationCreateInfo* pCreateInfo, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemory")]
        public unsafe partial Result AllocateMemory(ref AllocatorT allocator, ref MemoryRequirements pMemoryRequirements, AllocationCreateInfo* pCreateInfo, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemory")]
        public unsafe partial Result AllocateMemory(ref AllocatorT allocator, ref MemoryRequirements pMemoryRequirements, AllocationCreateInfo* pCreateInfo, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemory")]
        public unsafe partial Result AllocateMemory(ref AllocatorT allocator, ref MemoryRequirements pMemoryRequirements, ref AllocationCreateInfo pCreateInfo, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemory")]
        public unsafe partial Result AllocateMemory(ref AllocatorT allocator, ref MemoryRequirements pMemoryRequirements, ref AllocationCreateInfo pCreateInfo, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemory")]
        public unsafe partial Result AllocateMemory(ref AllocatorT allocator, ref MemoryRequirements pMemoryRequirements, ref AllocationCreateInfo pCreateInfo, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemory")]
        public unsafe partial Result AllocateMemory(ref AllocatorT allocator, ref MemoryRequirements pMemoryRequirements, ref AllocationCreateInfo pCreateInfo, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryPages")]
        public unsafe partial Result AllocateMemoryPages(AllocatorT* allocator, MemoryRequirements* pMemoryRequirements, AllocationCreateInfo* pCreateInfo, uint allocationCount, AllocationT** pAllocations, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryPages")]
        public unsafe partial Result AllocateMemoryPages(AllocatorT* allocator, MemoryRequirements* pMemoryRequirements, AllocationCreateInfo* pCreateInfo, uint allocationCount, AllocationT** pAllocations, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryPages")]
        public unsafe partial Result AllocateMemoryPages(AllocatorT* allocator, MemoryRequirements* pMemoryRequirements, AllocationCreateInfo* pCreateInfo, uint allocationCount, ref AllocationT* pAllocations, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryPages")]
        public unsafe partial Result AllocateMemoryPages(AllocatorT* allocator, MemoryRequirements* pMemoryRequirements, AllocationCreateInfo* pCreateInfo, uint allocationCount, ref AllocationT* pAllocations, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryPages")]
        public unsafe partial Result AllocateMemoryPages(AllocatorT* allocator, MemoryRequirements* pMemoryRequirements, ref AllocationCreateInfo pCreateInfo, uint allocationCount, AllocationT** pAllocations, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryPages")]
        public unsafe partial Result AllocateMemoryPages(AllocatorT* allocator, MemoryRequirements* pMemoryRequirements, ref AllocationCreateInfo pCreateInfo, uint allocationCount, AllocationT** pAllocations, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryPages")]
        public unsafe partial Result AllocateMemoryPages(AllocatorT* allocator, MemoryRequirements* pMemoryRequirements, ref AllocationCreateInfo pCreateInfo, uint allocationCount, ref AllocationT* pAllocations, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryPages")]
        public unsafe partial Result AllocateMemoryPages(AllocatorT* allocator, MemoryRequirements* pMemoryRequirements, ref AllocationCreateInfo pCreateInfo, uint allocationCount, ref AllocationT* pAllocations, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryPages")]
        public unsafe partial Result AllocateMemoryPages(AllocatorT* allocator, ref MemoryRequirements pMemoryRequirements, AllocationCreateInfo* pCreateInfo, uint allocationCount, AllocationT** pAllocations, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryPages")]
        public unsafe partial Result AllocateMemoryPages(AllocatorT* allocator, ref MemoryRequirements pMemoryRequirements, AllocationCreateInfo* pCreateInfo, uint allocationCount, AllocationT** pAllocations, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryPages")]
        public unsafe partial Result AllocateMemoryPages(AllocatorT* allocator, ref MemoryRequirements pMemoryRequirements, AllocationCreateInfo* pCreateInfo, uint allocationCount, ref AllocationT* pAllocations, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryPages")]
        public unsafe partial Result AllocateMemoryPages(AllocatorT* allocator, ref MemoryRequirements pMemoryRequirements, AllocationCreateInfo* pCreateInfo, uint allocationCount, ref AllocationT* pAllocations, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryPages")]
        public unsafe partial Result AllocateMemoryPages(AllocatorT* allocator, ref MemoryRequirements pMemoryRequirements, ref AllocationCreateInfo pCreateInfo, uint allocationCount, AllocationT** pAllocations, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryPages")]
        public unsafe partial Result AllocateMemoryPages(AllocatorT* allocator, ref MemoryRequirements pMemoryRequirements, ref AllocationCreateInfo pCreateInfo, uint allocationCount, AllocationT** pAllocations, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryPages")]
        public unsafe partial Result AllocateMemoryPages(AllocatorT* allocator, ref MemoryRequirements pMemoryRequirements, ref AllocationCreateInfo pCreateInfo, uint allocationCount, ref AllocationT* pAllocations, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryPages")]
        public unsafe partial Result AllocateMemoryPages(AllocatorT* allocator, ref MemoryRequirements pMemoryRequirements, ref AllocationCreateInfo pCreateInfo, uint allocationCount, ref AllocationT* pAllocations, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryPages")]
        public unsafe partial Result AllocateMemoryPages(ref AllocatorT allocator, MemoryRequirements* pMemoryRequirements, AllocationCreateInfo* pCreateInfo, uint allocationCount, AllocationT** pAllocations, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryPages")]
        public unsafe partial Result AllocateMemoryPages(ref AllocatorT allocator, MemoryRequirements* pMemoryRequirements, AllocationCreateInfo* pCreateInfo, uint allocationCount, AllocationT** pAllocations, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryPages")]
        public unsafe partial Result AllocateMemoryPages(ref AllocatorT allocator, MemoryRequirements* pMemoryRequirements, AllocationCreateInfo* pCreateInfo, uint allocationCount, ref AllocationT* pAllocations, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryPages")]
        public unsafe partial Result AllocateMemoryPages(ref AllocatorT allocator, MemoryRequirements* pMemoryRequirements, AllocationCreateInfo* pCreateInfo, uint allocationCount, ref AllocationT* pAllocations, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryPages")]
        public unsafe partial Result AllocateMemoryPages(ref AllocatorT allocator, MemoryRequirements* pMemoryRequirements, ref AllocationCreateInfo pCreateInfo, uint allocationCount, AllocationT** pAllocations, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryPages")]
        public unsafe partial Result AllocateMemoryPages(ref AllocatorT allocator, MemoryRequirements* pMemoryRequirements, ref AllocationCreateInfo pCreateInfo, uint allocationCount, AllocationT** pAllocations, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryPages")]
        public unsafe partial Result AllocateMemoryPages(ref AllocatorT allocator, MemoryRequirements* pMemoryRequirements, ref AllocationCreateInfo pCreateInfo, uint allocationCount, ref AllocationT* pAllocations, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryPages")]
        public unsafe partial Result AllocateMemoryPages(ref AllocatorT allocator, MemoryRequirements* pMemoryRequirements, ref AllocationCreateInfo pCreateInfo, uint allocationCount, ref AllocationT* pAllocations, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryPages")]
        public unsafe partial Result AllocateMemoryPages(ref AllocatorT allocator, ref MemoryRequirements pMemoryRequirements, AllocationCreateInfo* pCreateInfo, uint allocationCount, AllocationT** pAllocations, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryPages")]
        public unsafe partial Result AllocateMemoryPages(ref AllocatorT allocator, ref MemoryRequirements pMemoryRequirements, AllocationCreateInfo* pCreateInfo, uint allocationCount, AllocationT** pAllocations, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryPages")]
        public unsafe partial Result AllocateMemoryPages(ref AllocatorT allocator, ref MemoryRequirements pMemoryRequirements, AllocationCreateInfo* pCreateInfo, uint allocationCount, ref AllocationT* pAllocations, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryPages")]
        public unsafe partial Result AllocateMemoryPages(ref AllocatorT allocator, ref MemoryRequirements pMemoryRequirements, AllocationCreateInfo* pCreateInfo, uint allocationCount, ref AllocationT* pAllocations, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryPages")]
        public unsafe partial Result AllocateMemoryPages(ref AllocatorT allocator, ref MemoryRequirements pMemoryRequirements, ref AllocationCreateInfo pCreateInfo, uint allocationCount, AllocationT** pAllocations, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryPages")]
        public unsafe partial Result AllocateMemoryPages(ref AllocatorT allocator, ref MemoryRequirements pMemoryRequirements, ref AllocationCreateInfo pCreateInfo, uint allocationCount, AllocationT** pAllocations, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryPages")]
        public unsafe partial Result AllocateMemoryPages(ref AllocatorT allocator, ref MemoryRequirements pMemoryRequirements, ref AllocationCreateInfo pCreateInfo, uint allocationCount, ref AllocationT* pAllocations, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryPages")]
        public unsafe partial Result AllocateMemoryPages(ref AllocatorT allocator, ref MemoryRequirements pMemoryRequirements, ref AllocationCreateInfo pCreateInfo, uint allocationCount, ref AllocationT* pAllocations, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3294, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryForBuffer")]
        public unsafe partial Result AllocateMemoryForBuffer(AllocatorT* allocator, ulong buffer, AllocationCreateInfo* pCreateInfo, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3294, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryForBuffer")]
        public unsafe partial Result AllocateMemoryForBuffer(AllocatorT* allocator, ulong buffer, AllocationCreateInfo* pCreateInfo, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3294, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryForBuffer")]
        public unsafe partial Result AllocateMemoryForBuffer(AllocatorT* allocator, ulong buffer, AllocationCreateInfo* pCreateInfo, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3294, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryForBuffer")]
        public unsafe partial Result AllocateMemoryForBuffer(AllocatorT* allocator, ulong buffer, AllocationCreateInfo* pCreateInfo, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3294, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryForBuffer")]
        public unsafe partial Result AllocateMemoryForBuffer(AllocatorT* allocator, ulong buffer, ref AllocationCreateInfo pCreateInfo, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3294, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryForBuffer")]
        public unsafe partial Result AllocateMemoryForBuffer(AllocatorT* allocator, ulong buffer, ref AllocationCreateInfo pCreateInfo, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3294, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryForBuffer")]
        public unsafe partial Result AllocateMemoryForBuffer(AllocatorT* allocator, ulong buffer, ref AllocationCreateInfo pCreateInfo, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3294, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryForBuffer")]
        public unsafe partial Result AllocateMemoryForBuffer(AllocatorT* allocator, ulong buffer, ref AllocationCreateInfo pCreateInfo, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3294, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryForBuffer")]
        public unsafe partial Result AllocateMemoryForBuffer(ref AllocatorT allocator, ulong buffer, AllocationCreateInfo* pCreateInfo, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3294, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryForBuffer")]
        public unsafe partial Result AllocateMemoryForBuffer(ref AllocatorT allocator, ulong buffer, AllocationCreateInfo* pCreateInfo, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3294, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryForBuffer")]
        public unsafe partial Result AllocateMemoryForBuffer(ref AllocatorT allocator, ulong buffer, AllocationCreateInfo* pCreateInfo, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3294, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryForBuffer")]
        public unsafe partial Result AllocateMemoryForBuffer(ref AllocatorT allocator, ulong buffer, AllocationCreateInfo* pCreateInfo, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3294, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryForBuffer")]
        public unsafe partial Result AllocateMemoryForBuffer(ref AllocatorT allocator, ulong buffer, ref AllocationCreateInfo pCreateInfo, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3294, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryForBuffer")]
        public unsafe partial Result AllocateMemoryForBuffer(ref AllocatorT allocator, ulong buffer, ref AllocationCreateInfo pCreateInfo, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3294, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryForBuffer")]
        public unsafe partial Result AllocateMemoryForBuffer(ref AllocatorT allocator, ulong buffer, ref AllocationCreateInfo pCreateInfo, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3294, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryForBuffer")]
        public unsafe partial Result AllocateMemoryForBuffer(ref AllocatorT allocator, ulong buffer, ref AllocationCreateInfo pCreateInfo, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3302, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryForImage")]
        public unsafe partial Result AllocateMemoryForImage(AllocatorT* allocator, ulong image, AllocationCreateInfo* pCreateInfo, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3302, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryForImage")]
        public unsafe partial Result AllocateMemoryForImage(AllocatorT* allocator, ulong image, AllocationCreateInfo* pCreateInfo, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3302, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryForImage")]
        public unsafe partial Result AllocateMemoryForImage(AllocatorT* allocator, ulong image, AllocationCreateInfo* pCreateInfo, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3302, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryForImage")]
        public unsafe partial Result AllocateMemoryForImage(AllocatorT* allocator, ulong image, AllocationCreateInfo* pCreateInfo, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3302, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryForImage")]
        public unsafe partial Result AllocateMemoryForImage(AllocatorT* allocator, ulong image, ref AllocationCreateInfo pCreateInfo, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3302, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryForImage")]
        public unsafe partial Result AllocateMemoryForImage(AllocatorT* allocator, ulong image, ref AllocationCreateInfo pCreateInfo, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3302, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryForImage")]
        public unsafe partial Result AllocateMemoryForImage(AllocatorT* allocator, ulong image, ref AllocationCreateInfo pCreateInfo, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3302, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryForImage")]
        public unsafe partial Result AllocateMemoryForImage(AllocatorT* allocator, ulong image, ref AllocationCreateInfo pCreateInfo, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3302, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryForImage")]
        public unsafe partial Result AllocateMemoryForImage(ref AllocatorT allocator, ulong image, AllocationCreateInfo* pCreateInfo, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3302, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryForImage")]
        public unsafe partial Result AllocateMemoryForImage(ref AllocatorT allocator, ulong image, AllocationCreateInfo* pCreateInfo, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3302, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryForImage")]
        public unsafe partial Result AllocateMemoryForImage(ref AllocatorT allocator, ulong image, AllocationCreateInfo* pCreateInfo, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3302, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryForImage")]
        public unsafe partial Result AllocateMemoryForImage(ref AllocatorT allocator, ulong image, AllocationCreateInfo* pCreateInfo, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3302, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryForImage")]
        public unsafe partial Result AllocateMemoryForImage(ref AllocatorT allocator, ulong image, ref AllocationCreateInfo pCreateInfo, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3302, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryForImage")]
        public unsafe partial Result AllocateMemoryForImage(ref AllocatorT allocator, ulong image, ref AllocationCreateInfo pCreateInfo, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3302, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryForImage")]
        public unsafe partial Result AllocateMemoryForImage(ref AllocatorT allocator, ulong image, ref AllocationCreateInfo pCreateInfo, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3302, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaAllocateMemoryForImage")]
        public unsafe partial Result AllocateMemoryForImage(ref AllocatorT allocator, ulong image, ref AllocationCreateInfo pCreateInfo, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3313, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFreeMemory")]
        public unsafe partial void FreeMemory(AllocatorT* allocator, AllocationT* allocation);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3313, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFreeMemory")]
        public unsafe partial void FreeMemory(AllocatorT* allocator, ref AllocationT allocation);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3313, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFreeMemory")]
        public unsafe partial void FreeMemory(ref AllocatorT allocator, AllocationT* allocation);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3313, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFreeMemory")]
        public partial void FreeMemory(ref AllocatorT allocator, ref AllocationT allocation);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3327, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFreeMemoryPages")]
        public unsafe partial void FreeMemoryPages(AllocatorT* allocator, uint allocationCount, AllocationT** pAllocations);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3327, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFreeMemoryPages")]
        public unsafe partial void FreeMemoryPages(AllocatorT* allocator, uint allocationCount, ref AllocationT* pAllocations);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3327, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFreeMemoryPages")]
        public unsafe partial void FreeMemoryPages(ref AllocatorT allocator, uint allocationCount, AllocationT** pAllocations);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3327, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFreeMemoryPages")]
        public unsafe partial void FreeMemoryPages(ref AllocatorT allocator, uint allocationCount, ref AllocationT* pAllocations);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3339, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaResizeAllocation")]
        public unsafe partial Result ResizeAllocation(AllocatorT* allocator, AllocationT* allocation, ulong newSize);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3339, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaResizeAllocation")]
        public unsafe partial Result ResizeAllocation(AllocatorT* allocator, ref AllocationT allocation, ulong newSize);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3339, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaResizeAllocation")]
        public unsafe partial Result ResizeAllocation(ref AllocatorT allocator, AllocationT* allocation, ulong newSize);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3339, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaResizeAllocation")]
        public partial Result ResizeAllocation(ref AllocatorT allocator, ref AllocationT allocation, ulong newSize);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3360, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetAllocationInfo")]
        public unsafe partial void GetAllocationInfo(AllocatorT* allocator, AllocationT* allocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3360, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetAllocationInfo")]
        public unsafe partial void GetAllocationInfo(AllocatorT* allocator, AllocationT* allocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3360, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetAllocationInfo")]
        public unsafe partial void GetAllocationInfo(AllocatorT* allocator, ref AllocationT allocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3360, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetAllocationInfo")]
        public unsafe partial void GetAllocationInfo(AllocatorT* allocator, ref AllocationT allocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3360, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetAllocationInfo")]
        public unsafe partial void GetAllocationInfo(ref AllocatorT allocator, AllocationT* allocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3360, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetAllocationInfo")]
        public unsafe partial void GetAllocationInfo(ref AllocatorT allocator, AllocationT* allocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3360, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetAllocationInfo")]
        public unsafe partial void GetAllocationInfo(ref AllocatorT allocator, ref AllocationT allocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3360, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaGetAllocationInfo")]
        public partial void GetAllocationInfo(ref AllocatorT allocator, ref AllocationT allocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3379, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaTouchAllocation")]
        public unsafe partial uint TouchAllocation(AllocatorT* allocator, AllocationT* allocation);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3379, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaTouchAllocation")]
        public unsafe partial uint TouchAllocation(AllocatorT* allocator, ref AllocationT allocation);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3379, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaTouchAllocation")]
        public unsafe partial uint TouchAllocation(ref AllocatorT allocator, AllocationT* allocation);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3379, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaTouchAllocation")]
        public partial uint TouchAllocation(ref AllocatorT allocator, ref AllocationT allocation);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3396, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaSetAllocationUserData")]
        public unsafe partial void SetAllocationUserData(AllocatorT* allocator, AllocationT* allocation, void* pUserData);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3396, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaSetAllocationUserData")]
        public unsafe partial void SetAllocationUserData<T0>(AllocatorT* allocator, AllocationT* allocation, ref T0 pUserData) where T0 : unmanaged;

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3396, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaSetAllocationUserData")]
        public unsafe partial void SetAllocationUserData(AllocatorT* allocator, ref AllocationT allocation, void* pUserData);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3396, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaSetAllocationUserData")]
        public unsafe partial void SetAllocationUserData<T0>(AllocatorT* allocator, ref AllocationT allocation, ref T0 pUserData) where T0 : unmanaged;

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3396, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaSetAllocationUserData")]
        public unsafe partial void SetAllocationUserData(ref AllocatorT allocator, AllocationT* allocation, void* pUserData);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3396, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaSetAllocationUserData")]
        public unsafe partial void SetAllocationUserData<T0>(ref AllocatorT allocator, AllocationT* allocation, ref T0 pUserData) where T0 : unmanaged;

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3396, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaSetAllocationUserData")]
        public unsafe partial void SetAllocationUserData(ref AllocatorT allocator, ref AllocationT allocation, void* pUserData);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3396, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaSetAllocationUserData")]
        public partial void SetAllocationUserData<T0>(ref AllocatorT allocator, ref AllocationT allocation, ref T0 pUserData) where T0 : unmanaged;

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3411, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateLostAllocation")]
        public unsafe partial void CreateLostAllocation(AllocatorT* allocator, AllocationT** pAllocation);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3411, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateLostAllocation")]
        public unsafe partial void CreateLostAllocation(AllocatorT* allocator, ref AllocationT* pAllocation);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3411, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateLostAllocation")]
        public unsafe partial void CreateLostAllocation(ref AllocatorT allocator, AllocationT** pAllocation);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3411, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateLostAllocation")]
        public unsafe partial void CreateLostAllocation(ref AllocatorT allocator, ref AllocationT* pAllocation);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3453, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaMapMemory")]
        public unsafe partial Result MapMemory(AllocatorT* allocator, AllocationT* allocation, void** ppData);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3453, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaMapMemory")]
        public unsafe partial Result MapMemory(AllocatorT* allocator, AllocationT* allocation, ref void* ppData);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3453, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaMapMemory")]
        public unsafe partial Result MapMemory(AllocatorT* allocator, ref AllocationT allocation, void** ppData);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3453, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaMapMemory")]
        public unsafe partial Result MapMemory(AllocatorT* allocator, ref AllocationT allocation, ref void* ppData);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3453, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaMapMemory")]
        public unsafe partial Result MapMemory(ref AllocatorT allocator, AllocationT* allocation, void** ppData);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3453, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaMapMemory")]
        public unsafe partial Result MapMemory(ref AllocatorT allocator, AllocationT* allocation, ref void* ppData);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3453, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaMapMemory")]
        public unsafe partial Result MapMemory(ref AllocatorT allocator, ref AllocationT allocation, void** ppData);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3453, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaMapMemory")]
        public unsafe partial Result MapMemory(ref AllocatorT allocator, ref AllocationT allocation, ref void* ppData);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3466, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaUnmapMemory")]
        public unsafe partial void UnmapMemory(AllocatorT* allocator, AllocationT* allocation);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3466, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaUnmapMemory")]
        public unsafe partial void UnmapMemory(AllocatorT* allocator, ref AllocationT allocation);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3466, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaUnmapMemory")]
        public unsafe partial void UnmapMemory(ref AllocatorT allocator, AllocationT* allocation);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3466, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaUnmapMemory")]
        public partial void UnmapMemory(ref AllocatorT allocator, ref AllocationT allocation);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3491, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFlushAllocation")]
        public unsafe partial Result FlushAllocation(AllocatorT* allocator, AllocationT* allocation, ulong offset, ulong size);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3491, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFlushAllocation")]
        public unsafe partial Result FlushAllocation(AllocatorT* allocator, ref AllocationT allocation, ulong offset, ulong size);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3491, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFlushAllocation")]
        public unsafe partial Result FlushAllocation(ref AllocatorT allocator, AllocationT* allocation, ulong offset, ulong size);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3491, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFlushAllocation")]
        public partial Result FlushAllocation(ref AllocatorT allocator, ref AllocationT allocation, ulong offset, ulong size);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3518, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaInvalidateAllocation")]
        public unsafe partial Result InvalidateAllocation(AllocatorT* allocator, AllocationT* allocation, ulong offset, ulong size);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3518, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaInvalidateAllocation")]
        public unsafe partial Result InvalidateAllocation(AllocatorT* allocator, ref AllocationT allocation, ulong offset, ulong size);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3518, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaInvalidateAllocation")]
        public unsafe partial Result InvalidateAllocation(ref AllocatorT allocator, AllocationT* allocation, ulong offset, ulong size);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3518, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaInvalidateAllocation")]
        public partial Result InvalidateAllocation(ref AllocatorT allocator, ref AllocationT allocation, ulong offset, ulong size);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3538, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFlushAllocations")]
        public unsafe partial Result FlushAllocations(AllocatorT* allocator, uint allocationCount, AllocationT** allocations, ulong* offsets, ulong* sizes);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3538, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFlushAllocations")]
        public unsafe partial Result FlushAllocations(AllocatorT* allocator, uint allocationCount, AllocationT** allocations, ulong* offsets, ref ulong sizes);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3538, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFlushAllocations")]
        public unsafe partial Result FlushAllocations(AllocatorT* allocator, uint allocationCount, AllocationT** allocations, ref ulong offsets, ulong* sizes);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3538, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFlushAllocations")]
        public unsafe partial Result FlushAllocations(AllocatorT* allocator, uint allocationCount, AllocationT** allocations, ref ulong offsets, ref ulong sizes);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3538, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFlushAllocations")]
        public unsafe partial Result FlushAllocations(AllocatorT* allocator, uint allocationCount, ref AllocationT* allocations, ulong* offsets, ulong* sizes);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3538, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFlushAllocations")]
        public unsafe partial Result FlushAllocations(AllocatorT* allocator, uint allocationCount, ref AllocationT* allocations, ulong* offsets, ref ulong sizes);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3538, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFlushAllocations")]
        public unsafe partial Result FlushAllocations(AllocatorT* allocator, uint allocationCount, ref AllocationT* allocations, ref ulong offsets, ulong* sizes);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3538, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFlushAllocations")]
        public unsafe partial Result FlushAllocations(AllocatorT* allocator, uint allocationCount, ref AllocationT* allocations, ref ulong offsets, ref ulong sizes);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3538, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFlushAllocations")]
        public unsafe partial Result FlushAllocations(ref AllocatorT allocator, uint allocationCount, AllocationT** allocations, ulong* offsets, ulong* sizes);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3538, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFlushAllocations")]
        public unsafe partial Result FlushAllocations(ref AllocatorT allocator, uint allocationCount, AllocationT** allocations, ulong* offsets, ref ulong sizes);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3538, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFlushAllocations")]
        public unsafe partial Result FlushAllocations(ref AllocatorT allocator, uint allocationCount, AllocationT** allocations, ref ulong offsets, ulong* sizes);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3538, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFlushAllocations")]
        public unsafe partial Result FlushAllocations(ref AllocatorT allocator, uint allocationCount, AllocationT** allocations, ref ulong offsets, ref ulong sizes);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3538, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFlushAllocations")]
        public unsafe partial Result FlushAllocations(ref AllocatorT allocator, uint allocationCount, ref AllocationT* allocations, ulong* offsets, ulong* sizes);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3538, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFlushAllocations")]
        public unsafe partial Result FlushAllocations(ref AllocatorT allocator, uint allocationCount, ref AllocationT* allocations, ulong* offsets, ref ulong sizes);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3538, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFlushAllocations")]
        public unsafe partial Result FlushAllocations(ref AllocatorT allocator, uint allocationCount, ref AllocationT* allocations, ref ulong offsets, ulong* sizes);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3538, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaFlushAllocations")]
        public unsafe partial Result FlushAllocations(ref AllocatorT allocator, uint allocationCount, ref AllocationT* allocations, ref ulong offsets, ref ulong sizes);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3559, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaInvalidateAllocations")]
        public unsafe partial Result InvalidateAllocations(AllocatorT* allocator, uint allocationCount, AllocationT** allocations, ulong* offsets, ulong* sizes);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3559, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaInvalidateAllocations")]
        public unsafe partial Result InvalidateAllocations(AllocatorT* allocator, uint allocationCount, AllocationT** allocations, ulong* offsets, ref ulong sizes);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3559, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaInvalidateAllocations")]
        public unsafe partial Result InvalidateAllocations(AllocatorT* allocator, uint allocationCount, AllocationT** allocations, ref ulong offsets, ulong* sizes);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3559, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaInvalidateAllocations")]
        public unsafe partial Result InvalidateAllocations(AllocatorT* allocator, uint allocationCount, AllocationT** allocations, ref ulong offsets, ref ulong sizes);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3559, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaInvalidateAllocations")]
        public unsafe partial Result InvalidateAllocations(AllocatorT* allocator, uint allocationCount, ref AllocationT* allocations, ulong* offsets, ulong* sizes);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3559, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaInvalidateAllocations")]
        public unsafe partial Result InvalidateAllocations(AllocatorT* allocator, uint allocationCount, ref AllocationT* allocations, ulong* offsets, ref ulong sizes);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3559, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaInvalidateAllocations")]
        public unsafe partial Result InvalidateAllocations(AllocatorT* allocator, uint allocationCount, ref AllocationT* allocations, ref ulong offsets, ulong* sizes);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3559, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaInvalidateAllocations")]
        public unsafe partial Result InvalidateAllocations(AllocatorT* allocator, uint allocationCount, ref AllocationT* allocations, ref ulong offsets, ref ulong sizes);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3559, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaInvalidateAllocations")]
        public unsafe partial Result InvalidateAllocations(ref AllocatorT allocator, uint allocationCount, AllocationT** allocations, ulong* offsets, ulong* sizes);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3559, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaInvalidateAllocations")]
        public unsafe partial Result InvalidateAllocations(ref AllocatorT allocator, uint allocationCount, AllocationT** allocations, ulong* offsets, ref ulong sizes);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3559, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaInvalidateAllocations")]
        public unsafe partial Result InvalidateAllocations(ref AllocatorT allocator, uint allocationCount, AllocationT** allocations, ref ulong offsets, ulong* sizes);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3559, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaInvalidateAllocations")]
        public unsafe partial Result InvalidateAllocations(ref AllocatorT allocator, uint allocationCount, AllocationT** allocations, ref ulong offsets, ref ulong sizes);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3559, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaInvalidateAllocations")]
        public unsafe partial Result InvalidateAllocations(ref AllocatorT allocator, uint allocationCount, ref AllocationT* allocations, ulong* offsets, ulong* sizes);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3559, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaInvalidateAllocations")]
        public unsafe partial Result InvalidateAllocations(ref AllocatorT allocator, uint allocationCount, ref AllocationT* allocations, ulong* offsets, ref ulong sizes);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3559, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaInvalidateAllocations")]
        public unsafe partial Result InvalidateAllocations(ref AllocatorT allocator, uint allocationCount, ref AllocationT* allocations, ref ulong offsets, ulong* sizes);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3559, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaInvalidateAllocations")]
        public unsafe partial Result InvalidateAllocations(ref AllocatorT allocator, uint allocationCount, ref AllocationT* allocations, ref ulong offsets, ref ulong sizes);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3582, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCheckCorruption")]
        public unsafe partial Result CheckCorruption(AllocatorT* allocator, uint memoryTypeBits);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3582, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCheckCorruption")]
        public partial Result CheckCorruption(ref AllocatorT allocator, uint memoryTypeBits);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3748, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragmentationBegin")]
        public unsafe partial Result DefragmentationBegin(AllocatorT* allocator, DefragmentationInfo2* pInfo, DefragmentationStats* pStats, DefragmentationContextT** pContext);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3748, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragmentationBegin")]
        public unsafe partial Result DefragmentationBegin(AllocatorT* allocator, DefragmentationInfo2* pInfo, DefragmentationStats* pStats, ref DefragmentationContextT* pContext);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3748, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragmentationBegin")]
        public unsafe partial Result DefragmentationBegin(AllocatorT* allocator, DefragmentationInfo2* pInfo, ref DefragmentationStats pStats, DefragmentationContextT** pContext);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3748, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragmentationBegin")]
        public unsafe partial Result DefragmentationBegin(AllocatorT* allocator, DefragmentationInfo2* pInfo, ref DefragmentationStats pStats, ref DefragmentationContextT* pContext);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3748, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragmentationBegin")]
        public unsafe partial Result DefragmentationBegin(AllocatorT* allocator, ref DefragmentationInfo2 pInfo, DefragmentationStats* pStats, DefragmentationContextT** pContext);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3748, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragmentationBegin")]
        public unsafe partial Result DefragmentationBegin(AllocatorT* allocator, ref DefragmentationInfo2 pInfo, DefragmentationStats* pStats, ref DefragmentationContextT* pContext);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3748, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragmentationBegin")]
        public unsafe partial Result DefragmentationBegin(AllocatorT* allocator, ref DefragmentationInfo2 pInfo, ref DefragmentationStats pStats, DefragmentationContextT** pContext);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3748, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragmentationBegin")]
        public unsafe partial Result DefragmentationBegin(AllocatorT* allocator, ref DefragmentationInfo2 pInfo, ref DefragmentationStats pStats, ref DefragmentationContextT* pContext);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3748, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragmentationBegin")]
        public unsafe partial Result DefragmentationBegin(ref AllocatorT allocator, DefragmentationInfo2* pInfo, DefragmentationStats* pStats, DefragmentationContextT** pContext);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3748, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragmentationBegin")]
        public unsafe partial Result DefragmentationBegin(ref AllocatorT allocator, DefragmentationInfo2* pInfo, DefragmentationStats* pStats, ref DefragmentationContextT* pContext);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3748, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragmentationBegin")]
        public unsafe partial Result DefragmentationBegin(ref AllocatorT allocator, DefragmentationInfo2* pInfo, ref DefragmentationStats pStats, DefragmentationContextT** pContext);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3748, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragmentationBegin")]
        public unsafe partial Result DefragmentationBegin(ref AllocatorT allocator, DefragmentationInfo2* pInfo, ref DefragmentationStats pStats, ref DefragmentationContextT* pContext);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3748, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragmentationBegin")]
        public unsafe partial Result DefragmentationBegin(ref AllocatorT allocator, ref DefragmentationInfo2 pInfo, DefragmentationStats* pStats, DefragmentationContextT** pContext);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3748, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragmentationBegin")]
        public unsafe partial Result DefragmentationBegin(ref AllocatorT allocator, ref DefragmentationInfo2 pInfo, DefragmentationStats* pStats, ref DefragmentationContextT* pContext);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3748, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragmentationBegin")]
        public unsafe partial Result DefragmentationBegin(ref AllocatorT allocator, ref DefragmentationInfo2 pInfo, ref DefragmentationStats pStats, DefragmentationContextT** pContext);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3748, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragmentationBegin")]
        public unsafe partial Result DefragmentationBegin(ref AllocatorT allocator, ref DefragmentationInfo2 pInfo, ref DefragmentationStats pStats, ref DefragmentationContextT* pContext);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3759, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragmentationEnd")]
        public unsafe partial Result DefragmentationEnd(AllocatorT* allocator, DefragmentationContextT* context);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3759, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragmentationEnd")]
        public unsafe partial Result DefragmentationEnd(AllocatorT* allocator, ref DefragmentationContextT context);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3759, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragmentationEnd")]
        public unsafe partial Result DefragmentationEnd(ref AllocatorT allocator, DefragmentationContextT* context);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3759, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragmentationEnd")]
        public partial Result DefragmentationEnd(ref AllocatorT allocator, ref DefragmentationContextT context);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3763, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaBeginDefragmentationPass")]
        public unsafe partial Result BeginDefragmentationPass(AllocatorT* allocator, DefragmentationContextT* context, DefragmentationPassInfo* pInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3763, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaBeginDefragmentationPass")]
        public unsafe partial Result BeginDefragmentationPass(AllocatorT* allocator, DefragmentationContextT* context, ref DefragmentationPassInfo pInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3763, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaBeginDefragmentationPass")]
        public unsafe partial Result BeginDefragmentationPass(AllocatorT* allocator, ref DefragmentationContextT context, DefragmentationPassInfo* pInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3763, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaBeginDefragmentationPass")]
        public unsafe partial Result BeginDefragmentationPass(AllocatorT* allocator, ref DefragmentationContextT context, ref DefragmentationPassInfo pInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3763, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaBeginDefragmentationPass")]
        public unsafe partial Result BeginDefragmentationPass(ref AllocatorT allocator, DefragmentationContextT* context, DefragmentationPassInfo* pInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3763, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaBeginDefragmentationPass")]
        public unsafe partial Result BeginDefragmentationPass(ref AllocatorT allocator, DefragmentationContextT* context, ref DefragmentationPassInfo pInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3763, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaBeginDefragmentationPass")]
        public unsafe partial Result BeginDefragmentationPass(ref AllocatorT allocator, ref DefragmentationContextT context, DefragmentationPassInfo* pInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3763, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaBeginDefragmentationPass")]
        public partial Result BeginDefragmentationPass(ref AllocatorT allocator, ref DefragmentationContextT context, ref DefragmentationPassInfo pInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3768, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaEndDefragmentationPass")]
        public unsafe partial Result EndDefragmentationPass(AllocatorT* allocator, DefragmentationContextT* context);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3768, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaEndDefragmentationPass")]
        public unsafe partial Result EndDefragmentationPass(AllocatorT* allocator, ref DefragmentationContextT context);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3768, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaEndDefragmentationPass")]
        public unsafe partial Result EndDefragmentationPass(ref AllocatorT allocator, DefragmentationContextT* context);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3768, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaEndDefragmentationPass")]
        public partial Result EndDefragmentationPass(ref AllocatorT allocator, ref DefragmentationContextT context);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragment")]
        public unsafe partial Result Defragment(AllocatorT* allocator, AllocationT** pAllocations, uint allocationCount, uint* pAllocationsChanged, DefragmentationInfo* pDefragmentationInfo, DefragmentationStats* pDefragmentationStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragment")]
        public unsafe partial Result Defragment(AllocatorT* allocator, AllocationT** pAllocations, uint allocationCount, uint* pAllocationsChanged, DefragmentationInfo* pDefragmentationInfo, ref DefragmentationStats pDefragmentationStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragment")]
        public unsafe partial Result Defragment(AllocatorT* allocator, AllocationT** pAllocations, uint allocationCount, uint* pAllocationsChanged, ref DefragmentationInfo pDefragmentationInfo, DefragmentationStats* pDefragmentationStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragment")]
        public unsafe partial Result Defragment(AllocatorT* allocator, AllocationT** pAllocations, uint allocationCount, uint* pAllocationsChanged, ref DefragmentationInfo pDefragmentationInfo, ref DefragmentationStats pDefragmentationStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragment")]
        public unsafe partial Result Defragment(AllocatorT* allocator, AllocationT** pAllocations, uint allocationCount, ref uint pAllocationsChanged, DefragmentationInfo* pDefragmentationInfo, DefragmentationStats* pDefragmentationStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragment")]
        public unsafe partial Result Defragment(AllocatorT* allocator, AllocationT** pAllocations, uint allocationCount, ref uint pAllocationsChanged, DefragmentationInfo* pDefragmentationInfo, ref DefragmentationStats pDefragmentationStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragment")]
        public unsafe partial Result Defragment(AllocatorT* allocator, AllocationT** pAllocations, uint allocationCount, ref uint pAllocationsChanged, ref DefragmentationInfo pDefragmentationInfo, DefragmentationStats* pDefragmentationStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragment")]
        public unsafe partial Result Defragment(AllocatorT* allocator, AllocationT** pAllocations, uint allocationCount, ref uint pAllocationsChanged, ref DefragmentationInfo pDefragmentationInfo, ref DefragmentationStats pDefragmentationStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragment")]
        public unsafe partial Result Defragment(AllocatorT* allocator, ref AllocationT* pAllocations, uint allocationCount, uint* pAllocationsChanged, DefragmentationInfo* pDefragmentationInfo, DefragmentationStats* pDefragmentationStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragment")]
        public unsafe partial Result Defragment(AllocatorT* allocator, ref AllocationT* pAllocations, uint allocationCount, uint* pAllocationsChanged, DefragmentationInfo* pDefragmentationInfo, ref DefragmentationStats pDefragmentationStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragment")]
        public unsafe partial Result Defragment(AllocatorT* allocator, ref AllocationT* pAllocations, uint allocationCount, uint* pAllocationsChanged, ref DefragmentationInfo pDefragmentationInfo, DefragmentationStats* pDefragmentationStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragment")]
        public unsafe partial Result Defragment(AllocatorT* allocator, ref AllocationT* pAllocations, uint allocationCount, uint* pAllocationsChanged, ref DefragmentationInfo pDefragmentationInfo, ref DefragmentationStats pDefragmentationStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragment")]
        public unsafe partial Result Defragment(AllocatorT* allocator, ref AllocationT* pAllocations, uint allocationCount, ref uint pAllocationsChanged, DefragmentationInfo* pDefragmentationInfo, DefragmentationStats* pDefragmentationStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragment")]
        public unsafe partial Result Defragment(AllocatorT* allocator, ref AllocationT* pAllocations, uint allocationCount, ref uint pAllocationsChanged, DefragmentationInfo* pDefragmentationInfo, ref DefragmentationStats pDefragmentationStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragment")]
        public unsafe partial Result Defragment(AllocatorT* allocator, ref AllocationT* pAllocations, uint allocationCount, ref uint pAllocationsChanged, ref DefragmentationInfo pDefragmentationInfo, DefragmentationStats* pDefragmentationStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragment")]
        public unsafe partial Result Defragment(AllocatorT* allocator, ref AllocationT* pAllocations, uint allocationCount, ref uint pAllocationsChanged, ref DefragmentationInfo pDefragmentationInfo, ref DefragmentationStats pDefragmentationStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragment")]
        public unsafe partial Result Defragment(ref AllocatorT allocator, AllocationT** pAllocations, uint allocationCount, uint* pAllocationsChanged, DefragmentationInfo* pDefragmentationInfo, DefragmentationStats* pDefragmentationStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragment")]
        public unsafe partial Result Defragment(ref AllocatorT allocator, AllocationT** pAllocations, uint allocationCount, uint* pAllocationsChanged, DefragmentationInfo* pDefragmentationInfo, ref DefragmentationStats pDefragmentationStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragment")]
        public unsafe partial Result Defragment(ref AllocatorT allocator, AllocationT** pAllocations, uint allocationCount, uint* pAllocationsChanged, ref DefragmentationInfo pDefragmentationInfo, DefragmentationStats* pDefragmentationStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragment")]
        public unsafe partial Result Defragment(ref AllocatorT allocator, AllocationT** pAllocations, uint allocationCount, uint* pAllocationsChanged, ref DefragmentationInfo pDefragmentationInfo, ref DefragmentationStats pDefragmentationStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragment")]
        public unsafe partial Result Defragment(ref AllocatorT allocator, AllocationT** pAllocations, uint allocationCount, ref uint pAllocationsChanged, DefragmentationInfo* pDefragmentationInfo, DefragmentationStats* pDefragmentationStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragment")]
        public unsafe partial Result Defragment(ref AllocatorT allocator, AllocationT** pAllocations, uint allocationCount, ref uint pAllocationsChanged, DefragmentationInfo* pDefragmentationInfo, ref DefragmentationStats pDefragmentationStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragment")]
        public unsafe partial Result Defragment(ref AllocatorT allocator, AllocationT** pAllocations, uint allocationCount, ref uint pAllocationsChanged, ref DefragmentationInfo pDefragmentationInfo, DefragmentationStats* pDefragmentationStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragment")]
        public unsafe partial Result Defragment(ref AllocatorT allocator, AllocationT** pAllocations, uint allocationCount, ref uint pAllocationsChanged, ref DefragmentationInfo pDefragmentationInfo, ref DefragmentationStats pDefragmentationStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragment")]
        public unsafe partial Result Defragment(ref AllocatorT allocator, ref AllocationT* pAllocations, uint allocationCount, uint* pAllocationsChanged, DefragmentationInfo* pDefragmentationInfo, DefragmentationStats* pDefragmentationStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragment")]
        public unsafe partial Result Defragment(ref AllocatorT allocator, ref AllocationT* pAllocations, uint allocationCount, uint* pAllocationsChanged, DefragmentationInfo* pDefragmentationInfo, ref DefragmentationStats pDefragmentationStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragment")]
        public unsafe partial Result Defragment(ref AllocatorT allocator, ref AllocationT* pAllocations, uint allocationCount, uint* pAllocationsChanged, ref DefragmentationInfo pDefragmentationInfo, DefragmentationStats* pDefragmentationStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragment")]
        public unsafe partial Result Defragment(ref AllocatorT allocator, ref AllocationT* pAllocations, uint allocationCount, uint* pAllocationsChanged, ref DefragmentationInfo pDefragmentationInfo, ref DefragmentationStats pDefragmentationStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragment")]
        public unsafe partial Result Defragment(ref AllocatorT allocator, ref AllocationT* pAllocations, uint allocationCount, ref uint pAllocationsChanged, DefragmentationInfo* pDefragmentationInfo, DefragmentationStats* pDefragmentationStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragment")]
        public unsafe partial Result Defragment(ref AllocatorT allocator, ref AllocationT* pAllocations, uint allocationCount, ref uint pAllocationsChanged, DefragmentationInfo* pDefragmentationInfo, ref DefragmentationStats pDefragmentationStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragment")]
        public unsafe partial Result Defragment(ref AllocatorT allocator, ref AllocationT* pAllocations, uint allocationCount, ref uint pAllocationsChanged, ref DefragmentationInfo pDefragmentationInfo, DefragmentationStats* pDefragmentationStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDefragment")]
        public unsafe partial Result Defragment(ref AllocatorT allocator, ref AllocationT* pAllocations, uint allocationCount, ref uint pAllocationsChanged, ref DefragmentationInfo pDefragmentationInfo, ref DefragmentationStats pDefragmentationStats);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3833, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaBindBufferMemory")]
        public unsafe partial Result BindBufferMemory(AllocatorT* allocator, AllocationT* allocation, ulong buffer);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3833, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaBindBufferMemory")]
        public unsafe partial Result BindBufferMemory(AllocatorT* allocator, ref AllocationT allocation, ulong buffer);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3833, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaBindBufferMemory")]
        public unsafe partial Result BindBufferMemory(ref AllocatorT allocator, AllocationT* allocation, ulong buffer);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3833, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaBindBufferMemory")]
        public partial Result BindBufferMemory(ref AllocatorT allocator, ref AllocationT allocation, ulong buffer);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3848, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaBindBufferMemory2")]
        public unsafe partial Result BindBufferMemory2(AllocatorT* allocator, AllocationT* allocation, ulong allocationLocalOffset, ulong buffer, void* pNext);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3848, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaBindBufferMemory2")]
        public unsafe partial Result BindBufferMemory2<T0>(AllocatorT* allocator, AllocationT* allocation, ulong allocationLocalOffset, ulong buffer, ref T0 pNext) where T0 : unmanaged;

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3848, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaBindBufferMemory2")]
        public unsafe partial Result BindBufferMemory2(AllocatorT* allocator, ref AllocationT allocation, ulong allocationLocalOffset, ulong buffer, void* pNext);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3848, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaBindBufferMemory2")]
        public unsafe partial Result BindBufferMemory2<T0>(AllocatorT* allocator, ref AllocationT allocation, ulong allocationLocalOffset, ulong buffer, ref T0 pNext) where T0 : unmanaged;

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3848, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaBindBufferMemory2")]
        public unsafe partial Result BindBufferMemory2(ref AllocatorT allocator, AllocationT* allocation, ulong allocationLocalOffset, ulong buffer, void* pNext);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3848, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaBindBufferMemory2")]
        public unsafe partial Result BindBufferMemory2<T0>(ref AllocatorT allocator, AllocationT* allocation, ulong allocationLocalOffset, ulong buffer, ref T0 pNext) where T0 : unmanaged;

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3848, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaBindBufferMemory2")]
        public unsafe partial Result BindBufferMemory2(ref AllocatorT allocator, ref AllocationT allocation, ulong allocationLocalOffset, ulong buffer, void* pNext);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3848, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaBindBufferMemory2")]
        public partial Result BindBufferMemory2<T0>(ref AllocatorT allocator, ref AllocationT allocation, ulong allocationLocalOffset, ulong buffer, ref T0 pNext) where T0 : unmanaged;

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3867, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaBindImageMemory")]
        public unsafe partial Result BindImageMemory(AllocatorT* allocator, AllocationT* allocation, ulong image);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3867, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaBindImageMemory")]
        public unsafe partial Result BindImageMemory(AllocatorT* allocator, ref AllocationT allocation, ulong image);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3867, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaBindImageMemory")]
        public unsafe partial Result BindImageMemory(ref AllocatorT allocator, AllocationT* allocation, ulong image);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3867, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaBindImageMemory")]
        public partial Result BindImageMemory(ref AllocatorT allocator, ref AllocationT allocation, ulong image);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3882, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaBindImageMemory2")]
        public unsafe partial Result BindImageMemory2(AllocatorT* allocator, AllocationT* allocation, ulong allocationLocalOffset, ulong image, void* pNext);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3882, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaBindImageMemory2")]
        public unsafe partial Result BindImageMemory2<T0>(AllocatorT* allocator, AllocationT* allocation, ulong allocationLocalOffset, ulong image, ref T0 pNext) where T0 : unmanaged;

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3882, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaBindImageMemory2")]
        public unsafe partial Result BindImageMemory2(AllocatorT* allocator, ref AllocationT allocation, ulong allocationLocalOffset, ulong image, void* pNext);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3882, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaBindImageMemory2")]
        public unsafe partial Result BindImageMemory2<T0>(AllocatorT* allocator, ref AllocationT allocation, ulong allocationLocalOffset, ulong image, ref T0 pNext) where T0 : unmanaged;

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3882, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaBindImageMemory2")]
        public unsafe partial Result BindImageMemory2(ref AllocatorT allocator, AllocationT* allocation, ulong allocationLocalOffset, ulong image, void* pNext);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3882, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaBindImageMemory2")]
        public unsafe partial Result BindImageMemory2<T0>(ref AllocatorT allocator, AllocationT* allocation, ulong allocationLocalOffset, ulong image, ref T0 pNext) where T0 : unmanaged;

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3882, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaBindImageMemory2")]
        public unsafe partial Result BindImageMemory2(ref AllocatorT allocator, ref AllocationT allocation, ulong allocationLocalOffset, ulong image, void* pNext);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3882, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaBindImageMemory2")]
        public partial Result BindImageMemory2<T0>(ref AllocatorT allocator, ref AllocationT allocation, ulong allocationLocalOffset, ulong image, ref T0 pNext) where T0 : unmanaged;

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(AllocatorT* allocator, BufferCreateInfo* pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pBuffer, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(AllocatorT* allocator, BufferCreateInfo* pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pBuffer, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(AllocatorT* allocator, BufferCreateInfo* pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pBuffer, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(AllocatorT* allocator, BufferCreateInfo* pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pBuffer, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(AllocatorT* allocator, BufferCreateInfo* pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ref ulong pBuffer, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(AllocatorT* allocator, BufferCreateInfo* pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ref ulong pBuffer, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(AllocatorT* allocator, BufferCreateInfo* pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ref ulong pBuffer, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(AllocatorT* allocator, BufferCreateInfo* pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ref ulong pBuffer, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(AllocatorT* allocator, BufferCreateInfo* pBufferCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ulong* pBuffer, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(AllocatorT* allocator, BufferCreateInfo* pBufferCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ulong* pBuffer, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(AllocatorT* allocator, BufferCreateInfo* pBufferCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ulong* pBuffer, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(AllocatorT* allocator, BufferCreateInfo* pBufferCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ulong* pBuffer, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(AllocatorT* allocator, BufferCreateInfo* pBufferCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ref ulong pBuffer, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(AllocatorT* allocator, BufferCreateInfo* pBufferCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ref ulong pBuffer, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(AllocatorT* allocator, BufferCreateInfo* pBufferCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ref ulong pBuffer, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(AllocatorT* allocator, BufferCreateInfo* pBufferCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ref ulong pBuffer, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(AllocatorT* allocator, ref BufferCreateInfo pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pBuffer, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(AllocatorT* allocator, ref BufferCreateInfo pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pBuffer, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(AllocatorT* allocator, ref BufferCreateInfo pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pBuffer, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(AllocatorT* allocator, ref BufferCreateInfo pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pBuffer, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(AllocatorT* allocator, ref BufferCreateInfo pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ref ulong pBuffer, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(AllocatorT* allocator, ref BufferCreateInfo pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ref ulong pBuffer, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(AllocatorT* allocator, ref BufferCreateInfo pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ref ulong pBuffer, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(AllocatorT* allocator, ref BufferCreateInfo pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ref ulong pBuffer, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(AllocatorT* allocator, ref BufferCreateInfo pBufferCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ulong* pBuffer, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(AllocatorT* allocator, ref BufferCreateInfo pBufferCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ulong* pBuffer, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(AllocatorT* allocator, ref BufferCreateInfo pBufferCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ulong* pBuffer, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(AllocatorT* allocator, ref BufferCreateInfo pBufferCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ulong* pBuffer, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(AllocatorT* allocator, ref BufferCreateInfo pBufferCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ref ulong pBuffer, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(AllocatorT* allocator, ref BufferCreateInfo pBufferCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ref ulong pBuffer, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(AllocatorT* allocator, ref BufferCreateInfo pBufferCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ref ulong pBuffer, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(AllocatorT* allocator, ref BufferCreateInfo pBufferCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ref ulong pBuffer, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(ref AllocatorT allocator, BufferCreateInfo* pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pBuffer, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(ref AllocatorT allocator, BufferCreateInfo* pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pBuffer, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(ref AllocatorT allocator, BufferCreateInfo* pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pBuffer, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(ref AllocatorT allocator, BufferCreateInfo* pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pBuffer, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(ref AllocatorT allocator, BufferCreateInfo* pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ref ulong pBuffer, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(ref AllocatorT allocator, BufferCreateInfo* pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ref ulong pBuffer, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(ref AllocatorT allocator, BufferCreateInfo* pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ref ulong pBuffer, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(ref AllocatorT allocator, BufferCreateInfo* pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ref ulong pBuffer, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(ref AllocatorT allocator, BufferCreateInfo* pBufferCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ulong* pBuffer, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(ref AllocatorT allocator, BufferCreateInfo* pBufferCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ulong* pBuffer, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(ref AllocatorT allocator, BufferCreateInfo* pBufferCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ulong* pBuffer, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(ref AllocatorT allocator, BufferCreateInfo* pBufferCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ulong* pBuffer, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(ref AllocatorT allocator, BufferCreateInfo* pBufferCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ref ulong pBuffer, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(ref AllocatorT allocator, BufferCreateInfo* pBufferCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ref ulong pBuffer, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(ref AllocatorT allocator, BufferCreateInfo* pBufferCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ref ulong pBuffer, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(ref AllocatorT allocator, BufferCreateInfo* pBufferCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ref ulong pBuffer, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(ref AllocatorT allocator, ref BufferCreateInfo pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pBuffer, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(ref AllocatorT allocator, ref BufferCreateInfo pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pBuffer, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(ref AllocatorT allocator, ref BufferCreateInfo pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pBuffer, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(ref AllocatorT allocator, ref BufferCreateInfo pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pBuffer, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(ref AllocatorT allocator, ref BufferCreateInfo pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ref ulong pBuffer, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(ref AllocatorT allocator, ref BufferCreateInfo pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ref ulong pBuffer, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(ref AllocatorT allocator, ref BufferCreateInfo pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ref ulong pBuffer, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(ref AllocatorT allocator, ref BufferCreateInfo pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ref ulong pBuffer, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(ref AllocatorT allocator, ref BufferCreateInfo pBufferCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ulong* pBuffer, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(ref AllocatorT allocator, ref BufferCreateInfo pBufferCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ulong* pBuffer, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(ref AllocatorT allocator, ref BufferCreateInfo pBufferCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ulong* pBuffer, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(ref AllocatorT allocator, ref BufferCreateInfo pBufferCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ulong* pBuffer, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(ref AllocatorT allocator, ref BufferCreateInfo pBufferCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ref ulong pBuffer, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(ref AllocatorT allocator, ref BufferCreateInfo pBufferCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ref ulong pBuffer, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(ref AllocatorT allocator, ref BufferCreateInfo pBufferCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ref ulong pBuffer, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateBuffer")]
        public unsafe partial Result CreateBuffer(ref AllocatorT allocator, ref BufferCreateInfo pBufferCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ref ulong pBuffer, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3938, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDestroyBuffer")]
        public unsafe partial void DestroyBuffer(AllocatorT* allocator, ulong buffer, AllocationT* allocation);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3938, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDestroyBuffer")]
        public unsafe partial void DestroyBuffer(AllocatorT* allocator, ulong buffer, ref AllocationT allocation);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3938, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDestroyBuffer")]
        public unsafe partial void DestroyBuffer(ref AllocatorT allocator, ulong buffer, AllocationT* allocation);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3938, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDestroyBuffer")]
        public partial void DestroyBuffer(ref AllocatorT allocator, ulong buffer, ref AllocationT allocation);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(AllocatorT* allocator, ImageCreateInfo* pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pImage, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(AllocatorT* allocator, ImageCreateInfo* pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pImage, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(AllocatorT* allocator, ImageCreateInfo* pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pImage, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(AllocatorT* allocator, ImageCreateInfo* pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pImage, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(AllocatorT* allocator, ImageCreateInfo* pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ref ulong pImage, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(AllocatorT* allocator, ImageCreateInfo* pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ref ulong pImage, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(AllocatorT* allocator, ImageCreateInfo* pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ref ulong pImage, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(AllocatorT* allocator, ImageCreateInfo* pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ref ulong pImage, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(AllocatorT* allocator, ImageCreateInfo* pImageCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ulong* pImage, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(AllocatorT* allocator, ImageCreateInfo* pImageCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ulong* pImage, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(AllocatorT* allocator, ImageCreateInfo* pImageCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ulong* pImage, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(AllocatorT* allocator, ImageCreateInfo* pImageCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ulong* pImage, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(AllocatorT* allocator, ImageCreateInfo* pImageCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ref ulong pImage, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(AllocatorT* allocator, ImageCreateInfo* pImageCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ref ulong pImage, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(AllocatorT* allocator, ImageCreateInfo* pImageCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ref ulong pImage, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(AllocatorT* allocator, ImageCreateInfo* pImageCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ref ulong pImage, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(AllocatorT* allocator, ref ImageCreateInfo pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pImage, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(AllocatorT* allocator, ref ImageCreateInfo pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pImage, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(AllocatorT* allocator, ref ImageCreateInfo pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pImage, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(AllocatorT* allocator, ref ImageCreateInfo pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pImage, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(AllocatorT* allocator, ref ImageCreateInfo pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ref ulong pImage, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(AllocatorT* allocator, ref ImageCreateInfo pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ref ulong pImage, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(AllocatorT* allocator, ref ImageCreateInfo pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ref ulong pImage, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(AllocatorT* allocator, ref ImageCreateInfo pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ref ulong pImage, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(AllocatorT* allocator, ref ImageCreateInfo pImageCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ulong* pImage, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(AllocatorT* allocator, ref ImageCreateInfo pImageCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ulong* pImage, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(AllocatorT* allocator, ref ImageCreateInfo pImageCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ulong* pImage, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(AllocatorT* allocator, ref ImageCreateInfo pImageCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ulong* pImage, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(AllocatorT* allocator, ref ImageCreateInfo pImageCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ref ulong pImage, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(AllocatorT* allocator, ref ImageCreateInfo pImageCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ref ulong pImage, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(AllocatorT* allocator, ref ImageCreateInfo pImageCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ref ulong pImage, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(AllocatorT* allocator, ref ImageCreateInfo pImageCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ref ulong pImage, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(ref AllocatorT allocator, ImageCreateInfo* pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pImage, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(ref AllocatorT allocator, ImageCreateInfo* pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pImage, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(ref AllocatorT allocator, ImageCreateInfo* pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pImage, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(ref AllocatorT allocator, ImageCreateInfo* pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pImage, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(ref AllocatorT allocator, ImageCreateInfo* pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ref ulong pImage, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(ref AllocatorT allocator, ImageCreateInfo* pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ref ulong pImage, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(ref AllocatorT allocator, ImageCreateInfo* pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ref ulong pImage, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(ref AllocatorT allocator, ImageCreateInfo* pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ref ulong pImage, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(ref AllocatorT allocator, ImageCreateInfo* pImageCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ulong* pImage, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(ref AllocatorT allocator, ImageCreateInfo* pImageCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ulong* pImage, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(ref AllocatorT allocator, ImageCreateInfo* pImageCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ulong* pImage, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(ref AllocatorT allocator, ImageCreateInfo* pImageCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ulong* pImage, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(ref AllocatorT allocator, ImageCreateInfo* pImageCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ref ulong pImage, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(ref AllocatorT allocator, ImageCreateInfo* pImageCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ref ulong pImage, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(ref AllocatorT allocator, ImageCreateInfo* pImageCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ref ulong pImage, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(ref AllocatorT allocator, ImageCreateInfo* pImageCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ref ulong pImage, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(ref AllocatorT allocator, ref ImageCreateInfo pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pImage, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(ref AllocatorT allocator, ref ImageCreateInfo pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pImage, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(ref AllocatorT allocator, ref ImageCreateInfo pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pImage, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(ref AllocatorT allocator, ref ImageCreateInfo pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pImage, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(ref AllocatorT allocator, ref ImageCreateInfo pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ref ulong pImage, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(ref AllocatorT allocator, ref ImageCreateInfo pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ref ulong pImage, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(ref AllocatorT allocator, ref ImageCreateInfo pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ref ulong pImage, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(ref AllocatorT allocator, ref ImageCreateInfo pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ref ulong pImage, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(ref AllocatorT allocator, ref ImageCreateInfo pImageCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ulong* pImage, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(ref AllocatorT allocator, ref ImageCreateInfo pImageCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ulong* pImage, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(ref AllocatorT allocator, ref ImageCreateInfo pImageCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ulong* pImage, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(ref AllocatorT allocator, ref ImageCreateInfo pImageCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ulong* pImage, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(ref AllocatorT allocator, ref ImageCreateInfo pImageCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ref ulong pImage, AllocationT** pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(ref AllocatorT allocator, ref ImageCreateInfo pImageCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ref ulong pImage, AllocationT** pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(ref AllocatorT allocator, ref ImageCreateInfo pImageCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ref ulong pImage, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaCreateImage")]
        public unsafe partial Result CreateImage(ref AllocatorT allocator, ref ImageCreateInfo pImageCreateInfo, ref AllocationCreateInfo pAllocationCreateInfo, ref ulong pImage, ref AllocationT* pAllocation, ref AllocationInfo pAllocationInfo);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3963, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDestroyImage")]
        public unsafe partial void DestroyImage(AllocatorT* allocator, ulong image, AllocationT* allocation);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3963, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDestroyImage")]
        public unsafe partial void DestroyImage(AllocatorT* allocator, ulong image, ref AllocationT allocation);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3963, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDestroyImage")]
        public unsafe partial void DestroyImage(ref AllocatorT allocator, ulong image, AllocationT* allocation);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3963, Column 33 in _mem_alloc.h")]
        [NativeApi(EntryPoint = "vmaDestroyImage")]
        public partial void DestroyImage(ref AllocatorT allocator, ulong image, ref AllocationT allocation);

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2654, Column 33 in _mem_alloc.h")]
        public unsafe void BuildStatsString(AllocatorT* allocator, string[] ppStatsStringSa, uint detailedMap)
        {
            // StringArrayOverloader
            var ppStatsString = (byte**) SilkMarshal.StringArrayToPtr(ppStatsStringSa);
            BuildStatsString(allocator, ppStatsString, detailedMap);
            SilkMarshal.CopyPtrToStringArray((IntPtr) ppStatsString, ppStatsStringSa);
            SilkMarshal.Free((IntPtr) ppStatsString);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2654, Column 33 in _mem_alloc.h")]
        public unsafe void BuildStatsString(ref AllocatorT allocator, string[] ppStatsStringSa, uint detailedMap)
        {
            // StringArrayOverloader
            var ppStatsString = (byte**) SilkMarshal.StringArrayToPtr(ppStatsStringSa);
            BuildStatsString(ref allocator, ppStatsString, detailedMap);
            SilkMarshal.CopyPtrToStringArray((IntPtr) ppStatsString, ppStatsStringSa);
            SilkMarshal.Free((IntPtr) ppStatsString);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3149, Column 33 in _mem_alloc.h")]
        public unsafe void GetPoolName(AllocatorT* allocator, PoolT* pool, string[] ppNameSa)
        {
            // StringArrayOverloader
            var ppName = (byte**) SilkMarshal.StringArrayToPtr(ppNameSa);
            GetPoolName(allocator, pool, ppName);
            SilkMarshal.CopyPtrToStringArray((IntPtr) ppName, ppNameSa);
            SilkMarshal.Free((IntPtr) ppName);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3149, Column 33 in _mem_alloc.h")]
        public unsafe void GetPoolName(AllocatorT* allocator, ref PoolT pool, string[] ppNameSa)
        {
            // StringArrayOverloader
            var ppName = (byte**) SilkMarshal.StringArrayToPtr(ppNameSa);
            GetPoolName(allocator, ref pool, ppName);
            SilkMarshal.CopyPtrToStringArray((IntPtr) ppName, ppNameSa);
            SilkMarshal.Free((IntPtr) ppName);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3149, Column 33 in _mem_alloc.h")]
        public unsafe void GetPoolName(ref AllocatorT allocator, PoolT* pool, string[] ppNameSa)
        {
            // StringArrayOverloader
            var ppName = (byte**) SilkMarshal.StringArrayToPtr(ppNameSa);
            GetPoolName(ref allocator, pool, ppName);
            SilkMarshal.CopyPtrToStringArray((IntPtr) ppName, ppNameSa);
            SilkMarshal.Free((IntPtr) ppName);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3149, Column 33 in _mem_alloc.h")]
        public unsafe void GetPoolName(ref AllocatorT allocator, ref PoolT pool, string[] ppNameSa)
        {
            // StringArrayOverloader
            var ppName = (byte**) SilkMarshal.StringArrayToPtr(ppNameSa);
            GetPoolName(ref allocator, ref pool, ppName);
            SilkMarshal.CopyPtrToStringArray((IntPtr) ppName, ppNameSa);
            SilkMarshal.Free((IntPtr) ppName);
        }


        public Vma(INativeContext ctx)
            : base(ctx)
        {
        }
    }
}

