using System;
using NUnit.Framework;

namespace TradingCardGameStateMachine
{
	class CardTests
	{
		[SetUp]
		public void CreatePlayersAndCards()
		{
			player1 = new Player("Player1");
			player2 = new Player("Player2");
			attack = CardFactory.Create(CardType.Attack);
			defense = CardFactory.Create(CardType.Defense);
			revive = CardFactory.Create(CardType.Revive);
			block = CardFactory.Create(CardType.Block);
		}

		private Player player1;
		private Player player2;
		private Card attack;
		private Card defense;
		private Card revive;
		private Card block;

		[Test]
		public void ApplyAttack()
		{
			Assert.That(player2.HP, Is.EqualTo(50));
			attack.CastAction(player1, player2, attack);
			Assert.That(player2.HP, Is.EqualTo(44));
		}
	}
}
