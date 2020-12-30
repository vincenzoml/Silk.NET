using System;
using System.Threading;
using System.Threading.Tasks;
using Aliquip;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Silk.NET.Windowing;

namespace AliquipDemo
{
    class Program
    {
        static async Task RunAsync(IHost host, CancellationToken token = default)
        {

            await host.StartAsync(token).ConfigureAwait(false);

            await host.WaitForShutdownAsync(token).ConfigureAwait(false);

            if (host is IAsyncDisposable asyncDisposable)
            {
                await asyncDisposable.DisposeAsync().ConfigureAwait(false);
            }
            else
            {
                host.Dispose();
            }
        }

        static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .UseSerilog
                (
                    (a, b) => b
                        .MinimumLevel.Verbose()
                        .ReadFrom.Configuration(a.Configuration)
                        .Enrich.FromLogContext()
                        .WriteTo.Console()
                        .WriteTo.File("./log.txt")
                )
                .ConfigureServices(x => x.AddAliquip())
                .UseConsoleLifetime()
                .Build();

            var task = RunAsync(host);
            if (task.IsFaulted)
            {
                task.GetAwaiter().GetResult();   
            }

            var window = host.Services.GetRequiredService<IWindowProvider>().Window;
            task = task.ContinueWith((x) => window.Close());

            window.UpdatesPerSecond = Double.MaxValue;
            window.FramesPerSecond = Double.MaxValue;
            window.Run
            (
                () =>
                {
                    window.DoEvents();
                    if (!window.IsClosing)
                    {
                        window.DoUpdate();
                        window.DoRender();
                    }
                }
            );

            window.DoEvents();
            window.Reset();

            await host.StopAsync();
            await task;
            host.Dispose(); // don't use using, we don't want to swallow exceptions
        }
    }
}
