#pragma once
#include "Game.h"
#include <memory>
#include "VertexPositionUV.h"

using namespace CppGameEngine;

class FpsGame : public Game
{
public:
	FpsGame() : Game("Fps")
	{
		playerPositionX = 0.f;
		playerPositionY = 0.f;
		headingInDegree = 0.f;

		groundTexture = std::make_shared<Texture>("Ground.png");
		wallTexture = std::make_shared<Texture>("Wall.png");

		vertices[0] = VertexPositionUV(-100, -100, 0, 0, 0);
		vertices[1] = VertexPositionUV(100, -100, 0, 20, 0);
		vertices[2] = VertexPositionUV(100, 100, 0, 20, 20);
		vertices[3] = VertexPositionUV(-100, -100, 0, 0, 0);
		vertices[4] = VertexPositionUV(100, 100, 0, 20, 20);
		vertices[5] = VertexPositionUV(-100, 100, 0, 0, 20);
	}
	void PlayGame()
	{
		Run([=]()
		{
			glMatrixMode(GL_PROJECTION);
			glLoadIdentity();
			GLfloat zNear = 0.1f;
			GLfloat zFar = 100.f;
			GLfloat aspect = viewportWidth / (GLfloat)viewportHeight;
			GLfloat fov = 60.f;
			GLfloat fovH = tan(GLfloat(fov / 360.f * 3.14159f)) * zNear;
			GLfloat fovW = fovH * aspect;
			glFrustum(-fovW, fovW, -fovH, fovH, zNear, zFar);

			//setup camera
			glMatrixMode(GL_MODELVIEW);
			glLoadIdentity();

			if (leftPressed)
				headingInDegree -= GetTimeDelta() * 90;
			else if (rightPressed)
				headingInDegree += GetTimeDelta() * 90;
			const float DegreeToRadians = 3.14159f / 180.0f;
			float movement = 0;
			if (upPressed)
				movement = 1;
			else if (downPressed)
				movement = -1;
			playerPositionX +=
				sin(headingInDegree * DegreeToRadians) *
				GetTimeDelta() * 5 * movement;
			playerPositionY +=
				cos(headingInDegree * DegreeToRadians) *
				GetTimeDelta() * 5 * movement;

			glRotatef(270, 1, 0, 0);
			glRotatef(headingInDegree, 0, 0, 1);
			glTranslatef(-playerPositionX, -playerPositionY, -1.8f);

			//render sky
			glClearColor(49 / 255.0f, 90 / 255.0f, 137 / 255.0f, 1.0f);

			//render ground
			glBindTexture(GL_TEXTURE_2D, groundTexture->GetHandle());
			glEnable(GL_TEXTURE_2D);
			glBegin(GL_TRIANGLES);
			for (int v = 0; v < sizeof(vertices) / VertexPositionUV::SizeInBytes; v++)
			{
				vertices[v].Draw();
			}
			glEnd();
		});
	}

private:
	std::shared_ptr<Texture> groundTexture;
	std::shared_ptr<Texture> wallTexture;
	VertexPositionUV vertices[6];
	GLfloat playerPositionX;
	GLfloat playerPositionY;
	GLfloat headingInDegree;
};