// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using Silk.NET.Vulkan;

namespace Aliquip
{
    public interface ICommandBufferFactory
    {
        void RunSingleTime(uint queueFamilyIndex, Queue queueFamily, Action<CommandBuffer> record);
        CommandBuffer[] CreateCommandBuffers(int amount, uint queueFamilyIndex, CommandBufferBeginInfo? commandBufferBeginInfo, Action<CommandBuffer, int> record);
        void FreeCommandBuffers(CommandBuffer[] commandBuffers, uint queueFamilyIndex);
    }
}
