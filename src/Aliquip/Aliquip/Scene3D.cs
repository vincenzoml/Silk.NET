// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Extensions.Logging;
using Silk.NET.Maths;
using Silk.NET.Vulkan;
using Silk.NET.Windowing;
using VMASharp;
using Buffer = Silk.NET.Vulkan.Buffer;

namespace Aliquip
{
    public sealed class Scene3D : IScene, IDisposable
    {
        [StructLayout(LayoutKind.Explicit)]
        private struct UniformBufferObject
        {
            [FieldOffset(0)]
            public Matrix4x4 Model;
            [FieldOffset(64)]
            public Matrix4x4 View;

            public UniformBufferObject(Matrix4x4 model, Matrix4x4 view)
            {
                Model = model;
                View = view;
            }
        }
        
        private readonly struct ModelBuffer
        {
            public readonly Buffer Buffer;
            public readonly Allocation Allocation;
            public readonly ulong VertexOffset;
            public readonly ulong IndexOffset;

            public ModelBuffer(Buffer buffer, Allocation allocation, ulong vertexOffset, ulong indexOffset)
            {
                Buffer = buffer;
                Allocation = allocation;
                VertexOffset = vertexOffset;
                IndexOffset = indexOffset;
            }
        }

        private sealed class MaterialInfo
        {
            public List<ISceneObject> Objects { get; } = new();
            public PipelineLayout PipelineLayout { get; }
            public Pipeline GraphicsPipeline { get; }
            public DescriptorSetLayout DescriptorSetLayout { get; }
            public DescriptorPool? DescriptorPool { get; } // result of optimization

            public MaterialInfo
            (
                PipelineLayout pipelineLayout,
                Pipeline graphicsPipeline,
                DescriptorSetLayout descriptorSetLayout,
                DescriptorPool? descriptorPool
            )
            {
                PipelineLayout = pipelineLayout;
                GraphicsPipeline = graphicsPipeline;
                DescriptorSetLayout = descriptorSetLayout;
                DescriptorPool = descriptorPool;
            }
        }
        
        private sealed class SceneObjectInfo
        {
            public Buffer[] UboBuffers { get; }
            public Allocation[] UboAllocations { get; }
            public MappedMemoryRange[] UboRanges { get; }
            public DescriptorSet[] DescriptorSets { get; }
            public DescriptorPool DescriptorPool { get; }
            public bool OwnDescriptorPool { get; }

            public SceneObjectInfo(Buffer[] uboBuffers, Allocation[] uboAllocations, MappedMemoryRange[] uboRanges, DescriptorSet[] descriptorSets, DescriptorPool descriptorPool, bool ownDescriptorPool)
            {
                UboBuffers = uboBuffers;
                UboAllocations = uboAllocations;
                UboRanges = uboRanges;
                DescriptorSets = descriptorSets;
                DescriptorPool = descriptorPool;
                OwnDescriptorPool = ownDescriptorPool;
            }
        }
        
        public IEnumerable<IMaterial> Materials => _materialInfos.Keys;
        public IEnumerable<ISceneObject> Objects => _objectInfos.Keys;
        public IEnumerable<IModel> Models => _modelBuffers.Keys;
        public bool CommandBufferNeedsRebuild { get; set; }

        public int CommandBufferCount
        {
            get => _commandBufferCount;
            set
            {
                if (value != _commandBufferCount)
                {
                    _commandBufferCount = value;
                    OnCommandBufferCountChange();
                }
            }
        }

        private readonly Vk _vk;
        private readonly IBufferFactory _bufferFactory;
        private readonly ICommandBufferFactory _commandBufferFactory;
        private readonly ITransferQueueProvider _transferQueueProvider;
        private readonly IGraphicsQueueProvider _graphicsQueueProvider;
        private readonly ILogicalDeviceProvider _logicalDeviceProvider;
        private readonly IGraphicsPipelineFactory _graphicsPipelineFactory;
        private readonly ICameraProvider _cameraProvider;
        private readonly IDescriptorSetLayoutFactory _descriptorSetLayoutFactory;
        private readonly IDescriptorSetFactory _descriptorSetFactory;
        private readonly IPipelineLayoutFactory _pipelineLayoutFactory;
        private readonly IDescriptorPoolFactory _descriptorPoolFactory;
        private readonly IWindowProvider _windowProvider;
        private readonly ILogger _logger;
        private readonly VulkanMemoryAllocator _vma;
        private readonly IAllocationCallbacksProvider _allocationCallbacksProvider;
        private Dictionary<IMaterial, MaterialInfo> _materialInfos = new();
        private Dictionary<IModel, ModelBuffer> _modelBuffers = new();
        private Dictionary<ISceneObject, SceneObjectInfo> _objectInfos = new();
        private ReaderWriterLockSlim _infoLock = new();
        private int _commandBufferCount;

