/*Challenge link:https://www.codewars.com/kata/54b81566cd7f51408300022d/train/csharp
Question:
Write a method that will search an array of strings for all strings that contain another string, ignoring capitalization. Then return an array of the found strings.

The method takes two parameters, the query string and the array of strings to search, and returns an array.

If the string isn't contained in any of the strings in the array, the method returns an array containing a single string: "Empty" (or Nothing in Haskell, or "None" in Python and C)

Examples
If the string to search for is "me", and the array to search is ["home", "milk", "Mercury", "fish"], the method should return ["home", "Mercury"].
*/

//***************Solution********************

//x is the current element.
//convert both x and query to lowercase, check if x contains the string query
//if not return "Empty", else store the elements in arraya and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Linq;

public class Kata{
  public static string[] WordSearch(string query, string[] seq) => 
    seq.Where(x => x.ToLower().Contains(query.ToLower()))
       .DefaultIfEmpty("Empty")
       .ToArray();
}

//solution 2
using System.Linq;
using System.Text.RegularExpressions;

public class Kata
{
  public static string[] WordSearch(string query, string[] seq)
  {
    return seq.Where(s => Regex.IsMatch(s, $"(?i){query}")).DefaultIfEmpty("Empty").ToArray();
  }
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class KataTests
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual(new string[] {"ab", "abc", "zab"}, Kata.WordSearch("ab", new string[] {"za", "ab", "abc", "zab", "zbc"}));
      Assert.AreEqual(new string[] {"ab", "abc", "zab"}, Kata.WordSearch("aB", new string[] {"za", "ab", "abc", "zab", "zbc"}));
      Assert.AreEqual(new string[] {"aB", "Abc", "zAB"}, Kata.WordSearch("ab", new string[] {"za", "aB", "Abc", "zAB", "zbc"}));
      Assert.AreEqual(new string[] {"Empty"}, Kata.WordSearch("abcd", new string[] {"za", "aB", "Abc", "zAB", "zbc"}));
      Assert.AreEqual(new string[] {"Empty"}, Kata.WordSearch("abcd", new string[] { }));  
    }
    
    [Test]
    public void RandomTests()
    {
      var letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
      var rand = new Random();

      Func<string,string[],string[]> wordSol = delegate (string query, string[] seq)
      {
        var res = seq.Where(a => a.ToLower().Contains(query.ToLower())).ToArray();
        return res.Length > 0 ? res : new string[] { "Empty" };
      };
      
      for (var r = 0 ; r < 40 ; r++)
      {
        var query = "";
        var queryLength = rand.Next(1,5);
        
        var seqLength = rand.Next(0,12);
        var seq = new string[seqLength];
        
        for (var i = 0 ; i < queryLength ; i++)
        {
          query += letters[rand.Next(0, letters.Length-1)];
        }
        for (var i = 0 ; i < seqLength ; i++)
        {
          var templen = rand.Next(1,15);
          var temp="";
          for (var j = 0 ; j < templen ; j++)
          {
            temp += letters[rand.Next(0, letters.Length-1)];
            if (rand.Next(0,100) >= 95) 
            {
              temp += query;
            }
          }
          seq[i] = temp;
        }
  
        Console.WriteLine("Testing for wordSearch(" + query + ", {" + string.Join(", ", seq) + "})");
        Assert.AreEqual(wordSol(query, seq), Kata.WordSearch(query, seq),"It should work for random inputs too");
      }
    }
  }
}
