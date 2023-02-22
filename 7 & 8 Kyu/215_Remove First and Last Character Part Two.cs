/*Challenge link:https://www.codewars.com/kata/570597e258b58f6edc00230d/train/csharp
Question:
This is a spin off of my first kata.

You are given a string containing a sequence of character sequences separated by commas.

Write a function which returns a new string containing the same character sequences except the first and the last ones but this time separated by spaces.

If the input string is empty or the removal of the first and last items would cause the resulting string to be empty, return an empty value (represented as a generic value NULL in the examples below).

Examples
"1,2,3"      =>  "2"
"1,2,3,4"    =>  "2 3"
"1,2,3,4,5"  =>  "2 3 4"

""     =>  NULL
"1"    =>  NULL
"1,2"  =>  NULL
*/

//***************Solution********************
//split string by ",", then if element length is less than or equal to 2, return null
//else split the string by ",", remove first and last elements, then join by an empty space, return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System;
using System.Linq;

public static class Kata{
  public static string Array(string s) => 
    s.Split(",").Length <= 2 ? null : string.Join(" ",(s.Split(",").Skip(1).SkipLast(1)));
  }
  
  //solution 2
  using System.Linq;

public static class Kata
{
    public static string Array(string s)
    {
        var arr = s.Split(",");
        return arr.Length > 2 ? string.Join(" ", arr[1..^1]) : null;
    }
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
        Assert.AreEqual(null, Kata.Array(""));
        Assert.AreEqual(null, Kata.Array("1"));
        Assert.AreEqual(null, Kata.Array("1, 3"));
        Assert.AreEqual("2", Kata.Array("1,2,3"));
        Assert.AreEqual("2 3", Kata.Array("1,2,3,4"));
    }

    [Test]
    public void RandomTest()
    {
        for (var i = 0; i < 300; i++)
        {
            var str = RandomString();
            var expected = Solution(str);
            var message = FailureMessage(str, expected);
            var actual = Kata.Array(str);

            Assert.AreEqual(expected, actual, message);
        }
    }

    private static string Solution(string s)
    {
        var arr = s.Split(",");
        return arr.Length > 2 ? string.Join(" ", arr[1..^1]) : null;
    }

    private static readonly Random Rand = new Random();
    private const string Chars = "abcdef123456";

    private static string RandomString()
    {
        return string.Join(",", Enumerable.Range(0, Rand.Next(15))
            .Select(x =>
                string.Concat(Enumerable.Range(0, Rand.Next(1, 4)).Select(i => Chars[Rand.Next(Chars.Length)]))));
    }

    private static string FailureMessage(string str, string value)
    {
        return $"Should return {value ?? "null"} with \"{str}\"";
    }
}
