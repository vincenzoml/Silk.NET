using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
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

            public void Run()
            {
                var lifetime = _host.Services.GetRequiredService<IHostApplicationLifetime>();
                var window = _host.Services.GetRequiredService<IWindowProvider>().Window;
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
