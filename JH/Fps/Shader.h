#pragma once
#include <memory>
#include "Texture.h"

namespace CppGameEngine
{
	class Shader
	{
	public:
		Shader(char* vertexChaderCode, char* pixelShaderCode);
		void Use();

		

	private:
		GLuint vertexShader;
		GLuint pixelShader;
		GLuint program;
	};
}
