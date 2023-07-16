/*Challenge link:https://www.codewars.com/kata/strip-comments/train/csharp
Question:
Complete the solution so that it strips all text that follows any of a set of comment markers passed in. Any whitespace at the end of the line should also be stripped out.

Example:

Given an input string of:

apples, pears # and bananas
grapes
bananas !apples
The output expected would be:

apples, pears
grapes
bananas
The code would be called like so:

string stripped = StripCommentsSolution.StripComments("apples, pears # and bananas\ngrapes\nbananas !apples", new [] { "#", "!" })
// result should == "apples, pears\ngrapes\nbananas"
*/

//***************Solution********************

//separate text by space
//join the commentSymbols together with string.join, conver to char array
//select element if the current element index contains any commentSymbols, while the index is not out of range -1

//if true, remove string starting from commentSymbols, then use trim to remove all leading and trailing white-space characters 
//else trim the End, removes all the trailing white-space characters from the current string.
using System.Linq;
using System.Text.RegularExpressions;

public class StripCommentsSolution
{
    public static string StripComments(string text, string[] commentSymbols)
    {
        return string.Join("\n", text.Split('\n')
                     .Select(x => x.IndexOfAny(string.Join("", commentSymbols).ToCharArray()) != -1
                      ? x.Remove(x.IndexOfAny(string.Join("", commentSymbols).ToCharArray())).Trim()
                      : x.TrimEnd()));
    }
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

public class StripCommentsTest
{

    private static Random RANDOM = new Random();

    [Test]
    public void StripComments()
    {
        Assert.AreEqual(
            "apples, pears\ngrapes\nbananas",
            StripCommentsSolution.StripComments("apples, pears # and bananas\ngrapes\nbananas !apples", new string[] { "#", "!" }));

        Assert.AreEqual(
                "a\nc\nd",
                StripCommentsSolution.StripComments("a #b\nc\nd $e f g", new string[] { "#", "$" }));
    }

    [Test]
    public void Edges()
    {
        Assert.AreEqual("a\n b\nc", StripCommentsSolution.StripComments("a \n b \nc ", new string[] { "#", "$" }));
        Assert.AreEqual("a", StripCommentsSolution.StripComments("a", new string[] { "1" }));
        Assert.AreEqual("", StripCommentsSolution.StripComments("a", new string[] { "a" }));
        Assert.AreEqual("", StripCommentsSolution.StripComments("            ", new string[] { "#" }));
        Assert.AreEqual("", StripCommentsSolution.StripComments("# some text", new string[] { "#" }));
    }

    [Test]
    public void Random()
    {
        var comments = new string[] { "#", "$", "!", "-" };
        for (int i = 0; i < 20; i++)
        {
            var test = Regex.Replace(RandomString().Replace("1", comments[RANDOM.Next(4)]).Replace("0", "\n"), "\n+$", "");
            Console.WriteLine(test);
            var exp = StripCommentsSolution.StripComments(test, comments);
            Assert.AreEqual(StripComments(test, comments), exp);
        }
    }

    private static string RandomString()
    {
        var max = BigInteger.Pow(2, 1000);
        var rnd = RandomIntegerBelow(max);
        return Regex.Replace(rnd.ToString("X"), "[2-9]+", "\n\n");
    }

    private static BigInteger RandomIntegerBelow(BigInteger N)
    {
        byte[] bytes = N.ToByteArray();
        BigInteger R;
        Random rnd = new Random();
        do
        {
            rnd.NextBytes(bytes);
            bytes[bytes.Length - 1] &= 0x7F; //force sign bit to positive
            R = new BigInteger(bytes);
        } while (R >= N);

        return R;
    }

    private static string StripComments(string text, string[] commentSymbols)
    {
        var pattern = $"[ ]*([{string.Concat(commentSymbols)}].*)?$";
        return string.Join("\n", text.Split('\n').Select(x => Regex.Replace(x, pattern, "")));
    }
}
