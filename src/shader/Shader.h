//
// Created by wm200618 on 2020/10/22.
//

#ifndef GL_SHADER_H
#define GL_SHADER_H

#include <glad/glad.h>// 包含glad来获取所有的必须OpenGL头文件

#include <string>
#include <fstream>
#include <sstream>
#include <iostream>

#include "../include/glm/glm.hpp"
#include "../include/glm/gtc/matrix_transform.hpp"
#include "../include/glm/gtc/type_ptr.hpp"


class Shader {
public:
    // 程序ID
    unsigned int ID;

    // 构造器读取并构建着色器
    Shader(const GLchar *vertexPath, const GLchar *fragmentPath);

    // 使用/激活程序
    void use();

    // uniform工具函数
    void setBool(const std::string &name, bool value) const;

    void setInt(const std::string &name, int value) const;

    void setFloat(const std::string &name, float value) const;

    void setFloat4(const std::string &name, float value1, float value2, float value3, float value4) const;

    void setMatrix4fv(const std::string &name, glm::mat4 &trans) const;

    void setVec3(const std::string &name, glm::vec3 vec) const;

    void setVec3(const std::string &name, float x, float y, float z) const;

    virtual ~ Shader();
};


#endif //GL_SHADER_H
