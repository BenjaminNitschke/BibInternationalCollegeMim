using System;

namespace Pathfinding
{
	public class Point : Tuple<int, int>
	{
		public Point(int x, int y) : base(x, y) {}
		public override bool Equals(object obj) => Equals(obj as Point);
		protected bool Equals(Point other)
			=> other != null &&other.Item1 == Item1 && other.Item2 == Item2;
		public override int GetHashCode() => base.GetHashCode();
	}
}