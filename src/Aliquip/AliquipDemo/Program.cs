using System;
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
        static async Task Main(string[] args)
        {
            using var host = Host.CreateDefaultBuilder(args)
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

            var task = host.RunAsync();
            if (task.IsFaulted)
                task.GetAwaiter().GetResult();

            var window = host.Services.GetRequiredService<IWindowProvider>().Window;
            task = task.ContinueWith((x) => window.Close());
            
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
        }
    }
}
