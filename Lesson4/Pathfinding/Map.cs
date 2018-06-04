using System;

namespace Pathfinding
{
	public class Map
	{
		public Map(int width, int height)
		{
			Width = width;
			Height = height;
			data = new int[Width, Height];
		}
		public int Width { get; }
		public int Height { get; }
		private readonly int[,] data;
		//All numbers are the pathfind way: 0, 1, 2, 3, 4
		private const int Blockade = -1;
		private const int Start = -2;
		private const int End = -3;

		public void FillWithBlockade()
		{
			for (int x = 0; x <= 4; x++)
			for (int y = 3; y <= 4; y++)
				data[x, y] = -1;
		}

		public void SetStart(int x, int y)
		{
			data[x, y] = Start;
		}
		public void SetEnd(int x, int y)
		{
			data[x, y] = End;
		}

		public void FindWay()
		{
			//Start at S, fill all neighbours with 1
			//Find all 1, fill all unfilled neighbours with 2, etc. until map is filled
			//When done go from E to S by finding the lowest neighbour (store result list)
		}

		public void Draw()
		{
			for (int y = 0; y < Height; y++)
			{
				for (int x = 0; x < Width; x++)
					Console.Write(
						data[x, y] == Blockade
							? "B"
							: data[x,y] == Start
								? "S"
								: data[x, y] == End
									? "E"
									: data[x, y] > 0
										? data[x,y].ToString()
										: ".");
				Console.WriteLine();
			}
		}
	}
}
