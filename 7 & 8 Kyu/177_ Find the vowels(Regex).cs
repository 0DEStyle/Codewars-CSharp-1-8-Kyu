/*Challenge link:https://www.codewars.com/kata/5680781b6b7c2be860000036/train/csharp
Question:
We want to know the index of the vowels in a given word, for example, there are two vowels in the word super (the second and fourth letters).

So given a string "super", we should return a list of [2, 4].

Some examples:
Mmmm  => []
Super => [2,4]
Apple => [1,5]
YoMama -> [1,2,4,6]
NOTES
Vowels in this context refers to: a e i o u y (including upper case)
This is indexed from [1..n] (not zero indexed!)
*/

//***************Solution********************
//using Regex to find match character of a,e,i,o,u,y and ignore the letter case, then select the index of each character but +1(result demanded)
//return the result in array format.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
using System.Text.RegularExpressions;

public class Kata{
  public static int[] VowelIndices(string word) => Regex.Matches(word, "(?i)[aeiouy]").Select(c => c.Index + 1).ToArray();
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text.RegularExpressions;

  [TestFixture]
  public class SolutionTest
  {
    private static Random rnd = new Random();
    
    private static int[] solution(string word)
    {
      List<int> result = new List<int>();
      
      // Regex which matches any vowels (including 'y'), ignoring case.
      Regex pattern = new Regex("[aeiouy]", RegexOptions.IgnoreCase);
      
      // Push the index (+ 1, due to the result being one-based) of any matches against the input word into our result list
      foreach (Match match in pattern.Matches(word)) 
      {
        result.Add(match.Index + 1);
      }
      
      return result.ToArray();
    }
  
    [Test]
    public void FixedTest()
    {
      Assert.AreEqual(new int[] {}, Kata.VowelIndices("mmm"));
      Assert.AreEqual(new int[] {1, 5}, Kata.VowelIndices("apple"));
      Assert.AreEqual(new int[] {2, 4}, Kata.VowelIndices("super"));
      Assert.AreEqual(new int[] {1, 3, 6}, Kata.VowelIndices("orange"));
      Assert.AreEqual(new int[] {2, 4, 7, 9, 12, 14, 16, 19, 21, 24, 25, 27, 29, 31, 32, 33}, Kata.VowelIndices("supercalifragilisticexpialidocious"));
    }
    
    [Test]
    public void RandomTest()
    {
      const int Tests = 1000;
      
      for (int i = 0; i < Tests; ++i)
      {
        string test = String.Concat(new char[rnd.Next(1, 100)].Select(_ => (char)rnd.Next(32, 127)));
        
        int[] expected = solution(test);
        int[] actual = Kata.VowelIndices(test);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
