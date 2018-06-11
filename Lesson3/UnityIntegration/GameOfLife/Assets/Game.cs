public class Game
{
	public Game(int width, int height)
	{
		Width = width;
		Height = height;
		before = new bool[width, height];
		current = new bool[width, height];
	}

	public int Width { get; private set; }
	public int Height { get; private set; }
	private bool[,] before;
	private bool[,] current;

	public bool IsAlive(int x, int y)
	{
		return current[x, y];
	}

	public void Set(int x, int y, bool value)
	{
		current[x, y] = value;
	}

	public int GetNumberOfNeighboursAlive(int checkX, int checkY)
	{
		int numberOfNeighbours = 0;
		for (int x = -1; x <= 1; x++)
		for (int y = -1; y <= 1; y++)
		{
			if ((x != 0 || y != 0) && x + checkX >= 0 && x + checkX < Width && y + checkY >= 0 &&
					y + checkY < Height && before[x + checkX, y + checkY])
				numberOfNeighbours++;
		}
		return numberOfNeighbours;
	}

	public void Tick()
	{
		var temp = before;
		before = current;
		current = temp;
		for (int x = 0; x < Width; x++)
		for (int y = 0; y < Height; y++)
		{
			var neighbours = GetNumberOfNeighboursAlive(x, y);
			var isAlive = before[x, y];
			bool shouldLive = false;
			if (isAlive)
			{
				if (neighbours < 2)
					shouldLive = false;
				else if (neighbours == 2 || neighbours == 3)
					shouldLive = true;
			}
			else
			{
				if (neighbours == 3)
					shouldLive = true;
			}
			Set(x, y, shouldLive);
		}
	}

	public void Random()
	{
		var random = new System.Random();
		for (int y = 0; y < Height; y++)
		for (int x = 0; x < Width; x++)
			Set(x, y, random.NextDouble() < 0.3);
	}
}