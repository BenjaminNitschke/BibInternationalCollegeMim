using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM
{
    class MagicCard : Card
    {
        public MagicCard(string name, int activatedRound, int manaCost) : base(name, activatedRound, manaCost)
        {

        }

        public void UseMagic()
        {
            // Use Magic effect of the Card
        }
    }
}
