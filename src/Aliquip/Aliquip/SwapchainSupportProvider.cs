// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using Silk.NET.Vulkan;
using Silk.NET.Vulkan.Extensions.KHR;

namespace Aliquip
{
    internal sealed class SwapchainSupportProvider : ISwapchainSupportProvider
    {
        private readonly KhrSurface _khrSurface;
        private readonly SurfaceKHR _surface;

        public SwapchainSupportProvider(KhrSurface khrSurface, ISurfaceProvider surfaceProvider)
        {
            _khrSurface = khrSurface;
            _surface = surfaceProvider.Surface;
        }

        public unsafe SwapchainSupportDetails QuerySwapchainSupport(PhysicalDevice device)
        {
            SwapchainSupportDetails details = default;

            _khrSurface.GetPhysicalDeviceSurfaceCapabilities(device, _surface, out details.Capabilities).ThrowCode();

            uint count = 0;
            _khrSurface.GetPhysicalDeviceSurfaceFormats(device, _surface, ref count, null).ThrowCode();
            var formats = new SurfaceFormatKHR[(int) count];
            fixed (SurfaceFormatKHR* pformats = formats)
                _khrSurface.GetPhysicalDeviceSurfaceFormats(device, _surface, ref count, pformats).ThrowCode();
            details.Formats = formats;

            count = 0;
            _khrSurface.GetPhysicalDeviceSurfacePresentModes(device, _surface, ref count, null).ThrowCode();
            var modes = new PresentModeKHR[(int) count];
            fixed (PresentModeKHR* pmodes = modes)
                _khrSurface.GetPhysicalDeviceSurfacePresentModes(device, _surface, ref count, pmodes).ThrowCode();
            details.PresentModes = modes;

            return details;
        }
    }
}
