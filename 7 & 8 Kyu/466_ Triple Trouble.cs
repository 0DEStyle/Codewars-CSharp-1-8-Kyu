/*Challenge link:https://www.codewars.com/kata/5704aea738428f4d30000914/train/csharp
Question:
Triple Trouble
Create a function that will return a string that combines all of the letters of the three inputed strings in groups. Taking the first letter of all of the inputs and grouping them next to each other. Do this for every letter, see example below!

E.g. Input: "aa", "bb" , "cc" => Output: "abcabc"

Note: You can expect all of the inputs to be the same length.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression
//_ is current element, i is index
//"" to make the result turn into a string, then add letter from a,b,c using index.
//concat the strings and return result
using System.Linq;
public class Kata{
  public static string TripleTrouble(string a, string b, string c) => string.Concat(a.Select((_,i) => "" + a[i] + b[i] + c[i]));
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class SolutionTest
  {
    private static Random rnd = new Random();
    
    private static string Solution(string one, string two, string three)
    {
      string result = "";
      
      for (int i = 0; i < one.Length; ++i)
      {
        result += $"{one[i]}{two[i]}{three[i]}";
      }
      return result;
    }
  
    [Test, Description("Hardcoded Tests")]
    public void FixedTest()
    {
      Action[] tests = new Action[]
      {
        () => Assert.AreEqual("ttlheoiscstk", Kata.TripleTrouble("this","test","lock")),
        () => Assert.AreEqual("abcabc", Kata.TripleTrouble("aa","bb","cc")),
        () => Assert.AreEqual("Batman", Kata.TripleTrouble("Bm", "aa", "tn")),
        () => Assert.AreEqual("LexLuthor", Kata.TripleTrouble("LLh","euo","xtr")),
        () => Assert.AreEqual("abcabcabc", Kata.TripleTrouble("aaa","bbb","ccc")),
        () => Assert.AreEqual("abcabcabcabcabcabc", Kata.TripleTrouble("aaaaaa","bbbbbb","cccccc")),
        () => Assert.AreEqual("brrueordlnsl", Kata.TripleTrouble("burn", "reds", "roll")),
        () => Assert.AreEqual("Supermans", Kata.TripleTrouble("Sea","urn","pms")),
      };
      tests.OrderBy(x => rnd.Next()).ToList().ForEach(a => a.Invoke());
    }
    
    [Test, Description("Random Tests")]
    public void RandomTest()
    {
      string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
      for (int i = 0; i < 100; ++i) {
        string a, b, c;
        a = b = c = String.Empty;
        int loops = rnd.Next(1, 30);
        for (int j = 0; j < loops; ++j)
        {
          a += chars[rnd.Next(0, chars.Length)];
          b += chars[rnd.Next(0, chars.Length)];
          c += chars[rnd.Next(0, chars.Length)];
        }
        string expected = Solution(a, b, c);
        string actual = Kata.TripleTrouble(a, b, c);
        Console.WriteLine($"Expected: {expected}\nActual:   {actual}\n");
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
