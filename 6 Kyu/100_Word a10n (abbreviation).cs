/*Challenge link:https://www.codewars.com/kata/5375f921003bf62192000746/train/csharp
Question:
The word i18n is a common abbreviation of internationalization in the developer community, used instead of typing the whole word and trying to spell it correctly. Similarly, a11y is an abbreviation of accessibility.

Write a function that takes a string and turns any and all "words" (see below) within that string of length 4 or greater into an abbreviation, following these rules:

A "word" is a sequence of alphabetical characters. By this definition, any other character like a space or hyphen (eg. "elephant-ride") will split up a series of letters into two words (eg. "elephant" and "ride").
The abbreviated version of the word should have the first letter, then the number of removed characters, then the last letter (eg. "elephant ride" => "e6t r2e").
Example
abbreviate("elephant-rides are really fun!")
//          ^^^^^^^^*^^^^^*^^^*^^^^^^*^^^*
// words (^):   "elephant" "rides" "are" "really" "fun"
//                123456     123     1     1234     1
// ignore short words:               X              X

// abbreviate:    "e6t"     "r3s"  "are"  "r4y"   "fun"
// all non-word characters (*) remain in place
//                     "-"      " "    " "     " "     "!"
=== "e6t-r3s are r4y fun!"
*/

//***************Solution********************

//replace input 
//\B not word bound, \w word, {2,} matches 2 or more
//get m length and convert to string. (length that excluded the first and last character)
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Text.RegularExpressions;

public class Abbreviator{
  public static string Abbreviate(string input) => Regex.Replace(input, @"\B\w{2,}\B", m => m.Length.ToString());
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Text;

[TestFixture]
public class AbbreviatorTests
{
  [Test]
    public void TestInternationalization()
    {
        Assert.AreEqual("i18n", Abbreviator.Abbreviate("internationalization"));
    }
    [Test]
    public void TestShortSentance()
    {
        Assert.AreEqual("my. dog, isn't f5g v2y w2l.", Abbreviator.Abbreviate("my. dog, isn't feeling very well."));
    }
    [Test]
    public void TestAccessibility()
    {
        Assert.AreEqual("a11y", Abbreviator.Abbreviate("accessibility"));
    }
    [Test]
    public void TestAccessibilityCaps()
    {
        Assert.AreEqual("A11y", Abbreviator.Abbreviate("Accessibility"));
    }
    [Test]
    public void TestLongSentance()
    {
        Assert.AreEqual("You n2d, n2d not w2t, to c6e t2s c2e-w2s m5n", Abbreviator.Abbreviate("You need, need not want, to complete this code-wars mission"));
    }
    [Test]
    public void TestThrowTheKitchenSinkAtEm()
    {
        string[] joins = { ", ", "-", ": ", "; ", ". ", "'", " " }; // should add "_" and "5"
        string[] words = { "cat", "mat", "doggy", "balloon", "sits", "sat", "a", "is", "on", "the", "monolithic", "double-barreled" };
        string[] wordsAbbreviated = { "cat", "mat", "d3y", "b5n", "s2s", "sat", "a", "is", "on", "the", "m8c", "d4e-b6d" };
        Random rand = new Random();

        for (int i = 0; i < 100; i++)
        {
            StringBuilder input = new StringBuilder();
            StringBuilder expected = new StringBuilder();
            int upper = rand.Next(10) + 1;
            for (int j = 0; j < upper; j++)
            {
                int wordIndex = rand.Next(joins.Length);
                if (input.Length > 0)
                {
                    input.Append(joins[wordIndex]);
                    expected.Append(joins[wordIndex]);
                }
                wordIndex = rand.Next(words.Length);
                input.Append(words[wordIndex]);
                expected.Append(wordsAbbreviated[wordIndex]);
            }
            Assert.AreEqual(expected.ToString(), Abbreviator.Abbreviate(input.ToString()));
        }
    }
    
}
