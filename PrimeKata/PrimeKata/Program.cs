using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimeFactorsKata.PrimeKata;

namespace PrimeKata
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("IsPrime(1)=" + PrimeFactors.IsPrime(1));
            Console.WriteLine("IsPrime(3)=" + PrimeFactors.IsPrime(3));
            Console.WriteLine("IsPrime(4)=" + PrimeFactors.IsPrime(4));

            List<int> n = PrimeFactors.Primes(10);
            Console.Write(n + ", ");
            Console.WriteLine();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Generate(" + i + ")=" + String.Join("*",
                PrimeFactors.Generate(i)));
            }
        }
    }
}
