using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApplicationPrimeNumbers
{

    class MainMethod

    {

       
        static void Main(string[] args)
        {
            int x = 200;

            List<int> output = new List<int>();

            PrimeFactors prime = new PrimeFactors();
           output = prime.getPrimeFactors(x);
            
            foreach(int y in output)
            {
                Console.WriteLine(y);
            }
           
        }
    }


    class PrimeNumbers
    {
        float check;
        private List<int> primeNumbers = new List<int>();
       public List<int> getPrimeNumbers(int number)
        {

            for (int i = 1; i <= number; i++)
            {
                for (int j =1;j<= i;j++)
                {
                    check = i / j;

                    if (check % 1 == 0)
                    {
                        primeNumbers.Add(i / j);
                    }

                }



            }




            return primeNumbers;

        }
        

    }



    class PrimeFactors
        {
       // private List<int> temp = new List<int>();
        public List<int> primeNumbers = new List<int>();
        private List<int> primeFactors = new List<int>();
        float n;
       public List<int> getPrimeFactors(int number)
        {
            PrimeNumbers getprimes = new PrimeNumbers();
            primeNumbers = getprimes.getPrimeNumbers(number);
            foreach (int prime in primeNumbers)
            {
                n = number / prime;
                if (n % 1 == 0 && (!primeNumbers.Contains(number/prime)))
                {
                    primeFactors.Add(prime);
                    getPrimeFactors(number / prime);
                   

                }
                else
                {
                    if (n % 1 == 0 && (primeNumbers.Contains(number/prime)))
                    {
                        primeFactors.Add(number/prime);
                       // primeFactors.Add(0);
                        
                    }
                    else{
                       
                    }
                }





            }

            return primeFactors;
               
        }
    }
}