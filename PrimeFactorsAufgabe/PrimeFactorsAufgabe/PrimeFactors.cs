using System;
using System.Collections.Generic;

namespace PrimeFactorsAufgabe
{
    public class PrimeFactors
    {
        public static List<int> GetPrimeNumbers(int numberOfPrimes)
        {

            return new List<int> { 1 };
        }
        public static bool isPrime(int number)
        { 
            var knownPrimes = new List<int> { 1, 2};
            int counter = 3;
            while(number > counter)
            {
                for (int i = 1; i < knownPrimes.Count; i++)
                    if (number % knownPrimes[i] = 0)
                        return false;
                    knownPrimes.Add(counter);
                    counter++;
               
            }
           return true;
        }
        public static List<int> Generate(int number)
        {
            return new List<int> { 1 };
        }

    }
}
