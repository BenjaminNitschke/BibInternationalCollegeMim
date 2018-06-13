using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachineCardGame
{
    public abstract class Card
    {
        public int Mana { get; protected set; }
        public int RoundPlayed { get; private set; }
        public void Play(int round)
        {
            RoundPlayed = round;
        }

        public override string ToString()
        {
            return GetType().Name.Replace("Card", "");
        }
    }
}
