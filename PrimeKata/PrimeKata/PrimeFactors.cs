using System;
using System.Collections.Generic;

namespace PrimeFactorsKata
{
    namespace PrimeKata
    {
        public static class PrimeFactors
        {
            public static List<int> Primes(int n)
            {
                return new List<int> { 1 };
            }

            public static bool IsPrime(int number)
            {
                List<int> knownPrimes = new List<int> { 1, 2 };
                int counter = 3;

                while (number > counter)
                {
                    for (int i = 1; i < knownPrimes.Count; i++)
                        if (number % knownPrimes[i] = 0)
                            return false;
                    knownPrimes.Add(counter);
                    counter++;
                }
                return true;
            }

            public static List<int> Generate(int n)
            {
                return new List<int> { 1 };
            }
        }
    }
}


