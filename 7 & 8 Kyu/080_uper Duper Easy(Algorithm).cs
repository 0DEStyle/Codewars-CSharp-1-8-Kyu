/*Challenge link:https://www.codewars.com/kata/55a5bfaa756cfede78000026/train/csharp
Question:
Make a function that returns the value multiplied by 50 and increased by 6. If the value entered is a string it should return "Error".

Note: in C#, you'll always get the input as a string, so the above applies if the string isn't representing a double value.


*/

//***************Solution********************
//try convert string to double, if success, apply algorithm and return as a string, else return "Error"
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
public class Kata
{
  public static string Problem(String a) => Double.TryParse(a,out var num) ? (num *50 + 6).ToString() : "Error";
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class EasyTests {

    [Test]
    public void Test1() {
      Assert.AreEqual("Error", Kata.Problem("hello"));
      Assert.AreEqual("56", Kata.Problem("1"));
      Assert.AreEqual("256", Kata.Problem("5"));
      Assert.AreEqual("6", Kata.Problem("0"));
      Assert.AreEqual("66", Kata.Problem("1.2"));
    }
    
    [Test]
    public void Randoms() {
      Console.WriteLine("***Random tests");
      var i = 0;
      var rand = new Random();
      while (i < 50){
        var num = rand.Next(0, i+1);
        var expected = (num*50+6).ToString();
        Assert.AreEqual(expected, Kata.Problem(num.ToString()));
        i++;
      }
    }
}
