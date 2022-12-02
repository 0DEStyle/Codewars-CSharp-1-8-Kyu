/*Challenge link:https://www.codewars.com/kata/57e92e91b63b6cbac20001e5/train/csharp
Question:The purpose of this kata is to work out just how many bottles of duty free whiskey you would have to buy such that the saving over the normal high street price would effectively cover the cost of your holiday.

You will be given the high street price (normPrice), the duty free discount (discount) and the cost of the holiday.

For example, if a bottle cost £10 normally and the discount in duty free was 10%, you would save £1 per bottle. If your holiday cost £500, the answer you should return would be 500.

All inputs will be integers. Please return an integer. Round down.

The question actually means:
#It is asking you to find the DIFFERENCE between normal price and discounted price

#How many times that DIFFERENCE would sum to the equivalent of the holiday price

#Final part you can get away with geting rid of the decimals
*/

//***************Solution********************
//apply algorithm
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Kata{
  public static int DutyFree(double normPrice, double Discount, double hol) =>
    (int)(hol / (normPrice * (Discount / 100 )));
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
  
    [Test, Description("Fixed Tests")]
    public void SampleTest()
    {
      Action[] tests = new Action[]
      {
        () => Assert.AreEqual(166, Kata.DutyFree(12, 50, 1000)),
        () => Assert.AreEqual(294, Kata.DutyFree(17, 10, 500)),
        () => Assert.AreEqual(357, Kata.DutyFree(24, 35, 3000)),
        () => Assert.AreEqual(20, Kata.DutyFree(1400, 35, 10000)),
        () => Assert.AreEqual(38, Kata.DutyFree(700, 26, 7000)),
      };
      tests.OrderBy(x => rnd.Next()).ToList().ForEach(a => a.Invoke());
    }
    
    [Test, Description("Random Tests")]
    public void RandomTest()
    {
      Func<int, int, int, int> Solution = (normPrice, discount, hol) => (int)Math.Floor(hol / (normPrice * (discount / 100d)));
      for (int i = 0; i < 100; ++i)
      {
        int normPrice = rnd.Next(1, 2500 + 1);
        int discount = rnd.Next(0, 95 + 1);
        int hol = rnd.Next(100, 20000 + 1);
        int expected = Solution(normPrice, discount, hol);
        int actual = Kata.DutyFree(normPrice, discount, hol);
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
