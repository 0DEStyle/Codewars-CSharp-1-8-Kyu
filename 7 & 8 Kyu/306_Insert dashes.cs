/*Challenge link:https://www.codewars.com/kata/55960bbb182094bc4800007b/train/csharp
Question:
Write a function insert_dash(num) / insertDash(num) / InsertDash(int num) that will insert dashes ('-') between each two odd digits in num. For example: if num is 454793 the output should be 4547-9-3. Don't count zero as an odd digit.

Note that the number will always be non-negative (>= 0).


*/

//***************Solution********************
//replace the string num(convert to string using string interpolation) 
//if character is equal to pattern 1,3,5,7,9, using the regex Lookahead operator ?= to check the next character
//then return the string with $1 the number itself with the character '-'
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Text.RegularExpressions;

public class Kata{
  public static string InsertDash(int num) =>
    Regex.Replace($"{num}", "([1,3,5,7,9])(?=[1,3,5,7,9])", "$1-");
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Text.RegularExpressions;

  [TestFixture]
  public class SolutionTest
  {
    private static Random rnd = new Random();
    
    private static string solution(int num) =>
      new Regex("([13579])(?=[13579])", RegexOptions.IgnoreCase).Replace(num.ToString(), "$1-");
    
    [Test]
    public void SampleTest()
    {
      Assert.AreEqual("4547-9-3", Kata.InsertDash(454793));
      Assert.AreEqual("123456", Kata.InsertDash(123456));
      Assert.AreEqual("1003-567", Kata.InsertDash(1003567));
    }
    
    [Test]
    public void RandomTest()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        int num = rnd.Next();
        
        string expected = solution(num);
        string actual = Kata.InsertDash(num);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
