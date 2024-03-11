/*Challenge link:https://www.codewars.com/kata/5a731b36e19d14400f000c19/train/csharp
Question:
Password Check - Binary to String
A wealthy client has forgotten the password to his business website, but he has a list of possible passwords. His previous developer has left a file on the server with the name password.txt. You open the file and realize it's in binary format.

Write a script that takes an array of possible passwords and a string of binary representing the possible password. Convert the binary to a string and compare to the password array. If the password is found, return the password string, else return false;

DecodePass(["password123", "admin", "admin1"], "01110000 01100001 01110011 01110011 01110111 01101111 01110010 01100100 00110001 00110010 00110011");    => "password123"
DecodePass(["password321", "admin", "admin1"], "01110000 01100001 01110011 01110011 01110111 01101111 01110010 01100100 00110001 00110010 00110011");    => null
DecodePass(["password456", "pass1", "test12"], "01110000 01100001 01110011 01110011 01110111 0
*/

//***************Solution********************
using System;
using System.Linq;

public static class Kata{
    public static string DecodePass(string[] passArr, string bin){
      //split the binary by empty space, select element and convert to int then convert to char
         var s = string.Concat(bin.Split()
                                  .Select(x => (char)Convert.ToInt32(x, 2)));
      //if passArr contains s, return password, else return null
        return passArr.Contains(s) ? s : null;
    }
}

//****************Sample Test*****************
using System;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class KataTests
{
    [Test]
    public void SampleTest()
    {
        Assert.AreEqual("password123",
            Kata.DecodePass(new string[] { "password123", "admin", "admin1" },
                "01110000 01100001 01110011 01110011 01110111 01101111 01110010 01100100 00110001 00110010 00110011"));

        Assert.AreEqual(null,
            Kata.DecodePass(new string[] { "password321", "admin", "admin1" },
                "01110000 01100001 01110011 01110011 01110111 01101111 01110010 01100100 00110001 00110010 00110011"));

        Assert.AreEqual(null,
            Kata.DecodePass(new string[] { "password456", "pass1", "test12" },
                "01110000 01100001 01110011 01110011 01110111 01101111 01110010 01100100 00110001 00110010 00110011"));
    }

    [Test]
    public void FixedTest()
    {
        Assert.AreEqual("password123",
            Kata.DecodePass(new string[] { "password123", "admin", "admin1" },
                "01110000 01100001 01110011 01110011 01110111 01101111 01110010 01100100 00110001 00110010 00110011"));

        Assert.AreEqual(null,
            Kata.DecodePass(new string[] { "password321", "admin", "admin1" },
                "01110000 01100001 01110011 01110011 01110111 01101111 01110010 01100100 00110001 00110010 00110011"));

        Assert.AreEqual(null,
            Kata.DecodePass(new string[] { "password456", "pass1", "test12" },
                "01110000 01100001 01110011 01110011 01110111 01101111 01110010 01100100 00110001 00110010 00110011"));

        Assert.AreEqual("password123",
            Kata.DecodePass(new string[] { "password123", "admin", "admin1" },
                "01110000 01100001 01110011 01110011 01110111 01101111 01110010 01100100 00110001 00110010 00110011"));

        Assert.AreEqual(null,
            Kata.DecodePass(new string[] { "password", "admin", "admin1" },
                "01110000 01100001 01110011 01110011 01110111 01101111 01110010 01100100 00110001 00110010 00110011"));

        Assert.AreEqual(null,
            Kata.DecodePass(new string[] { "password", "pass", "test" },
                "01110000 01100001 01110011 01110011 01110111 01101111 01110010 01100100 00110001 00110010 00110011"));

        Assert.AreEqual("admin123",
            Kata.DecodePass(new string[] { "password123", "admin123" },
                "01100001 01100100 01101101 01101001 01101110 00110001 00110010 00110011"));

        Assert.AreEqual(null,
            Kata.DecodePass(new string[] { "password123", "admin1", "login" },
                "01100001 01100100 01101101 01101001 01101110 00110001 00110010 00110011"));

        Assert.AreEqual(null,
            Kata.DecodePass(new string[] { "password123", "admin321" },
                "01100001 01100100 01101101 01101001 01101110 00110001 00110010 00110011"));

        Assert.AreEqual("a", Kata.DecodePass(new string[] { "password123", "admin123", "a" }, "01100001"));

        Assert.AreEqual(null, Kata.DecodePass(new string[] { "password123", "admin123", "b" }, "01100001"));

        Assert.AreEqual(null,
            Kata.DecodePass(new string[] { "password123", "admin123", "c" }, "01100001"));

        Assert.AreEqual("IzeID1N3JiJNpQGR",
            Kata.DecodePass(new string[] { "IzeID1N3JiJNpQGR", "abc123", "goteam" },
                "01001001 01111010 01100101 01001001 01000100 00110001 01001110 00110011 01001010 01101001 01001010 01001110 01110000 01010001 01000111 01010010"));

        Assert.AreEqual(null,
            Kata.DecodePass(new string[] { "IzeID1N3JpQGR", "abc123", "goteam" },
                "01011010 01111101 00101000 00110100 01111101 01011100 01110110 01111001 01011000 00100101 01010101 01010100 01111001 01101010 00110111 00110010"));

        Assert.AreEqual(null,
            Kata.DecodePass(new string[] { "IzeID1N3Ji", "abc123", "goteam" },
                "01011010 01111101 00101000 00110100 01111101 01011100 01110110 01111001 01011000 00100101 01010101 01010100 01111001 01101010 00110111 00110010"));
    }

    private static string Solution(string[] passArr, string bin)
    {
        var binStr = string.Concat(bin.Split().Select(x => (char)Convert.ToInt32(x, 2)));
        return passArr.Contains(binStr) ? binStr : null;
    }

    private static readonly Random Rand = new Random();

    private static string MakeBinary(string s)
    {
        return string.Join(" ", s.Select(x => Convert.ToString(x, 2)));
    }

    private static string[] RandomPasswords()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        List<string> result = new List<string>();
        for (var i = 0; i < Rand.Next(1, 10); i++)
        {
            var str = string.Concat(Enumerable.Repeat(chars, Rand.Next(5, chars.Length))
                .Select(s => s[Rand.Next(s.Length)]).Take(20));

            result.Add(str);
        }

        return result.ToArray();
    }

    [Test]
    public void RandomTest1()
    {
        for (var i = 0; i < 200; i++)
        {
            var randomPasswords = RandomPasswords();
            var index = Rand.Next(0, randomPasswords.Length);
            var password = randomPasswords[index];
            var binStr = MakeBinary(password);

            var expected = Solution(randomPasswords, binStr);
            var message = FailureMessage(randomPasswords, binStr, expected);
            var actual = Kata.DecodePass(randomPasswords, binStr);

            Assert.AreEqual(expected, actual, message);
        }
    }

    [Test]
    public void RandomTest2()
    {
        for (var i = 0; i < 200; i++)
        {
            var randomPasswords = RandomPasswords();
            var randomPasswords2 = RandomPasswords();
            var index = Rand.Next(0, randomPasswords2.Length);
            var password = randomPasswords2[index];
            var binStr = MakeBinary(password);

            var expected = Solution(randomPasswords, binStr);
            var message = FailureMessage(randomPasswords, binStr, expected);
            var actual = Kata.DecodePass(randomPasswords, binStr);

            Assert.AreEqual(expected, actual, message);
        }
    }

    private static string FailureMessage(string[] randomPasswords, string binStr, string value)
    {
        return $"Should return {value ?? "null"} with [{string.Join(", ", randomPasswords)}] and \"{binStr}\"";
    }
}
