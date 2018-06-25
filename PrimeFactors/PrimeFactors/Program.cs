using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeFactors
{
    public class Program
    {

        public static void Main()
        {
            var pf = new PrimeFactors();
            Console.WriteLine(pf.IsPrime(7));
            pf.GetPrimeNumbers(13);

        }

    }

}