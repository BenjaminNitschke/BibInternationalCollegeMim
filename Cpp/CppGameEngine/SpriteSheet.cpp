#include "SpriteSheet.h"

using namespace CppGameEngine;


double animationTime = 0;
int animationFrame = 0;

void SpriteSheet::Draw(float x, float y)
{
	glBindTexture(GL_TEXTURE_2D, texture->GetHandle());
	glEnable(GL_TEXTURE_2D);
	glBegin(GL_QUADS);
	animationTime = (float)glfwGetTime();
	animationFrame = (int)(animationTime * 24);
	int col = animationFrame % NumberOfColumns;
	int row = (animationFrame / NumberOfColumns) % NumberOfRows;
	float u1 = col / (float)NumberOfColumns;
	float v1 = row / (float)NumberOfRows;
	float u2 = u1 + (1.0f / NumberOfColumns);
	float v2 = v1 + (1.0f / NumberOfRows);
	glTexCoord2d(u1, 1 - v1);
	glVertex3f(-1 + (initialX + x) * 2, -1 + (initialY + y) * 2, 0);
	glTexCoord2d(u2, 1 - v1);
	glVertex3f(-1 + (initialX + x + width) * 2, -1 + (initialY + y) * 2, 0);
	glTexCoord2d(u2, 1 - v2);
	glVertex3f(-1 + (initialX + x + width) * 2, -1 + (initialY + y + height) * 2, 0);
	glTexCoord2d(u1, 1 - v2);
	glVertex3f(-1 + (initialX + x) * 2, -1 + (initialY + y + height) * 2, 0);
	glEnd();
}