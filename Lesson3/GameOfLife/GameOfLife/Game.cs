using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Game
    {
        private bool[,] currentMap;
        private bool[,] newMap;

        private int width;
        private int height;

        public Game() { }

        public Game(int width, int height)
        {
            this.width = width;
            this.height = height;

            currentMap = new bool[this.width, this.height];
            newMap = new bool[this.width, this.height];
        }

        public void SetUp()
        {
            Random r = new Random();
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (r.NextDouble() < 0.3d) currentMap[x, y] = true;
                    else currentMap[x, y] = false;
                }
            }
        }

        public void SetUp(bool[,] map, int xPos, int yPos)
        {
            for(int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    currentMap[xPos + x, yPos + y] = map[x, y];
                }
            }
        }

        public void Add(bool[,] map, int xPos, int yPos)
        {
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    currentMap[xPos + x, yPos + y] = map[x, y];
                }
            }
        }

        public void Tick()
        {
            newMap = new bool[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int neighbours = GetNeighbours(x, y);
                    bool shouldLive = false;
                    if (currentMap[x, y])
                    {
                        if (neighbours == 2 || neighbours == 3)
                        {
                            shouldLive = true;
                        }
                    }
                    else
                    {
                        if (neighbours == 3)
                        {
                            shouldLive = true;
                        }
                    }
                    newMap[x, y] = shouldLive;
                }
            }
            currentMap = newMap;
        }

        private int GetNeighbours(int xCheck, int yCheck)
        {
            int neighbours = 0;
            for (int x = -1; x < 2; x++)
            {
                for (int y = -1; y < 2; y++)
                {
                    int xPos = xCheck + x;
                    int yPos = yCheck + y;
                    if ((x != 0 || y != 0) && (0 <= xPos && xPos < width) && (0 <= yPos && yPos < height))
                    {
                        if (currentMap[xPos, yPos])
                            neighbours++;
                    }
                }
            }
            return neighbours;
        }

        public void Draw()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (currentMap[x, y]) Console.Write("o ");
                    else Console.Write("  ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}