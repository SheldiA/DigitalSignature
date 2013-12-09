using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigitalSignature
{
    class RSA
    {
        public int p;
        public int q;
        private int r;
        private int functionEuler;
        public int publicKey;
        public int privateKey;
        private Generator generator;
        private ResidueNumberSstem modArithmetic;
        public readonly int maxPrimeNumber;

        public RSA(int pPos,int qPos,bool isBreaking,int maxPrimeCount)
        {
            generator = new Generator();
            this.maxPrimeNumber = maxPrimeCount;
            generator.GeneratePrimeIntegers(maxPrimeNumber);
            modArithmetic = new ResidueNumberSstem();
            if (!isBreaking)
            {                
                this.p = generator.primeNumbers[pPos % generator.primeNumbers.Count];
                this.q = generator.primeNumbers[qPos % generator.primeNumbers.Count];
                CalculateData();
            }
            else
                functionEuler = 0;
        }

        private void CalculateData()
        {
            r = p * q;
            functionEuler = (p - 1) * (q - 1);
            publicKey = generator.GenerateCoprimeInteger(functionEuler);
            privateKey = modArithmetic.ExtendedEuclid(functionEuler, publicKey);
        }

        public int Encrypt(int message)
        {
            int result = 0;
            result = modArithmetic.FastExp(message, publicKey, r);
            return result;
        }

        public int Decrypt(int cipher)
        {
            int result = 0;
            result = modArithmetic.FastExp(cipher, privateKey, r);
            return result;
        }

        public int Breaking(int r, int publicKey, int message)
        {
            int result = 0;

            /*this.r = r;
            this.publicKey = publicKey;
            double maxPublicKey = ((double)1 / (double)3) * Math.Pow(r,1.0/4.0);
            int currA = publicKey / r;
            double currRemainder = (double)publicKey / (double)r - (double)currA;
            int[] pn = {1,currA,0};
            int[] qn = {0,1,0};

            //while(qn[2] < maxPublicKey)
            while(currRemainder - 0.00000000000001 > 0)
            {
                if (Math.Pow(message,qn[2] * publicKey) % r == message % r)
                    break;
                currA = (int)(1 / currRemainder);
                currRemainder = 1 / currRemainder - currA;
                pn[0] = pn[1];
                pn[1] = pn[2];
                qn[0] = qn[1];
                qn[1] = qn[2];
                pn[2] = currA * pn[1] + pn[0];
                qn[2] = currA * qn[1] + qn[0];
            }
            result = qn[2];*/
            //generator.GeneratePrimeIntegers(r / 2);
            if (functionEuler == 0)
            {
                this.r = r;
                this.publicKey = publicKey;
                List<int> primeNumbers = generator.primeNumbers;
                bool isFind = false;
                for (int i = 0; i < primeNumbers.Count; ++i)
                {
                    for (int j = 0; j < primeNumbers.Count; ++j)
                        if ((primeNumbers[i] * primeNumbers[j]) == r)
                        {
                            functionEuler = (primeNumbers[i] - 1) * (primeNumbers[j] - 1);
                            p = primeNumbers[i];
                            q = primeNumbers[j];
                            privateKey = modArithmetic.ExtendedEuclid(functionEuler, publicKey);
                            isFind = true;
                            break;
                        }
                    if (isFind)
                        break;
                }
            }
            result = Decrypt(message);
            return result;
        }
    }
}
