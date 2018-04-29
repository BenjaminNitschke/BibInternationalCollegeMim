using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Game
    {
        public bool[,] before;
        public bool[,] current;
        private Random rnd;
        private int dimensions;

        public void Setup(int dimensions)
        {
            this.dimensions = dimensions;
            rnd = new Random();
            before = new bool[dimensions, dimensions];
            current = new bool[dimensions, dimensions];
            for (int x = 0; x < before.GetLength(0); x++)
                for (int y = 0; y < before.GetLength(1); y++)
                    before[x, y] = rnd.Next(0, 10) < 4;
            Draw(before);
        }

        public int GetNeighbors(int xPos, int yPos)
        {
            int neighborCount = 0;
            for (int x = xPos - 1; x < (xPos + 2); x++)
                for (int y = yPos - 1; y < (yPos + 2); y++)
                    if ((x != xPos || y != yPos) && x >= 0 && x < dimensions && y >= 0 && y < dimensions && before[x, y])
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
                else if (neighbors == 2 || neighbors == 3)
                    return true;
                else
                    return false;
            }
            else
            {
                if (neighbors == 3)
                    return true;
                else
                    return false;
            }

        }

        public void Tick()
        {
            for (int x = 0; x < dimensions; x++)
                for (int y = 0; y < dimensions; y++)
                {
                    current[x, y] = CheckState(x, y);
                    //Console.WriteLine("Tick");
                }
            before = current;
        }

        public void Draw(bool[,] array)
        {
            for (int x = 0; x < dimensions; x++)
            {
                for (int y = 0; y < dimensions; y++)
                    if (array[x, y])
                        Console.Write("o ");
                    else
                        Console.Write("x ");
                Console.WriteLine();
            }
        }
    }
}
