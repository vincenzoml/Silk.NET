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
    [NativeName("Name", "VkAttachmentDescription")]
    public unsafe partial struct AttachmentDescription
    {
        public AttachmentDescription
        (
            AttachmentDescriptionFlags? flags = null,
            Format? format = null,
            SampleCountFlags? samples = null,
            AttachmentLoadOp? loadOp = null,
            AttachmentStoreOp? storeOp = null,
            AttachmentLoadOp? stencilLoadOp = null,
            AttachmentStoreOp? stencilStoreOp = null,
            ImageLayout? initialLayout = null,
            ImageLayout? finalLayout = null
        ) : this()
        {
            if (flags is not null)
            {
                Flags = flags.Value;
            }

            if (format is not null)
            {
                Format = format.Value;
            }

            if (samples is not null)
            {
                Samples = samples.Value;
            }

            if (loadOp is not null)
            {
                LoadOp = loadOp.Value;
            }

            if (storeOp is not null)
            {
                StoreOp = storeOp.Value;
            }

            if (stencilLoadOp is not null)
            {
                StencilLoadOp = stencilLoadOp.Value;
            }

            if (stencilStoreOp is not null)
            {
                StencilStoreOp = stencilStoreOp.Value;
            }

            if (initialLayout is not null)
            {
                InitialLayout = initialLayout.Value;
            }

            if (finalLayout is not null)
            {
                FinalLayout = finalLayout.Value;
            }
        }

/// <summary></summary>
        [NativeName("Type", "VkAttachmentDescriptionFlags")]
        [NativeName("Type.Name", "VkAttachmentDescriptionFlags")]
        [NativeName("Name", "flags")]
        public AttachmentDescriptionFlags Flags;
/// <summary></summary>
        [NativeName("Type", "VkFormat")]
        [NativeName("Type.Name", "VkFormat")]
        [NativeName("Name", "format")]
        public Format Format;
/// <summary></summary>
        [NativeName("Type", "VkSampleCountFlagBits")]
        [NativeName("Type.Name", "VkSampleCountFlagBits")]
        [NativeName("Name", "samples")]
        public SampleCountFlags Samples;
/// <summary></summary>
        [NativeName("Type", "VkAttachmentLoadOp")]
        [NativeName("Type.Name", "VkAttachmentLoadOp")]
        [NativeName("Name", "loadOp")]
        public AttachmentLoadOp LoadOp;
/// <summary></summary>
        [NativeName("Type", "VkAttachmentStoreOp")]
        [NativeName("Type.Name", "VkAttachmentStoreOp")]
        [NativeName("Name", "storeOp")]
        public AttachmentStoreOp StoreOp;
/// <summary></summary>
        [NativeName("Type", "VkAttachmentLoadOp")]
        [NativeName("Type.Name", "VkAttachmentLoadOp")]
        [NativeName("Name", "stencilLoadOp")]
        public AttachmentLoadOp StencilLoadOp;
/// <summary></summary>
        [NativeName("Type", "VkAttachmentStoreOp")]
        [NativeName("Type.Name", "VkAttachmentStoreOp")]
        [NativeName("Name", "stencilStoreOp")]
        public AttachmentStoreOp StencilStoreOp;
/// <summary></summary>
        [NativeName("Type", "VkImageLayout")]
        [NativeName("Type.Name", "VkImageLayout")]
        [NativeName("Name", "initialLayout")]
        public ImageLayout InitialLayout;
/// <summary></summary>
        [NativeName("Type", "VkImageLayout")]
        [NativeName("Type.Name", "VkImageLayout")]
        [NativeName("Name", "finalLayout")]
        public ImageLayout FinalLayout;
    }
}
