using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachineCardGame
{
    public class AttackCard : Card
    {
        private int Attack { get; }
        public AttackCard()
        {
            Mana = 1;
            Attack = 6;
        }
    }
}
