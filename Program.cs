using System;

namespace Pathfinding
{
    class Program
    {
        private Map map;

        static void Main(string[] args)
        {
            var map = new Map(7, 7);
            map.FillDataWithBlockade();
            map.SetStart(0, 1);
            map.SetEnd(1, 6);
            map.FindWay();
            map.Draw();
            Console.ReadLine();
        }
    }
}