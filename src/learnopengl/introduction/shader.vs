// 顶点着色器
#version 330 core
layout (location = 0) in vec3 aPos;   // 位置变量的属性位置值为 0
//layout (location = 1) in vec3 aColor; // 颜色变量的属性位置值为 1
layout (location = 1) in vec2 aTexCoord; // 纹理变量的属性位置值为 2
out vec4 ourColor;
out vec2 texCoord;
uniform vec4 greenColor;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

void main()
{
    gl_Position = projection * view * model * vec4(aPos, 1.0f);
    //ourColor = vec4(greenColor.x * aColor.x,greenColor.y * aColor.y,greenColor.z * aColor.z,1.0f);
    texCoord = aTexCoord;
}