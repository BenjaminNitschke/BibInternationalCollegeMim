namespace BowlingGame
{
	public class Game
	{
        private byte[] pins = new byte[23];

        private byte index = 0;

        public void Roll(byte pin)
        {
            pins[index++] = pin;
        }

        public int GetScore()
        {
            byte index = 0;
            int sum = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(index))
                {
                    sum += 10 + pins[index + 1] + pins[index + 2];
                    index++;
                }
                else if (IsSpare(index))
                {
                    sum += pins[index] + pins[index + 1];
                    index += 2;
                }
                else
                {
                    sum += pins[index];
                    index++;
                }

            }

            return sum;
        }

        private bool IsStrike(byte pin)
        {
            if (pins[pin] == 10) return true;
            return false;
        }

        private bool IsSpare(byte pin)
        {
            if (pins[pin] + pins[pin + 1] == 10) return true;
            return false;
        }
    }
}
