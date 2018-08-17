using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiMArbeit
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("2=" + string.Join("*", PrimeFactors.Generate(2)));
            Console.WriteLine("4=" + string.Join("*", PrimeFactors.Generate(4)));
            Console.WriteLine("5=" + string.Join("*", PrimeFactors.Generate(5)));
            Console.WriteLine("6=" + string.Join("*", PrimeFactors.Generate(6)));
            Console.WriteLine("8=" + string.Join("*", PrimeFactors.Generate(8)));
            //Console.WriteLine("9=" + string.Join("*", PrimeFactors.Generate(9)));
            //Console.WriteLine("10=" + string.Join("*", PrimeFactors.Generate(10)));            
        }     
    }
}
