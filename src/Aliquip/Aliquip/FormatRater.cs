// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using Silk.NET.Vulkan;

namespace Aliquip
{
    internal sealed class FormatRater : IFormatRater
    {
        public int Rate(Format format)
        {
            int R(int value) => value switch { < 8 => 100, > 16 => 100, _ => 200 } * 2 + value;
            int G(int value) => value switch { < 8 => 100, > 16 => 100, _ => 200 } * 2 + value;
            int B(int value) => value switch { < 8 => 100, > 16 => 100, _ => 200 } * 2 + value;
            int A(int value) => value switch { < 8 => 100, > 16 => 100, _ => 200 } * 1 + value;
            int Depth(int value) => 0;
            int Stencil(int value) => 0;
            int Srgb = 100;
            switch (format)
            {
                // case Format.R4G4UnormPack8:
                //     return R(4) + G(4);
                case Format.R4G4B4A4UnormPack16:
                    return R(4) + G(4) + B(4) + A(4);
                case Format.B4G4R4A4UnormPack16:
                    return B(4) + G(4) + R(4) + A(4);
                // case Format.R5G6B5UnormPack16:
                //     return R(5) + G(6) + B(5);
                // case Format.B5G6R5UnormPack16:
                //     return B(5) + G(6) + R(5);
                case Format.R5G5B5A1UnormPack16:
                    return R(5)  + G(5) + B(5) + A(1);
                case Format.B5G5R5A1UnormPack16:
                    return B(5) + G(5) + R(5) + A(1);
                // case Format.A1R5G5B5UnormPack16:
                //     return A(1) + R(5) + G(5) + B(5);
                //case Format.R8Unorm:
                //    return R(8);
                // case Format.R8SNorm:
                //     return R(8);
                // case Format.R8Uscaled:
                //     return R(8);
                // case Format.R8Sscaled:
                //     return R(8);
                // case Format.R8Uint:
                //     return R(8);
                // case Format.R8Sint:
                //     return R(8);
                // case Format.R8Srgb:
                //     return R(8) + Srgb;
                // case Format.R8G8Unorm:
                //     return R(8) + G(8);
                /*case Format.R8G8SNorm:
                    return R(8) + G(8);
                case Format.R8G8Uscaled:
                    return R(8) + G(8);
                case Format.R8G8Sscaled:
                    return R(8) + G(8);
                case Format.R8G8Uint:
                    return R(8) + G(8);
                case Format.R8G8Sint:
                    return R(8) + G(8);
                case Format.R8G8Srgb:
                    return R(8) + G(8) + Srgb;
                case Format.R8G8B8Unorm:
                    return R(8) + G(8) + B(8);
                case Format.R8G8B8SNorm:
                    return R(8) + G(8) + B(8);
                case Format.R8G8B8Uscaled:
                    return R(8) + G(8) + B(8);
                case Format.R8G8B8Sscaled:
                    return R(8) + G(8) + B(8);
                case Format.R8G8B8Uint:
                    return R(8) + G(8) + B(8);
                case Format.R8G8B8Sint:
                    return R(8) + G(8) + B(8);
                case Format.R8G8B8Srgb:
                    return R(8) + G(8) + B(8) + Srgb;
                case Format.B8G8R8Unorm:
                    return R(8) + G(8) + B(8);
                case Format.B8G8R8SNorm:
                    return R(8) + G(8) + B(8);
                case Format.B8G8R8Uscaled:
                    return R(8) + G(8) + B(8);
                case Format.B8G8R8Sscaled:
                    return R(8) + G(8) + B(8);
                case Format.B8G8R8Uint:
                    return R(8) + G(8) + B(8);
                case Format.B8G8R8Sint:
                    return R(8) + G(8) + B(8);
                case Format.B8G8R8Srgb:
                    return R(8) + G(8) + B(8) + Srgb;*/
                case Format.R8G8B8A8Unorm:
                    return R(8) + G(8) + B(8) + A(8) + 100;
                case Format.R8G8B8A8SNorm:
                    return R(8) + G(8) + B(8) + A(8);
                case Format.R8G8B8A8Uscaled:
                    return R(8) + G(8) + B(8) + A(8);
                case Format.R8G8B8A8Sscaled:
                    return R(8) + G(8) + B(8) + A(8);
                case Format.R8G8B8A8Uint:
                    return R(8) + G(8) + B(8) + A(8);
                case Format.R8G8B8A8Sint:
                    return R(8) + G(8) + B(8) + A(8);
                case Format.R8G8B8A8Srgb:
                    return R(8) + G(8) + B(8) + A(8) + Srgb;
                case Format.B8G8R8A8Unorm:
                    return R(8) + G(8) + B(8) + A(8) + 100;
                case Format.B8G8R8A8SNorm:
                    return R(8) + G(8) + B(8) + A(8);
                case Format.B8G8R8A8Uscaled:
                    return R(8) + G(8) + B(8) + A(8);
                case Format.B8G8R8A8Sscaled:
                    return R(8) + G(8) + B(8) + A(8);
                case Format.B8G8R8A8Uint:
                    return R(8) + G(8) + B(8) + A(8);
                case Format.B8G8R8A8Sint:
                    return R(8) + G(8) + B(8) + A(8);
                case Format.B8G8R8A8Srgb:
                    return R(8) + G(8) + B(8) + A(8) + Srgb;
                case Format.A8B8G8R8UnormPack32:
                    return R(8) + G(8) + B(8) + A(8);
                case Format.A8B8G8R8SNormPack32:
                    return R(8) + G(8) + B(8) + A(8);
                case Format.A8B8G8R8UscaledPack32:
                    return R(8) + G(8) + B(8) + A(8);
                case Format.A8B8G8R8SscaledPack32:
                    return R(8) + G(8) + B(8) + A(8);
                case Format.A8B8G8R8UintPack32:
                    return R(8) + G(8) + B(8) + A(8);
                case Format.A8B8G8R8SintPack32:
                    return R(8) + G(8) + B(8) + A(8);
                case Format.A8B8G8R8SrgbPack32:
                    return R(8) + G(8) + B(8) + A(8) + Srgb;
                case Format.A2R10G10B10UnormPack32:
                    return R(10) + G(10) + B(10) + A(2);
                case Format.A2R10G10B10SNormPack32:
                    return R(10) + G(10) + B(10) + A(2);
                case Format.A2R10G10B10UscaledPack32:
                    return R(10) + G(10) + B(10) + A(2);
                case Format.A2R10G10B10SscaledPack32:
                    return R(10) + G(10) + B(10) + A(2);
                case Format.A2R10G10B10UintPack32:
                    return R(10) + G(10) + B(10) + A(2);
                case Format.A2R10G10B10SintPack32:
                    return R(10) + G(10) + B(10) + A(2);
                case Format.A2B10G10R10UnormPack32:
                    return R(10) + G(10) + B(10) + A(2);
                case Format.A2B10G10R10SNormPack32:
                    return R(10) + G(10) + B(10) + A(2);
                case Format.A2B10G10R10UscaledPack32:
                    return R(10) + G(10) + B(10) + A(2);
                case Format.A2B10G10R10SscaledPack32:
                    return R(10) + G(10) + B(10) + A(2);
                case Format.A2B10G10R10UintPack32:
                    return R(10) + G(10) + B(10) + A(2);
                case Format.A2B10G10R10SintPack32:
                    return R(10) + G(10) + B(10) + A(2);
                /*case Format.R16Unorm:
                    return 100;
                case Format.R16SNorm:
                    return 100;
                case Format.R16Uscaled:
                    return 100;
                case Format.R16Sscaled:
                    return 100;
                case Format.R16Uint:
                    return 100;
                case Format.R16Sint:
                    return 100;
                case Format.R16Sfloat:
                    return 100;
                case Format.R16G16Unorm:
                    return R(16) + G(16) + B(0) + A(0);
                case Format.R16G16SNorm:
                    return R(16) + G(16) + B(0) + A(0);
                case Format.R16G16Uscaled:
                    return R(16) + G(16) + B(0) + A(0);
                case Format.R16G16Sscaled:
                    return R(16) + G(16) + B(0) + A(0);
                case Format.R16G16Uint:
                    return R(16) + G(16) + B(0) + A(0);
                case Format.R16G16Sint:
                    return R(16) + G(16) + B(0) + A(0);
                case Format.R16G16Sfloat:
                    return R(16) + G(16) + B(0) + A(0);
                case Format.R16G16B16Unorm:
                    return R(16) + G(16) + B(16) + A(0);
                case Format.R16G16B16SNorm:
                    return R(16) + G(16) + B(16) + A(0);
                case Format.R16G16B16Uscaled:
                    return R(16) + G(16) + B(16) + A(0);
                case Format.R16G16B16Sscaled:
                    return R(16) + G(16) + B(16) + A(0);
                case Format.R16G16B16Uint:
                    return R(16) + G(16) + B(16) + A(0);
                case Format.R16G16B16Sint:
                    return R(16) + G(16) + B(16) + A(0);
                case Format.R16G16B16Sfloat:
                    return R(16) + G(16) + B(16) + A(0);*/
                case Format.R16G16B16A16Unorm:
                    return R(16) + G(16) + B(16) + A(16);
                case Format.R16G16B16A16SNorm:
                    return R(16) + G(16) + B(16) + A(16);
                case Format.R16G16B16A16Uscaled:
                    return R(16) + G(16) + B(16) + A(16);
                case Format.R16G16B16A16Sscaled:
                    return R(16) + G(16) + B(16) + A(16);
                case Format.R16G16B16A16Uint:
                    return R(16) + G(16) + B(16) + A(16);
                case Format.R16G16B16A16Sint:
                    return R(16) + G(16) + B(16) + A(16);
                case Format.R16G16B16A16Sfloat:
                    return R(16) + G(16) + B(16) + A(16);
                /*case Format.R32Uint:
                    return R(32);
                case Format.R32Sint:
                    return R(32);
                case Format.R32Sfloat:
                    return R(32);
                case Format.R32G32Uint:
                    return R(32) + G(32);
                case Format.R32G32Sint:
                    return R(32) + G(32);
                case Format.R32G32Sfloat:
                    return R(32) + G(32);
                case Format.R32G32B32Uint:
                    return R(32) + G(32) + B(32);
                case Format.R32G32B32Sint:
                    return R(32) + G(32) + B(32);
                case Format.R32G32B32Sfloat:
                    return R(32) + G(32) + B(32);*/
                case Format.R32G32B32A32Uint:
                    return R(32) + G(32) + B(32) + A(32);
                case Format.R32G32B32A32Sint:
                    return R(32) + G(32) + B(32) + A(32);
                case Format.R32G32B32A32Sfloat:
                    return R(32) + G(32) + B(32) + A(32);
                /*case Format.R64Uint:
                    return R(64);
                case Format.R64Sint:
                    return R(64);
                case Format.R64Sfloat:
                    return R(64);
                case Format.R64G64Uint:
                    return R(64) + G(64);
                case Format.R64G64Sint:
                    return R(64) + G(64);
                case Format.R64G64Sfloat:
                    return R(64) + G(64);
                case Format.R64G64B64Uint:
                    return R(64) + G(64) + B(64);
                case Format.R64G64B64Sint:
                    return R(64) + G(64) + B(64);
                case Format.R64G64B64Sfloat:
                    return R(64) + G(64) + B(64);*/
                case Format.R64G64B64A64Uint:
                    return R(64) + G(64) + B(64) + A(64);
                case Format.R64G64B64A64Sint:
                    return R(64) + G(64) + B(64) + A(64);
                case Format.R64G64B64A64Sfloat:
                    return R(64) + G(64) + B(64) + A(64);
                /*case Format.B10G11R11UfloatPack32:
                    return B(10) + G(11) + R(11);
                case Format.E5B9G9R9UfloatPack32:
                    return B(11) + G(11) + B(11);
                case Format.D16Unorm:
                    return 100;
                case Format.X8D24UnormPack32:
                    return Depth(24);
                case Format.D32Sfloat:
                    return Depth(32);
                case Format.S8Uint:
                    return Stencil(8);
                case Format.D16UnormS8Uint:
                    return Depth(16) + Stencil(8);
                case Format.D24UnormS8Uint:
                    return Depth(24) + Stencil(8);
                case Format.D32SfloatS8Uint:
                    return Depth(24) + Stencil(8);*/
                default:
                    return 0; // things like block formats, that we just can't properly rate.
            }
        }

        public (Format, int) BestPossibleFormat { get; }

        public FormatRater()
        {
            int max = 0;
            Format best = default;
            foreach (var format in Enum.GetValues<Format>())
            {
                var score = Rate(format);
                if (score > max) 
                {
                    best = format;
                    max = score;
                }
            }

            BestPossibleFormat = (best, max);
        }
    }
}
