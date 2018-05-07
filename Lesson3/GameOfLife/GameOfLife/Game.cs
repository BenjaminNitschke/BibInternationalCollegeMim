using System;

namespace GameOfLife
{
    public class Game
    {
        public Game(int dimensions)
        {
            Dimensions = dimensions;

            before = new bool[dimensions, dimensions];
            current = new bool[dimensions, dimensions];
        }

        public int Dimensions;
        private bool[,] before;
        private readonly bool[,] current;
        private Random _rnd;

        public void Setup()
        {
            Randomize();
            Draw();
        }

        private int GetNeighbors(int xPos, int yPos)
        {
            int neighborCount = 0;
            for (int x = xPos - 1; x < xPos + 2; x++)
                for (int y = yPos - 1; y < yPos + 2; y++)
                    if ((x != xPos || y != yPos) && x >= 0 && x < Dimensions && y >= 0 && y < Dimensions &&
                        before[x, y])
                        neighborCount++;
            return neighborCount;
        }

        private bool CheckState(int xPos, int yPos)
        {
            int neighbors = GetNeighbors(xPos, yPos);
            if (before[xPos, yPos])
            {
                if (neighbors < 2)
                    return false;
                if (neighbors == 2 || neighbors == 3)
                    return true;
                return false;
            }

            if (neighbors == 3)
                return true;
            return false;
        }

        public void Tick()
        {
            for (int x = 0; x < Dimensions; x++)
                for (int y = 0; y < Dimensions; y++)
                    current[x, y] = CheckState(x, y);
            before = current;
        }

        public void Draw()
        {
            for (int x = 0; x < Dimensions; x++)
            {
                for (int y = 0; y < Dimensions; y++)
                    if (current[x, y])
                        Console.Write("x ");
                    else
                        Console.Write("o ");
                Console.WriteLine();
            }
        }

        public bool IsAlive(int x, int y)
        {
            return current[x, y];
        }

        public void Randomize()
        {
            _rnd = new Random();
            for (int x = 0; x < before.GetLength(0); x++)
                for (int y = 0; y < before.GetLength(1); y++)
                    before[x, y] = _rnd.NextDouble() < 0.4;
        }
    }
}