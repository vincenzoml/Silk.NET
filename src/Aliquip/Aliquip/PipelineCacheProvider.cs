// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Buffers.Binary;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Silk.NET.Vulkan;

namespace Aliquip
{
    internal sealed class PipelineCacheProvider : IPipelineCacheProvider, IDisposable, IHostedService
    {
        private readonly Vk _vk;
        private readonly ILogicalDeviceProvider _logicalDeviceProvider;
        public PipelineCache PipelineCache { get; }
        public bool UsePipelineCache { get; private set; }
        private readonly string? _path;
        private readonly ILogger _logger;
        private readonly IAllocationCallbacksProvider _allocationCallbacksProvider;

        public unsafe PipelineCacheProvider
        (
            IConfiguration configuration,
            Vk vk,
            ILogicalDeviceProvider logicalDeviceProvider,
            ILogger<PipelineCacheProvider> logger,
            IHostEnvironment environment,
            IPhysicalDeviceProvider physicalDeviceProvider,
            IAllocationCallbacksProvider allocationCallbacksProvider
        )
        {
            _vk = vk;
            _logicalDeviceProvider = logicalDeviceProvider;
            _logger = logger;
            _allocationCallbacksProvider = allocationCallbacksProvider;
            var section = configuration.GetSection("Pipeline Cache");
            var useStr = section["Enabled"];
            if (useStr is null || !bool.TryParse(useStr, out var useRes))
                useRes = true;
            UsePipelineCache = useRes;
            if (useRes)
            {
                _path = section["Path"];
                if (_path is not null)
                    _path = environment.ContentRootFileProvider.GetFileInfo(_path).PhysicalPath;
            }

            if (!UsePipelineCache)
                _logger.LogDebug("Not using pipeline cache");
            
            if (UsePipelineCache)
            {
                var createInfo = new PipelineCacheCreateInfo(sType: StructureType.PipelineCacheCreateInfo);
                byte[]? bytes = null;
                if (_path is not null)
                {
                    _logger.LogDebug("Using physical pipeline cache at {path}", _path);

                    if (File.Exists(_path))
                    {
                        bytes = File.ReadAllBytes(_path!);

                        // when loading, we want to verify the cache actually fits the currently selected physical device (it's vendor)
                        // this is done using the header, which looks like this:
                        // 4 bytes length (ignored)
                        // 4 bytes header version
                        // 4 bytes vendor id
                        // 4 bytes device id
                        // UUID_SIZE uuid (ignored)
                        // see https://www.khronos.org/registry/vulkan/specs/1.2/html/vkspec.html (look for vkGetPipelineCacheData)

                        var version = (PipelineCacheHeaderVersion) BinaryPrimitives.ReadInt32LittleEndian
                            (bytes.AsSpan(4, 4));
                        if (version == PipelineCacheHeaderVersion.One)
                        {
                            var vendorId = BinaryPrimitives.ReadInt32LittleEndian(bytes.AsSpan(8, 4));
                            var deviceId = BinaryPrimitives.ReadInt32LittleEndian(bytes.AsSpan(12, 4));

                            var deviceProperties = _vk.GetPhysicalDeviceProperty(physicalDeviceProvider.Device);
                            if (deviceProperties.VendorID != vendorId)
                            {
                                _logger.LogWarning("Cannot load stored pipeline cache. VendorID mismatch.");
                                bytes = null;
                            }
                            else if (deviceProperties.DeviceID != deviceId)
                            {
                                _logger.LogWarning("Cannot load stored pipeline cache. DeviceID mismatch.");
                                bytes = null;
                            }
                            else
                            {
                                _logger.LogDebug
                                (
                                    "Stored pipeline cache loaded. {vendorId} {deviceId}", vendorId switch
                                    {
                                        0x1002 => "AMD",
                                        0x1010 => "ImgTec",
                                        0x10DE => "NVIDIA",
                                        0x13B5 => "ARM",
                                        0x5143 => "Qualcomm",
                                        0x8086 => "INTEL",
                                        _ => "unknown vendor: " + vendorId
                                    }, deviceId
                                );
                            }
                        }
                        else
                        {
                            // if the version doesn't match, log a warning, skip verifying rest.
                            _logger.LogWarning("During Pipeline read: header version unknown");
                        }

                        createInfo.InitialDataSize = (nuint) (bytes?.Length ?? 0);
                    }
                }
                else
                {
                    _logger.LogDebug("Using temporary local pipeline cache");
                }

                fixed (byte* pBytes = bytes)
                {
                    createInfo.PInitialData = pBytes;
                    _vk.CreatePipelineCache
                            (_logicalDeviceProvider.LogicalDevice, createInfo, null, out var pipelineCache)
                        .ThrowCode();
                    PipelineCache = pipelineCache;
                }
            }
        }

        public unsafe void Dispose()
        {
            if (UsePipelineCache)
            {
                _vk.DestroyPipelineCache(_logicalDeviceProvider.LogicalDevice, PipelineCache, null);
                UsePipelineCache = false;
            }
        }

        public Task StartAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            if (UsePipelineCache && _path is not null)
            {
                try
                {
                    nuint dataSize = default;
                    unsafe
                    {
                        _vk.GetPipelineCacheData
                                (_logicalDeviceProvider.LogicalDevice, PipelineCache, ref dataSize, null)
                            .ThrowCode();
                    }

                    var arr = GC.AllocateUninitializedArray<byte>((int) dataSize, true);
                    unsafe
                    {
                        fixed (byte* p = arr)
                            _vk.GetPipelineCacheData
                                    (_logicalDeviceProvider.LogicalDevice, PipelineCache, ref dataSize, p)
                                .ThrowCode();
                    }

                    if (File.Exists(_path))
                        File.Delete(_path);
                    await using var fs = File.OpenWrite(_path);
                    await fs.WriteAsync(arr, 0, (int) dataSize, cancellationToken);
                    await fs.FlushAsync(cancellationToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to write pipeline cache");
                }
            }
        }
    }
}
