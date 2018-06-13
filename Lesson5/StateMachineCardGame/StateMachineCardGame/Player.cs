using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachineCardGame
{
    public class Player
    {
        public Player()
        {
            cards = Draw8Random();
            ListCards();
        }

        private List<Card> cards;
        private const int MaxHp = 50;
        private const int MaxMana = 20;
        public int Hp = 50;
        public int Mana = 10;
        public int Armor = 0;

        private List<Card> Draw8Random()
        {
            var rnd = new Random();
            var temp = new List<Card>();
            for (int i = 0; i < 8; i++)
            {
                temp.Add(Draw());
            }
            return temp;
        }

        private Card Draw()
        {
            Random rnd = new Random();
            int i = rnd.Next(0, 4);
            return i == 0 ? new AttackCard() : i == 1 ? new DefenseCard() : i == 2 ? new ReviveCard() : new BlockCard();
        }

        public void ListCards()
        {
            Console.Write("You have these cards in your hand: ");
            foreach (var card in cards)
                Console.Write($"{card.ToString()}, ");
        }
    }
}
