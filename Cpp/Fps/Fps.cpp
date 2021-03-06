#include "stdafx.h"
#include "Fps.h"
#include "Game.h"
#include "FpsGame.h"

using namespace CppGameEngine;
FILE _iob[] = { *stdin, *stdout, *stderr };

extern "C" FILE * __cdecl __iob_func(void)
{
	return _iob;
}

int APIENTRY wWinMain(_In_ HINSTANCE hInstance,
	_In_opt_ HINSTANCE hPrevInstance,
	_In_ LPWSTR    lpCmdLine,
	_In_ int       nCmdShow)
{
	Game* game = new FpsGame();
	game->PlayGame();
	delete game;
	return 0;
}
