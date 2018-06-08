#pragma once
#include "Game.h"
#include <memory>

#include <memory>
#include <memory>
#include <memory>
#include <memory>

using namespace CppGameEngine;

class FpsGame : public Game
{
public:
	FpsGame() : Game("Fps")
	{
		groundTexture = std::make_shared<Texture>("Ground.png");
		wallTexture = std::make_shared<Texture>("Wall.png");
	}
	void PlayGame()
	{
		Run([=]() {
			glClearColor(49 / 255.0f, 90 / 255.0f, 137 / 255.0f, 1.0f);
			//Building the ground and 
			std::make_shared<Sprite>(wallTexture, 0, 0, 1, 1)->Draw();
			//Creating walls(by importing a text file)
			//Displaying 3D Walls
			//Rotate around with a camera
			//Moving around the new 3D world
			//Add some sound
		});
	}

private:
	std::shared_ptr<Texture> groundTexture;
	std::shared_ptr<Texture> wallTexture;
};
