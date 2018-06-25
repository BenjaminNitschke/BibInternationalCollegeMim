using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumber
{
    public class PrimeFactors
    {
        public static List<int> GetPrimeNumbers(int n)
        {
            List<int> primeNumbers = new List<int>();
            
            int[] temp = new int[1000000];

            for(int i = 0; i < temp.Length; i++)
            {
                temp[i] = i+1;
            }

            for (int i = 1; i < temp.Length; i++)
            {
                if (temp[i] != -1)
                {
                    for (int j = i + temp[i]; j < temp.Length; j += temp[i])
                    {
                        temp[j] = -1;
                    }
                }
            }

            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] != -1) primeNumbers.Add(temp[i]);
                if (primeNumbers.Count == n) break;
            }

            return primeNumbers;
        }

        public static List<string> GetPrimeFactors(int n)
        {
            List<string> primeFactors = new List<string>();
            List<int> primeNumbers = GetPrimeNumbers(n);

            for(int i = 1; i < n+1; i++)
            {
                if(primeNumbers.Contains(i))
                {
                    primeFactors.Add(string.Format("{0} = {1}", i, i));
                }
                else
                {
                    primeFactors.Add(string.Format("{0} = {1}", i, GetNumberFactorized(i, primeNumbers)));
                }
            }

            return primeFactors;
        }

        private static string GetNumberFactorized(int n, List<int> primeNumbers)
        {
            string s = null;

            int[] times = new int[primeNumbers.Count];

            for(int i = 0; i < times.Length; i++)
            {
                times[i] = 0;
            }

            int num = n;
            int primNum = 1;
            while(num > 1)
            {
                if(num % primeNumbers[primNum] == 0)
                {
                    times[primNum]++;
                    num /= primeNumbers[primNum];
                }
                else
                {
                    primNum++;
                }
            }

            for (int i = 0; i < times.Length; i++)
            {
                for (int j = 0; j < times[i]; j++)
                {
                    if (s == null) s = (i + 1).ToString();
                    else
                    {
                        s = string.Format("{0} * {1}", s, primeNumbers[i]);
                    }
                }
            }

            return s;
        }
    }
}
