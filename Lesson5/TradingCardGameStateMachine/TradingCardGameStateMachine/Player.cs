using System.Collections.Generic;

namespace TradingCardGameStateMachine
{
    public class Player
    {
        private int hp;
        private int mana;
        private List<Card> activeCards = new List<Card>();

        public Player(int startHp, int startMana)
        {
            hp = startHp;
            mana = startMana;
        }



        public void SetHP(int hp)
        {
            this.hp = hp;
        }

        public void SetMana(int mana)
        {
            this.mana = mana;
        }

        public void SetActiveCards(List<Card> activeCards)
        {
            this.activeCards = activeCards;
        }

        public int GetHP()
        {
            return hp;
        }

        public int GetMana()
        {
            return mana;
        }

        public List<Card> GetActiveCards()
        {
            return activeCards;
        }
    }
}
