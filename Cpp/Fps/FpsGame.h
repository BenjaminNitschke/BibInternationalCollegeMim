#pragma once
#include "Game.h"
#include "Texture.h"
#include "Shader.h"
#include "VertexPositionUV.h"

using namespace CppGameEngine;

class FpsGame : public Game
{
public:
	FpsGame() : Game("Fps")
	{
		playerPositionX = 0;
		playerPositionY = 0;
		headingInDegree = 180;
		LoadResources();
		CreateGround();
		CreateWall();
	}
	void LoadResources() {
		groundTexture = std::make_shared<Texture>("Ground.png");
		wallTexture = std::make_shared<Texture>("Wall.png");
		groundShader = std::make_shared<Shader>(
			// Vertex Shader
			"void main(){"
			"  gl_Position.xyz = gl_Position.xyz;//vertexPosition_modelspace;"
			"  gl_Position.w = 1.0;"
			"}",
			// Pixel Shader
			"#version 330 core"
			"out vec3 color;"
			"void main() {"
			"	color = vec3(1, 0, 0);"
			"}");
	}
	void CreateGround() {
		vertices[0] = VertexPositionUV(-10, -10, 0, 0, 0);
		vertices[1] = VertexPositionUV(10, -10, 0, 20, 0);
		vertices[2] = VertexPositionUV(10, 10, 0, 20, 20);
		vertices[3] = VertexPositionUV(-10, -10, 0, 0, 0);
		vertices[4] = VertexPositionUV(10, 10, 0, 20, 20);
		vertices[5] = VertexPositionUV(-10, 10, 0, 0, 20);
	}
	void CreateWall() {

		// A1
		int wallVertex = 6;
		vertices[wallVertex++] = VertexPositionUV(-2, -2, 1, 0, 1);
		vertices[wallVertex++] = VertexPositionUV(-2, -2, 0, 0, 0);
		vertices[wallVertex++] = VertexPositionUV(-0.5f, -2, 1, 1, 1);
		vertices[wallVertex++] = VertexPositionUV(-2, -2, 0, 0, 0);
		vertices[wallVertex++] = VertexPositionUV(-0.5f, -2, 1, 1, 1);
		vertices[wallVertex++] = VertexPositionUV(-0.5f, -2, 0, 1, 0);

		/*

		// A2
		2.0  1.0 - 2.0 2.0 1.0
		2.0  0.0 - 2.0 2.0 0.0
		0.5  0.0 - 2.0 0.5 0.0
		2.0  1.0 - 2.0 2.0 1.0
		0.5  1.0 - 2.0 0.5 1.0
		0.5  0.0 - 2.0 0.5 0.0

		// B1
		- 2.0  1.0  2.0 2.0  1.0
		- 2.0  0.0   2.0 2.0 0.0
		- 0.5  0.0   2.0 0.5 0.0
		- 2.0  1.0  2.0 2.0  1.0
		- 0.5  1.0  2.0 0.5  1.0
		- 0.5  0.0   2.0 0.5 0.0

		// B2
		2.0  1.0  2.0 2.0  1.0
		2.0  0.0   2.0 2.0 0.0
		0.5  0.0   2.0 0.5 0.0
		2.0  1.0  2.0 2.0  1.0
		0.5  1.0  2.0 0.5  1.0
		0.5  0.0   2.0 0.5 0.0

		// C1
		- 2.0  1.0 - 2.0 0.0  1.0
		- 2.0  0.0 - 2.0 0.0 0.0
		- 2.0  0.0 - 0.5 1.5 0.0
		- 2.0  1.0 - 2.0 0.0  1.0
		- 2.0  1.0 - 0.5 1.5  1.0
		- 2.0  0.0 - 0.5 1.5 0.0

		// C2
		- 2.0  1.0   2.0 2.0 1.0
		- 2.0  0.0   2.0 2.0 0.0
		- 2.0  0.0   0.5 0.5 0.0
		- 2.0  1.0  2.0 2.0 1.0
		- 2.0  1.0  0.5 0.5 1.0
		- 2.0  0.0   0.5 0.5 0.0

		// D1
		2.0  1.0 - 2.0 0.0 1.0
		2.0  0.0 - 2.0 0.0 0.0
		2.0  0.0 - 0.5 1.5 0.0
		2.0  1.0 - 2.0 0.0 1.0
		2.0  1.0 - 0.5 1.5 1.0
		2.0  0.0 - 0.5 1.5 0.0

		// D2
		2.0  1.0  2.0 2.0 1.0
		2.0  0.0   2.0 2.0 0.0
		2.0  0.0   0.5 0.5 0.0
		2.0  1.0  2.0 2.0 1.0
		2.0  1.0  0.5 0.5 1.0
		2.0  0.0   0.5 0.5 0.0

		// Upper hallway - L
		- 0.5  1.0 - 3.0 0.0 1.0
		- 0.5  0.0 - 3.0 0.0 0.0
		- 0.5  0.0 - 2.0 1.0 0.0
		- 0.5  1.0 - 3.0 0.0 1.0
		- 0.5  1.0 - 2.0 1.0 1.0
		- 0.5  0.0 - 2.0 1.0 0.0

		// Upper hallway - R
		0.5  1.0 - 3.0 0.0 1.0
		0.5  0.0 - 3.0 0.0 0.0
		0.5  0.0 - 2.0 1.0 0.0
		0.5  1.0 - 3.0 0.0 1.0
		0.5  1.0 - 2.0 1.0 1.0
		0.5  0.0 - 2.0 1.0 0.0

		// Lower hallway - L
		- 0.5  1.0  3.0 0.0 1.0
		- 0.5  0.0   3.0 0.0 0.0
		- 0.5  0.0   2.0 1.0 0.0
		- 0.5  1.0  3.0 0.0 1.0
		- 0.5  1.0  2.0 1.0 1.0
		- 0.5  0.0   2.0 1.0 0.0

		// Lower hallway - R
		0.5  1.0  3.0 0.0 1.0
		0.5  0.0   3.0 0.0 0.0
		0.5  0.0   2.0 1.0 0.0
		0.5  1.0  3.0 0.0 1.0
		0.5  1.0  2.0 1.0 1.0
		0.5  0.0   2.0 1.0 0.0

		// Left hallway - Lw
		- 3.0  1.0  0.5 1.0 1.0
		- 3.0  0.0   0.5 1.0 0.0
		- 2.0  0.0   0.5 0.0 0.0
		- 3.0  1.0  0.5 1.0 1.0
		- 2.0  1.0  0.5 0.0 1.0
		- 2.0  0.0   0.5 0.0 0.0

		// Left hallway - Hi
		- 3.0  1.0 - 0.5 1.0 1.0
		- 3.0  0.0 - 0.5 1.0 0.0
		- 2.0  0.0 - 0.5 0.0 0.0
		- 3.0  1.0 - 0.5 1.0 1.0
		- 2.0  1.0 - 0.5 0.0 1.0
		- 2.0  0.0 - 0.5 0.0 0.0

		// Right hallway - Lw
		3.0  1.0  0.5 1.0 1.0
		3.0  0.0   0.5 1.0 0.0
		2.0  0.0   0.5 0.0 0.0
		3.0  1.0  0.5 1.0 1.0
		2.0  1.0  0.5 0.0 1.0
		2.0  0.0   0.5 0.0 0.0

		// Right hallway - Hi
		3.0  1.0 - 0.5 1.0 1.0
		3.0  0.0 - 0.5 1.0 0.0
		2.0  0.0 - 0.5 0.0 0.0
		3.0  1.0 - 0.5 1.0 1.0
		2.0  1.0 - 0.5 0.0 1.0
		2.0  0.0 - 0.5 0.0 0.0
		*/
	}
	void PlayGame()
	{
		Run([=]() {
			CreatePerspectiveMatrix();
			SetupCamera();
			RenderSky();
			RenderGround();
			RenderWall();
			//Add some sound
		});
	}

	void CreatePerspectiveMatrix(){
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
	}

	void SetupCamera() {
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
		glTranslatef(-playerPositionX, -playerPositionY, -0.8f);
	}

	void RenderSky(){
		glClearColor(49 / 255.0f, 90 / 255.0f, 137 / 255.0f, 1.0f);
	}
	void RenderGround() {
		groundShader->Use();
		glBindTexture(GL_TEXTURE_2D, groundTexture->GetHandle());
		glBegin(GL_TRIANGLES);
		for (int v = 0; v < 6; v++)
			vertices[v].Draw();
		glEnd();
	}
	void RenderWall() {
		//Creating walls(by importing a text file)
		glBindTexture(GL_TEXTURE_2D, wallTexture->GetHandle());
		glBegin(GL_TRIANGLES);
		for (int v = 6; v < sizeof(vertices) / VertexPositionUV::SizeInBytes; v++) // Rest is walls
			vertices[v].Draw();
		glEnd();
	}
private:
	std::shared_ptr<Texture> groundTexture;
	std::shared_ptr<Texture> wallTexture;
	std::shared_ptr<Shader> groundShader;
	VertexPositionUV vertices[12];
	float playerPositionX;
	float playerPositionY;
	float headingInDegree;
};
