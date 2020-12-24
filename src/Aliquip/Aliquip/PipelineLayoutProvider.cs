// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using Silk.NET.Vulkan;

namespace Aliquip
{
    internal sealed class PipelineLayoutProvider : IPipelineLayoutProvider, IDisposable
    {
        private readonly Vk _vk;
        private readonly Device _device;
        public PipelineLayout PipelineLayout { get; private set; }

        public PipelineLayoutProvider(Vk vk, ILogicalDeviceProvider logicalDeviceProvider)
        {
            _vk = vk;
            _device = logicalDeviceProvider.LogicalDevice;
            
            RecreatePipelineLayout();
        }
        
        public unsafe void RecreatePipelineLayout()
        {
            var createInfo = new PipelineLayoutCreateInfo(setLayoutCount: 0, pushConstantRangeCount: 0);
            _vk.CreatePipelineLayout(_device, &createInfo, null, out var pipelineLayout).ThrowCode();
            PipelineLayout = pipelineLayout;
        }

        public unsafe void Dispose()
        {
            _vk.DestroyPipelineLayout(_device, PipelineLayout, null);
        }
    }
}
