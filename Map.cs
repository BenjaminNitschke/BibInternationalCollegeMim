using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private const int Blockade = -1;
        private const int Start = -2;
        private const int End = -3;

        private int Width;
        private int Height;
        private readonly int[,] data;

        public void FillDataWithBlockade()
        {
            for (int x = 0; x <= 4; x++)
            {
                for (int y = 3; y <= 4; y++)
                {
                    data[x, y] = Blockade;
                }
            }
        }

        public void SetStart(int x, int y)
        {
            data[x, y] = Start;
        }

        public void SetEnd(int x, int y)
        {
            data[x, y] = End;
        }

        public void Set(Tuple<int, int> pos, int type)
        {
            int x = pos.Item1;
            int y = pos.Item2;
            if (x >= 0 && y >= 0 && x <= 6 && y <= 6)
            {
                data[x, y] = 1;
            }
        }

        private bool CanFillMoreNeighbours(int type)
        {
            var positions = FindAll(type);
            foreach(var pos in positions)
            {
                foreach(var neighbour in FindEmptyNeighbours(positions))
                {
                    Set(neighbour, type <= 0 ? 1 : type + 1);
                }
            }
            return positions.Count > 0;
        }

        private List<Tuple<int, int>> FindAll(int type)
        {
            var result = new List<Tuple<int, int>>();
            for(int x = 0; x < Width; x++)
            {
                for(int y = 0; y < Height; y++)
                {
                    if(data[x, y] == type)
                    {
                        result.Add(new Tuple<int, int>(x, y));
                    }
                }
            }
            return result;
        }

        public List<Tuple<int, int>> FindEmptyNeighbours(Tuple<int, int> check)
        {
            int checkX = check.Item1;
            int checkY = check.Item2;
            var neighbours = new List<Tuple<int, int>>();
            for(int x = -1; x <= 1; x++)
            {
                for(int y = -1; y <= 1; y++)
                {
                    if((x != 0 || y != 0) && x + checkX >= 0 && x + checkX < Width && y + checkY >= 0 && y + checkY < Height && data[x + checkX, y + checkY] == 0)
                    {
                        neighbours.Add(new Tuple<int, int>(x + checkX, x + checkY));
                    }
                }
            }
        }

        public void FindWay()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (data[x, y] == Start)
                    {
                        Set(x - 1, y - 1);
                        Set(x, y - 1);
                        Set(x + 1, y - 1);
                        Set(x - 1, y);
                        Set(x + 1, y);
                        Set(x - 1, y + 1);
                        Set(x, y + 1);
                        Set(x + 1, y + 1);
                    }
                }
            }
        }

        public void Draw()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Console.Write(data[x, y] == Blockade ? "X" : data[x, y] == Start ? "S" : data[x, y] == End ? "E" : data[x, y] == 1 ? "1" : data[x, y] == 2 ? "2" : data[x, y] == 3 ? "3" : data[x, y] == 4 ? "4" : data[x, y] == 5 ? "5" : data[x, y] == 6 ? "6" : data[x, y] == 7 ? "7" : data[x, y] == 8 ? "8" : data[x, y] == 9 ? "9" : data[x, y] == 10 ? "10" : data[x, y] > 0 ? data[x, y].ToString() : ".");
                }
                Console.WriteLine();
            }
        }
    }
}

