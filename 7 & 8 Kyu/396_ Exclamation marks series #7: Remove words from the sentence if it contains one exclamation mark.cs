/*Challenge link:https://www.codewars.com/kata/57fafb6d2b5314c839000195/train/csharp
Question:
Description:
Remove words from the sentence if they contain exactly one exclamation mark. Words are separated by a single space, without leading/trailing spaces.

Examples
remove("Hi!") === ""
remove("Hi! Hi!") === ""
remove("Hi! Hi! Hi!") === ""
remove("Hi Hi! Hi!") === "Hi"
remove("Hi! !Hi Hi!") === ""
remove("Hi! Hi!! Hi!") === "Hi!!"
remove("Hi! !Hi! Hi!") === "!Hi!"
*/

//***************Solution********************

//split s by space
//x is the current element(word), and ch is character,
//count if character is '!', then get all element where count is not equal to 1, convert to array
//join the elements together with " ", then return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public static class Kata{
  public static string Remove(string s) => string.Join(" ",s.Split().Where(x => x.Count(ch => ch == '!') != 1).ToArray());
}

//solution 2
using System.Linq;

public static class Kata
{
  public static string Remove(string s)
  {
    return string.Join(" ", s.Split().Where(x => x.Split("!").Length != 2));
  }
}

//solution 3
using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class Kata
{
  public static string Remove(string s)
  {
    return String.Join(' ', s.Split(" ").Where(x => !Regex.Match(x, @"^\w*[!]{1}\w*\z").Success).ToArray());
  }
}
//****************Sample Test*****************
using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class KataTests
{
    [Test]
    public void SampleTest()
    {
        Assert.AreEqual("", Kata.Remove("Hi!"));
        Assert.AreEqual("", Kata.Remove("!Hi"));
        Assert.AreEqual("", Kata.Remove("Hi! Hi! Hi!"));
        Assert.AreEqual("", Kata.Remove("Hi! !Hi Hi!"));
        Assert.AreEqual("", Kata.Remove("Hi! Hi!"));
        Assert.AreEqual("!Hi!", Kata.Remove("!Hi!"));
        Assert.AreEqual("Hi!!!", Kata.Remove("Hi!!!"));
        Assert.AreEqual("Hi", Kata.Remove("Hi Hi! Hi!"));
        Assert.AreEqual("Hi hi hI", Kata.Remove("Hi hi hI"));
        Assert.AreEqual("Hi!!", Kata.Remove("Hi! Hi!! Hi!"));
        Assert.AreEqual("!Hi!", Kata.Remove("Hi! !Hi! Hi!"));
        Assert.AreEqual("!Hi! !Hi!", Kata.Remove("!Hi! ! !Hi!"));
        Assert.AreEqual("!!!Hi !!hi!!!", Kata.Remove("!!!Hi !!hi!!! !hi"));
    }

    private static string Solution(string s)
    {
        return string.Join(" ", s.Split().Where(x => x.Split("!").Length != 2));
    }

    private static readonly Random Rand = new Random();

    private static string RandomStr()
    {
        const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        List<string> list = new List<string>();
        var n = Rand.Next(1, 10);
        for (var i = 0; i < n; i++)
        {
            var str = string.Concat(Enumerable.Repeat(chars, Rand.Next(1, chars.Length))
                .Select(s => s[Rand.Next(s.Length)])
                .Take(Rand.Next(3, 6)));

            var v = Rand.Next(0, 5);
            str = v switch
            {
                0 => new string('!', Rand.Next(0, 4)) + str + new string('!', Rand.Next(0, 4)),
                1 => str + new string('!', Rand.Next(0, 3)),
                2 => new string('!', Rand.Next(0, 3)) + str,
                3 => (Rand.Next(0, 4) == 0 ? "!" : "") + str + (Rand.Next(0, 4) == 0 ? "!" : ""),
                _ => str
            };

            list.Add(str);
        }

        return string.Join(" ", list);
    }

    [Test]
    public void RandomTest()
    {
        for (var i = 0; i < 300; i++)
        {
            var str = RandomStr();
            var expected = Solution(str);
            var message = FailureMessage(str, expected);
            var actual = Kata.Remove(str);

            Assert.AreEqual(expected, actual, message);
        }
    }

    private static string FailureMessage(string str, string value)
    {
        return $"Should return \"{value}\" with \"{str}\"";
    }
}
