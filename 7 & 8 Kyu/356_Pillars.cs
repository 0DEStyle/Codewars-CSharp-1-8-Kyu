/*Challenge link:https://www.codewars.com/kata/5bb0c58f484fcd170700063d/train/csharp
Question:
There are pillars near the road. The distance between the pillars is the same and the width of the pillars is the same. Your function accepts three arguments:

number of pillars (≥ 1);
distance between pillars (10 - 30 meters);
width of the pillar (10 - 50 centimeters).
Calculate the distance between the first and the last pillar in centimeters (without the width of the first and last pillar).
*/

//***************Solution********************
//apply algorithm
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public static class Kata{
 public static int Pillars(int numPill, int dist, int width)=>
   (numPill - 1) * dist * 100 + width * (numPill > 1 ? numPill - 2 : 0);
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void BasicTest1()
    {
      Assert.AreEqual(0, Kata.Pillars(1,10,10), "Testing for number of pillars: 1, distance: 10 m and width: 10 cm");
    }
    
    [Test]
    public void BasicTest2()
    {
      Assert.AreEqual(2000, Kata.Pillars(2,20,25), "Testing for number of pillars: 2, distance: 20 m and width: 25 cm");
    }
    
    [Test]
    public void BasicTest3()
    {
      Assert.AreEqual(15270, Kata.Pillars(11,15,30), "Testing for number of pillars: 11, distance: 15 m and width: 30 cm");
    }
    
    [Test]
    public void RandomTests()
    {
      Random r = new Random();
      for(int i = 0; i < 50; i++)
      {
        int n = r.Next(1, 1000);
        int d = r.Next(10, 30);
        int w = r.Next(10, 50);
        
        int result = (n-1)*d*100 + Math.Max(0, n-2)*w;
        
        Assert.AreEqual(result, Kata.Pillars(n,d,w), 
                        "Testing for number of pillars: " + n + ", distance: " + d + " and width: " + w + " cm");
      }      
    }
  }
}
