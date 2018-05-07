using System.Threading;

namespace GameOfLife2
{
    public class Program
    {
        private static void Main()
        {
            Game game = new Game(10, 10);
            //game.Random();
            game.Glider();
            game.Draw();

            while (true)
            {
                Thread.Sleep(100);
                game.Tick();
                game.Draw();
            }
        }
    }
}
