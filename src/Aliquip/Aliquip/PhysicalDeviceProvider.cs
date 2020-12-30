// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Silk.NET.Core.Native;
using Silk.NET.Vulkan;
using Silk.NET.Vulkan.Extensions.KHR;

namespace Aliquip
{
    public sealed class PhysicalDeviceProvider : IPhysicalDeviceProvider
    {
        private readonly Instance _instance;
        private readonly Vk _vk;
        private ILogger<PhysicalDeviceProvider> _logger;
        public PhysicalDevice Device { get; }

        public unsafe PhysicalDeviceProvider
        (
            Vk vk,
            IInstanceProvider instanceProvider,
            ILogger<PhysicalDeviceProvider> logger,
            IQueueFamilyProvider queueFamilyProvider,
            ISwapchainSupportProvider swapchainSupportProvider,
            IFormatRater formatRater,
            IColorspaceRater colorspaceRater
        )
        {
            _vk = vk;
            _instance = instanceProvider.Instance;
            _logger = logger;

            var deviceExtensions = new List<string>();
            deviceExtensions.Add(KhrSwapchain.ExtensionName);

            _logger.LogDebug("Selecting physical device");
            uint deviceCount = 0;
            _vk.EnumeratePhysicalDevices(_instance, ref deviceCount, null).ThrowCode();

            if (deviceCount == 0)
            {
                _logger.LogError("No Vulkan device found.");
                return;
            }

            var pPhysicalDevices = stackalloc PhysicalDevice[(int) deviceCount];
            _vk.EnumeratePhysicalDevices(_instance, ref deviceCount, pPhysicalDevices).ThrowCode();

            var maximum = 0;
            PhysicalDevice device = default;
            for (int i = 0; i < deviceCount; i++)
            {
                var rating = RateDeviceSuitability(pPhysicalDevices[i]);
                if (rating > maximum)
                {
                    maximum = rating;
                    device = pPhysicalDevices[i];
                }
            }

            if (maximum <= 0)
            {
                _logger.LogError("No suitable GPU found.");
            }


            PhysicalDeviceProperties deviceProperties;
            _vk.GetPhysicalDeviceProperties(device, &deviceProperties);
            _logger.LogDebug
            (
                "Picked device: {Name} | {Type}", SilkMarshal.PtrToString((IntPtr) deviceProperties.DeviceName),
                deviceProperties.DeviceType
            );
            Device = device;

            int RateDeviceSuitability(PhysicalDevice device)
            {
                bool CheckDeviceExtensionSupport(PhysicalDevice device, out int extensionRating)
                {
                    extensionRating = 0;
                    
                    uint extensionCount;
                    _vk.EnumerateDeviceExtensionProperties(device, default(byte*), &extensionCount, null);

                    var pavailableExtensions = stackalloc ExtensionProperties[(int) extensionCount];
                    _vk.EnumerateDeviceExtensionProperties
                        (device, default(byte*), &extensionCount, pavailableExtensions);
                    var availableExtensions = new string[(int) extensionCount];

                    for (int i = 0; i < extensionCount; i++)
                        availableExtensions[i] = SilkMarshal.PtrToString
                            ((IntPtr) pavailableExtensions[i].ExtensionName);

                    foreach (var extension in deviceExtensions)
                    {
                        if (!availableExtensions.Contains(extension)) return false;
                    }

                    return true;
                }

                PhysicalDeviceProperties deviceProperties;
                _vk.GetPhysicalDeviceProperties(device, &deviceProperties);
                var depthStencilResolveProperties = new PhysicalDeviceSeparateDepthStencilLayoutsFeatures(sType: StructureType.PhysicalDeviceFeatures2);
                PhysicalDeviceFeatures2 deviceFeatures = new PhysicalDeviceFeatures2(pNext: &depthStencilResolveProperties);
                _vk.GetPhysicalDeviceFeatures2(device, &deviceFeatures);

                int score = 5;
                
                if (!depthStencilResolveProperties.SeparateDepthStencilLayouts) return 0;

                if (!deviceFeatures.Features.SamplerAnisotropy) return 0;

                if (!queueFamilyProvider.FindQueueFamilyIndices(device).IsComplete()) return 0;

                if (!CheckDeviceExtensionSupport(device, out var extensionRating)) return 0;

                score += extensionRating;

                var swapChainSupport = swapchainSupportProvider.QuerySwapchainSupport(device);
                if (swapChainSupport.Formats.Length == 0 || swapChainSupport.PresentModes.Length == 0) return 0;

                score += swapChainSupport.Formats.Max
                    (x => formatRater.Rate(x.Format) + colorspaceRater.Rate(x.ColorSpace));

                if (swapChainSupport.Formats.Any
                    (x => x.Format == Format.R8G8B8A8Srgb && x.ColorSpace == ColorSpaceKHR.ColorspaceSrgbNonlinearKhr))
                    score += 200; // total of 400, as the previous two also apply.

                if (swapChainSupport.PresentModes.Contains(PresentModeKHR.PresentModeMailboxKhr)) score += 200;

                // Discrete GPUs have a significant performance advantage.
                if (deviceProperties.DeviceType == PhysicalDeviceType.DiscreteGpu)
                {
                    score += 3000;
                }

                return score;
            }
        }
    }
}
