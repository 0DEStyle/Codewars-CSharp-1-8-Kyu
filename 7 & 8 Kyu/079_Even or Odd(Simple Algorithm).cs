/*Challenge link:https://www.codewars.com/kata/53da3dbb4a5168369a0000fe/train/csharp
Question:
Create a function that takes an integer as an argument and returns "Even" for even numbers or "Odd" for odd numbers.


*/

//***************Solution********************
//check remainder, if 0, return even, else return odd
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

namespace Solution
{
  public class SolutionClass{
    public static string EvenOrOdd(int number) => number % 2 == 0 ? "Even" : "Odd";
  }
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

namespace Solution
{
  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void BasicTest()
    {
      Assert.AreEqual("Even", SolutionClass.EvenOrOdd(2));
      Assert.AreEqual("Odd", SolutionClass.EvenOrOdd(1));
      Assert.AreEqual("Even", SolutionClass.EvenOrOdd(0));
      Assert.AreEqual("Odd", SolutionClass.EvenOrOdd(7));
      Assert.AreEqual("Odd", SolutionClass.EvenOrOdd(-1));
    }
    
    [Test]
    public void AdditionalTest()
    {
      Assert.AreEqual("Even", SolutionClass.EvenOrOdd(1545452));
      Assert.AreEqual("Odd", SolutionClass.EvenOrOdd(17));
      Assert.AreEqual("Even", SolutionClass.EvenOrOdd(78));
      Assert.AreEqual("Odd", SolutionClass.EvenOrOdd(74156741));
      Assert.AreEqual("Odd", SolutionClass.EvenOrOdd(-123));
      Assert.AreEqual("Even", SolutionClass.EvenOrOdd(-456));
    }
  }
}
