#pragma once
#include "Game.h"
#include "VertexPositionUV.h"

using namespace CppGameEngine;

class FpsGame : public Game
{
public:
	FpsGame() : Game("Fps")
	{
		playerPositionX = 0;
		playerPositionY = 0;
		headingInDegree = 0;

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
		Run([=]() {
			// Create perspective matrix for our 3D camera
			glMatrixMode(GL_PROJECTION);
			glLoadIdentity();
			//https://www.khronos.org/registry/OpenGL-Refpages/gl2.1/xhtml/glFrustum.xml
			float zNear = 0.1f;
			float zFar = 100;
			GLfloat aspect = viewportWidth / (float)viewportHeight;
			float fov = 60.0f;
			float fovH = tan(float(fov / 360.0f * 3.14159f)) * zNear;
			float fovW = fovH * aspect;
			glFrustum(-fovW, fovW, -fovH, fovH, zNear, zFar);

			// Setup camera
			glMatrixMode(GL_MODELVIEW);
			glLoadIdentity();
			//glRotatef(360.0f - headingInDegree, 1, 0, 0);
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

			//Render sky
			glClearColor(49 / 255.0f, 90 / 255.0f, 137 / 255.0f, 1.0f);

			//Render ground
			glBindTexture(GL_TEXTURE_2D, groundTexture->GetHandle());
			glBegin(GL_TRIANGLES);
			for (int v = 0;
				v < sizeof(vertices)/VertexPositionUV::SizeInBytes;
				v++)
				vertices[v].Draw();
			glEnd();

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
	VertexPositionUV vertices[6];
	float playerPositionX;
	float playerPositionY;
	float headingInDegree;
};
