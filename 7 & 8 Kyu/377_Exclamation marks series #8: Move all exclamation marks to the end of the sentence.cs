/*Challenge link:https://www.codewars.com/kata/57fafd0ed80daac48800019f/train/csharp
Question:
Description:
Move all exclamation marks to the end of the sentence

Examples
"Hi!"          ---> "Hi!"
"Hi! Hi!"      ---> "Hi Hi!!"
"Hi! Hi! Hi!"  ---> "Hi Hi Hi!!!"
"Hi! !Hi Hi!"  ---> "Hi Hi Hi!!!"
"Hi! Hi!! Hi!" ---> "Hi Hi Hi!!!!"
*/

//***************Solution********************

//replace "!" in string s with nothing
//count the number of '!' in string s.
//append a new string '!' count number of times.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;
using System.Text.RegularExpressions;
  
public static class Kata{
    public static string Remove(string s) => Regex.Replace(s, @"!", "") + new String('!',  s.Count(x=>x=='!'));
}

//solution 2
using System.Linq;

public static class Kata
{
    public static string Remove(string s) => string.Concat(s.OrderBy(c => c == '!'));
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
        Assert.AreEqual("Hi!", Kata.Remove("Hi!"));
        Assert.AreEqual("Hi Hi!!", Kata.Remove("Hi! Hi!"));
        Assert.AreEqual("Hi Hi Hi!!!", Kata.Remove("Hi! Hi! Hi!"));
        Assert.AreEqual("Hi Hi Hi!!!", Kata.Remove("Hi! !Hi Hi!"));
        Assert.AreEqual("Hi Hi Hi!!!", Kata.Remove("Hi! !Hi Hi!"));
        Assert.AreEqual("Hi Hi Hi!!!!", Kata.Remove("Hi! Hi!! Hi!"));
    }

    private static string Solution(string s)
    {
        return s.Replace("!", "") + new string('!', s.Count(x => x == '!'));
    }

    private static readonly Random Rand = new Random();

    private static string RandomStr()
    {
        const string chars =
            "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_ !@#$%^&*_(),.?|{}[]-=+\\/";

        List<string> list = new List<string>();
        var n = Rand.Next(1, 10);
        for (var i = 0; i < n; i++)
        {
            var str = string.Concat(Enumerable.Repeat(chars, Rand.Next(1, chars.Length))
                .Select(s => s[Rand.Next(s.Length)])
                .Take(Rand.Next(3, 6)));

            if (Rand.Next(0, 1000) % 3 == 0) str += "!" + new string('!', Rand.Next(0, 3));
            if (Rand.Next(0, 1000) % 3 == 0) str = "!" + new string('!', Rand.Next(0, 3)) + str;

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
