/*Challenge link:https://www.codewars.com/kata/58068479c27998b11900056e/train/csharp
Question:
#Sorting on planet Twisted-3-7

There is a planet... in a galaxy far far away. It is exactly like our planet, but it has one difference: #The values of the digits 3 and 7 are twisted. Our 3 means 7 on the planet Twisted-3-7. And 7 means 3.

Your task is to create a method, that can sort an array the way it would be sorted on Twisted-3-7.

7 Examples from a friend from Twisted-3-7:

[1,2,3,4,5,6,7,8,9] -> [1,2,7,4,5,6,3,8,9]
[12,13,14] -> [12,14,13]
[9,2,4,7,3] -> [2,7,4,3,9]
There is no need for a precheck. The array will always be not null and will always contain at least one number.

You should not modify the input array!

Have fun coding it and please don't forget to vote and rank this kata! :-)

I have also created other katas. Take a look if you enjoyed this kata!
*/

//***************Solution********************
//x is the current element, from array, order by...
//concat "" with current element x.
//c is the current character, select if c is '3', return '7', if c is '7' return '3', else just return c itself.
//int parse the string, convert to array and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Linq;

public class Kata{
  public static int[] SortTwisted37(int[] array) => 
    array.OrderBy(x => int.Parse(string.Concat(("" + x)
                                       .Select(c => c == '3' ? '7' : c == '7' ? '3' : c))))
                                       .ToArray();
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
      Assert.AreEqual(string.Join(",",new [] {1,2,7,4,5,6,3,8,9}), string.Join(",",Kata.SortTwisted37(new [] {1,2,3,4,5,6,7,8,9})));
      Assert.AreEqual(string.Join(",",new [] {12,14,13}), string.Join(",",Kata.SortTwisted37(new [] {12,13,14})));
      Assert.AreEqual(string.Join(",",new [] {2,7,4,3,9}), string.Join(",",Kata.SortTwisted37(new [] {9,2,4,7,3})));
    }
    
    [Test]
    public void UnchangedArrayTest()
    {
      var array = new [] {9,2,4,7,3};
      var arrayCpy = array.ToArray();
      Kata.SortTwisted37(array);
      Assert.AreEqual(string.Join(",",new [] {2,7,4,3,9}), string.Join(",",Kata.SortTwisted37(array)));
      Assert.AreEqual(string.Join(",",arrayCpy), string.Join(",",array), "You should not modify the input array!");
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      Func<int[],int[]> mySortTwisted37 = delegate (int[] array)
      {
        return array.OrderBy(a => 
        {
          return int.Parse(string.Concat(a.ToString().Select(d => d == '3' ? '7' : d == '7' ? '3' : d)));
        }).ToArray();
      };
      
      for(var r=0;r<40;r++)
      {
        var array = Enumerable.Range(0, rand.Next(1,30)).Select(a => rand.Next(-30, 80)).ToArray();
        Assert.AreEqual(string.Join(",",mySortTwisted37(array)), string.Join(",",Kata.SortTwisted37(array)));
      }
    }
  }
}
