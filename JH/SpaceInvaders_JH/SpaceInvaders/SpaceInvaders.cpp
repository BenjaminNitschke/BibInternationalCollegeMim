#include "stdafx.h"
#include "SpaceInvaders.h"
#include <GLFW/glfw3.h>
#include "Game.h"
#include "Texture.h"
using namespace CppGameEngine;

class SpaceInvadersGame : public CppGameEngine::Game
{
public:
	SpaceInvadersGame(std::string gameName) : CppGameEngine::Game(gameName) {}

	void PlayGame()
	{

	}
};

			int APIENTRY wWinMain(_In_ HINSTANCE hInstance,
				_In_opt_ HINSTANCE hPrevInstance,
				_In_ LPWSTR    lpCmdLine,
				_In_ int       nCmdShow)
	{
		auto game = new SpaceInvadersGame("Space Invaders");
		auto texture = std::make_shared<Texture>("Background.png");
		game->Run([]() 
		{
			glBegin(GL_TRIANGLES);
			
			glColor3f(1, 0, 0);
			glVertex3f(-0.7f, -0.1f, 0.f);
			glColor3f(0, 1, 0);
			glVertex3f(0.7f, -0.1f, 0.f);
			glColor3f(0, 0, 1);
			glVertex3f(0.f, 0.7f, 0.f);

			glEnd();
		});

		return 0;
		//    return (int) msg.wParam;
	}
