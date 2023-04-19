/*Challenge link:https://www.codewars.com/kata/57f75cc397d62fc93d000059/train/csharp
Question:
Given a string, turn each character into its ASCII character code and join them together to create a number - let's call this number total1:

'ABC' --> 'A' = 65, 'B' = 66, 'C' = 67 --> 656667
Then replace any incidence of the number 7 with the number 1, and call this number 'total2':

total1 = 656667
              ^
total2 = 656661
              ^
Then return the difference between the sum of the digits in total1 and total2:

  (6 + 5 + 6 + 6 + 6 + 7)
- (6 + 5 + 6 + 6 + 6 + 1)
-------------------------
                       6
*/

//***************Solution********************
//convert characteer to ASCII, count the number of occurrence of 7, and multiply it by 6 to find the difference.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public class Kata{
  public static int Calc(string s){
    return string.Concat(s.Select(x => (int) x)).Count(x => x == '7') * 6;
  }
}

//****************Sample Test*****************
using System;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class KataTests
{
    [Test]
    public void SampleTest()
    {
        Assert.AreEqual(0, Kata.Calc(""));
        Assert.AreEqual(6, Kata.Calc("abc"));
        Assert.AreEqual(6, Kata.Calc("ABC"));
        Assert.AreEqual(6, Kata.Calc("abcdef"));
        Assert.AreEqual(6, Kata.Calc("ifkhchlhfd"));
        Assert.AreEqual(6, Kata.Calc("jfmgklf8hglbe"));
        Assert.AreEqual(12, Kata.Calc("jaam"));
        Assert.AreEqual(18, Kata.Calc("AFHJD"));
        Assert.AreEqual(18, Kata.Calc("CodeWars"));
        Assert.AreEqual(24, Kata.Calc("FVJFVDF"));
        Assert.AreEqual(24, Kata.Calc("AOUCUAOF"));
        Assert.AreEqual(30, Kata.Calc("aaaaaddddr"));
        Assert.AreEqual(36, Kata.Calc("XLdNDcAbUkMnkV"));
        Assert.AreEqual(42, Kata.Calc("cSuLifxDQkOiypJsxOJSE"));
        Assert.AreEqual(48, Kata.Calc("ZHAUnSGoIbgPSezhjePIbHFrHUOv"));
        Assert.AreEqual(54, Kata.Calc("VFhSMbZETZVHxYiiYsBMrWuecDN")); 
        Assert.AreEqual(60, Kata.Calc("sphPoGbicTCLbiuUcwFMEGaFmy"));
        Assert.AreEqual(72, Kata.Calc("oXoQKiCflHIHFyGizCYCuaHhX"));
        Assert.AreEqual(84, Kata.Calc("sUuPmNnnJOOCAGOuyzmcHQGJhXHYgZLY"));
    }
  
    private static readonly Random Rand = new();

    [Test]
    public void RandomTest()
    {
        for (var i = 0; i < 100; i++)
        {
            var s = RandomStr();

            var total1 = string.Concat(s.Select(x => (int) x));
            var total2 = total1.Replace("7", "1");
            var expected = total1.Sum(x => int.Parse(x.ToString())) - total2.Sum(x => int.Parse(x.ToString()));

            var message = FailureMessage(s, expected);
            var actual = Kata.Calc(s);

            Assert.AreEqual(expected, actual, message);
        }
    }

    private static string RandomStr()
    {
        const string chars = "abcdefghijklmnopqrsyuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        return string.Concat(Enumerable.Repeat(chars, Rand.Next(20, chars.Length))
            .Select(s => s[Rand.Next(s.Length)]).Take(Rand.Next(0, 16)));
    }

    private static string FailureMessage(string s, int value)
    {
        return $"Should return {value} with s=\"{s}\"";
    }
}
