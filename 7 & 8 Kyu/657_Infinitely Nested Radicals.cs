/*Challenge link:https://www.codewars.com/kata/5af2b240d2ee2764420000a2/train/csharp
Question:
Hello,

I am Jomo Pipi

and today we will be evaluating an expression like this:

(there are an infinite number of radicals)

 
​
//see formula in link

for a given value x

Simple!

arguments passed in will be 1 or greater
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class JomoPipi { 
  public static double evaluateFunction(int x) => (1 + System.Math.Sqrt(1 + 4.0 * x)) * 0.5;
}

//method 2
using System;
public class JomoPipi {
  public static double evaluateFunction(int x) {
  
    var result = Math.Sqrt(x);
    
    for(int i = 0; i < 100; i++)
      result = Math.Sqrt(result + x);
    return result;
  }
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Numerics;
  // TODO: Replace examples and use TDD development by writing your own tests


[TestFixture]
public class SolutionTest {
    private static double answer(int x) {
        return Math.Sqrt(x+.25)+.5;
    }
    [Test]
    public void testbasic() {
        Assert.AreEqual(2.0, JomoPipi.evaluateFunction(2), 0.000000001);
        Assert.AreEqual(3.0, JomoPipi.evaluateFunction(6), 0.000000001);
        Assert.AreEqual(4.0, JomoPipi.evaluateFunction(12), 0.000000001);
    }
    [Test]
    public void randomInts() {
        for (int i = 0; i < 1000000; i++){
          Random rnd = new Random();
          int x = rnd.Next(1,10000);
          int y = x*(x+1);
          Assert.AreEqual(answer(y), JomoPipi.evaluateFunction(y), 0.000000001);
        }
    }
    [Test]
    public void randomNums() {
        for (int i = 0; i < 1000000; i++){
          Random rnd = new Random();
          int x = rnd.Next(1,1000000000);
          Assert.AreEqual(answer(x), JomoPipi.evaluateFunction(x), 0.000000001);
        }
    }
    [Test]
    public void goldenRatio() {
          Assert.AreEqual(answer(1), JomoPipi.evaluateFunction(1), 0.000000001);
    }
    [Test]
    public void constants() {
          Assert.AreEqual(answer(69), JomoPipi.evaluateFunction(69), 0.000000001);
          Assert.AreEqual(answer(123), JomoPipi.evaluateFunction(123), 0.000000001);
          Assert.AreEqual(answer(99), JomoPipi.evaluateFunction(99), 0.000000001);
          Assert.AreEqual(answer(1337), JomoPipi.evaluateFunction(1337), 0.000000001);
    }
}
}
