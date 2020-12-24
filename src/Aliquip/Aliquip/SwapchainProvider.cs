// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using Microsoft.Extensions.Logging;
using Silk.NET.Maths;
using Silk.NET.Vulkan;
using Silk.NET.Vulkan.Extensions.KHR;
using Silk.NET.Windowing;

namespace Aliquip
{
    internal sealed class SwapchainProvider : ISwapchainProvider, IDisposable
    {
        private readonly KhrSwapchain _khrSwapchain;
        private readonly Device _device;
        private readonly SurfaceKHR _surface;
        private readonly IWindow _window;
        private readonly SurfaceFormatKHR _surfaceFormat;
        private readonly PresentModeKHR _presentMode;
        private readonly uint _imageCount;
        private readonly PhysicalDevice _physicalDevice;
        private readonly ILogger _logger;
        private readonly ISwapchainSupportProvider _swapchainSupportProvider;
        private readonly IQueueFamilyProvider _queueFamilyProvider;
        public SwapchainKHR Swapchain { get; private set; }
        public Image[] SwapchainImages { get; private set; }
        public Format SwapchainFormat { get; private set; }
        public Extent2D SwapchainExtent { get; private set; }

        public unsafe SwapchainProvider(ILogger<SwapchainProvider> logger, IFormatRater formatRater, IColorspaceRater colorspaceRater, IWindowProvider windowProvider, ISwapchainSupportProvider swapchainSupportProvider, IPhysicalDeviceProvider physicalDeviceProvider
        , IQueueFamilyProvider queueFamilyProvider, ISurfaceProvider surfaceProvider, KhrSwapchain khrSwapchain, ILogicalDeviceProvider deviceProvider)
        {
            _device = deviceProvider.LogicalDevice;
            _khrSwapchain = khrSwapchain;
            _physicalDevice = physicalDeviceProvider.Device;
            _surface = surfaceProvider.Surface;
            _window = windowProvider.Window;
            _logger = logger;
            _swapchainSupportProvider = swapchainSupportProvider;
            _queueFamilyProvider = queueFamilyProvider;
            
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

            var supportDetails = swapchainSupportProvider.QuerySwapchainSupport(_physicalDevice);

            _surfaceFormat = ChooseSwapSurfaceFormat(supportDetails.Formats);
            _presentMode = ChooseSwapPresentMode(supportDetails.PresentModes);
            
            _imageCount = 3;
            
            var hasMaxImage = supportDetails.Capabilities.MaxImageCount > 0;
            if (hasMaxImage && _imageCount > supportDetails.Capabilities.MaxImageCount)
                _imageCount = supportDetails.Capabilities.MaxImageCount;

            if (_imageCount < supportDetails.Capabilities.MinImageCount)
                _imageCount = supportDetails.Capabilities.MinImageCount;
            
            logger.LogDebug("Best possible format: {format}, rating: {rating}", formatRater.BestPossibleFormat.Item1, formatRater.BestPossibleFormat.Item2);
            var formatRating = formatRater.Rate(_surfaceFormat.Format);
            logger.LogDebug("Selected format: {format}, rating: {rating} ({percent}%)", _surfaceFormat.Format, formatRating, MathF.Round((float)formatRating / (float)formatRater.BestPossibleFormat.Item2 * 100f, 2));
            logger.LogDebug("Best possible colorspace: {colorspace}, rating: {rating}", colorspaceRater.BestPossibleColorspace.Item1, colorspaceRater.BestPossibleColorspace.Item2);
            var colorspaceRating = colorspaceRater.Rate(_surfaceFormat.ColorSpace);
            logger.LogDebug("Selected colorspace: {colorspace}, rating: {rating}, ({percent}%)", _surfaceFormat.ColorSpace, colorspaceRating, MathF.Round((float)colorspaceRating / (float)colorspaceRater.BestPossibleColorspace.Item2 * 100f, 2));
            logger.LogDebug("Selected present mode: {presentMode}", _presentMode);
            logger.LogDebug("Image count: {imageCount}", _imageCount);

            RecreateSwapchain();
        }
        
        public unsafe void RecreateSwapchain()
        {            
            Extent2D ChooseSwapExtend(SurfaceCapabilitiesKHR capabilities)
            {
                if (capabilities.CurrentExtent.Width != uint.MaxValue)
                {
                    return capabilities.CurrentExtent;
                }

                var windowSize = (Vector2D<uint>) _window.FramebufferSize;
                var minImage = new Vector2D<uint>
                    (capabilities.MinImageExtent.Width, capabilities.MinImageExtent.Height);
                var maxImage = new Vector2D<uint>
                    (capabilities.MaxImageExtent.Width, capabilities.MaxImageExtent.Height);

                var actual = Vector2D.Max(minImage, Vector2D.Max(maxImage, windowSize));
                return new Extent2D(actual.X, actual.Y);
            }
            var supportDetails = _swapchainSupportProvider.QuerySwapchainSupport(_physicalDevice);
            var extent = ChooseSwapExtend(supportDetails.Capabilities);

            _logger.LogDebug("Creating swapchain");

            var indices = _queueFamilyProvider.FindQueueFamilyIndices(_physicalDevice);
            var indicesSame = indices.GraphicsFamily == indices.PresentFamily;

            var queueFamilyIndices = stackalloc uint[] {indices.GraphicsFamily!.Value, indices.PresentFamily!.Value};
            SwapchainCreateInfoKHR createInfo = new SwapchainCreateInfoKHR
            (
                surface: _surface,
                minImageCount: _imageCount,
                imageFormat: _surfaceFormat.Format,
                imageColorSpace: _surfaceFormat.ColorSpace,
                imageExtent: extent,
                imageArrayLayers: 1,
                imageUsage: ImageUsageFlags.ImageUsageColorAttachmentBit,
                imageSharingMode: indicesSame ? SharingMode.Exclusive : SharingMode.Concurrent,
                queueFamilyIndexCount: indicesSame ? default : 2,
                pQueueFamilyIndices: indicesSame ? default : queueFamilyIndices,
                preTransform: supportDetails.Capabilities.CurrentTransform,
                compositeAlpha: CompositeAlphaFlagsKHR.CompositeAlphaOpaqueBitKhr,
                presentMode: _presentMode,
                clipped: Vk.True
            );

            _khrSwapchain.CreateSwapchain(_device, &createInfo, null, out var swapchain).ThrowCode();

            var imageCount = _imageCount;
            _khrSwapchain.GetSwapchainImages(_device, swapchain, ref imageCount, null);
            var images = new Image[imageCount];
            fixed (Image* pImages =
                images) _khrSwapchain.GetSwapchainImages(_device, swapchain, ref imageCount, pImages);

            Swapchain = swapchain;
            SwapchainImages = images;
            SwapchainFormat = _surfaceFormat.Format;
            SwapchainExtent = extent;
        }

        public unsafe void Dispose()
        {
            _khrSwapchain.DestroySwapchain(_device, Swapchain, null);
        }
    }
}
