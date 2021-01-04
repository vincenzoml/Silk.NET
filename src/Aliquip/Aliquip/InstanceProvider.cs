// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Silk.NET.Core.Native;
using Silk.NET.Vulkan;
using Silk.NET.Vulkan.Extensions.EXT;

namespace Aliquip
{
    internal sealed unsafe class InstanceProvider : IInstanceProvider
    {
        public Instance Instance { get; }
        private Vk _vk;
        private readonly ILogger _logger;
        private readonly IAllocationCallbacksProvider _allocationCallbacksProvider;

        public InstanceProvider(Vk vk, ILogger<InstanceProvider> logger, IWindowProvider windowProvider,
            IAllocationCallbacksProvider allocationCallbacksProvider
#if DEBUG
            , IDebugMessengerProvider debugMessengerProvider
#endif
            )
        {
            _vk = vk;
            _logger = logger;
            _allocationCallbacksProvider = allocationCallbacksProvider;

            ApplicationInfo appInfo = new ApplicationInfo(
                pApplicationName: (byte*) SilkMarshal.StringToPtr("Project Aliquip"),
                applicationVersion: Vk.MakeVersion(1, 0, 0),
                pEngineName: (byte*) SilkMarshal.StringToPtr("No engine"),
                engineVersion: Vk.MakeVersion(1, 0, 0),
                apiVersion: Vk.Version12
            );

            var extensions = new List<string>();
            var pGlfwExtensions = windowProvider.Window.VkSurface!.GetRequiredExtensions(out var count);
            extensions.AddRange(SilkMarshal.PtrToStringArray((IntPtr) pGlfwExtensions, (int)count));
#if DEBUG
            extensions.Add(ExtDebugUtils.ExtensionName);
#endif
            
            var pExtensionNames = SilkMarshal.StringArrayToPtr(extensions.ToArray());

#if DEBUG
            var layerNames = new[] {"VK_LAYER_KHRONOS_validation"};
#else
            var layerNames = new string[] { };
#endif
            var pLayerNames = layerNames.Length > 0 ? SilkMarshal.StringArrayToPtr(layerNames) : default;

            _logger.LogDebug($"Creating instance with {layerNames.Length} layers: \"{string.Join("\", \"", layerNames)}\".");
            _logger.LogDebug($"Loading {extensions.Count} instance extensions: \"{string.Join("\", \"", extensions)}\".");
            
#if DEBUG
            var debugMessengerCreateInfo = debugMessengerProvider.CreateInfo;
#endif
            InstanceCreateInfo instanceCreateInfo = new InstanceCreateInfo(
                pApplicationInfo: &appInfo,
                enabledExtensionCount: (uint)extensions.Count,
                ppEnabledExtensionNames: (byte**) pExtensionNames,
#if DEBUG
                pNext: &debugMessengerCreateInfo,
#endif
                enabledLayerCount: (uint)layerNames.Length,
                ppEnabledLayerNames: (byte**) pLayerNames
            );
            
            { // hide instance variable
                _vk.CreateInstance(&instanceCreateInfo, _allocationCallbacksProvider.AllocationCallbacks, out var instance).ThrowCode();
                Instance = instance;
            }
            
            SilkMarshal.FreeString((IntPtr) appInfo.PApplicationName);
            SilkMarshal.FreeString((IntPtr) appInfo.PEngineName);
            _vk.CurrentInstance = Instance;
#if DEBUG
            debugMessengerProvider.Attach(Instance);
#endif
        }          

        public void Dispose()
        {
            _vk.DestroyInstance(Instance, _allocationCallbacksProvider.AllocationCallbacks);
        }
    }
}
