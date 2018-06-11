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
		}

		public string Name;
		public int HP;
		public int Mana;
		public List<Card> ActiveCards = new List<Card>();

		public void DealDamage(int dmg)
		{
			HP -= dmg;
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
