/*Challenge link:https://www.codewars.com/kata/557cd6882bfa3c8a9f0000c1/train/csharp
Question:
You ask a small girl,"How old are you?" She always says, "x years old", where x is a random number between 0 and 9.

Write a program that returns the girl''s age (0-9) as an integer.

Assume the test input string is always a valid string. For example, the test input may be "1 year old" or "5 years old". The first character in the string is always a number.
*/

//***************Solution********************
//select digit from text, convert to int and return the result
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Text.RegularExpressions;
using System;

public class Kata{
  public static int GetAge(string s) => Convert.ToInt32(Regex.Match(s, @"\d+").Value);
}


//solution 2
//select first character and convert to int, return result
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;

public class Kata{
  public static int GetAge(string inputString) =>(int)char.GetNumericValue(inputString[0]);
}

//solution 3

public class Kata
{
  public static int GetAge(string inputString) =>inputString[0] - '0';
}
//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class Test
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual(1, Kata.GetAge("1 year old"));
      Assert.AreEqual(2, Kata.GetAge("2 years old"));
      Assert.AreEqual(3, Kata.GetAge("3 years old"));
      Assert.AreEqual(4, Kata.GetAge("4 years old"));
      Assert.AreEqual(5, Kata.GetAge("5 years old"));
      Assert.AreEqual(6, Kata.GetAge("6 years old"));
      Assert.AreEqual(7, Kata.GetAge("7 years old"));
      Assert.AreEqual(8, Kata.GetAge("8 years old"));
      Assert.AreEqual(9, Kata.GetAge("9 years old"));
    }
  }
}
