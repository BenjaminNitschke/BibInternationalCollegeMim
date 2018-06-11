using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM
{
    class TestAttackCard : AttackCard
    {
        public TestAttackCard(string name, int activatedRound, int manaCost, int dmg) : base(name, activatedRound, manaCost, dmg)
        {

        }
        //Spezifische Methoden für diese Klasse, z.B. Effekte
    }
}
