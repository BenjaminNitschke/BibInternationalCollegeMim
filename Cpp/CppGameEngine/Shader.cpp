#include "Shader.h"
using namespace CppGameEngine;

Shader::Shader(const char* vertexShaderCode,const char* pixelShaderCode)
{
	Shader::program = glCreateProgram();
	Shader::vertexShader = CreateShader(GL_VERTEX_SHADER, vertexShaderCode);
	Shader::pixelShader = CreateShader(GL_FRAGMENT_SHADER, pixelShaderCode);
	glAttachShader(program, vertexShader);
	glAttachShader(program, pixelShader);
	glLinkProgram(program);
}

void Shader::Use()
{
	
	glUseProgram(program);
}

GLuint Shader::CreateShader(GLenum type,const char* code)
{
	GLuint myShader = glCreateShader(type);
	glShaderSource(myShader, 1, &code, 0);
	glCompileShader(myShader);
	return myShader;
}
