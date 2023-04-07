/*Challenge link:https://www.codewars.com/kata/57a62154cf1fa5b25200031e/train/csharp
Question:
Write function alternateCase which switch every letter in string from upper to lower and from lower to upper. E.g: Hello World -> hELLO wORLD
*/

//***************Solution********************
//if character is upper case, convert to lower, else stay at upper case, concatenate the result
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
namespace Solution{
    using System.Linq;
    public static class Program{
        public static string alternateCase(string s) =>
             string.Concat(s.Select(e => char.IsUpper(e) ? char.ToLower(e) : char.ToUpper(e)));
    }
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
    public void MyTest()
    {
      Assert.AreEqual("ABC", Program.alternateCase("abc"));
      Assert.AreEqual("abc", Program.alternateCase("ABC"));
      Assert.AreEqual("hELLO wORLD", Program.alternateCase("Hello World"));
      Assert.AreEqual("cODEwARS", Program.alternateCase("CodeWars"));
      Assert.AreEqual("I like making katas very much!", Program.alternateCase("i LIKE MAKING KATAS VERY MUCH!"));
    }
  }
}
