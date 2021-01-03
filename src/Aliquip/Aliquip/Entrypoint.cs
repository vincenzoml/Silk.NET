// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Runtime.InteropServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Silk.NET.Input;
using Silk.NET.Vulkan;
using Silk.NET.Vulkan.Extensions.KHR;
using Silk.NET.Windowing;
using VMASharp;

namespace Aliquip
{
    public static class Entrypoint
    {
        public static IServiceCollection AddAliquip(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddSingleton<IWindowProvider, WindowProvider>()
                .AddSingleton(provider => provider.GetRequiredService<IWindowProvider>().Window)
                .AddSingleton(provider => (IObservable<WindowResized>) provider.GetRequiredService<IWindowProvider>())
                .AddSingleton
                    (provider => (IObservable<WindowStateChanged>) provider.GetRequiredService<IWindowProvider>())
                .AddSingleton<Vk>(x => Vk.GetApi())
                .AddSingleton<IInstanceProvider, InstanceProvider>()
#if DEBUG
                .AddSingleton<IDebugMessengerProvider, DebugMessengerProvider>()
#endif
                .AddSingleton<ISurfaceProvider, SurfaceProvider>()
                .AddSingleton<IColorspaceRater, ColorSpaceRater>()
                .AddSingleton<IFormatRater, FormatRater>()
                .AddSingleton<IPhysicalDeviceProvider, PhysicalDeviceProvider>()
                .AddSingleton
                (
                    (provider) =>
                    {
                        provider.GetRequiredService<Vk>()
                            .TryGetInstanceExtension
                                (provider.GetRequiredService<IInstanceProvider>().Instance, out KhrSurface ext);
                        return ext;
                    }
                )
                .AddSingleton<ISwapchainSupportProvider, SwapchainSupportProvider>()
                .AddSingleton<IQueueFamilyProvider, QueueFamilyProvider>()
                .AddSingleton<LogicalDeviceProvider>()
                .AddSingleton(provider => (ILogicalDeviceProvider) provider.GetRequiredService<LogicalDeviceProvider>())
                .AddSingleton(provider => (IGraphicsQueueProvider) provider.GetRequiredService<LogicalDeviceProvider>())
                .AddSingleton(provider => (IPresentQueueProvider) provider.GetRequiredService<LogicalDeviceProvider>())
                .AddSingleton(provider => (ITransferQueueProvider) provider.GetRequiredService<LogicalDeviceProvider>())
                .AddSingleton
                (
                    (provider) =>
                    {
                        provider.GetRequiredService<Vk>()
                            .TryGetDeviceExtension
                            (
                                provider.GetRequiredService<IInstanceProvider>().Instance,
                                provider.GetRequiredService<ILogicalDeviceProvider>().LogicalDevice,
                                out KhrSwapchain ext
                            );
                        return ext;
                    }
                )
                .AddSingleton<ISwapchainProvider, SwapchainProvider>()
                .AddSingleton<IImageViewProvider, ImageViewProvider>()
                .AddSingleton<IRenderPassProvider, RenderPassProvider>()
                .AddSingleton<IPipelineLayoutFactory, PipelineLayoutFactory>()
                .AddSingleton<IGraphicsPipelineFactory, GraphicsPipelineFactory>()
                .AddSingleton<IFramebufferProvider, FramebufferProvider>()
                .AddSingleton<ICommandPoolProvider, CommandPoolProvider>()
                .AddHostedService<DrawFrameService>()
                .AddSingleton<IResourceProvider, ResourceProvider>()
                .AddSingleton<SwapchainRecreationService>()
                .AddSingleton(x => (ISwapchainRecreationService) x.GetRequiredService<SwapchainRecreationService>())
                .AddHostedService(x => x.GetRequiredService<SwapchainRecreationService>())
                .AddSingleton<ICommandBufferFactory, CommandBufferFactory>()
                .AddSingleton<IBufferFactory, BufferFactory>()
                .AddSingleton<IGraphicsCommandBufferProvider, GraphicsCommandBufferProvider>()
                .AddSingleton<IDescriptorSetLayoutFactory, DescriptorSetLayoutFactory>()
                .AddSingleton<IDescriptorPoolFactory, DescriptorPoolFactory>()
                .AddSingleton<IDescriptorSetFactory, DescriptorSetFactory>()
                .AddSingleton<ICameraProvider, CameraProvider>()
                .AddSingleton(x => x.GetRequiredService<IWindowProvider>().Window.CreateInput())
                .AddSingleton<ITextureFactory, TextureFactory>()
                .AddSingleton<IDepthImageProvider, DepthImageProvider>()
                .AddSingleton<IMsaaProvider, MsaaProvider>()
                .AddSingleton<ISampleShadingProvider, SampleShadingProvider>()
                .AddSingleton<IColorImageProvider, ColorImageProvider>()
                .AddSingleton<Scene3D>()
                .AddSingleton(x => (IScene) x.GetRequiredService<Scene3D>())
                .AddSingleton
                (
                    x => new VulkanMemoryAllocator
                    (
                        new VulkanMemoryAllocatorCreateInfo
                        (
                            Vk.Version12, x.GetRequiredService<Vk>(),
                            x.GetRequiredService<IInstanceProvider>().Instance,
                            x.GetRequiredService<IPhysicalDeviceProvider>().Device,
                            x.GetRequiredService<ILogicalDeviceProvider>().LogicalDevice
                        )
                    )
                )
                ;
        }
    }
}
