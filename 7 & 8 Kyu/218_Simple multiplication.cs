/*Challenge link:https://www.codewars.com/kata/583710ccaa6717322c000105/train/csharp
Question:
This kata is about multiplying a given number by eight if it is an even number and by nine otherwise.
*/

//***************Solution********************
//apply algorihm
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Multiplier{
  public static int Multiply(int x) => x % 2 == 0 ? x * 8 : x * 9;
}  

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  
  public class Solve
  {
    public static int GetTheAnswer(int x) 
    {
      return x % 2 == 0 ? x*8 : x*9;
    }
  }

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual(9, Multiplier.Multiply(1),"Should return given argument times nine");
      Assert.AreEqual(16, Multiplier.Multiply(2), "Should return given argument times eight");
      Assert.AreEqual(64, Multiplier.Multiply(8), "Should return given argument times eight");
      Assert.AreEqual(32, Multiplier.Multiply(4), "Should return given argument times eight");
      Assert.AreEqual(45, Multiplier.Multiply(5), "Should return given argument times nine");
    }
    
    [Test]
    public void RandomTest()
    {
      Random rand = new Random();
      for (int i = 0; i < 100; i++)
      {        
        int num = rand.Next(1,1000);
        Assert.AreEqual(Solve.GetTheAnswer(num), Multiplier.Multiply(num));
      }
    }
  }
}
