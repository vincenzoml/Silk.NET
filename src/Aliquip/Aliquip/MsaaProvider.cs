// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Silk.NET.Vulkan;

namespace Aliquip
{
    internal sealed class MsaaProvider : IMsaaProvider
    {
        private readonly IConfiguration _configuration;
        private readonly Vk _vk;
        private readonly Dictionary<PhysicalDevice, SampleCountFlags> _dictionary = new();

        public MsaaProvider(IConfiguration configuration, Vk vk)
        {
            _configuration = configuration;
            _vk = vk;
        }

        public SampleCountFlags MsaaSamples(PhysicalDevice device)
        {
            if (_dictionary.TryGetValue(device, out var v2))
                return v2;
            
            var msaaSamples = SampleCountFlags.SampleCount1Bit;

            var multisamplingSection = _configuration.GetSection("Multisampling");
            if (!multisamplingSection.Exists())
                return msaaSamples;
            var msaaSection = multisamplingSection.GetSection("MSAA");
            if (!msaaSection.Exists())
                return msaaSamples;

            _vk.GetPhysicalDeviceProperties(device, out var physicalDeviceProperties);

            var counts = physicalDeviceProperties.Limits.FramebufferColorSampleCounts &
                         physicalDeviceProperties.Limits.FramebufferDepthSampleCounts;
                
            bool v;
            if (bool.TryParse(msaaSection["x64"], out v) && v && (counts & SampleCountFlags.SampleCount64Bit) != 0)
                msaaSamples = SampleCountFlags.SampleCount64Bit;
            else if (bool.TryParse
                (msaaSection["x32"], out v) && v && (counts & SampleCountFlags.SampleCount32Bit) != 0)
                msaaSamples = SampleCountFlags.SampleCount32Bit;
            else if (bool.TryParse
                (msaaSection["x16"], out v) && v && (counts & SampleCountFlags.SampleCount16Bit) != 0)
                msaaSamples = SampleCountFlags.SampleCount16Bit;
            else if (bool.TryParse
                (msaaSection["x8"], out v) && v && (counts & SampleCountFlags.SampleCount8Bit) != 0)
                msaaSamples = SampleCountFlags.SampleCount8Bit;
            else if (bool.TryParse
                (msaaSection["x4"], out v) && v && (counts & SampleCountFlags.SampleCount4Bit) != 0)
                msaaSamples = SampleCountFlags.SampleCount4Bit;
            else if (bool.TryParse
                (msaaSection["x2"], out v) && v && (counts & SampleCountFlags.SampleCount2Bit) != 0)
                msaaSamples = SampleCountFlags.SampleCount2Bit;

            _dictionary[device] = msaaSamples;
            return msaaSamples;
        }
    }
}
