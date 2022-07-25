#version 330 core
out vec4 FragColor;

in vec2 TexCoords;

uniform sampler2D texture1;
float near = 1.0;
float far  = 100.0;

float LinearizeDepth(float depth)
{
    float z = depth * 2.0 - 1.0;// back to NDC
    return (2.0 * near * far) / (far + near - z * (far - near));
}


void main()
{
    //    FragColor = texture(texture1, TexCoords);
    FragColor = mix (vec4(1.0, 1.0, 1.0, 0.0), texture(texture1, TexCoords), 0.8);
    //    float depth = LinearizeDepth(gl_FragCoord.z) / 50; // 为了演示除以 far
    //    FragColor = vec4(vec3(depth), 1.0);
}