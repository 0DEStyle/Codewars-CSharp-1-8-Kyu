/*Challenge link:https://www.codewars.com/kata/5274e122fc75c0943d000148/train/csharp
Question:
Finish the solution so that it takes an input n (integer) and returns a string that is the decimal representation of the number grouped by commas after every 3 digits.

Assume: 0 <= n < 2147483647

Examples
       1  ->           "1"
      10  ->          "10"
     100  ->         "100"
    1000  ->       "1,000"
   10000  ->      "10,000"
  100000  ->     "100,000"
 1000000  ->   "1,000,000"
35235235  ->  "35,235,235"
*/

//***************Solution********************


//insert n using n0 format with string interpolation
//ref: https://stackoverflow.com/questions/16209509/what-is-tostringn0-format
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public static class Kata{
  public static string GroupByCommas(int n) => $"{n:n0}";
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void SampleTest()
    {
      Assert.That(Kata.GroupByCommas(1), Is.EqualTo("1"));
      Assert.That(Kata.GroupByCommas(12), Is.EqualTo("12"));
      Assert.That(Kata.GroupByCommas(123), Is.EqualTo("123"));
      Assert.That(Kata.GroupByCommas(1234), Is.EqualTo("1,234"));
      Assert.That(Kata.GroupByCommas(12345), Is.EqualTo("12,345"));
      Assert.That(Kata.GroupByCommas(123456), Is.EqualTo("123,456"));
      Assert.That(Kata.GroupByCommas(1234567), Is.EqualTo("1,234,567"));
      Assert.That(Kata.GroupByCommas(12345678), Is.EqualTo("12,345,678"));
      Assert.That(Kata.GroupByCommas(123456789), Is.EqualTo("123,456,789"));
      Assert.That(Kata.GroupByCommas(1234567890), Is.EqualTo("1,234,567,890"));
    }
    
    [Test]
    public void RandomTest()
    {
      Random rnd = new Random();
      
      for (int i = 0; i < 100; ++i)
      {
        int n = rnd.Next();
        Assert.That(Kata.GroupByCommas(n), Is.EqualTo(n.ToString("#,#")));
      }
    }
  }
}
