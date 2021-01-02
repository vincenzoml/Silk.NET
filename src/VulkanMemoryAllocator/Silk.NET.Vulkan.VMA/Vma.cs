using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Text;
using Silk.NET.Core;
using Silk.NET.Core.Native;
using Silk.NET.Core.Attributes;
using Silk.NET.Core.Contexts;
using Silk.NET.Core.Loader;
using ExtensionAttribute = Silk.NET.Core.Attributes.ExtensionAttribute;

#pragma warning disable 1591

namespace Silk.NET.Vulkan.VMA
{
    public partial class Vma
    {
        public static Vma GetApi()
        {
             return new Vma(CreateDefaultContext(new VMALibraryNameContainer().GetLibraryName()));
        }

        public bool TryGetExtension<T>(out T ext)
            where T:NativeExtension<Vma>
        {
             ext = IsExtensionPresent(ExtensionAttribute.GetExtensionAttribute(typeof(T)).Name)
                 ? (T) Activator.CreateInstance(typeof(T), Context)
                 : null;
             return ext is not null;
        }

        public override bool IsExtensionPresent(string extension)
        {
            return false;
        }
    }
}

