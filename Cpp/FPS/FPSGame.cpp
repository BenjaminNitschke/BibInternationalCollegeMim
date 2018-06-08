#include "stdafx.h"
#include "FPSGame.h"

using namespace CppGameEngine;

FPSGame::FPSGame() : Game("FPS Game")
{
	groundTexture = std::make_shared<Texture>("Ground.png");
	wallTexture = std::make_shared<Texture>("Wall.png");
}

void FPSGame::PlayGame()
{
	Run([=]()
	{
		glClearColor(49 / 255.0f, 90 / 255.0f, 137 / 255.0f, 1);
		//Call GameLogic
		//Call RenderCode
	});
}

void FPSGame::SetUpProjectionMatrix(float nearPlane, float farPlane, float myFov)
{
	GLfloat zNear = nearPlane;
	GLfloat zFar = farPlane;
	GLfloat aspect = (float)viewportWidth / (float)viewportHeight;
	GLfloat fov = myFov;
	GLfloat fH = tan(float(fov / 360.0f*3.14159f)) * zNear;
	GLfloat fW = fH * aspect;
	glFrustum(-fW, fW, -fH, fH, zNear, zFar);

}