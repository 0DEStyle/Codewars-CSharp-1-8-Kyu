/*Challenge link:https://www.codewars.com/kata/57ed30dde7728215300005fa/train/csharp
Question:
Your car is old, it breaks easily. The shock absorbers are gone and you think it can handle about 15 more bumps before it dies totally.

Unfortunately for you, your drive is very bumpy! Given a string showing either flat road (_) or bumps (n). If you are able to reach home safely by encountering 15 bumps or less, return Woohoo!, otherwise return Car Dead
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
class Kata{
    public static string Bump(string input) => input.Count(x=>x == 'n') <= 15 ? "Woohoo!" : "Car Dead";
}

//****************Sample Test*****************
using System;
using System.Linq;
using NUnit.Framework;

[TestFixture]
class Tests
{
    [TestCase("n", "Woohoo!")]
    [TestCase("__nn_nnnn__n_n___n____nn__nnn", "Woohoo!")]
    [TestCase("nnn_n__n_n___nnnnn___n__nnn__", "Woohoo!")]
    [TestCase("_nnnnnnn_n__n______nn__nn_nnn", "Car Dead")]
    [TestCase("______n___n_", "Woohoo!")]
    public void BasicTests(string input, string expected)
    {
        Assert.That(Kata.Bump(input), Is.EqualTo(expected));
    }
    [Test]
    public void RandomTests()
    {
        var input = CreateString();
        var expected = BumpSolution(input);
        Assert.That(Kata.Bump(input), Is.EqualTo(expected));
    }
    string BumpSolution(string input) => input.Count(x => x == 'n') <= 15 ? "Woohoo!" : "Car Dead";

    string CreateString()
    {
        var rnd = new Random();
        var s = "";
        for (int i = 0; i < rnd.Next(1, 35); i++)
            s += "_n"[rnd.Next(0, 2)];
        return s;
    }
}
