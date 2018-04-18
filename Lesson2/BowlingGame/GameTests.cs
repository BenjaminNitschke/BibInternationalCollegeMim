using NUnit.Framework;

namespace BowlingGame
{
    public class GameTests
    {
        //private Game game;

        //[SetUp]
        //public void CreateGame()
        //{
        //    game = new Game();
        //}

        //[Test]
        //public void WorstBowlingPlayerOfTheWorld()
        //{
        //    for (int roll = 0; roll < 20; roll++)
        //        game.Roll(0);
        //    Assert.That(game.GetScore(), Is.EqualTo(0));
        //}

        //[Test]
        //public void OnePinOnly()
        //{
        //    game.Roll(1);
        //    for (int roll = 1; roll < 20; roll++)
        //        game.Roll(0);
        //    Assert.That(game.GetScore(), Is.EqualTo(1));
        //}

        //[Test]
        //public void OneSpare()
        //{
        //    game.Roll(2);
        //    game.Roll(8);
        //    game.Roll(1);
        //    for (int roll = 3; roll < 20; roll++)
        //        game.Roll(0);
        //    Assert.That(game.GetScore(), Is.EqualTo(12));
        //}

        //[Test]
        //public void OneStrike()
        //{
        //    game.Roll(10);
        //    game.Roll(1);
        //    game.Roll(1);
        //    for (int roll = 3; roll < 20; roll++)
        //        game.Roll(0);
        //    Assert.That(game.GetScore(), Is.EqualTo(14));
        //}

        //[Test]
        //public void TwoStrikes()
        //{
        //    game.Roll(10); //10
        //    game.Roll(10); //2x, also 20 macht 30
        //    game.Roll(4); //3x, also 12 macht 42
        //    game.Roll(3); //2x, also 6 macht 48
        //    Assert.That(game.GetScore(), Is.EqualTo(48));
        //}

        //[Test]
        //public void LastStrike()
        //{
        //    for (int i = 0; i < 18; i++)
        //        game.Roll(1);

        //    game.Roll(10);

        //    game.GetScore();
        //}

        //[Test]
        //public void MultipleStrikes()
        //{
        //    for (int i = 0; i < 9; i++)
        //        game.Roll(10);

        //    game.GetScore();
        //}

        //[Test]
        //public void AllStrike()
        //{
        //    for (int i = 0; i < 11; i++)
        //        game.Roll(10);

        //    Assert.That(game.GetScore(), Is.EqualTo(300));
        //}
    }
}
