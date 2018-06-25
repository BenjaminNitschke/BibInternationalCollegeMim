using System;
using System.Collections.Generic;

namespace PrimeNumbers
{
    public class PrimeFactors
    {
        public static List<int> GeneratePrimes(int number)
        {
            int currentNumber = 1;
            var primes = new List<int>();
            Console.WriteLine($"These are the first {number} primes");
            while (primes.Count < number)
            {
                if (isPrime(currentNumber))
                {
                    primes.Add(currentNumber);
                    Console.WriteLine(currentNumber);
                }
                    currentNumber++;
            }
            return primes;
        }

        public static List<int> GeneratePrimeFactors(int number)
        {
            var factors = new List<int>();
            if (isPrime(number))
            {
                factors.Add(number);
                Console.WriteLine($"{number} was already a prime");
                return factors;
            }
            Console.Write($"{number}'s prime factors are:  ");
            for (int i = 2; i <= number; i++)
                while(number % i == 0)
                {
                    factors.Add(i);
                    number /= i;
                    
                    Console.Write($"{i} ");
                }
            Console.WriteLine();
            return factors;
        }

        public static bool isPrime(double number)
        {
            if (number % 2 == 0 && number != 0 && number != 2) return false;
            var start = Math.Floor(number / 2);
            for (int i = 2; i <= start; i++)
            {
                if ((number / i) % 1 == 0) return false;
            }
            return true;
        }
    }
}
