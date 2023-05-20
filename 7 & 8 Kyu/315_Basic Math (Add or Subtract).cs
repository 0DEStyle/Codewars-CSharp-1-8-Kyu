/*Challenge link:https://www.codewars.com/kata/5809b62808ad92e31b000031/train/csharp
Question:
In this kata, you will do addition and subtraction on a given string. The return value must be also a string.

Note: the input will not be empty.

Examples
"1plus2plus3plus4"  --> "10"
"1plus2plus3minus4" -->  "2"

*/

//***************Solution********************
//replace plus with " " and minue with " -"
//split the string by empty space
//convert string to int and find the sum
//convert back to string and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public static class Kata{
  public static string Calculate(string str) =>
    str.Replace("plus", " ").Replace("minus", " -").Split().Sum(int.Parse).ToString();
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    private Random random = new Random();
    
    [Test(Description = "Basic (fixed) tests")]
    public void BasicTests()
    {
      Test("10", "1plus2plus3plus4");
      Test("-8", "1minus2minus3minus4");
      Test("2", "1plus2plus3minus4");
      Test("-2", "1minus2plus3minus4");
      Test("-1", "1plus2minus3plus4minus5");
    }
    
    [Test(Description = "Random tests")]
    public void RandomTests()
    {
      for (int i = 0; i < 15; i++)
      {
        string input = GetNum() + GetOperator() + GetNum() + GetOperator() + GetNum();
        Test(Solution(input), input);
      }
      for (int i = 0; i < 15; i++)
      {
        string input = GetNum() + GetOperator() + GetNum() + GetOperator() + GetNum() + GetOperator() + GetNum();
        Test(Solution(input), input);
      }
      for (int i = 0; i < 15; i++)
      {
        string input = GetNum() + GetOperator() + GetNum() + GetOperator() + GetNum() + GetOperator() + GetNum() + GetOperator() + GetNum();
        Test(Solution(input), input);
      }
    }
    
    private string GetNum() => random.Next(1001).ToString();
    
    private string GetOperator() => random.Next(2) == 0 ? "plus" : "minus";
    
    private void Test(string solution, string input)
    {
      Assert.AreEqual(solution, Kata.Calculate(input), $"Incorrect answer for input \"{input}\"");
    }
    
    private string Solution(string str)
    {
      string[] split = str.Replace("plus", " + ").Replace("minus", " - ").Split(' ');
      int result = int.Parse(split[0]);
      for (int i = 1; i < split.Length; i += 2)
      {
        int num = int.Parse(split[i + 1]);
        result += split[i] == "+" ? num : -num;
      }
      return result.ToString();
    }
  }
}
