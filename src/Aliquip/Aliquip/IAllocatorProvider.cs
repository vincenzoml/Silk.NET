// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using Silk.NET.Vulkan.VMA;

namespace Aliquip
{
    public interface IAllocatorProvider
    {
        unsafe AllocatorT Allocator { get; }
    }
}
