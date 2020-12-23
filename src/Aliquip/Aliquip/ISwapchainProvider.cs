// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using Silk.NET.Vulkan;

namespace Aliquip
{
    public interface ISwapchainProvider
    {
        SwapchainKHR Swapchain { get; }
        Image[] SwapchainImages { get; }
        Format SwapchainFormat { get; }
        Extent2D SwapchainExtent { get; }
    }
}
