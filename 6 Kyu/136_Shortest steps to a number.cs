/*Challenge link:https://www.codewars.com/kata/5cd4aec6abc7260028dcd942/train/csharp
Question:
Summary:
Given a number, num, return the shortest amount of steps it would take from 1, to land exactly on that number.

Description:
A step is defined as either:

Adding 1 to the number: num += 1
Doubling the number: num *= 2
You will always start from the number 1 and you will have to return the shortest count of steps it would take to land exactly on that number.

1 <= num <= 10000

Examples:

num == 3 would return 2 steps:

1 -- +1 --> 2:        1 step
2 -- +1 --> 3:        2 steps

2 steps
num == 12 would return 4 steps:

1 -- +1 --> 2:        1 step
2 -- +1 --> 3:        2 steps
3 -- x2 --> 6:        3 steps
6 -- x2 --> 12:       4 steps

4 steps
num == 16 would return 4 steps:

1 -- +1 --> 2:        1 step
2 -- x2 --> 4:        2 steps
4 -- x2 --> 8:        3 steps
8 -- x2 --> 16:       4 steps

4 steps

*/

//***************Solution********************

//if number is less than 2, return 0
//else 1 + num mod 2 + recussively call function ShortestStepsToNum by passing num / 2 to accumulate the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

namespace Solution{
  public static class Kata{
    public static int ShortestStepsToNum(int num) =>  num < 2 ? 0 :
                                                                1 + num % 2 + ShortestStepsToNum(num / 2);
  }
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
namespace Solution 
{
  public static class Answer
  {
    public static int ExpectedMethod(int num)
    {
      int count = 0;
      while(num != 1)
      {
        if (num % 2 == 0)
          num /= 2;
        else
          num -= 1;
        count++;
      }
      return count;
    }
  }

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void SimpleTests()
    {
      Assert.AreEqual(0, Kata.ShortestStepsToNum(1));
      Assert.AreEqual(4, Kata.ShortestStepsToNum(12));
      Assert.AreEqual(4, Kata.ShortestStepsToNum(16));
      Assert.AreEqual(9, Kata.ShortestStepsToNum(71));
    }
    
    [Test]
    public void SmallNumbers()
    {
      Assert.AreEqual(1, Kata.ShortestStepsToNum(2));
      Assert.AreEqual(2, Kata.ShortestStepsToNum(3));
      Assert.AreEqual(2, Kata.ShortestStepsToNum(4));
      Assert.AreEqual(3, Kata.ShortestStepsToNum(5));
      Assert.AreEqual(3, Kata.ShortestStepsToNum(6));
      Assert.AreEqual(4, Kata.ShortestStepsToNum(7));
      Assert.AreEqual(3, Kata.ShortestStepsToNum(8));
      Assert.AreEqual(4, Kata.ShortestStepsToNum(9));
      Assert.AreEqual(4, Kata.ShortestStepsToNum(10));
      Assert.AreEqual(5, Kata.ShortestStepsToNum(20));
      Assert.AreEqual(7, Kata.ShortestStepsToNum(30));
      Assert.AreEqual(6, Kata.ShortestStepsToNum(40));
      Assert.AreEqual(7, Kata.ShortestStepsToNum(50));
      Assert.AreEqual(5, Kata.ShortestStepsToNum(11));
      Assert.AreEqual(5, Kata.ShortestStepsToNum(24));
      Assert.AreEqual(7, Kata.ShortestStepsToNum(37));
      Assert.AreEqual(6, Kata.ShortestStepsToNum(48));
      Assert.AreEqual(9, Kata.ShortestStepsToNum(59));
      Assert.AreEqual(7, Kata.ShortestStepsToNum(65));
      Assert.AreEqual(8, Kata.ShortestStepsToNum(73));
      Assert.AreEqual(9, Kata.ShortestStepsToNum(83));
      Assert.AreEqual(6, Kata.ShortestStepsToNum(64));
      Assert.AreEqual(9, Kata.ShortestStepsToNum(99));
      Assert.AreEqual(8, Kata.ShortestStepsToNum(100));
    }
    
    [Test]
    public void BigNumbers()
    {
      Assert.AreEqual(17, Kata.ShortestStepsToNum(10000));
      Assert.AreEqual(16, Kata.ShortestStepsToNum(1500));
      Assert.AreEqual(18, Kata.ShortestStepsToNum(1534));
      Assert.AreEqual(17, Kata.ShortestStepsToNum(1978));
      Assert.AreEqual(17, Kata.ShortestStepsToNum(2763));
      Assert.AreEqual(20, Kata.ShortestStepsToNum(9999));
      Assert.AreEqual(16, Kata.ShortestStepsToNum(2673));
      Assert.AreEqual(17, Kata.ShortestStepsToNum(4578));
      Assert.AreEqual(18, Kata.ShortestStepsToNum(9876));
      Assert.AreEqual(16, Kata.ShortestStepsToNum(2659));
      Assert.AreEqual(18, Kata.ShortestStepsToNum(7777));
      Assert.AreEqual(17, Kata.ShortestStepsToNum(9364));
      Assert.AreEqual(17, Kata.ShortestStepsToNum(7280));
      Assert.AreEqual(17, Kata.ShortestStepsToNum(4998));
      Assert.AreEqual(17, Kata.ShortestStepsToNum(9283));
      Assert.AreEqual(16, Kata.ShortestStepsToNum(8234));
      Assert.AreEqual(19, Kata.ShortestStepsToNum(7622));
      Assert.AreEqual(11, Kata.ShortestStepsToNum(800));
      Assert.AreEqual(13, Kata.ShortestStepsToNum(782));
      Assert.AreEqual(12, Kata.ShortestStepsToNum(674));
      Assert.AreEqual(18, Kata.ShortestStepsToNum(4467));
      Assert.AreEqual(14, Kata.ShortestStepsToNum(1233));
      Assert.AreEqual(18, Kata.ShortestStepsToNum(3678));
      Assert.AreEqual(19, Kata.ShortestStepsToNum(7892));
      Assert.AreEqual(16, Kata.ShortestStepsToNum(5672));
    }
    
    [Test]
    public void SmallRandomNumbers()
    {
      Random rd = new Random();
      for(int i = 0; i < 50; i++)
      {
        int num = rd.Next(0,1000);
        int expected = Answer.ExpectedMethod(num);
        Assert.AreEqual(expected, Kata.ShortestStepsToNum(num));
      }
    }
    
    [Test]
    public void BigRandomNumbers()
    {
      Random rd = new Random();
      for(int i = 0; i < 50; i++)
      {
        int num = rd.Next(1000,10000);
        int expected = Answer.ExpectedMethod(num);
        Assert.AreEqual(expected, Kata.ShortestStepsToNum(num));
      }
    }
  }
}
