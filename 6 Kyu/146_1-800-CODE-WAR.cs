/*Challenge link:https://www.codewars.com/kata/5a3267b2ee1aaead3d000037/train/csharp
Question:
Background
If your phone buttons have letters, then it is easy remember long phone numbers by making words from the substituted digits.

https://en.wikipedia.org/wiki/Phoneword

source: imgur.com
This is common for 1-800 numbers

1-800 number format
This format probably varies for different countries, but for the purpose of this Kata here are my rules:

A 1-800 number is an 11 digit phone number which starts with a 1-800 prefix.

The remaining 7 digits can be written as a combination of 3 or 4 letter words. e.g.

1-800-CODE-WAR
1-800-NEW-KATA
1-800-GOOD-JOB
The - are included just to improve the readability.

Story
A local company has decided they want to reserve a 1-800 number to help with advertising.

They have already chosen what words they want to use, but they are worried that maybe that same phone number could spell out other words as well. Maybe bad words. Maybe embarrassing words.

They need somebody to check for them so they can avoid any accidental PR scandals!

That's where you come in...

Kata Task
There is a preloaded array of lots of 3 and 4 letter (upper-case) words:

Preloaded.WORDS

Given the 1-800 (phone word) number that the company wants to use, you need to check against all known words and return the set of all possible 1-800 numbers which can be formed using those same digits.

Notes
The desired phone-word number provided by the company is formatted properly. No need to check.
All the letters are upper-case. No need to check.
Only words in the list are allowed.
Good luck!
DM
*/

//***************Solution********************

//Simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Collections.Generic;
using System.Linq;

public class Dinglemouse{
  //string variable
    private static string last7;
  // c - 'A'(ascii value)
    private static char ToDig(char c) => "22233344455566677778889999"[c-'A'];
  
  //check matches by access Preloaded.WORDS
  //x is current element, get element if a.Length equal to x.Length or a.Length equal to 7 and... 
  //f is current element, s is index. 
  //recursively pass in f into ToDig and recursively pass in s into ToDig, check if they're equal, select all.
    private static IEnumerable<string> Matches(string a) => Preloaded.WORDS
      .Where(x => (a.Length == x.Length || a.Length == 7) && x.Zip(a, (f,s) => ToDig(f) == ToDig(s)).All(b => b));
    
  //access matches function, split the strings by '-', take last 2, concat the result and assign it to last7.
  //from the result select many, a is current element. 
  //get substring by a.Length in last7.
  //b is current element, select using string interpolation $"1-800-{a}-{b}", convert to hashset and return the result.
    public static HashSet<string> Check1800(string s) => Matches(last7 = string.Concat(s.Split('-').TakeLast(2)))
      .SelectMany(a => Matches(last7.Substring(a.Length)).Select(b => $"1-800-{a}-{b}")).ToHashSet();
}
//****************Sample Test*****************
//the test case from java version
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
public class SolutionTests
{
    private HashSet<string> Show(HashSet<string> set)
    {
        Console.WriteLine(string.Join(", ", set));
        return set;
    }

    // Reference implementation for the random test cases
    private static class Solution
    {
        // Number/Letter equivalents
        private static string[] BUTTONS = { "0", "1", "2ABC", "3DEF", "4GHI", "5JKL", "6MNO", "7PQRS", "8TUV", "9WXYZ" };

        // One time initialization of the number-word map
        private static Dictionary<long, HashSet<string>> MAP_NUMBER_TO_WORDS = new Dictionary<long, HashSet<string>>();
        static Solution()
        {
            foreach (var word in Preloaded.WORDS)
            {
                var number = StrToNumber(word);
                var r = MAP_NUMBER_TO_WORDS.TryGetValue(number, out var o);
                if (r) o.Add(word);
                else MAP_NUMBER_TO_WORDS.Add(number, new HashSet<string> { word });
            }
        }

        private static int LetterToNumber(char c)
        {
            int i = 0;
            do
            {
                if (BUTTONS[i].IndexOf(c) >= 0) break;
            } while (++i < BUTTONS.Length);
            return i;
        }

        private static long StrToNumber(string str)
        {
            var number = "";
            foreach (var c in str)
                number += LetterToNumber(c);
            return long.Parse(number);
        }

