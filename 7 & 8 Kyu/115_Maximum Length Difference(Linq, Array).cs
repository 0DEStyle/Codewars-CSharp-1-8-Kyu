/*Challenge link:https://www.codewars.com/kata/5663f5305102699bad000056/train/csharp
Question:
You are given two arrays a1 and a2 of strings. Each string is composed with letters from a to z. Let x be any string in the first array and y be any string in the second array.

Find max(abs(length(x) − length(y)))

If a1 and/or a2 are empty return -1 in each language except in Haskell (F#) where you will return Nothing (None).

Example:
a1 = ["hoqq", "bbllkw", "oox", "ejjuyyy", "plmiis", "xxxzgpsssa", "xxwwkktt", "znnnnfqknaz", "qqquuhii", "dvvvwz"]
a2 = ["cccooommaaqqoxii", "gggqaffhhh", "tttoowwwmmww"]
mxdiflg(a1, a2) --> 13
Bash note:
input : 2 strings with substrings separated by ,
output: number as a string
*/

//***************Solution********************
//solution1
//find shortest and longest for both a1 and a2,
//then find the difference between a1 longest to a2 shortest, and a2 longest to a2 shortest,
//compare both differences and find the largest, return the result.
using System;
using System.Linq;

public class MaxDiffLength {   
    public static int Mxdiflg(string[] a1, string[] a2) {
      if(a1.Length == 0 || a2.Length == 0) return -1;
      
      string longest1 = a1.OrderByDescending(s => s.Length).First();
      string longest2 = a2.OrderByDescending(s => s.Length).First();
      
      string shortest1 = a1.OrderBy(s => s.Length).First();
      string shortest2 = a2.OrderBy(s => s.Length).First();
      
      int a1Diff = longest1.Length - shortest2.Length, a2Diff = longest2.Length - shortest1.Length;
      
      if (a1Diff > a2Diff) return a1Diff;  
      return a2Diff;  
    }
}

//soluton 2
using System;
using System.Linq;

public class MaxDiffLength 
{
    
    public static int Mxdiflg(string[] a1, string[] a2) 
    {
        if(a1.Length <= 0 || a2.Length <= 0)
          return -1;   
        var first = Math.Abs(a1.Max(x => x.Length) - a2.Min(x => x.Length));
        var second = Math.Abs(a2.Max(x => x.Length) - a1.Min(x => x.Length));
        return Math.Max(first, second);
    }

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public static class MaxDiffLengthTests {

    private static Random rnd = new Random();

[Test]
    public static void test1() 
    {
        string[] s1 = new string[]{"hoqq", "bbllkw", "oox", "ejjuyyy", "plmiis", "xxxzgpsssa", "xxwwkktt", "znnnnfqknaz", "qqquuhii", "dvvvwz"};
        string[] s2 = new string[]{"cccooommaaqqoxii", "gggqaffhhh", "tttoowwwmmww"};
        Assert.AreEqual(13, MaxDiffLength.Mxdiflg(s1, s2)); // 13
        s1 = new string[]{"ejjjjmmtthh", "zxxuueeg", "aanlljrrrxx", "dqqqaaabbb", "oocccffuucccjjjkkkjyyyeehh"};
        s2 = new string[]{"bbbaaayddqbbrrrv"};
        Assert.AreEqual(10, MaxDiffLength.Mxdiflg(s1, s2)); // 10
        s1 = new string[]{"ccct", "tkkeeeyy", "ggiikffsszzoo", "nnngssddu", "rrllccqqqqwuuurdd", "kkbbddaakkk"};
        s2 = new string[]{"tttxxxxxxgiiyyy", "ooorcvvj", "yzzzhhhfffaaavvvpp", "jjvvvqqllgaaannn", "tttooo", "qmmzzbhhbb"};
        Assert.AreEqual(14, MaxDiffLength.Mxdiflg(s1, s2)); // 14  
        s1 = new String[]{};
        s2 = new String[]{"bbbaaayddqbbrrrv"};
        Assert.AreEqual(-1, MaxDiffLength.Mxdiflg(s1, s2)); 
        s1 = new String[]{"ejjjjmmtthh", "zxxuueeg", "aanlljrrrxx", "dqqqaaabbb", "oocccffuucccjjjkkkjyyyeehh"};
        s2 = new String[]{};
        Assert.AreEqual(-1, MaxDiffLength.Mxdiflg(s1, s2)); 
        s1 = new String[]{};
        s2 = new String[]{};
        Assert.AreEqual(-1, MaxDiffLength.Mxdiflg(s1, s2)); 
    }
    
    //-----------------------
    public static string[] DoEx(int k) 
    {
        string[] a1 = new string[k];
        for (int u = 0; u < k; u++) 
        {
            string res = "";
            int n = -1;
            for (int i = 0; i < rnd.Next(1, 15); i++) 
            {
                n = rnd.Next(97, 122); 
                for (int j = 0; j < rnd.Next(1, 4); j++)
                    res += (char)n;
            }
            a1[u] = res;
        }
        return a1;
    }
    
    public static int MxdiflgSol(string[] a1, string[] a2) 
    {
        int mx = -1;
        foreach (string x in a1)
            foreach (string y in a2) 
            {
                int diff = Math.Abs(x.Length - y.Length);
                if (diff > mx)
                    mx = diff;
            }
        return mx;
    }
    //-----------------------
[Test]    
    public static void RandomTest() 
    {
        Console.WriteLine("100 Random Tests MaxDifLength");
        for (int i = 0; i < 100; i++) { 
            string[] s1 = DoEx(rnd.Next(1, 10));
            string[] s2 = DoEx(rnd.Next(1, 8));
            //Console.WriteLine(s1);
            //Console.WriteLine(s2);
            //Console.WriteLine(MxdiflgSol(s1, s2));
            //Console.WriteLine("****");
            Assert.AreEqual(MxdiflgSol(s1, s2), MaxDiffLength.Mxdiflg(s1, s2));
        }
    }  
    
}
