/*Challenge link:https://www.codewars.com/kata/5506b230a11c0aeab3000c1f/train/csharp
Question:
This program tests the life of an evaporator containing a gas.

We know the content of the evaporator (content in ml), the percentage of foam or gas lost every day (evap_per_day) and the threshold (threshold) in percentage beyond which the evaporator is no longer useful. All numbers are strictly positive.

The program reports the nth day (as an integer) on which the evaporator will be out of use.

Example:
evaporator(10, 10, 5) -> 29
Note:
Content is in fact not necessary in the body of the function "evaporator", you can use it or not use it, as you wish. Some people might prefer to reason with content, some other with percentages only. It's up to you but you must keep it as a parameter because the tests have it as an argument.
*/

//***************Solution********************
//apply algorithm
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
public class Evaporator { 
  public static int evaporator(double content, double evap_per_day, double threshold) =>
    (int)Math.Ceiling(Math.Log(threshold / 100.0) / Math.Log(1.0 - evap_per_day / 100.0));
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class EvaporatorTests {

[Test]
  public void Test1() {
    Assert.AreEqual(22, Evaporator.evaporator(10, 10, 10));
  }
[Test]
  public void Test2() {
    Assert.AreEqual(29, Evaporator.evaporator(10, 10, 5));
  }
[Test]
  public void Test3() {
    Assert.AreEqual(59, Evaporator.evaporator(100, 5, 5));
  }
[Test]
  public void Test4() {
    Assert.AreEqual(37, Evaporator.evaporator(50, 12, 1));
  }
[Test]
  public void Test5() {
    Assert.AreEqual(31, Evaporator.evaporator(47.5, 8, 8));
  }
[Test]
  public void Test6() {
    Assert.AreEqual(459, Evaporator.evaporator(100, 1, 1));
  }
[Test]
  public void Test7() {
    Assert.AreEqual(459, Evaporator.evaporator(10, 1, 1));
  }
[Test]
  public void Test8() {
    Assert.AreEqual(299, Evaporator.evaporator(100, 1, 5));
  }
}
