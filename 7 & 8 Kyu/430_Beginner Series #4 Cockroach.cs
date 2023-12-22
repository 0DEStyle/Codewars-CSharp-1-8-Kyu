/*Challenge link:https://www.codewars.com/kata/55fab1ffda3e2e44f00000c6/train/csharp
Question:
The cockroach is one of the fastest insects. Write a function which takes its speed in km per hour and returns it in cm per second, rounded down to the integer (= floored).

For example:

1.08 --> 30
Note! The input is a Real number (actual type is language dependent) and is >= 0. The result should be an Integer.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression
//km to cm
//1.08 * 1000 * 100
//hour to second
//divide by 3600
//simplification 
//100,000 / 3600 => 1000 / 36 => 250 / 9
//convert to int and return the result

public class Cockroach{
  public static int CockroachSpeed(double x) => (int)((x * 250) / 9);
}


//****************Sample Test*****************
  using NUnit.Framework;
  using System;
  
  [TestFixture]
  public class CockTest
  {
    [Test]
    public void SimpleTests()
    {
     Random r = new Random();
        
      for(int d = 0; d < 100; d++){
        double i = r.NextDouble();
        
        Assert.AreEqual((int)(i / 0.036), Cockroach.CockroachSpeed(i), "Failed at Cockroach(" + i + ")");
      }

     }    

  }
