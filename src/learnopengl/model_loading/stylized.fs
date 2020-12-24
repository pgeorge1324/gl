#version 330 core
out vec4 FragColor;

in vec2 TexCoords;
in vec3 Normal;
in vec3 FragPos;

uniform sampler2D texture_diffuse1;
uniform sampler2D texture_specular1;

uniform vec3 lightPos;
uniform vec3 lightColor;
uniform vec3 viewPos;

void main() {
    vec3 norm = normalize(Normal);
    vec3 lightDir = normalize(lightPos - FragPos);

    // cool
    vec3 cool = vec3(0, 0, 0.55) + 0.25 * vec3(texture(texture_specular1, TexCoords));

    // warm
    vec3 warm = vec3(0.6, 0.6, 0) + 0.25 * vec3(texture(texture_diffuse1, TexCoords));

    // highlight
    vec3 highlight = vec3(1, 1, 1);

    float tPercent = (dot(norm, lightDir) + 1) / 2;
    vec3 reflectDir = reflect(-lightDir, norm);
    float sPercent = clamp((100 * dot(reflectDir, viewPos) - 97), 0, 1);

    vec3 result = mix(highlight, mix(warm, cool, tPercent), sPercent);
    FragColor = vec4(result, 1.0);
}