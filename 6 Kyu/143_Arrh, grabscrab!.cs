/*Challenge link:https://www.codewars.com/kata/52b305bec65ea40fe90007a7/train/csharp
Question:
Pirates have notorious difficulty with enunciating. They tend to blur all the letters together and scream at people.

At long last, we need a way to unscramble what these pirates are saying.

Write a function that will accept a jumble of letters as well as a dictionary, and output a list of words that the pirate might have meant.

For example:

grabscrab( "ortsp", ["sport", "parrot", "ports", "matey"] )
Should return ["sport", "ports"].

Return matches in the same order as in the dictionary. Return an empty array if there are no matches.

Good luck!
*/

//***************Solution********************

//x is the current element and y is the character in x, from dictionary, order x by its character y
//check if sequence is equal to anagram order by its charater, then store all the result to list.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Linq;
using System.Collections.Generic;

public static class Kata{
  public static List<string> Grabscrab(string anagram, List<string> dictionary) => 
    dictionary.Where(x => x.OrderBy(y => y).SequenceEqual(anagram.OrderBy(y => y))).ToList();
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  
  public static class Sol
  {
    private static Dictionary<char, int> table(string str) => 
      str.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
      
    private static bool isEqual<T1, T2>(Dictionary<T1, T2> dic1, Dictionary<T1, T2> dic2) => 
      dic1.Count == dic2.Count && !dic1.Except(dic2).Any();
      
    public static List<string> Grabscrab(string anagram, List<string> dictionary)
    {
      var dict = table(anagram);
      return dictionary.Where(v => isEqual(dict, table(v))).ToList();
    }
  }

  [TestFixture]
  public class GrabscrapTest
  {
    private static Random rnd = new Random();
    private static string randStr(int min, int max) => String.Concat(new int[rnd.Next(min, max)].Select(_ => (char)rnd.Next(97, 123)));
    private static List<T> shuffle<T>(List<T> array)
    {
    	for (int i = array.Count; i > 1; i--)
    	{
    	    // Pick random element to swap.
    	    int j = rnd.Next(i); // 0 <= j <= i-1
    	    // Swap.
    	    T tmp = array[j];
    	    array[j] = array[i - 1];
    	    array[i - 1] = tmp;
    	}
      
      return array;
    }
  

    [Test, Description("should pass random test cases")]
    public void RandomTest()
    {
      for (int i = 0; i < 200; ++i)
      {
        string anagram = randStr(2, 100);
        List<string> dictionary = new int[rnd.Next(2, 100)].Select(_ => rnd.Next(0, 2) == 0 ? String.Concat(shuffle(new List<char>(anagram))) : randStr(Math.Max(2, anagram.Length - 5), anagram.Length + 5)).ToList();
        
        Assert.That(Kata.Grabscrab(anagram, dictionary), Is.EqualTo(Sol.Grabscrab(anagram, dictionary)));
      }
    }
  }
}
