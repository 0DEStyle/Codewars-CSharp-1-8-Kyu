/*Challenge link:https://www.codewars.com/kata/5813d19765d81c592200001a/train/csharp
Question:
Don't give me five!
In this kata you get the start number and the end number of a region and should return the count of all numbers except numbers with a 5 in it. The start and the end number are both inclusive!

Examples:

1,9 -> 1,2,3,4,6,7,8,9 -> Result 8
4,17 -> 4,6,7,8,9,10,11,12,13,14,16,17 -> Result 12
The result may contain fives. ;-)
The start number will always be smaller than the end number. Both numbers can be also negative!

I'm very curious for your solutions and the way you solve it. Maybe someone of you will find an easy pure mathematics solution.

Have fun coding it and please don't forget to vote and rank this kata! :-)

I have also created other katas. Take a look if you enjoyed this kata!


*/

//***************Solution********************
using System.Linq;

//set range from start, count up to (end - start), and include the last digit(+1)
//convert the number to string, if the string does not contain 5, increase count by 1.
//return the result
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Kata
{
  public static int DontGiveMeFive(int start, int end) =>
    Enumerable.Range(start, end-start+1).Where(x => !(x.ToString()).Contains("5")).Count();
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;
  
  public class KataTests
  {
    [Test]
    public void ExampleTests()
    {
      Assert.AreEqual(8, Kata.DontGiveMeFive(1,9));
      Assert.AreEqual(12, Kata.DontGiveMeFive(4,17));
    }
    
    [Test]
    public void MoreTests()
    {
      Assert.AreEqual(72, Kata.DontGiveMeFive(1,90));
      Assert.AreEqual(20, Kata.DontGiveMeFive(-4,17));
      Assert.AreEqual(38, Kata.DontGiveMeFive(-4,37));
      Assert.AreEqual(13, Kata.DontGiveMeFive(-14,-1));
      Assert.AreEqual(1, Kata.DontGiveMeFive(149,151));
      Assert.AreEqual(9, Kata.DontGiveMeFive(-14,-6));      
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      
      Func<int,int,int> myDontGiveMeFive = delegate (int start, int end)
      {
        var count = 0;
        for(int i=start;i<=end;i++)
        {
          if(!i.ToString().Contains("5"))
          {
            count++;
          }
       }
       return count;
      };
      
      for(var i=0;i<30;i++)
      {
        var start = rand.Next(-50, 60);
        var end = rand.Next(start + 1, 80);
        
        Assert.AreEqual(myDontGiveMeFive(start,end), Kata.DontGiveMeFive(start, end));
      }
    }
  }
}
