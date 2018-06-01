#include "stdafx.h"
#include "Space_Invaders_JH.h"
#include "Vector2D.h"

SpaceInvadersGame::SpaceInvadersGame() : Game("Space Invaders")
{
	background = std::make_shared<Sprite>(std::make_shared<Texture>("Background.png"),
		0.0f, 0.0f, 1.0f, 720.0f / 1280.0f);
	ship = std::make_shared<Sprite>(std::make_shared<Texture>("ship.png"),
		0.45f, 0.01f, 0.1f, 0.1f);
	auto enemyTexture = std::make_shared<Texture>("ship.png");
	bulletTexture = std::make_shared<Texture>("bullet.png");
	explosionTexture = std::make_shared<Texture>("explosion.png");
	explosion = std::make_shared<SpriteSheet>(explosionTexture,
		0.2f, 0.3f, 0.1f, 0.1f, 47, 1);


	for (float y = 0.9f; y > 0.5f; y -= 0.13f)
		for (int i = 1; i < 9; i++)
		{
			enemies.push_back(std::make_shared<Sprite>(enemyTexture, 0.05f + i * 0.1f - 0.05f / 2.f, y, 0.05f, 0.05f));
		}
	//for (int i = 1; i < 9; i++)
		/*enemies.push_back(std::make_shared<Sprite>(enemyTexture, -0.f + i * 0.11f, 0.8f, 0.06f, 0.04f));*/

	shipPositionX = 0.f;
	shipPositionY = 0.f;
}

void SpaceInvadersGame::PlayGame()
{
	Run([&]()
	{
		background->Draw();
		ship->Draw();
		explosion->Draw();


		for (auto enemy : enemies)
			enemy->Draw(enemiesPositionX, enemiesPositionY);
		for (auto bullet : bullets)
			bullet->Draw();

		ControlShip();
		MoveEnemies();
		MoveBullets();
	});
}

#define SHOOTINGDELAY 0.5

void SpaceInvadersGame::ControlShip()
{
	timePassed = timePassed + GetTimeDelta();
	const float movementPerSecond = 1.0f / 2.5f;
	float movementPerFrame = movementPerSecond * GetTimeDelta();

	if (leftPressed && ship->getPosX() >= 0.05 - ship->GetWidth() / 2)
		ship->setPosX(ship->getPosX() - movementPerFrame);
	if (rightPressed && ship->getPosX() <= 0.95 - ship->GetWidth() / 2)
		ship->setPosX(ship->getPosX() + movementPerFrame);

	if (spacePressed && timePassed >= SHOOTINGDELAY)
	{
		FireBullets();
		timePassed = 0.f;
	}
}

void SpaceInvadersGame::FireBullets()
{
	bullets.push_back(std::make_shared<Sprite>(bulletTexture, ship->getPosX() + ship->GetWidth() / 2.f - 0.01f / 2.f, ship->getPosY() + ship->GetHeight() - 0.01f / 2, 0.01f, 0.01f));
}

void SpaceInvadersGame::MoveBullets()
{
	if (bullets.size() == 0)
		return;

	const float movementPerSecond = 1.f;
	float movementPerFrame = movementPerSecond * GetTimeDelta();
	float bulletRadius = bullets[0]->GetWidth() / 2;
	float enemyRadius = enemies[0]->GetWidth() / 2;
	float squaredMinimumDistance = (bulletRadius + enemyRadius) * (bulletRadius + enemyRadius);

	for (auto bullet : bullets)
	{
		Vector2D current = bullet->getPosition() + Vector2D(0, movementPerFrame);
		bullet->setPosition(current);


		//collision, TODO: circle check
		//TODO:	Sprite Animations
		//for (auto enemy : enemies)
		//{
		//	if (current.x > enemy->getPosition().x + enemiesPositionX &&
		//		current.x < enemy->getPosition().x + enemiesPositionX + enemy->GetWidth() &&
		//		current.y > enemy->getPosition().y &&
		//		current.y < enemy->getPosition().y + enemy->GetHeight())
		//		enemy->setPosY(-1);
		//}

		for (auto enemy : enemies)
		{
			if (current.DistanceToSquared(enemy->getPosition() + Vector2D(enemiesPositionX, 0) + Vector2D(enemy->GetWidth() / 4, 0)) < squaredMinimumDistance)
			{
				enemy->setPosY(-1);
				bullet->setPosY(1);
			}					
		}
	}
}

void SpaceInvadersGame::MoveEnemies()
{

	const float movementPerSecond = 0.1234f;
	float movementPerFrame = movementPerSecond * GetTimeDelta();

	if (enemiesPositionX > 0.1f)
		enemiesMoveRight = false;
	if (enemiesPositionX < -0.1f)
		enemiesMoveRight = true;
	enemiesPositionX += (enemiesMoveRight ? 1 : -1) * movementPerFrame;

	//float pos = enemies[0]->getPosX();

	//WCHAR buffer[128];
	//swprintf(buffer, 128, L"pos=%f\n", pos);
	//OutputDebugString(buffer);
}