/*Challenge link:https://www.codewars.com/kata/55902c5eaa8069a5b4000083/train/csharp
Question:
The company you work for has just been awarded a contract to build a payment gateway. In order to help move things along, you have volunteered to create a function that will take a float and return the amount formatting in dollars and cents.

39.99 becomes $39.99

The rest of your team will make sure that the argument is sanitized before being passed to your function although you will need to account for adding trailing zeros if they are missing (though you won't have to worry about a dangling period).

Examples:

3 needs to become $3.00

3.1 needs to become $3.10
Good luck! Your team knows they can count on you!
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//string interpolation with 2 decimal places.
public class Kata{
  public static string FormatMoney(double amount) => $"${amount:f2}";
}

//solution 2
public class Kata
{
  public static string FormatMoney(double amount)
  {
    return amount.ToString("$0.00");
  }
}

//solution 3
public class Kata
{
  public static string FormatMoney(double amount)
  {
    return $"${amount:.00}";
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
  
    [Test, Description("Fixed tests")]
    public void SampleTest()
    {
      Action[] tests = new Action[]
      {
        () => Assert.AreEqual("$39.99", Kata.FormatMoney(39.99), "That's not formatted the way we expected."),
        () => Assert.AreEqual("$3.00", Kata.FormatMoney(3), "That's not formatted the way we expected."),
        () => Assert.AreEqual("$3.10", Kata.FormatMoney(3.10), "That's not formatted the way we expected."),
        () => Assert.AreEqual("$314.16", Kata.FormatMoney(314.16), "That's not formatted the way we expected."),
      };
      tests.OrderBy(x => rng.Next()).ToList().ForEach(a => a.Invoke());
    }
    
    [Test, Description("Random Tests")]
    public void RandomTest()
    {
      for (int i = 0; i < 100; ++i)
      {
        double test = rng.NextDouble() * 10000;
        string expected = test.ToString("$###0.00");
        string actual = Kata.FormatMoney(test);
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
