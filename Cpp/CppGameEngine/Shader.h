#pragma once
#include "Headers.h"

namespace CppGameEngine
{
	class Shader
	{
	public:
		Shader(const char* vertexShaderCode, const char* pixelShaderCode);
		void Use();

	private:
		GLuint CreateShader(GLenum type, const char* code);
		GLuint vertexShader;
		GLuint pixelShader;
		GLuint program;
	};
}