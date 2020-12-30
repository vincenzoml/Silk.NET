// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Aliquip
{
    internal sealed class SampleShadingProvider : ISampleShadingProvider
    {
        public bool UseSampleShading { get; }

        public SampleShadingProvider(IConfiguration configuration, ILogger<SampleShadingProvider> logger)
        {
            UseSampleShading = bool.TryParse(configuration["Sample Shading"], out var v) && v;
            if (UseSampleShading)
                logger.LogInformation("Using sample shading");
        }
    }
}
