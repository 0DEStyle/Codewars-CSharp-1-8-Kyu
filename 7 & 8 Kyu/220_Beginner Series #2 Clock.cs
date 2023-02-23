/*Challenge link:https://www.codewars.com/kata/55f9bca8ecaa9eac7100004a
Question:
Clock shows h hours, m minutes and s seconds after midnight.

Your task is to write a function which returns the time since midnight in milliseconds.

Example:
h = 0
m = 1
s = 1

result = 61000
Input constraints:

0 <= h <= 23
0 <= m <= 59
0 <= s <= 59
*/

//***************Solution********************
//apply algorithm
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

public static class Clock{
    public static int Past(int h, int m, int s)=> h * 3600000 + m * 60000 + s * 1000;
}

//solution 2
using System;
  public static class Clock
  {
    public static int Past(int h, int m, int s)
    {
      return (int)(new TimeSpan(h, m, s)).TotalMilliseconds;
    }
  }
//****************Sample Test*****************
 using NUnit.Framework;
  using System;
  
  [TestFixture]
  public class ClockTest
  {
    [Test]
    public void RandomTests()
    {
     Random r = new Random();
     
      for(int d = 0; d < 100; d++){
        int i = r.Next(24);
        int j = r.Next(60);
        int s = r.Next(60); 
        Assert.AreEqual(Past(i,j,s), Clock.Past(i,j,s), "Failed at Past(" + i + "," + j + "," + s + ")");
      }
     }
     
    public int Past(int h, int m, int s)
    {
      return (h * 60 + m) * 60000 + s * 1000;
    }
  }
