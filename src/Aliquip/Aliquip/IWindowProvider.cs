// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using Microsoft.Extensions.Hosting;
using Silk.NET.Windowing;

namespace Aliquip
{
    public interface IWindowProvider
        :
            IDisposable,
            IObservable<WindowResized>,
            IObservable<WindowStateChanged>,
            IObservable<WindowRender>
    {
        public IWindow Window { get; }
    }
}
