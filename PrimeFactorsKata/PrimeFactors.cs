using System.Collections.Generic;

namespace PrimeFactorsKata
{
	public class PrimeFactors
	{
		public static List<int> Generate(int number)
		{
			var primes = new List<int>();
			for (int factor=2; factor<number; factor++)
				while (number % factor == 0)
				{
					primes.Add(factor);
					number /= factor;
				}
			if (number > 1)
				primes.Add(number);
			return primes;
		}
	}
}