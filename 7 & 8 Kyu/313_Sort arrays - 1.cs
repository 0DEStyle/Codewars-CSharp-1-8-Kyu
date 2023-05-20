/*Challenge link:https://www.codewars.com/kata/51f41b98e8f176e70d0002a8/train/csharp
Question:
Just a simple sorting usage. Create a function that returns the elements of the input-array / list sorted in lexicographical order.
*/

//***************Solution********************
//use Linq OrderBy to sort in lexicographical order
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
public class Kata{
  public static string[] SortMe(string[] n) => n.OrderBy(x => x).ToArray();
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
      Assert.AreEqual("one,three,two", string.Join(",", Kata.SortMe(new [] {"one", "two", "three"})));
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      for(int r=0;r<40;r++)
      {
        var names = Enumerable.Range(0,rand.Next(3,6)).Select(a => string.Concat(Enumerable.Range(0,rand.Next(4, 10)).Select(b => (char)rand.Next(65,90)))).ToArray();
        var expected = names.OrderBy(a => a).ToArray();
        Assert.AreEqual(expected, Kata.SortMe(names));
      }
    }
  }
}
