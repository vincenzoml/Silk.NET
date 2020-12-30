// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Collections.Generic;
using System.Linq;
using Silk.NET.Core.Native;
using Silk.NET.Vulkan;
using Silk.NET.Vulkan.Extensions.KHR;

namespace Aliquip
{
    internal sealed class LogicalDeviceProvider : ILogicalDeviceProvider, IGraphicsQueueProvider, IPresentQueueProvider, ITransferQueueProvider, IDisposable
    {
        private readonly IPhysicalDeviceProvider _physicalDeviceProvider;
        private readonly Vk _vk;
        public Device LogicalDevice { get; private set; }
        public Queue GraphicsQueue { get; }
        public uint GraphicsQueueIndex { get; set; }
        public Queue PresentQueue { get; }
        public uint PresentQueueIndex { get; }
        public Queue TransferQueue { get; }
        public uint TransferQueueIndex { get; }

        public unsafe LogicalDeviceProvider(IQueueFamilyProvider queueFamilyProvider, IPhysicalDeviceProvider physicalDeviceProvider, Vk vk, ISampleShadingProvider sampleShadingProvider)
        {
            _physicalDeviceProvider = physicalDeviceProvider;
            _vk = vk;
            // TODO: dedup device extensions
            // (LogicalDeviceProvider & PhysicalDeviceProvider)
            var deviceExtensions = new List<string>();
            deviceExtensions.Add(KhrSwapchain.ExtensionName);
            
            QueueFamilyIndices indices = queueFamilyProvider.FindQueueFamilyIndices(physicalDeviceProvider.Device);

            List<uint> queuesToCreate = new();
            queuesToCreate.Add(indices.GraphicsFamily!.Value);
            queuesToCreate.Add(indices.PresentFamily!.Value);
            queuesToCreate.Add(indices.TransferFamily!.Value);
            queuesToCreate = queuesToCreate.Distinct().ToList();

            var queueCreateInfos = stackalloc DeviceQueueCreateInfo[queuesToCreate.Count];
            var queuePriority = 1.0f;
            for (var i = 0; i < queuesToCreate.Count; i++)
            {
                queueCreateInfos[i] = new DeviceQueueCreateInfo
                    (queueFamilyIndex: queuesToCreate[i], queueCount: 1, pQueuePriorities: &queuePriority);
            }

            PhysicalDeviceFeatures deviceFeatures = new PhysicalDeviceFeatures();
            deviceFeatures.SamplerAnisotropy = true;
            deviceFeatures.SampleRateShading = sampleShadingProvider.UseSampleShading;

            var physicalDeviceSeparateDepthStencilLayoutsFeatures =
                new PhysicalDeviceSeparateDepthStencilLayoutsFeatures(separateDepthStencilLayouts: true);

            DeviceCreateInfo deviceCreateInfo = new DeviceCreateInfo
            (
                pQueueCreateInfos: queueCreateInfos,
                queueCreateInfoCount: (uint) queuesToCreate.Count,
                pEnabledFeatures: &deviceFeatures,
                enabledExtensionCount: (uint) deviceExtensions.Count,
                ppEnabledExtensionNames: deviceExtensions.Count > 0 ? (byte**) SilkMarshal.StringArrayToPtr(deviceExtensions) : default
                // these *should* be ignored by up-to-date versions, but we set them anyways.
                // TODO: Fix this up
                // enabledLayerCount: EnableValidationLayers ? (uint) ValidationLayers.Length : 0,
                // ppEnabledLayerNames: EnableValidationLayers
                //     ? (byte**) SilkMarshal.StringArrayToPtr(ValidationLayers)
                //     : default
                , pNext: &physicalDeviceSeparateDepthStencilLayoutsFeatures
            );

            _vk.CreateDevice(physicalDeviceProvider.Device, &deviceCreateInfo, null, out var logicalDevice).ThrowCode();
            LogicalDevice = logicalDevice;
            _vk.CurrentDevice = LogicalDevice;
            _vk.GetDeviceQueue(LogicalDevice, indices.GraphicsFamily!.Value, 0, out var graphicsQueue);
            GraphicsQueue = graphicsQueue;
            GraphicsQueueIndex = indices.GraphicsFamily.Value;
            _vk.GetDeviceQueue(LogicalDevice, indices.PresentFamily!.Value, 0, out var presentQueue);
            PresentQueue = presentQueue;
            PresentQueueIndex = indices.PresentFamily.Value;
            _vk.GetDeviceQueue(LogicalDevice, indices.TransferFamily!.Value, 0, out var transferQueue);
            TransferQueue = transferQueue;
            TransferQueueIndex = indices.TransferFamily.Value;
        }

        public unsafe void Dispose()
        {
            if (LogicalDevice.Handle != default)
            {
                _vk.DestroyDevice(LogicalDevice, null);
                LogicalDevice = default;
            }
        }
    }
}
