// 片段着色器（GPU中没有默认的顶点/片段着色器）
#version 330 core
out vec4 FragColor;
//in vec4 ourColor;
in vec2 texCoord;

uniform sampler2D texture1;
uniform sampler2D texture2;
uniform float fPercent;

void main()
{
    FragColor = mix(texture(texture1,texCoord),texture(texture2,texCoord),fPercent);
}