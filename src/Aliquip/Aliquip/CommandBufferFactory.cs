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

        public unsafe void RunSingleTime(uint queueFamilyIndex, Queue queueFamily, Action<CommandBuffer> record)
        {

            var cbs = CreateCommandBuffers
            (
                1, queueFamilyIndex,
                new CommandBufferBeginInfo(flags: CommandBufferUsageFlags.CommandBufferUsageOneTimeSubmitBit),
                CommandBufferLevel.Primary,
                (commandBuffer, _) => record(commandBuffer)
            );

            var c = cbs[0];
            var submitInfo = new SubmitInfo(commandBufferCount: 1, pCommandBuffers: &c);
            _vk.QueueSubmit(queueFamily, 1, submitInfo, default).ThrowCode();
            _vk.QueueWaitIdle(queueFamily).ThrowCode(); // TODO: run in background (async/await? :eyes:)
            
            FreeCommandBuffers(cbs, queueFamilyIndex);
        }

        public unsafe CommandBuffer[] CreateCommandBuffers
        (
            int amount,
            uint queueFamilyIndex,
            CommandBufferBeginInfo? commandBufferBeginInfo,
            CommandBufferLevel level,
            Action<CommandBuffer, int> record 
        )
        {
            var commandBuffers = GC.AllocateUninitializedArray<CommandBuffer>(amount, true);

            var allocInfo = new CommandBufferAllocateInfo
            (
                commandPool: _commandPoolProvider[queueFamilyIndex], level: level,
                commandBufferCount: (uint) commandBuffers.Length
            );

            fixed (CommandBuffer* pCommandBuffers = commandBuffers)
            {
                _vk.AllocateCommandBuffers
                        (_logicalDeviceProvider.LogicalDevice, &allocInfo, pCommandBuffers)
                    .ThrowCode();
            }

            if (record is not null)
            {
                commandBufferBeginInfo ??= new CommandBufferBeginInfo(sType: StructureType.CommandBufferBeginInfo);
                
                for (int i = 0; i < amount; i++)
                {
                    _vk.BeginCommandBuffer(commandBuffers[i], commandBufferBeginInfo.Value).ThrowCode();
                    record(commandBuffers[i], i);
                    _vk.EndCommandBuffer(commandBuffers[i]).ThrowCode();
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
