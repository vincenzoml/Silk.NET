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
    [NativeName("Name", "VmaAllocatorInfo")]
    public unsafe partial struct AllocatorInfo
    {
        public AllocatorInfo
        (
            Instance? instance = null,
            PhysicalDevice? physicalDevice = null,
            Device? device = null
        ) : this()
        {
            if (instance is not null)
            {
                Instance = instance.Value;
            }

            if (physicalDevice is not null)
            {
                PhysicalDevice = physicalDevice.Value;
            }

            if (device is not null)
            {
                Device = device.Value;
            }
        }


        [NativeName("Type", "Instance _Nonnull")]
        [NativeName("Type.Name", "Instance _Nonnull")]
        [NativeName("Name", "instance")]
        public Instance Instance;

        [NativeName("Type", "PhysicalDevice _Nonnull")]
        [NativeName("Type.Name", "PhysicalDevice _Nonnull")]
        [NativeName("Name", "physicalDevice")]
        public PhysicalDevice PhysicalDevice;

        [NativeName("Type", "Device _Nonnull")]
        [NativeName("Type.Name", "Device _Nonnull")]
        [NativeName("Name", "device")]
        public Device Device;
    }
}
