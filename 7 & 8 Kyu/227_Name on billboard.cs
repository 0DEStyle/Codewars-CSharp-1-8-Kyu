/*Challenge link:https://www.codewars.com/kata/570e8ec4127ad143660001fd/train/csharp
Question:
You can print your name on a billboard ad. Find out how much it will cost you. Each character has a default price of £30, but that can be different if you are given 2 parameters instead of 1.

You can not use multiplier "*" operator.

If your name would be Jeong-Ho Aristotelis, ad would cost £600. 20 leters * 30 = 600 (Space counts as a character).


*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public class Kata {
  public static double Billboard(string name, double price = 30) {
    double ans = 0;
    return Enumerable.Repeat(ans+=price,name.Length).Sum();
  }
}

//solution 2
public class Kata {
  public static double Billboard(string name, double price = 30) {
    return name.Length / (1/price);
  }
}

//solution 3
using System.Linq;

public class Kata
{
  public static double Billboard(string name, double price = 30)
  {
    return name.Sum(_ => price);
  }
}
//****************Sample Test*****************
namespace Solution {
  
  using NUnit.Framework;
  using NUnit.Framework.Internal;
  
  using System;
  using System.IO;
  
  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void SampleTests()
    {
      Assertion(600, "Jeong-Ho Aristotelis");
      Assertion(40,"CODEWARS", 5);
    }
    
    [Test]
    public void ZeroTest()
    {
      Assertion(0, "CODEWARS", 0);
    }
    
    [Test]
    public void DoesNotContainMultiSign() {
      string code = File.ReadAllText("/workspace/solution.txt");
      Assert.IsFalse(code.Contains("*"), "You can't use the multiply symbol(*) in the code");
    }
    
    [Test]
    public void RandomTesting() {
      Random rand = new Random();
      double price = 0;
      string name = string.Empty;
      double answer = 0;
      
      for (int i = 0; i < 100; i++) {
        price = (double)rand.Next() / 100;
        name = RandName();
        answer = name.Length * price;
        Assertion(answer, name, price);
      }
    }
    
    private static Randomizer RandomString = TestContext.CurrentContext.Random;
    private static string RandName() => RandomString.GetString();
    
    private static void Assertion(double expected, string name, double price = -1) =>
      Assert.AreEqual(
          expected,
          price == -1 ? Kata.Billboard(name) : Kata.Billboard(name, price),
      
          0.000001,
      
          $"\n  Name: \"{name}\"\n" +
            $"  Price: {(price == -1 ? 30 : price)}\n\n"
      
      );
  }
}
