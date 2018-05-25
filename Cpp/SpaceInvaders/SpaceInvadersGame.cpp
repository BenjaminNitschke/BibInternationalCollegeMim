#include "stdafx.h"
#include "SpaceInvadersGame.h"
#include <../glfw-3.2.1.bin.WIN64/include/GLFW/glfw3.h>
#include "Game.h"
using namespace CppGameEngine;

SpaceInvadersGame::SpaceInvadersGame() : Game("Space Invaders")
{
	int enemyNumber = 10;
	background = std::make_shared<Sprite>(std::make_shared<Texture>("Background.png"), 0, 0, 1.0f, 720.0f / 1280.0f);
	ship = std::make_shared<Sprite>(std::make_shared<Texture>("player_ship.png"), 0.5 - 0.07 / 2, 0.1 - 0.07 / 2, 0.07, 0.07);
	enemyTexture = std::make_shared<Texture>("spacecraft.png");
	for (int i = 0; i < enemyNumber; i++)
	{
		enemies.push_back(std::make_shared<Sprite>(enemyTexture, 0.05 + i * 0.1 - 0.05 / 2, 0.9 - 0.05 / 2, 0.05, 0.05));
	}
}
void SpaceInvadersGame::PlayGame()
{
	Run([&]() {
		background->Draw();
		ship->Draw();
		for (auto enemy : enemies)
		{
			enemy->Draw();
		}
	});
}