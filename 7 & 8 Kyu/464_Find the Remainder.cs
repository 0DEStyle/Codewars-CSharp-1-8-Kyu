/*Challenge link:https://www.codewars.com/kata/524f5125ad9c12894e00003f/train/csharp
Question:
Task:
Write a function that accepts two integers and returns the remainder of dividing the larger value by the smaller value.

Divison by zero should throw a DivideByZeroException.

Examples:
n = 17
m = 5
result = 2 (remainder of `17 / 5`)

n = 13
m = 72
result = 7 (remainder of `72 / 13`)

n = 0
m = -1
result = 0 (remainder of `0 / -1`)

n = 0
m = 1
result - division by zero (refer to the specifications on how to handle this in your language)
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression

//if a is less than b, a mod b, else b mod a

public class Kata{
  public static int Remainder(int a, int b) => a > b ? a % b : b % a ;
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    [Test, Description("Your solution should handle arguments and math as defined in specifications")]
    public void FixedTest()
    {
      Assert.AreEqual(2, Kata.Remainder(17, 5), "Returned value should be the value left over after dividing as much as possible.");
      Assert.AreEqual(Kata.Remainder(72, 13), Kata.Remainder(13, 72), "The order the arguments are passed should not matter.");
      Assert.Throws<DivideByZeroException>(() => Kata.Remainder(0, 1));
      Assert.Throws<DivideByZeroException>(() => Kata.Remainder(0, 0));
      Assert.Throws<DivideByZeroException>(() => Kata.Remainder(1, 0));
      Assert.AreEqual(0, Kata.Remainder(0, -1), "Finding the remainder of 0 divided by -1 should not raise an exception.");
      Assert.AreEqual(0, Kata.Remainder(-13, -13), "Should handle negative numbers.");
      Assert.AreEqual(40, Kata.Remainder(-60, 340), "Should handle negative numbers.");
    }
    
    private static Random rnd = new Random();
    
    private static int solution(int a, int b) =>
      a > b ? a % b : b % a;
    
    [Test, Description("Your solution should be able to handle random inputs")]
    public void RandomTest()
    {
      const int Tests = 200;
      
      for (int i = 0; i < Tests; ++i)
      {
        int a = rnd.Next(5, 100);
        int b = rnd.Next(-40, 20);
        
        if (b == 0)
        {
          Assert.Throws<DivideByZeroException>(() => Kata.Remainder(b, a));
        }
        else
        {
          int expected = solution(b, a);
          int actual = Kata.Remainder(b, a);
          
          Assert.AreEqual(expected, actual);
        }
      }
    }
  }
}
