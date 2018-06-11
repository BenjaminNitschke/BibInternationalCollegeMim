using System;

namespace FSM
{
    public class Card
    {
        public Card(string name, int activatedRound, int manaCost)
        {
            this.activatedRound = activatedRound;
            this.manaCost = manaCost;
        }
        private string name;
        private int activatedRound;
        private int manaCost;
        public void PlaceCard()
        {
            // Place Card on Map
        }
    }
}
