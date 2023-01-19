/*Challenge link:https://www.codewars.com/kata/57faf12b21c84b5ba30001b0/train/csharp
Question:
Description:
Remove all exclamation marks from sentence but ensure a exclamation mark at the end of string. For a beginner kata, you can assume that the input data is always a non empty string, no need to verify it.

Examples
remove("Hi!") === "Hi!"
remove("Hi!!!") === "Hi!"
remove("!Hi") === "Hi!"
remove("!Hi!") === "Hi!"
remove("Hi! Hi!") === "Hi Hi!"
remove("Hi") === "Hi!"

*/

//***************Solution********************
//replace all ! with nothing, then add ! at the end
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

public class Kata{
  public static string Remove(string s)=> s.Replace("!", "") + "!";
}
//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Text.RegularExpressions;

  // TODO: Replace examples and use TDD development by writing your own tests

  [TestFixture]
  public class Test
  {
    [Test]
    public void SampleTest()
    {
      Assert.AreEqual("Hi!", Kata.Remove("Hi!"));
      Assert.AreEqual("Hi!", Kata.Remove("Hi!!!"));
      Assert.AreEqual("Hi!", Kata.Remove("!Hi"));
      Assert.AreEqual("Hi!", Kata.Remove("!Hi!"));
      Assert.AreEqual("Hi Hi!", Kata.Remove("Hi! Hi!"));
      Assert.AreEqual("Hi!", Kata.Remove("Hi"));
    }
    
    private static Random rnd = new Random();
    
    [Test]
    public void RandomTest()
    {
      string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_ @#$%^&*_(),.?|{}[]-=+\\/0123456789";
      
      for (int i = 0; i < 100; ++i)
      {
        string test = String.Empty;
        for (int j = 0; j < 40; ++j)
        {
          test += rnd.Next(0, 6) == 0 ? '!' : chars[rnd.Next(0, chars.Length)];
        }
        string expected = new Regex("!").Replace(test, "") + "!";
        string actual = Kata.Remove(test);
        Console.WriteLine("Testing for: \"{0}\"", test);
        Console.WriteLine("Expected:    \"{0}\"", expected);
        Console.WriteLine("Actual:      \"{0}\"\n", actual);
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
