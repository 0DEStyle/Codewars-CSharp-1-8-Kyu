/*Challenge link:https://www.codewars.com/kata/57eba158e8ca2c8aba0002a0/train/csharp
Question:
Given a string of words (x), you need to return an array of the words, sorted alphabetically by the final character in each.

If two words have the same last letter, they returned array should show them in the order they appeared in the given string.

All inputs will be valid.
*/

//***************Solution********************
//split the string x
//order by last character
//store in array and return the result

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
public static class Kata{
  public static string[] Last(string x)=> x.Split().OrderBy(c=>c.Last()).ToArray();
}

//****************Sample Test*****************
using System;
using System.Linq;
using NUnit.Framework;

public class KataTests
{
    [Test]
    public void SampleTest()
    {
        Assert.AreEqual(new[] { "cba", "cab", "abc" }, Kata.Last("abc cba cab"));
        Assert.AreEqual(new[] { "aaa", "bbb", "ccc", "ddd" }, Kata.Last("bbb ccc aaa ddd"));
        Assert.AreEqual(new[] { "wa", "de", "co", "rs" }, Kata.Last("co de wa rs"));
        Assert.AreEqual(new[] { "axa", "ava", "asa" }, Kata.Last("axa ava asa"));
      
        Assert.AreEqual(new[] { "a", "need", "ubud", "i", "taxi", "man", "to", "up" },
            Kata.Last("man i need a taxi up to ubud"));

        Assert.AreEqual(new[] { "time", "are", "we", "the", "climbing", "volcano", "up", "what" },
            Kata.Last("what time are we climbing up the volcano"));

        Assert.AreEqual(new[] { "take", "me", "semynak", "to" }, Kata.Last("take me to semynak"));

        Assert.AreEqual(new[] { "massage", "massage", "massage", "yes", "yes" },
            Kata.Last("massage yes massage yes massage"));

        Assert.AreEqual(new[] { "a", "and", "take", "dance", "please", "bintang" },
            Kata.Last("take bintang and a dance please"));
    }

    [Test]
    public void RandomTest()
    {
        for (var i = 0; i < 300; i++)
        {
            var str = RandomString();
            var expected = Solution(str);
            var message = FailureMessage(str, expected);
            var actual = Kata.Last(str);

            Assert.AreEqual(expected, actual, message);
        }
    }

    private static string[] Solution(string x)
    {
        return x.Split().OrderBy(s => s.Last()).ToArray();
    }

    private static readonly Random Rand = new Random();
    private const string Chars = "abcdefghijklmnopqrstuvwxyz";

    private static string RandomString()
    {
        var n = Rand.Next(1, 32);
        return string.Join(" ",
            Enumerable.Range(0, 4).Select(x =>
                string.Concat(Enumerable.Range(0, n).Select(c => Chars[Rand.Next(Chars.Length)]))));
    }

    private static string FailureMessage(string str, string[] value)
    {
        return $"Should return [{string.Join(", ", value)}] with \"{str}\"";
    }
}
