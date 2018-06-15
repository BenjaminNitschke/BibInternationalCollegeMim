#pragma once
#include "Shader.h"
#include "Game.h"
#include <../glfw-3.2.1.bin.WIN64/include/GLFW/glfw3.h>
#include "VertexPositionUV.h"
#include "Texture.h"
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
	void CreateGround();
	void CreateWall();
	void LoadResources();

private:
	std::shared_ptr<Texture> groundTexture;
	std::shared_ptr<Texture> wallTexture;
	std::shared_ptr<Shader> groundShader;
	VertexPositionUV aGroundVertices[6];
	VertexPositionUV aWallVertices[36];

	float playerPositionX = 0;
	float playerPositionY = 0;
	float headingInDegree = 0;
};