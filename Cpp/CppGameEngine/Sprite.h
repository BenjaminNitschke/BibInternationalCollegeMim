#pragma once
#include <memory>
#include "Texture.h"
#include "Vector2D.h"

namespace CppGameEngine
{
	class Sprite
	{
	public:
		// Since we did not touch viewport matrices, the screen goes from -1 to +1, which is 2.0 and we
		// multiply heights by 2, so 2, 1 is required to fill the whole screen with this code.
		Sprite(std::shared_ptr<Texture> texture, float x, float y, float width, float height)
			: texture(texture), initialX(x), initialY(y), width(width), height(height * 2.0f) {}

		void Draw(float x = 0.0f, float y = 0.0f);

		void SetAspectRatio(float setHeight) {
			height = setHeight;
		}
		void setPosX(float posX) { initialX = posX; };
		void setPosY(float posY) { initialY = posY; };
		void setPosition(Vector2D position) { initialX = position.x; initialY = position.y; }
		float getPosX() { return initialX; };
		float getPosY() { return initialY; };

		Vector2D getPosition() { return Vector2D(initialX, initialY); }
		float GetWidth() { return width; }
		float GetHeight() { return height; }
		bool IncreaseY(float amount) { initialY += amount; return initialY > 1.0f; }

		float DistanceTo(std::shared_ptr<Sprite> other, float xOffset)
		{
			float distanceX = abs(initialX + xOffset - other->initialX);
			float distanceY = abs(initialY - other->initialY);
			return sqrt(distanceX*distanceX + distanceY*distanceY);
		}
		
	protected:
		std::shared_ptr<Texture> texture;
		float initialX;
		float initialY;
		float width;
		float height;
	};
}