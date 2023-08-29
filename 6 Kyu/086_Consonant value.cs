/*Challenge link:https://www.codewars.com/kata/59c633e7dcc4053512000073/train/csharp
Question:
Given a lowercase string that has alphabetic characters only and no spaces, return the highest value of consonant substrings. Consonants are any letters of the alphabet except "aeiou".

We shall assign the following values: a = 1, b = 2, c = 3, .... z = 26.

For example, for the word "zodiacs", let's cross out the vowels. We get: "z o d ia cs"

-- The consonant substrings are: "z", "d" and "cs" and the values are z = 26, d = 4 and cs = 3 + 19 = 22. The highest is 26.
solve("zodiacs") = 26

For the word "strength", solve("strength") = 57
-- The consonant substrings are: "str" and "ngth" with values "str" = 19 + 20 + 18 = 57 and "ngth" = 14 + 7 + 20 + 8 = 49. The highest is 57.
For C: do not mutate input.

More examples in test cases. Good luck!

If you like this Kata, please try:

Word values

Vowel-consonant lexicon
*/

//***************Solution********************
//from input, split by pattern "[aeiou]+"
//if current exist, select (y => (int)y - (int)'a' + 1), and get the sum.
//return the max value.

using System.Linq;
using System.Text.RegularExpressions;

public class Kata{
  public static int Solve(string input) => Regex.Split(input, @"[aeiou]+")
          .Where(x => x.Any())
          .Select(x => x.Select(y => (int)y - (int)'a' + 1).Sum())
          .Max();
}

//****************Sample Test*****************
namespace Solution
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class Tests
    {
        [TestCase("zodiac", 26)]
        [TestCase("chruschtschov", 80)]
        [TestCase("khrushchev", 38)]
        [TestCase("strength", 57)]
        [TestCase("catchphrase", 73)]
        [TestCase("twelfthstreet", 103)]
        [TestCase("mischtschenkoana", 80)]
        public void BasicTests(string input, int expected)
        {
            Assert.That(Kata.Solve(input), Is.EqualTo(expected));
        }
        [Test]
        public void RandomTests()
        {
            for (int i = 0; i < 100; i++)
            {
                var s = RandomWord();
                var ex = SolutionSolver(s);
                Assert.That(Kata.Solve(s), Is.EqualTo(ex));
            }
        }

        private string RandomWord()
        {
            var rnd = new Random();
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, rnd.Next(1, 50))
              .Select(s => s[rnd.Next(s.Length)]).ToArray());
        }

        private static int SolutionSolver(string s)
        {
            var split = s.ToLower().Split(new[] { 'a', 'e', 'i', 'o', 'u' }, StringSplitOptions.RemoveEmptyEntries);
            return split.Select(w => w.Sum(x => x - 96)).Max();
        }
    }
}
