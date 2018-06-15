#include "Sprite.h"

using namespace CppGameEngine;

void Sprite::Draw(float x, float y)
{
	glBindTexture(GL_TEXTURE_2D, texture->GetHandle());
	glEnable(GL_TEXTURE_2D);
	glBegin(GL_QUADS);
	glTexCoord2d(0, 0);
	glVertex3f(-1 + (initialX + x) * 2, -1 + (initialY + y) * 2, 0);
	glTexCoord2d(1, 0);
	glVertex3f(-1 + (initialX + x + width) * 2, -1 + (initialY + y) * 2, 0);
	glTexCoord2d(1, 1);
	glVertex3f(-1 + (initialX + x + width) * 2, -1 + (initialY + y + height) * 2, 0);
	glTexCoord2d(0, 1);
	glVertex3f(-1 + (initialX + x) * 2, -1 + (initialY + y + height) * 2, 0);
	glEnd();
}