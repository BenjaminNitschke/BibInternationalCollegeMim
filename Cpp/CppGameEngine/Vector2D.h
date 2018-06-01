#pragma once

class Vector2D
{
public:
	float x;
	float y;

	Vector2D(float setX, float setY) : x(setX), y(setY) {}

	Vector2D operator+(const Vector2D other)
	{
		return Vector2D(x + other.x, y + other.y);
	}

	float DistanceToSquared(Vector2D other)
	{
		float xDistance = other.x - this->x;
		float yDistance = other.y - this->y;
		return xDistance * xDistance + yDistance * yDistance;
	}
};
