/*Challenge link:https://www.codewars.com/kata/569e09850a8e371ab200000b/train/csharp
Question:
This is the first step to understanding FizzBuzz.

Your inputs: a positive integer, n, greater than or equal to one. n is provided, you have NO CONTROL over its value.

Your expected output is an array of positive integers from 1 to n (inclusive).

Your job is to write an algorithm that gets you from the input to the output.
*/

//***************Solution********************
//generate number start from 1, count until n, store in array and return the result
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
public class Kata{
  public static int[] PreFizz(int n) => Enumerable.Range(1, n).ToArray();
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
      Assert.AreEqual(new int[] { 1 }, Kata.PreFizz(1), "Array should be from 1 to 1");
      Assert.AreEqual(new int[] { 1, 2 }, Kata.PreFizz(2), "Array should be from 1 to 2");
      Assert.AreEqual(new int[] { 1, 2, 3 }, Kata.PreFizz(3), "Array should be from 1 to 3");
      Assert.AreEqual(new int[] { 1, 2, 3, 4 }, Kata.PreFizz(4), "Array should be from 1 to 4");
      Assert.AreEqual(new int[] { 1, 2, 3, 4, 5 }, Kata.PreFizz(5), "Array should be from 1 to 5");      
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      for(var i=0;i<100;i++)
      {
        var num = rand.Next(1, 1001);
        var expected = Enumerable.Range(1,num).ToArray();
        Assert.AreEqual(expected, Kata.PreFizz(num), "Array should be from 1 to " + num);
      }
    }
  }
}
