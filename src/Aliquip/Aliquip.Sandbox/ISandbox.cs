// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Silk.NET.Maths;
using Silk.NET.Windowing;

namespace Aliquip.Sandbox
{
    public interface ISandbox : IAsyncDisposable, IDisposable
    {
        Scene3D Scene3D { get; }
        IWindow Window { get; }
        void Run();
        ILogger<T> GetLogger<T>();
        T GetService<T>();
        T Instantiate<T>(params object[] extraParams);
        MovableSceneObject AddPrimitive(Primitive primitive, Vector3 color);
    }
}
