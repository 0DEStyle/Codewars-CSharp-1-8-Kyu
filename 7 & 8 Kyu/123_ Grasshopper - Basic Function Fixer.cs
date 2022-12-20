/*Challenge link:https://www.codewars.com/kata/56200d610758762fb0000002/train/csharp
Question:
Fix the function
I created this function to add five to any number that was passed in to it and return the new value. It doesn''t throw any errors but it returns the wrong number.

Can you help me fix the function?


*/

//***************Solution********************
//add 5 and return the result
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Kata{
  public static int AddFive(int n) => n+ 5;
}

//****************Sample Test*****************
using NUnit.Framework;
using System;

[TestFixture]
public class Tests
{
  [Test]
  [TestCase(5,ExpectedResult=10)]
  [TestCase(0,ExpectedResult=5)]
  [TestCase(-5,ExpectedResult=0)]
  public static int FixedTest(int num)
  {
    return Kata.AddFive(num);
  }
  
  [Test]
  public static void RandomTest([Random(-100,100,100)]int num)
  {
    Assert.AreEqual(num+5, Kata.AddFive(num), string.Format("Should work for {0}", num));
  }
}
