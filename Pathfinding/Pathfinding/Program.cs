using System;
using System.Diagnostics;

namespace Pathfinding
{
    public class Program
    {
        public static void Main()
        {
            Map map = new Map(10, 10);
            map.FillWithBlockade();
            map.SetStart(2, 1);
            map.SetEnd(1, 6);
            map.FindWay(2, 1);
            map.Draw();
        }
    }
}
