/*Challenge link:https://www.codewars.com/kata/55606aeebf1f0305f900006f/train/csharp
Question:
Convert integers to binary as simple as that. You would be given an integer as a argument and you have to return its binary form. To get an idea about how to convert a decimal number into a binary number, visit here.

Notes: negative numbers should be handled as two's complement; assume all numbers are integers stored using 4 bytes (or 32 bits) in any language.

Your output should ignore leading 0s.

Examples (input --> output):
3  --> "11"
-3 -->"11111111111111111111111111111101"
Be Ready for Large Numbers. Happy Coding ^_^
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//convert int to binary using toString
public class Converter{
  public static string ToBinary(int n) => System.Convert.ToString(n, 2);
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;  

  [TestFixture]
  public class ConvertTests
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual("10", Converter.ToBinary(2), "Failed for 2");
      Assert.AreEqual("11", Converter.ToBinary(3), "Failed for 3");
      Assert.AreEqual("100", Converter.ToBinary(4), "Failed for 4");
      Assert.AreEqual("101", Converter.ToBinary(5), "Failed for 5");
      Assert.AreEqual("111", Converter.ToBinary(7), "Failed for 7");
      Assert.AreEqual("1010", Converter.ToBinary(10), "Failed for 10");
      Assert.AreEqual("11111111111111111111111111111101", Converter.ToBinary(-3), "Failed for -3");
      Assert.AreEqual("0", Converter.ToBinary(0), "Failed for 0");
      Assert.AreEqual("1111101000", Converter.ToBinary(1000), "Failed for 1000");
      Assert.AreEqual("11111111111111111111111111110001", Converter.ToBinary(-15), "Failed for -15");
      Assert.AreEqual("11111111111111111111110000011000", Converter.ToBinary(-1000), "Failed for -1000");
      Assert.AreEqual("11111111111100001011110111000001", Converter.ToBinary(-999999), "Failed for -999999");
      Assert.AreEqual("11110100001000111111", Converter.ToBinary(999999), "Failed for 999999");
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      for(var i = 0; i < 20; i++)
      {
        var n = rand.Next(int.MinValue, int.MaxValue);
        Assert.AreEqual(Convert.ToString(n, 2), Converter.ToBinary(n), "Failed for " + n);
      }
    }
  }
}
