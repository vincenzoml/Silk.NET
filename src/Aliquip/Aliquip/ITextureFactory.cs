// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using Silk.NET.Vulkan;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using Image = Silk.NET.Vulkan.Image;

namespace Aliquip
{
    public interface ITextureFactory
    {
        Texture this[string name] { get; }
        Texture CreateImage(Image<Rgba32> src, bool createSampler, bool useMipmaps, ImageAspectFlags aspectFlags, ImageUsageFlags imageUsageFlags);
        Texture CreateImage(uint width, uint height, Format format, bool createSampler, bool useMipmaps, ImageAspectFlags aspectFlags, ImageUsageFlags imageUsageFlags);
    }
}
