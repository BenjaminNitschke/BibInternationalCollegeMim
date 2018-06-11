using System;

namespace PathFinding
{
    public class Program
    {
        public static void Main()
        {
            // Create map
            Map map = new Map(7, 7);
            map.SetUpMap(0, 0, 5, 1, Map.BLOCKED);
            map.SetUpMap(0, 3, 4, 2, Map.BLOCKED);
            map.SetUpMap(6, 1, 1, 2, Map.BLOCKED);
            map.SetUpMap(4, 4, 1, 2, Map.BLOCKED);
            // Set start/end
            map.SetStart(1, 2);
            map.SetEnd(1, 5);
            // Find way
            map.Calculate();
            map.FindWay();
            // Show map, show start/end, show way
            map.Draw();
        }
    }
}