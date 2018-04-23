using NUnit.Framework;

namespace BowlingGame
{
	public class GameTests
	{
		private Game game;

		[SetUp]
		public void CreateGame()
		{
			game = new Game();
		}

		[Test]
		public void WorstBowlingPlayerOfTheWorld()
		{
			for (int roll = 0; roll < 20; roll++)
				game.Roll(0);
			Assert.That(game.GetScore(), Is.EqualTo(0));
		}

		[Test]
		public void OnePinOnly()
		{
			game.Roll(1);
			for (int roll = 1; roll < 20; roll++)
				game.Roll(0);
			Assert.That(game.GetScore(), Is.EqualTo(1));
		}

		[Test]
		public void OneSpare()
		{
			game.Roll(2);
			game.Roll(8);
			game.Roll(1);
			for (int roll = 3; roll < 20; roll++)
				game.Roll(0);
			Assert.That(game.GetScore(), Is.EqualTo(12));
		}
	}
}
