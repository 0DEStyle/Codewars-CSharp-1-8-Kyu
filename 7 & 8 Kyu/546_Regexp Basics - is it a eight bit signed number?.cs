/*Challenge link:https://www.codewars.com/kata/567ed73340895395c100002e/train/csharp
Question:
Implement:

.SignedEightBitNumber()
which should return true if given object is a number representable by 8 bit signed integer (-128 to -1 or 0 to 127), false otherwise.

It should only accept numbers in canonical representation, so no leading +, extra 0s, spaces etc.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//pattern capture group 0 or -128 or 
//- sign 0 or one time with 
//digit 12 + (0 to 7) or
//digit 1 + (0 to 1) + (0 to 9) or
//digit (1 to 9) + (0 to 9) matche between 0 or 1 time
//\z at the end of line

using System.Text.RegularExpressions;

public static class Kata{
    public static bool SignedEightBitNumber(this string s) => 
      Regex.IsMatch(s, @"^(0|(-128)|(-?((12[0-7])|(1[0-1][0-9])|([1-9][0-9]{0,1}))))\z");
}

//solution 2
using System.Text.RegularExpressions;

public static class Kata
{
  public static bool SignedEightBitNumber(this string s)
  {
    return Regex.IsMatch(s, @"^(-?([1-9][0-9]?|1[01][0-9]|12[0-7])|-128|0)(?!\n)$");
  }
}

//****************Sample Test*****************
using System;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;

[TestFixture]
public class KataTestf
{
    [Test]
    public void BasicTests()
    {
        Assert.IsFalse("".SignedEightBitNumber());
        Assert.IsTrue("0".SignedEightBitNumber());
        Assert.IsFalse("00".SignedEightBitNumber());
        Assert.IsFalse("-0".SignedEightBitNumber());
        Assert.IsTrue("55".SignedEightBitNumber());
        Assert.IsTrue("-23".SignedEightBitNumber());
        Assert.IsFalse("042".SignedEightBitNumber());
        Assert.IsTrue("127".SignedEightBitNumber());
        Assert.IsFalse("128".SignedEightBitNumber());
        Assert.IsFalse("999".SignedEightBitNumber());
        Assert.IsTrue("-128".SignedEightBitNumber());
        Assert.IsFalse("-129".SignedEightBitNumber());
        Assert.IsFalse("-999".SignedEightBitNumber());
        Assert.IsFalse("1\n".SignedEightBitNumber());
        Assert.IsFalse("1 ".SignedEightBitNumber());
        Assert.IsFalse(" 1".SignedEightBitNumber());
        Assert.IsFalse("1\n2".SignedEightBitNumber());
        Assert.IsFalse("+1".SignedEightBitNumber());
        Assert.IsFalse("--1".SignedEightBitNumber());
        Assert.IsFalse("11٢".SignedEightBitNumber());
        Assert.IsFalse("1٢".SignedEightBitNumber());
        Assert.IsFalse("٢".SignedEightBitNumber());    }

    [Test]
    public void ExtraTests()
    {
        for (int i = -210; i < 210; i++)
        {
            var expected = i >= -128 && i <= 127;
            Assert.AreEqual(expected, $"{i}".SignedEightBitNumber());
        }

        for (int i = 0; i < 200; i++)
        {
            Assert.AreEqual(false, $"0{i}".SignedEightBitNumber());
            Assert.AreEqual(false, $"-0{i}".SignedEightBitNumber());
        }
    }
}
