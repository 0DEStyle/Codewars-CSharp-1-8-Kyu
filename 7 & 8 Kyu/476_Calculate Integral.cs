/*Challenge link:https://www.codewars.com/kata/55d32bff0cc60b2e7f000173/train/csharp
Question:
##What are you dealing with...

You're a clever programmer and too lazy to calculate integrals by your own!
So you decide to write a method which will do your calculations.

You got a linear function y = m * x + b and this is the code that is already existing:

public class LinFunc
{
  public double M { get; set; }
  public double B { get; set; }
  
  public double GetY(double x)
  {
    // not implemented
  }
  
  public double CalcIntegral(int a, int b)
  {
    // not implemented
  }
}
##TODO Here it is up to you! Implement the missing code for these two methods GetY(double x) and CalcIntegral(int from, int to).
*/

//***************Solution********************
public class LinFunc{
  //arg (double m, double b, int from, int to)
  public double M { get; set; }
  public double B { get; set; }
  
  //y = mx + b
  public double GetY(double x) => M * x + B;
  
  //plug the sum of to and from / 2 into GetY, 
  //times the difference between to and from 
  public double CalcIntegral(int from, int to) => 
    GetY((to + from) / 2.0) * (to - from);
}

//****************Sample Test*****************
using NUnit.Framework;

[TestFixture]
public class Tests
{
  [Test]
  [TestCase(0,1,0,1,ExpectedResult=1)]
  [TestCase(0,1,0,10,ExpectedResult=10)]
  [TestCase(1,0,0,4,ExpectedResult=8)]
  [TestCase(2,0,2,4,ExpectedResult=12)]
  public static double FixedTestCalcIntegral(double m, double b, int from, int to)
  {
    LinFunc f = new LinFunc();
    f.M = m;
    f.B = b;
    return f.CalcIntegral(from, to);
  }
  
  [Test]
  [TestCase(1,1,1,ExpectedResult=2)]
  [TestCase(1,2,1,ExpectedResult=3)]
  [TestCase(5,7,4,ExpectedResult=27)]
  public static double FixedTestGetY(double m, double b, double x)
  {
    LinFunc f = new LinFunc();
    f.M = m;
    f.B = b;
    return f.GetY(x);
  }
  
  [Test]
  public static void RandomTestCalcIntegral(
    [Random(0,100,4)] double m,
    [Random(0,100,4)] double b,
    [Random(0,100,4)] int from,
    [Random(0,100,4)] int to
  )
  {
    LinFunc f = new LinFunc();
    f.M = m;
    f.B = b;
    Assert.AreEqual(Solution(m,b,from,to), f.CalcIntegral(from, to));
  }
  
  [Test]
  public static void RandomTestGetY([Random(1,5,4)]double m, [Random(1,5,4)]double b, [Random(1,20,4)]double x)
  {
    LinFunc f1 = new LinFunc();
    Func f2 = new Func();
    f1.M = m;
    f2.M = m;
    f1.B = b;
    f2.B = b;
    Assert.AreEqual(f1.GetY(x), f2.GetY(x));
  }
  
  private static double Solution(double a, double b, int c, int d)
  {
    Func f = new Func();
    f.M = a;
    f.B = b;
    return f.CalcIntegral(c,d);
  }
  
  private class Func
  {
    public double M { get; set; }
    public double B { get; set; }
  
    public double GetY(double x)
    {
      return this.M * x + this.B;
    }
  
    public double CalcIntegral(int from, int to)
    {
      return (to-from)*this.GetY(from)+(to-from)*(this.GetY(to)-this.GetY(from))/2;
    }
  }
}
