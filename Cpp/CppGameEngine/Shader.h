#pragma once
#include "Headers.h"

namespace CppGameEngine
{
	class Shader
	{
	public:
		Shader(char* vertexShaderCode, char* pixelShaderCode);
		void Use();

	private:
		GLuint CreateShader(GLenum type, char* code);
		GLuint VertexShader;
		GLuint PixelShader;
		GLuint program;
	};
}
