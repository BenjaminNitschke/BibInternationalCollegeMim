#include "stdafx.h"
#include "FPSGame.h"

using namespace CppGameEngine;

FPSGame::FPSGame() : Game("FPS Game")
{
	groundTexture = std::make_shared<Texture>("Ground.png");
	wallTexture = std::make_shared<Texture>("Wall.png");
	LoadResources();
	CreateGround();
	CreateWall();
}

void FPSGame::LoadResources()
{
	groundShader = std::make_shared<Shader>("" "void main(){"
		" gl_Position.xyz = gl.Position.xyz;//vertexPosition_modelspace;"
		" gl_Position.w = 1.0;"
		"}",
		"#version 330 core"
		"put vec3 color;"
		"void main(){"
		" color = vec3(1,0,0);"
		"}");
	CreateGround();
	CreateWall();
}

void FPSGame::PlayGame()
{
	Run([=]()
	{
		KeyPressReactions();
		//Drawing the Sky
		glClearColor(49 / 255.0f, 90 / 255.0f, 137 / 255.0f, 1);
		SetUpProjectionMatrix(1, 100, 60);
		SetUpCamera();
		groundShader->Use();
		DrawGround();
		DrawWall();
	});
}

void FPSGame::CreateGround()
{
	aGroundVertices[0] = VertexPositionUV(-10, -10, 0, 0, 0);
	aGroundVertices[1] = VertexPositionUV(10, -10, 0, 20, 0);
	aGroundVertices[2] = VertexPositionUV(10, 10, 0, 20, 20);
	aGroundVertices[3] = VertexPositionUV(-10, -10, 0, 0, 0);
	aGroundVertices[4] = VertexPositionUV(10, 10, 0, 20, 20);
	aGroundVertices[5] = VertexPositionUV(-10, 10, 0, 0, 20);
}

void FPSGame::CreateWall()
{
	//Front
	aWallVertices[0] = VertexPositionUV(0, 0, 0, 0, 0);
	aWallVertices[1] = VertexPositionUV(0, 0, 1, 0, 1);
	aWallVertices[2] = VertexPositionUV(0, 1, 1, 1, 1);
	aWallVertices[3] = VertexPositionUV(0, 0, 0, 0, 0);
	aWallVertices[4] = VertexPositionUV(0, 1, 1, 1, 1);
	aWallVertices[5] = VertexPositionUV(0, 1, 0, 1, 0);

	//Up
	aWallVertices[6] = VertexPositionUV(0, 0, 1, 0, 0);
	aWallVertices[7] = VertexPositionUV(1, 0, 1, 0, 1);
	aWallVertices[8] = VertexPositionUV(1, 1, 1, 1, 1);
	aWallVertices[9] = VertexPositionUV(0, 0, 1, 0, 0);
	aWallVertices[10] = VertexPositionUV(1, 1, 1, 1, 1);
	aWallVertices[11] = VertexPositionUV(0, 1, 1, 1, 0);

	//Back
	aWallVertices[12] = VertexPositionUV(1, 1, 1, 0, 0);
	aWallVertices[13] = VertexPositionUV(1, 1, 0, 0, 1);
	aWallVertices[14] = VertexPositionUV(1, 0, 0, 1, 1);
	aWallVertices[15] = VertexPositionUV(1, 1, 1, 0, 0);
	aWallVertices[16] = VertexPositionUV(1, 0, 0, 1, 1);
	aWallVertices[17] = VertexPositionUV(1, 0, 1, 1, 0);

	//Right
	aWallVertices[18] = VertexPositionUV(0, 0, 0, 0, 0);
	aWallVertices[19] = VertexPositionUV(0, 0, 1, 0, 1);
	aWallVertices[20] = VertexPositionUV(1, 0, 1, 1, 1);
	aWallVertices[21] = VertexPositionUV(0, 0, 0, 0, 0);
	aWallVertices[22] = VertexPositionUV(1, 0, 1, 1, 1);
	aWallVertices[23] = VertexPositionUV(1, 0, 0, 1, 0);

	//Left
	aWallVertices[24] = VertexPositionUV(0, 1, 0, 0, 0);
	aWallVertices[25] = VertexPositionUV(0, 1, 1, 0, 1);
	aWallVertices[26] = VertexPositionUV(1, 1, 1, 1, 1);
	aWallVertices[27] = VertexPositionUV(0, 1, 0, 0, 0);
	aWallVertices[28] = VertexPositionUV(1, 1, 1, 1, 1);
	aWallVertices[29] = VertexPositionUV(1, 1, 0, 1, 0);
}
void FPSGame::SetUpProjectionMatrix(float nearPlane, float farPlane, float fov)
{
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	float aspect = (float)viewportWidth / (float)viewportHeight;
	float fovHeight = tan(float(fov / 360.0f*3.14159f)) * nearPlane;
	float fovWidth = fovHeight * aspect;
	glFrustum(-fovWidth, fovWidth, -fovHeight, fovHeight, nearPlane, farPlane);
}

void FPSGame::SetUpCamera()
{
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
	glRotatef(270, 1, 0, 0);
	glRotatef(-headingInDegree, 0, 0, 1);
	glTranslatef(playerPositionX, playerPositionY, -1.8f);
}

void FPSGame::DrawGround()
{
	glBindTexture(GL_TEXTURE_2D, groundTexture->GetHandle());
	glBegin(GL_TRIANGLES);
	for (int v = 0; v < sizeof(aGroundVertices) / VertexPositionUV::SizeInBytes; v++)
	{
		aGroundVertices[v].Draw();
	}
	glEnd();
}

void FPSGame::DrawWall()
{
	glEnable(GL_TEXTURE_2D);
	glBindTexture(GL_TEXTURE_2D, wallTexture->GetHandle());
	glBegin(GL_TRIANGLES);
	for (int v = 0; v < sizeof(aWallVertices) / VertexPositionUV::SizeInBytes; v++)
	{
		aWallVertices[v].Draw();
	}
	glEnd();
}

void FPSGame::KeyPressReactions()
{
	const float cDegreeToRadiant = 3.14159 / 180.0f;
	float movement = 0;
	if (leftPressed)
		headingInDegree += GetTimeDelta() * 90;
	else if (rightPressed)
		headingInDegree -= GetTimeDelta() * 90;
	if (upPressed)
		movement = 1;
	else if (downPressed)
		movement = -1;
	playerPositionX += sin(headingInDegree * cDegreeToRadiant) * GetTimeDelta() * 5 * movement;
	playerPositionY += cos(headingInDegree * cDegreeToRadiant) * GetTimeDelta() * 5 * -movement;
}