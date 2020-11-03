// 片段着色器（GPU中没有默认的顶点/片段着色器）
#version 330 core
out vec4 FragColor;

void main()
{
    FragColor = vec4(1.0); // set alle 4 vector values to 1.0
}