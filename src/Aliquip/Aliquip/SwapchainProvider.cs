// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using Microsoft.Extensions.Logging;
using Silk.NET.Maths;
using Silk.NET.Vulkan;
using Silk.NET.Vulkan.Extensions.KHR;

namespace Aliquip
{
    internal sealed class SwapchainProvider : ISwapchainProvider, IDisposable
    {
        private readonly KhrSwapchain _khrSwapchain;
        private readonly Device _device;
        public SwapchainKHR Swapchain { get; }
        public Image[] SwapchainImages { get; }
        public Format SwapchainFormat { get; }
        public Extent2D SwapchainExtent { get; }

        public unsafe SwapchainProvider(ILogger<SwapchainProvider> logger, IFormatRater formatRater, IColorspaceRater colorspaceRater, IWindowProvider windowProvider, ISwapchainSupportProvider swapchainSupportProvider, IPhysicalDeviceProvider physicalDeviceProvider
        , IQueueFamilyProvider queueFamilyProvider, ISurfaceProvider surfaceProvider, KhrSwapchain khrSwapchain, ILogicalDeviceProvider deviceProvider)
        {
            _device = deviceProvider.LogicalDevice;
            _khrSwapchain = khrSwapchain;
            var physicalDevice = physicalDeviceProvider.Device;
            var surface = surfaceProvider.Surface;
            
            SurfaceFormatKHR ChooseSwapSurfaceFormat(SurfaceFormatKHR[] availableFormats)
            {
                int maximum = 0;
                SurfaceFormatKHR best = availableFormats[0];
                foreach (var availableFormat in availableFormats)
                {
                    int score = 0;

                    if (availableFormat.Format == Format.B8G8R8Srgb) score += 100;
                    score += formatRater.Rate(availableFormat.Format);

                    if (availableFormat.ColorSpace == ColorSpaceKHR.ColorSpaceSrgbNonlinearKhr) score += 100;
                    score += colorspaceRater.Rate(availableFormat.ColorSpace);

                    if (score > maximum)
                    {
                        best = availableFormat;
                        maximum = score;
                    }
                }

                if (maximum == 0)
                    logger.LogCritical("No suitable surface format found");

                return best;
            }

            PresentModeKHR ChooseSwapPresentMode(PresentModeKHR[] availablePresentModes)
            {
                int maximum = 0;
                PresentModeKHR best = PresentModeKHR.PresentModeFifoKhr;
                foreach (var availablePresentMode in availablePresentModes)
                {
                    if (availablePresentMode == PresentModeKHR.PresentModeMailboxKhr)
                    {
                        return PresentModeKHR.PresentModeMailboxKhr;
                    }

                    if (availablePresentMode == PresentModeKHR.PresentModeFifoRelaxedKhr)
                    {
                        best = PresentModeKHR.PresentModeFifoRelaxedKhr;
                        maximum = 10;
                    }

                    // we don't want VK_PRESENT_MODE_IMMEDIATE_KHR
                    // and VK_PRESENT_MODE_FIFO_KHR is guaranteed and our default fallback
                    // therefore we are not rating those.
                }
                
                if (maximum == 0)
                    logger.LogCritical("No suitable surface format found");

                return best;
            }

            Extent2D ChooseSwapExtend(SurfaceCapabilitiesKHR capabilities)
            {
                if (capabilities.CurrentExtent.Width != uint.MaxValue)
                {
                    return capabilities.CurrentExtent;
                }

                var windowSize = (Vector2D<uint>) windowProvider.Window.FramebufferSize;
                var minImage = new Vector2D<uint>
                    (capabilities.MinImageExtent.Width, capabilities.MinImageExtent.Height);
                var maxImage = new Vector2D<uint>
                    (capabilities.MaxImageExtent.Width, capabilities.MaxImageExtent.Height);

                var actual = Vector2D.Max(minImage, Vector2D.Max(maxImage, windowSize));
                return new Extent2D(actual.X, actual.Y);
            }

            var supportDetails = swapchainSupportProvider.QuerySwapchainSupport(physicalDevice);

            var surfaceFormat = ChooseSwapSurfaceFormat(supportDetails.Formats);
            var presentMode = ChooseSwapPresentMode(supportDetails.PresentModes);
            var extent = ChooseSwapExtend(supportDetails.Capabilities);

            uint imageCount = 3;
            
            var hasMaxImage = supportDetails.Capabilities.MaxImageCount > 0;
            if (hasMaxImage && imageCount > supportDetails.Capabilities.MaxImageCount)
                imageCount = supportDetails.Capabilities.MaxImageCount;

            if (imageCount < supportDetails.Capabilities.MinImageCount)
                imageCount = supportDetails.Capabilities.MinImageCount;
            
            logger.LogDebug("Creating swapchain");
            logger.LogDebug("Best possible format: {format}, rating: {rating}", formatRater.BestPossibleFormat.Item1, formatRater.BestPossibleFormat.Item2);
            var formatRating = formatRater.Rate(surfaceFormat.Format);
            logger.LogDebug("Selected format: {format}, rating: {rating} ({percent}%)", surfaceFormat.Format, formatRating, MathF.Round((float)formatRating / (float)formatRater.BestPossibleFormat.Item2 * 100f, 2));
            logger.LogDebug("Best possible colorspace: {colorspace}, rating: {rating}", colorspaceRater.BestPossibleColorspace.Item1, colorspaceRater.BestPossibleColorspace.Item2);
            var colorspaceRating = colorspaceRater.Rate(surfaceFormat.ColorSpace);
            logger.LogDebug("Selected colorspace: {colorspace}, rating: {rating}, ({percent}%)", surfaceFormat.ColorSpace, colorspaceRating, MathF.Round((float)colorspaceRating / (float)colorspaceRater.BestPossibleColorspace.Item2 * 100f, 2));
            logger.LogDebug("Selected present mode: {presentMode}", presentMode);
            logger.LogDebug("Image count: {imageCount}", imageCount);

            var indices = queueFamilyProvider.FindQueueFamilyIndices(physicalDevice);
            var indicesSame = indices.GraphicsFamily == indices.PresentFamily;

            var queueFamilyIndices = stackalloc uint[] {indices.GraphicsFamily!.Value, indices.PresentFamily!.Value};
            SwapchainCreateInfoKHR createInfo = new SwapchainCreateInfoKHR
            (
                surface: surface,
                minImageCount: imageCount,
                imageFormat: surfaceFormat.Format,
                imageColorSpace: surfaceFormat.ColorSpace,
                imageExtent: extent,
                imageArrayLayers: 1,
                imageUsage: ImageUsageFlags.ImageUsageColorAttachmentBit,
                imageSharingMode: indicesSame ? SharingMode.Exclusive : SharingMode.Concurrent,
                queueFamilyIndexCount: indicesSame ? default : 2,
                pQueueFamilyIndices: indicesSame ? default : queueFamilyIndices,
                preTransform: supportDetails.Capabilities.CurrentTransform,
                compositeAlpha: CompositeAlphaFlagsKHR.CompositeAlphaOpaqueBitKhr,
                presentMode: presentMode,
                clipped: Vk.True
            );

            _khrSwapchain.CreateSwapchain(_device, &createInfo, null, out var swapchain).ThrowCode();

            _khrSwapchain.GetSwapchainImages(_device, swapchain, ref imageCount, null);
            var images = new Image[imageCount];
            fixed (Image* pImages =
                images) _khrSwapchain.GetSwapchainImages(_device, swapchain, ref imageCount, pImages);

            Swapchain = swapchain;
            SwapchainImages = images;
            SwapchainFormat = surfaceFormat.Format;
            SwapchainExtent = extent;
        }

        public unsafe void Dispose()
        {
            _khrSwapchain.DestroySwapchain(_device, Swapchain, null);
        }
    }
}
