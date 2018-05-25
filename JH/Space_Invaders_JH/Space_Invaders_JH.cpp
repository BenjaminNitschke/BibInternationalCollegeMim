#include "stdafx.h"
#include "Space_Invaders_JH.h"

SpaceInvadersGame::SpaceInvadersGame() : Game("Space Invaders")
{
	background = std::make_shared<Sprite>(std::make_shared<Texture>("Background.png"),
		0.0f, 0.0f, 1.0f, 720.0f / 1280.0f);
	ship = std::make_shared<Sprite>(std::make_shared<Texture>("ship.png"),
		0.45f, 0.01f, 0.1f, 0.1f);
	auto enemyTexture = std::make_shared<Texture>("ship.png");
	for (int i = 0; i < 10; i++)
		enemies.push_back(std::make_shared<Sprite>(enemyTexture, -0.9f + i * 0.2f, 0.8f, 0.08f, 0.08f));
	shipPosition = 0.f;
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
	if (leftPressed)
	{
		shipPosition += 0.01f;
	}

	ship
}