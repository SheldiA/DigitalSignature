using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigitalSignature
{
    class ResidueNumberSstem
    {
        public int ExtendedEuclid(int a, int b)
        {
            int d0 = a, d1 = b, q, d2, x2, y2, x0 = 1, x1 = 0, y0 = 0, y1 = 1;
            while (d1 > 1)
            {
                q = d0 / d1;
                d2 = d0 % d1;
                x2 = x0 - q * x1;
                y2 = y0 - q * y1;
                d0 = d1;
                d1 = d2;
                x0 = x1;
                x1 = x2;
                y0 = y1;
                y1 = y2;
            }
            if (y1 < 0)
                y1 += a;
            return y1;
        }

        public int FastExp(int number, int power, int modul)
        {
            int a = number;
            int z = power;
            int x = 1;
            while (z != 0)
            {
                while (z % 2 == 0)
                {
                    z /= 2;
                    a = (a * a) % modul;
                }
                --z;
                x = (x * a) % modul;
            }
            return x;
        }
        
    }
}
