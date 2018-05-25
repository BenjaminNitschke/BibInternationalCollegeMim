#include "stdafx.h"
#include "main.h"
#include "Space_Invaders_JH.h"

int APIENTRY wWinMain(_In_ HINSTANCE hInstance,
	_In_opt_ HINSTANCE hPrevInstance,
	_In_ LPWSTR    lpCmdLine,
	_In_ int       nCmdShow)
{
	auto game = new SpaceInvadersGame();
	game->PlayGame();

	return 0;
}