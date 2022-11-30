/*Challenge link:https://www.codewars.com/kata/52f3149496de55aded000410/train/csharp
Question:
Write a function named sumDigits which takes a number as input and returns the sum of the absolute value of each of the number's decimal digits.

For example: (Input --> Output)

10 --> 1
99 --> 18
-32 --> 5
Let's assume that all numbers in the input will be integer values.
*/

//***************Solution********************

//solution 1
//the absolute value of number is equal to n
//while n is not 0, add the digit to the sum
//divide the number by 10 to get the next digit
//return the result.
using System;
public class Kata{
  public static int SumDigits(int number){
    
    int n = Math.Abs(number), sum = 0;
    
    while (n != 0){
    sum += n % 10;
    n /= 10;
    }
    
    return sum;
  }
}

//solution 2
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;

public class Kata
{
  public static int SumDigits(int number) => Math.Abs(number).ToString().Select(x=>int.Parse(x.ToString())).Sum();
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;

  [TestFixture]
  public class Fixed_Tests
  {
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        yield return new TestCaseData(10).Returns(1);
        yield return new TestCaseData(99).Returns(18);
        yield return new TestCaseData(-32).Returns(5);
        yield return new TestCaseData(1234567890).Returns(45);
        yield return new TestCaseData(0).Returns(0);
        yield return new TestCaseData(666).Returns(18);
        yield return new TestCaseData(100000002).Returns(3);
        yield return new TestCaseData(800000009).Returns(17);
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public int FixedTest(int number) => Kata.SumDigits(number);
  }
  
  [TestFixture]
  public class Random_Tests
  {
    private static Random rnd = new Random();
    
    private static int SumDigits(int number)
    {
      // Recursive base case
      if (number == 0) { return 0; }
      
      // If number is negative, make it positive
      number = Math.Abs(number);
      
      // Return the last digit of number + last digit of number / 10 + so on and so on...
      return (number % 10) + SumDigits(number / 10);
    }
    
    [Test, Description("Random Tests")]
    public void RandomTests()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        int test = rnd.Next();
        if (rnd.Next(0, 2) == 0) { test *= -1; }
        
        int expected = SumDigits(test);
        int actual = Kata.SumDigits(test);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
