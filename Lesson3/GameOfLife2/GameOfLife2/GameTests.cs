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
        public void WorstPossibleGameOfLife()
        {
            game.Tick();

            for (int y = 0; y < game.height; y++)
            {
                for (int x = 0; x < game.width; x++)
                {
                    Assert.That(game.current[x, y], Is.False);
                }
            }
        }

        /// <summary>
        /// Rule 1: Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.
        /// </summary>
        [Test]
        public void CellWithFewerThanTwoNeighboursDies()
        {
            game.before[1, 1] = true;
            game.Tick();

            Assert.That(game.current[1, 1], Is.False);
        }

        /// <summary>
        /// Rule 2: Any live cell with two or three live neighbours lives on to the next generation.
        /// </summary>
        [Test]
        public void CellWithTwoOrThreeNeighboursLives()
        {
            game.before[1, 1] = true;
            game.before[0, 0] = true;
            game.before[0, 1] = true;
            game.Tick();

            Assert.That(game.current[1, 1], Is.True);
        }

        [Test]
        public void NothingHappensWithAllLivingCellsHavingTwoNeighbours()
        {
            game.before[1, 1] = true;
            game.before[0, 0] = true;
            game.before[0, 1] = true;
            game.Tick();

            Assert.That(game.current[1, 1], Is.True);
            Assert.That(game.current[0, 0], Is.True);
            Assert.That(game.current[0, 1], Is.True);
        }

        /// <summary>
        /// Rule 3: Any live cell with more than three live neighbours dies, as if by overpopulation.
        /// </summary>
        [Test]
        public void CellWithMoreThanThreeNeighboursDies()
        {
            game.before[1, 1] = true;
            game.before[0, 0] = true;
            game.before[0, 1] = true;
            game.before[0, 2] = true;
            game.before[1, 0] = true;
            game.Tick();

            Assert.That(game.current[1, 1], Is.False);
        }

        /// <summary>
        /// Rule 4: Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
        /// </summary>
        [Test]
        public void DeadCellWithExactlyThreeNeighboursLives()
        {
            game.before[1, 1] = false;
            game.before[0, 0] = true;
            game.before[0, 1] = true;
            game.before[0, 2] = true;
            game.Tick();

            for (int x = 0; x < game.width; x++)
            {
                for (int y = 0; y < game.height; y++)
                {
                    bool shouldBeAlive = (x == 0 || x == 1) && y == 1;
                    Assert.That(game.current[x, y], Is.EqualTo(shouldBeAlive), "Cell " + x + ", " + y);
                }
            }
        }
    }
}