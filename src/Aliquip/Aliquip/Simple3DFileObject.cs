// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System.Numerics;
using Microsoft.Extensions.Logging;
using Silk.NET.Maths;
using Silk.NET.Vulkan;

namespace Aliquip
{
    public sealed class Simple3DFileObject : ISceneObject
    {
        public IMaterial Material { get; }
        public IModel Model { get; }
        public Matrix4x4 WorldToLocal { get; }

        public Simple3DFileObject
        (
            string fileName,
            IResourceProvider resourceProvider,
            ILoggerFactory loggerFactory,
            ITextureFactory textureFactory,
            Vk vk,
            ILogicalDeviceProvider logicalDeviceProvider,
            IAllocationCallbacksProvider allocationCallbacksProvider,
            Matrix4x4 worldToLocal
        )
        {
            WorldToLocal = worldToLocal;
            Model = Simple3DFileModel.Create(fileName, loggerFactory.CreateLogger<Simple3DFileModel>());
            Material = SimpleTextured3DMaterial.Create(textureFactory[fileName + ".png"], vk, resourceProvider, logicalDeviceProvider, allocationCallbacksProvider);
        }
    }
}
