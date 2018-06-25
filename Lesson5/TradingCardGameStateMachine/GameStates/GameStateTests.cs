using System;
using NUnit.Framework;

namespace TradingCardGameStateMachine.GameStates
{
	public class GameStateTests
	{
		[SetUp]
		public void CreateGame()
		{
			game = new Game((newState, newRoundState, currentPlayer) =>
				Console.WriteLine("Changing game state to: " + newState.GetType().Name + " " +
					(newRoundState?.GetType().Name ?? "") + " " + currentPlayer));
		}

		private Game game;
		
		[Test]
		public void GoThroughGameStates()
		{
			Assert.That(game.State, Is.InstanceOf<ChooseStartPlayer>());
			game.Tick();
			Assert.That(game.State, Is.InstanceOf<Playing>());
			while (game.State is Playing)
				game.Tick();
			Assert.That(game.State, Is.InstanceOf<GameOver>());
			game.Tick();
		}

		[Test]
		public void PlayRound()
		{
			game.Tick();
		}

	}
}