using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RSA1
{
    class Cypher
    {
        public static int e;
        public static string answer;
        public static string Enxryption(int p, int q, List<int>ascii)
        {
            int n;
            //modulus, second number (x,n)
            n = p* q;

            int fi;
            //fi function
            fi = (p - 1) * (q - 1);

            //we need e mnumber, it is first numer (e,x)
            for (int i=2; i < fi; i++)
            {
                if ( prime(i) && coprime(i,fi))
                {
                    if (fi != i && q != i && p != i)
                    {
                    e = i;
                    break;
                    }
                }
            }
            Console.WriteLine(e + " , " + n + " e ir n");
            Console.WriteLine(fi + " raktas");

            cyphermod(e, fi,out BigInteger result);
            BigInteger d = result;
            Console.WriteLine(d);

            //cypher
            foreach(int word in ascii)
            {
                answer += BigInteger.Pow(word, e) % n + " ";  
            }
            answer = answer.Substring(0,answer.Length-1);
            Console.WriteLine(answer);
            //DB here


            //toTextbox
            return answer;
        }
        public static string Decryption()
        {
            return "hi";
        }
        public static bool cyphermod(int number, int modulo, out BigInteger result)
        {
            if (number < 1) throw new ArgumentOutOfRangeException(nameof(number));
            if (modulo < 2) throw new ArgumentOutOfRangeException(nameof(modulo));
            int n = number;
            int m = modulo, v = 0, d = 1;
            while (n > 0)
            {
                int t = m / n, x = n;
                n = m % x;
                m = x;
                x = d;
                d = checked(v - t * x); // Just in case
                v = x;
            }
            result = v % modulo;
            if (result < 0) result += modulo;
            if ((long)number * result % modulo == 1L) return true;
            result = default;
            return false;
        }
        static bool prime(int prime)
        {
            if (prime > 1 && prime <= 3 )
            {
                return true;
            }
            else if (prime==1 || prime % 2 == 0 || prime % 3 == 0)
            {
                return false;
            }
            else
            {
                for (int i = 1; i*i <= prime; i += 6)
                {
                    if (prime % i == 0 || prime % (i + 2) == 0)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        static bool coprime(int e, int fi)
        {
            int cprime;
            while ( fi != 0 )
            {
                cprime = e;
                e = fi;
                fi = cprime % fi;
            }
            if (e == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
