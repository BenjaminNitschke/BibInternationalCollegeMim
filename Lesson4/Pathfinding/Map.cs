using System;
using System.Collections.Generic;

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
			CanFillMoreNeighbours(Start);
			//Find all 1, fill all unfilled neighbours with 2, etc. until map is filled
			int count = 1;
			while (CanFillMoreNeighbours(count++)) {}
			//When done go from E to S by finding the lowest neighbour (store result list)
		}

		private bool CanFillMoreNeighbours(int type)
		{
			var positions = FindAll(type);
			foreach (var pos in positions)
			foreach (var neighbour in FindEmptyNeighbours(pos))
				Set(neighbour, type <= 0 ? 1 : type + 1);
			return positions.Count > 0;
		}

		private List<Tuple<int, int>> FindAll(int type)
		{
			var result = new List<Tuple<int, int>>();
			for (int x = 0; x < Width; x++)
				for (int y = 0; y < Height; y++)
					if (data[x, y] == type)
						result.Add(new Tuple<int, int>(x, y));
			return result;
		}

		//Mostly from GameOfLife/Game.cs
		public List<Tuple<int, int>> FindEmptyNeighbours(Tuple<int, int> check)
		{
			int checkX = check.Item1;
			int checkY = check.Item2;
			var neighbours = new List<Tuple<int, int>>();
			for (int x = -1; x <= 1; x++)
				for (int y = -1; y <= 1; y++)
				{
					if ((x != 0 || y != 0) &&
						x + checkX >= 0 &&
						x + checkX < Width &&
						y + checkY >= 0 &&
						y + checkY < Height &&
						data[x + checkX, y + checkY] == 0)
						neighbours.Add(new Tuple<int, int>(x+checkX, y+checkY));
				}
			return neighbours;
		}

		public void Set(Tuple<int, int> pos, int value)
		{
			data[pos.Item1, pos.Item2] = value;
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
									: data[x, y] > 0 && data[x, y] < 10
										? data[x,y].ToString()
										: ".");
				Console.WriteLine();
			}
		}
	}
}
