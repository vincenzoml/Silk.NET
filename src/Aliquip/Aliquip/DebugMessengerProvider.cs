// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Silk.NET.Core;
using Silk.NET.Core.Native;
using Silk.NET.Vulkan;
using Silk.NET.Vulkan.Extensions.EXT;

namespace Aliquip
{
    #if DEBUG
    internal sealed class DebugMessengerProvider : IDebugMessengerProvider, IDisposable
    {
        public unsafe DebugUtilsMessengerCreateInfoEXT CreateInfo
            => new DebugUtilsMessengerCreateInfoEXT
            (
                messageSeverity: DebugUtilsMessageSeverityFlagsEXT.DebugUtilsMessageSeverityVerboseBitExt |
                                 DebugUtilsMessageSeverityFlagsEXT.DebugUtilsMessageSeverityInfoBitExt |
                                 DebugUtilsMessageSeverityFlagsEXT.DebugUtilsMessageSeverityWarningBitExt |
                                 DebugUtilsMessageSeverityFlagsEXT.DebugUtilsMessageSeverityErrorBitExt,
                messageType: DebugUtilsMessageTypeFlagsEXT.DebugUtilsMessageTypeGeneralBitExt |
                             DebugUtilsMessageTypeFlagsEXT.DebugUtilsMessageTypeValidationBitExt |
                             DebugUtilsMessageTypeFlagsEXT.DebugUtilsMessageTypePerformanceBitExt,
                pfnUserCallback: new PfnDebugUtilsMessengerCallbackEXT(Callback)
            );
        private readonly Vk _vk;
        private readonly IAllocationCallbacksProvider _allocationCallbacksProvider;
        private readonly ILogger _generalLogger;
        private readonly ILogger _validationLogger;
        private readonly ILogger _performanceLogger;
        private ExtDebugUtils? _debugUtils;
        private DebugUtilsMessengerEXT _messenger;
        private Instance _instance;

        private unsafe uint Callback(DebugUtilsMessageSeverityFlagsEXT severity, DebugUtilsMessageTypeFlagsEXT type, DebugUtilsMessengerCallbackDataEXT* pData, void* pUserData)
        {
            var logger = type switch
            {
                DebugUtilsMessageTypeFlagsEXT.DebugUtilsMessageTypePerformanceBitExt => _performanceLogger,
                DebugUtilsMessageTypeFlagsEXT.DebugUtilsMessageTypeValidationBitExt => _validationLogger,
                _ => _generalLogger
            };

            var str = SilkMarshal.PtrToString((IntPtr) pData->PMessage);
            
            switch (severity)
            {
                case DebugUtilsMessageSeverityFlagsEXT.DebugUtilsMessageSeverityErrorBitExt:
                    logger.LogError(str);
                    break;
                case DebugUtilsMessageSeverityFlagsEXT.DebugUtilsMessageSeverityWarningBitExt:
                    logger.LogWarning(str);
                    break;
                case DebugUtilsMessageSeverityFlagsEXT.DebugUtilsMessageSeverityInfoBitExt:
                    logger.LogInformation(str);
                    break;
                case DebugUtilsMessageSeverityFlagsEXT.DebugUtilsMessageSeverityVerboseBitExt:
                    logger.LogDebug(str);
                    break;
            }
            
            return Vk.False;
        }

        public DebugMessengerProvider(Vk vk, ILoggerFactory loggerFactory, IAllocationCallbacksProvider allocationCallbacksProvider)
        {
            _generalLogger = loggerFactory.CreateLogger("Vulkan.DebugMessenger.General");
            _validationLogger = loggerFactory.CreateLogger("Vulkan.DebugMessenger.Validation");
            _performanceLogger = loggerFactory.CreateLogger("Vulkan.DebugMessenger.Performance");
            _vk = vk;
            _allocationCallbacksProvider = allocationCallbacksProvider;
        }

        public unsafe void Attach(Instance instance)
        {
            if (!_vk.TryGetInstanceExtension(instance, out _debugUtils))
                return;

            _instance = instance;
            _debugUtils!.CreateDebugUtilsMessenger(_instance, CreateInfo, null, out _messenger).ThrowCode();
        }

        public unsafe void Dispose()
        {
            if (_debugUtils is not null)
            {
                _debugUtils.DestroyDebugUtilsMessenger(_instance, _messenger, null);
                _debugUtils.Dispose();
            }
        }
    }
    #endif
}
