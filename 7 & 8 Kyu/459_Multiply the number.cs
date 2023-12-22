/*Challenge link:https://www.codewars.com/kata/5708f682c69b48047b000e07/train/csharp
Question:
Jack really likes his number five: the trick here is that you have to multiply each number by 5 raised to the number of digits of each numbers, so, for example:

multiply(3)==15 // 3 * 5¹
multiply(10)==250 // 10 * 5²
multiply(200)==25000 // 200 * 5³
multiply(0)==0 // 0 * 5¹
multiply(-3)==-15 // -3 * 5¹
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression
//get absolute value of number, convert to string and find its length
//number * 5 to the power of number's length, then return the result
using static System.Math;

public class Kata{
  public static int Multiply(int number) => (int)(number * Pow(5, Abs(number).ToString().Length));
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class SolutionTest
  {
    private static Random rnd = new Random();
    
    private static int Solution(int number) =>
      number * (int)Math.Pow(5, Math.Abs(number).ToString().Length);
  
    [Test, Description("Basic Tests")]
    public void SampleTest()
    {
      Action[] tests = new Action[]
      {
        () => Assert.AreEqual(250, Kata.Multiply(10)),
        () => Assert.AreEqual(25, Kata.Multiply(5)),
        () => Assert.AreEqual(25000, Kata.Multiply(200)),
        () => Assert.AreEqual(0, Kata.Multiply(0)),
        () => Assert.AreEqual(-10, Kata.Multiply(-2)),
      };
      tests.OrderBy(x => rnd.Next()).ToList().ForEach(a => a.Invoke());
    }
    
    [Test, Description("Random Tests")]
    public void RandomTest()
    {
      for (int i = 0; i < 100; ++i)
      {
        int number = rnd.Next(0, 5000);
        Console.WriteLine($"Testing for {number}");
        int expected = Solution(number);
        int actual = Kata.Multiply(number);
        Assert.AreEqual(expected, actual, "It's not multiplying properly!");
      }
    }
  }
}
