// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Silk.NET.Maths;
using Silk.NET.Vulkan;
using Silk.NET.Vulkan.VMA;
using Silk.NET.Windowing;
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
            public readonly AllocationT AllocationT;
            public readonly AllocationInfo AllocationInfo;
            public readonly ulong VertexOffset;
            public readonly ulong IndexOffset;

            public ModelBuffer(Buffer buffer, AllocationT allocationT, AllocationInfo allocationInfo, ulong vertexOffset, ulong indexOffset)
            {
                AllocationT = allocationT;
                AllocationInfo = allocationInfo;
                Buffer = buffer;
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
            public Buffer[] UniformBuffer { get; }
            public AllocationT[] AllocationT { get; }
            public AllocationInfo[] AllocationInfo { get; }
            public DescriptorSet[] DescriptorSets { get; }

            public SceneObjectInfo(Buffer[] uniformBuffer, AllocationT[] allocationT, AllocationInfo[] allocationInfo, DescriptorSet[] descriptorSets)
            {
                UniformBuffer = uniformBuffer;
                AllocationT = allocationT;
                AllocationInfo = allocationInfo;
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
        private readonly Vma _vma;
        private readonly IAllocatorProvider _allocatorProvider;
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
            Vma vma,
            IAllocatorProvider allocatorProvider
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
            _vma = vma;
            _allocatorProvider = allocatorProvider;
            CommandBufferNeedsRebuild = true;
            _windowProvider.Window.Update += (WindowOnUpdate);
        }

        private void WindowOnUpdate(double d)
        {
            Update();
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

        public unsafe void Update()
        {
            foreach (var (sceneObject, info) in _objectInfos)
            {
                var ubo = new UniformBufferObject(
                    model: sceneObject.WorldToLocal, // Matrix4X4<float>.Identity, // Matrix4X4.CreateRotationZ((float) ((timeDiff.TotalMilliseconds / 10) * MathF.PI / 180f)),
                    view: _cameraProvider.ViewMatrix
                );

                for (int i = 0; i < info.AllocationInfo.Length; i++)
                {
                    void* data = default;
                    var allocator = _allocatorProvider.Allocator;
                    // TODO: don't write all the data
                    var allocation = info.AllocationT[i];
                    _vma.MapMemory(&allocator, ref allocation, ref data);
                    *(UniformBufferObject*)data = ubo;
                    _vma.UnmapMemory(&allocator, ref allocation);
                }
            }
        }
        
        public void AddObject(ISceneObject sceneObject)
        {

            if (_objectInfos.ContainsKey(sceneObject))
                throw new ArgumentException("Cannot add scene object twice");
            
            if (_materialInfos.TryGetValue(sceneObject.Material, out var info))
                info.Objects.Add(sceneObject);
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
                info.DescriptorPool = _descriptorPoolFactory.CreateDescriptorPool
                (
                    m.DescriptorPoolSizes
                        .Select
                        (
                            x =>
                            {
                                x.DescriptorCount = (uint) CommandBufferCount;
                                return x;
                            }
                        )
                        .ToArray()
                );
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
            var allocator = _allocatorProvider.Allocator;
            for (int i = 0; i < info.AllocationInfo.Length; i++)
            {
                var allocation = info.AllocationT[i];
                _vma.DestroyBuffer(&allocator, info.UniformBuffer[i].Handle, &allocation);
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
            
            (Buffer UniformBuffer, AllocationT AllocationT, AllocationInfo AllocationInfo) CreateUniformBuffer()
            {
                var (uniformBuffer, allocationT, allocationInfo) = _bufferFactory.CreateBuffer
                (
                    (ulong) sizeof(UniformBufferObject), MemoryUsage.MemoryUsageGpuOnly, BufferUsageFlags.BufferUsageUniformBufferBit,
                    MemoryPropertyFlags.MemoryPropertyHostVisibleBit | MemoryPropertyFlags.MemoryPropertyHostCoherentBit,
                    stackalloc[] {_graphicsQueueProvider.GraphicsQueueIndex}, 0
                );

                return (uniformBuffer, allocationT, allocationInfo);
            }

            var buffers = new Buffer[CommandBufferCount];
            var allocations = new AllocationT[CommandBufferCount];
            var infos = new AllocationInfo[CommandBufferCount];

            for (int i = 0; i < CommandBufferCount; i++)
            {
                (buffers[i], allocations[i], infos[i]) = CreateUniformBuffer();
            }
            
            _objectInfos[sceneObject] = new SceneObjectInfo(buffers, allocations, infos, CreateDescriptorSet());
        }

        private unsafe void UpdateDescriptorSet(ISceneObject sceneObject)
        {
            var objectInfo = _objectInfos[sceneObject];
            for (int i = 0; i < CommandBufferCount; i++)
            {
                var writeDescriptorSetList = new List<WriteDescriptorSet>();
                
                var bufferInfo = new DescriptorBufferInfo
                    (objectInfo.UniformBuffer[i], objectInfo.AllocationInfo[i].Offset, (ulong) sizeof(UniformBufferObject));

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
            
            var (stagingBuffer, allocationT, allocationInfo) = _bufferFactory.CreateBuffer
            (
                bufferSize, MemoryUsage.MemoryUsageCpuToGpu, BufferUsageFlags.BufferUsageTransferSrcBit,
                MemoryPropertyFlags.MemoryPropertyHostVisibleBit |
                MemoryPropertyFlags.MemoryPropertyHostCoherentBit,
                stackalloc[] {_transferQueueProvider.TransferQueueIndex, _graphicsQueueProvider.GraphicsQueueIndex}, AllocationCreateFlagBits.AllocationCreateMappedBit
            );

            var span = new Span<T>(allocationInfo.PMappedData, src.Length);
            src.CopyTo(span);
            var allocator = _allocatorProvider.Allocator;
            _vma.UnmapMemory(&allocator, &allocationT);

            _commandBufferFactory.RunSingleTime(_transferQueueProvider.TransferQueueIndex, _transferQueueProvider.TransferQueue,
                (commandBuffer) =>
                {
                    var region = new BufferCopy(0, dstOffset, bufferSize);
                    _vk.CmdCopyBuffer(commandBuffer, stagingBuffer, dstBuffer, 1, &region);   
                });
            
            _vma.DestroyBuffer(&allocator, stagingBuffer.Handle, &allocationT);
        }
        
        private void BuildBuffer(IModel model)
        {
            // TODO: Now that we use VMA, split this allocation.
            var (buffer, allocationT, allocationInfo) = _bufferFactory.CreateBuffer
            (
                (ulong) (model.VertexSize * model.VertexCount + sizeof(uint) * model.IndexCount), MemoryUsage.MemoryUsageGpuOnly,
                BufferUsageFlags.BufferUsageIndexBufferBit | BufferUsageFlags.BufferUsageVertexBufferBit | BufferUsageFlags.BufferUsageTransferDstBit,
                MemoryPropertyFlags.MemoryPropertyDeviceLocalBit,
                stackalloc uint[] {_graphicsQueueProvider.GraphicsQueueIndex, _transferQueueProvider.TransferQueueIndex}, 0
            );

            var vertexOffset = (ulong) 0;
            var indexOffset = (ulong) (model.VertexSize * model.VertexCount);
            
            CopyDataToBufferViaStaging(model.Vertices, buffer, vertexOffset);
            CopyDataToBufferViaStaging(model.Indices, buffer, indexOffset);

            _modelBuffers[model] = new ModelBuffer(buffer, allocationT, allocationInfo, vertexOffset, indexOffset);
        }

        private unsafe void BuildMaterialInfo(IMaterial material)
        {
            DescriptorPool CreateDescriptorPool()
            {
                return _descriptorPoolFactory.CreateDescriptorPool
                (
                    material.DescriptorPoolSizes
                        .Select
                        (
                            x =>
                            {
                                x.DescriptorCount = (uint) CommandBufferCount;
                                return x;
                            }
                        )
                        .ToArray()
                );
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
            _windowProvider.Window.Update -= WindowOnUpdate;

            var allocator = _allocatorProvider.Allocator;
            foreach (var modelBuffer in _modelBuffers.Values)
            {
                var allocation = modelBuffer.AllocationT;
                _vma.DestroyBuffer(&allocator, modelBuffer.Buffer.Handle, &allocation);
            }
            _modelBuffers.Clear();
        }
    }
}
