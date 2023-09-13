/*Challenge link:https://www.codewars.com/kata/527e4141bb2ea5ea4f00072f/train/csharp
Question:
Find the sum of the digits of all the numbers from 1 to N (both ends included).

Examples
# N = 4
1 + 2 + 3 + 4 = 10

# N = 10
1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 + 9 + (1 + 0) = 46

# N = 12
1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 + 9 + (1 + 0) + (1 + 1) + (1 + 2) = 51
*/

//***************Solution********************

//if n is less than or equal to 0, return to 0
//else check if (n+1) mod 10 is equal to 0
//if true, 45 * ((n + 1) / 10) + 10 * recurssive method to get all result of (n + 1) / 10) - 1
//else recurssive method (n - 1) + 
//convert n to string, then to list, then convert each ch to int and get total sum.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;

public class TwistedSum{
  public static long Solution(long n) => n <= 0 ?  0 : 
          ((n + 1) % 10) == 0 ? 45 * ((n + 1) / 10) + 10 * Solution((int)((n + 1) / 10) - 1) :
          Solution(n - 1) + n.ToString().ToList().ConvertAll(ch => (int)Char.GetNumericValue(ch)).Sum();
}

//****************Sample Test*****************
using NUnit.Framework;
using System;

[TestFixture]
public class Tests
{ 
    private static Random rand = new Random();
    
    private static long RefSolution(long n)
    {
  	  Func<long,long,long> f = (x,y) => x/y*(x+x%y-y+2)/2;
  	  var r = (int)Math.Ceiling(Math.Log10(n));
  	  long d = 1;
  	  long sum = 0;
  	  for(var i=0;i<=r;i++)
  	  {
  		  sum += f(n,d)-10*f(n,10*d); 
  		  d *= 10;		
  	  }
  	  return sum;
    }
    
    /*
    [Test]
    public void Test01()
    {
      Assert.AreEqual(6,TwistedSum.Solution(3));
    }
    [Test]
    public void Test02()
    {
      Assert.AreEqual(46,TwistedSum.Solution(10));
    }
    [Test]
    public void Test03()
    {
      Assert.AreEqual(48,TwistedSum.Solution(11));
    }
    [Test]
    public void Test04()
    {
      Assert.AreEqual(51,TwistedSum.Solution(12));
    }
    [Test]
    public void Test05()
    {
      Assert.AreEqual(13500,TwistedSum.Solution(999));
    }    
    [Test]
    public void Test07()
    {
      Assert.AreEqual(1038,TwistedSum.Solution(123));
    }
    */
    [Test]
    public void RandomTest()
    {
      for(int i=0; i<100; i++) {
        int num = rand.Next(0,10000);
        Assert.AreEqual(RefSolution(num), TwistedSum.Solution(num));
      }
    }
}
