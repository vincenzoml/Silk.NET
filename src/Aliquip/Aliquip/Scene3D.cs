// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
            public Matrix4X4<float> Model;
            [FieldOffset(64)]
            public Matrix4X4<float> View;

            public UniformBufferObject(Matrix4X4<float> model, Matrix4X4<float> view)
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
            public DescriptorPool DescriptorPool { get; set; }
            public List<ISceneObject> Objects { get; } = new();
            public PipelineLayout PipelineLayout { get; }
            public Pipeline GraphicsPipeline { get; }
            public DescriptorSetLayout DescriptorSetLayout { get; }

            public MaterialInfo
            (
                PipelineLayout pipelineLayout,
                Pipeline graphicsPipeline,
                DescriptorSetLayout descriptorSetLayout,
                DescriptorPool descriptorPool
            )
            {
                DescriptorPool = descriptorPool;
                PipelineLayout = pipelineLayout;
                GraphicsPipeline = graphicsPipeline;
                DescriptorSetLayout = descriptorSetLayout;
            }
        }
        
        private sealed class SceneObjectInfo
        {
            public Buffer[] Buffers { get; }
            public Allocation[] Allocations { get; }
            public MappedMemoryRange[] Ranges { get; }
            public DescriptorSet[] DescriptorSets { get; }

            public SceneObjectInfo(Buffer[] buffers, Allocation[] allocations, MappedMemoryRange[] ranges, DescriptorSet[] descriptorSets)
            {
                Buffers = buffers;
                Allocations = allocations;
                Ranges = ranges;
                DescriptorSets = descriptorSets;
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
        private Dictionary<IMaterial, MaterialInfo> _materialInfos = new();
        private Dictionary<IModel, ModelBuffer> _modelBuffers = new();
        private Dictionary<ISceneObject, SceneObjectInfo> _objectInfos = new();
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
            VulkanMemoryAllocator vma
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
                        (uint) sizeof(Matrix4X4<float>), ref cameraProjection
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
                model: sceneObject
                    .WorldToLocal, // Matrix4X4<float>.Identity, // Matrix4X4.CreateRotationZ((float) ((timeDiff.TotalMilliseconds / 10) * MathF.PI / 180f)),
                view: _cameraProvider.ViewMatrix
            );

            var data = info.Allocations[index].MappedData.ToPointer();
            var range = info.Ranges[index];
            *(UniformBufferObject*) (byte*) data = ubo;
            return range;
        }

        public unsafe void AddObject(ISceneObject sceneObject)
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
                // model: sceneObject.WorldToLocal, // Matrix4X4<float>.Identity, // Matrix4X4.CreateRotationZ((float) ((timeDiff.TotalMilliseconds / 10) * MathF.PI / 180f)),
                model: Matrix4X4<float>.Identity,
                view: _cameraProvider.ViewMatrix
            );

            for (int i = 0; i < CommandBufferCount; i++)
            {
                var data = info.Allocations[i].MappedData.ToPointer();
                *(UniformBufferObject*) (byte*) data = ubo;
            }
            
            fixed(MappedMemoryRange* ranges = info.Ranges)
                _vk.FlushMappedMemoryRanges(_logicalDeviceProvider.LogicalDevice, (uint) CommandBufferCount, ranges).ThrowCode();
        }
        
        private unsafe void OnCommandBufferCountChange()
        {
            var objects = _objectInfos.Keys.ToArray();
            
            foreach (var o in objects)
            {
                DisposeObjectInfo(o);
            }

            foreach (var (m, info) in _materialInfos)
            {
                _vk.DestroyDescriptorPool(_logicalDeviceProvider.LogicalDevice, info.DescriptorPool, null);
                var v = m.DescriptorPoolSizes.ToArray();
                for (int i = 0; i < v.Length; i++)
                {
                    v[i].DescriptorCount = (uint) CommandBufferCount;
                }

                info.DescriptorPool = _descriptorPoolFactory.CreateDescriptorPool(v);
            }

            foreach (var o in objects)
            {
                BuildObjectInfo(o);
                UpdateDescriptorSet(o);
            }
        }

        private unsafe void DisposeObjectInfo(ISceneObject sceneObject)
        {
            var info = _objectInfos[sceneObject];
            for (int i = 0; i < info.Allocations.Length; i++)
            {
                _vk.DestroyBuffer(_logicalDeviceProvider.LogicalDevice, info.Buffers[i], null);
                _vma.FreeMemory(info.Allocations[i]);
            }

            fixed (DescriptorSet* p = info.DescriptorSets)
                _vk.FreeDescriptorSets
                (
                    _logicalDeviceProvider.LogicalDevice, _materialInfos[sceneObject.Material].DescriptorPool,
                    (uint) info.DescriptorSets.Length,
                    p
                ).ThrowCode();
        }

        private unsafe void BuildObjectInfo(ISceneObject sceneObject)
        {
            DescriptorSet[] CreateDescriptorSet()
                => _descriptorSetFactory.CreateDescriptorSets(_materialInfos[sceneObject.Material].DescriptorPool, CommandBufferCount, _materialInfos[sceneObject.Material].DescriptorSetLayout);
            
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
                        size: (ulong) uniformBufferAllocations[i].Offset
                    );
                }

                return (uniformBuffers, uniformBufferAllocations, ranges);
            }

            var uniformBuffers = CreateUniformBuffers();
            
            _objectInfos[sceneObject] = new SceneObjectInfo(uniformBuffers.UniformBuffers, uniformBuffers.UniformBufferAllocations, uniformBuffers.Ranges, CreateDescriptorSet());
        }

        private unsafe void UpdateDescriptorSet(ISceneObject sceneObject)
        {
            var objectInfo = _objectInfos[sceneObject];
            for (int i = 0; i < CommandBufferCount; i++)
            {
                var writeDescriptorSetList = new List<WriteDescriptorSet>();
                
                var bufferInfo = new DescriptorBufferInfo
                    (objectInfo.Buffers[i], (ulong) objectInfo.Allocations[i].Offset, (ulong) sizeof(UniformBufferObject));

                writeDescriptorSetList.Add(new WriteDescriptorSet(dstBinding: 0, dstArrayElement: 0, descriptorType: DescriptorType.UniformBuffer,
                    descriptorCount: 1, dstSet: objectInfo.DescriptorSets[i], pBufferInfo: &bufferInfo));

                foreach (var (descriptorSet, a, b, c) in sceneObject.Material.WriteDescriptorSets)
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

                    writeDescriptorSetList.Add(res);
                }
                
                var arr = writeDescriptorSetList.ToArray();
                fixed (WriteDescriptorSet* p = arr)
                    _vk.UpdateDescriptorSets
                        (_logicalDeviceProvider.LogicalDevice, (uint) arr.Length, p, 0, null);
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
                    var region = new BufferCopy(0, dstOffset, bufferSize);
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

            var vertexOffset = (ulong) 0 + (ulong) bufferAllocation.Offset;
            var indexOffset = (ulong) (model.VertexSize * model.VertexCount) + (ulong) bufferAllocation.Offset;
            
            CopyDataToBufferViaStaging(model.Vertices, buffer, vertexOffset);
            CopyDataToBufferViaStaging(model.Indices, buffer, indexOffset);

            _modelBuffers[model] = new ModelBuffer(buffer, bufferAllocation, vertexOffset, indexOffset);
        }

        private unsafe void BuildMaterialInfo(IMaterial material)
        {
            DescriptorPool CreateDescriptorPool()
            {
                var v = material.DescriptorPoolSizes.ToArray();
                for (int i = 0; i < v.Length; i++)
                {
                    v[i].DescriptorCount = (uint) CommandBufferCount;
                }

                return _descriptorPoolFactory.CreateDescriptorPool(v);
            }
            
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
                (pipelineLayout, CreateGraphicsPipeline(), descriptorLayout, CreateDescriptorPool());
            CommandBufferNeedsRebuild = true;
        }

        public unsafe void Dispose()
        {
            foreach (var modelBuffer in _modelBuffers.Values)
            {
                _vk.DestroyBuffer(_logicalDeviceProvider.LogicalDevice, modelBuffer.Buffer, null);
                _vma.FreeMemory(modelBuffer.Allocation);
            }
            _modelBuffers.Clear();
        }
    }
}
