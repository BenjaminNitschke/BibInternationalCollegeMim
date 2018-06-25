using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIM_PrimeFactorsProgram
{
    class Program
    {
        static void Main()
        {
            List<int> Try = Program.generate(9);
            foreach (int t in Try)
            {
                Console.WriteLine(t);
            }
            Console.ReadLine();
        }
     }
}