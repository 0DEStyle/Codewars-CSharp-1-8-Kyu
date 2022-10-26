/*Challenge link:https://www.codewars.com/kata/5966e33c4e686b508700002d/train/csharp
Question:
Create a function that takes 2 integers in form of a string as an input, and outputs the sum (also as a string):

Example: (Input1, Input2 -->Output)

"4",  "5" --> "9"
"34", "5" --> "39"
"", "" --> "0"
"2", "" --> "2"
"-5", "3" --> "-2"
Notes:

If either input is an empty string, consider it as zero.

Inputs and the expected output will never exceed the signed 32-bit integer limit (2^31 - 1)
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//check for valid input first, then convert s1 and s2 to int and sum, return the sum.
using System;

namespace Solution
{
  public static class Program
  {
    public static string StringsSum(string s1, string s2){
      
      if(s1.Length  == 0 && s2.Length == 0) return "0";
      if(s1.Length  != 0 && s2.Length == 0) return s1;
      if(s1.Length  == 0 && s2.Length != 0) return s2;
        
      return (Int32.Parse(s1) + Int32.Parse(s2)).ToString();
      }
  }
}


//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    [Test(Description = "Tests")]
    public void Tests()
    {
      Assert.AreEqual("9", Program.StringsSum("4","5"));
      Assert.AreEqual("39", Program.StringsSum("34","5"));
      Assert.AreEqual("9", Program.StringsSum("","9"));
      Assert.AreEqual("9", Program.StringsSum("9",""));
      Assert.AreEqual("0", Program.StringsSum("",""));
      Assert.AreEqual("-2", Program.StringsSum("4","-6"));
      Assert.AreEqual("13", Program.StringsSum("23","-10"));
      Assert.AreEqual("44", Program.StringsSum("4","40"));
      Assert.AreEqual("4", Program.StringsSum("4",""));
      Assert.AreEqual("-7", Program.StringsSum("","-7"));
    }
    
    private static string Solve(string s1, string s2)
    {
      int num1 = s1 == "" ? 0 : int.Parse(s1);
      int num2 = s2 == "" ? 0 : int.Parse(s2);
      return (num1 + num2).ToString();
    }
    
    private static void Act(string s1, string s2)
    {
      var actual = Program.StringsSum(s1, s2);
      var expected = Solve(s1, s2);
      Assert.AreEqual(expected, actual);
    }
    
    [Test(Description = "Random Tests")]
    public void RandomTests()
    {
      var rand = new Random();
      for (int i = 0; i < 100; i++)
      {
        string s1, s2;
        switch (rand.Next(4)){
          case 0:
            s1 = rand.Next(-100, 101).ToString();
            s2 = "";
            break;
          case 1:
            s1 = "";
            s2 = rand.Next(-100, 101).ToString();
            break;
          case 2:
            s1 = "";
            s2 = "";
            break;
          default:
            s1 = rand.Next(-100, 101).ToString();
            s2 = rand.Next(-100, 101).ToString();
            break;
        }
        Act(s1, s2);
      }
    }
  }
}
