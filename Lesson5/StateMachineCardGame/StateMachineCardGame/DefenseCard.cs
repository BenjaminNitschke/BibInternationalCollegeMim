using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachineCardGame
{
    public class DefenseCard : Card
    {
        private int Shield { get; }
        private int Rounds { get; }
        public DefenseCard()
        {
            Mana = 2;
            Shield = 5;
            Rounds = 2;
        }
    }
}
