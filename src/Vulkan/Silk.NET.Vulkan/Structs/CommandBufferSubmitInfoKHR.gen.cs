// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.


using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Text;
using Silk.NET.Core;
using Silk.NET.Core.Native;
using Silk.NET.Core.Attributes;
using Silk.NET.Core.Contexts;
using Silk.NET.Core.Loader;

#pragma warning disable 1591

namespace Silk.NET.Vulkan
{
    [NativeName("Name", "VkCommandBufferSubmitInfoKHR")]
    public unsafe partial struct CommandBufferSubmitInfoKHR
    {
        public CommandBufferSubmitInfoKHR
        (
            StructureType? sType = StructureType.CommandBufferSubmitInfoKhr,
            void* pNext = null,
            CommandBuffer? commandBuffer = null,
            uint? deviceMask = null
        ) : this()
        {
            if (sType is not null)
            {
                SType = sType.Value;
            }

            if (pNext is not null)
            {
                PNext = pNext;
            }

            if (commandBuffer is not null)
            {
                CommandBuffer = commandBuffer.Value;
            }

            if (deviceMask is not null)
            {
                DeviceMask = deviceMask.Value;
            }
        }

/// <summary></summary>
        [NativeName("Type", "VkStructureType")]
        [NativeName("Type.Name", "VkStructureType")]
        [NativeName("Name", "sType")]
        public StructureType SType;
/// <summary></summary>
        [NativeName("Type", "void*")]
        [NativeName("Type.Name", "void")]
        [NativeName("Name", "pNext")]
        public void* PNext;
/// <summary></summary>
        [NativeName("Type", "VkCommandBuffer")]
        [NativeName("Type.Name", "VkCommandBuffer")]
        [NativeName("Name", "commandBuffer")]
        public CommandBuffer CommandBuffer;
/// <summary></summary>
        [NativeName("Type", "uint32_t")]
        [NativeName("Type.Name", "uint32_t")]
        [NativeName("Name", "deviceMask")]
        public uint DeviceMask;
    }
}
