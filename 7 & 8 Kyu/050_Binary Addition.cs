/*Challenge link:https://www.codewars.com/kata/551f37452ff852b7bd000139/train/csharp
Question:
Implement a function that adds two numbers together and returns their sum in binary. The conversion can be done before, or after the addition.

The binary number returned should be a string.

Examples:(Input1, Input2 --> Output (explanation)))

1, 1 --> "10" (1 + 1 = 2 in decimal or 10 in binary)
5, 9 --> "1110" (5 + 9 = 14 in decimal or 1110 in binary)
add .cs 
*/

//***************Solution********************

//add a and b, convert to base 2 
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;

public static class Kata
{
  public static string AddBinary(int a, int b) =>
     Convert.ToString(a + b, 2);
}

//****************Sample Test*****************
namespace Solution
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  
  [TestFixture]
  public class RandomAddBinaryTest
  {
    private static Random rnd = new Random();
  
    private static IEnumerable<TestCaseData> randomTestCases
    {
      get
      {
        const int Tests = 100;
        for (int i = 0; i < Tests; ++i)
        {
          int a = rnd.Next(0, 100000);
          int b = rnd.Next(0, 100000);
          
          string expected = Convert.ToString(a + b, 2);
          
          yield return new TestCaseData(a, b).Returns(expected).SetDescription($"Should return \"{expected}\" for {a} + {b}");
        }
      }
    }
    
    [Test, TestCaseSource("randomTestCases")]
    public string Random_Tests(int a, int b) => Kata.AddBinary(a, b);
  }
  
  public class AddBinaryTest
  {
    [Test]
    public void Test_One_Two()
    {
      Assert.AreEqual("11", Kata.AddBinary(1, 2), "Should return \"11\" for 1 + 2");
    }
    
    [Test]
    public void Test_FiftyOne_Twelve()
    {
      Assert.AreEqual("111111", Kata.AddBinary(51, 12), "Should return \"111111\" for 51 + 12");
    }
    
    [Test]
    public void Test_Hundred_Zero()
    {
      Assert.AreEqual("1100100", Kata.AddBinary(100, 0), "Should return \"1100100\" for 100 + 0");
    }
  }
}
