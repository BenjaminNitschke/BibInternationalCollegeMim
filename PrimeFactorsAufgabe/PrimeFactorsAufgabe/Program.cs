using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeFactorsAufgabe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("IsPrime(1)=" + PrimeFactors.isPrime(1));
            Console.WriteLine("IsPrime(1)=" + PrimeFactors.isPrime(3));
            Console.WriteLine("IsPrime(1)=" + PrimeFactors.isPrime(4));

            var numbers = PrimeFactors.GetPrimeNumbers(10);
            Console.Write("GetPrimeNumbers(10)=");
            foreach (var number in numbers)
                Console.Write(number + ", ");
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
                Console.WriteLine("Generate(" + i + ")=" + String.Join("*", PrimeFactors.Generate(i)));
        }
    }
}
