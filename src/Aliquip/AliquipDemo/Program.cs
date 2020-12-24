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
        static void Main(string[] args)
        {
            using var host = Host.CreateDefaultBuilder(args)
                .UseSerilog
                (
                    (a, b) => b.MinimumLevel.Verbose()
                        .MinimumLevel.Override("Vulkan.DebugMessenger", LogEventLevel.Information)
                        .MinimumLevel.Override("Vulkan.DebugMessenger.General", LogEventLevel.Warning)
                        .Enrich.FromLogContext()
                        .WriteTo.Console()
                        .WriteTo.File("./log.txt")
                )
                .ConfigureServices(x => x.AddAliquip())
                .UseConsoleLifetime()
                .Build();

            using var task = host.RunAsync();

            var window = host.Services.GetRequiredService<IWindowProvider>().Window;
            task.ContinueWith((x) => window.Close());
            
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
        }
    }
}
