// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.
using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Text;
using Silk.NET.Core;
using Silk.NET.Core.Native;
using Silk.NET.Core.Attributes;
using Silk.NET.Core.Contexts;
using Silk.NET.Core.Loader;
using Silk.NET.Vulkan;
using Extension = Silk.NET.Core.Attributes.ExtensionAttribute;

#pragma warning disable 1591

namespace Silk.NET.Vulkan.Extensions.FUCHSIA
{
    [Extension("VK_FUCHSIA_imagepipe_surface")]
    public unsafe partial class FuchsiaImagepipeSurface : NativeExtension<Vk>
    {
        public const string ExtensionName = "VK_FUCHSIA_imagepipe_surface";
        /// <summary>To be documented.</summary>
        [NativeApi(EntryPoint = "vkCreateImagePipeSurfaceFUCHSIA")]
        public unsafe partial Result CreateImagePipeSurfaceFuchsia([Count(Count = 0)] Instance instance, [Count(Count = 0), Flow(FlowDirection.In)] ImagePipeSurfaceCreateInfoFUCHSIA* pCreateInfo, [Count(Count = 0), Flow(FlowDirection.In)] AllocationCallbacks* pAllocator, [Count(Count = 0), Flow(FlowDirection.Out)] SurfaceKHR* pSurface);

        /// <summary>To be documented.</summary>
        [NativeApi(EntryPoint = "vkCreateImagePipeSurfaceFUCHSIA")]
        public unsafe partial Result CreateImagePipeSurfaceFuchsia([Count(Count = 0)] Instance instance, [Count(Count = 0), Flow(FlowDirection.In)] ImagePipeSurfaceCreateInfoFUCHSIA* pCreateInfo, [Count(Count = 0), Flow(FlowDirection.In)] AllocationCallbacks* pAllocator, [Count(Count = 0), Flow(FlowDirection.Out)] out SurfaceKHR pSurface);

        /// <summary>To be documented.</summary>
        [NativeApi(EntryPoint = "vkCreateImagePipeSurfaceFUCHSIA")]
        public unsafe partial Result CreateImagePipeSurfaceFuchsia([Count(Count = 0)] Instance instance, [Count(Count = 0), Flow(FlowDirection.In)] ImagePipeSurfaceCreateInfoFUCHSIA* pCreateInfo, [Count(Count = 0), Flow(FlowDirection.In)] in AllocationCallbacks pAllocator, [Count(Count = 0), Flow(FlowDirection.Out)] SurfaceKHR* pSurface);

        /// <summary>To be documented.</summary>
        [NativeApi(EntryPoint = "vkCreateImagePipeSurfaceFUCHSIA")]
        public unsafe partial Result CreateImagePipeSurfaceFuchsia([Count(Count = 0)] Instance instance, [Count(Count = 0), Flow(FlowDirection.In)] ImagePipeSurfaceCreateInfoFUCHSIA* pCreateInfo, [Count(Count = 0), Flow(FlowDirection.In)] in AllocationCallbacks pAllocator, [Count(Count = 0), Flow(FlowDirection.Out)] out SurfaceKHR pSurface);

        /// <summary>To be documented.</summary>
        [NativeApi(EntryPoint = "vkCreateImagePipeSurfaceFUCHSIA")]
        public unsafe partial Result CreateImagePipeSurfaceFuchsia([Count(Count = 0)] Instance instance, [Count(Count = 0), Flow(FlowDirection.In)] in ImagePipeSurfaceCreateInfoFUCHSIA pCreateInfo, [Count(Count = 0), Flow(FlowDirection.In)] AllocationCallbacks* pAllocator, [Count(Count = 0), Flow(FlowDirection.Out)] SurfaceKHR* pSurface);

        /// <summary>To be documented.</summary>
        [NativeApi(EntryPoint = "vkCreateImagePipeSurfaceFUCHSIA")]
        public unsafe partial Result CreateImagePipeSurfaceFuchsia([Count(Count = 0)] Instance instance, [Count(Count = 0), Flow(FlowDirection.In)] in ImagePipeSurfaceCreateInfoFUCHSIA pCreateInfo, [Count(Count = 0), Flow(FlowDirection.In)] AllocationCallbacks* pAllocator, [Count(Count = 0), Flow(FlowDirection.Out)] out SurfaceKHR pSurface);

        /// <summary>To be documented.</summary>
        [NativeApi(EntryPoint = "vkCreateImagePipeSurfaceFUCHSIA")]
        public unsafe partial Result CreateImagePipeSurfaceFuchsia([Count(Count = 0)] Instance instance, [Count(Count = 0), Flow(FlowDirection.In)] in ImagePipeSurfaceCreateInfoFUCHSIA pCreateInfo, [Count(Count = 0), Flow(FlowDirection.In)] in AllocationCallbacks pAllocator, [Count(Count = 0), Flow(FlowDirection.Out)] SurfaceKHR* pSurface);

        /// <summary>To be documented.</summary>
        [NativeApi(EntryPoint = "vkCreateImagePipeSurfaceFUCHSIA")]
        public partial Result CreateImagePipeSurfaceFuchsia([Count(Count = 0)] Instance instance, [Count(Count = 0), Flow(FlowDirection.In)] in ImagePipeSurfaceCreateInfoFUCHSIA pCreateInfo, [Count(Count = 0), Flow(FlowDirection.In)] in AllocationCallbacks pAllocator, [Count(Count = 0), Flow(FlowDirection.Out)] out SurfaceKHR pSurface);

        public FuchsiaImagepipeSurface(INativeContext ctx)
            : base(ctx)
        {
        }
    }
}

