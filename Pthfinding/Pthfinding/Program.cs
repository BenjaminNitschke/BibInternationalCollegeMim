
using System;

namespace Pathfinding
{
    class Program
    {
        

        public static void Main()
        {
            var map = new Map(20, 20);

            map.FillWithBlockade();
            map.SetStart(0, 1);
            map.SetEnd(6, 4);
            map.FindWay();

            map.Draw();
        }
    }
}
