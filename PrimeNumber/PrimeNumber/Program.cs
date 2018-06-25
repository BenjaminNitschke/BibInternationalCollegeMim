using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumber
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //List<int> myPrimeNumbers = PrimeFactors.GetPrimeNumbers(10);

            //for (int i = 0; i < myPrimeNumbers.Count; i++)
            //{
            //    Console.WriteLine(string.Format("{0}: {1}", i+1 ,myPrimeNumbers[i]));
            //}

            //Console.WriteLine();

            List<string> myPrimeFactors = PrimeFactors.GetPrimeFactors(20);

            for (int i = 0; i < myPrimeFactors.Count; i++)
            {
                Console.WriteLine(myPrimeFactors[i]);
            }
        }
    }
}
