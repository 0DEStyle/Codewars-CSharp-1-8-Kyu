/*Challenge link:https://www.codewars.com/kata/5b180e9fedaa564a7000009a/train/csharp
Question:
In this Kata, you will be given a string that may have mixed uppercase and lowercase letters and your task is to convert that string to either lowercase only or uppercase only based on:

make as few changes as possible.
if the string contains equal number of uppercase and lowercase letters, convert the string to lowercase.
For example:

solve("coDe") = "code". Lowercase characters > uppercase. Change only the "D" to lowercase.
solve("CODe") = "CODE". Uppercase characters > lowecase. Change only the "e" to uppercase.
solve("coDE") = "code". Upper == lowercase. Change all to lowercase.
More examples in test cases. Good luck!

Please also try:

Simple time difference

Simple remove duplicates 
*/

//***************Solution********************
//if uppercase letter is more than lowercase letter, convert all to upper, else convert all to lower, return the result
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
class Kata{
    public static string Solve(string s) =>
      s.Count(x=> char.IsUpper(x)) >s.Count(x=> char.IsLower(x)) ? s.ToUpper() : s.ToLower();
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Linq;

[TestFixture]
class Tetst
{
    [TestCase("code", "code")]
    [TestCase("CODe", "CODE")]
    [TestCase("COde", "code")]
    [TestCase("Code", "code")]
    public void BasicTests(string s, string expected)
    {
        Assert.That(Kata.Solve(s), Is.EqualTo(expected));
    }
    static Random rnd = new Random();
    [Test]
    public void RandomTests()
    {
        for (int i = 0; i < 100; i++)
        {
            var s = CreateString();
            var expected = SolveSolution(s);
            Assert.That(Kata.Solve(s), Is.EqualTo(expected));
        }
    }

    string SolveSolution(string s)
    {
        return s.Count(char.IsUpper) > s.Count(char.IsLower) ? s.ToUpper() : s.ToLower();
    }
    string CreateString()
    {
        var letters = new[] { "abcdefghijklmnopqrstuvwxyz", "ABCDEFGHIJKLMNOPQRSTUVWXYZ" };
        var length = rnd.Next(2, 100);
        var opt = rnd.Next(1, 2);
        var position = rnd.Next(0, 26);
        var res = "";
        for (int i = 0; i < length; i++)
            res += letters[opt][position];
        return res;
    }
}
