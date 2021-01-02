// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System.Collections.Generic;
using System.Numerics;
using Silk.NET.Vulkan;

namespace Aliquip
{
    public interface IScene
    {
        IEnumerable<IMaterial> Materials { get; }
        IEnumerable<ISceneObject> Objects { get; }
        IEnumerable<IModel> Models { get; }
        bool CommandBufferNeedsRebuild { get; set; }
        int CommandBufferCount { get; set; }
        void RecordCommandBuffer(CommandBuffer commandBuffer, int index);
        void AddObject(ISceneObject sceneObject);
    }
}
