using System;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Silk.NET.Maths;
using Silk.NET.Windowing;

namespace Aliquip.Sandbox
{
    public static class Sandbox
    {
        public static ISandbox Create()
        {
            return new SandboxImpl();
        }
        
        private class SandboxImpl : ISandbox
        {
            private IHost _host;

            public Scene3D Scene3D => _host.Services.GetRequiredService<Scene3D>();
            public IWindow Window => _host.Services.GetRequiredService<IWindowProvider>().Window;

            public SandboxImpl()
            {
                _host = Host.CreateDefaultBuilder()
                    .UseSerilog
                    (
                        (a, b) => b.MinimumLevel.Verbose()
                            .ReadFrom.Configuration(a.Configuration)
                            .Enrich.FromLogContext()
                            .WriteTo.Console()
                    )
                    .ConfigureServices(x => x.AddAliquip())
                    .Build();
                _host.Start();
            }

            public ILogger<T> GetLogger<T>() => GetService<ILogger<T>>();
            public T GetService<T>() => _host.Services.GetService<T>();
            public T Instantiate<T>(params object[] extraParams)
                => ActivatorUtilities.CreateInstance<T>(GetService<IServiceProvider>(), extraParams);

            public MovableSceneObject AddPrimitive(Primitive primitive, Vector3 color)
            {
                if (color.X > 1 || color.Y > 1 || color.Z > 1)
                    color /= 255f;

                MovableSceneObject o;
                switch (primitive)
                {
                    case Primitive.Quad:
                        o = Instantiate<Quad>(color);
                        Scene3D.AddObject(o);
                        return o;
                    case Primitive.Cube:
                        o = Instantiate<Cube>(color);
                        Scene3D.AddObject(o);
                        return o;
                    case Primitive.SpiralSphere:
                        o = Instantiate<Sphere>(color, SphereType.Spiral);
                        Scene3D.AddObject(o);
                        return o;
                    case Primitive.StackedSphere:
                        o = Instantiate<Sphere>(color, SphereType.Stacked);
                        Scene3D.AddObject(o);
                        return o;
                    default:
                        throw new ArgumentException(nameof(primitive));
                }
            }

            public void Run()
            {
                var lifetime = _host.Services.GetRequiredService<IHostApplicationLifetime>();
                var window = _host.Services.GetRequiredService<IWindowProvider>().Window;
                window.VSync = true;
                window.Run
                (
                    () =>
                    {
                        window.DoEvents();
                        if (!window.IsClosing)
                        {
                            window.DoUpdate();
                            window.DoRender();
                            
                            if (lifetime.ApplicationStopping.IsCancellationRequested)
                                window.Close();
                        }
                    }
                );

                window.DoEvents();
                window.Reset();
            }
            
            public void Dispose()
            {
                _host.StopAsync().GetAwaiter().GetResult();
                _host.Dispose();
            }

            public async ValueTask DisposeAsync()
            {
                await _host.StopAsync();
                _host.Dispose();
            }
        }
    }
}
