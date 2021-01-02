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

namespace Silk.NET.Vulkan.VMA
{
    [NativeName("Name", "VmaBudget")]
    public unsafe partial struct Budget
    {
        public Budget
        (
            ulong? blockBytes = null,
            ulong? allocationBytes = null,
            ulong? usage = null,
            ulong? budget = null
        ) : this()
        {
            if (blockBytes is not null)
            {
                BlockBytes = blockBytes.Value;
            }

            if (allocationBytes is not null)
            {
                AllocationBytes = allocationBytes.Value;
            }

            if (usage is not null)
            {
                Usage = usage.Value;
            }

            if (budget is not null)
            {
                Value = budget.Value;
            }
        }


        [NativeName("Type", "DeviceSize")]
        [NativeName("Type.Name", "DeviceSize")]
        [NativeName("Name", "blockBytes")]
        public ulong BlockBytes;

        [NativeName("Type", "DeviceSize")]
        [NativeName("Type.Name", "DeviceSize")]
        [NativeName("Name", "allocationBytes")]
        public ulong AllocationBytes;

        [NativeName("Type", "DeviceSize")]
        [NativeName("Type.Name", "DeviceSize")]
        [NativeName("Name", "usage")]
        public ulong Usage;

        [NativeName("Type", "DeviceSize")]
        [NativeName("Type.Name", "DeviceSize")]
        [NativeName("Name", "budget")]
        public ulong Value;
    }
}
