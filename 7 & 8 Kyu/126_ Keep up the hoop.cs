/*Challenge link:https://www.codewars.com/kata/55cb632c1a5d7b3ad0000145/train/csharp
Question:
Alex just got a new hula hoop, he loves it but feels discouraged because his little brother is better than him

Write a program where Alex can input (n) how many times the hoop goes round and it will return him an encouraging message :)

If Alex gets 10 or more hoops, return the string "Great, now move on to tricks".
If he doesn''t get 10 hoops, return the string "Keep at it until you get it".
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Kata{
  public static string HoopCount(int n)=> n >= 10 ? "Great, now move on to tricks" : "Keep at it until you get it";
}

//****************Sample Test*****************
using NUnit.Framework;
using System;

[TestFixture]
public class Tests
{
  [Test]
  public static void FixedTest()
  {
    Assert.AreEqual("Keep at it until you get it", Kata.HoopCount(6), "Should work for 6");
    Assert.AreEqual("Great, now move on to tricks", Kata.HoopCount(10), "Should work for 10");
    Assert.AreEqual("Great, now move on to tricks", Kata.HoopCount(22), "Should work for 22");
  }
  
  [Test]
  public static void RandomTest()
  {
    Random r = new Random();
    for(int i = 0; i < 1000; i++)
    {
      int num = r.Next(1000)-500;
      Assert.AreEqual(Solution(num), Kata.HoopCount(num), "Should work for "+num);
    }
  }
  
  private static string Solution(int n)
  {
    return n >= 10 ? "Great, now move on to tricks" : "Keep at it until you get it";
  }
}
