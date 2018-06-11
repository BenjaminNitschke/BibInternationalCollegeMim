using System;
using System.Collections.Generic;

namespace Pathfinding
{
    class Map
    {
        private int width;
        private int height;
        private readonly int[,] data;
        // 0, 1, 2, 3, 4: way
        private const int Blockade = -1;
        private const int Start = -2;
        private const int End = -3;
        private const int Path = 10;

        private List<Node> nodes;
        private List<Node> cache;
        private int position;
        private int positionX = 1;
        private int positionY = 6;

        int counter = 1;

        public Map(int width, int height)
        {
            this.width = width;
            this.height = height;
            data = new int[width, height];
            nodes = new List<Node>();
            cache = new List<Node>();
        }

        public void FillWithBlockade()
        {
            for (int x = 0; x <= 4; x++)
            {
                for (int y = 3; y <= 4; y++)
                {
                    data[x, y] = -1;
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

        public void FindWay()
        {
            nodes.Add(new Node(2, 1));
            SetNeighbours();

            while (position != -2)
            {
                FindBestPath(positionX, positionY);
            }
        }

        private void SetNeighbours()
        {
            foreach (Node node in nodes)
            {
                for (int y = -1; y <= 1; y++)
                {
                    for (int x = -1; x <= 1; x++)
                    {
                        if (node.x + x >= 0 && node.y + y >= 0 && node.x + x < width && node.y + y < height && data[node.x + x, node.y + y] == 0 && (x != 0 || y != 0))
                        {
                            data[node.x + x, node.y + y] = counter;
                            cache.Add(new Node(node.x + x, node.y + y));
                        }
                    }
                }
            }

            if (cache.Count > 0 && counter < 9)
            {
                counter++;
                nodes.Clear();

                foreach (Node node in cache)
                {
                    nodes.Add(node);
                }
                cache.Clear();

                SetNeighbours();
            }
        }

        private void FindBestPath(int xPos, int yPos)
        {
            int cachedValue = 100;
            for (int y = -1; y <= 1; y++)
            {
                for (int x = -1; x <= 1; x++)
                {
                    if (xPos + x >= 0 && yPos + y >= 0 && xPos + x < width && yPos + y < height && data[xPos + x, yPos + y] != -3 && data[xPos + x, yPos + y] != -1)
                    {
                        if (data[xPos + x, yPos + y] < cachedValue)
                        {
                            positionX = xPos + x;
                            positionY = yPos + y;
                            position = data[x + xPos, yPos + y];
                            cachedValue = data[x + xPos, yPos + y];
                            data[x + xPos, yPos + y] = Path;
                        }
                    }
                }
            }
        }

        public void Draw()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.Write(
                        data[x, y] == Blockade
                        ? "B"
                        : data[x, y] == Start
                        ? "S"
                        : data[x, y] == End
                        ? "E"
                        : data[x, y] == Path
                        ? "*"
                        : data[x, y] > 0
                        ? data[x, y].ToString()
                        : ".");
                }
                Console.WriteLine();
            }
        }

        private int IsBlocked(int x, int y)
        {
            return data[x, y] = Blockade;
        }
    }

    public struct Node
    {
        public int x;
        public int y;

        public Node(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}


//private void CreateMap()
//{

//    Random rand = new Random();

//    for (int y = 0; y < height; y++)
//    {
//        for (int x = 0; x < width; x++)
//        {
//            if (x > .5f * width - 1 && y > .5f * height - 1 && x < .5f * width + 1 && y < .5f * height + 1)
//            {
//                map[x, y] = true;
//            }

//            if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
//            {
//                map[x, y] = rand.NextDouble() <= .5f ? true : false;
//            }
//        }
//    }
//}