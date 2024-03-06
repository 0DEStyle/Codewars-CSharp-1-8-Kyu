/*Challenge link:https://www.codewars.com/kata/567e8dbb9b6f4da558000030/train/csharp
Question:
Implement String#six_bit_number?, which should return true if given object is a number representable by 6 bit unsigned integer (0-63), false otherwise.

It should only accept numbers in canonical representation, so no leading +, extra 0s, spaces etc.

 
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//0-63
//pattern any digit, 1-5, any digit, 6, 0 to 3
static class SimpleExtensions {
  public static bool SixBitNumber(this string s) => 
    System.Text.RegularExpressions.Regex.IsMatch(s, @"^(\d|[1-5]\d|6[0-3])\z");
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
    static Random _random = new Random();
    static void Shuffle<T>(T[] array)
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
      Assert.AreEqual(false, "".SixBitNumber());
      Assert.AreEqual(true,  "0".SixBitNumber());
      Assert.AreEqual(false, "00".SixBitNumber());
      Assert.AreEqual(true,  "55".SixBitNumber());
      Assert.AreEqual(true,  "63".SixBitNumber());
      Assert.AreEqual(false, "64".SixBitNumber());
      Assert.AreEqual(false, "-0".SixBitNumber());
      Assert.AreEqual(false, "-5".SixBitNumber());
      Assert.AreEqual(false, "05".SixBitNumber());
      Assert.AreEqual(true,  "5".SixBitNumber());
    }
    
    [Test]
    public void WhiteSpaceTests() {
      Assert.AreEqual(false, "1\n".SixBitNumber());
      Assert.AreEqual(false, "1 ".SixBitNumber());
      Assert.AreEqual(false, " 1".SixBitNumber());
      Assert.AreEqual(false, "1\n2".SixBitNumber());
    }
    
    [Test]
    public void RandomTests() {
      var tests = Enumerable.Range(0, 64).ToArray();
      Shuffle(tests);
      foreach (var i in tests) {
        Assert.AreEqual(false, ("0" + i).SixBitNumber());
        Assert.AreEqual(false, ("-0" + i).SixBitNumber());
        Assert.AreEqual(true, ("" + i).SixBitNumber());
      }  
    }
  }
}