        public static HashSet<string> Check1800(string str)
        {
            var phoneNumber = StrToNumber(str.Replace("-", ""));
            // 3 or 4 digit substitutions
            var formats = new long[][]
            {
            new []{ phoneNumber / 1000 % 10000, phoneNumber % 1000 },   // 1800-XXXX-XXX
            new []{ phoneNumber / 10000 % 1000, phoneNumber % 10000 }   // 1800-XXX-XXXX
            };
            var results = new HashSet<string>();
            foreach (var part in formats)
            {
                // Do both parts make words?
                if (MAP_NUMBER_TO_WORDS.ContainsKey(part[0]) && MAP_NUMBER_TO_WORDS.ContainsKey(part[1]))
                {
                    // Find all combinations!
                    foreach (var first in MAP_NUMBER_TO_WORDS[part[0]])
                        foreach (var second in MAP_NUMBER_TO_WORDS[part[1]])
                            results.Add($"1-800-{first}-{second}");
                }
            }
            return results;
        }
    }

    // =================================================================================  

    [Test]
    public void Clash()
    {
        var expected = new HashSet<string> { "1-800-CODE-WAR", "1-800-CODE-YAP", "1-800-CODE-WAS", "1-800-CODE-ZAP" };
        Assert.IsTrue(expected.SetEquals(Show(Dinglemouse.Check1800("1-800-CODE-WAR"))));

        var expected1 = new HashSet<string> { "1-800-BOY-ARMY", "1-800-COW-ARMY", "1-800-ANY-ARMY" };
        Assert.IsTrue(expected1.SetEquals(Show(Dinglemouse.Check1800("1-800-BOY-ARMY"))));

        var expected2 = new HashSet<string> { "1-800-INK-WANT", "1-800-HOLY-ANT", "1-800-HOLY-COT" };
        Assert.IsTrue(expected2.SetEquals(Show(Dinglemouse.Check1800("1-800-INK-WANT"))));
    }

    [Test]
    public void Unavailable()
    {
        Assert.AreEqual(0, Show(Dinglemouse.Check1800("1-800-WORD-WTF")).Count);
        Assert.AreEqual(0, Show(Dinglemouse.Check1800("1-800-WORD-TTT")).Count);
        Assert.AreEqual(0, Show(Dinglemouse.Check1800("1-800-QQQQ-YOU")).Count);
    }

    [Test]
    public void Xxx()
    {
        var expected = new HashSet<string> { "1-800-XXXX-XXX", "1-800-XXX-XXXX" };
        Assert.IsTrue(expected.SetEquals(Show(Dinglemouse.Check1800("1-800-XXXX-XXX"))));
    }

    [Test]
    public void Unique()
    {
        Assert.AreEqual(1, Show(Dinglemouse.Check1800("1-800-OUR-MUTT")).Count);
        Assert.AreEqual(1, Show(Dinglemouse.Check1800("1-800-SEX-TOYS")).Count);
        Assert.AreEqual(1, Show(Dinglemouse.Check1800("1-800-GOOD-JOB")).Count);
        Assert.AreEqual(1, Show(Dinglemouse.Check1800("1-800-FUN-KATA")).Count);
        Assert.AreEqual(1, Show(Dinglemouse.Check1800("1-800-BIG-JOHN")).Count);
        Assert.AreEqual(1, Show(Dinglemouse.Check1800("1-800-SUX-EGGS")).Count);
    }

    [Test]
    public void Random()
    {
        var w3 = new List<string>();
        var w4 = new List<string>();
        foreach (var w in Preloaded.WORDS)
        {
            if (w.Length == 3) w3.Add(w);
            if (w.Length == 4) w4.Add(w);
        }
        var random = new Random();
        for (int r = 0; r < 250; r++)
        {

            var w3Rnd = w3[random.Next(w3.Count)];
            var w4Rnd = w4[random.Next(w4.Count)];

            if (random.NextDouble() < 0.04)
            {
                // invalid words
                w3Rnd = string.Concat(w3Rnd.Reverse());
                w4Rnd = string.Concat(w4Rnd.Reverse());
            }

            // 1-800-XXX-XXXX or 1-800-XXXX-XXX format?
            var sNumber = random.NextDouble() < 0.5 ? $"1-800-{w3Rnd}-{w4Rnd}" : $"1-800-{w4Rnd}-{w3Rnd}";

            var expected = Solution.Check1800(sNumber);
            var actual = Dinglemouse.Check1800(sNumber);

            Console.WriteLine($"Random Test #{r + 1:D3}: {sNumber} = {string.Join(", ", expected)}");
            Assert.IsTrue(expected.SetEquals(actual));
        }
    }
}
