// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Collections.Generic;
using System.Linq;
using Silk.NET.Maths;
using Silk.NET.Vulkan;

namespace Aliquip
{
    internal sealed class Simple3DMaterial : IMaterial
    {
        private readonly Vk _vk;
        private readonly ILogicalDeviceProvider _logicalDeviceProvider;
        private readonly IAllocationCallbacksProvider _allocationCallbacksProvider;

        private static Simple3DMaterial? _cache;
        
        public static Simple3DMaterial Create
            (Vk vk, IResourceProvider resourceProvider, ILogicalDeviceProvider logicalDeviceProvider, IAllocationCallbacksProvider allocationCallbacksProvider)
        {
            return _cache ??= new Simple3DMaterial(vk, resourceProvider, logicalDeviceProvider, allocationCallbacksProvider);
        }

        private Simple3DMaterial(Vk vk, IResourceProvider resourceProvider, ILogicalDeviceProvider logicalDeviceProvider, IAllocationCallbacksProvider allocationCallbacksProvider)
        {
            _vk = vk;
            _logicalDeviceProvider = logicalDeviceProvider;
            _allocationCallbacksProvider = allocationCallbacksProvider;

            unsafe ShaderModule CreateShaderModule(string path)
            {
                var fileContents = resourceProvider[path];
                fixed (byte* pFile = fileContents)
                {
                    var createInfo = new ShaderModuleCreateInfo(codeSize: (UIntPtr) fileContents.Length, pCode: (uint*) pFile);
                    _vk!.CreateShaderModule
                            (_logicalDeviceProvider.LogicalDevice, &createInfo, null, out var module)
                        .ThrowCode();
                    return module;
                }
            }
            
            VertexShader = CreateShaderModule("shaders.simple3d.vert.spv");
            FragmentShader = CreateShaderModule("shaders.simple3d.frag.spv");
        }

        public unsafe IEnumerable<(WriteDescriptorSet, DescriptorImageInfo?, DescriptorBufferInfo?, BufferView?)> WriteDescriptorSets
        {
            get
            {
                return Array.Empty<(WriteDescriptorSet, DescriptorImageInfo?, DescriptorBufferInfo?, BufferView?)>();
            }
        }

        public IEnumerable<DescriptorPoolSize> DescriptorPoolSizes
            => new[]
            {
                new DescriptorPoolSize(DescriptorType.UniformBuffer)
            };

        public ShaderModule VertexShader { get; }
        public ShaderModule FragmentShader { get; }
        public VertexInputAttributeDescription[] VertexInputAttributeDescriptions => Vertex.AttributeDescriptions;
        public unsafe VertexInputBindingDescription VertexInputBindingDescription => new(0, (uint) sizeof(Vertex), VertexInputRate.Vertex);

        public unsafe PushConstantRange[] PushConstantRanges
            => new[]
            {
                new PushConstantRange(ShaderStageFlags.ShaderStageVertexBit, 0, (uint) sizeof(Matrix4X4<float>))
            };

        public unsafe DescriptorSetLayoutBinding[] DescriptorSetLayoutBindings
            => new[]
            {
                new DescriptorSetLayoutBinding
                (
                    binding: 0, descriptorType: DescriptorType.UniformBuffer, descriptorCount: 1,
                    stageFlags: ShaderStageFlags.ShaderStageVertexBit, pImmutableSamplers: null
                )
            };

        public unsafe void Dispose()
        {
            _vk.DestroyShaderModule(_logicalDeviceProvider.LogicalDevice, VertexShader, null);
            _vk.DestroyShaderModule(_logicalDeviceProvider.LogicalDevice, FragmentShader, null);
        }
    }
}
