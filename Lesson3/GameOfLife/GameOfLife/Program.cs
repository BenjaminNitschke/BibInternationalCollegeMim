using System;
using System.Diagnostics;
using System.Threading;

namespace GameOfLife
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Game _game = new Game(10);
            _game.Setup();
            while (true)
            {
                Thread.Sleep(500);
                Console.Clear();
                _game.Tick();
                _game.Draw();
            }
        }
    }
}
