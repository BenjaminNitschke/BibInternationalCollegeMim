using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Game _game = new Game();
            _game.Setup(5);
            while (true)
            {
                Thread.Sleep(500);
                Console.Clear();
                _game.Tick();
                _game.Draw(_game.current);
            }            
        }
    }
}
