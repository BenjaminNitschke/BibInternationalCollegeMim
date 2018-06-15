#include "Shader.h"

using namespace CppGameEngine;

Shader::Shader(const char* vertexShaderCode, const char* pixelShaderCode)
{
	program = glCreateProgram();
	glAttachShader(program, CreateShader(GL_VERTEX_SHADER, vertexShaderCode));
	glAttachShader(program, CreateShader(GL_FRAGMENT_SHADER, pixelShaderCode));
	glLinkProgram(program);
}

GLuint Shader::CreateShader(GLenum type, const char* code)
{
	auto shaderHandle = glCreateShader(type);
	glShaderSource(shaderHandle, 1, &code, NULL);
	glCompileShader(shaderHandle);
	return shaderHandle;
}

void Shader::Use()
{
	glUseProgram(program);
}