cmake_minimum_required(VERSION 3.15)
project(gl)

set(CMAKE_CXX_STANDARD 14)

INCLUDE_DIRECTORIES(${PROJECT_SOURCE_DIR}/include)
link_directories(${PROJECT_SOURCE_DIR}/lib)
link_directories(${PROJECT_SOURCE_DIR}/dll)

add_executable(gl main.cpp src/glad.c src/stb_image.cpp src/shader/Shader.cpp src/shader/Shader.h src/camera/Camera.cpp src/camera/Camera.h)

target_link_libraries(gl -lopengl32 ${PROJECT_SOURCE_DIR}/dll/glfw3.dll)