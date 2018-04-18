namespace BowlingGame
{
    public class Game
    {
        private static int totalThrows;
        static private int[] pinsThrown = new int[21];

        public static void Roll(int pins)
        {
            pinsThrown[totalThrows] = pins;

            if (pins == 10)
                totalThrows++;

            totalThrows++;
        }

        public static int GetScore()
        {
            int score = 0;
            var roll = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if ((roll == 18 && IsStrike(roll)) || (roll == 18 && totalThrows[18] + totalThrows[19] == 10))
                {
                    score += pinsThrown[20];
                    return score;
                }
                if (IsStrike(roll))
                {
                    score += 10 + pinsThrown[roll + 2];

                    if (IsStrike(roll + 2))
                        score += pinsThrown[roll + 4];
                    else
                        score += pinsThrown[roll + 3];

                    roll += 2;
                }
                if (IsSpare(roll))
                {
                    score += 10 + pinsThrown[roll + 2];

                    roll += 2;
                }
                else
                    score += pinsThrown[roll++] + pinsThrown[roll++];
            }
            return score;
        }

        private static bool IsSpare(int roll)
        {
            return pinsThrown[roll] + pinsThrown[roll + 1] == 10;
        }

        private static bool IsStrike(int roll)
        {
            return pinsThrown[roll] == 10;
        }
    }
}
