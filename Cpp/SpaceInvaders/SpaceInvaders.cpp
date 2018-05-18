#include "stdafx.h"
#include "SpaceInvaders.h"
#include <../glfw-3.2.1.bin.WIN64/include/GLFW/glfw3.h>
#include "Game.h"
using namespace CppGameEngine;
FILE _iob[] = { *stdin, *stdout, *stderr };
extern "C" FILE * __cdecl __iob_func(void)
{
	return _iob;
}

class SpaceInvadersGame : public Game
{
	public:
		SpaceInvadersGame() : Game("Space Invaders") {}
		void PlayGame()
		{

		}
};
int APIENTRY wWinMain(_In_ HINSTANCE hInstance,
                     _In_opt_ HINSTANCE hPrevInstance,
                     _In_ LPWSTR    lpCmdLine,
                     _In_ int       nCmdShow)
{
	auto game = new SpaceInvadersGame();
	auto texture = std::make_shared<Texture>("Background.png");
	game->Run([texture]() {
		glBegin(GL_TEXTURE_2D);
		//glTexImage2D(GL_TEXTURE_2D, 0, GL_RGBA, 10, 10, 0, GL_RGBA, GL_UNSIGNED_BYTE, *texture.handle);
		/*glBegin(GL_TRIANGLES);
		glColor3f(1.0f, 0.0f, 0.0f);
		glVertex3f(-1, -1, 0);
		glColor3f(0.0f, 1.0f, 0.0f);
		glVertex3f(1, -1, 0);
		glColor3f(0.0f, 0.0f, 1.0f);
		glVertex3f(0, 1, 0);
		glEnd();*/
	});
	return 0;
}