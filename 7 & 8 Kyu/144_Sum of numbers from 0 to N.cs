/*Challenge link:https://www.codewars.com/kata/56e9e4f516bcaa8d4f001763/train/csharp
Question:
Description:

We want to generate a function that computes the series starting from 0 and ending until the given number.

Example:
Input:

> 6
Output:

0+1+2+3+4+5+6 = 21

Input:

> -15
Output:

-15<0

Input:

> 0
Output:

0=0


*/

//***************Solution********************
//apply format and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public class SequenceSum{
  public static string ShowSequence(int n) =>
    n < 0 ? $"{n}<0" : n == 0 ? "0=0" : $"{string.Join("+", Enumerable.Range(0, n + 1))} = {(1 + n) * n / 2}";
}


//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  
  [TestFixture]
  public class SequenceSumTests
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual("0+1+2+3+4+5+6 = 21", SequenceSum.ShowSequence(6));
      Assert.AreEqual("0+1+2+3+4+5+6+7 = 28", SequenceSum.ShowSequence(7));
    }
    
    [Test]
    public void NegativeAndZeroTests()
    { 
      Assert.AreEqual("0=0", SequenceSum.ShowSequence(0));
      Assert.AreEqual("-1<0", SequenceSum.ShowSequence(-1));
      Assert.AreEqual("-10<0", SequenceSum.ShowSequence(-10));      
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      
      Func<int,string> myShowSequence = delegate (int n)
      {
        if(n == 0)
        {
          return "0=0";
        }
        if(n < 0)
        {
          return n + "<0";
        }
        var sum = 0;
        var numbers = new int[n+1];
        for(int i = 0 ; i <= n ; i++)
        {
          sum += i;
          numbers[i] = i;
        }
    
        return string.Join("+", numbers) + " = " + sum;
      }; 
      
      for(int r = 0 ; r < 40 ; r++)
      {
        var number = rand.Next(0, 1000);
        Assert.AreEqual(myShowSequence(number), SequenceSum.ShowSequence(number));
      }
    }
  }
}
