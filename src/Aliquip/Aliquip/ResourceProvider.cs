// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Logging;

namespace Aliquip
{
    internal sealed class ResourceProvider : IResourceProvider
    {
        private Dictionary<string, byte[]> _resources = new();
        
        public byte[] this[string name] => _resources[name];

        public ResourceProvider(ILogger<ResourceProvider> logger)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var embeddedNames = assembly.GetManifestResourceNames();

            foreach (var embeddedName in embeddedNames)
            {
                using var manifestStream = assembly.GetManifestResourceStream(embeddedName);
                if (manifestStream is null)
                {
                    continue;
                }
                
                using var mem = new MemoryStream();
                manifestStream.CopyTo(mem);
                var n = embeddedName.StartsWith("Aliquip.") ? embeddedName.Substring("Aliquip.".Length) : embeddedName;
                _resources[n] = mem.ToArray();
                logger.LogInformation("Loaded {name}", n);
            }
        }
    }
}
