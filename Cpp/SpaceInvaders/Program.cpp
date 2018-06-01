#include "stdafx.h"
#include "SpaceInvadersGame.h"

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
	//TODO: Sprite Animations, explosion 24fps, 48
	auto game = new SpaceInvadersGame();
	game->PlayGame();
	return 0;
}