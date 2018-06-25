using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatePrimes
{
    class MainMethod
    {

        private static List<int> results = new List<int>();
        static void Main(string[] args)
        {
            PrimeFactors prime = new PrimeFactors();
            int input = 100;

            results = prime.getPrimeNumbers(input);
            if(results == null)
            {
                Console.WriteLine("It's empty");
                return;
            }

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }
    }

    class PrimeFactors
    {
        private List<int> primeFactors = new List<int>();
        private List<int> primeNumbers = new List<int>();

        public List<int> getPrimeFactors(int number)
        {

            if (primeFactors.Count == 0)
                return primeFactors;

            return null;
        }

        public List<int> getPrimeNumbers(int number)
        {
            primeNumbers.Add(2);
            int nextPrime = 3;
            while (true)
            {
                int sqrt = (int)Math.Sqrt(nextPrime);
                bool isPrime = true;

                for (int i = 0; (int)primeNumbers[i] <= sqrt; i++)
                {
                    if (nextPrime % primeNumbers[i] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primeNumbers.Add(nextPrime);
                    if (nextPrime > number)
                    {
                        break;
                    }
                }
                nextPrime += 2;
            }

            if (primeNumbers.Count == 0)
                return primeNumbers;

            return null;
        }

    }
}
