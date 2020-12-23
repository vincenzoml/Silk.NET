// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using Silk.NET.Vulkan;

namespace Aliquip
{
    public interface ISurfaceProvider
    {
        SurfaceKHR Surface { get; }
    }
}
