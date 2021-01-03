C:/VulkanSDK/1.2.154.1/Bin32/glslc.exe ./shaders/simple3d/shader.vert -o ./shaders/simple3d/vert.spv
C:/VulkanSDK/1.2.154.1/Bin32/glslc.exe ./shaders/simple3d/shader.frag -o ./shaders/simple3d/frag.spv

C:/VulkanSDK/1.2.154.1/Bin32/spirv-remap.exe -i ./shaders/simple3d/vert.spv -o .
C:/VulkanSDK/1.2.154.1/Bin32/spirv-remap.exe -i ./shaders/simple3d/frag.spv -o .

C:/VulkanSDK/1.2.154.1/Bin32/spirv-opt.exe -O ./shaders/simple3d/vert.spv -o ./shaders/simple3d/vert.spv
C:/VulkanSDK/1.2.154.1/Bin32/spirv-opt.exe -O ./shaders/simple3d/frag.spv -o ./shaders/simple3d/frag.spv

C:/VulkanSDK/1.2.154.1/Bin32/glslc.exe ./shaders/simpletextured3d/shader.vert -o ./shaders/simpletextured3d/vert.spv
C:/VulkanSDK/1.2.154.1/Bin32/glslc.exe ./shaders/simpletextured3d/shader.frag -o ./shaders/simpletextured3d/frag.spv

C:/VulkanSDK/1.2.154.1/Bin32/spirv-remap.exe -i ./shaders/simpletextured3d/vert.spv -o .
C:/VulkanSDK/1.2.154.1/Bin32/spirv-remap.exe -i ./shaders/simpletextured3d/frag.spv -o .

C:/VulkanSDK/1.2.154.1/Bin32/spirv-opt.exe -O ./shaders/simpletextured3d/vert.spv -o ./shaders/simpletextured3d/vert.spv
C:/VulkanSDK/1.2.154.1/Bin32/spirv-opt.exe -O ./shaders/simpletextured3d/frag.spv -o ./shaders/simpletextured3d/frag.spv