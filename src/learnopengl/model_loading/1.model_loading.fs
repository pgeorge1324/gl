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

// 定义材质
struct Material {
    vec3 ambient;// 环境光
    vec3 diffuse;// 漫反射
    vec3 specular;// 镜面反射
    float shininess;// 反光度
};

// 定义点光源
struct PointLight {
    vec3 position;

    float constant;
    float linear;
    float quadratic;

    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
};

// 定义聚光灯光源
struct SpotLight {
    vec3 position;// 光源顶点位置
    vec3 direction;// 母线方向
    float cutOff;// 切光角
    float outerCutOff;

    // 实现衰减的二次项的系数
    float constant;// 常量
    float linear;// 一次项系数
    float quadratic;// 二次项系数

    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
};

vec3 phoneShading(vec3 lightPos, vec3 FragPos, vec3 viewPos, vec3 Normal, sampler2D texture_diffuse1, sampler2D texture_specular1, vec2 TexCoords);
vec3 rabbitShading(vec3 lightPos, vec3 FragPos, vec3 viewPos, vec3 Normal, sampler2D texture_diffuse1, sampler2D texture_specular1, vec2 TexCoords);
vec3 stylizedShading(vec3 lightPos, vec3 FragPos, vec3 viewPos, vec3 Normal, sampler2D texture_diffuse1, sampler2D texture_specular1, vec2 TexCoords);
vec3 sunlightShading(vec3 lightPos, vec3 FragPos, vec3 viewPos, vec3 Normal, sampler2D texture_diffuse1, sampler2D texture_specular1, vec2 TexCoords);

void main() {
    vec3 res = phoneShading(lightPos, FragPos, viewPos, Normal, texture_diffuse1, texture_specular1, TexCoords);
    vec3 res1 = sunlightShading(lightPos, FragPos, viewPos, Normal, texture_diffuse1, texture_specular1, TexCoords);
    FragColor = vec4(res + res1, 1.0);
}

vec3 phoneShading(vec3 lightPos, vec3 FragPos, vec3 viewPos, vec3 Normal, sampler2D texture_diffuse1, sampler2D texture_specular1, vec2 TexCoords){
    // ambient
    float ambientStrength = 0.3;
    vec3 ambient = ambientStrength * lightColor* vec3(texture(texture_diffuse1, TexCoords));

    // diffuse
    vec3 norm = normalize(Normal);
    vec3 lightDir = normalize(lightPos - FragPos);

    float diff = max(dot(norm, lightDir), 0.0);
    vec3 diffuse = diff * lightColor * vec3(texture(texture_diffuse1, TexCoords)) *0.5;

    //specular
    float specularStrength = 1.0;
    vec3 viewDir = normalize(viewPos - FragPos);
    vec3 reflectDir = reflect(-lightDir, norm);
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), 32);
    vec3 specular = specularStrength * spec * lightColor * vec3(texture(texture_specular1, TexCoords));

    vec3 result = ambient + diffuse + specular;
    return result;
}

vec3 rabbitShading(vec3 lightPos, vec3 FragPos, vec3 viewPos, vec3 Normal, sampler2D texture_diffuse1, sampler2D texture_specular1, vec2 TexCoords){
    // cool
    float ambientStrength = 0.3;
    vec3 cool = ambientStrength * lightColor* vec3(1.0f, 0.5f, 0.31f);

    // warm
    vec3 norm = normalize(Normal);
    vec3 lightDir = normalize(lightPos - FragPos);

    float diff = max(dot(norm, lightDir), 0.0);
    vec3 warm = diff * lightColor * vec3(1.0f, 0.5f, 0.2f);

    // specular
    float specularStrength = 1.0f;
    vec3 viewDir = normalize(viewPos - FragPos);
    vec3 reflectDir = reflect(-lightDir, norm);
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), 32);
    vec3 specular = specularStrength * spec * lightColor * vec3(1.0f, 1.0f, 1.0f);

    vec3 result = cool + warm + specular;
    return result;
}

vec3 stylizedShading(vec3 lightPos, vec3 FragPos, vec3 viewPos, vec3 Normal, sampler2D texture_diffuse1, sampler2D texture_specular1, vec2 TexCoords){
    vec3 norm = normalize(Normal);
    vec3 lightDir = normalize(lightPos - FragPos);

    // cool
    vec3 cool = vec3(0, 0, 0.55) + 0.25 * vec3(texture(texture_specular1, TexCoords));

    // warm
    vec3 warm = vec3(0.6, 0.6, 0) + 0.25 * vec3(texture(texture_diffuse1, TexCoords));

    // highlight
    vec3 highlight = vec3(1, 1, 1);

    float tPercent = (dot(norm, lightDir) + 1) * 0.5;
    vec3 reflectDir = reflect(-lightDir, norm);
    float sPercent = clamp((100 * dot(reflectDir, viewPos) - 97), 0.8, 1);

    vec3 result = mix(highlight, mix(warm, cool, tPercent), sPercent);
    return result;
}

vec3 sunlightShading(vec3 lightPos, vec3 FragPos, vec3 viewPos, vec3 Normal, sampler2D texture_diffuse1, sampler2D texture_specular1, vec2 TexCoords){

    // diffuse
    vec3 norm = normalize(Normal);
    vec3 lightDir = normalize(vec3(5.0f, 4.0f, 3.0f));

    float diff = max(dot(norm, lightDir), 0.0);
    vec3 diffuse = diff * lightColor * vec3(texture(texture_diffuse1, TexCoords)) *0.5;

    //specular
    float specularStrength = 1.0;
    vec3 viewDir = normalize(viewPos - FragPos);
    vec3 reflectDir = reflect(-lightDir, norm);
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), 32);
    vec3 specular = specularStrength * spec * lightColor * vec3(texture(texture_specular1, TexCoords));

    vec3 result = diffuse + specular;
    return result;
}