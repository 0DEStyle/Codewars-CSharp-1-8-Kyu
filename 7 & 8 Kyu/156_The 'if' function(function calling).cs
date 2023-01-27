/*Challenge link:https://www.codewars.com/kata/54147087d5c2ebe4f1000805/train/csharp
Question:
Create a function called _if which takes 3 arguments: a value bool and 2 functions (which do not take any parameters): func1 and func2

When bool is truthy, func1 should be called, otherwise call the func2.

Example:
Kata.If(true, () => Console.WriteLine("True"), () => Console.WriteLine("False"));
// write "True" to console
*/

//***************Solution********************
//if condition is true, call func1, else func2
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;

public class Kata
{
  public static void If(bool condition, Action func1, Action func2) => (condition ? func1 : func2)();
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class Tests
{ 
  [Test]
  public void TrueTest()
  {
    bool a = false;
    Kata.If(true, () => a = true, () => Assert.Fail("func2 called"));
    Assert.True(a, "func1 should be called"); 
  }
  
  [Test]
  public void FalseTest()
  {
    bool a = false;
    Kata.If(false, () => Assert.Fail("func1 called"), () => a = true);
    Assert.True(a, "func2 should be called");
  }
  
}
