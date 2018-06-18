using System;
using NUnit.Framework;

namespace TradingCardGameStateMachine
{
	public class GameStateTests
	{
		[SetUp]
		public void CreateGame()
		{
			game = new Game(newState => Console.WriteLine("Changing game state to: " + newState));
		}

		private Game game;
		
		[Test]
		public void GoThroughGameStates()
		{
			Assert.That(game.State, Is.InstanceOf<ChooseStartPlayer>());
			game.Tick();
			Assert.That(game.State, Is.InstanceOf<Playing>());
			game.Tick();
			Assert.That(game.State, Is.InstanceOf<GameOver>());
		}
	}
}