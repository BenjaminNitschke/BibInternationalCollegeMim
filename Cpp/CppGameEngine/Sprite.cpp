#include "Sprite.h"
#include <GLFW/glfw3.h>
#include <GL/gl.h>

using namespace CppGameEngine;

void Sprite::Draw(float x, float y)
{
	glBindTexture(GL_TEXTURE_2D, texture->GetHandle());
	glEnable(GL_TEXTURE_2D);
	glBegin(GL_QUADS);
	float u1 = 0;
	float v1 = 0;
	float u2 = 1;
	float v2 = 1;
	glTexCoord2d(u1, v1);
	glVertex3f(-1 + (initialX + x) * 2, -1 + (initialY + y) *2, 0);
	glTexCoord2d(u2, v1);
	glVertex3f(-1 + (initialX + x + width) * 2, -1 + (initialY + y) * 2, 0);
	glTexCoord2d(u2, v2);
	glVertex3f(-1 + (initialX + x + width) * 2, -1 + (initialY + y + height) * 2, 0);
	glTexCoord2d(u1, v2);
	glVertex3f(-1 + (initialX + x) * 2, -1 + (initialY + y + height) *2, 0);
	glEnd();
}