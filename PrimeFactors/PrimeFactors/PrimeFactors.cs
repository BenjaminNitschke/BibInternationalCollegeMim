using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeFactors
{
    class PrimeFactors
    {
        public static List<int> GetPrimeFactors(int number)
        {
            List<int> PrimeFactor = new List<int>();

            
            for (int i = 1; i < number; i++)
            {
                //PrimeFactors
                if (number % i == 0)
                {
                    PrimeFactor.Add(i);
                    Console.WriteLine(string.Format("for {0}, {1} is a prime factor if multiplied by {2}!", number, i, number/i));
                    Console.ReadLine();
                }

            }
            return PrimeFactor;
        }

        public static bool IsPrime(int number)
        {
            List<int> Primes = new List<int> { 1, 2 };
            int counter = 3;

            while (number > counter)
            {
                for (int i = 0; i < Primes.Count; i++)
                {
                    if (number % Primes[i] == 0)
                    {
                        return false;
                    }
                }
                Primes.Add(counter);
                Console.WriteLine(counter + " is a Prime Number!");
                counter++;
            }
            return true;
        }

        public static List<int> GetPrimeNumbers(int number)
        {
            List<int> PrimeNumber = new List<int>();

            for (int i = 2; i < number; i++)
            {
                //Start bei i = 2, da 2 die kleinste Primzahl ist.
                if (i == 3)
                {
                    PrimeNumber.Add(i);
                    Console.WriteLine(i + " is a prime number.");
                    Console.ReadLine();
                }

                if (i == 5)
                {
                    PrimeNumber.Add(i);
                    Console.WriteLine(i + " is a prime number.");
                    Console.ReadLine();
                }

                if (i == 7)
                {
                    PrimeNumber.Add(i);
                    Console.WriteLine(i + " is a prime number.");
                    Console.ReadLine();
                }


                if (i % 2 != 0 && i % 1 == 0 && i % 3 != 0 && i % 5 != 0 && i % 7 != 0 && i % i == 0)
                {
                    Console.WriteLine(i + " is a prime number.");
                    //Format Error?
                    //Console.WriteLine(string.Format("{0} is a Prime Number!"), i); 
                    Console.ReadLine();
                }
            }

            return PrimeNumber;
        }
    }
}
