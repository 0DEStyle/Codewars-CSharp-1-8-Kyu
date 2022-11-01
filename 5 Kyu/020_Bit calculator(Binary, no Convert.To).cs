/*Challenge link:https://www.codewars.com/kata/52ece9de44751a64dc0001d9/train/csharp
Question:
In this kata your task is to create bit calculator. Function arguments are two bit representation of numbers ("101","1","10"...), and you must return their sum in decimal representation.

Test.expect(calculate("10","10") == 4);
Test.expect(calculate("10","0") == 2);
Test.expect(calculate("101","10") == 7);
parseInt and some Math functions are disabled.

Those Math functions are enabled: pow,round,random
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
public class Kata{
  public static int Calculate(string num1, string num2) {
    
    double ConvertString(string str) {
    var idx = 0;
    double result = 0;
    char[] temp = str.ToCharArray();
    for (var i = temp.Length - 1; i >= 0; i--)
    {
        if (temp[idx++] == '1')
            result += Math.Pow(2, i);
    }
    return result;
}
    
    return (int)(ConvertString(num1) + ConvertString(num2));
}
}

//****************Sample Test****************
namespace Solution 
{
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual(2, Kata.Calculate("1", "1"));
      Assert.AreEqual(4, Kata.Calculate("10", "10"));
      Assert.AreEqual(2, Kata.Calculate("10", "0"));
      Assert.AreEqual(3, Kata.Calculate("10", "1"));
      Assert.AreEqual(6, Kata.Calculate("101", "1"));
      Assert.AreEqual(7, Kata.Calculate("101", "10"));
    }
    
    [Test]
    public void AntiCheatingTest()
    {
      Assert.IsFalse(CheatingPrevention.CheatingDetection(), "You are not allowed to use the \"Convert.To\"-Methods!");
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      for(int i=0;i<10;i++)
      {
        var n1 = rand.Next(0, 200);
        var n2 = rand.Next(0, 200);

        Assert.AreEqual(n1 + n2, Kata.Calculate(Convert.ToString(n1, 2), Convert.ToString(n2, 2)));
      }
    }
  }
}
