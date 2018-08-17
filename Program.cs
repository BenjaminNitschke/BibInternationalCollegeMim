//André Waldner

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeFactorsKata
                {//primzahl = zahlen durch sich selbst teilbar und durch 1
    class Program
    {
        

        static void Main()
        {
            Console.WriteLine("2=" + string.Join("*", Generate(2)));

            Console.WriteLine("4=" + string.Join("*", Generate(4)));

            Console.WriteLine("5=" + string.Join("*", Generate(5)));

            Console.WriteLine("6=" + string.Join("*", Generate(6)));

            Console.WriteLine("8=" + string.Join("*", Generate(8)));

            Console.WriteLine("9=" + string.Join("*", Generate(9)));

            Console.WriteLine("10=" + string.Join("*", Generate(10)));
        }

        public static int Generate(int number)
        {
            // 0 = 0 , 1 = 1 , 2 = 2 , 3 = 3 , 4 = 2 * 2 , 5 = 5 , 6 = 2 * 3 , 7 = 7 , 8 = 2 * 2 * 2
            if (number == 2)
            {
                
            }


            return number;
        }
    }

   
}
