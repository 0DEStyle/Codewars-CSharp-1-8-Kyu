/*Challenge link:https://www.codewars.com/kata/57cff961eca260b71900008f/train/csharp
Question:
Given an array of numbers, check if any of the numbers are the character codes for lower case vowels (a, e, i, o, u).

If they are, change the array value to a string of that vowel.

Return the resulting array.


*/

//***************Solution********************
//in object array a, convert elements(an ASCII number) to character and see if it matches "aeiou"
//if true, convert that element to character and to string
//if not, return element as normal
//store everything in array and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;

public class Kata{
    public static object[] IsVow(object[] a) =>
      a.Select(x => "aeiou".Contains(Convert.ToChar(x)) ? Convert.ToChar(x).ToString() : x).ToArray();
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
      Assert.AreEqual(new object[] { 118, "u",120,121,"u",98,122,"a",120,106,104,116,113,114,113,120,106 }, Kata.IsVow(new object[] { 118,117,120,121,117,98,122,97,120,106,104,116,113,114,113,120,106 }));
      Assert.AreEqual(new object[] { "e",121,110,113,113,103,121,121,"e",107,103 }, Kata.IsVow(new object[] { 101,121,110,113,113,103,121,121,101,107,103 }));
      Assert.AreEqual(new object[] { 118,103,110,109,104,106 }, Kata.IsVow(new object[] { 118,103,110,109,104,106 }));
      Assert.AreEqual(new object[] { 107,99,110,107,118,106,112,102 }, Kata.IsVow(new object[] { 107,99,110,107,118,106,112,102 }));
      Assert.AreEqual(new object[] { 100,100,116,"i","u",121 }, Kata.IsVow(new object[] { 100,100,116,105,117,121 }));
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      Func<object[], object[]> myIsVow = delegate(object[] a)
      {
        return a.Select(b => (int)b == 101 ? "e" : (int)b == 97 ? "a" : (int)b == 117 ? "u" : (int)b == 111 ? "o" : (int)b == 105 ? "i" : b).ToArray();
      };
      
      for (var i=0;i<40;i++)
      {
        var len = rand.Next(1,20);
      
        var s = Enumerable.Range(0,len).Select(a => rand.Next(97, 123)).Cast<object>().ToArray();      
  
        Assert.AreEqual(myIsVow(s), Kata.IsVow(s), "It should work for random inputs too");  
      }
    }
  }
}
