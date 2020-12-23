// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using Silk.NET.Vulkan;

namespace Aliquip
{
    internal sealed class CommandPoolProvider : ICommandPoolProvider, IDisposable
    {
        private readonly Vk _vk;
        private readonly Device _device;
        public CommandPool CommandPool { get; }

        public unsafe CommandPoolProvider(Vk vk, IQueueFamilyProvider queueFamilyProvider, IPhysicalDeviceProvider physicalDeviceProvider, ILogicalDeviceProvider logicalDeviceProvider)
        {
            _vk = vk;
            _device = logicalDeviceProvider.LogicalDevice;
            var indices = queueFamilyProvider.FindQueueFamilyIndices(physicalDeviceProvider.Device);

            var createInfo = new CommandPoolCreateInfo(queueFamilyIndex: indices.GraphicsFamily!.Value);

            _vk.CreateCommandPool(_device, &createInfo, null, out var cp).ThrowCode();
            CommandPool = cp;
        }

        public unsafe void Dispose()
        {
            _vk.DestroyCommandPool(_device, CommandPool, null);
        }
    }
}
