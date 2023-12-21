/*Challenge link:https://www.codewars.com/kata/526471539d52735c620000c6/train/csharp
Question:
Our counter prototype is broken. Can you spot, what's wrong here?

Counter.Value must have manually defined getter/setter methods, according to our company's style guide.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//get and set value in counter to num
public class Counter{
  private int num; 
  
  public int Value{
    get{return num;}
    set{num = value;}
  }
  public Counter() => Value = 0;
  public void Increase() =>++Value;
  public void Reset() => Value = 0;
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;
  using System.Reflection;
  using System.Runtime.CompilerServices;

  [TestFixture]
  public class Counter_Test
  {

    [Test]
    public void Test()
    {
      if (typeof(Counter).GetProperty("Value") == null || typeof(Counter).GetProperty("Value").GetGetMethod() == null)
      {
        Console.WriteLine("Heya, pal. Boss wants getters and setters for the Value property.\nPlease don't remove those or else we won't be able to teach the intended lesson. Cheers.");
        Assert.Fail();
      }
      if (typeof(Counter).GetProperty("Value").GetGetMethod().GetCustomAttributes(typeof(CompilerGeneratedAttribute), true).Any())
      {
        Console.WriteLine("Heya, pal. Me again. We're technically illiterate folks, so we're using C# 2.0 and can't use auto properties. Sorry.");
        Assert.Fail();
      }
      
      Counter counter = new Counter();
      Assert.AreEqual(0, counter.Value, "Initial counter value must be 0");
      counter.Increase();
      Assert.AreEqual(1, counter.Value, "Counter value must be incremented.");
      counter.Reset();
      Assert.AreEqual(0, counter.Value, "Counter value must be reset.");
    }
  }
}
