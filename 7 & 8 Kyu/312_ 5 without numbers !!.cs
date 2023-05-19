/*Challenge link:https://www.codewars.com/kata/59441520102eaa25260000bf/train/csharp
Question:
Write a function that always returns 5

Sounds easy right? Just bear in mind that you can't use any of the following characters: 0123456789*+-/

Good luck :)
*/

//***************Solution********************
//return 5
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
class Kata{
    public static int UnusualFive()=> "five!".Length;
}

//****************Sample Test*****************
using NUnit.Framework;
using System.IO;
using System.Linq;

[TestFixture]
class Tests
{
    [Test]
    public void Test()
    {
        Assert.That(Kata.UnusualFive(), Is.EqualTo(5));
        Assert.That(CountNotAllowedChars(), Is.EqualTo(0), "you used prohibited chars !!!!!");
    }
    readonly string SolutionFile = File.ReadAllText(@"/workspace/solution.txt");
    readonly string NotAllowedChars = "0123456789*+-/";
    int CountNotAllowedChars() => SolutionFile.Count(x => NotAllowedChars.Contains(x));
}
