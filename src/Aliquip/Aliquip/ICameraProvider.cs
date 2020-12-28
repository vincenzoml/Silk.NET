// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using Silk.NET.Maths;

namespace Aliquip
{
    public interface ICameraProvider
    {
        Matrix4X4<float> ViewMatrix { get; }
        Matrix4X4<float> ProjectionMatrix { get; }
    }
}
