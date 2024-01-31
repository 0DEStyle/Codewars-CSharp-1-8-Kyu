/*Challenge link:https://www.codewars.com/kata/55f2b110f61eb01779000053/train/csharp
Question:
Given two integers a and b, which can be positive or negative, find the sum of all the integers between and including them and return it. If the two numbers are equal return a or b.

Note: a and b are not ordered!

Examples (a, b) --> output (explanation)
(1, 0) --> 1 (1 + 0 = 1)
(1, 2) --> 3 (1 + 2 = 3)
(0, 1) --> 1 (0 + 1 = 1)
(1, 1) --> 1 (1 since both are same)
(-1, 0) --> -1 (-1 + 0 = -1)
(-1, 2) --> 2 (-1 + 0 + 1 + 2 = 2)
Your function should only return a number, not the explanation about how you get that number.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using static System.Math;
public class Sum{
  public int GetSum(int a, int b) => (Abs(a - b) + 1) * (a+b) / 2;
}

//****************Sample Test*****************
  using NUnit.Framework;
  using System;
  
  [TestFixture]
  public class SumTest
  {
    Sum s = new Sum();

    [Test]
    public void TestPositive()
    {
      Assert.AreEqual(1, s.GetSum(0, 1));
      Assert.AreEqual(3, s.GetSum(1, 2));
      Assert.AreEqual(14, s.GetSum(5, -1));
      Assert.AreEqual(127759, s.GetSum(505, 4));
      Assert.AreEqual(44178, s.GetSum(321, 123));
    }
    
    [Test]
    public void TestNegative()
    {
      Assert.AreEqual(-1, s.GetSum(0, -1));
      Assert.AreEqual(-1275, s.GetSum(-50, 0));
      Assert.AreEqual(-15, s.GetSum(-1, -5));
      Assert.AreEqual(-5, s.GetSum(-5, -5));
      Assert.AreEqual(-127755, s.GetSum(-505, 4));
      Assert.AreEqual(-44055, s.GetSum(-321, 123));
    }
    
    [Test]
    public void TestZero()
    {
      Assert.AreEqual(0, s.GetSum(0, 0));
    }
    
    [Test]
    public void TestSwitchMinMax()
    {
      Assert.AreEqual(-15, s.GetSum(-5, -1));
      Assert.AreEqual(15, s.GetSum(5, 1));
    }
    
    [Test]
    public void TestEqual()
    {
      Assert.AreEqual(-17, s.GetSum(-17, -17));
      Assert.AreEqual(17, s.GetSum(17, 17));
    }
		
    
  }
