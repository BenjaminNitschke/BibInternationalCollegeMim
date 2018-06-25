using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace PrimeFactorsKata
{
	public class PrimeFactorsTests
	{
		[TestCase(2, new[] { 2 })]
		[TestCase(3, new[] { 3 })]
		[TestCase(6, new[] { 2, 3 })]
		[TestCase(9, new[] { 3, 3 })]
		[TestCase(10, new[] { 2, 5 })]
		public void ConfirmPrimeNumbers(int number, int[] expected)
		{
			Assert.That(PrimeFactors2.Generate(number),
				Is.EquivalentTo(expected));
		}
	}

	public class PrimeFactors2
	{
		public static List<int> GenerateOld(int number)
		{
			var primes = new List<int>();
			for (int counter = 2; number > 1; ++counter)
				for (; number % counter == 0; number /= counter)
					primes.Add(counter);
			return primes;
		}

		public static List<int> Generate(int number)
		{
			var primes = new List<int>();
			if (number <= 3)
				primes.Add(number);
			else if (number % 2 == 0)
			{
				primes.Add(2);
				number /= 2;
				if (number <= 3)
					primes.Add(number);
			}
			else if (number % 3 == 0)
			{
				primes.Add(3);
				number /= 3;
				if (number <= 3)
					primes.Add(number);
			}
			if (number % 5 == 0)
			{
				primes.Add(5);
				number /= 5;
				if (number > 1 && number <= 3)
					primes.Add(number);
			}
			//etc.
			return primes;
		}
	}
}
