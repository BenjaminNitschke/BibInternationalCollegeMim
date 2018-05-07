using System;
using System.Threading;

namespace GameOfLife2
{
    class Program
    {
        static void Main()
        {
            Game game = new Game(10, 10);
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
