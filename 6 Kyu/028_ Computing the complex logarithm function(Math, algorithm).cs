/*Challenge link:https://www.codewars.com/kata/590ba2baf06c49595f0000a0/train/csharp
Question:
Compute the complex logarithm at any given complex number, accurate to at least 1 in 10^-12. The imaginary part should be inside the interval (−π, π] (i.e if the imaginary part is exactly π, keep it as is).

Note: You shouldn't try to compute the value of this function at the poles. Please return null/NULL/nil/None (C#: throw an ArgumentException, Java: throw an ArithmeticException) if this happens.

System.Numerics is disallowed in this Kata.


*/

//***************Solution********************
//' see comment

using System;

public class Complex{
  public static double[] Log(double[] z){
    double x = z[0]; // Real part of z = x + iy
    double y = z[1]; // Imaginary part of z = x + iy
    
    //Throw exception if real and imaginary are 0 
    if(x==0 && y== 0) throw new ArgumentException();
    
    //Real Part
    z[0] = 0.5 * Math.Log((x*x) + (y*y));
    
    //Imagainary part
    //Atan2 allows calculating the arctangent of all four quadrants. 
    //Atan only allows calculating from quadrants 1 and 4.
    z[1] = Math.Atan2(y,x);
    
    return z; 
  }
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class LogTest
  {
    protected static void AssertComplexEquals(double[] expected, double[] actual)
    {
      if (Math.Abs(expected[0]) <= 1) Assert.That(actual[0], Is.EqualTo(expected[0]).Within(1e-12), "The real part of your returned complex number is not sufficiently close to the expected value");
      else Assert.That(actual[0], Is.EqualTo(expected[0]).Within(1e-10).Percent, "The real part of your returned complex number is not sufficiently close to the expected value");
      if (Math.Abs(expected[1]) <= 1) Assert.That(actual[1], Is.EqualTo(expected[1]).Within(1e-12), "The imaginary part of your returned complex number is not sufficiently close to the expected value");
      else Assert.That(actual[1], Is.EqualTo(expected[1]).Within(1e-10).Percent, "The imaginary part of your returned complex number is not sufficiently close to the expected value");
    }
    [Test]
    public void ExampleTests()
    {
      AssertComplexEquals(new double[] {2.995732273553991, 0}, Complex.Log(new double[] {20, 0}));
      AssertComplexEquals(new double[] {0, 3.141592653589793}, Complex.Log(new double[] {-1, 0}));
      AssertComplexEquals(new double[] {0.346573590279973, 0.785398163397448}, Complex.Log(new double[] {1, 1}));
      Assert.Throws<ArgumentException>(delegate { Complex.Log(new double[] {0, 0}); });
    }
    [Test]
    public void AntiCheatTests()
    {
      Assert.That(AntiCheat.UserSolution, Is.Not.StringContaining("Numerics").IgnoreCase, "System.Numerics is disallowed in this Kata");
    }
    [Test]
    public void FixedTests()
    {
      AssertComplexEquals(new double[] {3.218875824868201, 2.857798544381465}, Complex.Log(new double[] {-24, 7}));
      AssertComplexEquals(new double[] {0, 1.570796326794897}, Complex.Log(new double[] {0, 1}));
      AssertComplexEquals(new double[] {0, 0}, Complex.Log(new double[] {1, 0}));
      AssertComplexEquals(new double[] {1.598433436873693, 0.463447163733142}, Complex.Log(new double[] {8834d / 1997d, 93387d / 42243d}));
      AssertComplexEquals(new double[] {11.275831160977204, 1.203262110987354}, Complex.Log(new double[] {28347, 73623}));
      // Let's test this edge case one more time ;)
      Assert.Throws<ArgumentException>(delegate { Complex.Log(new double[] {0.0, 0.0}); });
    }
    protected static double[] Solution(double[] z) => new double[] {Math.Log(Math.Sqrt(z[0] * z[0] + z[1] * z[1])), Math.Atan2(z[1], z[0])};
    protected static Random RandGen = new Random();
    [Test]
    public void RandomTests()
    {
      double[] z;
      for (int i = 0; i < 100; i++)
      {
        z = new double[] {-5e3 + 1e4 * RandGen.NextDouble(), -5e3 + 1e4 * RandGen.NextDouble()};
        Console.WriteLine("Testing for z = " + z[0] + " + " + z[1] + "i");
        AssertComplexEquals(Solution(z), Complex.Log(z));
      }
    }
  }
}
