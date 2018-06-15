#pragma once
#include <GL\glew.h>
namespace CppGameEngine
{
	class Shader
	{
	public:
		Shader(char* vertexShaderCode, char* pixelShaderCode);
		void Use();

	private:
		GLuint CreateShader(GLenum type, char* code);
		GLuint vertexShader;
		GLuint pixelShader;
		GLuint program;
	};
}