cmake_minimum_required(VERSION 3.15)
project(gl)

set(CMAKE_CXX_STANDARD 14)

INCLUDE_DIRECTORIES(${PROJECT_SOURCE_DIR}/include)
link_directories(${PROJECT_SOURCE_DIR}/lib)
link_directories(${PROJECT_SOURCE_DIR}/dll)

#####################################################################
add_executable(gl main.cpp src/glad.c src/stb_image.cpp)
target_link_libraries(gl ${PROJECT_SOURCE_DIR}/lib/glfw3.lib)
#####################################################################

#####################################################################
add_executable(lighting_diffuse src/learnopengl/light/lighting_diffuse_2.1/lighting_diffuse.cpp src/glad.c src/stb_image.cpp src/classes/shader/Shader.cpp src/classes/shader/Shader.h src/classes/camera/Camera.cpp src/classes/camera/Camera.h include/model/light/light.h)
target_link_libraries(lighting_diffuse ${PROJECT_SOURCE_DIR}/lib/glfw3.lib)
#target_link_libraries(lightDiffuse ${PROJECT_SOURCE_DIR}/dll/mingw/glfw3.dll)
#####################################################################


#####################################################################
add_executable(material src/learnopengl/light/material/material.cpp src/glad.c src/stb_image.cpp src/classes/shader/Shader.cpp src/classes/shader/Shader.h src/classes/camera/Camera.cpp src/classes/camera/Camera.h)
target_link_libraries(material ${PROJECT_SOURCE_DIR}/lib/glfw3.lib)
#target_link_libraries(material ${PROJECT_SOURCE_DIR}/dll/mingw/glfw3.dll)
#####################################################################

#####################################################################
add_executable(introduction src/learnopengl/introduction/introduction.cpp src/glad.c src/stb_image.cpp src/classes/shader/Shader.cpp src/classes/shader/Shader.h src/classes/camera/Camera.cpp src/classes/camera/Camera.h)
target_link_libraries(introduction ${PROJECT_SOURCE_DIR}/lib/glfw3.lib)
#target_link_libraries(introduction ${PROJECT_SOURCE_DIR}/dll/mingw/glfw3.dll)
#####################################################################

#####################################################################
add_executable(model_loading src/learnopengl/model_loading/model_loading.cpp src/glad.c src/stb_image.cpp)
target_link_libraries(model_loading ${PROJECT_SOURCE_DIR}/lib/assimp-vc140-mt.lib)
target_link_libraries(model_loading ${PROJECT_SOURCE_DIR}/lib/glfw3.lib)
#target_link_libraries(model_loading ${PROJECT_SOURCE_DIR}/dll/mingw/glfw3.dll)
#####################################################################

#####################################################################
add_executable(depth_testing src/learnopengl/depth_testing/depth_testing.cpp src/glad.c src/stb_image.cpp)
target_link_libraries(depth_testing ${PROJECT_SOURCE_DIR}/lib/glfw3.lib)
#target_link_libraries(depth_testing ${PROJECT_SOURCE_DIR}/dll/mingw/glfw3.dll)
#####################################################################




