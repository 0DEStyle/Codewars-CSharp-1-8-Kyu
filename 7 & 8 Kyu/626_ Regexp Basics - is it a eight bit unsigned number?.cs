/*Challenge link:https://www.codewars.com/kata/567e8f7b4096f2b4b1000005/train/csharp
Question:
Implement String#eight_bit_number?, which should return true if given object is a number representable by 8 bit unsigned integer (0-255), false otherwise.

It should only accept numbers in canonical representation, so no leading +, extra 0s, spaces etc.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
/*
➖➖🟨🟨
➖➖🟨🔳🟧
🟨🟨🟨🟨
🟨🟨🟨🟨
➖🟧🟧
*/
//pattern
//^ start, \z before the end of string
//capture group
//0-9, [0-9] character between 0 to 9, [0-9],\d any digit
//10-100, or 1, any digit, any digit
//200-249, or 2, [0-4], any digit
//250-255, or 25, [0-5]
static class SimpleExtensions{
  public static bool EightBitNumber(this string s) => 
    System.Text.RegularExpressions.Regex.IsMatch(s, @"^([0-9]|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\z");
}

//without regex
static class SimpleExtensions 
{
  public static bool EightBitNumber(this string s) 
  {
    return byte.TryParse(s, out var n) && s.Length == $"{n}".Length;
  }
}

//solution 3
using System;
using System.Linq;

static class SimpleExtensions {
  public static bool EightBitNumber(this string str) {
  
     return Enumerable.Range(0, 256).Any(c => c.ToString().Equals(str));
  }
}
//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;
  
  [TestFixture]
  public class Tests
  {
    // Fisher-Yates shuffling algorithm
    private Random _random = new Random();
    private void Shuffle<T>(T[] array)
    {
        int n = array.Length;
        for (int i = 0; i < (n - 1); i++)
        {
            int r = i + _random.Next(n - i);
            T t = array[r];
            array[r] = array[i];
            array[i] = t;
        }
    }
  
    [Test]
    public void ExampleTests() {
      Assert.AreEqual(false, "".EightBitNumber());
      Assert.AreEqual(true,  "0".EightBitNumber());
      Assert.AreEqual(false, "00".EightBitNumber());
      Assert.AreEqual(true,  "55".EightBitNumber());
      Assert.AreEqual(false, "042".EightBitNumber());
      Assert.AreEqual(true,  "123".EightBitNumber());
      Assert.AreEqual(true,  "255".EightBitNumber());
      Assert.AreEqual(false, "256".EightBitNumber());
      Assert.AreEqual(false, "999".EightBitNumber());
      Assert.AreEqual(false, "-1".EightBitNumber());
    }
    
    [Test]
    public void WhiteSpaceTests() {
      Assert.AreEqual(false, "1\n".EightBitNumber());
      Assert.AreEqual(false, "1 ".EightBitNumber());
      Assert.AreEqual(false, " 1".EightBitNumber());
      Assert.AreEqual(false, "1\n2".EightBitNumber());
    }
    
    [Test]
    public void RandomTests() {
      var tests = Enumerable.Range(0, 256).ToArray();
      Shuffle(tests);
      foreach (var i in tests) {
        Assert.AreEqual(false, ("0" + i).EightBitNumber());
        Assert.AreEqual(false, ("-0" + i).EightBitNumber());
        Assert.AreEqual(true, ("" + i).EightBitNumber());
      }  
    }
  }
}
