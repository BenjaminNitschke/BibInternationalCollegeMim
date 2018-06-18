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
			Cards = new List<Card> { CardFactory.Create(CardType.Attack) };
		}

		public string Name;
		public int HP;
		public int Mana;
		public List<Card> ActiveCards = new List<Card>();
		public List<Card> Cards = new List<Card>();
		public Card SelectedCard { get; set; }

		public void DealDamage(int dmg)
		{
			HP -= dmg;
		}

		public override string ToString()
		{
			return Name + " HP=" + HP + ", Mana=" + Mana;
		}
	}
}
