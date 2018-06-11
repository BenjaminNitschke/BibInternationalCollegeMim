using System.Threading;

namespace GameOfLife
{
	public class Program
	{
		public static void Main()
		{
			var game = new Game(80, 26);
			// Glider
			game.Set(0, 2, true);
			game.Set(1, 3, true);
			game.Set(2, 1, true);
			game.Set(2, 2, true);
			game.Set(2, 3, true);
			while (true)
			{
				game.Tick();
				game.Draw();
				Thread.Sleep(100);
			}
		}
	}
}
