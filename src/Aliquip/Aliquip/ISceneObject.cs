// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using Silk.NET.Maths;

namespace Aliquip
{
    public interface ISceneObject
    {
        IMaterial Material { get; }
        IModel Model { get; }
        Matrix4X4<float> WorldToLocal { get; }
    }
}
