#include "stdafx.h"
#include "SpaceInvadersGame.h"

using namespace CppGameEngine;

SpaceInvadersGame::SpaceInvadersGame() : Game("Space Invaders")
{
	int enemyNumber = 9;
	background = std::make_shared<Sprite>(std::make_shared<Texture>("Background.png"), 0, 0, 1.0f, 720.0f / 1280.0f);
	ship = std::make_shared<Sprite>(std::make_shared<Texture>("player_ship.png"), 0.5 - 0.07 / 2, 0.1 - 0.07 / 2, 0.07, 0.07);
	enemyTexture = std::make_shared<Texture>("spacecraft.png");

	for (float y = 0.9f; y>0.5f;y-=0.13f)
	for (int i = 1; i < enemyNumber; i++)
	{
		enemies.push_back(std::make_shared<Sprite>(enemyTexture, 0.05 + i * 0.1 - 0.05 / 2, y, 0.05, 0.05));
	}
}

void SpaceInvadersGame::PlayGame()
{
	Run([&]()
	{
		MoveShip();
		MoveEnemies();
		background->Draw();
		ship->Draw();
		for (auto enemy : enemies)
		{
			enemy->Draw();
		}
	});
}
void SpaceInvadersGame::MoveShip()
{
	const float movementPerSecond = 1.0f / 2.5f;
	float movementPerFrame = movementPerSecond * GetTimeDelta();

	if (leftPressed && ship->GetXPos() >= 0.05 - ship->GetWidth() / 2)
		ship->SetXPos(ship->GetXPos() - movementPerFrame);
	if (rightPressed && ship->GetXPos() <= 0.95 - ship->GetWidth() / 2)
		ship->SetXPos(ship->GetXPos() + movementPerFrame);
}
void SpaceInvadersGame::MoveEnemies()
{
	float pos = enemies[0]->GetXPos();
	WCHAR buffer[128];
	wsprintf(buffer, L"pos: %d", pos);
	OutputDebugString(buffer);
}