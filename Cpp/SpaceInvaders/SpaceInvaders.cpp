#include "stdafx.h"
#include "SpaceInvaders.h"
#include <GLFW/glfw3.h>
#include "Game.h"
#include "Texture.h"
using namespace CppGameEngine;
FILE _iob[] = { *stdin, *stdout, *stderr };

extern "C" FILE * __cdecl __iob_func(void)
{
	return _iob;
}

class SpaceInvadersGame : public Game {
public:
	SpaceInvadersGame() : Game("Space Invaders")
	{
		background = std::make_shared<Sprite>(std::make_shared<Texture>("Background.png"),
			0, 0, 1, 1);
		ship = std::make_shared<Sprite>(std::make_shared<Texture>("Ship.png"),
			0, -0.7f, 0.1f, 0.1f);
	}

	void PlayGame() {
		Run([&]() {
			background->Draw();
			ship->Draw();
		});
	}
private:
	std::shared_ptr<Sprite> background;
	std::shared_ptr<Sprite> ship;
};

int APIENTRY wWinMain(_In_ HINSTANCE hInstance,
                     _In_opt_ HINSTANCE hPrevInstance,
                     _In_ LPWSTR    lpCmdLine,
                     _In_ int       nCmdShow)
{
	auto game = new SpaceInvadersGame();
	game->PlayGame();
	return 0;
}
