#include "stdafx.h"
#include "Space_Invaders_JH.h"

SpaceInvadersGame::SpaceInvadersGame() : Game("Space Invaders")
{
	background = std::make_shared<Sprite>(std::make_shared<Texture>("Background.png"),
		0.0f, 0.0f, 1.0f, 720.0f / 1280.0f);
	ship = std::make_shared<Sprite>(std::make_shared<Texture>("ship.png"),
		0.45f, 0.01f, 0.1f, 0.1f);
	auto enemyTexture = std::make_shared<Texture>("ship.png");
	for (int i = 1; i < 9; i++)
		enemies.push_back(std::make_shared<Sprite>(enemyTexture, -0.f + i * 0.11f, 0.8f, 0.06f, 0.04f));
	shipPositionX = 0.f;
	shipPositionY = 0.f;
}

void SpaceInvadersGame::PlayGame() 
{
	Run([&]() 
	{
		background->Draw();
		ship->Draw();
		for (auto enemy : enemies)
			enemy->Draw();
		ControlShip();
	});
}

void SpaceInvadersGame::ControlShip()
{
	//ship = std::make_shared<Sprite>(std::make_shared<Texture>("ship.png"),
	//		0.f, 0.f, 0.1f, 0.1f);
	if (leftPressed && ship->getPosX() >= 0)
	{
		shipPositionX -= 0.001f;
	}
	else if (rightPressed && ship->getPosY() >= 0)
	{
		shipPositionX += 0.001f;
	}

	ship->setPosX(shipPositionX);
	ship->setPosY(shipPositionY);
}

void SpaceInvadersGame::MoveEnemies()
{
	float pos = enemies[0]->getPosX();


	WCHAR buffer[128];
	swprintf(buffer, 128, L"pos=%f\n", pos);
	OutputDebugString(buffer);
}