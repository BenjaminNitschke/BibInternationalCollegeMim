#include "stdafx.h"
#include "SpaceInvadersGame.h"
#include <../glfw-3.2.1.bin.WIN64/include/GLFW/glfw3.h>
#include "Game.h"
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
	auto game = new SpaceInvadersGame();
	game->PlayGame();
	return 0;
}