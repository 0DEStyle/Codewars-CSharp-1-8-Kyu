/*Challenge link:https://www.codewars.com/kata/52c32ef251f31ae8f50000ae/train/csharp
Question:
Say you have a ratings system. People can rate a page, and the average is displayed on the page for everyone to see.

One way of storing such a running average is to keep the the current average as well as the total rating that all users have submitted and with how many people rated it, so that the average can be calculated and updated when a new rating has been made.

There are a couple of minor problems with this: first, you're keeping 3 columns instead of 1, which isn't ideal. Second is, if you're not careful, the number could get too large and get less and less accurate as the data format tries to keep up.

So what you need to do is this: write a function that takes the current average, the current number of ratings (data points) made, and a new value to add to the average; then return the new value. That way, you only need 2 columns in your database, and the number will not get crazy large over time.

To be clear:

current = 0.5
points = 2
add = 1

--> 0.6666666666666666666666666666666666 // (2/3)
There are also plenty of examples in the example tests.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//better description
//let's say we have a class of 10 students (data-points) with an average score of 80. 
//if you add one more student with a score of 100 what will the average be?

public class Kata{
  public static double AddToAverage(double current, int points, double add) => (current * points + add) / (points + 1);
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class KataTests
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual(1, Kata.AddToAverage(0, 0, 1));
      Assert.AreEqual(1.5, Kata.AddToAverage(1, 1, 2));
      Assert.AreEqual(2, Kata.AddToAverage(1.5, 2, 3));
    
      Assert.AreEqual(123, Kata.AddToAverage(0, 0, 123));
      Assert.AreEqual(289.5, Kata.AddToAverage(123, 1, 456));
      Assert.AreEqual(456, Kata.AddToAverage(289.5, 2, 789));
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      Func<double,int,double,double> solution = delegate (double current, int points, double add)
      {
        return (current * points + add ) / (points + 1);
      };
      for(int r=0;r<40;r++)
      {
        var current = rand.NextDouble() * rand.Next(0, 10);
        var points = rand.Next(0, 20);
        var add = rand.NextDouble() * rand.Next(1,10);
        
        var expected = solution(current, points, add);
        var actual = Kata.AddToAverage(current, points, add);
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
