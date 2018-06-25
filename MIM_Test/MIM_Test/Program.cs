using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIM_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("IsPrime(1): " + PrimeFactors.IsPrime(1));
            Console.WriteLine("IsPrime(3): " + PrimeFactors.IsPrime(3));
            Console.WriteLine("IsPrime(4): " + PrimeFactors.IsPrime(4));
            Console.ReadLine();
            PrimeFactors.GetPrimeNumbers(3);
            PrimeFactors.Generate(15);
        }
    }
}
