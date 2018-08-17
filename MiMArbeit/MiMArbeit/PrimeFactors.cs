using System;
using System.Collections.Generic;

namespace MiMArbeit
{
    internal class PrimeFactors
    {
        public static bool IsPrime(int x)
        {
            for (int i = 2; i < x; i++)
            {
                if (x % i == 0) return false;
            }
            return true;
        }
        public static List<int> Generate(int x)
        {
            List<int> result = new List<int>();
            int tmp = 0;


            if (IsPrime(x)) result.Add(x);
            else
            {
                    tmp = x / 2;

                    if (IsPrime(tmp))
                        for (int j = 2; j < x; j++)
                        {
                            if (j * tmp == x && IsPrime(j))
                            {
                                result.Add(j);
                                result.Add(tmp);
                                return result;
                            }
                            else
                            {

                            }
                        }
                
            }
            return result;
        }
       
    }
}