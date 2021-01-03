// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Drawing;
using System.Threading.Tasks;
using Silk.NET.Maths;

namespace Aliquip.Sandbox
{
    public static class SandboxExtensions
    {
        public static void Run(this ISandbox sandbox, Action action)
        {
            sandbox.Window.Update += (d) => action();
            sandbox.Run();
        }
        
        public static void Run(this ISandbox sandbox, Action<double> action)
        {
            sandbox.Window.Update += action;
            sandbox.Run();
        }

        public static MovableSceneObject AddPrimitive(this ISandbox sandbox, Primitive primitive, Color color)
        {
            return sandbox.AddPrimitive(primitive, new Vector3D<float>(color.R / 255f, color.G / 255f, color.B / 255f));
        }
    }
}
