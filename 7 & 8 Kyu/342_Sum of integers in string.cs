/*Challenge link:https://www.codewars.com/kata/598f76a44f613e0e0b000026/train/csharp
Question:
Your task in this kata is to implement a function that calculates the sum of the integers inside a string. For example, in the string "The30quick20brown10f0x1203jumps914ov3r1349the102l4zy dog", the sum of the integers is 3635.

Note: only positive integers will be tested.
*/

//***************Solution********************
//extract numbers using regex, select the values, parse to int and sum.
using System;
using System.Linq;
using System.Text.RegularExpressions;

public class Kata
{
  public static int SumOfIntegersInString(string s)
  {
    return Regex.Matches(s,"\\d+").Sum(x => int.Parse(x.Value));
  }
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Text;
  using System.Text.RegularExpressions;

  [TestFixture]
  public class SolutionTest
  {
  
    private static object[] sampleTests = new object[]
    {
      new object[] {"12.4", 16},
      new object[] {"h3ll0w0rld", 3},
      new object[] {"2 + 3 = ", 5},
      new object[] {"Our company made approximately 1 million in gross revenue last quarter.", 1},
      new object[] {"The Great Depression lasted from 1929 to 1939.", 3868},
      new object[] {"Dogs are our best friends.", 0},
      new object[] {"C4t5 are 4m4z1ng.", 18},
      new object[] {"The30quick20brown10f0x1203jumps914ov3r1349the102l4zy dog", 3635},
    };
  
    [Test, TestCaseSource("sampleTests")]
    public void SampleTest(string test, int expected) => Assert.AreEqual(expected, Kata.SumOfIntegersInString(test));
    
    private static string chars = "  abcdefghijklmnopqrstuvwxyz{}[]:\";',.<>/?";
    
    private static string numbers = "0123456789";
    
    private static Random rnd = new Random();
    
    private static string generateTest()
    {
      StringBuilder sb = new StringBuilder();
      
      // tracks digits added in a row (capped to prevent overflow)
      int digits = 0;
      int maxDigits = 5;
      
      for (int i = 0; i < 100; ++i)
      {
        if (rnd.Next(0, 2) == 0 || digits >= maxDigits)
        {
          digits = 0;
          sb.Append(chars[rnd.Next(0, chars.Length)]);
        }
        else
        {
          ++digits;
          sb.Append(numbers[rnd.Next(0, numbers.Length)]);
        }
      }
      
      return sb.ToString();
    }
    
    private static int solution(string s)
    {
      // Pattern to match a collection of digits, e.g. "12re4" => "12", "4"
      Regex pattern = new Regex(@"\d+");
      
      int sum = 0;
      
      // Iterate over any matches in input string to get the sum
      foreach (Match match in pattern.Matches(s))
      {
        // Add the parsed value to our sum
        sum += Int32.Parse(match.Value);
      }
      
      return sum;
    }
    
    [Test, Description("Random Tests")]
    public void RandomTest()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        string test = generateTest();
        int expected = solution(test);
        int actual = Kata.SumOfIntegersInString(test);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
