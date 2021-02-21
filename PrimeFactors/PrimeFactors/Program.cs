using System;
using System.Collections.Generic;

namespace PrimeFactors
{
    public class Program
    {
        private static List<int> primeNumbers;
        private static List<int> primeFactors;

        private static int amountOfPrimeNumbers = 10;
        private static int numberToFactorize = 27;

        static void Main(string[] args)
        {
            primeNumbers = PrimeFactors.Generate(amountOfPrimeNumbers);

            Console.WriteLine("The first {0} Prime Numbers are:", amountOfPrimeNumbers);
            foreach (int i in primeNumbers)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            primeFactors = PrimeFactors.GetPrimeFactors(numberToFactorize);

            if (primeFactors.Count > 0)
            {
                Console.WriteLine("The Prime Factors are:");
                foreach (int factor in primeFactors)
                {
                    Console.WriteLine(factor);
                }
            }
        }
    }
}
