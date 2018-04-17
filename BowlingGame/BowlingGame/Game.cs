using System;

namespace BowlingGame
{
    public class Game
    {
        private int totalThrows = 0;
        private readonly int[] pinsThrown = new int[21];

        public void Roll(int pins)
        {
            pinsThrown[totalThrows] = pins;
            totalThrows++;
        }

        public int GetScore()
        {
            int score = 0;
            int roll = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(roll))
                {
                    score += 10 + pinsThrown[roll + 1] + pinsThrown[roll + 2];
                    roll++;
                    totalThrows++;
                }
                else if (IsSpare(roll))
                {
                    score += 10 + pinsThrown[roll + 2];
                    roll += 2;
                }
                else
                {
                    score += pinsThrown[roll++] + pinsThrown[roll++];
                }
            }

            return score;
        }

        private bool IsStrike(int roll)
        {
            return pinsThrown[roll] == 10;
        }

        private bool IsSpare(int roll)
        {
            return pinsThrown[roll] + pinsThrown[roll + 1] == 10;
        }
    }
}