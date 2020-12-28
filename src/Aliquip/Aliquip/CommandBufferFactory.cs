// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using Silk.NET.Vulkan;

namespace Aliquip
{
    internal sealed class CommandBufferFactory : ICommandBufferFactory
    {
        private readonly Vk _vk;
        private readonly ICommandPoolProvider _commandPoolProvider;
        private readonly ILogicalDeviceProvider _logicalDeviceProvider;

        public CommandBufferFactory(Vk vk, ICommandPoolProvider commandPoolProvider, ILogicalDeviceProvider logicalDeviceProvider)
        {
            _vk = vk;
            _commandPoolProvider = commandPoolProvider;
            _logicalDeviceProvider = logicalDeviceProvider;
        }

        public unsafe CommandBuffer[] CreateCommandBuffers(int amount, uint queueFamilyIndex, CommandBufferBeginInfo? commandBufferBeginInfo, Action<CommandBuffer, int>? record)
        {
            var commandBuffers = GC.AllocateUninitializedArray<CommandBuffer>(amount, true);

            var allocInfo = new CommandBufferAllocateInfo
            (
                commandPool: _commandPoolProvider[queueFamilyIndex], level: CommandBufferLevel.Primary,
                commandBufferCount: (uint) commandBuffers.Length
            );

            _vk.AllocateCommandBuffers(_logicalDeviceProvider.LogicalDevice, &allocInfo, commandBuffers).ThrowCode();

            if (record is not null)
            {
                commandBufferBeginInfo ??= new CommandBufferBeginInfo(sType: StructureType.CommandBufferBeginInfo);
                
                for (int i = 0; i < amount; i++)
                {
                    _vk.BeginCommandBuffer(commandBuffers[i], commandBufferBeginInfo.Value);
                    record(commandBuffers[i], i);
                    _vk.EndCommandBuffer(commandBuffers[i]);
                }
            }

            return commandBuffers;
        }

        public void FreeCommandBuffers(CommandBuffer[] commandBuffers, uint queueFamilyIndex)
        {
            _vk.FreeCommandBuffers
            (
                _logicalDeviceProvider.LogicalDevice, _commandPoolProvider[queueFamilyIndex], (uint) commandBuffers.Length, commandBuffers
            );
        }
    }
}
