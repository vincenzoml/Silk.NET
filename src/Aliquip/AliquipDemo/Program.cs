using System;
using System.Threading.Tasks;
using Aliquip;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace AliquipDemo
{
    class Program
    {
        static Task Main(string[] args)
        {

            return Host.CreateDefaultBuilder(args)
                .UseSerilog((a, b) => b
                    .MinimumLevel.Verbose()
                    .MinimumLevel.Override("Vulkan.DebugMessenger", LogEventLevel.Information)
                    .MinimumLevel.Override("Vulkan.DebugMessenger.General", LogEventLevel.Warning)
                    .Enrich.FromLogContext()
                    .WriteTo.Console())
                .ConfigureServices(x => x.AddAliquip())
                .RunConsoleAsync();
        }
    }
}
