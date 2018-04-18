namespace BowlingGame
{
	public class Game
	{
		public void Roll(int pins)
		{
			pinsThrown[totalThrows] = pins;
			totalThrows++;
		}

		private int totalThrows = 0;
		private readonly int[] pinsThrown = new int[21];
		
		public int GetScore()
		{
			int score = 0;
			var roll = 0;
			for (int frame = 0; frame < 10; frame++)
			{
                if(IsStrike(roll))
                {
                    score += 10 + pinsThrown[roll + 1] + pinsThrown[roll + 2];
                    roll++;
                }
				else if (IsSpare(roll))
				{
					score += 10 + pinsThrown[roll + 2];
					roll += 2;
				}
				else
					score += pinsThrown[roll++] + pinsThrown[roll++];
			}
			return score;
		}

        private bool IsStrike(int roll)
        {
            if (pinsThrown[roll] == 10)
                return true;
            else
                return false;
        }

		private bool IsSpare(int roll)
		{
			return pinsThrown[roll] + pinsThrown[roll + 1] == 10;
		}
	}
}
