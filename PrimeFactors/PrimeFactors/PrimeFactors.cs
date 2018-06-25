using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeFactors
{
    class PrimeFactors
    {
        public PrimeFactors()
        {
        }

        public List<int> GetPrimeNumbers(int number)
        {
            var list = new List<int>();
            for (int i = number; i > 0; i--)
            {
                IsPrime(i);
                if (IsPrime(i))
                { 
                    Console.WriteLine(i);
                    list.Add(i);
                }
            }
            return list;
        }

        public List<int> Generate(int n)
        {
            var list = new List<int>();
            
            return list;
        }

        public bool IsPrime(int number)
        {
            var KnownPrimes = new List<int> { 1, 2 };
            int counter = 3;
            while (number > counter)
            {
                for (int i = 1; i < KnownPrimes.Count; i++)
                    if (number % KnownPrimes[i] == 0)
                        return false;
                    KnownPrimes.Add(counter);
                    counter++;                
            }
            return true;
        }
    }
}
