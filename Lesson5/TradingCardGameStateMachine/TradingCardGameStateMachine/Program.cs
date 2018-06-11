using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCardGameStateMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            StateMachine sm = new StateMachine();

            Player p1 = new Player(50, 10);
            Player p2 = new Player(50, 10);
        }
    }
}
