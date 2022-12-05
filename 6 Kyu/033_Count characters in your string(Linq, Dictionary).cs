/*Challenge link:https://www.codewars.com/kata/52efefcbcdf57161d4000091/train/csharp
Question:
The main idea is to count all the occurring characters in a string. If you have a string like aba, then the result should be {'a': 2, 'b': 1}.

What if the string is empty? Then the result should be empty object literal, {}.
*/

//***************Solution********************
//group the string by character, 
//add to dictionary, by each character key element, with its count
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Collections.Generic;
using System.Linq;

public class Kata{
  public static Dictionary<char, int> Count(string str) => str.GroupBy(c => c).ToDictionary(x => x.Key, x => x.Count());
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Collections.Generic;

[TestFixture]
public class Tests
{
  [Test]
  public static void FixedTest_aaaa()
  {
    Dictionary<char, int> d = new Dictionary<char, int>();
    d.Add('a', 4);
    Assert.AreEqual(d, Kata.Count("aaaa"));
  }
  
  [Test]
  public static void FixedTest_aabb()
  {
    Dictionary<char, int> d = new Dictionary<char, int>();
    d.Add('a', 2);
    d.Add('b', 2);
    Assert.AreEqual(d, Kata.Count("aabb"));
  }
  
  private static Dictionary<char, int> Solution(string str)
  {
    Dictionary<char, int> dict = new Dictionary<char, int>();
    foreach(char c in str)
    {
      if(dict.ContainsKey(c))
        dict[c] = dict[c]+1;
      else
        dict.Add(c, 1);
    }
    return dict;
  }
  
  private static string GetRandomString(int length)
  {
    string alpha = "abcdefghijklmnopqrstuvwxyz";
    string str = string.Empty;
    Random r = new Random();
    for(int i = 0; i < length; i++)
    {
      str += alpha[r.Next(26)];
    }
    return str;
  }
  
  [Test]
  public static void RandomTest([Random(5,100,100)]int length)
  {
    string str = GetRandomString(length);
    Assert.AreEqual(Solution(str), Kata.Count(str), string.Format("Should work for {0}", str));
  }
}
