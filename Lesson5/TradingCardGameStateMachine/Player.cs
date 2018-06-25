using System;
using System.Collections.Generic;

namespace TradingCardGameStateMachine
{
	public class Player
	{
		public Player(string name)
		{
			Name = name;
			HP = 50;
			Mana = 10;
			Cards = new List<Card>();
			for (int i = 0; i < NumberOfInitialCards; i++)
				Cards.Add(CardFactory.Create((CardType)random.Next(4)));
			Console.WriteLine("Player " + name + " has the following cards: " + string.Join(", ", Cards));
		}

		private static Random random = new Random();
		public string Name;
		public int HP;
		public int Mana;
		public const int NumberOfInitialCards = 5; 
		public List<Card> ActiveCards = new List<Card>();
		public List<Card> Cards = new List<Card>();
		public Card SelectedCard { get; set; }

		public void DealDamage(int dmg)
		{
			HP -= dmg;
		}

		public override string ToString()
		{
			return "Player "+ Name + " HP =" + HP + ", Mana=" + Mana;
		}
	}
}
