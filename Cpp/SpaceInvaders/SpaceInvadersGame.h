#pragma once
#include "stdafx.h"
#include <GLFW/glfw3.h>
#include "Game.h"
using namespace CppGameEngine;

class SpaceInvadersGame : public Game {
public:
	SpaceInvadersGame();
	void PlayGame();
private:
	std::shared_ptr<Sprite> background;
	std::shared_ptr<Sprite> ship;
	std::vector<std::shared_ptr<Sprite>> enemies;
};