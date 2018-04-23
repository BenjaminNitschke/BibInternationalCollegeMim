using NUnit.Framework;

namespace GameOfLife
{
    public class GameTests
    {
        // Rule 1: Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.
        [Test]
        public void CellWithFewerThanTwoNeighboursDies()
        {

        }

        // Rule 2: Any live cell with two or three live neighbours lives on to the next generation.

        // Rule 3: Any live cell with more than three live neighbours dies, as if by overpopulation.
        // Rule 4: Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.

    }
}
