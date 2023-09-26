/*Challenge link:https://www.codewars.com/kata/5254bd1357d59fbbe90001ec/train/csharp
Question:
Have a look at the following numbers.

 n | score
---+-------
 1 |  50
 2 |  150
 3 |  300
 4 |  500
 5 |  750
Can you find a pattern in it? If so, then write a function getScore(n)/get_score(n)/GetScore(n) which returns the score for any positive number n.

Note Real test cases consists of 100 random cases where 1 <= n <= 10000
*/

//***************Solution********************

//pattern: n * 50 + previous result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Sequence {
  public static long GetScore(long n) => 50 * (n * (n + 1) / 2);
}

//****************Sample Test*****************
using NUnit.Framework;
using System;

[TestFixture]
public class SequenceTest 
{
  [Test]
  public void BasicTests() 
  {
    Assert.AreEqual(50, Sequence.GetScore(1), "GetScore(1) returns a wrong result");
    Assert.AreEqual(150, Sequence.GetScore(2), "GetScore(2) returns a wrong result");
    Assert.AreEqual(300, Sequence.GetScore(3), "GetScore(3) returns a wrong result");
    Assert.AreEqual(500, Sequence.GetScore(4), "GetScore(4) returns a wrong result");
    Assert.AreEqual(750, Sequence.GetScore(5), "GetScore(5) returns a wrong result");  
    Assert.AreEqual(1050, Sequence.GetScore(6), "GetScore(6) returns a wrong result");  
    Assert.AreEqual(1400, Sequence.GetScore(7), "GetScore(7) returns a wrong result");  
    Assert.AreEqual(1800, Sequence.GetScore(8), "GetScore(8) returns a wrong result");  
    Assert.AreEqual(2250, Sequence.GetScore(9), "GetScore(9) returns a wrong result");  
    Assert.AreEqual(2750, Sequence.GetScore(10), "GetScore(10) returns a wrong result");  
    Assert.AreEqual(10500, Sequence.GetScore(20), "GetScore(20) returns a wrong result");  
    Assert.AreEqual(23250, Sequence.GetScore(30), "GetScore(30) returns a wrong result");  
    Assert.AreEqual(252500, Sequence.GetScore(100), "GetScore(100) returns a wrong result");  
    Assert.AreEqual(381300, Sequence.GetScore(123), "GetScore(123) returns a wrong result");  
    Assert.AreEqual(25025000, Sequence.GetScore(1000), "GetScore(1000) returns a wrong result");  
    Assert.AreEqual(38099750, Sequence.GetScore(1234), "GetScore(1234) returns a wrong result");  
    Assert.AreEqual(2500250000L, Sequence.GetScore(10000), "GetScore(10000) returns a wrong result");  
    Assert.AreEqual(3810284250L, Sequence.GetScore(12345), "GetScore(12345) returns a wrong result");  
  }

  [Test]
  public void RandomTests() 
  {
    Random random = new Random();
    int n;

    for(int i = 0; i < 20; i++) {
      n = random.Next(1, 10000);
      Assert.AreEqual(ActualSequence.GetScore(n), Sequence.GetScore(n), "GetScore(" + n + ") returns a wrong result"); 
    }
  }
}
