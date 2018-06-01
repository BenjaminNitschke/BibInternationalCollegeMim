#include "stdafx.h"
#include "SpaceInvadersGame.h"

using namespace CppGameEngine;

//TODO:
//1. Timed shooting
//2. Collision Detection
//3. Sprite Animations
//4. Sounds
SpaceInvadersGame::SpaceInvadersGame() : Game("Space Invaders")
{
	//------------------------------------------------------------------------------x, y, width, height
	background = std::make_shared<Sprite>(std::make_shared<Texture>("Background.png"), 0.0f, 0.0f, 1.0f, 720.0f / 1280.0f);
	ship = std::make_shared<Sprite>(std::make_shared<Texture>("Ship.png"), 0.5f - 0.1f / 2, 0.03f, 0.1f, 0.07f);

	auto enemyTexture = std::make_shared<Texture>("Enemy.png");
	missileTexture = std::make_shared<Texture>("Missile.png");

	for (float y = 0.87f; y > 0.5f; y -= 0.13f)
	for (int i = 1; i < 9; i++)
		enemies.push_back(std::make_shared<Sprite>(enemyTexture, 0.01f + i * 0.1f, y, 0.06f, 0.04f));
}

void SpaceInvadersGame::PlayGame()
{
	Run([&]()
	{
		ControllShip();
		MoveEnemies();
		MoveMissiles();

		background->Draw();
		ship->Draw();
		for (auto enemy : enemies)
			enemy->Draw(enemiesPositionX);
		for (auto missile : missiles)
			missile->Draw();
	});
}

void SpaceInvadersGame::ControllShip()
{
	const float movementPerSecond = 0.5;
	float movementPerFrame = movementPerSecond * GetTimeDelta();
	if (leftPressed && ship->GetPosX() >= 0.05f - ship->GetWidth() / 2)
		ship->SetPosX(ship->GetPosX() - movementPerFrame);
	if (rightPressed && ship->GetPosX() <= 0.95f - ship->GetWidth() / 2)
		ship->SetPosX(ship->GetPosX() + movementPerFrame);
	float cooldown = 0.5;
	elapsedTime += GetTimeDelta();
	if (spacePressed && elapsedTime >= cooldown)
	{
		FireMissile();
		elapsedTime = 0;
	}
		
}

void SpaceInvadersGame::FireMissile()
{
	missiles.push_back(std::make_shared<Sprite>(missileTexture,
		ship->GetPosX()+ship->GetWidth()/2, ship->GetPosY()+ship->GetHeight(),
		0.04f, 0.04f));
}

void SpaceInvadersGame::MoveEnemies()
{
	const float movementPerSecond = 0.1234;
	float movementPerFrame = movementPerSecond * GetTimeDelta();
	if (enemiesPositionX > 0.1f)
		enemiesMoveRight = false;
	else if (enemiesPositionX < -0.1f)
		enemiesMoveRight = true;
	enemiesPositionX += (enemiesMoveRight ? 1:-1)*movementPerFrame;
}

void SpaceInvadersGame::MoveMissiles()
{
	const float movementPerSecond = 0.2;
	float movementPerFrame = movementPerSecond * GetTimeDelta();
	for (auto missile : missiles) {
		float currentX = missile->GetPosX();
		float currentY = missile->GetPosY() + movementPerFrame;
		missile->SetPosY(currentY);
		for (auto enemy : enemies) {
			if (currentX > enemy->GetPosX() + enemiesPositionX &&
				currentX < enemy->GetPosX() + enemiesPositionX + enemy->GetWidth() &&
				currentY > enemy->GetPosY() &&
				currentY < enemy->GetPosY() + enemy->GetHeight())
				enemy->SetPosY(-1);
		}
	}
}