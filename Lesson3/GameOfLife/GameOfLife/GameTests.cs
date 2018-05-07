using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GameOfLife
{
    class GameTests
    {
        private Game _game;

        [SetUp]
        public void CreateGame()
        {
            _game = new Game(10);
            Assert.That(_game.Dimensions, Is.EqualTo(10));
        }

        [Test]
        public void Randomize()
        {
            _game.Randomize();
            _game.Tick();
        }

        [TearDown]
        public void DrawGame()
        {
            _game.Draw();
        }
    }
}
