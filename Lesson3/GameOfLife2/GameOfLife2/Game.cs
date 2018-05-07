using System;
using System.Diagnostics;

namespace GameOfLife2
{
    public class Game
    {
        private bool[,] before;
        private bool[,] current;

        public int Width { get; }
        public int Height { get; }

        public Game(int width, int height)
        {
            before = new bool[width, height];
            current = new bool[width, height];
            Width = width;
            Height = height;
        }

        public bool IsAlive(int x, int y)
        {
            return current[x, y];
        }

        public void Set(int x, int y, bool value)
        {
            current[x, y] = value;
        }

        public void Tick()
        {
            bool[,] temp = before;
            before = current;
            current = temp;

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    int neighbours = GetNumberOfNeighboursAlive(x, y);

                    bool isAlive = before[x, y];
                    bool shouldLive = false;

                    if (isAlive)
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
                    Set(x, y, shouldLive);
                }
            }
        }

        private int GetNumberOfNeighboursAlive(int checkX, int checkY)
        {
            int numberOfNeighbours = 0;
            for (int y = -1; y <= 1; y++)
            {
                for (int x = -1; x <= 1; x++)
                {
                    int xPos = checkX + x;
                    int yPos = checkY + y;

                    if ((x != 0 || y != 0) && xPos >= 0 && xPos < Width && yPos >= 0 && yPos < Height && before[xPos, yPos])
                    {
                        numberOfNeighbours++;
                    }
                }
            }

            return numberOfNeighbours;
        }

        public void Draw()
        {
            string callingFrameClassName = new StackTrace().GetFrame(1).GetMethod().DeclaringType.Name;
            if (!callingFrameClassName.Contains("GameTests"))
            {
                Console.SetCursorPosition(0, 0);
            }
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Console.Write(IsAlive(x, y) ? " o" : " -");
                }
                Console.WriteLine();
            }
        }

        public void Random()
        {
            Random random = new Random();

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Set(x, y, random.NextDouble() < .3);
                }
            }
        }

        public void Glider()
        {
            Set(0, 2, true);
            Set(1, 3, true);
            Set(2, 1, true);
            Set(2, 2, true);
            Set(2, 3, true);
        }
    }
}
