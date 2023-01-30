/*Challenge link:https://www.codewars.com/kata/55a5befdf16499bffb00007b/train/csharp
Question:
Make multiple functions that will return the sum, difference, modulus, product, quotient, and the exponent respectively.

Please use the following function names:

addition = Add

multiply = Multiply

division = Divide

modulus = Mod

exponential = Exponent

subtraction = Subt

Note: All funcitons can return int and all will recieve 2 integers.

Note: All math operations will be: a (operation) b
*/

//***************Solution********************
//apply the correct math operation, and return the result
public static class Kata{
  public static int Add(int a, int b)=> a + b;
  public static int Multiply(int a, int b)=> a * b;
  public static int Divide(int a, int b)=> a / b;
  public static int Mod(int a, int b)=> a % b;
  public static int Exponent(int a, int b)=> IntPow(a,b);
  public static int Subt(int a, int b)=> a - b;
  
  
public static int IntPow(int a, int b){ //not using System.Math 👌
  int result = 1;
  for (int i = 0; i < b; i++)
    result *= a;
  return result;
}
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void BasicTestAddition()
    {
      Assert.AreEqual(12, Kata.Add(5, 7), 
        "Addition for 5 added to 7 should be: 12");
    }
    
    [Test]
    public void BasicTestMultiplication()
    {
      Assert.AreEqual(10, Kata.Multiply(5, 2), 
        "Multiplication for 5 multiplied by 2 should be: 10");
    }
    
    [Test]
    public void BasicTestDivision()
    {
      Assert.AreEqual(4, Kata.Divide(40, 10),
        "Division for 40 divided by 10 should be: 4");
    }
    
    [Test]
    public void BasicTestRemainder()
    {
      Assert.AreEqual(5, Kata.Mod(5, 10),
        "Remainder for 5 divided by 10 should be: 5");
    }
    
    [Test]
    public void BasicTestExponential()
    {
      Assert.AreEqual(1024, Kata.Exponent(2, 10),
        "Exponential for 2 to power of 10 should be: 1024");
    } 
    
    [Test]
    public void BasicTestSubtraction()
    {
      Assert.AreEqual(4000, Kata.Subt(5832, 1832),
        "Subtraction for 1832 subtracted from 5832 should be: 4000");
    }
    
    [Test]
    public void RandomTests()
    {
      Random r = new Random();
      double result = 0;
      
      for(int i = 0; i < 10; i++)
      {
        int a = r.Next(1, 100);
        int b = r.Next(1, 100);
        result = a + b;
        
        Assert.AreEqual(result, Kata.Add(a, b), 
          "Addition for " + a +" added to " + b + " should be: " + result);

        a = r.Next(1, 100);
        b = r.Next(1, 100);
        result = a * b;
        
        Assert.AreEqual(result, Kata.Multiply(a, b),
          "Multiplication for " + a +" multiplied by " + b + " should be: " + result);
        
        a = r.Next(1, 100);
        b = r.Next(1, 100);
        result = a / b;
        
        Assert.AreEqual(result, Kata.Divide(a, b),
          "Division for " + a +" divided by " + b + " should be: " + result);
        
        a = r.Next(1, 100);
        b = r.Next(1, 100);
        result = a % b;
        
        Assert.AreEqual(result, Kata.Mod(a, b),
          "Remainder for " + a +" divided by " + b + " should be: " + result);
        
        a = r.Next(1, 16);
        b = r.Next(1, 8);
        result = Math.Pow(a, b);
        
        Assert.AreEqual(result, Kata.Exponent(a, b),
          "Exponential for " + a +" power of " + b + " should be: " + result);
        
        a = r.Next(1, 100);
        b = r.Next(1, 100);
        result = a - b;
        
        Assert.AreEqual(result, Kata.Subt(a, b), 
          "Subtraction for " + b +" subtracted from " + a + " should be: " + result);
      }
    }
  }
}
