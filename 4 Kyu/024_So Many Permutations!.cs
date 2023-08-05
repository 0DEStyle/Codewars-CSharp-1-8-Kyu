/*Challenge link:https://www.codewars.com/kata/5254ca2719453dcc0b00027d/train/csharp
Question:
In this kata, your task is to create all permutations of a non-empty input string and remove duplicates, if present.

Create as many "shufflings" as you can!

Examples:

With input 'a':
Your function should return: ['a']

With input 'ab':
Your function should return ['ab', 'ba']

With input 'abc':
Your function should return ['abc','acb','bac','bca','cab','cba']

With input 'aabb':
Your function should return ['aabb', 'abab', 'abba', 'baab', 'baba', 'bbaa']
Note: The order of the permutations doesn't matter.

Good luck!
*/

//***************Solution********************

// simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
using System.Collections.Generic;

//if length is less than 2, return s as string list
//recursive call to SinglePermutations by passing index 1 of s
//selectmany to return lists of lists, where range start from 0 to current element x.Length +1
//select element where element x start with character 0 up to index i + first item in s +  x.substring at index i
//get distinct value and return result as list.

class Permutations{
  public static List<string> SinglePermutations(string s) => 
      s.Length < 2 ?
  	  new List<string> { s } :
  	  SinglePermutations(s.Substring(1))
  		.SelectMany(x => Enumerable.Range(0, x.Length + 1)
  		.Select(i => x.Substring(0, i) + s[0] + x.Substring(i)))
  		.Distinct()
  		.ToList();
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class SolutionTest
{

    [Test]
    public void Example1()
    {
        Assert.AreEqual(new List<string> { "a" }, Permutations.SinglePermutations("a").OrderBy(x => x).ToList());
    }

    [Test]
    public void Example2()
    {
        Assert.AreEqual(new List<string> { "ab", "ba" }, Permutations.SinglePermutations("ab").OrderBy(x => x).ToList());
    }

    [Test]
    public void Example3()
    {
        Assert.AreEqual(new List<string> { "aabb", "abab", "abba", "baab", "baba", "bbaa" }, Permutations.SinglePermutations("aabb").OrderBy(x => x).ToList());
    }


    [Test]
    public void UniqueLetters()
    {
        var abcd = new List<string>{"abcd", "abdc", "acbd", "acdb", "adbc", "adcb", "bacd", "badc", "bcad", "bcda", "bdac", "bdca",
                                          "cabd", "cadb", "cbad", "cbda", "cdab", "cdba", "dabc", "dacb", "dbac", "dbca", "dcab", "dcba" };

        Assert.AreEqual(abcd, Permutations.SinglePermutations("abcd").OrderBy(x => x).ToList());
        Assert.AreEqual(abcd, Permutations.SinglePermutations("bcad").OrderBy(x => x).ToList());
        Assert.AreEqual(abcd, Permutations.SinglePermutations("dcba").OrderBy(x => x).ToList());
    }


    [Test]
    public void DuplicateLetters()
    {
        Assert.AreEqual(new List<string> { "aa" }, Permutations.SinglePermutations("aa").OrderBy(x => x).ToList());
        Assert.AreEqual(new List<string> { "aaaab", "aaaba", "aabaa", "abaaa", "baaaa" }, Permutations.SinglePermutations("aaaab").OrderBy(x => x).ToList());
        Assert.AreEqual(new List<string> { "aaaaab", "aaaaba", "aaabaa", "aabaaa", "abaaaa", "baaaaa" }, Permutations.SinglePermutations("aaaaab").OrderBy(x => x).ToList());
    }


    [Test]
    public void RandomTests()
    {
        var BASE = "abcdefghijklmnopqrstuvwxyz";
        for (int r = 0; r < 40; r++)
        {
            var s = string.Concat(Enumerable.Range(0, Rand(1, 8))
                                .Select(i => Rand(0, BASE.Length))
                                .Select(i => BASE.Substring(i, 1)));
                                
            Assert.AreEqual(GNAAAAAAAAAA.SinglePermutations(s).OrderBy(x => x).ToList(),Permutations.SinglePermutations(s).OrderBy(x => x).ToList());
        }
    }

    private Random rnd = new Random();

    private int Rand(int x, int y) { return x + rnd.Next(y - x); }

    private static class GNAAAAAAAAAA
    {
        public static List<string> SinglePermutations(string s)
        {
            var sb = new StringBuilder();
            var ans = new HashSet<string>();
            var used = new HashSet<int>();
            DFS(s, used, sb, ans);
            return new List<string>(ans);
        }

        private static void DFS(string s, HashSet<int> used, StringBuilder sb, HashSet<string> ans)
        {

            if (sb.Length == s.Length) ans.Add(sb.ToString());
            else
            {
                for (int x = 0; x < s.Length; x++)
                {
                    if (!used.Contains(x))
                    {
                        sb.Append(s[x]);
                        used.Add(x);
                        DFS(s, used, sb, ans);
                        used.Remove(x);
                        sb.Remove(sb.Length - 1, 1);
                    }
                }
            }
        }
    }
}
