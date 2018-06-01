#pragma once
#include "stdafx.h"
#include <GLFW/glfw3.h>
#include "Game.h"
#include "Texture.h"
#include "SpriteSheet.h"

using namespace CppGameEngine;

class SpaceInvadersGame : public Game
{
public:
	SpaceInvadersGame();
	void PlayGame();
	void ControlShip();
	void MoveEnemies();
	void FireBullets();
	void MoveBullets();

private:
	std::shared_ptr<Sprite> background;
	std::shared_ptr<Sprite> ship;
	std::shared_ptr<SpriteSheet> explosion;
	std::vector<std::shared_ptr<Sprite>> enemies;
	std::vector<std::shared_ptr<Sprite>> bullets;
	std::shared_ptr<Texture> bulletTexture;
	std::shared_ptr<Texture> explosionTexture;
	float shipPositionX;
	float shipPositionY;
	float enemiesPositionX;
	float enemiesPositionY;
	float timePassed;
	bool enemiesMoveRight;
};
