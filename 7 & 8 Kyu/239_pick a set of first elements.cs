/*Challenge link:https://www.codewars.com/kata/572b77262bedd351e9000076/train/csharp
Question:
Write a function to get the first element(s) of a sequence. Passing a parameter n (default=1) will return the first n element(s) of the sequence.

If n == 0 return an empty sequence []

Examples
var arr = new object[] { 'a', 'b', 'c', 'd', 'e' };
Kata.TakeFirstElements(arr); //=> new object[] { 'a' }
Kata.TakeFirstElements(arr, 2);// => new object[] { 'a', 'b' }
Kata.TakeFirstElements(arr, 3); //=> new object[] { 'a', 'b', 'c' }
Kata.TakeFirstElements(arr, 0); //=> new object[] { }
*/

//***************Solution********************
//take the first n of elements, then store in array, return the result
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
public class Kata{
  public static object[] TakeFirstElements(object[] array, int n = 1)=> array.Take(n).ToArray();
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;    
  using System;
  using System.Linq;

  [TestFixture]
  public class KataTest
  {
    [Test]
    public void BasicTests()
    {
      var arr = new object[] { 'a', 'b', 'c', 'd', 'e' };
      Assert.AreEqual(new object[] { 'a' }, Kata.TakeFirstElements(arr));
      Assert.AreEqual(new object[] { }, Kata.TakeFirstElements(arr, 0));
      Assert.AreEqual(new object[] { 'a' }, Kata.TakeFirstElements(arr, 1));
      Assert.AreEqual(new object[] { 'a', 'b' }, Kata.TakeFirstElements(arr, 2));
      Assert.AreEqual(new object[] { 'a', 'b', 'c', 'd', 'e' }, Kata.TakeFirstElements(arr, 10));
    }
    
    [Test]
    public void RandomTests()
    {
      Random rand = new Random();
      var range = Enumerable.Range(0, 26).Select(i => (object)((char)(i + 97))).ToArray();
      
      for(int i=0;i<30;i++)
      {
         var length = rand.Next(1,30);
                
         Assert.AreEqual(range.Take(length).ToArray(), Kata.TakeFirstElements(range, length));
      }
    }
  }
}
