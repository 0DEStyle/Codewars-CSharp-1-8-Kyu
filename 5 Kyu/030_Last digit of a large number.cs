/*Challenge link:https://www.codewars.com/kata/5511b2f550906349a70004e1/train/csharp
Question:
Define a function that takes in two non-negative integers aaa and bbb and returns the last decimal digit of aba^ba 
b
 . Note that aaa and bbb may be very large!

For example, the last decimal digit of 979^79 
7
  is 999, since 97=47829699^7 = 47829699 
7
 =4782969. The last decimal digit of (2200)2300({2^{200}})^{2^{300}}(2 
200
 ) 
2 
300
 
 , which has over 109210^{92}10 
92
  decimal digits, is 666. Also, please take 000^00 
0
  to be 111.

You may assume that the input will always be valid.

Examples
GetLastDigit(4, 1)            // returns 4
GetLastDigit(4, 2)            // returns 6
GetLastDigit(9, 7)            // returns 9    
GetLastDigit(10, 10000000000) // returns 0

*/

//***************Solution********************

namespace Solution{
  using System.Numerics;
  using System;
  
  class LastDigit{
    public static int GetLastDigit(BigInteger n1, BigInteger n2){
      Console.WriteLine($"n1:{n1},n2:{n2}");
      //mod 10 to get last digit
      return (int)BigInteger.ModPow(n1, n2, 10);
    }
  }
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;
  using System.Numerics;

  [TestFixture]
  public class SolutionTest
  {
    private static Random rd = new Random();
    
    [Test]
    public void ExampleTests()
    {
      Assert.AreEqual(4, LastDigit.GetLastDigit(4, 1));
      Assert.AreEqual(6, LastDigit.GetLastDigit(4, 2));
      Assert.AreEqual(9, LastDigit.GetLastDigit(9, 7));
      Assert.AreEqual(0, LastDigit.GetLastDigit(10, BigInteger.Pow(10,10)));
      Assert.AreEqual(6, LastDigit.GetLastDigit(BigInteger.Pow(2, 200), BigInteger.Pow(2, 300)));
      Assert.AreEqual(7, LastDigit.GetLastDigit(BigInteger.Parse("3715290469715693021198967285016729344580685479654510946723"), BigInteger.Parse("68819615221552997273737174557165657483427362207517952651")));
    }
                            
    [Test]
    public void XPowZero()
    {
      const string chars = "0123456789";
      foreach (var d in Enumerable.Range(0, 9))
      {
        string str1 = new string(Enumerable.Repeat(chars, rd.Next(1, 50)).Select(s => s[rd.Next(s.Length)]).ToArray());
        var n1 = BigInteger.Parse(str1);
        Assert.AreEqual(1, LastDigit.GetLastDigit(n1, 0));
      }
    }

    [Test]
    public void RandomTests()
    {
      const string chars = "0123456789";
      for(int i = 0; i < 42; i++)
      {
        string str1 = new string(Enumerable.Repeat(chars, rd.Next(1, 50)).Select(s => s[rd.Next(s.Length)]).ToArray());
        var str2 = new string(Enumerable.Repeat(chars, rd.Next(1, 50)).Select(s => s[rd.Next(s.Length)]).ToArray());
        var n1 = BigInteger.Parse(str1);
        var n2 = BigInteger.Parse(str1);
        Assert.AreEqual(GetLastDigit(n1, n2), LastDigit.GetLastDigit(n1, n2));
      }
    }

    public static int GetLastDigit(BigInteger n1, BigInteger n2)
    {
      return (int)BigInteger.ModPow(n1, n2, 10);
    }
  }
}
