/*Challenge link:https://www.codewars.com/kata/564e7fc20f0b53eb02000106/train/csharp
Question:
Complete the function that takes a string of English-language text and returns the number of consonants in the string.

Consonants are all letters used to write English excluding the vowels a, e, i, o, u.
*/

//***************Solution********************

//Use case-insensitive matching. range b to d, f to h, j to n, p to t, v to z, count number of match and return result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Text.RegularExpressions;

public class Kata{
  public static int ConsonantCount(string str) => Regex.Matches(str, "(?i)[b-df-hj-np-tv-z]").Count;
}

//solution 2
using System.Linq;

public class Kata
{
  public static int ConsonantCount(string s)
  {
    return s.ToLower().Count(x=>char.IsLetter(x)&!"aeiou".Contains(x));
  }
}

//solution 3
using System;
using System.Linq;

public class Kata
{
        public static int ConsonantCount(string str)
        {
            string pattern = ("bcdfghjklmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ");
            int consonantCount = str.Count(pattern.Contains);                       
            return consonantCount;
        }
}
//solution 4
using System;
using System.Linq;
using System.Text.RegularExpressions;

public class Kata
{
  public static int ConsonantCount(string str)
  {    
    return str.ToLower()
              .Where(x => Char.IsLetter(x) && !"aeiou".Contains(x) )
              .Count();
  }
}
//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

[TestFixture]
public class Tests
{
  [Test]
  [TestCase("", ExpectedResult=0)]
  [TestCase("aaaaa", ExpectedResult=0)]
  [TestCase("Bbbbb", ExpectedResult=5)]
  [TestCase("helLo world", ExpectedResult=7)]
  [TestCase("h^$&^#$&^elLo world", ExpectedResult=7)]
  [TestCase("012456789", ExpectedResult=0)]
  [TestCase("012345_Cb", ExpectedResult=2)]
  public static int FixedTest(string s)
  {
    return Kata.ConsonantCount(s);
  }
  
  private static int Solution(string str)
  {
    return new List<char>(str).Where(c => Char.IsLetter(c) && "aeiou".IndexOf(c.ToString().ToLower()) == -1).Count();
  }
  
  
  private static string GetRandomString(int length)
  {
    string chars = "abcdefghijklmnopqrstuvwxyz .,-#+'*!?$%()=";
    Random r = new Random();
    string s = string.Empty;
    for(int i = 0; i < length; i++)
    {
      s += chars[r.Next(chars.Length)];
    }
    return s;
  }
  
  [Test]
  public static void RandomTest([Random(50,100,100)]int length)
  {
    string str = GetRandomString(length);
    Assert.AreEqual(Solution(str), Kata.ConsonantCount(str), string.Format("Should work for \"{0}\"", str));
  }
}
