/*Challenge link:https://www.codewars.com/kata/5434283682b0fdb0420000e6/train/csharp
Question:
Complete the function which takes a non-zero integer as its argument.

If the integer is divisible by 3, return the string "Java".

If the integer is divisible by 3 and divisible by 4, return the string "Coffee"

If one of the condition above is true and the integer is even, add "Script" to the end of the string.

If none of the condition is true, return the string "mocha_missing!"

Examples
1   -->  "mocha_missing!"
3   -->  "Java"
6   -->  "JavaScript"
12  -->  "CoffeeScript"
*/

//***************Solution********************

//starting from the statement which everything is true, divisible by both 3 and 4, so 3*4 = 12 return "CoffeeScript"
//then n mod 6 for "JavaScript", then n mod 3 for "Java", if nothing is true, return "mocha_missing!"
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Kata{
  public static string CaffeineBuzz(int n) => 
           n % 12 == 0 ? "CoffeeScript" : 
           n % 6 == 0 ? "JavaScript" : 
           n % 3 == 0 ? "Java" : "mocha_missing!";
}

//solution 2
public class Kata
{
  public static string CaffeineBuzz(int n) => n % 3 == 0 ? (n % 4 == 0 ? "Coffee" : "Java") + (n % 2 == 0 ? "Script" : "") : "mocha_missing!";
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;

  [TestFixture]
  public class Sample_Test
  {
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        yield return new TestCaseData(1).Returns("mocha_missing!");
        yield return new TestCaseData(3).Returns("Java");
        yield return new TestCaseData(6).Returns("JavaScript");
        yield return new TestCaseData(12).Returns("CoffeeScript");
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public string Test(int n) => Kata.CaffeineBuzz(n);
  }
  
  [TestFixture]
  public class Random_Test
  {
    private static Random rnd = new Random();
    
    private static string solution(int n)
    {
      if (n % 12 == 0) { return "CoffeeScript"; }
      if (n % 6 == 0)  { return "JavaScript"; }
      if (n % 3 == 0)  { return "Java"; }
      return "mocha_missing!";
    }
    
    [Test, Description("Random Tests")]
    public void RandomTest()
    {
      const int Tests = 100;
      
      for (int i = Tests; i != 0; --i)
      {
        int test = rnd.Next();
        
        string expected = solution(test);
        string actual = Kata.CaffeineBuzz(test);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
