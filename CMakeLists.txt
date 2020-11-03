cmake_minimum_required(VERSION 3.15)
project(gl)

set(CMAKE_CXX_STANDARD 14)

INCLUDE_DIRECTORIES(${PROJECT_SOURCE_DIR}/include)
link_directories(${PROJECT_SOURCE_DIR}/lib)
link_directories(${PROJECT_SOURCE_DIR}/dll)

add_executable(gl main.cpp src/glad.c src/stb_image.cpp src/classes/shader/Shader.cpp src/classes/shader/Shader.h src/classes/camera/Camera.cpp src/classes/camera/Camera.h)
add_executable(introduction src/learnopengl/introduction/introduction.cpp src/glad.c src/stb_image.cpp src/classes/shader/Shader.cpp src/classes/shader/Shader.h src/classes/camera/Camera.cpp src/classes/camera/Camera.h)
add_executable(lightDiffuse src/learnopengl/light/lighting_diffuse_2.1/lighting_deffuse.cpp src/glad.c src/stb_image.cpp src/classes/shader/Shader.cpp src/classes/shader/Shader.h src/classes/camera/Camera.cpp src/classes/camera/Camera.h)
add_executable(material src/learnopengl/light/material/material.cpp src/glad.c src/stb_image.cpp src/classes/shader/Shader.cpp src/classes/shader/Shader.h src/classes/camera/Camera.cpp src/classes/camera/Camera.h)

target_link_libraries(gl -lopengl32 ${PROJECT_SOURCE_DIR}/dll/glfw3.dll)
target_link_libraries(introduction -lopengl32 ${PROJECT_SOURCE_DIR}/dll/glfw3.dll)
target_link_libraries(lightDiffuse -lopengl32 ${PROJECT_SOURCE_DIR}/dll/glfw3.dll)
target_link_libraries(material -lopengl32 ${PROJECT_SOURCE_DIR}/dll/glfw3.dll)