/*Challenge link:https://www.codewars.com/kata/5641a03210e973055a00000d/train/csharp
Question:
Each number should be formatted that it is rounded to two decimal places. You don't need to check whether the input is a valid number because only valid numbers are used in the tests.

Example:    
5.5589 is rounded 5.56   
3.3424 is rounded 3.34
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//round to 2dps
using static System.Math;

public class Numbers{
  public static double TwoDecimalPlaces(double n) => Round(n, 2);
}

//****************Sample Test*****************
using NUnit.Framework;
using System;

[TestFixture]
public class NumbersTest
{   
  [Test]
  public void Test_01()
  {
    Assert.AreEqual(4.66, Numbers.TwoDecimalPlaces(4.659725356));
  }
  
  [Test]
  public void Test_02()
  {
    Assert.AreEqual(173735326.38, Numbers.TwoDecimalPlaces(173735326.3783732637948948));
  }
  
  [Test]
  public void Test_Random_03([Random(-125.47658, 125.47658, 98)]double number)
  {
    Assert.AreEqual(Math.Round(number, 2), Numbers.TwoDecimalPlaces(number));
  }
}
