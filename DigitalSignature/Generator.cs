using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigitalSignature
{
    class Generator
    {
        public List<int> primeNumbers;

        public Generator()
        {
            primeNumbers = new List<int>();
        }

        public void GeneratePrimeIntegers(int number)
        {
            List<bool> allNumbers = new List<bool>();
            allNumbers.Add(false);
            allNumbers.Add(false);
            for (int i = 2; i <= number; ++i)
                allNumbers.Add(true);
            for (int i = 2; i * i <= number; ++i)
            {
                if (allNumbers[i])
                {
                    for (int j = i * i; j <= number; j += i)
                        allNumbers[j] = false;
                }
            }
            for (int i = 0; i <= number; ++i)
                if (allNumbers[i])
                    primeNumbers.Add(i);
        }

        private int EuclideanAlgorithm(int a, int b)
        {
            int temp = 0;
            if (a < b)
            {
                temp = a;
                a = b;
                b = temp;
            }
            while (b != 0)
            {
                temp = a % b;
                a = b;
                b = temp;
            }
            return a;
        }

        public int GenerateCoprimeInteger(int primeInteger)
        {
            int result = 0;

            for (int i = 2; i < primeInteger; ++i)
            {
                if (EuclideanAlgorithm(primeInteger, i) == 1)
                {
                    result = i;
                    break;
                }
            }

            return result;
        }
    }
}
