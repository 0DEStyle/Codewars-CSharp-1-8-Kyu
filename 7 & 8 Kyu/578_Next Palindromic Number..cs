/*Challenge link:https://www.codewars.com/kata/56a6ce697c05fb4667000029/train/csharp
Question:
There were and still are many problem in CW about palindrome numbers and palindrome strings. We suposse that you know which kind of numbers they are. If not, you may search about them using your favourite search engine.

In this kata you will be given a positive integer, val and you have to create the function next_pal()(nextPal Javascript) that will output the smallest palindrome number higher than val.

Let's see:

For C#
Kata.NextPal(11) == 22

Kata.NextPal(188) == 191

Kata.NextPal(191) == 202

Kata.NextPal(2541) == 2552
You will be receiving values higher than 10, all valid.

Enjoy it!!
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//start from val +1 count up to val
//x is the current element,
//parse x to string, get element where  x is the same as x.Reverse

//11 + 1, 11 => 12,13,14,15,16,17,18,19,20,21,22
//"22" == "22"
using System.Linq;

public class Kata{
  public static int NextPal(int val) => 
    Enumerable.Range(val+1, val)
              .First(x => $"{x}" == string.Concat($"{x}".Reverse()));
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
      Assert.AreEqual(22, Kata.NextPal(11));
      Assert.AreEqual(191, Kata.NextPal(188));
      Assert.AreEqual(202, Kata.NextPal(191));
      Assert.AreEqual(2552, Kata.NextPal(2541));
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      
      Func<int,int> myNextPal = delegate (int val)
      {
        do
        {
          val++;
        }
        while(val.ToString() != string.Concat(val.ToString().Reverse()));
    
        return val;
      };
      
      Action<int,int> TestFor = delegate (int rStart, int rEnd)
      {      
        for(var i=0;i<40;i++)
        {
          var val = rand.Next(rStart, rEnd);
          Console.WriteLine("val = " + val);
          Assert.AreEqual(myNextPal(val), Kata.NextPal(val));
        }
      };
      
      TestFor(100,10001);
      TestFor(10000,100001);
      TestFor(100000,1000001);
      TestFor(1000000,10000001);
      TestFor(10000000,100000001);
    }
  }
}
