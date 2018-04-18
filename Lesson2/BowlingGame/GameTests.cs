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

        [Test]
        public void OneStrike()
        {
            game.Roll(10);

            Assert.That(game.GetScore(), Is.EqualTo(10));
        }

        [Test]
        public void PerfectGame()
        {
            for (int roll = 0; roll < 12; roll++)
                game.Roll(10);

            Assert.That(game.GetScore(), Is.EqualTo(300));
        }

        [Test]
        public void SpareInLastFrame()
        {
            for (int roll = 0; roll < 19; roll++)
                game.Roll(0);

            game.Roll(10);
            game.Roll(5);

            Assert.That(game.GetScore(), Is.EqualTo(15));
        }

        [Test]
        public void TwoStrikes()
        {
            game.Roll(10);
            game.Roll(10);
            game.Roll(4);
            game.Roll(5);

            Assert.That(game.GetScore(), Is.EqualTo(52));
        }

    }
}
