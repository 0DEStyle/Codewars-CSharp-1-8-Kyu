/*Challenge link:https://www.codewars.com/kata/559ac78160f0be07c200005a/train/csharp
Question:
Write a function that returns a string in which firstname is swapped with last name.

Example(Input --> Output)

"john McClane" --> "McClane john"
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//split the string str, reverse it, then join with space.
using System.Linq;

public class Kata{   
  public static string NameShuffler(string str) => string.Join(" ", str.Split().Reverse());
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  
  [TestFixture]
  public class SolutionTest
  {
    [Test, Description("Sample Tests")]
    public void SampleTest()
    {
      Assert.AreEqual("McClane john", Kata.NameShuffler("john McClane"));
      Assert.AreEqual("jeggins Mary", Kata.NameShuffler("Mary jeggins"));
      Assert.AreEqual("jerry tom", Kata.NameShuffler("tom jerry"));
    }
    
    private static Random rnd = new Random();
    private static string[] firstNames = new string[] {"Augustus", "Tobias", "Vernon", "Ryan", "Bob", "Kareem", "Miguel", "Cyril", "Chris", "Simon", "Tim"};
    private static string[] lastNames = new string[] {"Hill" ,"Beecher" ,"Schillinger" ,"O'Reily" ,"Rebadow" ,"Said" ,"Alvarez" ,"O'Reily" ,"Keller" ,"Adebisi" ,"McManus"};
    
    private static string solution(string str)
    {
      // Split string by spaces
      string[] names = str.Split(' ');
      
      // Reverse array
      Array.Reverse(names);
      
      // Return joined reversed array
      return String.Join(" ", names);
    }
    
    [Test, Description("Random Tests (100 assertions)")]
    public void RandomTests()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        string test = firstNames[rnd.Next(0, firstNames.Length)] + " " + lastNames[rnd.Next(0, lastNames.Length)];
        string expected = solution(test);
        string actual = Kata.NameShuffler(test);
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
