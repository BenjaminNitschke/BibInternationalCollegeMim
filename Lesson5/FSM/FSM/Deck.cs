using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM
{
    public class Deck
    {
        public Deck(int cardAmount)
        {
            this.cardAmount = cardAmount;
            deckCards = new Stack<Card>();
        }
        private int cardAmount;
        private Stack<Card> deckCards;
        public Card DrawCard()
        {
            return deckCards.Pop();
        }
    }
}
