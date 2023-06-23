/*Challenge link:https://www.codewars.com/kata/5b853229cfde412a470000d0/train/csharp
Question:
Your function takes two arguments:

current father's age (years)
current age of his son (years)
Сalculate how many years ago the father was twice as old as his son (or in how many years he will be twice as old). The answer is always greater or equal to 0, no matter if it was in the past or it is in the future.
*/

//***************Solution********************
//answer is always positive, so use the absolute value of the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;

namespace Solution
{
  public class TwiceAsOldSolution
  {
    public static int TwiceAsOld(int dadYears, int sonYears)
    {
      return Math.Abs(dadYears - (sonYears * 2));
    }
  }
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

namespace Solution {
  [TestFixture]
  public class TwiceAsOldTest
  {
    [Test]
    public void FixedTests()
    {
      Assert.AreEqual(30, TwiceAsOldSolution.TwiceAsOld(30, 0));
      Assert.AreEqual(16, TwiceAsOldSolution.TwiceAsOld(30, 7));
      Assert.AreEqual(15, TwiceAsOldSolution.TwiceAsOld(45, 30));
      Assert.AreEqual(22, TwiceAsOldSolution.TwiceAsOld(36, 7));
      Assert.AreEqual(5, TwiceAsOldSolution.TwiceAsOld(55, 30));
      Assert.AreEqual(0, TwiceAsOldSolution.TwiceAsOld(42, 21));
      Assert.AreEqual(20, TwiceAsOldSolution.TwiceAsOld(22, 1));
      Assert.AreEqual(29, TwiceAsOldSolution.TwiceAsOld(29, 0));
    }
    
    [Test]
    public void RandomTests()
    {
      Random random = new Random();
      
      for (int i = 50; i > 0; i--) {
        int dad = random.Next(82) + 18;
        int son = dad - (random.Next(22) + 18);
        
        if(son < 0) {
          son = 0;
        }
        
        Assert.AreEqual(LocalTwiceAsOld(dad, son), TwiceAsOldSolution.TwiceAsOld(dad, son));
      }
    }
    
    private int LocalTwiceAsOld(int dadYears, int sonYears)
    {
      return Math.Abs(dadYears - sonYears * 2);
    }
  }
}
