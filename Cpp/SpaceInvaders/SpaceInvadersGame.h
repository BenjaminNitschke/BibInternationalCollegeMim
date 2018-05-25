#pragma once
#include <GLFW/glfw3.h>
#include "Game.h"
using namespace CppGameEngine;

class SpaceInvadersGame : public Game
{
public:
	SpaceInvadersGame();
	void PlayGame();
	void ControllShip();
	void MoveEnemies();
	void MoveMissiles();
	void FireMissile();

private:
	std::shared_ptr<Sprite> background;
	std::shared_ptr<Sprite> ship;
	std::vector<std::shared_ptr<Sprite>> enemies;
	std::shared_ptr<Texture> missileTexture;
	std::vector<std::shared_ptr<Sprite>> missiles;
	float enemiesPositionX;
	bool enemiesMoveRight;
};