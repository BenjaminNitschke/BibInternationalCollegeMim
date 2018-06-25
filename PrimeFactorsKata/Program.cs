using System;

namespace PrimeFactorsKata
{
	class Program
	{
		static void Main()
		{
			//Return list of Prime Factors
			//Examples: 1 = 1, 2 = 2, 3 = 3, 4 = 2 * 2, 5 = 5, 6 = 2 * 3, 7 = 7, 8 = 2 * 2 * 2, 9 = 3 * 3, 10 = 2 * 5, 11 = 11
			Console.WriteLine("2=" +
				string.Join("*", PrimeFactors.Generate(2)));
			Console.WriteLine("4=" +
				string.Join("*", PrimeFactors.Generate(4)));
			Console.WriteLine("5=" +
				string.Join("*", PrimeFactors.Generate(5)));
			Console.WriteLine("6=" +
				string.Join("*", PrimeFactors.Generate(6)));
			Console.WriteLine("8=" +
				string.Join("*", PrimeFactors.Generate(8)));
			Console.WriteLine("9=" +
				string.Join("*", PrimeFactors.Generate(9)));
			Console.WriteLine("10=" +
				string.Join("*", PrimeFactors.Generate(10)));
		}
	}
}