        public Scene3D
        (
            Vk vk,
            IBufferFactory bufferFactory,
            ICommandBufferFactory commandBufferFactory,
            ITransferQueueProvider transferQueueProvider,
            IGraphicsQueueProvider graphicsQueueProvider,
            ILogicalDeviceProvider logicalDeviceProvider,
            IGraphicsPipelineFactory graphicsPipelineFactory,
            ICameraProvider cameraProvider,
            IDescriptorSetLayoutFactory descriptorSetLayoutFactory,
            IDescriptorSetFactory descriptorSetFactory,
            IPipelineLayoutFactory pipelineLayoutFactory,
            IDescriptorPoolFactory descriptorPoolFactory,
            IWindowProvider windowProvider,
            ILogger<Scene3D> logger,
            VulkanMemoryAllocator vma,
            IAllocationCallbacksProvider allocationCallbacksProvider
        )
        {
            _vk = vk;
            _bufferFactory = bufferFactory;
            _commandBufferFactory = commandBufferFactory;
            _transferQueueProvider = transferQueueProvider;
            _graphicsQueueProvider = graphicsQueueProvider;
            _logicalDeviceProvider = logicalDeviceProvider;
            _graphicsPipelineFactory = graphicsPipelineFactory;
            _cameraProvider = cameraProvider;
            _descriptorSetLayoutFactory = descriptorSetLayoutFactory;
            _descriptorSetFactory = descriptorSetFactory;
            _pipelineLayoutFactory = pipelineLayoutFactory;
            _descriptorPoolFactory = descriptorPoolFactory;
            _windowProvider = windowProvider;
            _logger = logger;
            _vma = vma;
            _allocationCallbacksProvider = allocationCallbacksProvider;
            CommandBufferNeedsRebuild = true;
        }

        public unsafe void RecordCommandBuffer(CommandBuffer commandBuffer, int index)
        {
            foreach (var (material, materialInfo) in _materialInfos)
            {
                _vk.CmdBindPipeline(commandBuffer, PipelineBindPoint.Graphics, materialInfo.GraphicsPipeline);

                foreach (var sceneObject in materialInfo.Objects)
                {
                    var objectInfo = _objectInfos[sceneObject];
                    
                    var model = sceneObject.Model;
                    var modelBuffer = _modelBuffers[model];
                    var vertexBuffers = stackalloc[] {modelBuffer.Buffer};
                    var offsets = stackalloc[] {modelBuffer.VertexOffset};
                    _vk.CmdBindVertexBuffers(commandBuffer, 0, 1, vertexBuffers, offsets);
                    _vk.CmdBindIndexBuffer(commandBuffer, modelBuffer.Buffer, modelBuffer.IndexOffset, IndexType.Uint32);

                    var cameraProjection = _cameraProvider.ProjectionMatrix;
                    // Vulkan has the inverse Y
                    cameraProjection.M22 *= -1;
                    _vk.CmdPushConstants
                    (
                        commandBuffer, materialInfo.PipelineLayout, ShaderStageFlags.ShaderStageVertexBit, 0,
                        (uint) sizeof(Matrix4x4), ref cameraProjection
                    );

                    var descriptorSet = objectInfo.DescriptorSets[index];
                    _vk.CmdBindDescriptorSets
                    (
                        commandBuffer, PipelineBindPoint.Graphics, materialInfo.PipelineLayout, 0,
                        1, &descriptorSet, 0, default(uint*)
                    );

                    _vk.CmdDrawIndexed(commandBuffer, (uint) model.IndexCount, 1, 0, 0, 0);
                }
            }
        }

        public unsafe void OnFrameComplete(uint index)
        {
            // TODO: THIS IS A HUUUUUGE GC ISSUE
            var arr = GC.AllocateUninitializedArray<MappedMemoryRange>(_objectInfos.Count, true);
            int i = 0;
            foreach (var (sceneObject, info) in _objectInfos)
            {
                arr[i++] = UpdateUbo(sceneObject, info, index);
            }
            fixed(MappedMemoryRange* ranges = arr)
                _vk.FlushMappedMemoryRanges(_logicalDeviceProvider.LogicalDevice, (uint) arr.Length, ranges).ThrowCode();
        }

