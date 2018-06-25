using System.Collections.Generic;
using System;

namespace PrimeFactors
{
    public class PrimeFactors
    {
        // Generates a given amount of prime numbers.
        public static List<int> Generate(int amount)
        {
            List<int> primeNumbers = new List<int>();
            int i = 2;

            while (primeNumbers.Count < amount)
            {
                bool isPrimeNumber = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrimeNumber = false;
                        break;
                    }
                }
                if (isPrimeNumber)
                {
                    primeNumbers.Add(i);
                }
                i++;
            }

            return primeNumbers;
        }
        
        // Generates all prime factors of a given number.
        public static List<int> GetPrimeFactors(int number)
        {
            List<int> primeFactors = new List<int>();

            int x = GetNextPrimeFactor(number);
            if (x == 0)
            {
                Console.WriteLine(number + " is a prime number");
                return primeFactors;
            }

            while(x != 0)
            {
                primeFactors.Add(x);
                number /= x;
                x = GetNextPrimeFactor(number);
            }
            primeFactors.Add(number);

            return primeFactors;
        }

        // Calculates the next prime factor of a given number.
        private static int GetNextPrimeFactor(int number)
        {
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    return i;
                }
            }

            return 0;
        }

        // Generates all prime numbers up to the given number.
        public static List<int> GeneratWithMaxNumber(int maxNumber)
        {
            List<int> primeNumbers = new List<int>();
            for (int i = 2; i <= maxNumber; i++)
            {
                bool isPrimeNumber = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrimeNumber = false;
                        break;
                    }
                }
                if (isPrimeNumber)
                {
                    primeNumbers.Add(i);
                }
            }

            return primeNumbers;
        }

    }
}
