using System;

namespace GameOfLife
{
	public class Game
	{
		public bool[,] before = new bool[3, 3];
		public bool[,] current = new bool[3, 3];

		public int GetNumberOfNeighboursAlive(int checkX, int checkY)
		{
			int numberOfNeighbours = 0;
			for (int x = -1; x <= 1; x++)
			for (int y = -1; y <= 1; y++)
			{
				if ((x != 0 || y != 0) &&
						x + checkX >= 0 && x + checkX < current.GetLength(0) &&
						y + checkY >= 0 && y + checkY < current.GetLength(1) &&
						before[x+checkX, y+checkY])
						numberOfNeighbours++;
			}
			return numberOfNeighbours;
		}

		public void Tick()
		{
			for (int x = 0; x < current.GetLength(0); x++)
			for (int y = 0; y < current.GetLength(1); y++)
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
				current[x, y] = shouldLive;
			}
		}

		public void Draw()
		{
			for (int y = 0; y < 3; y++)
			{
				for (int x = 0; x < 3; x++)
					Console.Write(current[x, y] ? "*" : ".");
				Console.WriteLine();
			}
		}
	}
}
