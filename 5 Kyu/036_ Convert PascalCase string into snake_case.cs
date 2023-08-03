/*Challenge link:https://www.codewars.com/kata/529b418d533b76924600085d/train/csharp
Question:
Complete the function/method so that it takes a PascalCase string and returns the string in snake_case notation. Lowercase characters can be numbers. If the method gets a number as input, it should return a string.

Examples
"TestController"  -->  "test_controller"
"MoviesAndBooks"  -->  "movies_and_books"
"App7Test"        -->  "app7_test"
1                 -->  "1"
*/

//***************Solution********************

//simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Text.RegularExpressions;

public static class Kata {
  //function if input is an int
  public static string ToUnderscore(int str) => str.ToString();
  
  // "\B" non-word-boundary, where word do not start or ened with character A-Z (because word start with a capital letter)
  //replace it with "_" starting after the first word, then convert the result to lowercase.
  public static string ToUnderscore(string str) => Regex.Replace(str, "(\\B[A-Z]\\B)", "_$1").ToLower();
}

//****************Sample Test*****************
namespace Solution
{
  using NUnit.Framework;
  using System;
  using System.Linq;
  using System.Text;
  using System.Text.RegularExpressions;
  
  public static class Solution 
  {
    public static string ToUnderscore(int str) => str.ToString();
    public static string ToUnderscore(string str) => String.Join("_", Regex.Split(str, "(?=[A-Z])").Skip(1)).ToLower();
  }
  
  [TestFixture]
  public class Tests
  {
    [Test]
    public void SampleTests()
    {
      Assert.AreEqual("test_controller", Kata.ToUnderscore("TestController"));
      Assert.AreEqual("this_is_beautiful_day", Kata.ToUnderscore("ThisIsBeautifulDay"));
      Assert.AreEqual("am7_days", Kata.ToUnderscore("Am7Days"));
      Assert.AreEqual("my3_code_is4_times_better", Kata.ToUnderscore("My3CodeIs4TimesBetter"));
      Assert.AreEqual("arbitrarily_sending_different_types_to_functions_makes_katas_cool", Kata.ToUnderscore("ArbitrarilySendingDifferentTypesToFunctionsMakesKatasCool"));
      Assert.AreEqual("1", Kata.ToUnderscore(1), "Numbers should be turned to strings!");
    }
    
    [Test]
    public void RandomTests()
    {
      Random rnd = new Random();
      
      for (int i = 0; i < 100; ++i)
      {
        if (rnd.Next(0, 420) < 69)
        {
          int num = rnd.Next();
          Assert.That(Kata.ToUnderscore(num), Is.EqualTo(num.ToString()));
        }
        else
        {
          string str = String.Concat(new string[rnd.Next(5, 20)].Select(_ => (char)rnd.Next(65, 91) + String.Concat(new char[rnd.Next(5, 20)].Select(__ => (char)rnd.Next(97, 123)))));
          Assert.That(Kata.ToUnderscore(str), Is.EqualTo(Solution.ToUnderscore(str)));
        }
      }
    }
  }
}
