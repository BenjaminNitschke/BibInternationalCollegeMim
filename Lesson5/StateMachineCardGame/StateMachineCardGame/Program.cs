using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachineCardGame
{
    public class Program
    {
        private static Player player1;
        private static Player player2;
        private static Player currentPlayer;
        private static int round;

        public static void Main()
        {
        }

        public static void InitializeGame()
        {
            player1 = new Player();
            player2 = new Player();
        }
    }
}
