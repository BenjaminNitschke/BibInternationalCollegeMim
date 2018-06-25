#include "Shader.h"

using namespace CppGameEngine;

void CheckIfNoError() {
	int error = glGetError();
	//#define GL_INVALID_ENUM 0x0500 = 1280
	//#define GL_INVALID_VALUE 0x0501 = 1281
	//#define GL_INVALID_OPERATION 0x0502 = 1282
	//#define GL_STACK_OVERFLOW 0x0503
	//#define GL_STACK_UNDERFLOW 0x0504
	//#define GL_OUT_OF_MEMORY 0x0505
	if (error != GL_NO_ERROR)
		throw error;
}

Shader::Shader(const char* vertexShaderCode, const char* pixelShaderCode)
{
	program = glCreateProgram();
	CheckIfNoError();
	glAttachShader(program, CreateShader(GL_VERTEX_SHADER, vertexShaderCode));
	CheckIfNoError();
	glAttachShader(program, CreateShader(GL_FRAGMENT_SHADER, pixelShaderCode));
	CheckIfNoError();
	glLinkProgram(program);
	CheckIfNoError();
}

GLuint Shader::CreateShader(GLenum type, const char* code)
{
	auto shaderHandle = glCreateShader(type);
	CheckIfNoError();
	glShaderSource(shaderHandle, 1, &code, NULL);
	CheckIfNoError();
	glCompileShader(shaderHandle);
	CheckIfNoError();

	int compileStatus;
	glGetShaderiv(shaderHandle, GL_COMPILE_STATUS, &compileStatus);
	if (compileStatus == 0)
		throw "OpenGL4 error compiling vertex shader: ";// +GL.GetShaderInfoLog(vertexShader);
	return shaderHandle;
}

void Shader::Use()
{
	glUseProgram(program);
}