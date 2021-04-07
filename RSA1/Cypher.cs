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
        public static int e2;
        public static string answer;
        public static string answerde;
        public static string atsde;
        public static string Enxryption(BigInteger p, BigInteger q, List<int>ascii)
        {
            BigInteger n;
            //modulus, second number (x,n)
            n = p* q;

            BigInteger fi;
            //fi function
            fi = (p - 1) * (q - 1);

            //we need e mnumber, it is first numer (e,x)
            for (int i=2; i < fi; i++)
            {
                if ( prime(i) && coprime(i,fi) && fi != i && q != i && p != i)
                {
                    e = i;
                    break;
                 
                }
                //Console.WriteLine("no");
            }
            Console.WriteLine(e + " e , " + n + " n");
            Console.WriteLine(fi + " raktas");

            cyphermod(e, fi,out BigInteger result);
            BigInteger d = result;
            Console.WriteLine(d + " <- d");

            //cypher formula
            foreach(int word in ascii)
            {
                answer += BigInteger.Pow(word, e) % n + " ";  
            }
            answer = answer.Substring(0,answer.Length-1);
            Console.WriteLine(answer);

            //DB here
            DataBase db = new DataBase();
            db.insert(answer,e,n);

            //toTextbox
            return answer;
        }
        public static string Decryption(BigInteger[] Etext, BigInteger n, BigInteger e1)
        {
            try
            {
                BigInteger q;
                BigInteger p;
                p = 2;
                while (n % p > 0)
                {
                    p++;
                }
                Console.WriteLine(p + " given p");
                //finds q 
                q = n / p;
                Console.WriteLine(q + " given q");
                BigInteger fi;
                //fi number
                fi = (p - 1) * (q - 1);

                //mod 
                cyphermod((int)e1, fi,out BigInteger result);
                BigInteger d = result;
                Console.WriteLine("its d -> " + d);

                //decryption formula
                char[] word = new char[Etext.Length];
                for (int i =0; i < Etext.Length;i++)
                {
                    word[i] = (char)(BigInteger.Pow(Etext[i], (int)d) % n);
                }

                return new string (word);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        public static bool cyphermod(int number, BigInteger modulo, out BigInteger result)
        {
            if (number < 1) throw new ArgumentOutOfRangeException(nameof(number));
            if (modulo < 2) throw new ArgumentOutOfRangeException(nameof(modulo));
            BigInteger n = number;
            BigInteger m = modulo, v = 0, d = 1;
            while (n > 0)
            {
                BigInteger t = m / n, x = n;
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
        static bool prime(BigInteger prime)
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
                for (BigInteger i = 5; i*i <= prime; i += 6)
                {
                    if (prime % i == 0 || prime % (i + 2) == 0)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        static bool coprime(BigInteger e, BigInteger fi)
        {
            BigInteger cprime;
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
