using System;

namespace GameOfLife2
{
    class Game
    {
        public bool[,] before;
        public bool[,] current;

        public int width;
        public int height;

        private Random random;

        public Game(int width, int height)
        {
            before = new bool[width, height];
            current = new bool[width, height];
            this.width = width;
            this.height = height;
        }

        public void Tick()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
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
                    current[x, y] = shouldLive;
                }
            }
            before = current;
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

                    if ((x != 0 || y != 0) && xPos >= 0 && xPos < width && yPos >= 0 && yPos < height && before[xPos, yPos])
                    {
                        numberOfNeighbours++;
                    }
                }
            }

            return numberOfNeighbours;
        }

        public void Draw()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.Write(current[x, y] ? " +" : " -");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void Random()
        {
            random = new Random();

            for (int x = 0; x < before.GetLength(0); x++)
            {
                for (int y = 0; y < before.GetLength(1); y++)
                {
                    before[x, y] = current[x, y] = random.NextDouble() >= .5;
                }
            }
        }
    }
}
