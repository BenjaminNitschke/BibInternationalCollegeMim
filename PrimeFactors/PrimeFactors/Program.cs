using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeFactors
{
    class Program
    {
        static PrimeFactors factors = new PrimeFactors();
        static void Main(string[] args)
        {
            Console.WriteLine("IsPrime(1)= " + PrimeFactors.IsPrime(20));
            Console.ReadLine();

            PrimeFactors.GetPrimeFactors(20);

            PrimeFactors.GetPrimeNumbers(100);
        }
    }
}
