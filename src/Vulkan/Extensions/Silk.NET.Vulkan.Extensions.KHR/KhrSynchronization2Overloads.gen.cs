// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.
using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Text;
using Silk.NET.Core;
using Silk.NET.Core.Native;
using Silk.NET.Core.Attributes;
using Silk.NET.Core.Contexts;
using Silk.NET.Core.Loader;

#pragma warning disable 1591

namespace Silk.NET.Vulkan.Extensions.KHR
{
    public static class KhrSynchronization2Overloads
    {
        /// <summary>To be documented.</summary>
        public static unsafe void CmdPipelineBarrier2(this KhrSynchronization2 thisApi, [Count(Count = 0)] CommandBuffer commandBuffer, [Count(Count = 0), Flow(FlowDirection.In)] ReadOnlySpan<DependencyInfoKHR> pDependencyInfo)
        {
            // SpanOverloader
            thisApi.CmdPipelineBarrier2(commandBuffer, in pDependencyInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        public static unsafe void CmdSetEvent2(this KhrSynchronization2 thisApi, [Count(Count = 0)] CommandBuffer commandBuffer, [Count(Count = 0)] Event @event, [Count(Count = 0), Flow(FlowDirection.In)] ReadOnlySpan<DependencyInfoKHR> pDependencyInfo)
        {
            // SpanOverloader
            thisApi.CmdSetEvent2(commandBuffer, @event, in pDependencyInfo.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        public static unsafe void CmdWaitEvents2(this KhrSynchronization2 thisApi, [Count(Count = 0)] CommandBuffer commandBuffer, [Count(Count = 0)] uint eventCount, [Count(Computed = "eventCount"), Flow(FlowDirection.In)] Event* pEvents, [Count(Computed = "eventCount"), Flow(FlowDirection.In)] ReadOnlySpan<DependencyInfoKHR> pDependencyInfos)
        {
            // SpanOverloader
            thisApi.CmdWaitEvents2(commandBuffer, eventCount, pEvents, in pDependencyInfos.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        public static unsafe void CmdWaitEvents2(this KhrSynchronization2 thisApi, [Count(Count = 0)] CommandBuffer commandBuffer, [Count(Count = 0)] uint eventCount, [Count(Computed = "eventCount"), Flow(FlowDirection.In)] ReadOnlySpan<Event> pEvents, [Count(Computed = "eventCount"), Flow(FlowDirection.In)] DependencyInfoKHR* pDependencyInfos)
        {
            // SpanOverloader
            thisApi.CmdWaitEvents2(commandBuffer, eventCount, in pEvents.GetPinnableReference(), pDependencyInfos);
        }

        /// <summary>To be documented.</summary>
        public static unsafe void CmdWaitEvents2(this KhrSynchronization2 thisApi, [Count(Count = 0)] CommandBuffer commandBuffer, [Count(Count = 0)] uint eventCount, [Count(Computed = "eventCount"), Flow(FlowDirection.In)] ReadOnlySpan<Event> pEvents, [Count(Computed = "eventCount"), Flow(FlowDirection.In)] ReadOnlySpan<DependencyInfoKHR> pDependencyInfos)
        {
            // SpanOverloader
            thisApi.CmdWaitEvents2(commandBuffer, eventCount, in pEvents.GetPinnableReference(), in pDependencyInfos.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        public static unsafe void GetQueueCheckpointData2(this KhrSynchronization2 thisApi, [Count(Count = 0)] Queue queue, [Count(Count = 0)] uint* pCheckpointDataCount, [Count(Computed = "pCheckpointDataCount"), Flow(FlowDirection.Out)] Span<CheckpointData2NV> pCheckpointData)
        {
            // SpanOverloader
            thisApi.GetQueueCheckpointData2(queue, pCheckpointDataCount, out pCheckpointData.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        public static unsafe void GetQueueCheckpointData2(this KhrSynchronization2 thisApi, [Count(Count = 0)] Queue queue, [Count(Count = 0)] Span<uint> pCheckpointDataCount, [Count(Computed = "pCheckpointDataCount"), Flow(FlowDirection.Out)] CheckpointData2NV* pCheckpointData)
        {
            // SpanOverloader
            thisApi.GetQueueCheckpointData2(queue, ref pCheckpointDataCount.GetPinnableReference(), pCheckpointData);
        }

        /// <summary>To be documented.</summary>
        public static unsafe void GetQueueCheckpointData2(this KhrSynchronization2 thisApi, [Count(Count = 0)] Queue queue, [Count(Count = 0)] Span<uint> pCheckpointDataCount, [Count(Computed = "pCheckpointDataCount"), Flow(FlowDirection.Out)] Span<CheckpointData2NV> pCheckpointData)
        {
            // SpanOverloader
            thisApi.GetQueueCheckpointData2(queue, ref pCheckpointDataCount.GetPinnableReference(), out pCheckpointData.GetPinnableReference());
        }

        /// <summary>To be documented.</summary>
        public static unsafe Result QueueSubmit2(this KhrSynchronization2 thisApi, [Count(Count = 0)] Queue queue, [Count(Count = 0)] uint submitCount, [Count(Computed = "submitCount"), Flow(FlowDirection.In)] ReadOnlySpan<SubmitInfo2KHR> pSubmits, [Count(Count = 0)] Fence fence)
        {
            // SpanOverloader
            return thisApi.QueueSubmit2(queue, submitCount, in pSubmits.GetPinnableReference(), fence);
        }

    }
}