        private unsafe MappedMemoryRange UpdateUbo(ISceneObject sceneObject, SceneObjectInfo info, uint index)
        {
            var ubo = new UniformBufferObject
            (
                model: sceneObject.WorldToLocal, // Matrix4x4.Identity, // Matrix4x4.CreateRotationZ((float) ((timeDiff.TotalMilliseconds / 10) * MathF.PI / 180f)),
                view: _cameraProvider.ViewMatrix
            );

            var data = info.UboAllocations[index].MappedData.ToPointer();
            var range = info.UboRanges[index];
            *(UniformBufferObject*) (byte*) data = ubo;
            return range;
        }

        public unsafe void AddObject(ISceneObject sceneObject)
        {
            _infoLock.EnterWriteLock();
            try
            {
                if (_objectInfos.ContainsKey(sceneObject))
                    throw new ArgumentException("Cannot add scene object twice");

                if (_materialInfos.TryGetValue(sceneObject.Material, out var materialInfo))
                    materialInfo.Objects.Add(sceneObject);
                else
                {
                    BuildMaterialInfo(sceneObject.Material);
                    _materialInfos[sceneObject.Material].Objects.Add(sceneObject);
                }

                if (!_modelBuffers.ContainsKey(sceneObject.Model))
                {
                    BuildBuffer(sceneObject.Model);
                }
                
                BuildObjectInfo(sceneObject);

                UpdateDescriptorSet(sceneObject);

                var info = _objectInfos[sceneObject];
                var ubo = new UniformBufferObject
                (
                    // model: sceneObject.WorldToLocal, // Matrix4x4.Identity, // Matrix4x4.CreateRotationZ((float) ((timeDiff.TotalMilliseconds / 10) * MathF.PI / 180f)),
                    model: Matrix4x4.Identity, view: _cameraProvider.ViewMatrix
                );

                for (int i = 0; i < CommandBufferCount; i++)
                {
                    var data = info.UboAllocations[i].MappedData.ToPointer();
                    *(UniformBufferObject*) (byte*) data = ubo;
                }

                fixed (MappedMemoryRange* ranges = info.UboRanges)
                    _vk.FlushMappedMemoryRanges
                            (_logicalDeviceProvider.LogicalDevice, (uint) CommandBufferCount, ranges)
                        .ThrowCode();
            }
            finally
            {
                _infoLock.ExitWriteLock();
            }
        }

        private unsafe void OnCommandBufferCountChange()
        {
            _infoLock.EnterWriteLock();
            try
            {
                var objects = _objectInfos.Keys.ToArray();

                foreach (var o in objects)
                {
                    DisposeObjectInfo(o);
                }

                foreach (var o in objects)
                {
                    BuildObjectInfo(o);
                    UpdateDescriptorSet(o);
                }
            }
            finally
            {
                _infoLock.ExitWriteLock();
            }
        }

        private unsafe void DisposeObjectInfo(ISceneObject sceneObject)
        {
            var info = _objectInfos[sceneObject];
            for (int i = 0; i < info.UboAllocations.Length; i++)
            {
                _vk.DestroyBuffer(_logicalDeviceProvider.LogicalDevice, info.UboBuffers[i], null);
                _vma.FreeMemory(info.UboAllocations[i]);
            }
            
            if (info.OwnDescriptorPool)
                _vk.DestroyDescriptorPool(_logicalDeviceProvider.LogicalDevice, info.DescriptorPool, null);
        }

        private unsafe void BuildObjectInfo(ISceneObject sceneObject)
        {
            var material = sceneObject.Material;
            DescriptorPool CreateDescriptorPool()
            {
                var v = material.DescriptorPoolSizes.ToArray();
                for (int i = 0; i < v.Length; i++)
                {
                    v[i].DescriptorCount = (uint) CommandBufferCount;
                }

                return _descriptorPoolFactory.CreateDescriptorPool(v);
            }

            var descriptorPool = CreateDescriptorPool();
            
            DescriptorSet[] CreateDescriptorSets()
                => _descriptorSetFactory.CreateDescriptorSets(descriptorPool, CommandBufferCount, _materialInfos[sceneObject.Material].DescriptorSetLayout);
            
            (Buffer[] UniformBuffers, Allocation[] UniformBufferAllocations, MappedMemoryRange[] Ranges) CreateUniformBuffers()
            {
                var uniformBuffers = new Buffer[CommandBufferCount];
                var uniformBufferAllocations = new Allocation[CommandBufferCount];
                var ranges = new MappedMemoryRange[CommandBufferCount];
                for (int i = 0; i < CommandBufferCount; i++)
                {
                    (uniformBuffers[i], uniformBufferAllocations[i]) = _bufferFactory.CreateBuffer
                    (
                        (ulong) sizeof(UniformBufferObject),
                        new AllocationCreateInfo(AllocationCreateFlags.Mapped, usage: MemoryUsage.CPU_To_GPU),
                        BufferUsageFlags.BufferUsageUniformBufferBit,
                        stackalloc[] {_graphicsQueueProvider.GraphicsQueueIndex}
                    );
                    ranges[i] = new MappedMemoryRange
                    (
                        memory: uniformBufferAllocations[i].DeviceMemory, offset: (ulong)uniformBufferAllocations[i].Offset,
                        size: (ulong) sizeof(UniformBufferObject)
                    );
                }

                return (uniformBuffers, uniformBufferAllocations, ranges);
            }

            var uniformBuffers = CreateUniformBuffers();
            
            _objectInfos[sceneObject] = new SceneObjectInfo(uniformBuffers.UniformBuffers, uniformBuffers.UniformBufferAllocations, uniformBuffers.Ranges, CreateDescriptorSets(), descriptorPool, true);
        }

