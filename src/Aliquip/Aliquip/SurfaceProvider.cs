// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using Silk.NET.Core.Native;
using Silk.NET.Vulkan;
using Silk.NET.Vulkan.Extensions.KHR;

namespace Aliquip
{
    public sealed class SurfaceProvider : ISurfaceProvider, IDisposable
    {
        private readonly Instance _instance;
        private readonly KhrSurface _khrSurface;
        public SurfaceKHR Surface { get; }

        public unsafe SurfaceProvider(KhrSurface khrSurface, IInstanceProvider instanceProvider, IWindowProvider windowProvider)
        {
            _khrSurface = khrSurface;
            _instance = instanceProvider.Instance;
            Surface = windowProvider.Window.VkSurface!.Create<AllocationCallbacks>
                    (_instance.ToHandle(), null)
                .ToSurface();
        }

        public unsafe void Dispose()
        {
            _khrSurface.DestroySurface(_instance, Surface, null);
            _khrSurface.Dispose();
        }
    }
}
