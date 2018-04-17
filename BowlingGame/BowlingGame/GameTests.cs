using NUnit.Framework;

namespace BowlingGame
{
    class GameTests
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
            {
                game.Roll(0);
            }

            Assert.That(game.GetScore(), Is.EqualTo(0));
        }

        [Test]
        public void OnePinOnly()
        {
            game.Roll(1);

            for (int roll = 1; roll < 20; roll++)
            {
                game.Roll(0);
            }

            Assert.That(game.GetScore(), Is.EqualTo(1));
        }

        [Test]
        public void OneSpare()
        {
            game.Roll(2);
            game.Roll(8);
            game.Roll(1);

            for (int roll = 3; roll < 20; roll++)
            {
                game.Roll(0);
            }

            Assert.That(game.GetScore(), Is.EqualTo(12));
        }

        [Test]
        public void OneStrike()
        {
            game.Roll(10);
            game.Roll(2);
            game.Roll(1);

            for (int roll = 4; roll < 20; roll++)
            {
                game.Roll(0);
            }

            Assert.That(game.GetScore(), Is.EqualTo(16));
        }

        [Test]
        public void TwoStrikes()
        {
            game.Roll(10);
            game.Roll(10);
            game.Roll(1);

            for (int roll = 5; roll < 20; roll++)
            {
                game.Roll(0);
            }

            Assert.That(game.GetScore(), Is.EqualTo(33));
        }

        [Test]
        public void TwelveStrikes()
        {
            for (int roll = 0; roll < 12; roll++)
            {
                game.Roll(10);
            }

            Assert.That(game.GetScore(), Is.EqualTo(300));
        }

        [Test]
        public void SpareOnLast()
        {
            for (int roll = 0; roll < 18; roll++)
            {
                game.Roll(0);
            }

            game.Roll(2);
            game.Roll(8);
            game.Roll(10);

            Assert.That(game.GetScore(), Is.EqualTo(20));
        }

        [Test]
        public void RandomTest()
        {
            for (int roll = 0; roll < 9; roll++)
            {
                game.Roll(10);
            }

            game.Roll(2);
            game.Roll(8);
            game.Roll(10);

            Assert.That(game.GetScore(), Is.EqualTo(272));
        }
    }
}