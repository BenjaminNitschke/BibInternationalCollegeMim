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
		CheckIfNoError();
		wallTexture = std::make_shared<Texture>("Wall.png");
		CheckIfNoError();
		groundShader = std::make_shared<Shader>(
			// Vertex Shader
			"uniform mat4 perspective;"
			"uniform mat4 view;"
			"void main(){"
			"  gl_Position.xyz = gl_Position.xyz * perspective;"
			"  gl_Position.xyz = gl_Position.xyz * view;"
			"  gl_Position.w = 1.0;"
			"}",
			// Pixel Shader
			"#version 330 core"
			"out vec3 color;"
			"void main() {"
			"	color = vec3(1, 0, 0);"
			"}");
		CheckIfNoError();
	}
	void CreateGround() {
		vertices[0] = VertexPositionUV(-10, -10, 0, 0, 0);
		vertices[1] = VertexPositionUV(10, -10, 0, 20, 0);
		vertices[2] = VertexPositionUV(10, 10, 0, 20, 20);
		vertices[3] = VertexPositionUV(-10, 10, 0, 0, 20);
	}
	void CreateWall() {
		vertices[4] = VertexPositionUV(-2, -2, 1, 0, 1);
		vertices[5] = VertexPositionUV(-2, -2, 0, 0, 0);
		vertices[6] = VertexPositionUV(-0.5f, -2, 1, 1, 1);
		vertices[7] = VertexPositionUV(-0.5f, -2, 0, 1, 0);
		// Create Vertex Buffer
		glGenBuffers(1, &vbo);
		CheckIfNoError();
		// Bind Buffer
		glBindBuffer(GL_ARRAY_BUFFER, vbo);
		// Fill Buffer
		glBufferData(GL_ARRAY_BUFFER, sizeof(vertices), vertices, GL_STATIC_DRAW);

		// Create Index Buffer
		glGenBuffers(1, &ibo);
		glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, ibo);
#define INDEX_BUFFER_BYTE_SIZE sizeof(unsigned short)*2*2*3
		unsigned short indices[] = { 0, 1, 2, 0, 2, 3, 4, 5, 6, 5, 6, 7 };
			//TODO: { 0, 1, 2, 0, 2, 3, 4, 5, 6, 4, 6, 7 };
		glBufferData(GL_ELEMENT_ARRAY_BUFFER, INDEX_BUFFER_BYTE_SIZE, indices, GL_STATIC_DRAW);
		CheckIfNoError();
		
		// Set Vertex Format
		glEnableVertexAttribArray(0);
		glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, VertexPositionUV::SizeInBytes, 0);
		glEnableVertexAttribArray(1);
		glVertexAttribPointer(1, 2, GL_FLOAT, GL_FALSE, VertexPositionUV::SizeInBytes, (void*)(3 * sizeof(float)));

		CheckIfNoError();
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

		glGetFloatv(GL_PROJECTION_MATRIX, perspective);
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

		glGetFloatv(GL_MODELVIEW_MATRIX, view);
	}

	void RenderSky(){
		glClearColor(49 / 255.0f, 90 / 255.0f, 137 / 255.0f, 1.0f);
		CheckIfNoError();
	}
	void RenderGround() {
		//glColor3f(0, 0, 1);
		// Set Shader to use
		groundShader->Use();
		CheckIfNoError();
		// Specify vertex attributes to be used (position and uv)
		glGetAttribLocation(groundShader->GetHandle(), "position");
		glGetAttribLocation(groundShader->GetHandle(), "uv");
		CheckIfNoError();
		// Set perspective and view matrix for vertex shader to calculate pixel pos
		glUniformMatrix4fv(
			glGetUniformLocation(groundShader->GetHandle(), "perspective"),
			1, false, perspective);
		CheckIfNoError();
		glUniformMatrix4fv(
			glGetUniformLocation(groundShader->GetHandle(), "view"),
			1, false, view);
		CheckIfNoError();

		glBindTexture(GL_TEXTURE_2D, groundTexture->GetHandle());
		glBindBuffer(GL_ARRAY_BUFFER, vbo);
		glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, ibo);
		glDrawElements(GL_TRIANGLES, 2*3, GL_UNSIGNED_SHORT, (void*)0);
		CheckIfNoError();
	}
	void CheckIfNoError() {
		int error = glGetError();
//#define GL_INVALID_ENUM 0x0500 = 1280
//#define GL_INVALID_VALUE 0x0501 = 1281
//#define GL_INVALID_OPERATION 0x0502 = 1282
//#define GL_STACK_OVERFLOW 0x0503
//#define GL_STACK_UNDERFLOW 0x0504
//#define GL_OUT_OF_MEMORY 0x0505
		if (error != GL_NO_ERROR)
			throw error;
	}
	void RenderWall() {
		CheckIfNoError();
		glBindTexture(GL_TEXTURE_2D, wallTexture->GetHandle());
		glBindBuffer(GL_ARRAY_BUFFER, vbo);
		glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, ibo);
		glDrawElements(GL_TRIANGLES, 2*3, GL_UNSIGNED_SHORT, (void*)(2*3*2));
		CheckIfNoError();
	}
private:
	std::shared_ptr<Texture> groundTexture;
	std::shared_ptr<Texture> wallTexture;
	unsigned int vbo;
	unsigned int ibo;
	std::shared_ptr<Shader> groundShader;
	VertexPositionUV vertices[8];
	float playerPositionX;
	float playerPositionY;
	float headingInDegree;
	float perspective[16];
	float view[16];
};
