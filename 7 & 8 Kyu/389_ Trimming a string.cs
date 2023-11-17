/*Challenge link:https://www.codewars.com/kata/563fb342f47611dae800003c/train/csharp
Question:
Create a function that will trim a string (the first argument given) if it is longer than the requested maximum string length (the second argument given). The result should also end with "..."

These dots at the end also add to the string length.

For example, trim("Creating kata is fun", 14) should return "Creating ka..."

If the string is smaller or equal than the maximum string length, then simply return the string with no trimming or dots required.

e.g. trim("Code Wars is pretty rad", 50) should return "Code Wars is pretty rad"

If the requested string length is smaller than or equal to 3 characters, then the length of the dots is not added to the string length.

e.g. trim("He", 1) should return "H...", because 1 <= 3

Requested maximum length will be greater than 0. Input string will not be empty.


*/

//***************Solution********************

//if phrase is greater than length, return string interpolation of...
//if length is less than 3, get phrase upto length - 3, else get upto length
//append "..." at the end
//if nothing matches, return phrase.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

public class TrimStringKata{
    public static string TrimString(string p, int l) => p.Length > l ? $"{p[..(l > 3 ? l - 3 : l)]}..." : p;
}

//solution 2
public class TrimStringKata
{
    public static string TrimString(string phrase, int len)
    {
        if(phrase.Length <= len)
          return phrase;
      
        if (len <= 3)
          return phrase.Substring(0, len)+"...";
        
        return phrase.Substring(0, len-3)+"...";
    }
}

//****************Sample Test*****************
using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

[TestFixture]
public class FixedTestSuite
{
    [Test]
    public void ExampleTests()
    {
        DoTest("Creating kata is fun", 14, "Creating ka...");
        DoTest("He", 1, "H...");
        DoTest("Hey", 2, "He...");
        DoTest("Hey", 3, "Hey");
        DoTest("Creating kata is fun", 2, "Cr...");
        DoTest("Code Wars is pretty rad", 3, "Cod...");
        DoTest("Coding rocks", 12, "Coding rocks");
        DoTest("Code Wars is pretty rad", 50, "Code Wars is pretty rad");
        DoTest("London is freezing", 18, "London is freezing");
    }

    [Test]
    public void ShortInput_ShortOutput_Tests() { 

        var cases = new[] {
          ("H",   1, "H"   ), ("H",   2, "H"    ), ("H",   3, "H"  ),
          ("Hi",  1, "H..."), ("Hi",  2, "Hi"   ), ("Hi",  3, "Hi" ),
          ("Hey", 1, "H..."), ("Hey", 2, "He..."), ("Hey", 3, "Hey")
        };

        foreach (var (phrase, len, expected) in cases)
        {
            DoTest(phrase, len, expected);
        }
    }

    [Test]
    public void NoTrimming_Tests()
    {
        DoTest("Lorem ipsum", 11, "Lorem ipsum");
        DoTest("Lorem ipsum", 50, "Lorem ipsum");
    }

    [Test]
    public void TrimAtBeginning_Tests()
    {
        DoTest("Lorem ipsum", 1, "L...");
        DoTest("Lorem ipsum", 3, "Lor...");
        DoTest("Lorem ipsum", 4, "L...");
    }

    [Test]
    public void TrimAtEnd_Tests()
    {
        DoTest("Lorem ipsum", 10, "Lorem i...");
        DoTest("Lorem ipsum", 9, "Lorem ...");
    }

    [Test]
    public void TrimInMiddle_Tests()
    {
        DoTest("Lorem ipsum", 5, "Lo...");
        DoTest("Lorem ipsum", 7, "Lore...");
    }
    private void DoTest(string phrase, int len, string expected)
    {
        string actual = TrimStringKata.TrimString(phrase, len);
        string msg = $"Incorrect answer for:\n    phrase = \"{phrase}\"\n    len    = {len}";
        Assert.AreEqual(expected, actual, msg);
    }
}

[TestFixture]
public class RandomTestSuite
{
    [Test]
    public void RandomTests()
    {

        var cases = new List<(string, int, string)>();

        for (int i = 0; i < 20; ++i)
        {
            string phrase = RandPhrase(rnd.Next(4, 9));

            // No trimming
            int size = phrase.Length + rnd.Next(0, 10);
            cases.Add((phrase, size, phrase));

            // Near beginning
            size = rnd.Next(1, 4);
            cases.Add((phrase, size, RefSolution(phrase, size)));

            // Near end
            size = phrase.Length - rnd.Next(1, 4);
            cases.Add((phrase, size, RefSolution(phrase, size)));

            // In the middle
            size = rnd.Next(4, phrase.Length - 4);
            cases.Add((phrase, size, RefSolution(phrase, size)));
        }

        // Short inputs, short results
        for (int len = 1; len < 4; ++len)
        {
            for (int size = 1; size < 4; ++size)
            {
                string phrase = RandWord(len);
                cases.Add((phrase, size, RefSolution(phrase, size)));
                phrase = RandWord(len);
                cases.Add((phrase, size, RefSolution(phrase, size)));
            }
        }
        
        var shuffled = cases.Select(test => (test, rnd.Next())).OrderBy(e => e.Item2);
        foreach (var testCase in shuffled)
        {
            var (phrase, len, expected) = testCase.test;
            DoTest(phrase, len, expected);
        }
    }

    private string RefSolution(string phrase, int len)
    {
        if (phrase.Length <= len)
        {
            return phrase;
        }
        else if (len > 3)
        {
            return phrase[0..(len-3)] + "...";
        }
        return phrase[0..len] + "...";
    }

    private static readonly Random rnd = new Random();
    private string RandWord(int length)
    {
        const string alphabet = "abcdefghijklmnopqrstuvwxyz";
        string word = string.Join("", Enumerable.Range(0, length).Select(_ => alphabet[rnd.Next(alphabet.Length)]));
        return word;
    }
  
    private string RandPhrase(int length) =>
        string.Join(" ", Enumerable.Range(0, length).Select(_ => RandWord( rnd.Next(2, 8) )));

    private void DoTest(string phrase, int len, string expected)
    {
        string actual = TrimStringKata.TrimString(phrase, len);
        string msg = $"Incorrect answer for:\n    phrase = \"{phrase}\"\n    len    = {len}";
        Assert.AreEqual(expected, actual, msg);
    }
}
