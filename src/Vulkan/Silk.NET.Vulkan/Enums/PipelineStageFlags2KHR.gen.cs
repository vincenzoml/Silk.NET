// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.


using System;
using Silk.NET.Core.Attributes;

#pragma warning disable 1591

namespace Silk.NET.Vulkan
{
    [Flags()]
    [NativeName("Name", "VkPipelineStageFlags2KHR")]
    public enum PipelineStageFlags2KHR : int
    {
        [NativeName("Name", "VK_PIPELINE_STAGE_2_NONE_KHR")]
        PipelineStage2NoneKhr = 0,
        [NativeName("Name", "VK_PIPELINE_STAGE_2_TOP_OF_PIPE_BIT_KHR")]
        PipelineStage2TopOfPipeBitKhr = 1,
        [NativeName("Name", "VK_PIPELINE_STAGE_2_DRAW_INDIRECT_BIT_KHR")]
        PipelineStage2DrawIndirectBitKhr = 2,
        [NativeName("Name", "VK_PIPELINE_STAGE_2_VERTEX_INPUT_BIT_KHR")]
        PipelineStage2VertexInputBitKhr = 4,
        [NativeName("Name", "VK_PIPELINE_STAGE_2_VERTEX_SHADER_BIT_KHR")]
        PipelineStage2VertexShaderBitKhr = 8,
        [NativeName("Name", "VK_PIPELINE_STAGE_2_TESSELLATION_CONTROL_SHADER_BIT_KHR")]
        PipelineStage2TessellationControlShaderBitKhr = 16,
        [NativeName("Name", "VK_PIPELINE_STAGE_2_TESSELLATION_EVALUATION_SHADER_BIT_KHR")]
        PipelineStage2TessellationEvaluationShaderBitKhr = 32,
        [NativeName("Name", "VK_PIPELINE_STAGE_2_GEOMETRY_SHADER_BIT_KHR")]
        PipelineStage2GeometryShaderBitKhr = 64,
        [NativeName("Name", "VK_PIPELINE_STAGE_2_FRAGMENT_SHADER_BIT_KHR")]
        PipelineStage2FragmentShaderBitKhr = 128,
        [NativeName("Name", "VK_PIPELINE_STAGE_2_EARLY_FRAGMENT_TESTS_BIT_KHR")]
        PipelineStage2EarlyFragmentTestsBitKhr = 256,
        [NativeName("Name", "VK_PIPELINE_STAGE_2_LATE_FRAGMENT_TESTS_BIT_KHR")]
        PipelineStage2LateFragmentTestsBitKhr = 512,
        [NativeName("Name", "VK_PIPELINE_STAGE_2_COLOR_ATTACHMENT_OUTPUT_BIT_KHR")]
        PipelineStage2ColorAttachmentOutputBitKhr = 1024,
        [NativeName("Name", "VK_PIPELINE_STAGE_2_COMPUTE_SHADER_BIT_KHR")]
        PipelineStage2ComputeShaderBitKhr = 2048,
        [NativeName("Name", "VK_PIPELINE_STAGE_2_ALL_TRANSFER_BIT_KHR")]
        PipelineStage2AllTransferBitKhr = 4096,
        [NativeName("Name", "VK_PIPELINE_STAGE_2_TRANSFER_BIT_KHR")]
        PipelineStage2TransferBitKhr = 4096,
        [NativeName("Name", "VK_PIPELINE_STAGE_2_BOTTOM_OF_PIPE_BIT_KHR")]
        PipelineStage2BottomOfPipeBitKhr = 8192,
        [NativeName("Name", "VK_PIPELINE_STAGE_2_HOST_BIT_KHR")]
        PipelineStage2HostBitKhr = 16384,
        [NativeName("Name", "VK_PIPELINE_STAGE_2_ALL_GRAPHICS_BIT_KHR")]
        PipelineStage2AllGraphicsBitKhr = 32768,
        [NativeName("Name", "VK_PIPELINE_STAGE_2_ALL_COMMANDS_BIT_KHR")]
        PipelineStage2AllCommandsBitKhr = 65536,
        [NativeName("Name", "VK_PIPELINE_STAGE_2_COPY_BIT_KHR")]
        PipelineStage2CopyBitKhr = 1,
        [NativeName("Name", "VK_PIPELINE_STAGE_2_RESOLVE_BIT_KHR")]
        PipelineStage2ResolveBitKhr = 2,
        [NativeName("Name", "VK_PIPELINE_STAGE_2_BLIT_BIT_KHR")]
        PipelineStage2BlitBitKhr = 4,
        [NativeName("Name", "VK_PIPELINE_STAGE_2_CLEAR_BIT_KHR")]
        PipelineStage2ClearBitKhr = 8,
        [NativeName("Name", "VK_PIPELINE_STAGE_2_INDEX_INPUT_BIT_KHR")]
        PipelineStage2IndexInputBitKhr = 16,
        [NativeName("Name", "VK_PIPELINE_STAGE_2_VERTEX_ATTRIBUTE_INPUT_BIT_KHR")]
        PipelineStage2VertexAttributeInputBitKhr = 32,
        [NativeName("Name", "VK_PIPELINE_STAGE_2_PRE_RASTERIZATION_SHADERS_BIT_KHR")]
        PipelineStage2PreRasterizationShadersBitKhr = 64,
        [NativeName("Name", "VK_PIPELINE_STAGE_2_TRANSFORM_FEEDBACK_BIT_EXT")]
        PipelineStage2TransformFeedbackBitExt = 16777216,
        [NativeName("Name", "VK_PIPELINE_STAGE_2_CONDITIONAL_RENDERING_BIT_EXT")]
        PipelineStage2ConditionalRenderingBitExt = 262144,
        [NativeName("Name", "VK_PIPELINE_STAGE_2_COMMAND_PREPROCESS_BIT_NV")]
        PipelineStage2CommandPreprocessBitNV = 131072,
        [NativeName("Name", "VK_PIPELINE_STAGE_2_FRAGMENT_SHADING_RATE_ATTACHMENT_BIT_KHR")]
        PipelineStage2FragmentShadingRateAttachmentBitKhr = 4194304,
        [NativeName("Name", "VK_PIPELINE_STAGE_2_SHADING_RATE_IMAGE_BIT_NV")]
        PipelineStage2ShadingRateImageBitNV = 4194304,
        [NativeName("Name", "VK_PIPELINE_STAGE_2_ACCELERATION_STRUCTURE_BUILD_BIT_KHR")]
        PipelineStage2AccelerationStructureBuildBitKhr = 33554432,
        [NativeName("Name", "VK_PIPELINE_STAGE_2_RAY_TRACING_SHADER_BIT_KHR")]
        PipelineStage2RayTracingShaderBitKhr = 2097152,
        [NativeName("Name", "VK_PIPELINE_STAGE_2_RAY_TRACING_SHADER_BIT_NV")]
        PipelineStage2RayTracingShaderBitNV = 2097152,
        [NativeName("Name", "VK_PIPELINE_STAGE_2_ACCELERATION_STRUCTURE_BUILD_BIT_NV")]
        PipelineStage2AccelerationStructureBuildBitNV = 33554432,
        [NativeName("Name", "VK_PIPELINE_STAGE_2_FRAGMENT_DENSITY_PROCESS_BIT_EXT")]
        PipelineStage2FragmentDensityProcessBitExt = 8388608,
        [NativeName("Name", "VK_PIPELINE_STAGE_2_TASK_SHADER_BIT_NV")]
        PipelineStage2TaskShaderBitNV = 524288,
        [NativeName("Name", "VK_PIPELINE_STAGE_2_MESH_SHADER_BIT_NV")]
        PipelineStage2MeshShaderBitNV = 1048576,
    }
}
