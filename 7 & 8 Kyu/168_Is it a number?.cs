/*Challenge link:https://www.codewars.com/kata/57126304cdbf63c6770012bd/train/csharp
Question:
Given a string s, write a method (function) that will return true if its a valid single integer or floating number or false if its not.

Valid examples, should return true:

isDigit("3")
isDigit("  3  ")
isDigit("-3.23")
should return false:

isDigit("3-4")
isDigit("  3   5")
isDigit("3 5")
isDigit("zero") 
*/

//***************Solution********************
//check if string s is a digit.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class CodeWars{
  public static bool IsDigit(string s)  => float.TryParse(s, out _);
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    [Test, Sequential]
    public void BasicTests(
      [Values("s2324", "3 4", "3-4", "3  4   ", "34.65", "-0", " ", "", "0.0", "ab", "ab  cd")] string input, 
      [Values(false, false, false, false, true, true, false, false, true, false, false, false)] bool expectedResult)
    {
      Assert.IsTrue(CodeWars.IsDigit(input) == expectedResult);
    }
    
    [Test]
    public void RandomTest()
    {
      var random = new Random();

      for (var i = 0; i < 100; i++) {
        var a = $"{random.NextDouble()}";
        var b = $"{random.NextDouble()}";
        var c = $"{random.NextDouble()}";
        var d = "fsda243fs";

        Assert.IsTrue(CodeWars.IsDigit(a));
        Assert.IsTrue(CodeWars.IsDigit(b));
        Assert.IsTrue(CodeWars.IsDigit(c));
        Assert.IsFalse(CodeWars.IsDigit(d));
      }
    }
  }
}