        private unsafe void UpdateDescriptorSet(ISceneObject sceneObject)
        {
            var objectInfo = _objectInfos[sceneObject];
            var wds = sceneObject.Material.WriteDescriptorSets.ToArray();
            Span<WriteDescriptorSet> writeDescriptorSets = new WriteDescriptorSet[wds.Length + 1];
            for (int i = 0; i < CommandBufferCount; i++)
            {

                var bufferInfo = new DescriptorBufferInfo
                    (objectInfo.UboBuffers[i], 0, (ulong) sizeof(UniformBufferObject));

                int j = 0;
                writeDescriptorSets[j++] = (new WriteDescriptorSet(dstBinding: 0, dstArrayElement: 0, descriptorType: DescriptorType.UniformBuffer,
                    descriptorCount: 1, dstSet: objectInfo.DescriptorSets[i], pBufferInfo: &bufferInfo));

                foreach (var (descriptorSet, a, b, c) in wds)
                {
                    var res = descriptorSet;
                    if (a.HasValue)
                    {
                        var v = a.Value;
                        res.PImageInfo = &v;
                    }
                    
                    if (b.HasValue)
                    {
                        var v = b.Value;
                        res.PBufferInfo = &v;
                    }
                    
                    if (c.HasValue)
                    {
                        var v = c.Value;
                        res.PTexelBufferView = &v;
                    }

                    res.DstSet = objectInfo.DescriptorSets[i];

                    writeDescriptorSets[j++] = (res);
                }
                
                fixed(WriteDescriptorSet* p = writeDescriptorSets) 
                    _vk.UpdateDescriptorSets
                    (_logicalDeviceProvider.LogicalDevice, (uint) writeDescriptorSets.Length, p, 0, null);
            }
        }

        private unsafe void CopyDataToBufferViaStaging<T>(ReadOnlySpan<T> src, Buffer dstBuffer, ulong dstOffset) where T : unmanaged
        {
            var bufferSize = (ulong)(sizeof(T) * src.Length);
            
            var (stagingBuffer, stagingBufferAllocation) = _bufferFactory.CreateBuffer
            (
                bufferSize, new AllocationCreateInfo(AllocationCreateFlags.Mapped, usage: MemoryUsage.CPU_Only), BufferUsageFlags.BufferUsageTransferSrcBit,
                stackalloc[] {_transferQueueProvider.TransferQueueIndex, _graphicsQueueProvider.GraphicsQueueIndex}
            );

            void* data = stagingBufferAllocation.MappedData.ToPointer();
            var span = new Span<T>(data, src.Length);
            src.CopyTo(span);

            _commandBufferFactory.RunSingleTime(_transferQueueProvider.TransferQueueIndex, _transferQueueProvider.TransferQueue,
                (commandBuffer) =>
                {
                    var region = new BufferCopy((ulong) stagingBufferAllocation.Offset, dstOffset, bufferSize);
                    _vk.CmdCopyBuffer(commandBuffer, stagingBuffer, dstBuffer, 1, &region);   
                });

            _vma.FreeMemory(stagingBufferAllocation);
        }
        
