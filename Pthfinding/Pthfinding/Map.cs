using System;
using System.Collections.Generic;

namespace Pathfinding
{
    public class Map
    {
        private readonly int width, height;

        private const int Start = 0;
        private const int Obstacle = -1;
        private const int Empty = -2;
        private const int End = -3;
        private const int Way = -4;

        private readonly int[,] map;

        private int counter = 0;

        private Tuple<int, int> start, target;

        private List<Tuple<int, int>> currentPoints;

        public Map(int width, int height)
        {
            this.width = width;
            this.height = height;

            map = new int[width, height];
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = Empty;
                }
            }
            currentPoints = new List<Tuple<int, int>>();
        }

        public void Draw()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Console.Write(map[x, y] == Obstacle ? "x" : map[x, y] == Start ? "s" : map[x, y] == End ? "e" : map[x, y] > 0 ? map[x, y].ToString() : map[x, y] == Way ? "w" : ".");
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        private int IsBlocked(int x, int y)
        {
            return map[x, y];
        }

        public void FillWithBlockade()
        {
            Random rnd = new Random();

            if (width >= 3 && height >= 3)
            {
                for (int x = 1; x < width - 3; x++)
                {
                    for (int y = 1; y < height - 2; y++)
                    {
                        map[x, y] = rnd.NextDouble() >= 0.5 ? Empty : Obstacle;
                    }
                }
            }
        }

        public void SetStart(int x, int y)
        {
            map[x, y] = Start;
            start = new Tuple<int, int>(x, y);
        }

        public void SetEnd(int x, int y)
        {
            map[x, y] = End;
            target = new Tuple<int, int>(x, y);
        }

        public void FindWay()
        {
            List<Tuple<int, int>> checkNext;

            do
            {
                checkNext = FindAll(counter);
                counter++;
                foreach (Tuple<int, int> item in checkNext)
                {
                    foreach (var point in FindEmptyNeighbors(item))
                    {
                        map[point.Item1, point.Item2] = counter;
                    }
                }
            } while (checkNext.Count > 0);
        }

        private List<Tuple<int, int>> FindAll(int effort)
        {
            var result = new List<Tuple<int, int>>();

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (map[i, j] == effort)
                    {
                        result.Add(new Tuple<int, int>(i, j));
                    }
                }
            }

            return result;
        }

        private List<Tuple<int, int>> FindEmptyNeighbors(Tuple<int, int> point)
        {
            List<Tuple<int, int>> temp = new List<Tuple<int, int>>();

            int xPos = point.Item1;
            int yPos = point.Item2;

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if ((x != 0 || y != 0) && x + xPos >= 0 && x + xPos < width && y + yPos >= 0 && y + yPos < height && map[xPos + x, yPos + y] == Empty)
                    {
                        map[xPos + x, yPos + y] = counter;

                        temp.Add(new Tuple<int, int>(x + xPos, y + yPos));
                    }
                }
            }

            return temp;
        }
    }
}
