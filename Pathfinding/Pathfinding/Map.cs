using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding
{
    class Map
    {
        public Map(int width, int height)
        {
            Width = width;
            Height = height;

            map = new int[width, height];
        }

        private int count = 1;
        public int Width { get; }
        public int Height { get; }

        private int[,] map;

        // -1 Blockade
        // -2 Start
        // -3 End
        private const int Blockade = -1;
        private const int Start = -2;
        private const int End = -3;

        public void FillWithBlockade()
        {
            for (int x = 0; x <= 4; x++)
            {
                for (int y = 3; y <= 4; y++)
                {
                    map[x, y] = Blockade;
                }
            }
        }

        public void SetStart(int x, int y)
        {
            map[x, y] = Start;
        }

        public void SetEnd(int x, int y)
        {
            map[x, y] = End;
        }

        public void FindWay(int startX, int startY)
        {
            GetNeighbours(startX, startY);
        }

        private List<Tuple<int, int>> GetNeighbours(int startX, int startY)
        {
            var neighbours = new List<Tuple<int, int>>();

            for (int x = -1; x < 2; x++)
            {
                for (int y = -1; y < 2; y++)
                {
                    if ((x != 0 || y != 0) && x + startX >= 0 && x + startX < Width && y + startY >= 0 && y + startY < Height && map[x + startX, y + startY] == 0)
                    {
                        map[startX + x, startY + y] = count;

                        neighbours.Add(new Tuple<int, int>(x + startX, y + startY));
                    }
                }
            }
            return neighbours;
        }

        //public void CreateMap(int width, int height)
        //{
        //    map = new int[width, height];

        //    for (int i = 0; i < width; i++)
        //    {
        //        for (int j = 0; j < height; j++)
        //        {
        //            map[i, j] = 0;
        //        }
        //    }
        //}

        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Console.Write(map[x, y] == Blockade ? "B" : map[x, y] == Start ? "S" : map[x, y] == End ? "E" : map[x, y] > 0 ? map[x, y].ToString() : ".");
                }
                Console.WriteLine();
            }
        }

        //public bool IsBlocked(int x, int y)
        //{
        //    if (map[x, y] == 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
