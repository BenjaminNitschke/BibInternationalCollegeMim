using NUnit.Framework;

namespace GameOfLife2
{
    /// <summary>
    /// https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life
    /// </summary>
    public class GameTests
    {
        private Game game;

        [SetUp]
        public void CreateGame()
        {
            game = new Game(3, 3);
        }

        [TearDown]
        public void DrawGame()
        {
            game.Draw();
        }

        [Test]
        public void Create10x10Game()
        {
            game = new Game(10, 10);
            Assert.That(game.Width, Is.EqualTo(10));
            Assert.That(game.Height, Is.EqualTo(10));
            //Assert.That(game.before.GetLength(0), Is.EqualTo(10));
            //Assert.That(game.before.GetLength(1), Is.EqualTo(10));
            game.Random();
            game.Tick();
        }

        [Test]
        public void Random()
        {
            game.Random();
            game.Tick();
        }

        [Test]
        public void WorstPossibleGameOfLife()
        {
            game.Tick();

            for (int y = 0; y < game.Height; y++)
            {
                for (int x = 0; x < game.Width; x++)
                {
                    Assert.That(game.IsAlive(x, y), Is.False);
                }
            }
        }

        /// <summary>
        /// Rule 1: Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.
        /// </summary>
        [Test]
        public void CellWithFewerThanTwoNeighboursDies()
        {
            game.Set(1, 1, true);
            game.Tick();

            Assert.That(game.IsAlive(1, 1), Is.False);
        }

        /// <summary>
        /// Rule 2: Any live cell with two or three live neighbours lives on to the next generation.
        /// </summary>
        [Test]
        public void CellWithTwoOrThreeNeighboursLives()
        {
            game.Set(1, 1, true);
            game.Set(0, 0, true);
            game.Set(0, 1, true);
            game.Tick();

            Assert.That(game.IsAlive(1, 1), Is.True);
        }

        [Test]
        public void NothingHappensWithAllLivingCellsHavingTwoNeighbours()
        {
            game.Set(1, 1, true);
            game.Set(0, 0, true);
            game.Set(0, 1, true);
            game.Tick();

            Assert.That(game.IsAlive(1, 1), Is.True);
            Assert.That(game.IsAlive(0, 0), Is.True);
            Assert.That(game.IsAlive(0, 1), Is.True);
        }

        /// <summary>
        /// Rule 3: Any live cell with more than three live neighbours dies, as if by overpopulation.
        /// </summary>
        [Test]
        public void CellWithMoreThanThreeNeighboursDies()
        {
            game.Set(1, 1, true);
            game.Set(0, 0, true);
            game.Set(0, 1, true);
            game.Set(0, 2, true);
            game.Set(1, 0, true);
            game.Tick();

            Assert.That(game.IsAlive(1, 1), Is.False);
        }

        /// <summary>
        /// Rule 4: Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
        /// </summary>
        [Test]
        public void DeadCellWithExactlyThreeNeighboursLives()
        {
            game.Set(1, 1, false);
            game.Set(0, 0, true);
            game.Set(0, 1, true);
            game.Set(0, 2, true);
            Assert.That(game.IsAlive(1, 1), Is.False);
            game.Tick();
            Assert.That(game.IsAlive(1, 1), Is.True);

            for (int x = 0; x < game.Width; x++)
            {
                for (int y = 0; y < game.Height; y++)
                {
                    bool shouldBeAlive = (x == 0 || x == 1) && y == 1;
                    Assert.That(game.IsAlive(x, y), Is.EqualTo(shouldBeAlive), "Cell " + x + ", " + y);
                }
            }
        }

        [Test]
        public void SimulateTwoTicks()
        {
            game.Set(0, 0, true);
            game.Set(0, 1, true);
            game.Set(0, 2, true);
            game.Tick();
            Assert.That(game.IsAlive(1, 1), Is.True);
            game.Tick();
            Assert.That(game.IsAlive(1, 1), Is.False);
        }
    }
}