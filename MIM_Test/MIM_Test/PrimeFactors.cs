using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIM_Test
{
    class PrimeFactors
    {
        public static List<int> GetPrimeNumbers(int input)
        {
            List<int> PrimeNumberList = new List<int>();

            for (int i = 0; i <= input; i++)
            {
                if (PrimeFactors.IsPrime(i))
                {
                    Console.WriteLine(string.Format("Prime Number: {0}", i));
                    PrimeNumberList.Add(i);
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine(string.Format("No Prime Number: {0}", i));
                    Console.ReadLine();
                }
            }
            return PrimeNumberList;
        }

        public static bool IsPrime(int input)
        {
            var knownPrimes = new List<int> { 1, 2 };
            int counter = 3;
            while(input > counter)
            {
                for(int i = 1; i < knownPrimes.Count; i++)
                {
                    if(input % knownPrimes[i] == 0)
                    {
                        return false;
                    }
                    knownPrimes.Add(counter);
                    counter++;
                }
            }
            return true;
        }

        public static List<int> Generate(int input)
        {
            List<int> PrimeFactorList = new List<int>();

            for (int i = 2; i <= input; i++)
            {
                if(input % i == 0)
                {
                    PrimeFactorList.Add(i);
                    Console.WriteLine(string.Format("{0} is a prime factor.", i));
                    Console.ReadLine();
                }

                else
                {
                    Console.WriteLine(string.Format("{0} is no prime factor.", i));
                    Console.ReadLine();
                }
            }
            return PrimeFactorList;
        }
    }
}
