#pragma once
#include "Game.h"
#include <../glfw-3.2.1.bin.WIN64/include/GLFW/glfw3.h>
#include "VertexPositionUV.h"
using namespace CppGameEngine;

class FPSGame : public Game
{
public:
	FPSGame();
	void PlayGame();
	void SetUpProjectionMatrix(float nearPlane, float farPlane, float fov);
	void DrawGround();
	void DrawWall();
	void SetUpCamera();
	void KeyPressReactions();

private:
	std::shared_ptr<Texture> groundTexture;
	std::shared_ptr<Texture> wallTexture;
	VertexPositionUV aGroundVertices[6];
	VertexPositionUV aWallVertices[36];

	float playerPositionX = 0;
	float playerPositionY = 0;
	float headingInDegree = 0;
};