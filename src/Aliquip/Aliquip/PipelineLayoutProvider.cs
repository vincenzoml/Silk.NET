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
        private readonly ILogicalDeviceProvider _logicalDeviceProvider;
        private readonly IDescriptorSetLayoutProvider _descriptorSetLayoutProvider;
        public PipelineLayout PipelineLayout { get; private set; }

        public PipelineLayoutProvider(Vk vk, ILogicalDeviceProvider logicalDeviceProvider, IDescriptorSetLayoutProvider descriptorSetLayoutProvider)
        {
            _vk = vk;
            _logicalDeviceProvider = logicalDeviceProvider;
            _descriptorSetLayoutProvider = descriptorSetLayoutProvider;

            Recreate();
        }
        
        public unsafe void Recreate()
        {
            var setLayouts = stackalloc[] { _descriptorSetLayoutProvider.DescriptorSetLayout };
            var createInfo = new PipelineLayoutCreateInfo(setLayoutCount: 1, pSetLayouts: setLayouts, pushConstantRangeCount: 0);
            _vk.CreatePipelineLayout(_logicalDeviceProvider.LogicalDevice, &createInfo, null, out var pipelineLayout).ThrowCode();
            PipelineLayout = pipelineLayout;
        }

        public unsafe void Dispose()
        {
            _vk.DestroyPipelineLayout(_logicalDeviceProvider.LogicalDevice, PipelineLayout, null);
        }
    }
}
