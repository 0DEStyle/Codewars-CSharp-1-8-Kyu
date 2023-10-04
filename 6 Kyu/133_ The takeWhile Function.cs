/*Challenge link:https://www.codewars.com/kata/54f9173aa58bce9031001548/train/csharp
Question:
Here's another staple for the functional programmer. You have a sequence of values and some predicate for those values. You want to get the longest prefix of elements such that the predicate is true for each element. We'll call this the takeWhile function. It accepts two arguments. The first is the sequence of values, and the second is the predicate function. The function does not change the value of the original sequence.

Example:
sequence : [2,4,6,8,1,2,5,4,3,2]
predicate: is an even number
result   : [2,4,6,8]
Your task is to implement the takeWhile function.

If you've got a span function lying around, this is a one-liner! Also, if you liked this problem, you'll surely love the dropWhile function.
*/

//***************Solution********************
//arr takewhile (pred), convert back to array
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;

public class Kata{
  public static int[] TakeWhile(int[] arr, Func<int,bool> pred) =>  arr.TakeWhile(pred).ToArray();
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
      Func<int,bool> isEven = (num) => num % 2 == 0;
      Func<int,bool> isOdd = (num) => num % 2 != 0;
      
      Assert.AreEqual(new int[0], Kata.TakeWhile(new int[0], isEven));
      Assert.AreEqual(new int[] { 2,6,4,10 }, Kata.TakeWhile(new int[] { 2,6,4,10,1,5,4,3 }, isEven));
      Assert.AreEqual(new int[] { 2,100,1000,10000 }, Kata.TakeWhile(new int[] { 2,100,1000,10000,5,3,4,6 }, isEven));
      Assert.AreEqual(new int[] { 998,996,12,-1000,200,0 }, Kata.TakeWhile(new int[] { 998,996,12,-1000,200,0,1,1,1 }, isEven));
      Assert.AreEqual(new int[] { }, Kata.TakeWhile(new int[] { 1,4,2,3,5,4,5,6,7 }, isEven));
      Assert.AreEqual(new int[] { 2,4,10,100,64,78,92 }, Kata.TakeWhile(new int[] { 2,4,10,100,64,78,92 }, isEven));
      
      Assert.AreEqual(new int[] { 1,5,111,1111 }, Kata.TakeWhile(new int[] { 1,5,111,1111,2,4,6,4,5 }, isOdd));
      Assert.AreEqual(new int[] { -1,-5,127 }, Kata.TakeWhile(new int[] { -1,-5,127,86,902,2,1 }, isOdd));
      Assert.AreEqual(new int[] {  }, Kata.TakeWhile(new int[] { 2,1,2,4,3,5,4,6,7,8,9,0 }, isOdd));
      Assert.AreEqual(new int[] { 1,3,5,7,9,111 }, Kata.TakeWhile(new int[] { 1,3,5,7,9,111 }, isOdd));
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      
      Func<int,bool> isEven = (num) => num % 2 == 0;
      Func<int,bool> isOdd = (num) => num % 2 != 0;
      
      for(int r = 0; r < 40; r++)
      {
        var arr = Enumerable.Range(0, rand.Next(2, 10)).Select(a => rand.Next(-200, 201)).ToArray();
        
        Assert.AreEqual(arr.TakeWhile(isEven).ToArray(), Kata.TakeWhile(arr, isEven));
        Assert.AreEqual(arr.TakeWhile(isOdd).ToArray(), Kata.TakeWhile(arr, isOdd));
      }
    }
  }
}
