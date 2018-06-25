using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeFactors
{
    // größer als 1
    // durch sich selbst teilbar
    // durch 1 teilbar

    class Calculator
    {
        private List<int> primeNumbers;

        public Calculator(int i)
        {
            primeNumbers = Generate(i);
        }

        private List<int> Generate(int range)
        {
            List<int> temp = new List<int>();

            for (int i = 1; i < range; i++)
            {
                if (CheckIfPrime(i))
                    temp.Add(i);
            }

            return temp;
        }

        //public bool CheckIfPrime(int number)
        //{
        //    int temp = 0;

        //    bool isPrime = false;

        //    //if (number == 1)
        //    //    isPrime = false;
        //    //else if (number == 2)
        //    //    isPrime = true;
        //    //else if (number % 2 == 0)
        //    //    isPrime = false;

        //    for (int i = 2; i < number / 2; i++)
        //    {
        //        if (number % i == 0)
        //            temp++;
        //    }

        //    if (temp == 2)
        //        isPrime = false;
        //    else
        //        isPrime = true;

        //    return isPrime;
        //}

        public bool CheckIfPrime(int number)
        {
            bool isPrime = false;

            int temp = 0;

            for(int i = 2; i < number / 2; i++)
                if (number % i == 0)
                    temp++;

            isPrime = (temp == 0 && number != 1) ? true : false;

            return isPrime;
        }

        public void DebugList()
        {
            for (int i = 0; i < primeNumbers.Count; i++)
            {
                Console.WriteLine(primeNumbers[i]);
            }
        }
    }
}
