/*Challenge link:https://www.codewars.com/kata/57cfdf34902f6ba3d300001e/train/csharp
Question:
You will be given a list of strings. You must sort it alphabetically (case-sensitive, and based on the ASCII values of the chars) and then return the first value.

The returned value must be a string, and have "***" between each of its letters.

You should not remove or add elements from/to the array.


*/

//***************Solution********************
//sort the string alphabtically, select the first letter and store as array, join each element with ***
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;

public class Kata{
  public static string TwoSort(string[] s)=> string.Join("***", s.OrderBy(a => a, StringComparer.Ordinal).First().ToArray());
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
      Assert.AreEqual("b***i***t***c***o***i***n", Kata.TwoSort(new [] { "bitcoin", "take", "over", "the", "world", "maybe", "who", "knows", "perhaps"}));
      Assert.AreEqual("a***r***e", Kata.TwoSort(new [] { "turns", "out", "random", "test", "cases", "are", "easier", "than", "writing", "out", "basic", "ones"}));
      
      Assert.AreEqual("a***b***o***u***t", Kata.TwoSort(new [] { "lets", "talk", "about", "javascript", "the", "best", "language"}));
      Assert.AreEqual("c***o***d***e", Kata.TwoSort(new [] { "i", "want", "to", "travel", "the", "world", "writing", "code", "one", "day"}));
      Assert.AreEqual("L***e***t***s", Kata.TwoSort(new [] { "Lets", "all", "go", "on", "holiday", "somewhere", "very", "cold"}));
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      
      Func<string[], string> myTwoSort = delegate (string[] s)
      {
        return string.Join("***", s.OrderBy(a => a, StringComparer.Ordinal).First().Select(a => a));
      };

      var names = new [] { "Bitcoin", "LiteCoin", "Ripple", "Dash", "Lisk", "DarkCoin", "Monero", "Ethereum", "Classic", "Mine", "ProofOfWork", "ProofOfStake", "21inc", "Steem", "Dogecoin", "Waves", "Factom", "MadeSafeCoin", "BTC" };

      for (var i=0;i<40;i++)
      {
        var len = rand.Next(1,20);
        
        var s = Enumerable.Range(0, len).Select(a => names[rand.Next(0, names.Length)]).ToArray();       
  
        Assert.AreEqual(myTwoSort(s), Kata.TwoSort(s), "It should work for random inputs too");  
      }    
    }
  }
}
