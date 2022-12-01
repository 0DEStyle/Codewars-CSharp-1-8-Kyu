/*Challenge link:https://www.codewars.com/kata/56fa3c5ce4d45d2a52001b3c/train/csharp
Question:
Exclusive "or" (xor) Logical Operator
Overview
In some scripting languages like PHP, there exists a logical operator (e.g. &&, ||, and, or, etc.) called the "Exclusive Or" (hence the name of this Kata). The exclusive or evaluates two booleans. It then returns true if exactly one of the two expressions are true, false otherwise. For example:

false xor false == false // since both are false
true xor false == true // exactly one of the two expressions are true
false xor true == true // exactly one of the two expressions are true
true xor true == false // Both are true.  "xor" only returns true if EXACTLY one of the two expressions evaluate to true.
Task
Since we cannot define keywords in Javascript (well, at least I don''t know how to do it), your task is to define a function xor(a, b) where a and b are the two expressions to be evaluated. Your xor function should have the behaviour described above, returning true if exactly one of the two expressions evaluate to true, false otherwise. 
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Kata{
  public static bool Xor(bool a, bool b) => a^b;
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class KataTests
  {
    [Test]
    public void BasicTests()
    {
        testing(Kata.Xor(false, false), false);
        testing(Kata.Xor(true, false), true);
        testing(Kata.Xor(false, true), true);
        testing(Kata.Xor(true, true), false);
    }
    
    [Test]
    public void NestedTests()
    {
        testing(Kata.Xor(false, Kata.Xor(false, false)), false);
        testing(Kata.Xor(Kata.Xor(true, false), false), true);
        testing(Kata.Xor(Kata.Xor(true, true), false), false);
        testing(Kata.Xor(true, Kata.Xor(true, true)), true);
        testing(Kata.Xor(Kata.Xor(false, false), Kata.Xor(false, false)), false);
        testing(Kata.Xor(Kata.Xor(false, false), Kata.Xor(false, true)), true);
        testing(Kata.Xor(Kata.Xor(true, false), Kata.Xor(false, false)), true);
        testing(Kata.Xor(Kata.Xor(true, false), Kata.Xor(true, false)), false);
        testing(Kata.Xor(Kata.Xor(true, true), Kata.Xor(true, false)), true);
        testing(Kata.Xor(Kata.Xor(true, Kata.Xor(true, true)), Kata.Xor(Kata.Xor(true, true), false)), true);
    }
    
    private static void testing(bool actual, bool expected) 
    {
        Assert.AreEqual(expected, actual);
    }
  }
}
