/*Challenge link:https://www.codewars.com/kata/5656b6906de340bd1b0000ac/train/csharp
Question:
Take 2 strings s1 and s2 including only letters from a to z. Return a new sorted string, the longest possible, containing distinct letters - each taken only once - coming from s1 or s2.

Examples:
a = "xyaabbbccccdefww"
b = "xxxxyyyyabklmopq"
longest(a, b) -> "abcdefklmopqwxy"

a = "abcdefghijklmnopqrstuvwxyz"
longest(a, a) -> "abcdefghijklmnopqrstuvwxyz"

/*

//***************Solution********************
//Combine both string s1 and s2
//Find distinct letter, sort by alphabetical order
//return result
//simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Linq;

public class TwoToOne 
{
  
	public static string Longest (string s1, string s2)=> 
    string.Concat((s1+s2).Distinct().OrderBy(c => c));
}

//****************Sample Test*****************
using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public static class TwoToOneTests 
{

    private static Random rnd = new Random();

[Test]
    public static void test1() 
    {
        Assert.AreEqual("aehrsty", TwoToOne.Longest("aretheyhere", "yestheyarehere"));
        Assert.AreEqual("abcdefghilnoprstu", TwoToOne.Longest("loopingisfunbutdangerous", "lessdangerousthancoding"));
        Assert.AreEqual("acefghilmnoprstuy", TwoToOne.Longest("inmanylanguages", "theresapairoffunctions"));
        Assert.AreEqual("adefghklmnorstu", TwoToOne.Longest("lordsofthefallen", "gamekult"));
        Assert.AreEqual("acdeorsw", TwoToOne.Longest("codewars", "codewars"));
        Assert.AreEqual("acdefghilmnorstuw", TwoToOne.Longest("agenerationmustconfrontthelooming", "codewarrs"));
    }
    
    //-----------------------
    public static string LongestSol (string s1, string s2) 
    {
        int[] alpha1 = new int[26];
        for(int i = 0 ; i < alpha1.Length ; i++) alpha1[i] = 0;
        int[] alpha2 = new int[26];
        for(int i = 0 ; i < alpha2.Length ; i++) alpha2[i] = 0;
        for(int i = 0; i < s1.Length; i++) 
        {
            int c = (int)s1[i];
            if (c >= 97 && c <= 122)
                alpha1[c - 97]++;
        }
        for(int i = 0; i < s2.Length; i++) 
        {
            int c = (int)s2[i];
            if (c >= 97 && c <= 122)
                alpha2[c - 97]++;
        }
        string res = "";
        for(int i = 0; i < 26; i++) 
        {            
            if (alpha1[i] != 0) {
                res += (char)(i+97);
                alpha2[i] = 0;
            }
        }
        for(int i = 0; i < 26; i++) 
        {            
            if (alpha2[i] != 0)
                res += (char)(i+97);
        }      
        char[] lstr = res.ToCharArray();
        Array.Sort(lstr);
        res = string.Join("", lstr);
        return res;
    }
    public static string doEx(int k) 
    {
        String res = "";
        int n = -1;
        for (int i = 0; i < 15; i++) 
        {
            n = rnd.Next(97+k, 122); 
            for (int j = 0; j < rnd.Next(1, 5); j++)
                res += (char)n;
        }
        return res;
    }
    
    //-----------------------
[Test]    
    public static void RandomTest() 
    {
        Console.WriteLine("200 Random Tests");
        for (int i = 0; i < 200; i++) 
        { 
            string s1 = doEx(rnd.Next(1, 10));
            string s2 = doEx(rnd.Next(1, 8));
            //Console.WriteLine(s1);
            //Console.WriteLine(s2);
            //Console.WriteLine(longestSol(s1, s2));
            //Console.WriteLine("****");
            Assert.AreEqual(LongestSol(s1, s2), TwoToOne.Longest(s1, s2));
        }
    }  
}
