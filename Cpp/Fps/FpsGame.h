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
		/*
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
		*/
	}
	void CreateGround() {
		//TODO: only use 4 vertices per quad
		vertices[0] = VertexPositionUV(-10, -10, 0, 0, 0);
		vertices[1] = VertexPositionUV(10, -10, 0, 20, 0);
		vertices[2] = VertexPositionUV(10, 10, 0, 20, 20);
		vertices[3] = VertexPositionUV(-10, -10, 0, 0, 0);
		vertices[4] = VertexPositionUV(10, 10, 0, 20, 20);
		vertices[5] = VertexPositionUV(-10, 10, 0, 0, 20);
	}
	void CreateWall() {
		//TODO: only use 4 vertices per quad
		int wallVertex = 6;
		vertices[wallVertex++] = VertexPositionUV(-2, -2, 1, 0, 1);
		vertices[wallVertex++] = VertexPositionUV(-2, -2, 0, 0, 0);
		vertices[wallVertex++] = VertexPositionUV(-0.5f, -2, 1, 1, 1);
		vertices[wallVertex++] = VertexPositionUV(-2, -2, 0, 0, 0);
		vertices[wallVertex++] = VertexPositionUV(-0.5f, -2, 1, 1, 1);
		vertices[wallVertex++] = VertexPositionUV(-0.5f, -2, 0, 1, 0);
		// Create Vertex Buffer
		glGenBuffers(1, &vbo);
		// Bind Buffer
		glBindBuffer(GL_ARRAY_BUFFER, vbo);
		// Fill Buffer
		glBufferData(GL_ARRAY_BUFFER, sizeof(vertices), vertices, GL_STATIC_DRAW);

		// Create Index Buffer
		glGenBuffers(1, &ibo);
		glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, ibo);
#define INDEX_BUFFER_BYTE_SIZE sizeof(unsigned short)*2*2*3
		unsigned short indices[] = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
			//TODO: { 0, 1, 2, 0, 2, 3, 4, 5, 6, 4, 6, 7 };
		glBufferData(GL_ELEMENT_ARRAY_BUFFER, INDEX_BUFFER_BYTE_SIZE, indices, GL_STATIC_DRAW);

	}
	void PlayGame()
	{
		Run([=]() {
			CreatePerspectiveMatrix();
			SetupCamera();
			//RenderSky();
			//RenderGround();
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
		//groundShader->Use();
		glBindTexture(GL_TEXTURE_2D, groundTexture->GetHandle());
		glBegin(GL_TRIANGLES);
		for (int v = 0; v < 6; v++)
			vertices[v].Draw();
		glEnd();
	}
	void RenderWall() {
		//Creating walls(by importing a text file)
		glBindTexture(GL_TEXTURE_2D, wallTexture->GetHandle());
		/*
		glBegin(GL_TRIANGLES);
		for (int v = 6; v < sizeof(vertices) / VertexPositionUV::SizeInBytes; v++) // Rest is walls
			vertices[v].Draw();
		glEnd();
		*/
		glBindBuffer(GL_ARRAY_BUFFER, vbo);
		glClientActiveTexture(GL_TEXTURE0);
		glEnableVertexAttribArray(0);
		glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, VertexPositionUV::SizeInBytes, 0);
		glEnableVertexAttribArray(1);
		glVertexAttribPointer(1, 2, GL_FLOAT, GL_FALSE, VertexPositionUV::SizeInBytes, (void*)12);

		glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, ibo);
		glDrawElements(GL_TRIANGLES, 12, GL_UNSIGNED_SHORT, (void*)12);
		//int error = glGetError();
	}
private:
	std::shared_ptr<Texture> groundTexture;
	std::shared_ptr<Texture> wallTexture;
	unsigned int vbo;
	unsigned int ibo;
	//std::shared_ptr<Shader> groundShader;
	VertexPositionUV vertices[12];
	float playerPositionX;
	float playerPositionY;
	float headingInDegree;
};
