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
        private readonly Texture _texture;

        public Simple3DMaterial(Texture texture, Vk vk, IResourceProvider resourceProvider, ILogicalDeviceProvider logicalDeviceProvider)
        {
            _vk = vk;
            _logicalDeviceProvider = logicalDeviceProvider;

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

            _texture = texture;
        }

        public unsafe IEnumerable<(WriteDescriptorSet, DescriptorImageInfo?, DescriptorBufferInfo?, BufferView?)> WriteDescriptorSets
        {
            get
            {
                var imageInfo = new DescriptorImageInfo
                (
                    imageLayout: ImageLayout.ShaderReadOnlyOptimal, imageView: _texture.ImageView,
                    sampler: _texture.Sampler
                );
                return new (WriteDescriptorSet, DescriptorImageInfo?, DescriptorBufferInfo?, BufferView?)[]
                {
                    (new WriteDescriptorSet(dstBinding: 1, dstArrayElement: 0, descriptorType: DescriptorType.CombinedImageSampler, descriptorCount: 1),
                        imageInfo, null, null)
                };
            }
        }

        public IEnumerable<DescriptorPoolSize> DescriptorPoolSizes
            => new[]
            {
                new DescriptorPoolSize(DescriptorType.UniformBuffer),
                new DescriptorPoolSize(DescriptorType.CombinedImageSampler)
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
            => new DescriptorSetLayoutBinding[]
            {
                new DescriptorSetLayoutBinding
                (
                    binding: 0, descriptorType: DescriptorType.UniformBuffer, descriptorCount: 1,
                    stageFlags: ShaderStageFlags.ShaderStageVertexBit, pImmutableSamplers: null
                ),
                new DescriptorSetLayoutBinding
                (
                    binding: 1, descriptorType: DescriptorType.CombinedImageSampler, descriptorCount: 1,
                    stageFlags: ShaderStageFlags.ShaderStageFragmentBit, pImmutableSamplers: null
                )
            };

        public unsafe void Dispose()
        {
            _vk.DestroyShaderModule(_logicalDeviceProvider.LogicalDevice, VertexShader, null);
            _vk.DestroyShaderModule(_logicalDeviceProvider.LogicalDevice, FragmentShader, null);
        }
    }
}
