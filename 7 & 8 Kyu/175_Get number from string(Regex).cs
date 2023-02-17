/*Challenge link:https://www.codewars.com/kata/57a37f3cbb99449513000cd8/train/csharp
Question:
Write a function which removes from string all non-digit characters and parse the remaining to number. E.g: "hell5o wor6ld" -> 56

Function:

GetNumberFromString(string s)
*/

//***************Solution********************
//remove all letters and conver string to int, return the result
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Text.RegularExpressions;

namespace Solution{
  public static class Program{
    public static int getNumberFromString(string s)=> Convert.ToInt32(Regex.Replace(s, "[^0-9.]", ""));
  }
}

//solution 2
using System;
using System.Text.RegularExpressions;
namespace Solution
{
  public static class Program
  {
    public static int getNumberFromString(string s)
    {
      return Int32.Parse(Regex.Replace(s, @"[^\d]", ""));
    }
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
      Assert.AreEqual(1, Program.getNumberFromString("1"));
      Assert.AreEqual(123, Program.getNumberFromString("123"));
      Assert.AreEqual(7, Program.getNumberFromString("this is number: 7"));
      Assert.AreEqual(100000000, Program.getNumberFromString("$100 000 000"));
      Assert.AreEqual(56, Program.getNumberFromString("hell5o wor6ld"));
      Assert.AreEqual(12345, Program.getNumberFromString("one1 two2 three3 four4 five5"));
    }
  }
}
