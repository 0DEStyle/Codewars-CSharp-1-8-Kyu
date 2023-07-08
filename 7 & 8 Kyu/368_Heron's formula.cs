/*Challenge link:https://www.codewars.com/kata/57aa218e72292d98d500240f/train/csharp
Question:
Write function heron which calculates the area of a triangle with sides a, b, and c (x, y, z in COBOL).

Heron's formula:

s∗(s−a)∗(s−b)∗(s−c)\sqrt{s * (s - a) * (s - b) * (s - c)} 
s∗(s−a)∗(s−b)∗(s−c)
​
 
where

s=a+b+c2s = \frac{a + b + c} 2s= 
2
a+b+c
​
 
Output should have 2 digits precision.
*/

//***************Solution********************
//apply formula and round to 2 decimal place.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;

namespace Solution
{
  public static class Program
  {
    public static double Heron(double a, double b, double c)
    {
      double s = (a + b + c)/2;
      return Math.Round(Math.Sqrt(s*(s-a)*(s-b)*(s-c)), 2);
    }
  }
}

//****************Sample Test*****************
namespace Solution
{
  using NUnit.Framework;
  using System;
  using System.Reflection;
  
  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void SampleTests()
    {
      Assertion(6.0, (3, 4, 5));
      Assertion(24.0, (6, 8, 10));
    }
    
    [Test]
    public void RandomTests() {
      double a;
      double b;
      double c;
      
      double s;
      double expected;
      
      Random rand = new Random();
      
      for (int i = 0; i < 100; i++) {
        a = (double)rand.Next(5, 10000);
        b = (double)rand.Next( (int)(a / 2) + 1, (int)a );
        c = (double)rand.Next( (int)(a / 2) + 1, (int)a );
        
        s = (a + b + c) / 2;
        
        expected = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        
        Assertion(expected, (a, b, c));
      }
      
    }
    private static MethodInfo UserFunction;
    
    private static void Assertion(double expected, (double, double, double) inputs) {
      if (UserFunction == null) {
        UserFunction = GetFunction.GetHeron();
      }
            
      object actual = UserFunction.Invoke(null, new object[] {inputs.Item1, inputs.Item2, inputs.Item3});
      if (!(actual is double)) Assert.Fail("Function should return a double");
      
      
      Assert.AreEqual(
        expected,
        (double)UserFunction.Invoke(null, new object[] {inputs.Item1, inputs.Item2, inputs.Item3}),
        0.01,
        
        $"\n  Inputs: {inputs}"
      );
      
    }
  }
}
