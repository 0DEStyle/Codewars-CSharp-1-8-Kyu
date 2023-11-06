/*Challenge link:https://www.codewars.com/kata/54fb853b2c8785dd5e000957/train/csharp
Question:
Write a generic function chainer
Write a generic function chainer that takes a starting value, and an array of functions to execute on it (array of symbols for Ruby).

The input for each function is the output of the previous function (except the first function, which takes the starting value as its input). Return the final value after execution is complete.

double input = 2;

public static double add(double x) {
  return x + 1;
}

public static double mul(double x) {
   return x * 30;
}
Kata.Chain( input , new[] { (Func<double, double>)add, mul });
//=> returns 90

*/

//***************Solution********************
//loop through each function in fs, pass input value into function, and update the result in input
//return the input as result.
using System;

public static class Kata{
        public static double Chain(double input, Func<double,double>[] fs){
            foreach (var a in fs)
               input = a(input);
          return input;
        }
}

//other solutions
//2
Array.ForEach(fs, f => { input = f(input); });
return input;

//3
fs.ToList().ForEach(f => input = f(input));
return input;

//4
return !fs.Any() ? input : Chain(fs[0](input), fs.Skip(1).ToArray());

//5
return fs.Aggregate(input, (current, f) => f(current));

//****************Sample Test*****************
using NUnit.Framework;
using System;

[TestFixture]
public class ChainTests
{
  public static double add(double x){return x + 10;}
  public static double mul(double x){return x * 30;}
  public static double div(double x){return x / 2;}
  public static double sub(double x){return x - 5;}
  
  [Test]
  public static void AddMulTest()
  {
    Random r = new Random(); double input = r.Next(-1000, 1000);
    Assert.AreEqual(Kata.Chain( input , new[] { (Func<double, double>)add, mul }), (input+10)*30, "Error: chain function not working");  
  }
  
  [Test]
  public static void DivSubTest()
  {
    Random r = new Random(); double input = r.Next(-1000, 1000);
    Assert.AreEqual(Kata.Chain( input , new[] { (Func<double, double>)div, sub }), (input/2)-5, "Error: chain function not working");  
  }
  
  [Test]
  public static void AddSubTest()
  {
    Random r = new Random(); double input = r.Next(-1000, 1000);
    Assert.AreEqual(Kata.Chain( input , new[] { (Func<double, double>)add, sub }), (input+10-5), "Error: chain function not working");  
  }
  
  [Test]
  public static void AddDivTest()
  {
    Random r = new Random(); double input = r.Next(-1000, 1000);
    Assert.AreEqual(Kata.Chain( input , new[] { (Func<double, double>)add, div }), (input+10)/2, "Error: chain function not working");  
  }
  
  [Test]
  public static void MulSubTest()
  {
    Random r = new Random(); double input = r.Next(-1000, 1000);
    Assert.AreEqual(Kata.Chain( input , new[] { (Func<double, double>)mul, sub }), (input*30)-5, "Error: chain function not working");  
  }
  
  [Test]
  public static void AddDivSubMulTest()
  {
    Random r = new Random(); double input = r.Next(-1000, 1000);
    Assert.AreEqual(Kata.Chain( input , new[] { (Func<double, double>)add, div, sub, mul }), (((input+10)/2)-5)*30, "Error: chain function not working");  
  }
  
  [Test]
  public static void DivSubMulTest()
  {
    Random r = new Random(); double input = r.Next(-1000, 1000);
    Assert.AreEqual(Kata.Chain( input , new[] { (Func<double, double>)div, sub, mul }), ((input/2)-5)*30, "Error: chain function not working");  
  }
}
