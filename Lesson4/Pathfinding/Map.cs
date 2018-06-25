using System;
using System.Collections.Generic;

namespace Pathfinding
{
	/// <summary>
	/// Helps with Pathfinding using A*
	/// </summary>
	public class Map
	{
		public Map(int width, int height)
		{
			this.width = width;
			this.height = height;
			map = new int[width, height];
			for (int x = 0; x < width; x++)
			for (int y = 0; y < height; y++)
				map[x, y] = Empty;
		}

		private readonly int width;
		private readonly int height;
		private readonly int[,] map;
		private const int Empty = -2;
		private const int Obstacle = -1;
		private const int Target = -3;
		private const int Way = -4;
		private const int Start = 0;

		public void FillWithBlockade()
		{
			Random rnd = new Random();
			if (width >= 3 && height >= 3)
				for (int x = 1; x < width - 3; x++)
				for (int y = 1; y < height - 2; y++)
					map[x, y] = rnd.NextDouble() >= 0.5 ? Empty : Obstacle;
		}

		public void SetStart(int x, int y)
		{
			map[x, y] = Start;
			start = new Point(x, y);
		}

		private Point start;

		public void SetTarget(int x, int y)
		{
			map[x, y] = Target;
			target = new Point(x, y);
		}

		private Point target;

		public void FindWay()
		{
			List<Point> checkNext;
			do
			{
				checkNext = FindAll(counter);
				counter++;
				foreach (Point item in checkNext)
				{
					foreach (var point in FindEmptyNeighbors(item))
						map[point.Item1, point.Item2] = counter;
					for (int x = -1; x <= 1; x++)
						for (int y = -1; y <= 1; y++)
							if ((x != 0 || y != 0) && x + item.Item1 >= 0 && x + item.Item1 < width &&
									y + item.Item2 >= 0 && y + item.Item2 < height &&
									map[item.Item1 + x, item.Item2 + y] == Target)
								return;
				}
			} while (checkNext.Count > 0);
		}

		private int counter = 0;

		private List<Point> FindAll(int effort)
		{
			var result = new List<Point>();
			for (int x = 0; x < width; x++)
			for (int y = 0; y < height; y++)
				if (map[x, y] == effort)
					result.Add(new Point(x, y));
			return result;
		}

		private List<Point> FindEmptyNeighbors(Point point)
		{
			List<Point> temp = new List<Point>();
			int xPos = point.Item1;
			int yPos = point.Item2;
			for (int x = -1; x <= 1; x++)
			for (int y = -1; y <= 1; y++)
				if ((x != 0 || y != 0) && x + xPos >= 0 && x + xPos < width && y + yPos >= 0 &&
						y + yPos < height && map[xPos + x, yPos + y] == Empty)
				{
					map[xPos + x, yPos + y] = counter;
					temp.Add(new Point(x + xPos, y + yPos));
				}
			return temp;
		}

		public void Draw()
		{
			for (int x = 0; x < width; x++)
			{
				for (int y = 0; y < height; y++)
				{
					Console.Write(map[x, y] == Obstacle
						? "x "
						: map[x, y] == Start
							? "s "
							: map[x, y] == Target
								? "e "
								: map[x, y] > 0 ? map[x, y].ToString("00") : map[x, y] == Way ? "w " : ". ");
					Console.Write(" ");
				}
				Console.WriteLine();
			}
		}
	}
}