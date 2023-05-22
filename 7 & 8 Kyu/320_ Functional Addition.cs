/*Challenge link:https://www.codewars.com/kata/538835ae443aae6e03000547/train/csharp
Question:
Create a function add(n)/Add(n) which returns a function that always adds n to any number

Note for Java: the return type and methods have not been provided to make it a bit more challenging.

Func<double, double> AddOne = Kata.Add(1);
AddOne(3) => 4
*/

//***************Solution********************
//current x + n
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System;

public static class Kata{
  public static Func<double, double> Add(double n) => x => x + n;
}
//****************Sample Test*****************
namespace Solution
{
  using System;
  using NUnit.Framework;
  
  [TestFixture]
  public class AddFunctionTests
  {
    private Random _rnd;
    
    [SetUp]
    public void Setup()
    {
      _rnd = new Random();
    }
    
    [Test]
    public void AddTwoDoubleNumbers()
    {
      Assert.AreEqual(5, Kata.Add(2)(3), "Kata.Add(2)(3)");
    }
    
    [Test]
    public void AddNegativeAndZero()
    {
      Assert.AreEqual(-15, Kata.Add(0)(-15), "Kata.Add(0)(-15)");
    }
    
    [Test]
    public void AddFunctionReuse()
    {
      var addThree = Kata.Add(3);
      Assert.AreEqual(8, addThree(5), "Kata.Add(3)(5)");
      Assert.AreEqual(8, addThree(5), "Kata.Add(3)(5) again - make sure your add(3) is pure!");
    }
    
    [Test]
    public void RandomInput()
    {
      for (var i = 0; i < 100; i++)
      {
        int num1 = (_rnd.Next(1000) - 500);
        int num2 = (_rnd.Next(1000) - 500);
        Assert.AreEqual(num1 + num2, Kata.Add(num1)(num2), $"Adding {num1} and {num2}");
      }
    }
  }
}
