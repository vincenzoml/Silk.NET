// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using Silk.NET.Vulkan;

namespace Aliquip
{
    internal sealed class ColorImageProvider : IColorImageProvider
    {
        private readonly ITextureFactory _textureFactory;
        private readonly IPhysicalDeviceProvider _physicalDeviceProvider;
        private readonly IMsaaProvider _msaaProvider;
        private readonly ISwapchainProvider _swapchainProvider;
        public Texture? ColorImage { get; private set; }

        public ColorImageProvider(ITextureFactory textureFactory, IPhysicalDeviceProvider physicalDeviceProvider, IMsaaProvider msaaProvider, ISwapchainProvider swapchainProvider)
        {
            _textureFactory = textureFactory;
            _physicalDeviceProvider = physicalDeviceProvider;
            _msaaProvider = msaaProvider;
            _swapchainProvider = swapchainProvider;

            Recreate();
        }
        
        public void Recreate()
        {
            if (_msaaProvider.MsaaSamples(_physicalDeviceProvider.Device) == SampleCountFlags.SampleCount1Bit)
                return;
                
            ColorImage = _textureFactory.CreateImage
            (
                _swapchainProvider.SwapchainExtent.Width, _swapchainProvider.SwapchainExtent.Height,
                _swapchainProvider.SwapchainFormat, false, false,
                _msaaProvider.MsaaSamples(_physicalDeviceProvider.Device), ImageAspectFlags.ImageAspectColorBit,
                ImageUsageFlags.ImageUsageTransientAttachmentBit | ImageUsageFlags.ImageUsageColorAttachmentBit
            );
        }
        
        public void Dispose()
        {
            ColorImage?.Dispose();
            ColorImage = null;
        }
    }
}
