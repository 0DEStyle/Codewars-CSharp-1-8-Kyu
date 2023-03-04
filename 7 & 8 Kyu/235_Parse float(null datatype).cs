/*Challenge link:https://www.codewars.com/kata/57a386117cb1f31890000039/train/csharp
Question:
Write function parseFloat which takes an input and returns a number or Nothing if conversion is not possible.
*/

//***************Solution********************
//convert nullable object s to string, then tryparse and output as result, if possible, return result
//else return nullable double.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Kata{
  public static double? ParseF(object s = null){
    return double.TryParse(s?.ToString(), out var result) ? result : (double?) null;
  }
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class SolutionTest
  {
    private static Random rng = new Random();
  
    [Test]
    public void FixedTest()
    {
      Action[] tests = new Action[]
      {
        () => Assert.AreEqual(1.0d, Kata.ParseF("1")),
        () => Assert.AreEqual(123.0d, Kata.ParseF("123")),
        () => Assert.AreEqual(2.5d, Kata.ParseF("2.5")),
        () => Assert.AreEqual(null, Kata.ParseF("one")),
        () => Assert.AreEqual(0d, Kata.ParseF("0")),
        () => Assert.AreEqual(null, Kata.ParseF(true)),
        () => Assert.AreEqual(null, Kata.ParseF(false)),
        () => Assert.AreEqual(null, Kata.ParseF()),
      };
      tests.OrderBy(x => rng.Next()).ToList().ForEach(a => a.Invoke());
    }
  }
}
