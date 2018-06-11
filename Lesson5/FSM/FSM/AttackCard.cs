using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM
{
    public class AttackCard : Card
    {
        public AttackCard(string name, int activatedRound, int manaCost, int dmg) : base(name, activatedRound, manaCost)
        {
            this.dmg = dmg;
        }
        private int dmg;
        public int DMG { get; }
    }
}
