C:/VulkanSDK/1.2.154.1/Bin32/glslc.exe ./shaders/shader.vert -o ./shaders/vert.spv
C:/VulkanSDK/1.2.154.1/Bin32/glslc.exe ./shaders/shader.frag -o ./shaders/frag.spv

C:/VulkanSDK/1.2.154.1/Bin32/spirv-remap.exe -i ./shaders/vert.spv -o .
C:/VulkanSDK/1.2.154.1/Bin32/spirv-remap.exe -i ./shaders/frag.spv -o .

C:/VulkanSDK/1.2.154.1/Bin32/spirv-opt.exe -O ./shaders/vert.spv -o ./shaders/vert.spv
C:/VulkanSDK/1.2.154.1/Bin32/spirv-opt.exe -O ./shaders/frag.spv -o ./shaders/frag.spv