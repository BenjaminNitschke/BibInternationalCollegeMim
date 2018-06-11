using System;
using System.Collections.Generic;

namespace PathFinding
{
    public class Map
    {
        private int width;
        private int height;

        private int[,] map;

        public const int BLOCKED = -1;
        private const int START = -2;
        private const int END = -3;
        private const int WAY = -4;

        private Position start;
        private Position end;

        public Map(int width, int height)
        {
            this.width = width;
            this.height = height;

            map = new int[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    map[x, y] = 0;
                }
            }
        }

        public void Calculate()
        {
            Cal(start.x, start.y);
        }

        private void Cal(int x, int y)
        {
            List<Position> temp = new List<Position>();

            for (int j = y - 1; j <= y + 1; j++)
            {
                for (int i = x - 1; i <= x + 1; i++)
                {
                    if ((0 <= i && i < width) && (0 <= j && j < height))
                    {
                        if (map[i, j] == 0)
                        {
                            if (map[x, y] == START) map[i, j] = 1;
                            else map[i, j] = map[x, y] + 1;

                            temp.Add(new Position(i, j));
                        }
                        else if (map[i, j] > map[x, y] + 1)
                        {
                            if (map[x, y] == START) map[i, j] = 1;
                            else map[i, j] = map[x, y] + 1;

                            temp.Add(new Position(i, j));
                        }
                    }

                }
            }

            for (int i = 0; i < temp.Count; i++)
            {
                Cal(temp[i].x, temp[i].y);
            }
        }

        public void FindWay()
        {
            Way(end.x, end.y);
        }

        private void Way(int x, int y)
        {
            Position temp = new Position(x, y);
            int length = int.MaxValue;

            for (int j = y - 1; j <= y + 1; j++)
            {
                for (int i = x - 1; i <= x + 1; i++)
                {
                    if ((0 <= i && i < width) && (0 <= j && j < height))
                    {
                        if (map[i, j] == START)
                        {
                            return;
                        }
                        else if (map[i, j] != END && map[i, j] != WAY && map[i, j] != BLOCKED)
                        {
                            if (map[i, j] < length)
                            {
                                temp = new Position(i, j);
                                length = map[i, j];
                            }
                        }
                    }
                }
            }

            map[temp.x, temp.y] = WAY;
            Way(temp.x, temp.y);
        }

        public void SetStart(int x, int y)
        {
            start = new Position(x, y);
            map[x, y] = START;
        }

        public void SetEnd(int x, int y)
        {
            end = new Position(x, y);
            map[x, y] = END;
        }

        public bool IsBlocked(int x, int y)
        {
            return map[x, y] == BLOCKED ? true : false;
        }

        public void SetUpMap(int x, int y, int width, int height, int blocked)
        {
            for (int j = y; j < (y + height); j++)
            {
                for (int i = x; i < (x + width); i++)
                {
                    map[i, j] = blocked;
                }
            }
        }

        public void Draw()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (IsBlocked(x, y))
                    {
                        Console.Write("B ");
                    }
                    else
                    {
                        if (map[x, y] == START) Console.Write("S ");
                        else if (map[x, y] == END) Console.Write("E ");
                        else Console.Write(". ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (IsBlocked(x, y))
                    {
                        Console.Write("B ");
                    }
                    else
                    {
                        if (map[x, y] == START) Console.Write("S ");
                        else if (map[x, y] == END) Console.Write("E ");
                        else if(map[x, y] == WAY) Console.Write("W ");
                        else if (map[x, y] > 0) Console.Write(map[x, y].ToString().Substring(0, 1) + " ");
                        else Console.Write(". ");
                    }
                }
                Console.WriteLine();
            }
        }

        public int GetWidth()
        {
            return width;
        }

        public int GetHeight()
        {
            return height;
        }
    }
}