using System;
using System.Collections.Generic;

namespace FSM
{
    public class Player
    {
        public Player(Deck deck, int health,int mana)
        {
            this.deck = deck;
            this.health = health;
            this.mana = mana;
        }
        private Deck deck;
        private int health;
        public int HEALTH { get; set; }
        private int mana;
        private List<Card> activeCards = new List<Card>();
        private List<Card> usedCards = new List<Card>();
        private List<Card> handCards = new List<Card>();

        public void DrawCard()
        {
            handCards.Add(deck.DrawCard());
        }
        public void AttackEnemy(AttackCard attackCard, Player player)
        {
            player.HEALTH -= attackCard.DMG;
        }

    }
}
