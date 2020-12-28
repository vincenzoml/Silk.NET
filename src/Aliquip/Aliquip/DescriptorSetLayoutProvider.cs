// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using Silk.NET.Vulkan;

namespace Aliquip
{
    internal sealed class DescriptorSetLayoutProvider : IDescriptorSetLayoutProvider, IDisposable
    {
        private readonly Vk _vk;
        private readonly ILogicalDeviceProvider _logicalDeviceProvider;
        public DescriptorSetLayout DescriptorSetLayout { get; }

        public unsafe DescriptorSetLayoutProvider(Vk vk, ILogicalDeviceProvider logicalDeviceProvider)
        {
            _vk = vk;
            _logicalDeviceProvider = logicalDeviceProvider;

            var uboLayoutBinding = new DescriptorSetLayoutBinding
            (
                binding: 0, descriptorType: DescriptorType.UniformBuffer, descriptorCount: 1,
                stageFlags: ShaderStageFlags.ShaderStageVertexBit, pImmutableSamplers: null
            );

            var layoutInfo = new DescriptorSetLayoutCreateInfo(bindingCount: 1, pBindings: &uboLayoutBinding);
            _vk.CreateDescriptorSetLayout(_logicalDeviceProvider.LogicalDevice, &layoutInfo, null, out var descriptorSetLayout).ThrowCode();
            DescriptorSetLayout = descriptorSetLayout;
        }

        public unsafe void Dispose()
        {
            _vk.DestroyDescriptorSetLayout(_logicalDeviceProvider.LogicalDevice, DescriptorSetLayout, null);
        }
    }
}
