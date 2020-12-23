C:/VulkanSDK/1.2.154.1/Bin32/glslc.exe ./shaders/shader.vert -o ./shaders/vert-unoptimized.spv
C:/VulkanSDK/1.2.154.1/Bin32/glslc.exe ./shaders/shader.frag -o ./shaders/frag-unoptimized.spv

C:/VulkanSDK/1.2.154.1/Bin32/spirv-remap.exe -i ./shaders/vert-unoptimized.spv -o .
C:/VulkanSDK/1.2.154.1/Bin32/spirv-remap.exe -i ./shaders/frag-unoptimized.spv -o .

C:/VulkanSDK/1.2.154.1/Bin32/spirv-opt.exe -O ./shaders/vert-unoptimized.spv -o ./shaders/vert.spv
C:/VulkanSDK/1.2.154.1/Bin32/spirv-opt.exe -O ./shaders/frag-unoptimized.spv -o ./shaders/frag.spv