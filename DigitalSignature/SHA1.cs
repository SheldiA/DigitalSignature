using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigitalSignature
{
    class SHA1
    {
        private readonly UInt32 constA, constB, constC, constD, constE, constK1, constK2, constK3, constK4;
        private UInt32 A, B, C, D, E, a, b, c, d, e;
        public SHA1()
        {
            A = constA = (UInt32)(Convert.ToUInt32("0x67452301", 16) % Math.Pow(2,32));
            B = constB = (UInt32)(Convert.ToUInt32("0xEFCDAB89", 16) % Math.Pow(2, 32));
            C = constC = (UInt32)(Convert.ToUInt32("0x98BADCFE", 16) % Math.Pow(2, 32));
            D = constD = (UInt32)(Convert.ToUInt32("0x10325476", 16) % Math.Pow(2, 32));
            E = constE = (UInt32)(Convert.ToUInt32("0xC3D2E1F0", 16) % Math.Pow(2, 32));
            constK1 = (UInt32)(Convert.ToUInt32("0x5A827999", 16) % Math.Pow(2, 32));
            constK2 = (UInt32)(Convert.ToUInt32("0x6ED9EBA1", 16) % Math.Pow(2, 32));
            constK3 = (UInt32)(Convert.ToUInt32("0x8F1BBCDC", 16) % Math.Pow(2, 32));
            constK4 = (UInt32)(Convert.ToUInt32("0xCA62C1D6", 16) % Math.Pow(2, 32));

        }

        public void Initialization()
        {
            a = constA;
            b = constB;
            c = constC;
            d = constD;
            e = constE;
        }

        private UInt32 LeftRotate(UInt32 number, int offset)
        {
            return ((number << offset) | (number >> (32 - offset)));
        }

        public void ProcessBlock(UInt32[] block)
        {
            UInt32[] w = new UInt32[80];
            UInt32 f, k;
            for (int i = 0; i < 16; ++i)
                w[i] = block[i];
            for (int i = 16; i < 80; ++i)
                w[i] = LeftRotate((w[i - 3] ^ w[i - 8] ^ w[i - 14] ^ w[i - 16]),1);
            Initialization();
            for (int i = 0; i < 80; ++i)
            {
                if (i <= 19)
                {
                    f = (b & c) | (~b & d);
                    k = constK1;
                }
                else
                    if (i <= 39)
                    {
                        f = b ^ c ^ d;
                        k = constK2;
                    }
                    else
                        if (i <= 59)
                        {
                            f = (b & c) | (b & d) |(c & d);
                            k = constK3;
                        }
                        else
                        {
                            f = b ^ c ^ d;
                            k = constK4;
                        }
                UInt32 temp = (UInt32)((LeftRotate(a, 5) + f + e + k + w[i]) % Math.Pow(2, 32));
                e = d;
                d = c;
                c = LeftRotate(b,30);
                b = a;
                a = temp;
            }
            A = (UInt32)((A + a) % Math.Pow(2, 32));
            B = (UInt32)((B + b) % Math.Pow(2, 32));
            C = (UInt32)((C + c) % Math.Pow(2, 32));
            D = (UInt32)((D + d) % Math.Pow(2, 32));
            E = (UInt32)((E + e) % Math.Pow(2, 32));
        }

        public string GetResultHash()
        {
            string result = "";

            result += ("  " + Convert.ToString(A, 16));
            result += ("  " + Convert.ToString(B, 16));
            result += ("  " + Convert.ToString(C, 16));
            result += ("  " + Convert.ToString(D, 16));
            result += ("  " + Convert.ToString(E, 16));

            return result;
        }
    }

    
}
