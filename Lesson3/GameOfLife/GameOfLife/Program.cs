using System;
using System.Diagnostics;
using System.Threading;

namespace GameOfLife
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Game _game = new Game(50);
            _game.Setup();
            while (true)
            {
                Thread.Sleep(100);
                Console.SetCursorPosition(0, 0);
                _game.Tick();
                _game.Draw();
            }
        }
    }
}
