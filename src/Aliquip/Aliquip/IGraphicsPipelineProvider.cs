// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using Silk.NET.Vulkan;
using Buffer = Silk.NET.Vulkan.Buffer;

namespace Aliquip
{
    public interface IGraphicsPipelineProvider : IDisposable
    {
        uint IndexCount { get; }
        void RecreateGraphicsPipeline();
        void Bind(CommandBuffer commandBuffer);
    }
}
