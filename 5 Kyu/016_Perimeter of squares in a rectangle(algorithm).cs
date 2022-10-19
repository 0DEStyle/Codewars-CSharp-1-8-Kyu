/*Challenge link: https://www.codewars.com/kata/559a28007caad2ac4e000083/train/csharp
Question:
The drawing shows 6 squares the sides of which have a length of 1, 1, 2, 3, 5, 8. It's easy to see that the sum of the perimeters of these squares is : 4 * (1 + 1 + 2 + 3 + 5 + 8) = 4 * 20 = 80 

Could you give the sum of the perimeters of all the squares in a rectangle when there are n + 1 squares disposed in the same manner as in the drawing:

image url : https://i.imgur.com/EYcuB1wm.jpg

Hint:
See Fibonacci sequence

Ref:
http://oeis.org/A000045

The function perimeter has for parameter n where n + 1 is the number of squares (they are numbered from 0 to n) and returns the total perimeter of all the squares.

perimeter(5)  should return 80
perimeter(7)  should return 216
*/

//***************Solution********************

//apply aogirithm, set data type to biginter to avoid negative overflow, return the result
using System;
using System.Numerics;

public class SumFct
{
  public static BigInteger perimeter(BigInteger n) {
    BigInteger a = 0, b = 1, newB = 0, fib = 0, perimeters = 0;
    
    for (int i = 0; i < n + 1; i++) {
      fib = b;
      perimeters += 4 * (fib);

      //renew number for next loop
      newB = a + b;
      a = b;
      b = newB;
    }
    return perimeters;
  }
}

//****************Sample Test*****************
using System;
using NUnit.Framework;
using System.Numerics;

[TestFixture]
public class SumFctTests {
    
[Test]
    public void Test1() {
        Assert.AreEqual(new BigInteger(80), SumFct.perimeter(new BigInteger(5)));
    }
[Test]
    public void Test2() {
        Assert.AreEqual(new BigInteger(216), SumFct.perimeter(new BigInteger(7)));
    }
[Test]
    public void Test3() {
        Assert.AreEqual(new BigInteger(14098308), SumFct.perimeter(new BigInteger(30)));
    }
[Test]
    public void Test4() {
        BigInteger bigInt = 0;
        bigInt = BigInteger.Parse("6002082144827584333104");
        Assert.AreEqual(bigInt , SumFct.perimeter(new BigInteger(100)));
    }
[Test]
    public void Test5() {
        BigInteger bigInt = 0;
        bigInt = BigInteger.Parse("2362425027542282167538999091770205712168371625660854753765546783141099308400948230006358531927265833165504");
        Assert.AreEqual(bigInt, SumFct.perimeter(new BigInteger(500)));
    }
  
    //---------------------------------------
    public static BigInteger solution130412(BigInteger n) {
        BigInteger res  = new BigInteger(1);
        BigInteger tmp  = new BigInteger(1);
        BigInteger prev = new BigInteger(1);
        BigInteger next = new BigInteger(1);
        BigInteger four = new BigInteger(4);
        for (BigInteger i = new BigInteger(1); i <= n; i++) 
        {
            res = BigInteger.Add(res, next);
            tmp = next;
            next = BigInteger.Add(next, prev);
            prev = tmp;
        }
        return BigInteger.Multiply(res, four);
    }
    //---------------------------------------
[Test]
    public static void Test6() {
        Console.WriteLine("\n Random Tests ****************");
        Random rnd = new Random();
        for (int i = 0; i < 15; i++) {
            int n = rnd.Next(100, 50000);
            Console.WriteLine("Number : " + n);
            Assert.AreEqual(SumFctTests.solution130412(n), SumFct.perimeter(new BigInteger(n)));
        }
    }
}
