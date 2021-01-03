// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Threading.Tasks;

namespace Aliquip.Sandbox
{
    public static class SandboxExtensions
    {
        public static void Run(this ISandbox sandbox, Action action)
        {
            Task.Run(action);
            sandbox.Run();
        }
        
        public static void Run(this ISandbox sandbox, Func<Task> action)
        {
            Task.Run(action);
            sandbox.Run();
        }
    }
}
