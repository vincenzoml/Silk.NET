// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Silk.NET.Core.Native;
using Silk.NET.GLFW;
using Silk.NET.Maths;
using Silk.NET.Windowing;
using VideoMode = Silk.NET.Windowing.VideoMode;

namespace Aliquip
{
    internal sealed class WindowProvider
        : IWindowProvider
    {
        public IWindow Window { get; private set; }
        private bool _loaded;
        private IObservable<WindowResized> _windowResizeObservable;
        private IObservable<WindowStateChanged> _windowStateChangedObservable;
        private IObservable<WindowRender> _windowRenderObservable;
        private readonly ILogger<WindowProvider> _logger;

        public unsafe WindowProvider(ILogger<WindowProvider> logger)
        {
            _logger = logger;
            Window = Silk.NET.Windowing.Window.Create
            (
                new WindowOptions
                (
                    true, new Vector2D<int>(50, 50), new Vector2D<int>(1280, 720), 0.0, 0.0,
                    new GraphicsAPI
                        (ContextAPI.Vulkan, ContextProfile.Core, ContextFlags.ForwardCompatible, new APIVersion(1, 2)),
                    "Aliquip sample title", WindowState.Normal, WindowBorder.Resizable, false, false, new VideoMode()
                )
            );

            _windowResizeObservable = Observable.FromEvent<Action<Vector2D<int>>, WindowResized>
            (
                action => (x) => action(new WindowResized(Window, x)), 
                action => Window.Resize += action,
                action => Window.Resize -= action
            );

            _windowStateChangedObservable = Observable.FromEvent<Action<WindowState>, WindowStateChanged>
            (
                action => (x) => action(new WindowStateChanged(Window, x)), 
                action => Window.StateChanged += action,
                action => Window.StateChanged -= action
            );
            
            _windowRenderObservable = Observable.FromEvent<Action<double>, WindowRender>
            (
                action => (x) => action(new WindowRender(Window, x)), 
                action => Window.Render += action,
                action => Window.Render -= action
            );
            
            _logger.LogDebug("Waiting for window to load");
            
            Window.Initialize();
            var glfwExtensions = Window.VkSurface!.GetRequiredExtensions(out var count);
            InstanceExtensions = SilkMarshal.PtrToStringArray((IntPtr) glfwExtensions, (int)count);
        }

        public void Dispose()
        {
            Window?.Dispose();
        }

        public IDisposable Subscribe(IObserver<WindowResized> observer)
        {
            return _windowResizeObservable.Subscribe(observer);
        }

        public IDisposable Subscribe(IObserver<WindowStateChanged> observer)
        {
            return _windowStateChangedObservable.Subscribe(observer);
        }

        public IDisposable Subscribe(IObserver<WindowRender> observer)
        {
            return _windowRenderObservable.Subscribe(observer);
        }

        public IEnumerable<string> InstanceExtensions { get; private set; }
    }

    public record WindowResized(IWindow Sender, Vector2D<int> EventArgs) : IEventPattern<IWindow, Vector2D<int>> { }

    public record WindowStateChanged(IWindow Sender, WindowState EventArgs) : IEventPattern<IWindow, WindowState> { }
    
    public record WindowRender(IWindow Sender, double EventArgs) : IEventPattern<IWindow, double> { }
}
