using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIM_PrimeFactors
{
    public static class PrimeFactors
    {
        public static List<int> generate(int Zahl)
        {
            List<int> PrimeFactors = new List<int>();
            double sqrt = Math.Sqrt(Zahl);
            double ueber = sqrt % 2;
            if (IsPrimeFactor(Zahl))
            {
                PrimeFactors.Add(Zahl);
                return PrimeFactors;
            }
            Console.WriteLine(ueber);
            Console.ReadLine();
            return null;
        }
        public static bool IsPrimeFactor(int zl)
        {
            for (int i = 2; i < zl, i++)
            {
                double ueber = zl% i;
                if (ueber == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}