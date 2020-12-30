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
            
            var samplerLayoutBinding = new DescriptorSetLayoutBinding
            (
                binding: 1, descriptorType: DescriptorType.CombinedImageSampler, descriptorCount: 1,
                stageFlags: ShaderStageFlags.ShaderStageFragmentBit, pImmutableSamplers: null
            );

            var bindings = stackalloc[] {uboLayoutBinding, samplerLayoutBinding};

            var layoutInfo = new DescriptorSetLayoutCreateInfo(bindingCount: 2, pBindings: bindings);
            _vk.CreateDescriptorSetLayout(_logicalDeviceProvider.LogicalDevice, &layoutInfo, null, out var descriptorSetLayout).ThrowCode();
            DescriptorSetLayout = descriptorSetLayout;
        }

        public unsafe void Dispose()
        {
            _vk.DestroyDescriptorSetLayout(_logicalDeviceProvider.LogicalDevice, DescriptorSetLayout, null);
        }
    }
}
