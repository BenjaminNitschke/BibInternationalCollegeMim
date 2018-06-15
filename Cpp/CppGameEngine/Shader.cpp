#include "Shader.h"
using namespace CppGameEngine;

Shader::Shader(char* vertexShaderCode, char* pixelShaderCode)
{
	Shader::vertexShader = CreateShader(GL_VERTEX_SHADER, vertexShaderCode);
	Shader::pixelShader = CreateShader(GL_FRAGMENT_SHADER, pixelShaderCode);
	Use();
}

void Shader::Use()
{
	Shader::program = glCreateProgram();
	glAttachShader(program, vertexShader);
	glAttachShader(program, pixelShader);
	glLinkProgram(program);
	glUseProgram(program);
}

GLuint Shader::CreateShader(GLenum type, char* code)
{
	GLuint myShader = glCreateShader(type);
	glShaderSource(myShader, 1, &code, 0);
	glCompileShader(myShader);
	return myShader;
}
