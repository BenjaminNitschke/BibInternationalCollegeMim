using System.Threading;

namespace GameOfLife
{
    public class Program
    {
        public static void Main()
        {
            var game = new Game(40, 40);
            //game.Random();
            game.Glider();

            while (true)
            {
                game.Tick();
                game.Draw();
                Thread.Sleep(100);
            }
        }
    }
}