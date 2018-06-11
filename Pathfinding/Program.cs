using System;

namespace Pathfinding
{
	public class Program
	{
		public static void Main()
		{
			var map = new Map(7, 7);
			map.FillWithBlockade();
			map.SetStart(2, 1);
			map.SetEnd(1, 6);
			map.FindWay();
			map.Draw();
			Console.ReadLine();
		}
	}
}