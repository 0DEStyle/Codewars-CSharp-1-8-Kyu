/*Challenge link:https://www.codewars.com/kata/57ea5b0b75ae11d1e800006c/train/csharp
Question:
Write a function that takes an array of strings as an argument and returns a sorted array containing the same strings, ordered from shortest to longest.

For example, if this array were passed as an argument:

["Telescopes", "Glasses", "Eyes", "Monocles"]

Your function would return the following array:

["Eyes", "Glasses", "Monocles", "Telescopes"]

All of the strings in the array passed to your function will be different lengths, so you will not have to decide how to order multiple strings of the same length.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
public class Kata{
  public static string[] SortByLength (string[] array) => array.OrderBy(x => x.Length).ToArray();
}


//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class KataTests
  {
    [Test]
    public void ExampleTests()
    {
      Assert.AreEqual(new string[] { "I", "To", "Beg", "Life" }, Kata.SortByLength(new string[] { "Beg", "Life", "I", "To" }));
      Assert.AreEqual(new string[] { "", "Pizza", "Brains", "Moderately" }, Kata.SortByLength(new string[] { "", "Moderately", "Brains", "Pizza" }));
      Assert.AreEqual(new string[] { "Short", "Longer", "Longest" }, Kata.SortByLength(new string[] { "Longer", "Longest", "Short" }));
    }
    
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual(new string[] { "A", "Of", "Dog", "Food" }, Kata.SortByLength(new string[] { "Dog", "Food", "A", "Of" }));
      Assert.AreEqual(new string[] { "", "Bees", "Eloquent", "Dictionary" }, Kata.SortByLength(new string[] { "", "Dictionary", "Eloquent", "Bees" }));
      Assert.AreEqual(new string[] { "A short sentence", "A longer sentence", "The longest sentence" }, Kata.SortByLength(new string[] { "A longer sentence", "The longest sentence", "A short sentence" }));
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      
      for (var i = 1; i <= 100; i++) 
      {    
        var arrayLength = rand.Next(0, 200);
        var testArray = new string[arrayLength];
        
        for(int r = 0;r<arrayLength;r++)
        {
          testArray[r] = string.Concat(Enumerable.Range(0,r).Select(x => (char)rand.Next(65,91)).ToArray());
        }
        
        testArray = testArray.OrderBy(a => rand.Next(-1,2)).OrderBy(a => rand.Next(-1,2)).ToArray();
    
        var expected = testArray.OrderBy(a => a.Length).ToArray();
        Assert.AreEqual(expected, Kata.SortByLength(testArray));
      }
    }
  }
}
