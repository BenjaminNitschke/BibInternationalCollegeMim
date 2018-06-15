#pragma once
#include "Header_Includes.h"
#include "Sprite.h"
namespace CppGameEngine
{
	class SpriteSheet : public Sprite
	{
	public:
		SpriteSheet(std::shared_ptr<Texture> texture, float x, float y,
			float width, float height, int numberOfColumns, int numberOfRows)
			: Sprite(texture, x, y, width, height),
			NumberOfColumns(numberOfColumns), NumberOfRows(numberOfRows)
		{
		}

		void Draw(float x = 0.0f, float y = 0.0f);

	private:
		int NumberOfColumns;
		int NumberOfRows;
		float animationTime;
	};
}