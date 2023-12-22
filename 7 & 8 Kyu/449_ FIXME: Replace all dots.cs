/*Challenge link:https://www.codewars.com/kata/596c6eb85b0f515834000049/train/csharp
Question:
The code provided is supposed replace all the dots . in the specified String str with dashes -

But it's not working properly.

Task
Fix the bug so we can all go home early.

Notes
String str will never be null.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression
//replace all "." to "-"
using System.Text.RegularExpressions;

public class Kata{
  public static string ReplaceDots(string str) => str.Replace(".", "-");
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Text.RegularExpressions;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void SampleTest()
    {
      Assert.AreEqual("one-two-three", Kata.ReplaceDots("one.two.three"));
    }
    
    [Test]
    public void NoDotsTest()
    {
      Assert.AreEqual("no dots", Kata.ReplaceDots("no dots"));
    }
    
    [Test]
    public void EmptyTest()
    {
      Assert.AreEqual("", Kata.ReplaceDots(""));
    }
    
    [Test]
    public void AllDotsTest()
    {
      Assert.AreEqual("---", Kata.ReplaceDots("..."));
    }
    
    private static Random rnd = new Random();
    
    [Test]
    public void RandomTest()
    {
      for (int i = 0; i < 100; ++i)
      {
        string str = String.Empty;
        for (int j = 0; j < 20; ++j)
        {
          str += rnd.Next(0, 2) == 0 ? "x" : ".";
        }
        string expected = new Regex(@"\.").Replace(str, "-");
        string attempt = Kata.ReplaceDots(str);
        Console.WriteLine("Expected: \"{0}\" Actual: \"{1}\"", expected, attempt);
        Assert.AreEqual(expected, attempt);
      }
    }
  }
}
