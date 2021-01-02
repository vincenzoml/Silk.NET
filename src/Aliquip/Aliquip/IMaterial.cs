// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Collections.Generic;
using Silk.NET.Vulkan;

namespace Aliquip
{
    public interface IMaterial : IDisposable
    {
        ShaderModule VertexShader { get; }
        ShaderModule FragmentShader { get; }
        VertexInputAttributeDescription[] VertexInputAttributeDescriptions { get; }
        VertexInputBindingDescription VertexInputBindingDescription { get; }
        PushConstantRange[] PushConstantRanges { get; }
        DescriptorSetLayoutBinding[] DescriptorSetLayoutBindings { get; }
        IEnumerable<(WriteDescriptorSet, DescriptorImageInfo?, DescriptorBufferInfo?, BufferView?)> WriteDescriptorSets { get; }
        IEnumerable<DescriptorPoolSize> DescriptorPoolSizes { get; }
    }
}
