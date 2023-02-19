/*Challenge link:https://www.codewars.com/kata/5545f109004975ea66000086/train/csharp
Question:
Create a function that checks if a number n is divisible by two numbers x AND y. All inputs are positive, non-zero numbers.

Examples:
1) n =   3, x = 1, y = 3 =>  true because   3 is divisible by 1 and 3
2) n =  12, x = 2, y = 6 =>  true because  12 is divisible by 2 and 6
3) n = 100, x = 5, y = 3 => false because 100 is not divisible by 3
4) n =  12, x = 7, y = 5 => false because  12 is neither divisible by 7 nor 5
*/

//***************Solution********************
//check if remainder is 0, return bool result accordingly
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

public class DivisibleNb {
	public static bool IsDivisible(int n, int x, int y) =>  n%x==0 && n%y==0;
}

//****************Sample Test*****************
using System;
using System.Reflection;
using NUnit.Framework;

[TestFixture]
public class DivisibleNbTests {

    [Test]
    public void Test1() {
        Assertion(true, (12, 4, 3));
    }
    [Test]
    public void Test2() {
        Assertion(false, (3, 3, 4));
    }
    [Test]
    public void Test3() {
        Assertion(false, (8, 3, 4));
    }
    [Test]
    public void Test4() {
        Assertion(true, (48, 3, 4));
    }
    [Test]
    public void Test5() {
        Assertion(true, (100, 5, 10));
    }
    [Test]
    public void Test6() {
        Assertion(false, (100, 5, 3));
    }
    [Test]
    public void Test7() {
        Assertion(true, (4, 4, 2));
    }
    [Test]
    public void Test8() {
        Assertion(false, (5, 2, 3));
    }
    [Test]
    public void Test9() {
        Assertion(true, (1000000, 1000000, 1000000));
    }
    [Test]
    public void Test10() {
        Assertion(false, (1, 1000000, 1000000));
    }
    [Test]
    public static void Test11() {
        Random rnd = new Random();
        for (int i = 0; i < 100; i++) {
            int n = rnd.Next(1000) + 1;
            int x = rnd.Next(10) + 1;
            int y = rnd.Next(20) + 1;
            Assertion((n % x == 0) && (n % y == 0), (n, x, y));
        }
    }
    
    private static MethodInfo UserFunction;
    
    private static void Assertion(bool expected, (int, int, int) inputs) {
      if (UserFunction == null) {
        UserFunction = GetFunction.GetIsDiv();
      }
            
      object actual = UserFunction.Invoke(null, new object[] {inputs.Item1, inputs.Item2, inputs.Item3});
      if (!(actual is bool)) Assert.Fail("Function should return a bool");
      
      Assert.AreEqual(
        expected,
        (bool)UserFunction.Invoke(null, new object[] {inputs.Item1, inputs.Item2, inputs.Item3}),
        $"n = {inputs.Item1}, x = {inputs.Item2}, y = {inputs.Item3}"
      );
      
    }
}
