/*Challenge link:https://www.codewars.com/kata/583203e6eb35d7980400002a/train/csharp
Question:
Given an array (arr) as an argument complete the function countSmileys that should return the total number of smiling faces.

Rules for a smiling face:

Each smiley face must contain a valid pair of eyes. Eyes can be marked as : or ;
A smiley face can have a nose but it does not have to. Valid characters for a nose are - or ~
Every smiling face must have a smiling mouth that should be marked with either ) or D
No additional characters are allowed except for those mentioned.

Valid smiley face examples: :) :D ;-D :~)
Invalid smiley faces: ;( :> :} :]

Example
countSmileys([':)', ';(', ';}', ':-D']);       // should return 2;
countSmileys([';D', ':-(', ':-)', ';~)']);     // should return 3;
countSmileys([';]', ':[', ';*', ':$', ';-D']); // should return 1;
Note
In case of an empty array return 0. You will not be tested with invalid input (input will always be an array). Order of the face (eyes, nose, mouth) elements will always be the same.
*/

//***************Solution********************
//solution 1
//join the string array together separated by a space.
//check regex pattern to find if
//eyes are either : or ;
//nose is either - or ~
//mouth is either ) or D
//count the pattern, and return the result
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Text.RegularExpressions;
using System.Linq;

public static class Kata{
  public static int CountSmileys(string[] smileys) => Regex.Matches(string.Join(" ",smileys), @"(?::|;)(?:-|~)?(\)|D)").Count();
}

//solution 2
using System.Text.RegularExpressions;
using System.Linq;

public static class Kata{
  public static int CountSmileys(string[] smileys)=> smileys.Count(s => Regex.IsMatch(s, @"^[:;]{1}[~-]{0,1}[\)D]{1}$"));
}

//****************Sample Test*****************
namespace Solution {
  using System.Text.RegularExpressions;
  using System.Linq;
  using NUnit.Framework;
  using System;

[TestFixture]
public class SolutionTest
{
    [Test]
    public void BasicTest()
    {
        Assert.AreEqual(4, Kata.CountSmileys(new string[] { ":D", ":~)", ";~D", ":)" }));
        Assert.AreEqual(2, Kata.CountSmileys(new string[] { ":)", ":(", ":D", ":O", ":;" }));
        Assert.AreEqual(1, Kata.CountSmileys(new string[] { ";]", ":[", ";*", ":$", ";-D" }));
        Assert.AreEqual(0, Kata.CountSmileys(new string[] { ";", ")", ";*", ":$", "8-D" }));
    }

    [Test]
    public void RandomTests()
    {
        Random rand = new Random();
        var eyes   = new string[4] { ";", ":", "8", ""  };
        var noses  = new string[4] { "-", "~", " ", ""  };
        var mouths = new string[4] { ")", "D", "(", "P" };
        Func<string[], string> sample = (x) => x[rand.Next(x.Length)];

        for (int i = 0; i < 50; i++)
        {
            string[] smileys = new string[rand.Next(1,10)];
            for (int r = 0; r < smileys.Length; r++)
            {
                smileys[r] = sample(eyes) + sample(noses) + sample(mouths);
            }
            var expected = MyCode(smileys);
            var actual = Kata.CountSmileys(smileys);
            Console.WriteLine($"total = {expected}:\n  {string.Join("  ", smileys)} ");
            Assert.AreEqual(expected,actual);
        }
    }
    
    private int MyCode(string[] smileys) => Regex.Matches(string.Join(" ", smileys), @"[:;][-~]?[)D]").Count;
}
}
