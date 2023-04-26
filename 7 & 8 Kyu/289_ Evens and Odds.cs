/*Challenge link:https://www.codewars.com/kata/583ade15666df5a64e000058/train/csharp
Question:
This kata is about converting numbers to their binary or hexadecimal representation:

If a number is even, convert it to binary.
If a number is odd, convert it to hex.
Numbers will be positive. The hexadecimal string should be lowercased.
*/

//***************Solution********************
//check if number is an even number,
//if so convert to binary, else hexadecimal but with lower case (x is for lower and X is for upper)
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System;
public static class Kata{
  public static string EvensAndOdds(int n) => n % 2 == 0 ?  Convert.ToString(n, 2) : n.ToString("x");
}

//better solution
using System;

public static class Kata
{
  public static string EvensAndOdds(int num)
  {
    return Convert.ToString(num, num % 2 == 0 ? 2 : 16);
  }
}
//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  
  public static class Solution
  {
    public static string EvensAndOdds(int num) =>
      num % 2 == 0 ? Convert.ToString(num, 2) : Convert.ToString(num, 16);
  }

  [TestFixture]
  public class SolutionTest
  {
    [Test, Description("Sample Tests")]
    public void SampleTest()
    {
      Assert.AreEqual("10", Kata.EvensAndOdds(2));
      Assert.AreEqual("d", Kata.EvensAndOdds(13));
      Assert.AreEqual("2f", Kata.EvensAndOdds(47));
      Assert.AreEqual("0", Kata.EvensAndOdds(0));
      Assert.AreEqual("11001000000000", Kata.EvensAndOdds(12800));
    }
    
    private static Random rnd = new Random();
    
    [Test, Description("Random Tests")]
    public void RandomTest()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        int num = rnd.Next();
        
        string expected = Solution.EvensAndOdds(num);
        string actual = Kata.EvensAndOdds(num);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
