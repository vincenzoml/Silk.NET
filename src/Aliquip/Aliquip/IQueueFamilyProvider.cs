// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using Silk.NET.Vulkan;

namespace Aliquip
{
    public interface IQueueFamilyProvider
    {
        QueueFamilyIndices FindQueueFamilyIndices(PhysicalDevice device);
    }
    
    public struct QueueFamilyIndices
    {
        public uint? GraphicsFamily;
        public uint? PresentFamily;
        public uint? TransferFamily;

        public bool IsComplete()
        {
            return GraphicsFamily.HasValue && PresentFamily.HasValue && TransferFamily.HasValue;
        }
    }
}
