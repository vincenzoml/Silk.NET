// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;

namespace Aliquip
{
    public interface IColorImageProvider : IDisposable
    {
        Texture? ColorImage { get; }
        void Recreate();
    }
}
