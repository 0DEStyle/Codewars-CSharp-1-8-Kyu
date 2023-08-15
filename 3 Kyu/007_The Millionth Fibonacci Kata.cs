/*Challenge link:https://www.codewars.com/kata/53d40c1e2f13e331fc000c26/train/csharp
Question:
The year is 1214. One night, Pope Innocent III awakens to find the the archangel Gabriel floating before him. Gabriel thunders to the pope:

Gather all of the learned men in Pisa, especially Leonardo Fibonacci. In order for the crusades in the holy lands to be successful, these men must calculate the millionth number in Fibonacci's recurrence. Fail to do this, and your armies will never reclaim the holy land. It is His will.

The angel then vanishes in an explosion of white light.

Pope Innocent III sits in his bed in awe. How much is a million? he thinks to himself. He never was very good at math.

He tries writing the number down, but because everyone in Europe is still using Roman numerals at this moment in history, he cannot represent this number. If he only knew about the invention of zero, it might make this sort of thing easier.

He decides to go back to bed. He consoles himself, The Lord would never challenge me thus; this must have been some deceit by the devil. A pretty horrendous nightmare, to be sure.

Pope Innocent III's armies would go on to conquer Constantinople (now Istanbul), but they would never reclaim the holy land as he desired.

In this kata you will have to calculate fib(n) where:

fib(0) := 0
fib(1) := 1
fib(n + 2) := fib(n + 1) + fib(n)
Write an algorithm that can handle n up to 2000000.

Your algorithm must output the exact integer answer, to full precision. Also, it must correctly handle negative numbers as input.

HINT I: Can you rearrange the equation fib(n + 2) = fib(n + 1) + fib(n) to find fib(n) if you already know fib(n + 1) and fib(n + 2)? Use this to reason what value fib has to have for negative values.

HINT II: See https://web.archive.org/web/20220614001843/https://mitpress.mit.edu/sites/default/files/sicp/full-text/book/book-Z-H-11.html#%_sec_1.2.4


*/

//***************Solution********************
//https://web.archive.org/web/20220614001843/https://mitpress.mit.edu/sites/default/files/sicp/full-text/book/book-Z-H-11.html#%_sec_1.2.4
using System;
using System.Numerics;

public class Fibonacci{
    public static BigInteger fib(int n){
            BigInteger semn = 1, h = 1, t = 0, i = 1, j = 0, k = 0;

            if (n < 0){
                n *= -1;
                semn = n % 2 == 0 ? -1 : 1;
            }

            while (n > 0){
                if (n % 2 != 0){
                    t = j * h;
                    j = i * h + j * k + t;
                    i = i * k + t;
                }
              
              //update variables
                t = h * h;
                h = 2 * k * h + t;
                k = k * k + t;
                n /= 2;
            }

            return j * semn;
    }
}

//method 2
using System.Numerics;

public class Fibonacci
{
        public static BigInteger fib(int n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }

            if (n == -1)
            {
                return 1;
            }

            if (n <= -1)
            {
                return (n % 2 != 0 ? 1 : -1) * fib(-n);
            }
            else
            {
                BigInteger a = 0;
                BigInteger b = 1;
                for (int i = 31; i >= 0; i--)
                {
                    BigInteger d = a * (b * 2 - a);
                    BigInteger e = a * a + b * b;
                    a = d;
                    b = e;
                    if ((((uint)n >> i) & 1) != 0)
                    {
                        BigInteger c = a + b;
                        a = b;
                        b = c;
                    }
                }

                return a;
            }
        }
}
//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Numerics;

public class FibonacciTest
{

    [Test]
    public void testFib()
    {
        List<int> tests = new List<int> { 0, 1, 2, 3, 4, 5, -6, -96, 1000, 1001 };

        Random rnd = new Random();
        for (int i = 0; i < 10; ++i)
        {
            tests.Add(rnd.Next(-100, 0));
        }
        tests.Add(rnd.Next(10000, 100000));
        tests.Add(rnd.Next(1000000, 1500000));

        foreach (int n in tests)
        {
            BigInteger found = Fibonacci.fib(n);
            Assert.AreEqual(FibonacciRef.fib(n), found);
        }
    }
    
    private static class FibonacciRef
    {
        private static IDictionary<int, BigInteger> fibs = new Dictionary<int, BigInteger>();

        static FibonacciRef()
        {
            fibs[0] = BigInteger.Zero;
            fibs[1] = BigInteger.One;
            fibs[2] = BigInteger.One;
            fibs[3] = fibs[2] + fibs[1];
            fibs[4] = fibs[3] + fibs[2];
            fibs[5] = fibs[4] + fibs[3];
        }

        private static BigInteger calcFib(int n)
        {
            BigInteger result;
            if (fibs.TryGetValue(n, out result))
                return result;

            if ((n & 1) == 1)
            {

                int k = (n + 1) / 2;
                BigInteger fk = BigInteger.Pow(calcFib(k), 2);
                BigInteger fkm1 = BigInteger.Pow(calcFib(k - 1), 2);
                result = fk + fkm1;
            }
            else
            {
                int k = n / 2;
                BigInteger fk = calcFib(k);
                BigInteger fkm1 = calcFib(k - 1);
                result = (fkm1 * fibs[3] + fk) * fk;
            }

            fibs[n] = result;
            return result;
        }

        public static BigInteger fib(int n)
        {
            bool neg = n < 0;

            if (neg)
                n = -n;

            BigInteger result = calcFib(n);

            if (neg && (n & 1) == 0)
                result = -result;

            return result;
        }
    }
}
