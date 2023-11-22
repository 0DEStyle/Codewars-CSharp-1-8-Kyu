/*Challenge link:https://www.codewars.com/kata/59d9ff9f7905dfeed50000b0/train/csharp
Question:
Consider the word "abode". We can see that the letter a is in position 1 and b is in position 2. In the alphabet, a and b are also in positions 1 and 2. Notice also that d and e in abode occupy the positions they would occupy in the alphabet, which are positions 4 and 5.

Given an array of words, return an array of the number of letters that occupy their positions in the alphabet for each word. For example,

solve(["abode","ABc","xyzD"]) = [4, 3, 1]
See test cases for more examples.

Input will consist of alphabet characters, both uppercase and lowercase. No spaces.

Good luck!

If you like this Kata, please try:

Last digit symmetry

Alternate capitalization
*/

//***************Solution********************

//from arr, select element(word)
//c is current element(character) and i is index.
//if c mod 32 equal to index + 1, add to count. (mod 32 to get the index of ASCII letter)
//convert the array to list and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
using System.Collections.Generic;

public static class Kata{
  public static List<int> Solve(List<string> arr) => 
    arr.Select(s => s.Where((c, i) => c % 32 == i + 1).Count()).ToList();
}

//solution 2
using System;
using System.Collections.Generic;
using System.Linq;

public static class Kata
{
  public static List<int> Solve(List<string> arr) =>
    arr.Select(v => v.Where((c, i) => Char.ToLower(c) - 97 == i).Count()).ToList();
}

//solution 3
using System.Collections.Generic;
using System.Linq;

public static class Kata
{
    public static List<int> Solve(List<string> arr)
      => arr
      .Select(w => w.ToLower()
      .Where((c, i) => c - 'a' == i)
      .Count())
      .ToList();
}

//solution 4
using System;
using System.Collections.Generic;

public static class Kata
{
  public static List<int> Solve(List<string> arr)
  {
     var count = 0;

     string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

     var list = new List<int>();

     foreach (string item in arr)

            {
                for(int i = 0; i < item.Length; i++)

                {if (item.ToUpper()[i] == alpha[i]) count++; }

                list.Add(count);                
                count = 0;
             }
    
    return list;
    
  }
}
//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  
  public static class Solution
  {
    public static List<int> Solve(List<string> arr) =>
      arr.Select(v => v.Where((c, i) => Char.ToLower(c) - 97 == i).Count()).ToList();
  }

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void BasicTest()
    {
      Assert.That(Kata.Solve(new List<string> {"abode", "ABc", "xyzD"}), Is.EqualTo(new List<int> {4, 3, 1}));
      Assert.That(Kata.Solve(new List<string> {"abide", "ABc", "xyz"}), Is.EqualTo(new List<int> {4, 3, 0}));
      Assert.That(Kata.Solve(new List<string> {"IAMDEFANDJKL", "thedefgh", "xyzDEFghijabc"}), Is.EqualTo(new List<int> {6, 5, 7}));
      Assert.That(Kata.Solve(new List<string> {"encode", "abc", "xyzD", "ABmD"}), Is.EqualTo(new List<int> {1, 3, 1, 3}));
    }
    
    private static Random rnd = new Random();
    public static string randStr(int min, int max) =>
      String.Concat(new char[rnd.Next(min, max)].Select(_ => (char)rnd.Next(97, 123)).Select(c => rnd.Next(0, 2) == 0 ? Char.ToLower(c) : Char.ToUpper(c)).OrderBy(Char.ToLower));
    
    [Test]
    public void RandomTest()
    {
      for (int i = 0; i < 100; ++i)
      {
        List<string> arr = new string[rnd.Next(3, 20)].Select(_ => randStr(3, 20)).ToList();
        Assert.That(Kata.Solve(arr), Is.EqualTo(Solution.Solve(arr)));
      }
    }
  }
}
