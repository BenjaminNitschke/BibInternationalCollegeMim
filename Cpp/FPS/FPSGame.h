#pragma once
#include "Game.h"
#include <../glfw-3.2.1.bin.WIN64/include/GLFW/glfw3.h>
using namespace CppGameEngine;

class FPSGame : public Game
{
public:
	FPSGame();
	void PlayGame();
	void SetUpProjectionMatrix(float nearPlane, float farPlane, float fov);

private:
	std::shared_ptr<Texture> groundTexture;
	std::shared_ptr<Texture> wallTexture;
};