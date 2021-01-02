// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using Silk.NET.Core.Loader;

namespace Silk.NET.Vulkan.VMA
{
    /// <summary>
    /// Contains the library name of VMA.
    /// </summary>
    internal class VMALibraryNameContainer : SearchPathContainer
    {
        /// <inheritdoc />
        public override string Linux => "vma.so";

        /// <inheritdoc />
        public override string MacOS => "vma.dylib";

        /// <inheritdoc />
        public override string Android => "vma.so";

        /// <inheritdoc />
        public override string IOS => "__Internal";

        /// <inheritdoc />
        public override string Windows64 => "vma.dll";

        /// <inheritdoc />
        public override string Windows86 => "vma.dll";
    }
}
