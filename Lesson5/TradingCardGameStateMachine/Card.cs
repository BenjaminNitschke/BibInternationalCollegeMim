using System;

namespace TradingCardGameStateMachine
{
	public class Card
	{
		public Card(CardType type)
		{
			Type = type;
		}

		public CardType Type { get; private set; }

		public Card SetManaCost(int setManaCost)
		{
			ManaCost = setManaCost;
			return this;
		}

		public int ManaCost { get; private set; }

		public Card SetName(string setName)
		{
			Name = setName;
			return this;
		}

		public string Name { get; private set; }

		public Card SetDescription(string setDescription)
		{
			Description = setDescription;
			return this;
		}

		public string Description { get; private set; }

		public Card SetCast(Action<Player, Player, Card> setCastAction)
		{
			CastAction = setCastAction;
			return this;
		}

		public Action<Player, Player, Card> CastAction { get; private set; }

		public override string ToString()
		{
			return Name;
		}
	}
}
