cmake_minimum_required(VERSION 3.17)
project(gl)

set(CMAKE_CXX_STANDARD 14)

INCLUDE_DIRECTORIES(${PROJECT_SOURCE_DIR}/include)
link_directories(${PROJECT_SOURCE_DIR}/lib)

add_executable(gl main.cpp src/glad.c src/shader/Shader.cpp src/shader/Shader.h include/image/image.h src/model/hexagon/hexagon.h src/model/square/square.h)

target_link_libraries(gl -lopengl32 ${PROJECT_SOURCE_DIR}/lib/glfw3.dll )