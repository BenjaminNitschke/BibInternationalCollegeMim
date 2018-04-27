#include "stdafx.h"
#include "SpaceInvaders.h"
#include <GLFW/glfw3.h>
#include "Game.h"

class SpaceInvadersGame : CppGameEngine::Game
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
		glfwInit();
		GLFWwindow* window = glfwCreateWindow(1280, 720, "Space Invaders", NULL, NULL);
		int viewportWidth, viewportHeight;
		auto game = new SpaceInvadersGame("Space Invaders");
		while (!glfwWindowShouldClose(window))
		{
			glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
			glfwSwapBuffers(window);
			glfwPollEvents();
		}

		glfwTerminate();
		return 0;
		//    return (int) msg.wParam;
	}