        private void BuildBuffer(IModel model)
        {
            // TODO: split this allocation, now that we have proper VMA
            var (buffer, bufferAllocation) = _bufferFactory.CreateBuffer
            (
                (ulong) (model.VertexSize * model.VertexCount + sizeof(uint) * model.IndexCount),
                new AllocationCreateInfo(usage: MemoryUsage.GPU_Only),BufferUsageFlags.BufferUsageIndexBufferBit | BufferUsageFlags.BufferUsageVertexBufferBit | BufferUsageFlags.BufferUsageTransferDstBit,
                stackalloc uint[] {_graphicsQueueProvider.GraphicsQueueIndex, _transferQueueProvider.TransferQueueIndex}
            );

            var vertexOffset = (ulong) 0;
            var indexOffset = (ulong) (model.VertexSize * model.VertexCount);
            
            CopyDataToBufferViaStaging(model.Vertices, buffer, vertexOffset);
            CopyDataToBufferViaStaging(model.Indices, buffer, indexOffset);

            _modelBuffers[model] = new ModelBuffer(buffer, bufferAllocation, vertexOffset, indexOffset);
        }

        private unsafe void BuildMaterialInfo(IMaterial material)
        {
            DescriptorSetLayout CreateDescriptorSetLayout()
                => _descriptorSetLayoutFactory.CreateDescriptorSetLayout(material.DescriptorSetLayoutBindings);
            var descriptorLayout = CreateDescriptorSetLayout();

            PipelineLayout CreatePipelineLayout()
                => _pipelineLayoutFactory.CreatePipelineLayout(descriptorLayout, material.PushConstantRanges);

            var pipelineLayout = CreatePipelineLayout();
            
            Pipeline CreateGraphicsPipeline()
                => _graphicsPipelineFactory.CreatePipeline
                (
                    pipelineLayout,
                    material.VertexShader, material.VertexInputAttributeDescriptions,
                    material.VertexInputBindingDescription, material.FragmentShader
                );
            
            _materialInfos[material] = new MaterialInfo
                (pipelineLayout, CreateGraphicsPipeline(), descriptorLayout, null);
            CommandBufferNeedsRebuild = true;
        }

        public unsafe void Optimise()
        {
            var v1 = _materialInfos
                .Select(x => (x.Key, x.Value.Objects));
            var v2 = v1
                .SelectMany(x => x.Key.DescriptorPoolSizes.Select(x2 => (x2.Type, x.Objects)))
                .SelectMany(x => x.Objects.Select(x2 => (x.Type, x2)));
            var v3 = v2
                .GroupBy(x => x.Type);
            var v4 = v3
                .Select(x => new DescriptorPoolSize(x.Key, (uint) (x.Count() * CommandBufferCount)))
                .ToArray();

            var pool = _descriptorPoolFactory.CreateDescriptorPool(v4);
            
            foreach (var (material, materialInfo) in _materialInfos)
            {
                if (materialInfo is null)
                    continue;
                
                DescriptorSet[] CreateDescriptorSets()
                    => _descriptorSetFactory.CreateDescriptorSets(pool, CommandBufferCount, materialInfo.DescriptorSetLayout);
                
                foreach (var obj in materialInfo.Objects)
                {
                    var objInfo = _objectInfos[obj];

                    if (objInfo.OwnDescriptorPool)
                        _vk.DestroyDescriptorPool(_logicalDeviceProvider.LogicalDevice, objInfo.DescriptorPool, null);

                    _objectInfos[obj] = new SceneObjectInfo
                    (
                        objInfo.UboBuffers, objInfo.UboAllocations, objInfo.UboRanges, CreateDescriptorSets(), pool,
                        false
                    );
                    UpdateDescriptorSet(obj);
                }
            }
        }

        private unsafe void DisposeMaterial(MaterialInfo material)
        {
            foreach (var obj in material.Objects)
            {
                DisposeObjectInfo(obj);
            }

            if (material.DescriptorPool.HasValue)
                _vk.DestroyDescriptorPool(_logicalDeviceProvider.LogicalDevice, material.DescriptorPool.Value, null);
            _vk.DestroyPipeline(_logicalDeviceProvider.LogicalDevice, material.GraphicsPipeline, null);
            _vk.DestroyPipelineLayout(_logicalDeviceProvider.LogicalDevice, material.PipelineLayout, null);
            _vk.DestroyDescriptorSetLayout(_logicalDeviceProvider.LogicalDevice, material.DescriptorSetLayout, null);
        }

        public unsafe void Dispose()
        {
            foreach (var (_, info) in _materialInfos)
                DisposeMaterial(info);
            _materialInfos.Clear();
            
            foreach (var modelBuffer in _modelBuffers.Values)
            {
                _vk.DestroyBuffer(_logicalDeviceProvider.LogicalDevice, modelBuffer.Buffer, null);
                _vma.FreeMemory(modelBuffer.Allocation);
            }
            _modelBuffers.Clear();
            _infoLock.Dispose();
        }
    }
}
