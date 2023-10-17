/*Challenge link:https://www.codewars.com/kata/587319230e9cf305bb000098/train/csharp
Question:
A History Lesson
Soundex is an interesting phonetic algorithm developed nearly 100 years ago for indexing names as they are pronounced in English. The goal is for homophones to be encoded to the same representation so that they can be matched despite minor differences in spelling.

Reference: https://en.wikipedia.org/wiki/Soundex

Preface
I first read about Soundex over 30 years ago. At the time it seemed to me almost like A.I. that you could just type in somebody's name the way it sounded and there was still a pretty good chance it could match the correct person record. That was about the same year as the first "Terminator" movie so it was easy for me to put 2 and 2 together and conclude that Arnie must have had some kind of futuristic Soundex chip in his titanium skull helping him to locate Serah Coner... or was it Sarh Connor... or maybe Sayra Cunnarr...

:-)

Task
In this Kata you will encode strings using a Soundex variation called "American Soundex" using the following (case insensitive) steps:

Save the first letter. Remove all occurrences of h and w except first letter.
Replace all consonants (include the first letter) with digits as follows:
b, f, p, v = 1
c, g, j, k, q, s, x, z = 2
d, t = 3
l = 4
m, n = 5
r = 6
Replace all adjacent same digits with one digit.
Remove all occurrences of a, e, i, o, u, y except first letter.
If first symbol is a digit replace it with letter saved on step 1.
Append 3 zeros if result contains less than 3 digits. Remove all except first letter and 3 digits after it
Input
A space separated string of one or more names. E.g.

Sarah Connor

Output
Space separated string of equivalent Soundex codes (the first character of each code must be uppercase). E.g.

S600 C560
*/

//***************Solution********************
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Dinglemouse  {
  //create a dictionary to store regex pattern, replace the matched pattern with second parameter.
  private static Dictionary<string, string> patterns = new Dictionary<string, string> {
    { "(?!^)[HW]"     , ""  },    //(?!) Negative lookahead,for character set HW
    { "[BFPV]+"       , "1" },    //character set BFPV match 1 or more
    { "[CGJKQSXZ]+"   , "2" },    //character set CGJKQSXZ match 1 or more
    { "[DT]+"         , "3" },    //character set DT match 1 or more
    { "[L]+"          , "4" },    //character set L match 1 or more
    { "[MN]+"         , "5" },    //character set MN match 1 or more
    { "[R]+"          , "6" },    //character set R match 1 or more
    { "(?!^)[AEIOUY]" , ""  },    //(?!^) Negative look ahead at the beginning of the string. character set AEIOUY match 1 or more
  };
  
    //Regex.Replace(string input, string pattern, string replacement);
    //Substring (int startIndex, int length);
  
    //convert names to upper, split by space. str is current string element, acc is accumulator, s is index.
    //var s, from the above pattern dictionary, aggregate each pattern.  
    //var d, replace s with pattern "^\\d", ^ beginning, \\ escaped character for \, then d character
    //at the end, replace var d with pattern $, meaning end of line, with "00000" 
  public static string Soundex(string names) =>
    string.Join(" ", names.ToUpper().Split(' ').Select(str => {
      var s = patterns.Keys.Aggregate(str, (acc, s) => Regex.Replace(acc, s, patterns[s]));
      var d = Regex.Replace(s, "^\\d", str.Substring(0, 1));
      return Regex.Replace(d, "$", "00000").Substring(0, 4);
    }));

}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;
  using System.Text.RegularExpressions;

  [TestFixture]
  public class SolutionTest
  {
    
    // Reference implementation (for random test expected results)
    private static String _Soundex(String names) 
    {
      return string.Join(" ", names.ToUpper().Split(' ').Select(str => 
      {
        string hw = Regex.Replace(str, "(?!^)[HW]", "");
        string bfp = Regex.Replace(hw, "[BFPV]+", "1");
        string cgj = Regex.Replace(bfp, "[CGJKQSXZ]+", "2");
        string dt = Regex.Replace(cgj, "[DT]+", "3");
        string l = Regex.Replace(dt, "L+", "4");
        string mn = Regex.Replace(l, "[MN]+", "5");
        string r = Regex.Replace(mn, "R+", "6");
        string aei = Regex.Replace(r, "(?!^)[AEIOUY]", "");
        string dig = Regex.Replace(aei, "^\\d", str.Substring(0, 1));
        string result = Regex.Replace(dig, "$", "00000");
        return result.Substring(0, 4);
      }));
    }
    
    [Test]
    public void Arnie()
    {
      Assert.AreEqual("S600 C560", Dinglemouse.Soundex("Sarah Connor"));
      Assert.AreEqual("S600 C560", Dinglemouse.Soundex("Sarah Connor"));
      Assert.AreEqual("S600 C560", Dinglemouse.Soundex("Sarah Connor"));
      Assert.AreEqual("S600 C560", Dinglemouse.Soundex("Sarah Connor"));
      Assert.AreEqual("S600 C560", Dinglemouse.Soundex("Sarah Connor"));
    }
    
    [Test]
    public void ShortNames()
    {
      Assert.AreEqual("T500", Dinglemouse.Soundex("Tim"));
      Assert.AreEqual("J000", Dinglemouse.Soundex("Joe"));
      Assert.AreEqual("B100", Dinglemouse.Soundex("Bob"));
    }
    
    [Test]
    public void WikiExamples() 
    {        
      Assert.AreEqual("R163", Dinglemouse.Soundex("Robert"));
      Assert.AreEqual("R163", Dinglemouse.Soundex("Rupert"));
      Assert.AreEqual("R150", Dinglemouse.Soundex("Rubin"));
      Assert.AreEqual("A261", Dinglemouse.Soundex("Ashcraft"));
      Assert.AreEqual("A261", Dinglemouse.Soundex("Ashcroft"));
      Assert.AreEqual("T522", Dinglemouse.Soundex("Tymczak"));
      Assert.AreEqual("P236", Dinglemouse.Soundex("Pfister"));
    }
    
    [Test]
    public void BugFixes() 
    {  
      Assert.AreEqual("Z641", Dinglemouse.Soundex("zxqurlwbx"));
      Assert.AreEqual("U663", Dinglemouse.Soundex("uryrtkzp")); 
    }
    
    [Test]
    public void Random() {
      for (int r = 0; r < 20; r++)
      {
        Random random = new Random();
        
        int n = random.Next(1, 5);
        string[] names = new string[n];
        
        for (int w = 0; w < names.Length; w++)
        {
          int length = random.Next(2, 20);
          string name = "";
            for (int j = 0; j < length; j++)
            {
              name += "abcdefghijklmnopqrztuvwxyz"[random.Next(0, 25)];
            }
            names[w] = name;
        }
        
        string input = string.Join(" ", names);
        string expected = _Soundex(input);
        
        Assert.AreEqual(expected, Dinglemouse.Soundex(input));
      }
    }
  }
}
