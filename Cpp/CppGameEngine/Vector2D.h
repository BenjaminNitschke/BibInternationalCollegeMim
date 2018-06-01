#pragma once

class Vector2D {
public:
	float X;
	float Y;

	Vector2D(float x, float y) : X(x), Y(y) {}

	Vector2D operator+(const Vector2D other)
	{
		return Vector2D(X + other.X, Y + other.Y);
	}

	float DistanceToSquared(Vector2D other) {
		float xDistance = other.X - X;
		float yDistance = other.Y - Y;
		return xDistance * xDistance + yDistance * yDistance;
	}
};