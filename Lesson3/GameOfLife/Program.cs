using System.Threading;

namespace GameOfLife
{
	public class Program
	{
		public static void Main()
		{
			var game = new Game(80, 26);
			game.Random();
			while (true)
			{
				game.Tick();
				game.Draw();
				Thread.Sleep(100);
			}
		}
	}
}
