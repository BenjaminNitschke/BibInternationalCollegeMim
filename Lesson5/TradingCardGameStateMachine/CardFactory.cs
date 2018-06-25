using System;

namespace TradingCardGameStateMachine
{
	internal class CardFactory
	{
		public static Card Create(CardType cardType)
		{
			switch (cardType)
			{
			case CardType.Attack:
				return
					new Card(CardType.Attack).
					SetManaCost(1).
					SetName("Lightning Bolt").
					SetDescription("Lightning Bolt deals 6 damage to a single target and will cost 1 Mana").
					SetCast((us, target, card) =>
					{
						us.Mana -= card.ManaCost;
						Console.WriteLine("Dealing Lightning Bolt to " + target + ". " +
							"Damage Dealt: 6, Mana Lost: "+card.ManaCost);
						target.DealDamage(6);
					});
			case CardType.Defense:
				return
					new Card(CardType.Defense).
					SetManaCost(1).
					SetName("Shield of Valor").
					SetDescription("The Shield of Valor protects you from up to 5 damage in the next 2 rounds").
					SetCast((us, target, card) =>
					{
						us.Mana -= card.ManaCost;
						Console.WriteLine(
							"Activating Shield of Valor to shield 5 damage in the next 2 rounds. " +
							" Mana Lost: "+card.ManaCost);
						us.ActiveCards.Add(card);
					});
			case CardType.Revive:
				return
					new Card(CardType.Revive).
					SetManaCost(8).
					SetName("Revive last 3 cards").
					SetDescription("Revives the last 3 cards any player has used and adds them to our " +
						"player. Costs 8 Mana").
					SetCast((us, target, card) =>
					{
						us.Mana -= card.ManaCost;
						Console.WriteLine("Reviving last 3 cards: TODO");
					});
			case CardType.Block:
				return
					new Card(CardType.Block).
					SetManaCost(12).
					SetName("Block").
					SetDescription("Blocks the enemy from using Attack for 3 rounds. Costs 12 Mana").
					SetCast((us, target, card) =>
					{
						us.Mana -= card.ManaCost;
						Console.WriteLine("Blocking "+target+" from using Attack for the next 3 rounds. " +
							"Mana Lost: "+card.ManaCost);
						target.ActiveCards.Add(card);
					});
			default:
				throw new ArgumentOutOfRangeException(nameof(cardType), cardType, null);
			}
		}
	}
}