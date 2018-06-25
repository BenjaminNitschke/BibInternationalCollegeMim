using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeFactors
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator(20);

            calc.DebugList();
        }
    }
}
