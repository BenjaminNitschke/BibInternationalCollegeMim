using System.Threading;
using System;

namespace GameOfLife
{
    public class Program
    {
        private int[,] gosperGliderGunTemp = new int[,]
        {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1},
            { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        };

        private bool[,] glider = new bool[,]
        {
                {false, true, false },
                {false, false, true },
                {true, true, true}
        };

        private bool[,] beacon = new bool[,]
        {
            { true, true, false, false},
            { true, false, false, false},
            { false, false, false, true},
            { false, false, true, true},
        };

        private bool[,] gosperGliderGun;



        private void StartGame()
        {
            gosperGliderGun = new bool[gosperGliderGunTemp.GetLength(0), gosperGliderGunTemp.GetLength(1)];
            for(int i = 0; i < gosperGliderGunTemp.GetLength(0); i++)
            {
                for (int j = 0; j < gosperGliderGunTemp.GetLength(1); j++)
                {
                    if(gosperGliderGunTemp[i, j] == 1) gosperGliderGun[i, j] = true;
                    else gosperGliderGun[i, j] = false;
                }
            }

            Game game = new Game(50, 50);
            game.Add(gosperGliderGun, 0, 0);
            game.Draw();
            bool running = true;
            while (running)
            {
                Thread.Sleep(1);
                Console.SetCursorPosition(0, 0);
                game.Tick();
                game.Draw();
            }
        }

        public static void Main(string[] args)
        {
            Program p = new Program();
            p.StartGame();
        }
    }    
}
