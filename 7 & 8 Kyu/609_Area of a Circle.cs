/*Challenge link:https://www.codewars.com/kata/537baa6f8f4b300b5900106c/train/csharp
Question:
Complete the function which will return the area of a circle with the given radius.

Returned value is expected to be accurate up to tolerance of 0.01.

If the radius is not positive, throw ArgumentException.

Example:

Kata.CalculateAreaOfCircle(43.2673); // returns 5881.248  (± 0.01)
Kata.CalculateAreaOfCircle(68);      // returns 14526.724 (± 0.01)
Kata.CalculateAreaOfCircle(0.0);     // throws ArgumentException
Kata.CalculateAreaOfCircle(-1.0);    // throws ArgumentException
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
/*
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨⬛⬜🟨🟨🟨🟨🟨⬛⬜🟨
🟨⬛⬛🟨🟨🟨🟨🟨⬛⬛🟨
🟨⬛⬛🟨🟨⬛🟨🟨⬛⬛🟨
🟥🟨🟨🟨🟨🟨🟨🟨🟨🟨🟥
🟥🟥🟨🟨🟨⬛🟨🟨🟨🟥🟥
🟥🟥🟨🟨⬛🟨⬛🟨🟨🟥🟥
🟥🟨🟨🟨🟨🟨🟨🟨🟨🟨🟥
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
*/
//throw argument exption if r is null or 0, else pi*r^2
using System;

public static class Kata{
  public static double CalculateAreaOfCircle(double r) => 0 >= r ? throw new ArgumentException() : Math.PI * r * r;
}

//****************Sample Test*****************
using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class AreaOfCircleTests
{
  [Test, Order(1)]
  public void TestPositiveNumber()
  {
    DoTest(1.0, 3.141);
  }

  [Test, Order(1)]
  public void TestExamples()
  {
    DoTest(43.2673,  5881.248);
    DoTest(68     , 14526.724);
  }  

  [Test, Order(1)]
  public void TestZero()
  {
    DoFailingTest(0);
  }  
  
  [Test, Order(1)]
  public void TestNegativeNumber()
  {
    DoFailingTest(-1);
  }

  [Test, Order(2)]
  public void TestRandomCases()
  {
    var rnd = new Random();
    
    var inputs = new List<double>();
    for(int i=0; i<80; ++i)
    {
      double radius = rnd.Next(10_000 * 1_000) / 1_000.0;
      inputs.Add(radius);
    }
    for(int i=0; i<20; ++i)
    {
      double radius = -rnd.Next(10_000 * 1_000) / 1_000.0;
      inputs.Add(radius);
    }
    
    IEnumerable<T> Shuffle<T>(IEnumerable<T> col) =>
      col.Select(e => (Elem: e, Key: rnd.Next())).OrderBy(t => t.Key).Select(t => t.Elem);

    foreach(double radius in Shuffle(inputs))
    {      
      if(radius > 0)
      {
        double expected = Math.Pow(radius, 2) * Math.PI;
        DoTest(radius, expected);
      } else {
        DoFailingTest(radius);
      }
    }
  }  
  
  private void DoTest(double radius, double expected)
  {
    double actual = -1.0;
    Assert.DoesNotThrow(() => actual = Kata.CalculateAreaOfCircle(radius), $"Expected {expected} but an unexpected exception thrown for radius = {radius}");
    Assert.AreEqual(expected, actual, 0.01, $"Incorrect answer for radius = {radius}");
  }
  
  private void DoFailingTest(double radius)
  {
    Assert.Throws<ArgumentException>( () => Kata.CalculateAreaOfCircle(radius), $"Incorrect answer for radius = {radius}");
  }  
}
