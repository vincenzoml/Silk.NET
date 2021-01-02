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
    public static class VmaOverloads
    {
        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2476, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateAllocator(this Vma thisApi, Span<AllocatorCreateInfo> pCreateInfo, AllocatorT** pAllocator)
        {
            // SpanOverloader
            return thisApi.CreateAllocator(ref pCreateInfo.GetPinnableReference(), pAllocator);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2476, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateAllocator(this Vma thisApi, Span<AllocatorCreateInfo> pCreateInfo, ref AllocatorT* pAllocator)
        {
            // SpanOverloader
            return thisApi.CreateAllocator(ref pCreateInfo.GetPinnableReference(), ref pAllocator);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2481, Column 33 in _mem_alloc.h")]
        public static unsafe void DestroyAllocator(this Vma thisApi, Span<AllocatorT> allocator)
        {
            // SpanOverloader
            thisApi.DestroyAllocator(ref allocator.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2510, Column 33 in _mem_alloc.h")]
        public static unsafe void GetAllocatorInfo(this Vma thisApi, AllocatorT* allocator, Span<AllocatorInfo> pAllocatorInfo)
        {
            // SpanOverloader
            thisApi.GetAllocatorInfo(allocator, ref pAllocatorInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2510, Column 33 in _mem_alloc.h")]
        public static unsafe void GetAllocatorInfo(this Vma thisApi, Span<AllocatorT> allocator, AllocatorInfo* pAllocatorInfo)
        {
            // SpanOverloader
            thisApi.GetAllocatorInfo(ref allocator.GetPinnableReference(), pAllocatorInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2510, Column 33 in _mem_alloc.h")]
        public static unsafe void GetAllocatorInfo(this Vma thisApi, Span<AllocatorT> allocator, Span<AllocatorInfo> pAllocatorInfo)
        {
            // SpanOverloader
            thisApi.GetAllocatorInfo(ref allocator.GetPinnableReference(), ref pAllocatorInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2516, Column 33 in _mem_alloc.h")]
        public static unsafe void GetPhysicalDeviceProperties(this Vma thisApi, Span<AllocatorT> allocator, PhysicalDeviceProperties** ppPhysicalDeviceProperties)
        {
            // SpanOverloader
            thisApi.GetPhysicalDeviceProperties(ref allocator.GetPinnableReference(), ppPhysicalDeviceProperties);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2516, Column 33 in _mem_alloc.h")]
        public static unsafe void GetPhysicalDeviceProperties(this Vma thisApi, Span<AllocatorT> allocator, ref PhysicalDeviceProperties* ppPhysicalDeviceProperties)
        {
            // SpanOverloader
            thisApi.GetPhysicalDeviceProperties(ref allocator.GetPinnableReference(), ref ppPhysicalDeviceProperties);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2524, Column 33 in _mem_alloc.h")]
        public static unsafe void GetMemoryProperties(this Vma thisApi, Span<AllocatorT> allocator, PhysicalDeviceMemoryProperties** ppPhysicalDeviceMemoryProperties)
        {
            // SpanOverloader
            thisApi.GetMemoryProperties(ref allocator.GetPinnableReference(), ppPhysicalDeviceMemoryProperties);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2524, Column 33 in _mem_alloc.h")]
        public static unsafe void GetMemoryProperties(this Vma thisApi, Span<AllocatorT> allocator, ref PhysicalDeviceMemoryProperties* ppPhysicalDeviceMemoryProperties)
        {
            // SpanOverloader
            thisApi.GetMemoryProperties(ref allocator.GetPinnableReference(), ref ppPhysicalDeviceMemoryProperties);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2534, Column 33 in _mem_alloc.h")]
        public static unsafe void GetMemoryTypeProperties(this Vma thisApi, AllocatorT* allocator, uint memoryTypeIndex, Span<uint> pFlags)
        {
            // SpanOverloader
            thisApi.GetMemoryTypeProperties(allocator, memoryTypeIndex, ref pFlags.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2534, Column 33 in _mem_alloc.h")]
        public static unsafe void GetMemoryTypeProperties(this Vma thisApi, Span<AllocatorT> allocator, uint memoryTypeIndex, uint* pFlags)
        {
            // SpanOverloader
            thisApi.GetMemoryTypeProperties(ref allocator.GetPinnableReference(), memoryTypeIndex, pFlags);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2534, Column 33 in _mem_alloc.h")]
        public static unsafe void GetMemoryTypeProperties(this Vma thisApi, Span<AllocatorT> allocator, uint memoryTypeIndex, Span<uint> pFlags)
        {
            // SpanOverloader
            thisApi.GetMemoryTypeProperties(ref allocator.GetPinnableReference(), memoryTypeIndex, ref pFlags.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2547, Column 33 in _mem_alloc.h")]
        public static unsafe void SetCurrentFrameIndex(this Vma thisApi, Span<AllocatorT> allocator, uint frameIndex)
        {
            // SpanOverloader
            thisApi.SetCurrentFrameIndex(ref allocator.GetPinnableReference(), frameIndex);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2586, Column 33 in _mem_alloc.h")]
        public static unsafe void CalculateStats(this Vma thisApi, AllocatorT* allocator, Span<Stats> pStats)
        {
            // SpanOverloader
            thisApi.CalculateStats(allocator, ref pStats.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2586, Column 33 in _mem_alloc.h")]
        public static unsafe void CalculateStats(this Vma thisApi, Span<AllocatorT> allocator, Stats* pStats)
        {
            // SpanOverloader
            thisApi.CalculateStats(ref allocator.GetPinnableReference(), pStats);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2586, Column 33 in _mem_alloc.h")]
        public static unsafe void CalculateStats(this Vma thisApi, Span<AllocatorT> allocator, Span<Stats> pStats)
        {
            // SpanOverloader
            thisApi.CalculateStats(ref allocator.GetPinnableReference(), ref pStats.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2641, Column 33 in _mem_alloc.h")]
        public static unsafe void GetBudget(this Vma thisApi, AllocatorT* allocator, Span<Budget> pBudget)
        {
            // SpanOverloader
            thisApi.GetBudget(allocator, ref pBudget.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2641, Column 33 in _mem_alloc.h")]
        public static unsafe void GetBudget(this Vma thisApi, Span<AllocatorT> allocator, Budget* pBudget)
        {
            // SpanOverloader
            thisApi.GetBudget(ref allocator.GetPinnableReference(), pBudget);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2641, Column 33 in _mem_alloc.h")]
        public static unsafe void GetBudget(this Vma thisApi, Span<AllocatorT> allocator, Span<Budget> pBudget)
        {
            // SpanOverloader
            thisApi.GetBudget(ref allocator.GetPinnableReference(), ref pBudget.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2654, Column 33 in _mem_alloc.h")]
        public static unsafe void BuildStatsString(this Vma thisApi, Span<AllocatorT> allocator, byte** ppStatsString, uint detailedMap)
        {
            // SpanOverloader
            thisApi.BuildStatsString(ref allocator.GetPinnableReference(), ppStatsString, detailedMap);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2654, Column 33 in _mem_alloc.h")]
        public static unsafe void BuildStatsString(this Vma thisApi, Span<AllocatorT> allocator, ref byte* ppStatsString, uint detailedMap)
        {
            // SpanOverloader
            thisApi.BuildStatsString(ref allocator.GetPinnableReference(), ref ppStatsString, detailedMap);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2659, Column 33 in _mem_alloc.h")]
        public static unsafe void FreeStatsString(this Vma thisApi, AllocatorT* allocator, Span<byte> pStatsString)
        {
            // SpanOverloader
            thisApi.FreeStatsString(allocator, ref pStatsString.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2659, Column 33 in _mem_alloc.h")]
        public static unsafe void FreeStatsString(this Vma thisApi, Span<AllocatorT> allocator, byte* pStatsString)
        {
            // SpanOverloader
            thisApi.FreeStatsString(ref allocator.GetPinnableReference(), pStatsString);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2659, Column 33 in _mem_alloc.h")]
        public static unsafe void FreeStatsString(this Vma thisApi, Span<AllocatorT> allocator, Span<byte> pStatsString)
        {
            // SpanOverloader
            thisApi.FreeStatsString(ref allocator.GetPinnableReference(), ref pStatsString.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2659, Column 33 in _mem_alloc.h")]
        public static unsafe void FreeStatsString(this Vma thisApi, Span<AllocatorT> allocator, string pStatsString)
        {
            // SpanOverloader
            thisApi.FreeStatsString(ref allocator.GetPinnableReference(), pStatsString);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2913, Column 37 in _mem_alloc.h")]
        public static unsafe Result FindMemoryTypeIndex(this Vma thisApi, AllocatorT* allocator, uint memoryTypeBits, AllocationCreateInfo* pAllocationCreateInfo, Span<uint> pMemoryTypeIndex)
        {
            // SpanOverloader
            return thisApi.FindMemoryTypeIndex(allocator, memoryTypeBits, pAllocationCreateInfo, ref pMemoryTypeIndex.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2913, Column 37 in _mem_alloc.h")]
        public static unsafe Result FindMemoryTypeIndex(this Vma thisApi, AllocatorT* allocator, uint memoryTypeBits, Span<AllocationCreateInfo> pAllocationCreateInfo, uint* pMemoryTypeIndex)
        {
            // SpanOverloader
            return thisApi.FindMemoryTypeIndex(allocator, memoryTypeBits, ref pAllocationCreateInfo.GetPinnableReference(), pMemoryTypeIndex);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2913, Column 37 in _mem_alloc.h")]
        public static unsafe Result FindMemoryTypeIndex(this Vma thisApi, AllocatorT* allocator, uint memoryTypeBits, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<uint> pMemoryTypeIndex)
        {
            // SpanOverloader
            return thisApi.FindMemoryTypeIndex(allocator, memoryTypeBits, ref pAllocationCreateInfo.GetPinnableReference(), ref pMemoryTypeIndex.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2913, Column 37 in _mem_alloc.h")]
        public static unsafe Result FindMemoryTypeIndex(this Vma thisApi, Span<AllocatorT> allocator, uint memoryTypeBits, AllocationCreateInfo* pAllocationCreateInfo, uint* pMemoryTypeIndex)
        {
            // SpanOverloader
            return thisApi.FindMemoryTypeIndex(ref allocator.GetPinnableReference(), memoryTypeBits, pAllocationCreateInfo, pMemoryTypeIndex);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2913, Column 37 in _mem_alloc.h")]
        public static unsafe Result FindMemoryTypeIndex(this Vma thisApi, Span<AllocatorT> allocator, uint memoryTypeBits, AllocationCreateInfo* pAllocationCreateInfo, Span<uint> pMemoryTypeIndex)
        {
            // SpanOverloader
            return thisApi.FindMemoryTypeIndex(ref allocator.GetPinnableReference(), memoryTypeBits, pAllocationCreateInfo, ref pMemoryTypeIndex.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2913, Column 37 in _mem_alloc.h")]
        public static unsafe Result FindMemoryTypeIndex(this Vma thisApi, Span<AllocatorT> allocator, uint memoryTypeBits, Span<AllocationCreateInfo> pAllocationCreateInfo, uint* pMemoryTypeIndex)
        {
            // SpanOverloader
            return thisApi.FindMemoryTypeIndex(ref allocator.GetPinnableReference(), memoryTypeBits, ref pAllocationCreateInfo.GetPinnableReference(), pMemoryTypeIndex);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2913, Column 37 in _mem_alloc.h")]
        public static unsafe Result FindMemoryTypeIndex(this Vma thisApi, Span<AllocatorT> allocator, uint memoryTypeBits, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<uint> pMemoryTypeIndex)
        {
            // SpanOverloader
            return thisApi.FindMemoryTypeIndex(ref allocator.GetPinnableReference(), memoryTypeBits, ref pAllocationCreateInfo.GetPinnableReference(), ref pMemoryTypeIndex.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2931, Column 37 in _mem_alloc.h")]
        public static unsafe Result FindMemoryTypeIndexForBufferInfo(this Vma thisApi, AllocatorT* allocator, BufferCreateInfo* pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, Span<uint> pMemoryTypeIndex)
        {
            // SpanOverloader
            return thisApi.FindMemoryTypeIndexForBufferInfo(allocator, pBufferCreateInfo, pAllocationCreateInfo, ref pMemoryTypeIndex.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2931, Column 37 in _mem_alloc.h")]
        public static unsafe Result FindMemoryTypeIndexForBufferInfo(this Vma thisApi, AllocatorT* allocator, BufferCreateInfo* pBufferCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, uint* pMemoryTypeIndex)
        {
            // SpanOverloader
            return thisApi.FindMemoryTypeIndexForBufferInfo(allocator, pBufferCreateInfo, ref pAllocationCreateInfo.GetPinnableReference(), pMemoryTypeIndex);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2931, Column 37 in _mem_alloc.h")]
        public static unsafe Result FindMemoryTypeIndexForBufferInfo(this Vma thisApi, AllocatorT* allocator, BufferCreateInfo* pBufferCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<uint> pMemoryTypeIndex)
        {
            // SpanOverloader
            return thisApi.FindMemoryTypeIndexForBufferInfo(allocator, pBufferCreateInfo, ref pAllocationCreateInfo.GetPinnableReference(), ref pMemoryTypeIndex.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2931, Column 37 in _mem_alloc.h")]
        public static unsafe Result FindMemoryTypeIndexForBufferInfo(this Vma thisApi, AllocatorT* allocator, Span<BufferCreateInfo> pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, uint* pMemoryTypeIndex)
        {
            // SpanOverloader
            return thisApi.FindMemoryTypeIndexForBufferInfo(allocator, ref pBufferCreateInfo.GetPinnableReference(), pAllocationCreateInfo, pMemoryTypeIndex);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2931, Column 37 in _mem_alloc.h")]
        public static unsafe Result FindMemoryTypeIndexForBufferInfo(this Vma thisApi, AllocatorT* allocator, Span<BufferCreateInfo> pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, Span<uint> pMemoryTypeIndex)
        {
            // SpanOverloader
            return thisApi.FindMemoryTypeIndexForBufferInfo(allocator, ref pBufferCreateInfo.GetPinnableReference(), pAllocationCreateInfo, ref pMemoryTypeIndex.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2931, Column 37 in _mem_alloc.h")]
        public static unsafe Result FindMemoryTypeIndexForBufferInfo(this Vma thisApi, AllocatorT* allocator, Span<BufferCreateInfo> pBufferCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, uint* pMemoryTypeIndex)
        {
            // SpanOverloader
            return thisApi.FindMemoryTypeIndexForBufferInfo(allocator, ref pBufferCreateInfo.GetPinnableReference(), ref pAllocationCreateInfo.GetPinnableReference(), pMemoryTypeIndex);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2931, Column 37 in _mem_alloc.h")]
        public static unsafe Result FindMemoryTypeIndexForBufferInfo(this Vma thisApi, AllocatorT* allocator, Span<BufferCreateInfo> pBufferCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<uint> pMemoryTypeIndex)
        {
            // SpanOverloader
            return thisApi.FindMemoryTypeIndexForBufferInfo(allocator, ref pBufferCreateInfo.GetPinnableReference(), ref pAllocationCreateInfo.GetPinnableReference(), ref pMemoryTypeIndex.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2931, Column 37 in _mem_alloc.h")]
        public static unsafe Result FindMemoryTypeIndexForBufferInfo(this Vma thisApi, Span<AllocatorT> allocator, BufferCreateInfo* pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, uint* pMemoryTypeIndex)
        {
            // SpanOverloader
            return thisApi.FindMemoryTypeIndexForBufferInfo(ref allocator.GetPinnableReference(), pBufferCreateInfo, pAllocationCreateInfo, pMemoryTypeIndex);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2931, Column 37 in _mem_alloc.h")]
        public static unsafe Result FindMemoryTypeIndexForBufferInfo(this Vma thisApi, Span<AllocatorT> allocator, BufferCreateInfo* pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, Span<uint> pMemoryTypeIndex)
        {
            // SpanOverloader
            return thisApi.FindMemoryTypeIndexForBufferInfo(ref allocator.GetPinnableReference(), pBufferCreateInfo, pAllocationCreateInfo, ref pMemoryTypeIndex.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2931, Column 37 in _mem_alloc.h")]
        public static unsafe Result FindMemoryTypeIndexForBufferInfo(this Vma thisApi, Span<AllocatorT> allocator, BufferCreateInfo* pBufferCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, uint* pMemoryTypeIndex)
        {
            // SpanOverloader
            return thisApi.FindMemoryTypeIndexForBufferInfo(ref allocator.GetPinnableReference(), pBufferCreateInfo, ref pAllocationCreateInfo.GetPinnableReference(), pMemoryTypeIndex);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2931, Column 37 in _mem_alloc.h")]
        public static unsafe Result FindMemoryTypeIndexForBufferInfo(this Vma thisApi, Span<AllocatorT> allocator, BufferCreateInfo* pBufferCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<uint> pMemoryTypeIndex)
        {
            // SpanOverloader
            return thisApi.FindMemoryTypeIndexForBufferInfo(ref allocator.GetPinnableReference(), pBufferCreateInfo, ref pAllocationCreateInfo.GetPinnableReference(), ref pMemoryTypeIndex.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2931, Column 37 in _mem_alloc.h")]
        public static unsafe Result FindMemoryTypeIndexForBufferInfo(this Vma thisApi, Span<AllocatorT> allocator, Span<BufferCreateInfo> pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, uint* pMemoryTypeIndex)
        {
            // SpanOverloader
            return thisApi.FindMemoryTypeIndexForBufferInfo(ref allocator.GetPinnableReference(), ref pBufferCreateInfo.GetPinnableReference(), pAllocationCreateInfo, pMemoryTypeIndex);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2931, Column 37 in _mem_alloc.h")]
        public static unsafe Result FindMemoryTypeIndexForBufferInfo(this Vma thisApi, Span<AllocatorT> allocator, Span<BufferCreateInfo> pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, Span<uint> pMemoryTypeIndex)
        {
            // SpanOverloader
            return thisApi.FindMemoryTypeIndexForBufferInfo(ref allocator.GetPinnableReference(), ref pBufferCreateInfo.GetPinnableReference(), pAllocationCreateInfo, ref pMemoryTypeIndex.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2931, Column 37 in _mem_alloc.h")]
        public static unsafe Result FindMemoryTypeIndexForBufferInfo(this Vma thisApi, Span<AllocatorT> allocator, Span<BufferCreateInfo> pBufferCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, uint* pMemoryTypeIndex)
        {
            // SpanOverloader
            return thisApi.FindMemoryTypeIndexForBufferInfo(ref allocator.GetPinnableReference(), ref pBufferCreateInfo.GetPinnableReference(), ref pAllocationCreateInfo.GetPinnableReference(), pMemoryTypeIndex);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2931, Column 37 in _mem_alloc.h")]
        public static unsafe Result FindMemoryTypeIndexForBufferInfo(this Vma thisApi, Span<AllocatorT> allocator, Span<BufferCreateInfo> pBufferCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<uint> pMemoryTypeIndex)
        {
            // SpanOverloader
            return thisApi.FindMemoryTypeIndexForBufferInfo(ref allocator.GetPinnableReference(), ref pBufferCreateInfo.GetPinnableReference(), ref pAllocationCreateInfo.GetPinnableReference(), ref pMemoryTypeIndex.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2949, Column 37 in _mem_alloc.h")]
        public static unsafe Result FindMemoryTypeIndexForImageInfo(this Vma thisApi, AllocatorT* allocator, ImageCreateInfo* pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, Span<uint> pMemoryTypeIndex)
        {
            // SpanOverloader
            return thisApi.FindMemoryTypeIndexForImageInfo(allocator, pImageCreateInfo, pAllocationCreateInfo, ref pMemoryTypeIndex.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2949, Column 37 in _mem_alloc.h")]
        public static unsafe Result FindMemoryTypeIndexForImageInfo(this Vma thisApi, AllocatorT* allocator, ImageCreateInfo* pImageCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, uint* pMemoryTypeIndex)
        {
            // SpanOverloader
            return thisApi.FindMemoryTypeIndexForImageInfo(allocator, pImageCreateInfo, ref pAllocationCreateInfo.GetPinnableReference(), pMemoryTypeIndex);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2949, Column 37 in _mem_alloc.h")]
        public static unsafe Result FindMemoryTypeIndexForImageInfo(this Vma thisApi, AllocatorT* allocator, ImageCreateInfo* pImageCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<uint> pMemoryTypeIndex)
        {
            // SpanOverloader
            return thisApi.FindMemoryTypeIndexForImageInfo(allocator, pImageCreateInfo, ref pAllocationCreateInfo.GetPinnableReference(), ref pMemoryTypeIndex.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2949, Column 37 in _mem_alloc.h")]
        public static unsafe Result FindMemoryTypeIndexForImageInfo(this Vma thisApi, AllocatorT* allocator, Span<ImageCreateInfo> pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, uint* pMemoryTypeIndex)
        {
            // SpanOverloader
            return thisApi.FindMemoryTypeIndexForImageInfo(allocator, ref pImageCreateInfo.GetPinnableReference(), pAllocationCreateInfo, pMemoryTypeIndex);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2949, Column 37 in _mem_alloc.h")]
        public static unsafe Result FindMemoryTypeIndexForImageInfo(this Vma thisApi, AllocatorT* allocator, Span<ImageCreateInfo> pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, Span<uint> pMemoryTypeIndex)
        {
            // SpanOverloader
            return thisApi.FindMemoryTypeIndexForImageInfo(allocator, ref pImageCreateInfo.GetPinnableReference(), pAllocationCreateInfo, ref pMemoryTypeIndex.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2949, Column 37 in _mem_alloc.h")]
        public static unsafe Result FindMemoryTypeIndexForImageInfo(this Vma thisApi, AllocatorT* allocator, Span<ImageCreateInfo> pImageCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, uint* pMemoryTypeIndex)
        {
            // SpanOverloader
            return thisApi.FindMemoryTypeIndexForImageInfo(allocator, ref pImageCreateInfo.GetPinnableReference(), ref pAllocationCreateInfo.GetPinnableReference(), pMemoryTypeIndex);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2949, Column 37 in _mem_alloc.h")]
        public static unsafe Result FindMemoryTypeIndexForImageInfo(this Vma thisApi, AllocatorT* allocator, Span<ImageCreateInfo> pImageCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<uint> pMemoryTypeIndex)
        {
            // SpanOverloader
            return thisApi.FindMemoryTypeIndexForImageInfo(allocator, ref pImageCreateInfo.GetPinnableReference(), ref pAllocationCreateInfo.GetPinnableReference(), ref pMemoryTypeIndex.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2949, Column 37 in _mem_alloc.h")]
        public static unsafe Result FindMemoryTypeIndexForImageInfo(this Vma thisApi, Span<AllocatorT> allocator, ImageCreateInfo* pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, uint* pMemoryTypeIndex)
        {
            // SpanOverloader
            return thisApi.FindMemoryTypeIndexForImageInfo(ref allocator.GetPinnableReference(), pImageCreateInfo, pAllocationCreateInfo, pMemoryTypeIndex);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2949, Column 37 in _mem_alloc.h")]
        public static unsafe Result FindMemoryTypeIndexForImageInfo(this Vma thisApi, Span<AllocatorT> allocator, ImageCreateInfo* pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, Span<uint> pMemoryTypeIndex)
        {
            // SpanOverloader
            return thisApi.FindMemoryTypeIndexForImageInfo(ref allocator.GetPinnableReference(), pImageCreateInfo, pAllocationCreateInfo, ref pMemoryTypeIndex.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2949, Column 37 in _mem_alloc.h")]
        public static unsafe Result FindMemoryTypeIndexForImageInfo(this Vma thisApi, Span<AllocatorT> allocator, ImageCreateInfo* pImageCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, uint* pMemoryTypeIndex)
        {
            // SpanOverloader
            return thisApi.FindMemoryTypeIndexForImageInfo(ref allocator.GetPinnableReference(), pImageCreateInfo, ref pAllocationCreateInfo.GetPinnableReference(), pMemoryTypeIndex);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2949, Column 37 in _mem_alloc.h")]
        public static unsafe Result FindMemoryTypeIndexForImageInfo(this Vma thisApi, Span<AllocatorT> allocator, ImageCreateInfo* pImageCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<uint> pMemoryTypeIndex)
        {
            // SpanOverloader
            return thisApi.FindMemoryTypeIndexForImageInfo(ref allocator.GetPinnableReference(), pImageCreateInfo, ref pAllocationCreateInfo.GetPinnableReference(), ref pMemoryTypeIndex.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2949, Column 37 in _mem_alloc.h")]
        public static unsafe Result FindMemoryTypeIndexForImageInfo(this Vma thisApi, Span<AllocatorT> allocator, Span<ImageCreateInfo> pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, uint* pMemoryTypeIndex)
        {
            // SpanOverloader
            return thisApi.FindMemoryTypeIndexForImageInfo(ref allocator.GetPinnableReference(), ref pImageCreateInfo.GetPinnableReference(), pAllocationCreateInfo, pMemoryTypeIndex);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2949, Column 37 in _mem_alloc.h")]
        public static unsafe Result FindMemoryTypeIndexForImageInfo(this Vma thisApi, Span<AllocatorT> allocator, Span<ImageCreateInfo> pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, Span<uint> pMemoryTypeIndex)
        {
            // SpanOverloader
            return thisApi.FindMemoryTypeIndexForImageInfo(ref allocator.GetPinnableReference(), ref pImageCreateInfo.GetPinnableReference(), pAllocationCreateInfo, ref pMemoryTypeIndex.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2949, Column 37 in _mem_alloc.h")]
        public static unsafe Result FindMemoryTypeIndexForImageInfo(this Vma thisApi, Span<AllocatorT> allocator, Span<ImageCreateInfo> pImageCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, uint* pMemoryTypeIndex)
        {
            // SpanOverloader
            return thisApi.FindMemoryTypeIndexForImageInfo(ref allocator.GetPinnableReference(), ref pImageCreateInfo.GetPinnableReference(), ref pAllocationCreateInfo.GetPinnableReference(), pMemoryTypeIndex);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 2949, Column 37 in _mem_alloc.h")]
        public static unsafe Result FindMemoryTypeIndexForImageInfo(this Vma thisApi, Span<AllocatorT> allocator, Span<ImageCreateInfo> pImageCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<uint> pMemoryTypeIndex)
        {
            // SpanOverloader
            return thisApi.FindMemoryTypeIndexForImageInfo(ref allocator.GetPinnableReference(), ref pImageCreateInfo.GetPinnableReference(), ref pAllocationCreateInfo.GetPinnableReference(), ref pMemoryTypeIndex.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3094, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreatePool(this Vma thisApi, AllocatorT* allocator, Span<PoolCreateInfo> pCreateInfo, PoolT** pPool)
        {
            // SpanOverloader
            return thisApi.CreatePool(allocator, ref pCreateInfo.GetPinnableReference(), pPool);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3094, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreatePool(this Vma thisApi, AllocatorT* allocator, Span<PoolCreateInfo> pCreateInfo, ref PoolT* pPool)
        {
            // SpanOverloader
            return thisApi.CreatePool(allocator, ref pCreateInfo.GetPinnableReference(), ref pPool);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3094, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreatePool(this Vma thisApi, Span<AllocatorT> allocator, PoolCreateInfo* pCreateInfo, PoolT** pPool)
        {
            // SpanOverloader
            return thisApi.CreatePool(ref allocator.GetPinnableReference(), pCreateInfo, pPool);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3094, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreatePool(this Vma thisApi, Span<AllocatorT> allocator, PoolCreateInfo* pCreateInfo, ref PoolT* pPool)
        {
            // SpanOverloader
            return thisApi.CreatePool(ref allocator.GetPinnableReference(), pCreateInfo, ref pPool);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3094, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreatePool(this Vma thisApi, Span<AllocatorT> allocator, Span<PoolCreateInfo> pCreateInfo, PoolT** pPool)
        {
            // SpanOverloader
            return thisApi.CreatePool(ref allocator.GetPinnableReference(), ref pCreateInfo.GetPinnableReference(), pPool);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3094, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreatePool(this Vma thisApi, Span<AllocatorT> allocator, Span<PoolCreateInfo> pCreateInfo, ref PoolT* pPool)
        {
            // SpanOverloader
            return thisApi.CreatePool(ref allocator.GetPinnableReference(), ref pCreateInfo.GetPinnableReference(), ref pPool);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3101, Column 33 in _mem_alloc.h")]
        public static unsafe void DestroyPool(this Vma thisApi, AllocatorT* allocator, Span<PoolT> pool)
        {
            // SpanOverloader
            thisApi.DestroyPool(allocator, ref pool.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3101, Column 33 in _mem_alloc.h")]
        public static unsafe void DestroyPool(this Vma thisApi, Span<AllocatorT> allocator, PoolT* pool)
        {
            // SpanOverloader
            thisApi.DestroyPool(ref allocator.GetPinnableReference(), pool);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3101, Column 33 in _mem_alloc.h")]
        public static unsafe void DestroyPool(this Vma thisApi, Span<AllocatorT> allocator, Span<PoolT> pool)
        {
            // SpanOverloader
            thisApi.DestroyPool(ref allocator.GetPinnableReference(), ref pool.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3111, Column 33 in _mem_alloc.h")]
        public static unsafe void GetPoolStats(this Vma thisApi, AllocatorT* allocator, PoolT* pool, Span<PoolStats> pPoolStats)
        {
            // SpanOverloader
            thisApi.GetPoolStats(allocator, pool, ref pPoolStats.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3111, Column 33 in _mem_alloc.h")]
        public static unsafe void GetPoolStats(this Vma thisApi, AllocatorT* allocator, Span<PoolT> pool, PoolStats* pPoolStats)
        {
            // SpanOverloader
            thisApi.GetPoolStats(allocator, ref pool.GetPinnableReference(), pPoolStats);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3111, Column 33 in _mem_alloc.h")]
        public static unsafe void GetPoolStats(this Vma thisApi, AllocatorT* allocator, Span<PoolT> pool, Span<PoolStats> pPoolStats)
        {
            // SpanOverloader
            thisApi.GetPoolStats(allocator, ref pool.GetPinnableReference(), ref pPoolStats.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3111, Column 33 in _mem_alloc.h")]
        public static unsafe void GetPoolStats(this Vma thisApi, Span<AllocatorT> allocator, PoolT* pool, PoolStats* pPoolStats)
        {
            // SpanOverloader
            thisApi.GetPoolStats(ref allocator.GetPinnableReference(), pool, pPoolStats);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3111, Column 33 in _mem_alloc.h")]
        public static unsafe void GetPoolStats(this Vma thisApi, Span<AllocatorT> allocator, PoolT* pool, Span<PoolStats> pPoolStats)
        {
            // SpanOverloader
            thisApi.GetPoolStats(ref allocator.GetPinnableReference(), pool, ref pPoolStats.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3111, Column 33 in _mem_alloc.h")]
        public static unsafe void GetPoolStats(this Vma thisApi, Span<AllocatorT> allocator, Span<PoolT> pool, PoolStats* pPoolStats)
        {
            // SpanOverloader
            thisApi.GetPoolStats(ref allocator.GetPinnableReference(), ref pool.GetPinnableReference(), pPoolStats);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3111, Column 33 in _mem_alloc.h")]
        public static unsafe void GetPoolStats(this Vma thisApi, Span<AllocatorT> allocator, Span<PoolT> pool, Span<PoolStats> pPoolStats)
        {
            // SpanOverloader
            thisApi.GetPoolStats(ref allocator.GetPinnableReference(), ref pool.GetPinnableReference(), ref pPoolStats.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3122, Column 33 in _mem_alloc.h")]
        public static unsafe void MakePoolAllocationsLost(this Vma thisApi, AllocatorT* allocator, PoolT* pool, Span<uint> pLostAllocationCount)
        {
            // SpanOverloader
            thisApi.MakePoolAllocationsLost(allocator, pool, ref pLostAllocationCount.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3122, Column 33 in _mem_alloc.h")]
        public static unsafe void MakePoolAllocationsLost(this Vma thisApi, AllocatorT* allocator, Span<PoolT> pool, uint* pLostAllocationCount)
        {
            // SpanOverloader
            thisApi.MakePoolAllocationsLost(allocator, ref pool.GetPinnableReference(), pLostAllocationCount);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3122, Column 33 in _mem_alloc.h")]
        public static unsafe void MakePoolAllocationsLost(this Vma thisApi, AllocatorT* allocator, Span<PoolT> pool, Span<uint> pLostAllocationCount)
        {
            // SpanOverloader
            thisApi.MakePoolAllocationsLost(allocator, ref pool.GetPinnableReference(), ref pLostAllocationCount.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3122, Column 33 in _mem_alloc.h")]
        public static unsafe void MakePoolAllocationsLost(this Vma thisApi, Span<AllocatorT> allocator, PoolT* pool, uint* pLostAllocationCount)
        {
            // SpanOverloader
            thisApi.MakePoolAllocationsLost(ref allocator.GetPinnableReference(), pool, pLostAllocationCount);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3122, Column 33 in _mem_alloc.h")]
        public static unsafe void MakePoolAllocationsLost(this Vma thisApi, Span<AllocatorT> allocator, PoolT* pool, Span<uint> pLostAllocationCount)
        {
            // SpanOverloader
            thisApi.MakePoolAllocationsLost(ref allocator.GetPinnableReference(), pool, ref pLostAllocationCount.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3122, Column 33 in _mem_alloc.h")]
        public static unsafe void MakePoolAllocationsLost(this Vma thisApi, Span<AllocatorT> allocator, Span<PoolT> pool, uint* pLostAllocationCount)
        {
            // SpanOverloader
            thisApi.MakePoolAllocationsLost(ref allocator.GetPinnableReference(), ref pool.GetPinnableReference(), pLostAllocationCount);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3122, Column 33 in _mem_alloc.h")]
        public static unsafe void MakePoolAllocationsLost(this Vma thisApi, Span<AllocatorT> allocator, Span<PoolT> pool, Span<uint> pLostAllocationCount)
        {
            // SpanOverloader
            thisApi.MakePoolAllocationsLost(ref allocator.GetPinnableReference(), ref pool.GetPinnableReference(), ref pLostAllocationCount.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3141, Column 37 in _mem_alloc.h")]
        public static unsafe Result CheckPoolCorruption(this Vma thisApi, AllocatorT* allocator, Span<PoolT> pool)
        {
            // SpanOverloader
            return thisApi.CheckPoolCorruption(allocator, ref pool.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3141, Column 37 in _mem_alloc.h")]
        public static unsafe Result CheckPoolCorruption(this Vma thisApi, Span<AllocatorT> allocator, PoolT* pool)
        {
            // SpanOverloader
            return thisApi.CheckPoolCorruption(ref allocator.GetPinnableReference(), pool);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3141, Column 37 in _mem_alloc.h")]
        public static unsafe Result CheckPoolCorruption(this Vma thisApi, Span<AllocatorT> allocator, Span<PoolT> pool)
        {
            // SpanOverloader
            return thisApi.CheckPoolCorruption(ref allocator.GetPinnableReference(), ref pool.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3149, Column 33 in _mem_alloc.h")]
        public static unsafe void GetPoolName(this Vma thisApi, AllocatorT* allocator, Span<PoolT> pool, byte** ppName)
        {
            // SpanOverloader
            thisApi.GetPoolName(allocator, ref pool.GetPinnableReference(), ppName);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3149, Column 33 in _mem_alloc.h")]
        public static unsafe void GetPoolName(this Vma thisApi, AllocatorT* allocator, Span<PoolT> pool, ref byte* ppName)
        {
            // SpanOverloader
            thisApi.GetPoolName(allocator, ref pool.GetPinnableReference(), ref ppName);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3149, Column 33 in _mem_alloc.h")]
        public static unsafe void GetPoolName(this Vma thisApi, Span<AllocatorT> allocator, PoolT* pool, byte** ppName)
        {
            // SpanOverloader
            thisApi.GetPoolName(ref allocator.GetPinnableReference(), pool, ppName);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3149, Column 33 in _mem_alloc.h")]
        public static unsafe void GetPoolName(this Vma thisApi, Span<AllocatorT> allocator, PoolT* pool, ref byte* ppName)
        {
            // SpanOverloader
            thisApi.GetPoolName(ref allocator.GetPinnableReference(), pool, ref ppName);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3149, Column 33 in _mem_alloc.h")]
        public static unsafe void GetPoolName(this Vma thisApi, Span<AllocatorT> allocator, Span<PoolT> pool, byte** ppName)
        {
            // SpanOverloader
            thisApi.GetPoolName(ref allocator.GetPinnableReference(), ref pool.GetPinnableReference(), ppName);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3149, Column 33 in _mem_alloc.h")]
        public static unsafe void GetPoolName(this Vma thisApi, Span<AllocatorT> allocator, Span<PoolT> pool, ref byte* ppName)
        {
            // SpanOverloader
            thisApi.GetPoolName(ref allocator.GetPinnableReference(), ref pool.GetPinnableReference(), ref ppName);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3159, Column 33 in _mem_alloc.h")]
        public static unsafe void SetPoolName(this Vma thisApi, AllocatorT* allocator, PoolT* pool, Span<byte> pName)
        {
            // SpanOverloader
            thisApi.SetPoolName(allocator, pool, ref pName.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3159, Column 33 in _mem_alloc.h")]
        public static unsafe void SetPoolName(this Vma thisApi, AllocatorT* allocator, Span<PoolT> pool, byte* pName)
        {
            // SpanOverloader
            thisApi.SetPoolName(allocator, ref pool.GetPinnableReference(), pName);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3159, Column 33 in _mem_alloc.h")]
        public static unsafe void SetPoolName(this Vma thisApi, AllocatorT* allocator, Span<PoolT> pool, Span<byte> pName)
        {
            // SpanOverloader
            thisApi.SetPoolName(allocator, ref pool.GetPinnableReference(), ref pName.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3159, Column 33 in _mem_alloc.h")]
        public static unsafe void SetPoolName(this Vma thisApi, AllocatorT* allocator, Span<PoolT> pool, string pName)
        {
            // SpanOverloader
            thisApi.SetPoolName(allocator, ref pool.GetPinnableReference(), pName);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3159, Column 33 in _mem_alloc.h")]
        public static unsafe void SetPoolName(this Vma thisApi, Span<AllocatorT> allocator, PoolT* pool, byte* pName)
        {
            // SpanOverloader
            thisApi.SetPoolName(ref allocator.GetPinnableReference(), pool, pName);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3159, Column 33 in _mem_alloc.h")]
        public static unsafe void SetPoolName(this Vma thisApi, Span<AllocatorT> allocator, PoolT* pool, Span<byte> pName)
        {
            // SpanOverloader
            thisApi.SetPoolName(ref allocator.GetPinnableReference(), pool, ref pName.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3159, Column 33 in _mem_alloc.h")]
        public static unsafe void SetPoolName(this Vma thisApi, Span<AllocatorT> allocator, PoolT* pool, string pName)
        {
            // SpanOverloader
            thisApi.SetPoolName(ref allocator.GetPinnableReference(), pool, pName);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3159, Column 33 in _mem_alloc.h")]
        public static unsafe void SetPoolName(this Vma thisApi, Span<AllocatorT> allocator, Span<PoolT> pool, byte* pName)
        {
            // SpanOverloader
            thisApi.SetPoolName(ref allocator.GetPinnableReference(), ref pool.GetPinnableReference(), pName);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3159, Column 33 in _mem_alloc.h")]
        public static unsafe void SetPoolName(this Vma thisApi, Span<AllocatorT> allocator, Span<PoolT> pool, Span<byte> pName)
        {
            // SpanOverloader
            thisApi.SetPoolName(ref allocator.GetPinnableReference(), ref pool.GetPinnableReference(), ref pName.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3159, Column 33 in _mem_alloc.h")]
        public static unsafe void SetPoolName(this Vma thisApi, Span<AllocatorT> allocator, Span<PoolT> pool, string pName)
        {
            // SpanOverloader
            thisApi.SetPoolName(ref allocator.GetPinnableReference(), ref pool.GetPinnableReference(), pName);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemory(this Vma thisApi, AllocatorT* allocator, MemoryRequirements* pMemoryRequirements, AllocationCreateInfo* pCreateInfo, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemory(allocator, pMemoryRequirements, pCreateInfo, pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemory(this Vma thisApi, AllocatorT* allocator, MemoryRequirements* pMemoryRequirements, AllocationCreateInfo* pCreateInfo, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemory(allocator, pMemoryRequirements, pCreateInfo, ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemory(this Vma thisApi, AllocatorT* allocator, MemoryRequirements* pMemoryRequirements, Span<AllocationCreateInfo> pCreateInfo, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemory(allocator, pMemoryRequirements, ref pCreateInfo.GetPinnableReference(), pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemory(this Vma thisApi, AllocatorT* allocator, MemoryRequirements* pMemoryRequirements, Span<AllocationCreateInfo> pCreateInfo, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemory(allocator, pMemoryRequirements, ref pCreateInfo.GetPinnableReference(), pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemory(this Vma thisApi, AllocatorT* allocator, MemoryRequirements* pMemoryRequirements, Span<AllocationCreateInfo> pCreateInfo, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemory(allocator, pMemoryRequirements, ref pCreateInfo.GetPinnableReference(), ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemory(this Vma thisApi, AllocatorT* allocator, MemoryRequirements* pMemoryRequirements, Span<AllocationCreateInfo> pCreateInfo, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemory(allocator, pMemoryRequirements, ref pCreateInfo.GetPinnableReference(), ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemory(this Vma thisApi, AllocatorT* allocator, Span<MemoryRequirements> pMemoryRequirements, AllocationCreateInfo* pCreateInfo, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemory(allocator, ref pMemoryRequirements.GetPinnableReference(), pCreateInfo, pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemory(this Vma thisApi, AllocatorT* allocator, Span<MemoryRequirements> pMemoryRequirements, AllocationCreateInfo* pCreateInfo, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemory(allocator, ref pMemoryRequirements.GetPinnableReference(), pCreateInfo, pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemory(this Vma thisApi, AllocatorT* allocator, Span<MemoryRequirements> pMemoryRequirements, AllocationCreateInfo* pCreateInfo, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemory(allocator, ref pMemoryRequirements.GetPinnableReference(), pCreateInfo, ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemory(this Vma thisApi, AllocatorT* allocator, Span<MemoryRequirements> pMemoryRequirements, AllocationCreateInfo* pCreateInfo, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemory(allocator, ref pMemoryRequirements.GetPinnableReference(), pCreateInfo, ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemory(this Vma thisApi, AllocatorT* allocator, Span<MemoryRequirements> pMemoryRequirements, Span<AllocationCreateInfo> pCreateInfo, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemory(allocator, ref pMemoryRequirements.GetPinnableReference(), ref pCreateInfo.GetPinnableReference(), pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemory(this Vma thisApi, AllocatorT* allocator, Span<MemoryRequirements> pMemoryRequirements, Span<AllocationCreateInfo> pCreateInfo, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemory(allocator, ref pMemoryRequirements.GetPinnableReference(), ref pCreateInfo.GetPinnableReference(), pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemory(this Vma thisApi, AllocatorT* allocator, Span<MemoryRequirements> pMemoryRequirements, Span<AllocationCreateInfo> pCreateInfo, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemory(allocator, ref pMemoryRequirements.GetPinnableReference(), ref pCreateInfo.GetPinnableReference(), ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemory(this Vma thisApi, AllocatorT* allocator, Span<MemoryRequirements> pMemoryRequirements, Span<AllocationCreateInfo> pCreateInfo, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemory(allocator, ref pMemoryRequirements.GetPinnableReference(), ref pCreateInfo.GetPinnableReference(), ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemory(this Vma thisApi, Span<AllocatorT> allocator, MemoryRequirements* pMemoryRequirements, AllocationCreateInfo* pCreateInfo, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemory(ref allocator.GetPinnableReference(), pMemoryRequirements, pCreateInfo, pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemory(this Vma thisApi, Span<AllocatorT> allocator, MemoryRequirements* pMemoryRequirements, AllocationCreateInfo* pCreateInfo, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemory(ref allocator.GetPinnableReference(), pMemoryRequirements, pCreateInfo, pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemory(this Vma thisApi, Span<AllocatorT> allocator, MemoryRequirements* pMemoryRequirements, AllocationCreateInfo* pCreateInfo, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemory(ref allocator.GetPinnableReference(), pMemoryRequirements, pCreateInfo, ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemory(this Vma thisApi, Span<AllocatorT> allocator, MemoryRequirements* pMemoryRequirements, AllocationCreateInfo* pCreateInfo, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemory(ref allocator.GetPinnableReference(), pMemoryRequirements, pCreateInfo, ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemory(this Vma thisApi, Span<AllocatorT> allocator, MemoryRequirements* pMemoryRequirements, Span<AllocationCreateInfo> pCreateInfo, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemory(ref allocator.GetPinnableReference(), pMemoryRequirements, ref pCreateInfo.GetPinnableReference(), pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemory(this Vma thisApi, Span<AllocatorT> allocator, MemoryRequirements* pMemoryRequirements, Span<AllocationCreateInfo> pCreateInfo, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemory(ref allocator.GetPinnableReference(), pMemoryRequirements, ref pCreateInfo.GetPinnableReference(), pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemory(this Vma thisApi, Span<AllocatorT> allocator, MemoryRequirements* pMemoryRequirements, Span<AllocationCreateInfo> pCreateInfo, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemory(ref allocator.GetPinnableReference(), pMemoryRequirements, ref pCreateInfo.GetPinnableReference(), ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemory(this Vma thisApi, Span<AllocatorT> allocator, MemoryRequirements* pMemoryRequirements, Span<AllocationCreateInfo> pCreateInfo, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemory(ref allocator.GetPinnableReference(), pMemoryRequirements, ref pCreateInfo.GetPinnableReference(), ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemory(this Vma thisApi, Span<AllocatorT> allocator, Span<MemoryRequirements> pMemoryRequirements, AllocationCreateInfo* pCreateInfo, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemory(ref allocator.GetPinnableReference(), ref pMemoryRequirements.GetPinnableReference(), pCreateInfo, pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemory(this Vma thisApi, Span<AllocatorT> allocator, Span<MemoryRequirements> pMemoryRequirements, AllocationCreateInfo* pCreateInfo, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemory(ref allocator.GetPinnableReference(), ref pMemoryRequirements.GetPinnableReference(), pCreateInfo, pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemory(this Vma thisApi, Span<AllocatorT> allocator, Span<MemoryRequirements> pMemoryRequirements, AllocationCreateInfo* pCreateInfo, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemory(ref allocator.GetPinnableReference(), ref pMemoryRequirements.GetPinnableReference(), pCreateInfo, ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemory(this Vma thisApi, Span<AllocatorT> allocator, Span<MemoryRequirements> pMemoryRequirements, AllocationCreateInfo* pCreateInfo, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemory(ref allocator.GetPinnableReference(), ref pMemoryRequirements.GetPinnableReference(), pCreateInfo, ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemory(this Vma thisApi, Span<AllocatorT> allocator, Span<MemoryRequirements> pMemoryRequirements, Span<AllocationCreateInfo> pCreateInfo, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemory(ref allocator.GetPinnableReference(), ref pMemoryRequirements.GetPinnableReference(), ref pCreateInfo.GetPinnableReference(), pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemory(this Vma thisApi, Span<AllocatorT> allocator, Span<MemoryRequirements> pMemoryRequirements, Span<AllocationCreateInfo> pCreateInfo, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemory(ref allocator.GetPinnableReference(), ref pMemoryRequirements.GetPinnableReference(), ref pCreateInfo.GetPinnableReference(), pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemory(this Vma thisApi, Span<AllocatorT> allocator, Span<MemoryRequirements> pMemoryRequirements, Span<AllocationCreateInfo> pCreateInfo, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemory(ref allocator.GetPinnableReference(), ref pMemoryRequirements.GetPinnableReference(), ref pCreateInfo.GetPinnableReference(), ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3254, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemory(this Vma thisApi, Span<AllocatorT> allocator, Span<MemoryRequirements> pMemoryRequirements, Span<AllocationCreateInfo> pCreateInfo, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemory(ref allocator.GetPinnableReference(), ref pMemoryRequirements.GetPinnableReference(), ref pCreateInfo.GetPinnableReference(), ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryPages(this Vma thisApi, AllocatorT* allocator, MemoryRequirements* pMemoryRequirements, AllocationCreateInfo* pCreateInfo, uint allocationCount, AllocationT** pAllocations, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryPages(allocator, pMemoryRequirements, pCreateInfo, allocationCount, pAllocations, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryPages(this Vma thisApi, AllocatorT* allocator, MemoryRequirements* pMemoryRequirements, AllocationCreateInfo* pCreateInfo, uint allocationCount, ref AllocationT* pAllocations, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryPages(allocator, pMemoryRequirements, pCreateInfo, allocationCount, ref pAllocations, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryPages(this Vma thisApi, AllocatorT* allocator, MemoryRequirements* pMemoryRequirements, Span<AllocationCreateInfo> pCreateInfo, uint allocationCount, AllocationT** pAllocations, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryPages(allocator, pMemoryRequirements, ref pCreateInfo.GetPinnableReference(), allocationCount, pAllocations, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryPages(this Vma thisApi, AllocatorT* allocator, MemoryRequirements* pMemoryRequirements, Span<AllocationCreateInfo> pCreateInfo, uint allocationCount, AllocationT** pAllocations, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryPages(allocator, pMemoryRequirements, ref pCreateInfo.GetPinnableReference(), allocationCount, pAllocations, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryPages(this Vma thisApi, AllocatorT* allocator, MemoryRequirements* pMemoryRequirements, Span<AllocationCreateInfo> pCreateInfo, uint allocationCount, ref AllocationT* pAllocations, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryPages(allocator, pMemoryRequirements, ref pCreateInfo.GetPinnableReference(), allocationCount, ref pAllocations, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryPages(this Vma thisApi, AllocatorT* allocator, MemoryRequirements* pMemoryRequirements, Span<AllocationCreateInfo> pCreateInfo, uint allocationCount, ref AllocationT* pAllocations, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryPages(allocator, pMemoryRequirements, ref pCreateInfo.GetPinnableReference(), allocationCount, ref pAllocations, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryPages(this Vma thisApi, AllocatorT* allocator, Span<MemoryRequirements> pMemoryRequirements, AllocationCreateInfo* pCreateInfo, uint allocationCount, AllocationT** pAllocations, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryPages(allocator, ref pMemoryRequirements.GetPinnableReference(), pCreateInfo, allocationCount, pAllocations, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryPages(this Vma thisApi, AllocatorT* allocator, Span<MemoryRequirements> pMemoryRequirements, AllocationCreateInfo* pCreateInfo, uint allocationCount, AllocationT** pAllocations, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryPages(allocator, ref pMemoryRequirements.GetPinnableReference(), pCreateInfo, allocationCount, pAllocations, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryPages(this Vma thisApi, AllocatorT* allocator, Span<MemoryRequirements> pMemoryRequirements, AllocationCreateInfo* pCreateInfo, uint allocationCount, ref AllocationT* pAllocations, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryPages(allocator, ref pMemoryRequirements.GetPinnableReference(), pCreateInfo, allocationCount, ref pAllocations, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryPages(this Vma thisApi, AllocatorT* allocator, Span<MemoryRequirements> pMemoryRequirements, AllocationCreateInfo* pCreateInfo, uint allocationCount, ref AllocationT* pAllocations, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryPages(allocator, ref pMemoryRequirements.GetPinnableReference(), pCreateInfo, allocationCount, ref pAllocations, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryPages(this Vma thisApi, AllocatorT* allocator, Span<MemoryRequirements> pMemoryRequirements, Span<AllocationCreateInfo> pCreateInfo, uint allocationCount, AllocationT** pAllocations, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryPages(allocator, ref pMemoryRequirements.GetPinnableReference(), ref pCreateInfo.GetPinnableReference(), allocationCount, pAllocations, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryPages(this Vma thisApi, AllocatorT* allocator, Span<MemoryRequirements> pMemoryRequirements, Span<AllocationCreateInfo> pCreateInfo, uint allocationCount, AllocationT** pAllocations, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryPages(allocator, ref pMemoryRequirements.GetPinnableReference(), ref pCreateInfo.GetPinnableReference(), allocationCount, pAllocations, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryPages(this Vma thisApi, AllocatorT* allocator, Span<MemoryRequirements> pMemoryRequirements, Span<AllocationCreateInfo> pCreateInfo, uint allocationCount, ref AllocationT* pAllocations, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryPages(allocator, ref pMemoryRequirements.GetPinnableReference(), ref pCreateInfo.GetPinnableReference(), allocationCount, ref pAllocations, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryPages(this Vma thisApi, AllocatorT* allocator, Span<MemoryRequirements> pMemoryRequirements, Span<AllocationCreateInfo> pCreateInfo, uint allocationCount, ref AllocationT* pAllocations, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryPages(allocator, ref pMemoryRequirements.GetPinnableReference(), ref pCreateInfo.GetPinnableReference(), allocationCount, ref pAllocations, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryPages(this Vma thisApi, Span<AllocatorT> allocator, MemoryRequirements* pMemoryRequirements, AllocationCreateInfo* pCreateInfo, uint allocationCount, AllocationT** pAllocations, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryPages(ref allocator.GetPinnableReference(), pMemoryRequirements, pCreateInfo, allocationCount, pAllocations, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryPages(this Vma thisApi, Span<AllocatorT> allocator, MemoryRequirements* pMemoryRequirements, AllocationCreateInfo* pCreateInfo, uint allocationCount, AllocationT** pAllocations, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryPages(ref allocator.GetPinnableReference(), pMemoryRequirements, pCreateInfo, allocationCount, pAllocations, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryPages(this Vma thisApi, Span<AllocatorT> allocator, MemoryRequirements* pMemoryRequirements, AllocationCreateInfo* pCreateInfo, uint allocationCount, ref AllocationT* pAllocations, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryPages(ref allocator.GetPinnableReference(), pMemoryRequirements, pCreateInfo, allocationCount, ref pAllocations, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryPages(this Vma thisApi, Span<AllocatorT> allocator, MemoryRequirements* pMemoryRequirements, AllocationCreateInfo* pCreateInfo, uint allocationCount, ref AllocationT* pAllocations, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryPages(ref allocator.GetPinnableReference(), pMemoryRequirements, pCreateInfo, allocationCount, ref pAllocations, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryPages(this Vma thisApi, Span<AllocatorT> allocator, MemoryRequirements* pMemoryRequirements, Span<AllocationCreateInfo> pCreateInfo, uint allocationCount, AllocationT** pAllocations, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryPages(ref allocator.GetPinnableReference(), pMemoryRequirements, ref pCreateInfo.GetPinnableReference(), allocationCount, pAllocations, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryPages(this Vma thisApi, Span<AllocatorT> allocator, MemoryRequirements* pMemoryRequirements, Span<AllocationCreateInfo> pCreateInfo, uint allocationCount, AllocationT** pAllocations, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryPages(ref allocator.GetPinnableReference(), pMemoryRequirements, ref pCreateInfo.GetPinnableReference(), allocationCount, pAllocations, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryPages(this Vma thisApi, Span<AllocatorT> allocator, MemoryRequirements* pMemoryRequirements, Span<AllocationCreateInfo> pCreateInfo, uint allocationCount, ref AllocationT* pAllocations, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryPages(ref allocator.GetPinnableReference(), pMemoryRequirements, ref pCreateInfo.GetPinnableReference(), allocationCount, ref pAllocations, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryPages(this Vma thisApi, Span<AllocatorT> allocator, MemoryRequirements* pMemoryRequirements, Span<AllocationCreateInfo> pCreateInfo, uint allocationCount, ref AllocationT* pAllocations, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryPages(ref allocator.GetPinnableReference(), pMemoryRequirements, ref pCreateInfo.GetPinnableReference(), allocationCount, ref pAllocations, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryPages(this Vma thisApi, Span<AllocatorT> allocator, Span<MemoryRequirements> pMemoryRequirements, AllocationCreateInfo* pCreateInfo, uint allocationCount, AllocationT** pAllocations, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryPages(ref allocator.GetPinnableReference(), ref pMemoryRequirements.GetPinnableReference(), pCreateInfo, allocationCount, pAllocations, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryPages(this Vma thisApi, Span<AllocatorT> allocator, Span<MemoryRequirements> pMemoryRequirements, AllocationCreateInfo* pCreateInfo, uint allocationCount, AllocationT** pAllocations, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryPages(ref allocator.GetPinnableReference(), ref pMemoryRequirements.GetPinnableReference(), pCreateInfo, allocationCount, pAllocations, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryPages(this Vma thisApi, Span<AllocatorT> allocator, Span<MemoryRequirements> pMemoryRequirements, AllocationCreateInfo* pCreateInfo, uint allocationCount, ref AllocationT* pAllocations, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryPages(ref allocator.GetPinnableReference(), ref pMemoryRequirements.GetPinnableReference(), pCreateInfo, allocationCount, ref pAllocations, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryPages(this Vma thisApi, Span<AllocatorT> allocator, Span<MemoryRequirements> pMemoryRequirements, AllocationCreateInfo* pCreateInfo, uint allocationCount, ref AllocationT* pAllocations, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryPages(ref allocator.GetPinnableReference(), ref pMemoryRequirements.GetPinnableReference(), pCreateInfo, allocationCount, ref pAllocations, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryPages(this Vma thisApi, Span<AllocatorT> allocator, Span<MemoryRequirements> pMemoryRequirements, Span<AllocationCreateInfo> pCreateInfo, uint allocationCount, AllocationT** pAllocations, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryPages(ref allocator.GetPinnableReference(), ref pMemoryRequirements.GetPinnableReference(), ref pCreateInfo.GetPinnableReference(), allocationCount, pAllocations, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryPages(this Vma thisApi, Span<AllocatorT> allocator, Span<MemoryRequirements> pMemoryRequirements, Span<AllocationCreateInfo> pCreateInfo, uint allocationCount, AllocationT** pAllocations, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryPages(ref allocator.GetPinnableReference(), ref pMemoryRequirements.GetPinnableReference(), ref pCreateInfo.GetPinnableReference(), allocationCount, pAllocations, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryPages(this Vma thisApi, Span<AllocatorT> allocator, Span<MemoryRequirements> pMemoryRequirements, Span<AllocationCreateInfo> pCreateInfo, uint allocationCount, ref AllocationT* pAllocations, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryPages(ref allocator.GetPinnableReference(), ref pMemoryRequirements.GetPinnableReference(), ref pCreateInfo.GetPinnableReference(), allocationCount, ref pAllocations, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3280, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryPages(this Vma thisApi, Span<AllocatorT> allocator, Span<MemoryRequirements> pMemoryRequirements, Span<AllocationCreateInfo> pCreateInfo, uint allocationCount, ref AllocationT* pAllocations, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryPages(ref allocator.GetPinnableReference(), ref pMemoryRequirements.GetPinnableReference(), ref pCreateInfo.GetPinnableReference(), allocationCount, ref pAllocations, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3294, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryForBuffer(this Vma thisApi, AllocatorT* allocator, ulong buffer, AllocationCreateInfo* pCreateInfo, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryForBuffer(allocator, buffer, pCreateInfo, pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3294, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryForBuffer(this Vma thisApi, AllocatorT* allocator, ulong buffer, AllocationCreateInfo* pCreateInfo, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryForBuffer(allocator, buffer, pCreateInfo, ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3294, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryForBuffer(this Vma thisApi, AllocatorT* allocator, ulong buffer, Span<AllocationCreateInfo> pCreateInfo, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryForBuffer(allocator, buffer, ref pCreateInfo.GetPinnableReference(), pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3294, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryForBuffer(this Vma thisApi, AllocatorT* allocator, ulong buffer, Span<AllocationCreateInfo> pCreateInfo, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryForBuffer(allocator, buffer, ref pCreateInfo.GetPinnableReference(), pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3294, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryForBuffer(this Vma thisApi, AllocatorT* allocator, ulong buffer, Span<AllocationCreateInfo> pCreateInfo, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryForBuffer(allocator, buffer, ref pCreateInfo.GetPinnableReference(), ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3294, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryForBuffer(this Vma thisApi, AllocatorT* allocator, ulong buffer, Span<AllocationCreateInfo> pCreateInfo, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryForBuffer(allocator, buffer, ref pCreateInfo.GetPinnableReference(), ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3294, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryForBuffer(this Vma thisApi, Span<AllocatorT> allocator, ulong buffer, AllocationCreateInfo* pCreateInfo, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryForBuffer(ref allocator.GetPinnableReference(), buffer, pCreateInfo, pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3294, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryForBuffer(this Vma thisApi, Span<AllocatorT> allocator, ulong buffer, AllocationCreateInfo* pCreateInfo, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryForBuffer(ref allocator.GetPinnableReference(), buffer, pCreateInfo, pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3294, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryForBuffer(this Vma thisApi, Span<AllocatorT> allocator, ulong buffer, AllocationCreateInfo* pCreateInfo, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryForBuffer(ref allocator.GetPinnableReference(), buffer, pCreateInfo, ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3294, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryForBuffer(this Vma thisApi, Span<AllocatorT> allocator, ulong buffer, AllocationCreateInfo* pCreateInfo, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryForBuffer(ref allocator.GetPinnableReference(), buffer, pCreateInfo, ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3294, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryForBuffer(this Vma thisApi, Span<AllocatorT> allocator, ulong buffer, Span<AllocationCreateInfo> pCreateInfo, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryForBuffer(ref allocator.GetPinnableReference(), buffer, ref pCreateInfo.GetPinnableReference(), pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3294, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryForBuffer(this Vma thisApi, Span<AllocatorT> allocator, ulong buffer, Span<AllocationCreateInfo> pCreateInfo, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryForBuffer(ref allocator.GetPinnableReference(), buffer, ref pCreateInfo.GetPinnableReference(), pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3294, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryForBuffer(this Vma thisApi, Span<AllocatorT> allocator, ulong buffer, Span<AllocationCreateInfo> pCreateInfo, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryForBuffer(ref allocator.GetPinnableReference(), buffer, ref pCreateInfo.GetPinnableReference(), ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3294, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryForBuffer(this Vma thisApi, Span<AllocatorT> allocator, ulong buffer, Span<AllocationCreateInfo> pCreateInfo, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryForBuffer(ref allocator.GetPinnableReference(), buffer, ref pCreateInfo.GetPinnableReference(), ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3302, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryForImage(this Vma thisApi, AllocatorT* allocator, ulong image, AllocationCreateInfo* pCreateInfo, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryForImage(allocator, image, pCreateInfo, pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3302, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryForImage(this Vma thisApi, AllocatorT* allocator, ulong image, AllocationCreateInfo* pCreateInfo, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryForImage(allocator, image, pCreateInfo, ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3302, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryForImage(this Vma thisApi, AllocatorT* allocator, ulong image, Span<AllocationCreateInfo> pCreateInfo, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryForImage(allocator, image, ref pCreateInfo.GetPinnableReference(), pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3302, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryForImage(this Vma thisApi, AllocatorT* allocator, ulong image, Span<AllocationCreateInfo> pCreateInfo, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryForImage(allocator, image, ref pCreateInfo.GetPinnableReference(), pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3302, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryForImage(this Vma thisApi, AllocatorT* allocator, ulong image, Span<AllocationCreateInfo> pCreateInfo, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryForImage(allocator, image, ref pCreateInfo.GetPinnableReference(), ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3302, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryForImage(this Vma thisApi, AllocatorT* allocator, ulong image, Span<AllocationCreateInfo> pCreateInfo, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryForImage(allocator, image, ref pCreateInfo.GetPinnableReference(), ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3302, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryForImage(this Vma thisApi, Span<AllocatorT> allocator, ulong image, AllocationCreateInfo* pCreateInfo, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryForImage(ref allocator.GetPinnableReference(), image, pCreateInfo, pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3302, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryForImage(this Vma thisApi, Span<AllocatorT> allocator, ulong image, AllocationCreateInfo* pCreateInfo, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryForImage(ref allocator.GetPinnableReference(), image, pCreateInfo, pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3302, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryForImage(this Vma thisApi, Span<AllocatorT> allocator, ulong image, AllocationCreateInfo* pCreateInfo, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryForImage(ref allocator.GetPinnableReference(), image, pCreateInfo, ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3302, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryForImage(this Vma thisApi, Span<AllocatorT> allocator, ulong image, AllocationCreateInfo* pCreateInfo, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryForImage(ref allocator.GetPinnableReference(), image, pCreateInfo, ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3302, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryForImage(this Vma thisApi, Span<AllocatorT> allocator, ulong image, Span<AllocationCreateInfo> pCreateInfo, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryForImage(ref allocator.GetPinnableReference(), image, ref pCreateInfo.GetPinnableReference(), pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3302, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryForImage(this Vma thisApi, Span<AllocatorT> allocator, ulong image, Span<AllocationCreateInfo> pCreateInfo, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryForImage(ref allocator.GetPinnableReference(), image, ref pCreateInfo.GetPinnableReference(), pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3302, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryForImage(this Vma thisApi, Span<AllocatorT> allocator, ulong image, Span<AllocationCreateInfo> pCreateInfo, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryForImage(ref allocator.GetPinnableReference(), image, ref pCreateInfo.GetPinnableReference(), ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3302, Column 37 in _mem_alloc.h")]
        public static unsafe Result AllocateMemoryForImage(this Vma thisApi, Span<AllocatorT> allocator, ulong image, Span<AllocationCreateInfo> pCreateInfo, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.AllocateMemoryForImage(ref allocator.GetPinnableReference(), image, ref pCreateInfo.GetPinnableReference(), ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3313, Column 33 in _mem_alloc.h")]
        public static unsafe void FreeMemory(this Vma thisApi, AllocatorT* allocator, Span<AllocationT> allocation)
        {
            // SpanOverloader
            thisApi.FreeMemory(allocator, ref allocation.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3313, Column 33 in _mem_alloc.h")]
        public static unsafe void FreeMemory(this Vma thisApi, Span<AllocatorT> allocator, AllocationT* allocation)
        {
            // SpanOverloader
            thisApi.FreeMemory(ref allocator.GetPinnableReference(), allocation);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3313, Column 33 in _mem_alloc.h")]
        public static unsafe void FreeMemory(this Vma thisApi, Span<AllocatorT> allocator, Span<AllocationT> allocation)
        {
            // SpanOverloader
            thisApi.FreeMemory(ref allocator.GetPinnableReference(), ref allocation.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3327, Column 33 in _mem_alloc.h")]
        public static unsafe void FreeMemoryPages(this Vma thisApi, Span<AllocatorT> allocator, uint allocationCount, AllocationT** pAllocations)
        {
            // SpanOverloader
            thisApi.FreeMemoryPages(ref allocator.GetPinnableReference(), allocationCount, pAllocations);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3327, Column 33 in _mem_alloc.h")]
        public static unsafe void FreeMemoryPages(this Vma thisApi, Span<AllocatorT> allocator, uint allocationCount, ref AllocationT* pAllocations)
        {
            // SpanOverloader
            thisApi.FreeMemoryPages(ref allocator.GetPinnableReference(), allocationCount, ref pAllocations);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3339, Column 37 in _mem_alloc.h")]
        public static unsafe Result ResizeAllocation(this Vma thisApi, AllocatorT* allocator, Span<AllocationT> allocation, ulong newSize)
        {
            // SpanOverloader
            return thisApi.ResizeAllocation(allocator, ref allocation.GetPinnableReference(), newSize);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3339, Column 37 in _mem_alloc.h")]
        public static unsafe Result ResizeAllocation(this Vma thisApi, Span<AllocatorT> allocator, AllocationT* allocation, ulong newSize)
        {
            // SpanOverloader
            return thisApi.ResizeAllocation(ref allocator.GetPinnableReference(), allocation, newSize);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3339, Column 37 in _mem_alloc.h")]
        public static unsafe Result ResizeAllocation(this Vma thisApi, Span<AllocatorT> allocator, Span<AllocationT> allocation, ulong newSize)
        {
            // SpanOverloader
            return thisApi.ResizeAllocation(ref allocator.GetPinnableReference(), ref allocation.GetPinnableReference(), newSize);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3360, Column 33 in _mem_alloc.h")]
        public static unsafe void GetAllocationInfo(this Vma thisApi, AllocatorT* allocator, AllocationT* allocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            thisApi.GetAllocationInfo(allocator, allocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3360, Column 33 in _mem_alloc.h")]
        public static unsafe void GetAllocationInfo(this Vma thisApi, AllocatorT* allocator, Span<AllocationT> allocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            thisApi.GetAllocationInfo(allocator, ref allocation.GetPinnableReference(), pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3360, Column 33 in _mem_alloc.h")]
        public static unsafe void GetAllocationInfo(this Vma thisApi, AllocatorT* allocator, Span<AllocationT> allocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            thisApi.GetAllocationInfo(allocator, ref allocation.GetPinnableReference(), ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3360, Column 33 in _mem_alloc.h")]
        public static unsafe void GetAllocationInfo(this Vma thisApi, Span<AllocatorT> allocator, AllocationT* allocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            thisApi.GetAllocationInfo(ref allocator.GetPinnableReference(), allocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3360, Column 33 in _mem_alloc.h")]
        public static unsafe void GetAllocationInfo(this Vma thisApi, Span<AllocatorT> allocator, AllocationT* allocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            thisApi.GetAllocationInfo(ref allocator.GetPinnableReference(), allocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3360, Column 33 in _mem_alloc.h")]
        public static unsafe void GetAllocationInfo(this Vma thisApi, Span<AllocatorT> allocator, Span<AllocationT> allocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            thisApi.GetAllocationInfo(ref allocator.GetPinnableReference(), ref allocation.GetPinnableReference(), pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3360, Column 33 in _mem_alloc.h")]
        public static unsafe void GetAllocationInfo(this Vma thisApi, Span<AllocatorT> allocator, Span<AllocationT> allocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            thisApi.GetAllocationInfo(ref allocator.GetPinnableReference(), ref allocation.GetPinnableReference(), ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3379, Column 37 in _mem_alloc.h")]
        public static unsafe uint TouchAllocation(this Vma thisApi, AllocatorT* allocator, Span<AllocationT> allocation)
        {
            // SpanOverloader
            return thisApi.TouchAllocation(allocator, ref allocation.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3379, Column 37 in _mem_alloc.h")]
        public static unsafe uint TouchAllocation(this Vma thisApi, Span<AllocatorT> allocator, AllocationT* allocation)
        {
            // SpanOverloader
            return thisApi.TouchAllocation(ref allocator.GetPinnableReference(), allocation);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3379, Column 37 in _mem_alloc.h")]
        public static unsafe uint TouchAllocation(this Vma thisApi, Span<AllocatorT> allocator, Span<AllocationT> allocation)
        {
            // SpanOverloader
            return thisApi.TouchAllocation(ref allocator.GetPinnableReference(), ref allocation.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3396, Column 33 in _mem_alloc.h")]
        public static unsafe void SetAllocationUserData<T0>(this Vma thisApi, AllocatorT* allocator, AllocationT* allocation, Span<T0> pUserData) where T0 : unmanaged
        {
            // SpanOverloader
            thisApi.SetAllocationUserData(allocator, allocation, ref pUserData.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3396, Column 33 in _mem_alloc.h")]
        public static unsafe void SetAllocationUserData(this Vma thisApi, AllocatorT* allocator, Span<AllocationT> allocation, void* pUserData)
        {
            // SpanOverloader
            thisApi.SetAllocationUserData(allocator, ref allocation.GetPinnableReference(), pUserData);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3396, Column 33 in _mem_alloc.h")]
        public static unsafe void SetAllocationUserData<T0>(this Vma thisApi, AllocatorT* allocator, Span<AllocationT> allocation, Span<T0> pUserData) where T0 : unmanaged
        {
            // SpanOverloader
            thisApi.SetAllocationUserData(allocator, ref allocation.GetPinnableReference(), ref pUserData.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3396, Column 33 in _mem_alloc.h")]
        public static unsafe void SetAllocationUserData(this Vma thisApi, Span<AllocatorT> allocator, AllocationT* allocation, void* pUserData)
        {
            // SpanOverloader
            thisApi.SetAllocationUserData(ref allocator.GetPinnableReference(), allocation, pUserData);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3396, Column 33 in _mem_alloc.h")]
        public static unsafe void SetAllocationUserData<T0>(this Vma thisApi, Span<AllocatorT> allocator, AllocationT* allocation, Span<T0> pUserData) where T0 : unmanaged
        {
            // SpanOverloader
            thisApi.SetAllocationUserData(ref allocator.GetPinnableReference(), allocation, ref pUserData.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3396, Column 33 in _mem_alloc.h")]
        public static unsafe void SetAllocationUserData(this Vma thisApi, Span<AllocatorT> allocator, Span<AllocationT> allocation, void* pUserData)
        {
            // SpanOverloader
            thisApi.SetAllocationUserData(ref allocator.GetPinnableReference(), ref allocation.GetPinnableReference(), pUserData);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3396, Column 33 in _mem_alloc.h")]
        public static unsafe void SetAllocationUserData<T0>(this Vma thisApi, Span<AllocatorT> allocator, Span<AllocationT> allocation, Span<T0> pUserData) where T0 : unmanaged
        {
            // SpanOverloader
            thisApi.SetAllocationUserData(ref allocator.GetPinnableReference(), ref allocation.GetPinnableReference(), ref pUserData.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3411, Column 33 in _mem_alloc.h")]
        public static unsafe void CreateLostAllocation(this Vma thisApi, Span<AllocatorT> allocator, AllocationT** pAllocation)
        {
            // SpanOverloader
            thisApi.CreateLostAllocation(ref allocator.GetPinnableReference(), pAllocation);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3411, Column 33 in _mem_alloc.h")]
        public static unsafe void CreateLostAllocation(this Vma thisApi, Span<AllocatorT> allocator, ref AllocationT* pAllocation)
        {
            // SpanOverloader
            thisApi.CreateLostAllocation(ref allocator.GetPinnableReference(), ref pAllocation);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3453, Column 37 in _mem_alloc.h")]
        public static unsafe Result MapMemory(this Vma thisApi, AllocatorT* allocator, Span<AllocationT> allocation, void** ppData)
        {
            // SpanOverloader
            return thisApi.MapMemory(allocator, ref allocation.GetPinnableReference(), ppData);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3453, Column 37 in _mem_alloc.h")]
        public static unsafe Result MapMemory(this Vma thisApi, AllocatorT* allocator, Span<AllocationT> allocation, ref void* ppData)
        {
            // SpanOverloader
            return thisApi.MapMemory(allocator, ref allocation.GetPinnableReference(), ref ppData);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3453, Column 37 in _mem_alloc.h")]
        public static unsafe Result MapMemory(this Vma thisApi, Span<AllocatorT> allocator, AllocationT* allocation, void** ppData)
        {
            // SpanOverloader
            return thisApi.MapMemory(ref allocator.GetPinnableReference(), allocation, ppData);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3453, Column 37 in _mem_alloc.h")]
        public static unsafe Result MapMemory(this Vma thisApi, Span<AllocatorT> allocator, AllocationT* allocation, ref void* ppData)
        {
            // SpanOverloader
            return thisApi.MapMemory(ref allocator.GetPinnableReference(), allocation, ref ppData);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3453, Column 37 in _mem_alloc.h")]
        public static unsafe Result MapMemory(this Vma thisApi, Span<AllocatorT> allocator, Span<AllocationT> allocation, void** ppData)
        {
            // SpanOverloader
            return thisApi.MapMemory(ref allocator.GetPinnableReference(), ref allocation.GetPinnableReference(), ppData);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3453, Column 37 in _mem_alloc.h")]
        public static unsafe Result MapMemory(this Vma thisApi, Span<AllocatorT> allocator, Span<AllocationT> allocation, ref void* ppData)
        {
            // SpanOverloader
            return thisApi.MapMemory(ref allocator.GetPinnableReference(), ref allocation.GetPinnableReference(), ref ppData);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3466, Column 33 in _mem_alloc.h")]
        public static unsafe void UnmapMemory(this Vma thisApi, AllocatorT* allocator, Span<AllocationT> allocation)
        {
            // SpanOverloader
            thisApi.UnmapMemory(allocator, ref allocation.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3466, Column 33 in _mem_alloc.h")]
        public static unsafe void UnmapMemory(this Vma thisApi, Span<AllocatorT> allocator, AllocationT* allocation)
        {
            // SpanOverloader
            thisApi.UnmapMemory(ref allocator.GetPinnableReference(), allocation);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3466, Column 33 in _mem_alloc.h")]
        public static unsafe void UnmapMemory(this Vma thisApi, Span<AllocatorT> allocator, Span<AllocationT> allocation)
        {
            // SpanOverloader
            thisApi.UnmapMemory(ref allocator.GetPinnableReference(), ref allocation.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3491, Column 37 in _mem_alloc.h")]
        public static unsafe Result FlushAllocation(this Vma thisApi, AllocatorT* allocator, Span<AllocationT> allocation, ulong offset, ulong size)
        {
            // SpanOverloader
            return thisApi.FlushAllocation(allocator, ref allocation.GetPinnableReference(), offset, size);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3491, Column 37 in _mem_alloc.h")]
        public static unsafe Result FlushAllocation(this Vma thisApi, Span<AllocatorT> allocator, AllocationT* allocation, ulong offset, ulong size)
        {
            // SpanOverloader
            return thisApi.FlushAllocation(ref allocator.GetPinnableReference(), allocation, offset, size);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3491, Column 37 in _mem_alloc.h")]
        public static unsafe Result FlushAllocation(this Vma thisApi, Span<AllocatorT> allocator, Span<AllocationT> allocation, ulong offset, ulong size)
        {
            // SpanOverloader
            return thisApi.FlushAllocation(ref allocator.GetPinnableReference(), ref allocation.GetPinnableReference(), offset, size);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3518, Column 37 in _mem_alloc.h")]
        public static unsafe Result InvalidateAllocation(this Vma thisApi, AllocatorT* allocator, Span<AllocationT> allocation, ulong offset, ulong size)
        {
            // SpanOverloader
            return thisApi.InvalidateAllocation(allocator, ref allocation.GetPinnableReference(), offset, size);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3518, Column 37 in _mem_alloc.h")]
        public static unsafe Result InvalidateAllocation(this Vma thisApi, Span<AllocatorT> allocator, AllocationT* allocation, ulong offset, ulong size)
        {
            // SpanOverloader
            return thisApi.InvalidateAllocation(ref allocator.GetPinnableReference(), allocation, offset, size);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3518, Column 37 in _mem_alloc.h")]
        public static unsafe Result InvalidateAllocation(this Vma thisApi, Span<AllocatorT> allocator, Span<AllocationT> allocation, ulong offset, ulong size)
        {
            // SpanOverloader
            return thisApi.InvalidateAllocation(ref allocator.GetPinnableReference(), ref allocation.GetPinnableReference(), offset, size);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3538, Column 37 in _mem_alloc.h")]
        public static unsafe Result FlushAllocations(this Vma thisApi, AllocatorT* allocator, uint allocationCount, AllocationT** allocations, ulong* offsets, Span<ulong> sizes)
        {
            // SpanOverloader
            return thisApi.FlushAllocations(allocator, allocationCount, allocations, offsets, ref sizes.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3538, Column 37 in _mem_alloc.h")]
        public static unsafe Result FlushAllocations(this Vma thisApi, AllocatorT* allocator, uint allocationCount, AllocationT** allocations, Span<ulong> offsets, ulong* sizes)
        {
            // SpanOverloader
            return thisApi.FlushAllocations(allocator, allocationCount, allocations, ref offsets.GetPinnableReference(), sizes);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3538, Column 37 in _mem_alloc.h")]
        public static unsafe Result FlushAllocations(this Vma thisApi, AllocatorT* allocator, uint allocationCount, AllocationT** allocations, Span<ulong> offsets, Span<ulong> sizes)
        {
            // SpanOverloader
            return thisApi.FlushAllocations(allocator, allocationCount, allocations, ref offsets.GetPinnableReference(), ref sizes.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3538, Column 37 in _mem_alloc.h")]
        public static unsafe Result FlushAllocations(this Vma thisApi, AllocatorT* allocator, uint allocationCount, ref AllocationT* allocations, ulong* offsets, Span<ulong> sizes)
        {
            // SpanOverloader
            return thisApi.FlushAllocations(allocator, allocationCount, ref allocations, offsets, ref sizes.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3538, Column 37 in _mem_alloc.h")]
        public static unsafe Result FlushAllocations(this Vma thisApi, AllocatorT* allocator, uint allocationCount, ref AllocationT* allocations, Span<ulong> offsets, ulong* sizes)
        {
            // SpanOverloader
            return thisApi.FlushAllocations(allocator, allocationCount, ref allocations, ref offsets.GetPinnableReference(), sizes);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3538, Column 37 in _mem_alloc.h")]
        public static unsafe Result FlushAllocations(this Vma thisApi, AllocatorT* allocator, uint allocationCount, ref AllocationT* allocations, Span<ulong> offsets, Span<ulong> sizes)
        {
            // SpanOverloader
            return thisApi.FlushAllocations(allocator, allocationCount, ref allocations, ref offsets.GetPinnableReference(), ref sizes.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3538, Column 37 in _mem_alloc.h")]
        public static unsafe Result FlushAllocations(this Vma thisApi, Span<AllocatorT> allocator, uint allocationCount, AllocationT** allocations, ulong* offsets, ulong* sizes)
        {
            // SpanOverloader
            return thisApi.FlushAllocations(ref allocator.GetPinnableReference(), allocationCount, allocations, offsets, sizes);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3538, Column 37 in _mem_alloc.h")]
        public static unsafe Result FlushAllocations(this Vma thisApi, Span<AllocatorT> allocator, uint allocationCount, AllocationT** allocations, ulong* offsets, Span<ulong> sizes)
        {
            // SpanOverloader
            return thisApi.FlushAllocations(ref allocator.GetPinnableReference(), allocationCount, allocations, offsets, ref sizes.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3538, Column 37 in _mem_alloc.h")]
        public static unsafe Result FlushAllocations(this Vma thisApi, Span<AllocatorT> allocator, uint allocationCount, AllocationT** allocations, Span<ulong> offsets, ulong* sizes)
        {
            // SpanOverloader
            return thisApi.FlushAllocations(ref allocator.GetPinnableReference(), allocationCount, allocations, ref offsets.GetPinnableReference(), sizes);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3538, Column 37 in _mem_alloc.h")]
        public static unsafe Result FlushAllocations(this Vma thisApi, Span<AllocatorT> allocator, uint allocationCount, AllocationT** allocations, Span<ulong> offsets, Span<ulong> sizes)
        {
            // SpanOverloader
            return thisApi.FlushAllocations(ref allocator.GetPinnableReference(), allocationCount, allocations, ref offsets.GetPinnableReference(), ref sizes.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3538, Column 37 in _mem_alloc.h")]
        public static unsafe Result FlushAllocations(this Vma thisApi, Span<AllocatorT> allocator, uint allocationCount, ref AllocationT* allocations, ulong* offsets, ulong* sizes)
        {
            // SpanOverloader
            return thisApi.FlushAllocations(ref allocator.GetPinnableReference(), allocationCount, ref allocations, offsets, sizes);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3538, Column 37 in _mem_alloc.h")]
        public static unsafe Result FlushAllocations(this Vma thisApi, Span<AllocatorT> allocator, uint allocationCount, ref AllocationT* allocations, ulong* offsets, Span<ulong> sizes)
        {
            // SpanOverloader
            return thisApi.FlushAllocations(ref allocator.GetPinnableReference(), allocationCount, ref allocations, offsets, ref sizes.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3538, Column 37 in _mem_alloc.h")]
        public static unsafe Result FlushAllocations(this Vma thisApi, Span<AllocatorT> allocator, uint allocationCount, ref AllocationT* allocations, Span<ulong> offsets, ulong* sizes)
        {
            // SpanOverloader
            return thisApi.FlushAllocations(ref allocator.GetPinnableReference(), allocationCount, ref allocations, ref offsets.GetPinnableReference(), sizes);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3538, Column 37 in _mem_alloc.h")]
        public static unsafe Result FlushAllocations(this Vma thisApi, Span<AllocatorT> allocator, uint allocationCount, ref AllocationT* allocations, Span<ulong> offsets, Span<ulong> sizes)
        {
            // SpanOverloader
            return thisApi.FlushAllocations(ref allocator.GetPinnableReference(), allocationCount, ref allocations, ref offsets.GetPinnableReference(), ref sizes.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3559, Column 37 in _mem_alloc.h")]
        public static unsafe Result InvalidateAllocations(this Vma thisApi, AllocatorT* allocator, uint allocationCount, AllocationT** allocations, ulong* offsets, Span<ulong> sizes)
        {
            // SpanOverloader
            return thisApi.InvalidateAllocations(allocator, allocationCount, allocations, offsets, ref sizes.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3559, Column 37 in _mem_alloc.h")]
        public static unsafe Result InvalidateAllocations(this Vma thisApi, AllocatorT* allocator, uint allocationCount, AllocationT** allocations, Span<ulong> offsets, ulong* sizes)
        {
            // SpanOverloader
            return thisApi.InvalidateAllocations(allocator, allocationCount, allocations, ref offsets.GetPinnableReference(), sizes);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3559, Column 37 in _mem_alloc.h")]
        public static unsafe Result InvalidateAllocations(this Vma thisApi, AllocatorT* allocator, uint allocationCount, AllocationT** allocations, Span<ulong> offsets, Span<ulong> sizes)
        {
            // SpanOverloader
            return thisApi.InvalidateAllocations(allocator, allocationCount, allocations, ref offsets.GetPinnableReference(), ref sizes.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3559, Column 37 in _mem_alloc.h")]
        public static unsafe Result InvalidateAllocations(this Vma thisApi, AllocatorT* allocator, uint allocationCount, ref AllocationT* allocations, ulong* offsets, Span<ulong> sizes)
        {
            // SpanOverloader
            return thisApi.InvalidateAllocations(allocator, allocationCount, ref allocations, offsets, ref sizes.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3559, Column 37 in _mem_alloc.h")]
        public static unsafe Result InvalidateAllocations(this Vma thisApi, AllocatorT* allocator, uint allocationCount, ref AllocationT* allocations, Span<ulong> offsets, ulong* sizes)
        {
            // SpanOverloader
            return thisApi.InvalidateAllocations(allocator, allocationCount, ref allocations, ref offsets.GetPinnableReference(), sizes);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3559, Column 37 in _mem_alloc.h")]
        public static unsafe Result InvalidateAllocations(this Vma thisApi, AllocatorT* allocator, uint allocationCount, ref AllocationT* allocations, Span<ulong> offsets, Span<ulong> sizes)
        {
            // SpanOverloader
            return thisApi.InvalidateAllocations(allocator, allocationCount, ref allocations, ref offsets.GetPinnableReference(), ref sizes.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3559, Column 37 in _mem_alloc.h")]
        public static unsafe Result InvalidateAllocations(this Vma thisApi, Span<AllocatorT> allocator, uint allocationCount, AllocationT** allocations, ulong* offsets, ulong* sizes)
        {
            // SpanOverloader
            return thisApi.InvalidateAllocations(ref allocator.GetPinnableReference(), allocationCount, allocations, offsets, sizes);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3559, Column 37 in _mem_alloc.h")]
        public static unsafe Result InvalidateAllocations(this Vma thisApi, Span<AllocatorT> allocator, uint allocationCount, AllocationT** allocations, ulong* offsets, Span<ulong> sizes)
        {
            // SpanOverloader
            return thisApi.InvalidateAllocations(ref allocator.GetPinnableReference(), allocationCount, allocations, offsets, ref sizes.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3559, Column 37 in _mem_alloc.h")]
        public static unsafe Result InvalidateAllocations(this Vma thisApi, Span<AllocatorT> allocator, uint allocationCount, AllocationT** allocations, Span<ulong> offsets, ulong* sizes)
        {
            // SpanOverloader
            return thisApi.InvalidateAllocations(ref allocator.GetPinnableReference(), allocationCount, allocations, ref offsets.GetPinnableReference(), sizes);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3559, Column 37 in _mem_alloc.h")]
        public static unsafe Result InvalidateAllocations(this Vma thisApi, Span<AllocatorT> allocator, uint allocationCount, AllocationT** allocations, Span<ulong> offsets, Span<ulong> sizes)
        {
            // SpanOverloader
            return thisApi.InvalidateAllocations(ref allocator.GetPinnableReference(), allocationCount, allocations, ref offsets.GetPinnableReference(), ref sizes.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3559, Column 37 in _mem_alloc.h")]
        public static unsafe Result InvalidateAllocations(this Vma thisApi, Span<AllocatorT> allocator, uint allocationCount, ref AllocationT* allocations, ulong* offsets, ulong* sizes)
        {
            // SpanOverloader
            return thisApi.InvalidateAllocations(ref allocator.GetPinnableReference(), allocationCount, ref allocations, offsets, sizes);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3559, Column 37 in _mem_alloc.h")]
        public static unsafe Result InvalidateAllocations(this Vma thisApi, Span<AllocatorT> allocator, uint allocationCount, ref AllocationT* allocations, ulong* offsets, Span<ulong> sizes)
        {
            // SpanOverloader
            return thisApi.InvalidateAllocations(ref allocator.GetPinnableReference(), allocationCount, ref allocations, offsets, ref sizes.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3559, Column 37 in _mem_alloc.h")]
        public static unsafe Result InvalidateAllocations(this Vma thisApi, Span<AllocatorT> allocator, uint allocationCount, ref AllocationT* allocations, Span<ulong> offsets, ulong* sizes)
        {
            // SpanOverloader
            return thisApi.InvalidateAllocations(ref allocator.GetPinnableReference(), allocationCount, ref allocations, ref offsets.GetPinnableReference(), sizes);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3559, Column 37 in _mem_alloc.h")]
        public static unsafe Result InvalidateAllocations(this Vma thisApi, Span<AllocatorT> allocator, uint allocationCount, ref AllocationT* allocations, Span<ulong> offsets, Span<ulong> sizes)
        {
            // SpanOverloader
            return thisApi.InvalidateAllocations(ref allocator.GetPinnableReference(), allocationCount, ref allocations, ref offsets.GetPinnableReference(), ref sizes.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3582, Column 37 in _mem_alloc.h")]
        public static unsafe Result CheckCorruption(this Vma thisApi, Span<AllocatorT> allocator, uint memoryTypeBits)
        {
            // SpanOverloader
            return thisApi.CheckCorruption(ref allocator.GetPinnableReference(), memoryTypeBits);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3748, Column 37 in _mem_alloc.h")]
        public static unsafe Result DefragmentationBegin(this Vma thisApi, AllocatorT* allocator, DefragmentationInfo2* pInfo, Span<DefragmentationStats> pStats, DefragmentationContextT** pContext)
        {
            // SpanOverloader
            return thisApi.DefragmentationBegin(allocator, pInfo, ref pStats.GetPinnableReference(), pContext);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3748, Column 37 in _mem_alloc.h")]
        public static unsafe Result DefragmentationBegin(this Vma thisApi, AllocatorT* allocator, DefragmentationInfo2* pInfo, Span<DefragmentationStats> pStats, ref DefragmentationContextT* pContext)
        {
            // SpanOverloader
            return thisApi.DefragmentationBegin(allocator, pInfo, ref pStats.GetPinnableReference(), ref pContext);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3748, Column 37 in _mem_alloc.h")]
        public static unsafe Result DefragmentationBegin(this Vma thisApi, AllocatorT* allocator, Span<DefragmentationInfo2> pInfo, DefragmentationStats* pStats, DefragmentationContextT** pContext)
        {
            // SpanOverloader
            return thisApi.DefragmentationBegin(allocator, ref pInfo.GetPinnableReference(), pStats, pContext);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3748, Column 37 in _mem_alloc.h")]
        public static unsafe Result DefragmentationBegin(this Vma thisApi, AllocatorT* allocator, Span<DefragmentationInfo2> pInfo, DefragmentationStats* pStats, ref DefragmentationContextT* pContext)
        {
            // SpanOverloader
            return thisApi.DefragmentationBegin(allocator, ref pInfo.GetPinnableReference(), pStats, ref pContext);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3748, Column 37 in _mem_alloc.h")]
        public static unsafe Result DefragmentationBegin(this Vma thisApi, AllocatorT* allocator, Span<DefragmentationInfo2> pInfo, Span<DefragmentationStats> pStats, DefragmentationContextT** pContext)
        {
            // SpanOverloader
            return thisApi.DefragmentationBegin(allocator, ref pInfo.GetPinnableReference(), ref pStats.GetPinnableReference(), pContext);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3748, Column 37 in _mem_alloc.h")]
        public static unsafe Result DefragmentationBegin(this Vma thisApi, AllocatorT* allocator, Span<DefragmentationInfo2> pInfo, Span<DefragmentationStats> pStats, ref DefragmentationContextT* pContext)
        {
            // SpanOverloader
            return thisApi.DefragmentationBegin(allocator, ref pInfo.GetPinnableReference(), ref pStats.GetPinnableReference(), ref pContext);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3748, Column 37 in _mem_alloc.h")]
        public static unsafe Result DefragmentationBegin(this Vma thisApi, Span<AllocatorT> allocator, DefragmentationInfo2* pInfo, DefragmentationStats* pStats, DefragmentationContextT** pContext)
        {
            // SpanOverloader
            return thisApi.DefragmentationBegin(ref allocator.GetPinnableReference(), pInfo, pStats, pContext);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3748, Column 37 in _mem_alloc.h")]
        public static unsafe Result DefragmentationBegin(this Vma thisApi, Span<AllocatorT> allocator, DefragmentationInfo2* pInfo, DefragmentationStats* pStats, ref DefragmentationContextT* pContext)
        {
            // SpanOverloader
            return thisApi.DefragmentationBegin(ref allocator.GetPinnableReference(), pInfo, pStats, ref pContext);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3748, Column 37 in _mem_alloc.h")]
        public static unsafe Result DefragmentationBegin(this Vma thisApi, Span<AllocatorT> allocator, DefragmentationInfo2* pInfo, Span<DefragmentationStats> pStats, DefragmentationContextT** pContext)
        {
            // SpanOverloader
            return thisApi.DefragmentationBegin(ref allocator.GetPinnableReference(), pInfo, ref pStats.GetPinnableReference(), pContext);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3748, Column 37 in _mem_alloc.h")]
        public static unsafe Result DefragmentationBegin(this Vma thisApi, Span<AllocatorT> allocator, DefragmentationInfo2* pInfo, Span<DefragmentationStats> pStats, ref DefragmentationContextT* pContext)
        {
            // SpanOverloader
            return thisApi.DefragmentationBegin(ref allocator.GetPinnableReference(), pInfo, ref pStats.GetPinnableReference(), ref pContext);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3748, Column 37 in _mem_alloc.h")]
        public static unsafe Result DefragmentationBegin(this Vma thisApi, Span<AllocatorT> allocator, Span<DefragmentationInfo2> pInfo, DefragmentationStats* pStats, DefragmentationContextT** pContext)
        {
            // SpanOverloader
            return thisApi.DefragmentationBegin(ref allocator.GetPinnableReference(), ref pInfo.GetPinnableReference(), pStats, pContext);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3748, Column 37 in _mem_alloc.h")]
        public static unsafe Result DefragmentationBegin(this Vma thisApi, Span<AllocatorT> allocator, Span<DefragmentationInfo2> pInfo, DefragmentationStats* pStats, ref DefragmentationContextT* pContext)
        {
            // SpanOverloader
            return thisApi.DefragmentationBegin(ref allocator.GetPinnableReference(), ref pInfo.GetPinnableReference(), pStats, ref pContext);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3748, Column 37 in _mem_alloc.h")]
        public static unsafe Result DefragmentationBegin(this Vma thisApi, Span<AllocatorT> allocator, Span<DefragmentationInfo2> pInfo, Span<DefragmentationStats> pStats, DefragmentationContextT** pContext)
        {
            // SpanOverloader
            return thisApi.DefragmentationBegin(ref allocator.GetPinnableReference(), ref pInfo.GetPinnableReference(), ref pStats.GetPinnableReference(), pContext);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3748, Column 37 in _mem_alloc.h")]
        public static unsafe Result DefragmentationBegin(this Vma thisApi, Span<AllocatorT> allocator, Span<DefragmentationInfo2> pInfo, Span<DefragmentationStats> pStats, ref DefragmentationContextT* pContext)
        {
            // SpanOverloader
            return thisApi.DefragmentationBegin(ref allocator.GetPinnableReference(), ref pInfo.GetPinnableReference(), ref pStats.GetPinnableReference(), ref pContext);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3759, Column 37 in _mem_alloc.h")]
        public static unsafe Result DefragmentationEnd(this Vma thisApi, AllocatorT* allocator, Span<DefragmentationContextT> context)
        {
            // SpanOverloader
            return thisApi.DefragmentationEnd(allocator, ref context.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3759, Column 37 in _mem_alloc.h")]
        public static unsafe Result DefragmentationEnd(this Vma thisApi, Span<AllocatorT> allocator, DefragmentationContextT* context)
        {
            // SpanOverloader
            return thisApi.DefragmentationEnd(ref allocator.GetPinnableReference(), context);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3759, Column 37 in _mem_alloc.h")]
        public static unsafe Result DefragmentationEnd(this Vma thisApi, Span<AllocatorT> allocator, Span<DefragmentationContextT> context)
        {
            // SpanOverloader
            return thisApi.DefragmentationEnd(ref allocator.GetPinnableReference(), ref context.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3763, Column 37 in _mem_alloc.h")]
        public static unsafe Result BeginDefragmentationPass(this Vma thisApi, AllocatorT* allocator, DefragmentationContextT* context, Span<DefragmentationPassInfo> pInfo)
        {
            // SpanOverloader
            return thisApi.BeginDefragmentationPass(allocator, context, ref pInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3763, Column 37 in _mem_alloc.h")]
        public static unsafe Result BeginDefragmentationPass(this Vma thisApi, AllocatorT* allocator, Span<DefragmentationContextT> context, DefragmentationPassInfo* pInfo)
        {
            // SpanOverloader
            return thisApi.BeginDefragmentationPass(allocator, ref context.GetPinnableReference(), pInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3763, Column 37 in _mem_alloc.h")]
        public static unsafe Result BeginDefragmentationPass(this Vma thisApi, AllocatorT* allocator, Span<DefragmentationContextT> context, Span<DefragmentationPassInfo> pInfo)
        {
            // SpanOverloader
            return thisApi.BeginDefragmentationPass(allocator, ref context.GetPinnableReference(), ref pInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3763, Column 37 in _mem_alloc.h")]
        public static unsafe Result BeginDefragmentationPass(this Vma thisApi, Span<AllocatorT> allocator, DefragmentationContextT* context, DefragmentationPassInfo* pInfo)
        {
            // SpanOverloader
            return thisApi.BeginDefragmentationPass(ref allocator.GetPinnableReference(), context, pInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3763, Column 37 in _mem_alloc.h")]
        public static unsafe Result BeginDefragmentationPass(this Vma thisApi, Span<AllocatorT> allocator, DefragmentationContextT* context, Span<DefragmentationPassInfo> pInfo)
        {
            // SpanOverloader
            return thisApi.BeginDefragmentationPass(ref allocator.GetPinnableReference(), context, ref pInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3763, Column 37 in _mem_alloc.h")]
        public static unsafe Result BeginDefragmentationPass(this Vma thisApi, Span<AllocatorT> allocator, Span<DefragmentationContextT> context, DefragmentationPassInfo* pInfo)
        {
            // SpanOverloader
            return thisApi.BeginDefragmentationPass(ref allocator.GetPinnableReference(), ref context.GetPinnableReference(), pInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3763, Column 37 in _mem_alloc.h")]
        public static unsafe Result BeginDefragmentationPass(this Vma thisApi, Span<AllocatorT> allocator, Span<DefragmentationContextT> context, Span<DefragmentationPassInfo> pInfo)
        {
            // SpanOverloader
            return thisApi.BeginDefragmentationPass(ref allocator.GetPinnableReference(), ref context.GetPinnableReference(), ref pInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3768, Column 37 in _mem_alloc.h")]
        public static unsafe Result EndDefragmentationPass(this Vma thisApi, AllocatorT* allocator, Span<DefragmentationContextT> context)
        {
            // SpanOverloader
            return thisApi.EndDefragmentationPass(allocator, ref context.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3768, Column 37 in _mem_alloc.h")]
        public static unsafe Result EndDefragmentationPass(this Vma thisApi, Span<AllocatorT> allocator, DefragmentationContextT* context)
        {
            // SpanOverloader
            return thisApi.EndDefragmentationPass(ref allocator.GetPinnableReference(), context);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3768, Column 37 in _mem_alloc.h")]
        public static unsafe Result EndDefragmentationPass(this Vma thisApi, Span<AllocatorT> allocator, Span<DefragmentationContextT> context)
        {
            // SpanOverloader
            return thisApi.EndDefragmentationPass(ref allocator.GetPinnableReference(), ref context.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        public static unsafe Result Defragment(this Vma thisApi, AllocatorT* allocator, AllocationT** pAllocations, uint allocationCount, uint* pAllocationsChanged, DefragmentationInfo* pDefragmentationInfo, Span<DefragmentationStats> pDefragmentationStats)
        {
            // SpanOverloader
            return thisApi.Defragment(allocator, pAllocations, allocationCount, pAllocationsChanged, pDefragmentationInfo, ref pDefragmentationStats.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        public static unsafe Result Defragment(this Vma thisApi, AllocatorT* allocator, AllocationT** pAllocations, uint allocationCount, uint* pAllocationsChanged, Span<DefragmentationInfo> pDefragmentationInfo, DefragmentationStats* pDefragmentationStats)
        {
            // SpanOverloader
            return thisApi.Defragment(allocator, pAllocations, allocationCount, pAllocationsChanged, ref pDefragmentationInfo.GetPinnableReference(), pDefragmentationStats);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        public static unsafe Result Defragment(this Vma thisApi, AllocatorT* allocator, AllocationT** pAllocations, uint allocationCount, uint* pAllocationsChanged, Span<DefragmentationInfo> pDefragmentationInfo, Span<DefragmentationStats> pDefragmentationStats)
        {
            // SpanOverloader
            return thisApi.Defragment(allocator, pAllocations, allocationCount, pAllocationsChanged, ref pDefragmentationInfo.GetPinnableReference(), ref pDefragmentationStats.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        public static unsafe Result Defragment(this Vma thisApi, AllocatorT* allocator, AllocationT** pAllocations, uint allocationCount, Span<uint> pAllocationsChanged, DefragmentationInfo* pDefragmentationInfo, DefragmentationStats* pDefragmentationStats)
        {
            // SpanOverloader
            return thisApi.Defragment(allocator, pAllocations, allocationCount, ref pAllocationsChanged.GetPinnableReference(), pDefragmentationInfo, pDefragmentationStats);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        public static unsafe Result Defragment(this Vma thisApi, AllocatorT* allocator, AllocationT** pAllocations, uint allocationCount, Span<uint> pAllocationsChanged, DefragmentationInfo* pDefragmentationInfo, Span<DefragmentationStats> pDefragmentationStats)
        {
            // SpanOverloader
            return thisApi.Defragment(allocator, pAllocations, allocationCount, ref pAllocationsChanged.GetPinnableReference(), pDefragmentationInfo, ref pDefragmentationStats.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        public static unsafe Result Defragment(this Vma thisApi, AllocatorT* allocator, AllocationT** pAllocations, uint allocationCount, Span<uint> pAllocationsChanged, Span<DefragmentationInfo> pDefragmentationInfo, DefragmentationStats* pDefragmentationStats)
        {
            // SpanOverloader
            return thisApi.Defragment(allocator, pAllocations, allocationCount, ref pAllocationsChanged.GetPinnableReference(), ref pDefragmentationInfo.GetPinnableReference(), pDefragmentationStats);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        public static unsafe Result Defragment(this Vma thisApi, AllocatorT* allocator, AllocationT** pAllocations, uint allocationCount, Span<uint> pAllocationsChanged, Span<DefragmentationInfo> pDefragmentationInfo, Span<DefragmentationStats> pDefragmentationStats)
        {
            // SpanOverloader
            return thisApi.Defragment(allocator, pAllocations, allocationCount, ref pAllocationsChanged.GetPinnableReference(), ref pDefragmentationInfo.GetPinnableReference(), ref pDefragmentationStats.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        public static unsafe Result Defragment(this Vma thisApi, AllocatorT* allocator, ref AllocationT* pAllocations, uint allocationCount, uint* pAllocationsChanged, DefragmentationInfo* pDefragmentationInfo, Span<DefragmentationStats> pDefragmentationStats)
        {
            // SpanOverloader
            return thisApi.Defragment(allocator, ref pAllocations, allocationCount, pAllocationsChanged, pDefragmentationInfo, ref pDefragmentationStats.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        public static unsafe Result Defragment(this Vma thisApi, AllocatorT* allocator, ref AllocationT* pAllocations, uint allocationCount, uint* pAllocationsChanged, Span<DefragmentationInfo> pDefragmentationInfo, DefragmentationStats* pDefragmentationStats)
        {
            // SpanOverloader
            return thisApi.Defragment(allocator, ref pAllocations, allocationCount, pAllocationsChanged, ref pDefragmentationInfo.GetPinnableReference(), pDefragmentationStats);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        public static unsafe Result Defragment(this Vma thisApi, AllocatorT* allocator, ref AllocationT* pAllocations, uint allocationCount, uint* pAllocationsChanged, Span<DefragmentationInfo> pDefragmentationInfo, Span<DefragmentationStats> pDefragmentationStats)
        {
            // SpanOverloader
            return thisApi.Defragment(allocator, ref pAllocations, allocationCount, pAllocationsChanged, ref pDefragmentationInfo.GetPinnableReference(), ref pDefragmentationStats.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        public static unsafe Result Defragment(this Vma thisApi, AllocatorT* allocator, ref AllocationT* pAllocations, uint allocationCount, Span<uint> pAllocationsChanged, DefragmentationInfo* pDefragmentationInfo, DefragmentationStats* pDefragmentationStats)
        {
            // SpanOverloader
            return thisApi.Defragment(allocator, ref pAllocations, allocationCount, ref pAllocationsChanged.GetPinnableReference(), pDefragmentationInfo, pDefragmentationStats);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        public static unsafe Result Defragment(this Vma thisApi, AllocatorT* allocator, ref AllocationT* pAllocations, uint allocationCount, Span<uint> pAllocationsChanged, DefragmentationInfo* pDefragmentationInfo, Span<DefragmentationStats> pDefragmentationStats)
        {
            // SpanOverloader
            return thisApi.Defragment(allocator, ref pAllocations, allocationCount, ref pAllocationsChanged.GetPinnableReference(), pDefragmentationInfo, ref pDefragmentationStats.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        public static unsafe Result Defragment(this Vma thisApi, AllocatorT* allocator, ref AllocationT* pAllocations, uint allocationCount, Span<uint> pAllocationsChanged, Span<DefragmentationInfo> pDefragmentationInfo, DefragmentationStats* pDefragmentationStats)
        {
            // SpanOverloader
            return thisApi.Defragment(allocator, ref pAllocations, allocationCount, ref pAllocationsChanged.GetPinnableReference(), ref pDefragmentationInfo.GetPinnableReference(), pDefragmentationStats);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        public static unsafe Result Defragment(this Vma thisApi, AllocatorT* allocator, ref AllocationT* pAllocations, uint allocationCount, Span<uint> pAllocationsChanged, Span<DefragmentationInfo> pDefragmentationInfo, Span<DefragmentationStats> pDefragmentationStats)
        {
            // SpanOverloader
            return thisApi.Defragment(allocator, ref pAllocations, allocationCount, ref pAllocationsChanged.GetPinnableReference(), ref pDefragmentationInfo.GetPinnableReference(), ref pDefragmentationStats.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        public static unsafe Result Defragment(this Vma thisApi, Span<AllocatorT> allocator, AllocationT** pAllocations, uint allocationCount, uint* pAllocationsChanged, DefragmentationInfo* pDefragmentationInfo, DefragmentationStats* pDefragmentationStats)
        {
            // SpanOverloader
            return thisApi.Defragment(ref allocator.GetPinnableReference(), pAllocations, allocationCount, pAllocationsChanged, pDefragmentationInfo, pDefragmentationStats);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        public static unsafe Result Defragment(this Vma thisApi, Span<AllocatorT> allocator, AllocationT** pAllocations, uint allocationCount, uint* pAllocationsChanged, DefragmentationInfo* pDefragmentationInfo, Span<DefragmentationStats> pDefragmentationStats)
        {
            // SpanOverloader
            return thisApi.Defragment(ref allocator.GetPinnableReference(), pAllocations, allocationCount, pAllocationsChanged, pDefragmentationInfo, ref pDefragmentationStats.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        public static unsafe Result Defragment(this Vma thisApi, Span<AllocatorT> allocator, AllocationT** pAllocations, uint allocationCount, uint* pAllocationsChanged, Span<DefragmentationInfo> pDefragmentationInfo, DefragmentationStats* pDefragmentationStats)
        {
            // SpanOverloader
            return thisApi.Defragment(ref allocator.GetPinnableReference(), pAllocations, allocationCount, pAllocationsChanged, ref pDefragmentationInfo.GetPinnableReference(), pDefragmentationStats);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        public static unsafe Result Defragment(this Vma thisApi, Span<AllocatorT> allocator, AllocationT** pAllocations, uint allocationCount, uint* pAllocationsChanged, Span<DefragmentationInfo> pDefragmentationInfo, Span<DefragmentationStats> pDefragmentationStats)
        {
            // SpanOverloader
            return thisApi.Defragment(ref allocator.GetPinnableReference(), pAllocations, allocationCount, pAllocationsChanged, ref pDefragmentationInfo.GetPinnableReference(), ref pDefragmentationStats.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        public static unsafe Result Defragment(this Vma thisApi, Span<AllocatorT> allocator, AllocationT** pAllocations, uint allocationCount, Span<uint> pAllocationsChanged, DefragmentationInfo* pDefragmentationInfo, DefragmentationStats* pDefragmentationStats)
        {
            // SpanOverloader
            return thisApi.Defragment(ref allocator.GetPinnableReference(), pAllocations, allocationCount, ref pAllocationsChanged.GetPinnableReference(), pDefragmentationInfo, pDefragmentationStats);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        public static unsafe Result Defragment(this Vma thisApi, Span<AllocatorT> allocator, AllocationT** pAllocations, uint allocationCount, Span<uint> pAllocationsChanged, DefragmentationInfo* pDefragmentationInfo, Span<DefragmentationStats> pDefragmentationStats)
        {
            // SpanOverloader
            return thisApi.Defragment(ref allocator.GetPinnableReference(), pAllocations, allocationCount, ref pAllocationsChanged.GetPinnableReference(), pDefragmentationInfo, ref pDefragmentationStats.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        public static unsafe Result Defragment(this Vma thisApi, Span<AllocatorT> allocator, AllocationT** pAllocations, uint allocationCount, Span<uint> pAllocationsChanged, Span<DefragmentationInfo> pDefragmentationInfo, DefragmentationStats* pDefragmentationStats)
        {
            // SpanOverloader
            return thisApi.Defragment(ref allocator.GetPinnableReference(), pAllocations, allocationCount, ref pAllocationsChanged.GetPinnableReference(), ref pDefragmentationInfo.GetPinnableReference(), pDefragmentationStats);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        public static unsafe Result Defragment(this Vma thisApi, Span<AllocatorT> allocator, AllocationT** pAllocations, uint allocationCount, Span<uint> pAllocationsChanged, Span<DefragmentationInfo> pDefragmentationInfo, Span<DefragmentationStats> pDefragmentationStats)
        {
            // SpanOverloader
            return thisApi.Defragment(ref allocator.GetPinnableReference(), pAllocations, allocationCount, ref pAllocationsChanged.GetPinnableReference(), ref pDefragmentationInfo.GetPinnableReference(), ref pDefragmentationStats.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        public static unsafe Result Defragment(this Vma thisApi, Span<AllocatorT> allocator, ref AllocationT* pAllocations, uint allocationCount, uint* pAllocationsChanged, DefragmentationInfo* pDefragmentationInfo, DefragmentationStats* pDefragmentationStats)
        {
            // SpanOverloader
            return thisApi.Defragment(ref allocator.GetPinnableReference(), ref pAllocations, allocationCount, pAllocationsChanged, pDefragmentationInfo, pDefragmentationStats);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        public static unsafe Result Defragment(this Vma thisApi, Span<AllocatorT> allocator, ref AllocationT* pAllocations, uint allocationCount, uint* pAllocationsChanged, DefragmentationInfo* pDefragmentationInfo, Span<DefragmentationStats> pDefragmentationStats)
        {
            // SpanOverloader
            return thisApi.Defragment(ref allocator.GetPinnableReference(), ref pAllocations, allocationCount, pAllocationsChanged, pDefragmentationInfo, ref pDefragmentationStats.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        public static unsafe Result Defragment(this Vma thisApi, Span<AllocatorT> allocator, ref AllocationT* pAllocations, uint allocationCount, uint* pAllocationsChanged, Span<DefragmentationInfo> pDefragmentationInfo, DefragmentationStats* pDefragmentationStats)
        {
            // SpanOverloader
            return thisApi.Defragment(ref allocator.GetPinnableReference(), ref pAllocations, allocationCount, pAllocationsChanged, ref pDefragmentationInfo.GetPinnableReference(), pDefragmentationStats);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        public static unsafe Result Defragment(this Vma thisApi, Span<AllocatorT> allocator, ref AllocationT* pAllocations, uint allocationCount, uint* pAllocationsChanged, Span<DefragmentationInfo> pDefragmentationInfo, Span<DefragmentationStats> pDefragmentationStats)
        {
            // SpanOverloader
            return thisApi.Defragment(ref allocator.GetPinnableReference(), ref pAllocations, allocationCount, pAllocationsChanged, ref pDefragmentationInfo.GetPinnableReference(), ref pDefragmentationStats.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        public static unsafe Result Defragment(this Vma thisApi, Span<AllocatorT> allocator, ref AllocationT* pAllocations, uint allocationCount, Span<uint> pAllocationsChanged, DefragmentationInfo* pDefragmentationInfo, DefragmentationStats* pDefragmentationStats)
        {
            // SpanOverloader
            return thisApi.Defragment(ref allocator.GetPinnableReference(), ref pAllocations, allocationCount, ref pAllocationsChanged.GetPinnableReference(), pDefragmentationInfo, pDefragmentationStats);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        public static unsafe Result Defragment(this Vma thisApi, Span<AllocatorT> allocator, ref AllocationT* pAllocations, uint allocationCount, Span<uint> pAllocationsChanged, DefragmentationInfo* pDefragmentationInfo, Span<DefragmentationStats> pDefragmentationStats)
        {
            // SpanOverloader
            return thisApi.Defragment(ref allocator.GetPinnableReference(), ref pAllocations, allocationCount, ref pAllocationsChanged.GetPinnableReference(), pDefragmentationInfo, ref pDefragmentationStats.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        public static unsafe Result Defragment(this Vma thisApi, Span<AllocatorT> allocator, ref AllocationT* pAllocations, uint allocationCount, Span<uint> pAllocationsChanged, Span<DefragmentationInfo> pDefragmentationInfo, DefragmentationStats* pDefragmentationStats)
        {
            // SpanOverloader
            return thisApi.Defragment(ref allocator.GetPinnableReference(), ref pAllocations, allocationCount, ref pAllocationsChanged.GetPinnableReference(), ref pDefragmentationInfo.GetPinnableReference(), pDefragmentationStats);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3813, Column 37 in _mem_alloc.h")]
        public static unsafe Result Defragment(this Vma thisApi, Span<AllocatorT> allocator, ref AllocationT* pAllocations, uint allocationCount, Span<uint> pAllocationsChanged, Span<DefragmentationInfo> pDefragmentationInfo, Span<DefragmentationStats> pDefragmentationStats)
        {
            // SpanOverloader
            return thisApi.Defragment(ref allocator.GetPinnableReference(), ref pAllocations, allocationCount, ref pAllocationsChanged.GetPinnableReference(), ref pDefragmentationInfo.GetPinnableReference(), ref pDefragmentationStats.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3833, Column 37 in _mem_alloc.h")]
        public static unsafe Result BindBufferMemory(this Vma thisApi, AllocatorT* allocator, Span<AllocationT> allocation, ulong buffer)
        {
            // SpanOverloader
            return thisApi.BindBufferMemory(allocator, ref allocation.GetPinnableReference(), buffer);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3833, Column 37 in _mem_alloc.h")]
        public static unsafe Result BindBufferMemory(this Vma thisApi, Span<AllocatorT> allocator, AllocationT* allocation, ulong buffer)
        {
            // SpanOverloader
            return thisApi.BindBufferMemory(ref allocator.GetPinnableReference(), allocation, buffer);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3833, Column 37 in _mem_alloc.h")]
        public static unsafe Result BindBufferMemory(this Vma thisApi, Span<AllocatorT> allocator, Span<AllocationT> allocation, ulong buffer)
        {
            // SpanOverloader
            return thisApi.BindBufferMemory(ref allocator.GetPinnableReference(), ref allocation.GetPinnableReference(), buffer);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3848, Column 37 in _mem_alloc.h")]
        public static unsafe Result BindBufferMemory2<T0>(this Vma thisApi, AllocatorT* allocator, AllocationT* allocation, ulong allocationLocalOffset, ulong buffer, Span<T0> pNext) where T0 : unmanaged
        {
            // SpanOverloader
            return thisApi.BindBufferMemory2(allocator, allocation, allocationLocalOffset, buffer, ref pNext.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3848, Column 37 in _mem_alloc.h")]
        public static unsafe Result BindBufferMemory2(this Vma thisApi, AllocatorT* allocator, Span<AllocationT> allocation, ulong allocationLocalOffset, ulong buffer, void* pNext)
        {
            // SpanOverloader
            return thisApi.BindBufferMemory2(allocator, ref allocation.GetPinnableReference(), allocationLocalOffset, buffer, pNext);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3848, Column 37 in _mem_alloc.h")]
        public static unsafe Result BindBufferMemory2<T0>(this Vma thisApi, AllocatorT* allocator, Span<AllocationT> allocation, ulong allocationLocalOffset, ulong buffer, Span<T0> pNext) where T0 : unmanaged
        {
            // SpanOverloader
            return thisApi.BindBufferMemory2(allocator, ref allocation.GetPinnableReference(), allocationLocalOffset, buffer, ref pNext.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3848, Column 37 in _mem_alloc.h")]
        public static unsafe Result BindBufferMemory2(this Vma thisApi, Span<AllocatorT> allocator, AllocationT* allocation, ulong allocationLocalOffset, ulong buffer, void* pNext)
        {
            // SpanOverloader
            return thisApi.BindBufferMemory2(ref allocator.GetPinnableReference(), allocation, allocationLocalOffset, buffer, pNext);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3848, Column 37 in _mem_alloc.h")]
        public static unsafe Result BindBufferMemory2<T0>(this Vma thisApi, Span<AllocatorT> allocator, AllocationT* allocation, ulong allocationLocalOffset, ulong buffer, Span<T0> pNext) where T0 : unmanaged
        {
            // SpanOverloader
            return thisApi.BindBufferMemory2(ref allocator.GetPinnableReference(), allocation, allocationLocalOffset, buffer, ref pNext.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3848, Column 37 in _mem_alloc.h")]
        public static unsafe Result BindBufferMemory2(this Vma thisApi, Span<AllocatorT> allocator, Span<AllocationT> allocation, ulong allocationLocalOffset, ulong buffer, void* pNext)
        {
            // SpanOverloader
            return thisApi.BindBufferMemory2(ref allocator.GetPinnableReference(), ref allocation.GetPinnableReference(), allocationLocalOffset, buffer, pNext);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3848, Column 37 in _mem_alloc.h")]
        public static unsafe Result BindBufferMemory2<T0>(this Vma thisApi, Span<AllocatorT> allocator, Span<AllocationT> allocation, ulong allocationLocalOffset, ulong buffer, Span<T0> pNext) where T0 : unmanaged
        {
            // SpanOverloader
            return thisApi.BindBufferMemory2(ref allocator.GetPinnableReference(), ref allocation.GetPinnableReference(), allocationLocalOffset, buffer, ref pNext.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3867, Column 37 in _mem_alloc.h")]
        public static unsafe Result BindImageMemory(this Vma thisApi, AllocatorT* allocator, Span<AllocationT> allocation, ulong image)
        {
            // SpanOverloader
            return thisApi.BindImageMemory(allocator, ref allocation.GetPinnableReference(), image);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3867, Column 37 in _mem_alloc.h")]
        public static unsafe Result BindImageMemory(this Vma thisApi, Span<AllocatorT> allocator, AllocationT* allocation, ulong image)
        {
            // SpanOverloader
            return thisApi.BindImageMemory(ref allocator.GetPinnableReference(), allocation, image);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3867, Column 37 in _mem_alloc.h")]
        public static unsafe Result BindImageMemory(this Vma thisApi, Span<AllocatorT> allocator, Span<AllocationT> allocation, ulong image)
        {
            // SpanOverloader
            return thisApi.BindImageMemory(ref allocator.GetPinnableReference(), ref allocation.GetPinnableReference(), image);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3882, Column 37 in _mem_alloc.h")]
        public static unsafe Result BindImageMemory2<T0>(this Vma thisApi, AllocatorT* allocator, AllocationT* allocation, ulong allocationLocalOffset, ulong image, Span<T0> pNext) where T0 : unmanaged
        {
            // SpanOverloader
            return thisApi.BindImageMemory2(allocator, allocation, allocationLocalOffset, image, ref pNext.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3882, Column 37 in _mem_alloc.h")]
        public static unsafe Result BindImageMemory2(this Vma thisApi, AllocatorT* allocator, Span<AllocationT> allocation, ulong allocationLocalOffset, ulong image, void* pNext)
        {
            // SpanOverloader
            return thisApi.BindImageMemory2(allocator, ref allocation.GetPinnableReference(), allocationLocalOffset, image, pNext);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3882, Column 37 in _mem_alloc.h")]
        public static unsafe Result BindImageMemory2<T0>(this Vma thisApi, AllocatorT* allocator, Span<AllocationT> allocation, ulong allocationLocalOffset, ulong image, Span<T0> pNext) where T0 : unmanaged
        {
            // SpanOverloader
            return thisApi.BindImageMemory2(allocator, ref allocation.GetPinnableReference(), allocationLocalOffset, image, ref pNext.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3882, Column 37 in _mem_alloc.h")]
        public static unsafe Result BindImageMemory2(this Vma thisApi, Span<AllocatorT> allocator, AllocationT* allocation, ulong allocationLocalOffset, ulong image, void* pNext)
        {
            // SpanOverloader
            return thisApi.BindImageMemory2(ref allocator.GetPinnableReference(), allocation, allocationLocalOffset, image, pNext);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3882, Column 37 in _mem_alloc.h")]
        public static unsafe Result BindImageMemory2<T0>(this Vma thisApi, Span<AllocatorT> allocator, AllocationT* allocation, ulong allocationLocalOffset, ulong image, Span<T0> pNext) where T0 : unmanaged
        {
            // SpanOverloader
            return thisApi.BindImageMemory2(ref allocator.GetPinnableReference(), allocation, allocationLocalOffset, image, ref pNext.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3882, Column 37 in _mem_alloc.h")]
        public static unsafe Result BindImageMemory2(this Vma thisApi, Span<AllocatorT> allocator, Span<AllocationT> allocation, ulong allocationLocalOffset, ulong image, void* pNext)
        {
            // SpanOverloader
            return thisApi.BindImageMemory2(ref allocator.GetPinnableReference(), ref allocation.GetPinnableReference(), allocationLocalOffset, image, pNext);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3882, Column 37 in _mem_alloc.h")]
        public static unsafe Result BindImageMemory2<T0>(this Vma thisApi, Span<AllocatorT> allocator, Span<AllocationT> allocation, ulong allocationLocalOffset, ulong image, Span<T0> pNext) where T0 : unmanaged
        {
            // SpanOverloader
            return thisApi.BindImageMemory2(ref allocator.GetPinnableReference(), ref allocation.GetPinnableReference(), allocationLocalOffset, image, ref pNext.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, AllocatorT* allocator, BufferCreateInfo* pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pBuffer, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(allocator, pBufferCreateInfo, pAllocationCreateInfo, pBuffer, pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, AllocatorT* allocator, BufferCreateInfo* pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pBuffer, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(allocator, pBufferCreateInfo, pAllocationCreateInfo, pBuffer, ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, AllocatorT* allocator, BufferCreateInfo* pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, Span<ulong> pBuffer, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(allocator, pBufferCreateInfo, pAllocationCreateInfo, ref pBuffer.GetPinnableReference(), pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, AllocatorT* allocator, BufferCreateInfo* pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, Span<ulong> pBuffer, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(allocator, pBufferCreateInfo, pAllocationCreateInfo, ref pBuffer.GetPinnableReference(), pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, AllocatorT* allocator, BufferCreateInfo* pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, Span<ulong> pBuffer, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(allocator, pBufferCreateInfo, pAllocationCreateInfo, ref pBuffer.GetPinnableReference(), ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, AllocatorT* allocator, BufferCreateInfo* pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, Span<ulong> pBuffer, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(allocator, pBufferCreateInfo, pAllocationCreateInfo, ref pBuffer.GetPinnableReference(), ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, AllocatorT* allocator, BufferCreateInfo* pBufferCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, ulong* pBuffer, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(allocator, pBufferCreateInfo, ref pAllocationCreateInfo.GetPinnableReference(), pBuffer, pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, AllocatorT* allocator, BufferCreateInfo* pBufferCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, ulong* pBuffer, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(allocator, pBufferCreateInfo, ref pAllocationCreateInfo.GetPinnableReference(), pBuffer, pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, AllocatorT* allocator, BufferCreateInfo* pBufferCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, ulong* pBuffer, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(allocator, pBufferCreateInfo, ref pAllocationCreateInfo.GetPinnableReference(), pBuffer, ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, AllocatorT* allocator, BufferCreateInfo* pBufferCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, ulong* pBuffer, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(allocator, pBufferCreateInfo, ref pAllocationCreateInfo.GetPinnableReference(), pBuffer, ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, AllocatorT* allocator, BufferCreateInfo* pBufferCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<ulong> pBuffer, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(allocator, pBufferCreateInfo, ref pAllocationCreateInfo.GetPinnableReference(), ref pBuffer.GetPinnableReference(), pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, AllocatorT* allocator, BufferCreateInfo* pBufferCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<ulong> pBuffer, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(allocator, pBufferCreateInfo, ref pAllocationCreateInfo.GetPinnableReference(), ref pBuffer.GetPinnableReference(), pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, AllocatorT* allocator, BufferCreateInfo* pBufferCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<ulong> pBuffer, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(allocator, pBufferCreateInfo, ref pAllocationCreateInfo.GetPinnableReference(), ref pBuffer.GetPinnableReference(), ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, AllocatorT* allocator, BufferCreateInfo* pBufferCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<ulong> pBuffer, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(allocator, pBufferCreateInfo, ref pAllocationCreateInfo.GetPinnableReference(), ref pBuffer.GetPinnableReference(), ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, AllocatorT* allocator, Span<BufferCreateInfo> pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pBuffer, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(allocator, ref pBufferCreateInfo.GetPinnableReference(), pAllocationCreateInfo, pBuffer, pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, AllocatorT* allocator, Span<BufferCreateInfo> pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pBuffer, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(allocator, ref pBufferCreateInfo.GetPinnableReference(), pAllocationCreateInfo, pBuffer, pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, AllocatorT* allocator, Span<BufferCreateInfo> pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pBuffer, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(allocator, ref pBufferCreateInfo.GetPinnableReference(), pAllocationCreateInfo, pBuffer, ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, AllocatorT* allocator, Span<BufferCreateInfo> pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pBuffer, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(allocator, ref pBufferCreateInfo.GetPinnableReference(), pAllocationCreateInfo, pBuffer, ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, AllocatorT* allocator, Span<BufferCreateInfo> pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, Span<ulong> pBuffer, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(allocator, ref pBufferCreateInfo.GetPinnableReference(), pAllocationCreateInfo, ref pBuffer.GetPinnableReference(), pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, AllocatorT* allocator, Span<BufferCreateInfo> pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, Span<ulong> pBuffer, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(allocator, ref pBufferCreateInfo.GetPinnableReference(), pAllocationCreateInfo, ref pBuffer.GetPinnableReference(), pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, AllocatorT* allocator, Span<BufferCreateInfo> pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, Span<ulong> pBuffer, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(allocator, ref pBufferCreateInfo.GetPinnableReference(), pAllocationCreateInfo, ref pBuffer.GetPinnableReference(), ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, AllocatorT* allocator, Span<BufferCreateInfo> pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, Span<ulong> pBuffer, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(allocator, ref pBufferCreateInfo.GetPinnableReference(), pAllocationCreateInfo, ref pBuffer.GetPinnableReference(), ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, AllocatorT* allocator, Span<BufferCreateInfo> pBufferCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, ulong* pBuffer, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(allocator, ref pBufferCreateInfo.GetPinnableReference(), ref pAllocationCreateInfo.GetPinnableReference(), pBuffer, pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, AllocatorT* allocator, Span<BufferCreateInfo> pBufferCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, ulong* pBuffer, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(allocator, ref pBufferCreateInfo.GetPinnableReference(), ref pAllocationCreateInfo.GetPinnableReference(), pBuffer, pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, AllocatorT* allocator, Span<BufferCreateInfo> pBufferCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, ulong* pBuffer, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(allocator, ref pBufferCreateInfo.GetPinnableReference(), ref pAllocationCreateInfo.GetPinnableReference(), pBuffer, ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, AllocatorT* allocator, Span<BufferCreateInfo> pBufferCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, ulong* pBuffer, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(allocator, ref pBufferCreateInfo.GetPinnableReference(), ref pAllocationCreateInfo.GetPinnableReference(), pBuffer, ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, AllocatorT* allocator, Span<BufferCreateInfo> pBufferCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<ulong> pBuffer, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(allocator, ref pBufferCreateInfo.GetPinnableReference(), ref pAllocationCreateInfo.GetPinnableReference(), ref pBuffer.GetPinnableReference(), pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, AllocatorT* allocator, Span<BufferCreateInfo> pBufferCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<ulong> pBuffer, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(allocator, ref pBufferCreateInfo.GetPinnableReference(), ref pAllocationCreateInfo.GetPinnableReference(), ref pBuffer.GetPinnableReference(), pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, AllocatorT* allocator, Span<BufferCreateInfo> pBufferCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<ulong> pBuffer, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(allocator, ref pBufferCreateInfo.GetPinnableReference(), ref pAllocationCreateInfo.GetPinnableReference(), ref pBuffer.GetPinnableReference(), ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, AllocatorT* allocator, Span<BufferCreateInfo> pBufferCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<ulong> pBuffer, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(allocator, ref pBufferCreateInfo.GetPinnableReference(), ref pAllocationCreateInfo.GetPinnableReference(), ref pBuffer.GetPinnableReference(), ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, Span<AllocatorT> allocator, BufferCreateInfo* pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pBuffer, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(ref allocator.GetPinnableReference(), pBufferCreateInfo, pAllocationCreateInfo, pBuffer, pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, Span<AllocatorT> allocator, BufferCreateInfo* pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pBuffer, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(ref allocator.GetPinnableReference(), pBufferCreateInfo, pAllocationCreateInfo, pBuffer, pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, Span<AllocatorT> allocator, BufferCreateInfo* pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pBuffer, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(ref allocator.GetPinnableReference(), pBufferCreateInfo, pAllocationCreateInfo, pBuffer, ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, Span<AllocatorT> allocator, BufferCreateInfo* pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pBuffer, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(ref allocator.GetPinnableReference(), pBufferCreateInfo, pAllocationCreateInfo, pBuffer, ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, Span<AllocatorT> allocator, BufferCreateInfo* pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, Span<ulong> pBuffer, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(ref allocator.GetPinnableReference(), pBufferCreateInfo, pAllocationCreateInfo, ref pBuffer.GetPinnableReference(), pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, Span<AllocatorT> allocator, BufferCreateInfo* pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, Span<ulong> pBuffer, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(ref allocator.GetPinnableReference(), pBufferCreateInfo, pAllocationCreateInfo, ref pBuffer.GetPinnableReference(), pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, Span<AllocatorT> allocator, BufferCreateInfo* pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, Span<ulong> pBuffer, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(ref allocator.GetPinnableReference(), pBufferCreateInfo, pAllocationCreateInfo, ref pBuffer.GetPinnableReference(), ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, Span<AllocatorT> allocator, BufferCreateInfo* pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, Span<ulong> pBuffer, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(ref allocator.GetPinnableReference(), pBufferCreateInfo, pAllocationCreateInfo, ref pBuffer.GetPinnableReference(), ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, Span<AllocatorT> allocator, BufferCreateInfo* pBufferCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, ulong* pBuffer, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(ref allocator.GetPinnableReference(), pBufferCreateInfo, ref pAllocationCreateInfo.GetPinnableReference(), pBuffer, pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, Span<AllocatorT> allocator, BufferCreateInfo* pBufferCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, ulong* pBuffer, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(ref allocator.GetPinnableReference(), pBufferCreateInfo, ref pAllocationCreateInfo.GetPinnableReference(), pBuffer, pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, Span<AllocatorT> allocator, BufferCreateInfo* pBufferCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, ulong* pBuffer, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(ref allocator.GetPinnableReference(), pBufferCreateInfo, ref pAllocationCreateInfo.GetPinnableReference(), pBuffer, ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, Span<AllocatorT> allocator, BufferCreateInfo* pBufferCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, ulong* pBuffer, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(ref allocator.GetPinnableReference(), pBufferCreateInfo, ref pAllocationCreateInfo.GetPinnableReference(), pBuffer, ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, Span<AllocatorT> allocator, BufferCreateInfo* pBufferCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<ulong> pBuffer, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(ref allocator.GetPinnableReference(), pBufferCreateInfo, ref pAllocationCreateInfo.GetPinnableReference(), ref pBuffer.GetPinnableReference(), pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, Span<AllocatorT> allocator, BufferCreateInfo* pBufferCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<ulong> pBuffer, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(ref allocator.GetPinnableReference(), pBufferCreateInfo, ref pAllocationCreateInfo.GetPinnableReference(), ref pBuffer.GetPinnableReference(), pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, Span<AllocatorT> allocator, BufferCreateInfo* pBufferCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<ulong> pBuffer, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(ref allocator.GetPinnableReference(), pBufferCreateInfo, ref pAllocationCreateInfo.GetPinnableReference(), ref pBuffer.GetPinnableReference(), ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, Span<AllocatorT> allocator, BufferCreateInfo* pBufferCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<ulong> pBuffer, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(ref allocator.GetPinnableReference(), pBufferCreateInfo, ref pAllocationCreateInfo.GetPinnableReference(), ref pBuffer.GetPinnableReference(), ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, Span<AllocatorT> allocator, Span<BufferCreateInfo> pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pBuffer, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(ref allocator.GetPinnableReference(), ref pBufferCreateInfo.GetPinnableReference(), pAllocationCreateInfo, pBuffer, pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, Span<AllocatorT> allocator, Span<BufferCreateInfo> pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pBuffer, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(ref allocator.GetPinnableReference(), ref pBufferCreateInfo.GetPinnableReference(), pAllocationCreateInfo, pBuffer, pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, Span<AllocatorT> allocator, Span<BufferCreateInfo> pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pBuffer, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(ref allocator.GetPinnableReference(), ref pBufferCreateInfo.GetPinnableReference(), pAllocationCreateInfo, pBuffer, ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, Span<AllocatorT> allocator, Span<BufferCreateInfo> pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pBuffer, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(ref allocator.GetPinnableReference(), ref pBufferCreateInfo.GetPinnableReference(), pAllocationCreateInfo, pBuffer, ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, Span<AllocatorT> allocator, Span<BufferCreateInfo> pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, Span<ulong> pBuffer, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(ref allocator.GetPinnableReference(), ref pBufferCreateInfo.GetPinnableReference(), pAllocationCreateInfo, ref pBuffer.GetPinnableReference(), pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, Span<AllocatorT> allocator, Span<BufferCreateInfo> pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, Span<ulong> pBuffer, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(ref allocator.GetPinnableReference(), ref pBufferCreateInfo.GetPinnableReference(), pAllocationCreateInfo, ref pBuffer.GetPinnableReference(), pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, Span<AllocatorT> allocator, Span<BufferCreateInfo> pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, Span<ulong> pBuffer, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(ref allocator.GetPinnableReference(), ref pBufferCreateInfo.GetPinnableReference(), pAllocationCreateInfo, ref pBuffer.GetPinnableReference(), ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, Span<AllocatorT> allocator, Span<BufferCreateInfo> pBufferCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, Span<ulong> pBuffer, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(ref allocator.GetPinnableReference(), ref pBufferCreateInfo.GetPinnableReference(), pAllocationCreateInfo, ref pBuffer.GetPinnableReference(), ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, Span<AllocatorT> allocator, Span<BufferCreateInfo> pBufferCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, ulong* pBuffer, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(ref allocator.GetPinnableReference(), ref pBufferCreateInfo.GetPinnableReference(), ref pAllocationCreateInfo.GetPinnableReference(), pBuffer, pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, Span<AllocatorT> allocator, Span<BufferCreateInfo> pBufferCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, ulong* pBuffer, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(ref allocator.GetPinnableReference(), ref pBufferCreateInfo.GetPinnableReference(), ref pAllocationCreateInfo.GetPinnableReference(), pBuffer, pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, Span<AllocatorT> allocator, Span<BufferCreateInfo> pBufferCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, ulong* pBuffer, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(ref allocator.GetPinnableReference(), ref pBufferCreateInfo.GetPinnableReference(), ref pAllocationCreateInfo.GetPinnableReference(), pBuffer, ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, Span<AllocatorT> allocator, Span<BufferCreateInfo> pBufferCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, ulong* pBuffer, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(ref allocator.GetPinnableReference(), ref pBufferCreateInfo.GetPinnableReference(), ref pAllocationCreateInfo.GetPinnableReference(), pBuffer, ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, Span<AllocatorT> allocator, Span<BufferCreateInfo> pBufferCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<ulong> pBuffer, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(ref allocator.GetPinnableReference(), ref pBufferCreateInfo.GetPinnableReference(), ref pAllocationCreateInfo.GetPinnableReference(), ref pBuffer.GetPinnableReference(), pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, Span<AllocatorT> allocator, Span<BufferCreateInfo> pBufferCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<ulong> pBuffer, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(ref allocator.GetPinnableReference(), ref pBufferCreateInfo.GetPinnableReference(), ref pAllocationCreateInfo.GetPinnableReference(), ref pBuffer.GetPinnableReference(), pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, Span<AllocatorT> allocator, Span<BufferCreateInfo> pBufferCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<ulong> pBuffer, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(ref allocator.GetPinnableReference(), ref pBufferCreateInfo.GetPinnableReference(), ref pAllocationCreateInfo.GetPinnableReference(), ref pBuffer.GetPinnableReference(), ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3919, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateBuffer(this Vma thisApi, Span<AllocatorT> allocator, Span<BufferCreateInfo> pBufferCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<ulong> pBuffer, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateBuffer(ref allocator.GetPinnableReference(), ref pBufferCreateInfo.GetPinnableReference(), ref pAllocationCreateInfo.GetPinnableReference(), ref pBuffer.GetPinnableReference(), ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3938, Column 33 in _mem_alloc.h")]
        public static unsafe void DestroyBuffer(this Vma thisApi, AllocatorT* allocator, ulong buffer, Span<AllocationT> allocation)
        {
            // SpanOverloader
            thisApi.DestroyBuffer(allocator, buffer, ref allocation.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3938, Column 33 in _mem_alloc.h")]
        public static unsafe void DestroyBuffer(this Vma thisApi, Span<AllocatorT> allocator, ulong buffer, AllocationT* allocation)
        {
            // SpanOverloader
            thisApi.DestroyBuffer(ref allocator.GetPinnableReference(), buffer, allocation);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3938, Column 33 in _mem_alloc.h")]
        public static unsafe void DestroyBuffer(this Vma thisApi, Span<AllocatorT> allocator, ulong buffer, Span<AllocationT> allocation)
        {
            // SpanOverloader
            thisApi.DestroyBuffer(ref allocator.GetPinnableReference(), buffer, ref allocation.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, AllocatorT* allocator, ImageCreateInfo* pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pImage, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(allocator, pImageCreateInfo, pAllocationCreateInfo, pImage, pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, AllocatorT* allocator, ImageCreateInfo* pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pImage, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(allocator, pImageCreateInfo, pAllocationCreateInfo, pImage, ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, AllocatorT* allocator, ImageCreateInfo* pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, Span<ulong> pImage, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(allocator, pImageCreateInfo, pAllocationCreateInfo, ref pImage.GetPinnableReference(), pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, AllocatorT* allocator, ImageCreateInfo* pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, Span<ulong> pImage, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(allocator, pImageCreateInfo, pAllocationCreateInfo, ref pImage.GetPinnableReference(), pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, AllocatorT* allocator, ImageCreateInfo* pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, Span<ulong> pImage, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(allocator, pImageCreateInfo, pAllocationCreateInfo, ref pImage.GetPinnableReference(), ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, AllocatorT* allocator, ImageCreateInfo* pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, Span<ulong> pImage, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(allocator, pImageCreateInfo, pAllocationCreateInfo, ref pImage.GetPinnableReference(), ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, AllocatorT* allocator, ImageCreateInfo* pImageCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, ulong* pImage, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(allocator, pImageCreateInfo, ref pAllocationCreateInfo.GetPinnableReference(), pImage, pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, AllocatorT* allocator, ImageCreateInfo* pImageCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, ulong* pImage, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(allocator, pImageCreateInfo, ref pAllocationCreateInfo.GetPinnableReference(), pImage, pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, AllocatorT* allocator, ImageCreateInfo* pImageCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, ulong* pImage, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(allocator, pImageCreateInfo, ref pAllocationCreateInfo.GetPinnableReference(), pImage, ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, AllocatorT* allocator, ImageCreateInfo* pImageCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, ulong* pImage, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(allocator, pImageCreateInfo, ref pAllocationCreateInfo.GetPinnableReference(), pImage, ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, AllocatorT* allocator, ImageCreateInfo* pImageCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<ulong> pImage, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(allocator, pImageCreateInfo, ref pAllocationCreateInfo.GetPinnableReference(), ref pImage.GetPinnableReference(), pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, AllocatorT* allocator, ImageCreateInfo* pImageCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<ulong> pImage, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(allocator, pImageCreateInfo, ref pAllocationCreateInfo.GetPinnableReference(), ref pImage.GetPinnableReference(), pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, AllocatorT* allocator, ImageCreateInfo* pImageCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<ulong> pImage, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(allocator, pImageCreateInfo, ref pAllocationCreateInfo.GetPinnableReference(), ref pImage.GetPinnableReference(), ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, AllocatorT* allocator, ImageCreateInfo* pImageCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<ulong> pImage, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(allocator, pImageCreateInfo, ref pAllocationCreateInfo.GetPinnableReference(), ref pImage.GetPinnableReference(), ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, AllocatorT* allocator, Span<ImageCreateInfo> pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pImage, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(allocator, ref pImageCreateInfo.GetPinnableReference(), pAllocationCreateInfo, pImage, pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, AllocatorT* allocator, Span<ImageCreateInfo> pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pImage, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(allocator, ref pImageCreateInfo.GetPinnableReference(), pAllocationCreateInfo, pImage, pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, AllocatorT* allocator, Span<ImageCreateInfo> pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pImage, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(allocator, ref pImageCreateInfo.GetPinnableReference(), pAllocationCreateInfo, pImage, ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, AllocatorT* allocator, Span<ImageCreateInfo> pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pImage, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(allocator, ref pImageCreateInfo.GetPinnableReference(), pAllocationCreateInfo, pImage, ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, AllocatorT* allocator, Span<ImageCreateInfo> pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, Span<ulong> pImage, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(allocator, ref pImageCreateInfo.GetPinnableReference(), pAllocationCreateInfo, ref pImage.GetPinnableReference(), pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, AllocatorT* allocator, Span<ImageCreateInfo> pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, Span<ulong> pImage, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(allocator, ref pImageCreateInfo.GetPinnableReference(), pAllocationCreateInfo, ref pImage.GetPinnableReference(), pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, AllocatorT* allocator, Span<ImageCreateInfo> pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, Span<ulong> pImage, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(allocator, ref pImageCreateInfo.GetPinnableReference(), pAllocationCreateInfo, ref pImage.GetPinnableReference(), ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, AllocatorT* allocator, Span<ImageCreateInfo> pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, Span<ulong> pImage, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(allocator, ref pImageCreateInfo.GetPinnableReference(), pAllocationCreateInfo, ref pImage.GetPinnableReference(), ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, AllocatorT* allocator, Span<ImageCreateInfo> pImageCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, ulong* pImage, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(allocator, ref pImageCreateInfo.GetPinnableReference(), ref pAllocationCreateInfo.GetPinnableReference(), pImage, pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, AllocatorT* allocator, Span<ImageCreateInfo> pImageCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, ulong* pImage, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(allocator, ref pImageCreateInfo.GetPinnableReference(), ref pAllocationCreateInfo.GetPinnableReference(), pImage, pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, AllocatorT* allocator, Span<ImageCreateInfo> pImageCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, ulong* pImage, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(allocator, ref pImageCreateInfo.GetPinnableReference(), ref pAllocationCreateInfo.GetPinnableReference(), pImage, ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, AllocatorT* allocator, Span<ImageCreateInfo> pImageCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, ulong* pImage, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(allocator, ref pImageCreateInfo.GetPinnableReference(), ref pAllocationCreateInfo.GetPinnableReference(), pImage, ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, AllocatorT* allocator, Span<ImageCreateInfo> pImageCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<ulong> pImage, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(allocator, ref pImageCreateInfo.GetPinnableReference(), ref pAllocationCreateInfo.GetPinnableReference(), ref pImage.GetPinnableReference(), pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, AllocatorT* allocator, Span<ImageCreateInfo> pImageCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<ulong> pImage, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(allocator, ref pImageCreateInfo.GetPinnableReference(), ref pAllocationCreateInfo.GetPinnableReference(), ref pImage.GetPinnableReference(), pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, AllocatorT* allocator, Span<ImageCreateInfo> pImageCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<ulong> pImage, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(allocator, ref pImageCreateInfo.GetPinnableReference(), ref pAllocationCreateInfo.GetPinnableReference(), ref pImage.GetPinnableReference(), ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, AllocatorT* allocator, Span<ImageCreateInfo> pImageCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<ulong> pImage, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(allocator, ref pImageCreateInfo.GetPinnableReference(), ref pAllocationCreateInfo.GetPinnableReference(), ref pImage.GetPinnableReference(), ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, Span<AllocatorT> allocator, ImageCreateInfo* pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pImage, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(ref allocator.GetPinnableReference(), pImageCreateInfo, pAllocationCreateInfo, pImage, pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, Span<AllocatorT> allocator, ImageCreateInfo* pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pImage, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(ref allocator.GetPinnableReference(), pImageCreateInfo, pAllocationCreateInfo, pImage, pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, Span<AllocatorT> allocator, ImageCreateInfo* pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pImage, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(ref allocator.GetPinnableReference(), pImageCreateInfo, pAllocationCreateInfo, pImage, ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, Span<AllocatorT> allocator, ImageCreateInfo* pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pImage, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(ref allocator.GetPinnableReference(), pImageCreateInfo, pAllocationCreateInfo, pImage, ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, Span<AllocatorT> allocator, ImageCreateInfo* pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, Span<ulong> pImage, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(ref allocator.GetPinnableReference(), pImageCreateInfo, pAllocationCreateInfo, ref pImage.GetPinnableReference(), pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, Span<AllocatorT> allocator, ImageCreateInfo* pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, Span<ulong> pImage, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(ref allocator.GetPinnableReference(), pImageCreateInfo, pAllocationCreateInfo, ref pImage.GetPinnableReference(), pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, Span<AllocatorT> allocator, ImageCreateInfo* pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, Span<ulong> pImage, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(ref allocator.GetPinnableReference(), pImageCreateInfo, pAllocationCreateInfo, ref pImage.GetPinnableReference(), ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, Span<AllocatorT> allocator, ImageCreateInfo* pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, Span<ulong> pImage, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(ref allocator.GetPinnableReference(), pImageCreateInfo, pAllocationCreateInfo, ref pImage.GetPinnableReference(), ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, Span<AllocatorT> allocator, ImageCreateInfo* pImageCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, ulong* pImage, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(ref allocator.GetPinnableReference(), pImageCreateInfo, ref pAllocationCreateInfo.GetPinnableReference(), pImage, pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, Span<AllocatorT> allocator, ImageCreateInfo* pImageCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, ulong* pImage, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(ref allocator.GetPinnableReference(), pImageCreateInfo, ref pAllocationCreateInfo.GetPinnableReference(), pImage, pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, Span<AllocatorT> allocator, ImageCreateInfo* pImageCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, ulong* pImage, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(ref allocator.GetPinnableReference(), pImageCreateInfo, ref pAllocationCreateInfo.GetPinnableReference(), pImage, ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, Span<AllocatorT> allocator, ImageCreateInfo* pImageCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, ulong* pImage, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(ref allocator.GetPinnableReference(), pImageCreateInfo, ref pAllocationCreateInfo.GetPinnableReference(), pImage, ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, Span<AllocatorT> allocator, ImageCreateInfo* pImageCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<ulong> pImage, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(ref allocator.GetPinnableReference(), pImageCreateInfo, ref pAllocationCreateInfo.GetPinnableReference(), ref pImage.GetPinnableReference(), pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, Span<AllocatorT> allocator, ImageCreateInfo* pImageCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<ulong> pImage, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(ref allocator.GetPinnableReference(), pImageCreateInfo, ref pAllocationCreateInfo.GetPinnableReference(), ref pImage.GetPinnableReference(), pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, Span<AllocatorT> allocator, ImageCreateInfo* pImageCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<ulong> pImage, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(ref allocator.GetPinnableReference(), pImageCreateInfo, ref pAllocationCreateInfo.GetPinnableReference(), ref pImage.GetPinnableReference(), ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, Span<AllocatorT> allocator, ImageCreateInfo* pImageCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<ulong> pImage, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(ref allocator.GetPinnableReference(), pImageCreateInfo, ref pAllocationCreateInfo.GetPinnableReference(), ref pImage.GetPinnableReference(), ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, Span<AllocatorT> allocator, Span<ImageCreateInfo> pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pImage, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(ref allocator.GetPinnableReference(), ref pImageCreateInfo.GetPinnableReference(), pAllocationCreateInfo, pImage, pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, Span<AllocatorT> allocator, Span<ImageCreateInfo> pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pImage, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(ref allocator.GetPinnableReference(), ref pImageCreateInfo.GetPinnableReference(), pAllocationCreateInfo, pImage, pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, Span<AllocatorT> allocator, Span<ImageCreateInfo> pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pImage, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(ref allocator.GetPinnableReference(), ref pImageCreateInfo.GetPinnableReference(), pAllocationCreateInfo, pImage, ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, Span<AllocatorT> allocator, Span<ImageCreateInfo> pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, ulong* pImage, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(ref allocator.GetPinnableReference(), ref pImageCreateInfo.GetPinnableReference(), pAllocationCreateInfo, pImage, ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, Span<AllocatorT> allocator, Span<ImageCreateInfo> pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, Span<ulong> pImage, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(ref allocator.GetPinnableReference(), ref pImageCreateInfo.GetPinnableReference(), pAllocationCreateInfo, ref pImage.GetPinnableReference(), pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, Span<AllocatorT> allocator, Span<ImageCreateInfo> pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, Span<ulong> pImage, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(ref allocator.GetPinnableReference(), ref pImageCreateInfo.GetPinnableReference(), pAllocationCreateInfo, ref pImage.GetPinnableReference(), pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, Span<AllocatorT> allocator, Span<ImageCreateInfo> pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, Span<ulong> pImage, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(ref allocator.GetPinnableReference(), ref pImageCreateInfo.GetPinnableReference(), pAllocationCreateInfo, ref pImage.GetPinnableReference(), ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, Span<AllocatorT> allocator, Span<ImageCreateInfo> pImageCreateInfo, AllocationCreateInfo* pAllocationCreateInfo, Span<ulong> pImage, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(ref allocator.GetPinnableReference(), ref pImageCreateInfo.GetPinnableReference(), pAllocationCreateInfo, ref pImage.GetPinnableReference(), ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, Span<AllocatorT> allocator, Span<ImageCreateInfo> pImageCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, ulong* pImage, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(ref allocator.GetPinnableReference(), ref pImageCreateInfo.GetPinnableReference(), ref pAllocationCreateInfo.GetPinnableReference(), pImage, pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, Span<AllocatorT> allocator, Span<ImageCreateInfo> pImageCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, ulong* pImage, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(ref allocator.GetPinnableReference(), ref pImageCreateInfo.GetPinnableReference(), ref pAllocationCreateInfo.GetPinnableReference(), pImage, pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, Span<AllocatorT> allocator, Span<ImageCreateInfo> pImageCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, ulong* pImage, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(ref allocator.GetPinnableReference(), ref pImageCreateInfo.GetPinnableReference(), ref pAllocationCreateInfo.GetPinnableReference(), pImage, ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, Span<AllocatorT> allocator, Span<ImageCreateInfo> pImageCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, ulong* pImage, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(ref allocator.GetPinnableReference(), ref pImageCreateInfo.GetPinnableReference(), ref pAllocationCreateInfo.GetPinnableReference(), pImage, ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, Span<AllocatorT> allocator, Span<ImageCreateInfo> pImageCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<ulong> pImage, AllocationT** pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(ref allocator.GetPinnableReference(), ref pImageCreateInfo.GetPinnableReference(), ref pAllocationCreateInfo.GetPinnableReference(), ref pImage.GetPinnableReference(), pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, Span<AllocatorT> allocator, Span<ImageCreateInfo> pImageCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<ulong> pImage, AllocationT** pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(ref allocator.GetPinnableReference(), ref pImageCreateInfo.GetPinnableReference(), ref pAllocationCreateInfo.GetPinnableReference(), ref pImage.GetPinnableReference(), pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, Span<AllocatorT> allocator, Span<ImageCreateInfo> pImageCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<ulong> pImage, ref AllocationT* pAllocation, AllocationInfo* pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(ref allocator.GetPinnableReference(), ref pImageCreateInfo.GetPinnableReference(), ref pAllocationCreateInfo.GetPinnableReference(), ref pImage.GetPinnableReference(), ref pAllocation, pAllocationInfo);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3944, Column 37 in _mem_alloc.h")]
        public static unsafe Result CreateImage(this Vma thisApi, Span<AllocatorT> allocator, Span<ImageCreateInfo> pImageCreateInfo, Span<AllocationCreateInfo> pAllocationCreateInfo, Span<ulong> pImage, ref AllocationT* pAllocation, Span<AllocationInfo> pAllocationInfo)
        {
            // SpanOverloader
            return thisApi.CreateImage(ref allocator.GetPinnableReference(), ref pImageCreateInfo.GetPinnableReference(), ref pAllocationCreateInfo.GetPinnableReference(), ref pImage.GetPinnableReference(), ref pAllocation, ref pAllocationInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3963, Column 33 in _mem_alloc.h")]
        public static unsafe void DestroyImage(this Vma thisApi, AllocatorT* allocator, ulong image, Span<AllocationT> allocation)
        {
            // SpanOverloader
            thisApi.DestroyImage(allocator, image, ref allocation.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3963, Column 33 in _mem_alloc.h")]
        public static unsafe void DestroyImage(this Vma thisApi, Span<AllocatorT> allocator, ulong image, AllocationT* allocation)
        {
            // SpanOverloader
            thisApi.DestroyImage(ref allocator.GetPinnableReference(), image, allocation);
        }

        /// <summary>To be documented.</summary>
        [NativeName("Src", "Line 3963, Column 33 in _mem_alloc.h")]
        public static unsafe void DestroyImage(this Vma thisApi, Span<AllocatorT> allocator, ulong image, Span<AllocationT> allocation)
        {
            // SpanOverloader
            thisApi.DestroyImage(ref allocator.GetPinnableReference(), image, ref allocation.GetPinnableReference());
        }

    }
}

