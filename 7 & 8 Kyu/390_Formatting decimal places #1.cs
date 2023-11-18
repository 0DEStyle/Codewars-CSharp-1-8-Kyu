/*Challenge link:https://www.codewars.com/kata/5641c3f809bf31f008000042/train/csharp
Question:
Each floating-point number should be formatted that only the first two decimal places are returned. You don't need to check whether the input is a valid number because only valid numbers are used in the tests.

Don't round the numbers! Just cut them after two decimal places!

Right examples:  
32.8493 is 32.84  
14.3286 is 14.32

Incorrect examples (e.g. if you round the numbers):  
32.8493 is 32.85  
14.3286 is 14.33
*/

//***************Solution********************


//Math.Truncate: The number is rounded to the nearest integer towards zero.
//so time 100 before hand to keep the 2 decimal places, then divide by 100 afterward.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;

public class Numbers{
  public static double TwoDecimalPlaces(double number) => Math.Truncate(number * 100) / 100;
}

//solution 2
public class Numbers
{
  public static double TwoDecimalPlaces(double number)
  {
    return (int) (number * 100) / 100D;
  }
}
//solution 3
using static System.Math;

public class Numbers
{
    public static double TwoDecimalPlaces(double number)
    {
        return Truncate(number * 100) / 100f;
    }
}
//solution 4
using System;
using System.Text;

public class Numbers
{
  public static double TwoDecimalPlaces(double number)
  {
    return Math.Round(number, 2, MidpointRounding.ToZero);
  }
}

//solution 5
using System;
using System.Text;

public class Numbers
{
  public static double TwoDecimalPlaces(double number)
  {
    return Math.Round(number - Math.Sign(number)*0.005, 2);
  }
}
//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Text;
  
[TestFixture]
public class NumbersTest
{
  [Test]
  public void Test_01()
  {
    Assert.AreEqual(10.12, Numbers.TwoDecimalPlaces(10.1289767789));
  }

  [Test]
  public void Test_Negative_02()
  {
    Assert.AreEqual(-7488.83, Numbers.TwoDecimalPlaces(-7488.83485834983));
  }
  
  [Test]
  public void Test_Random_03([Random(-2837823.73748453445, 2837823.73748453445, 98)]double number)
  {
    Assert.AreEqual(this.TwoDecimalPlaces(number), Numbers.TwoDecimalPlaces(number));
  }
  
  private double TwoDecimalPlaces(double number)
  {
    char[] input = (number.ToString()).ToCharArray();
    StringBuilder ShortenedNumber = new StringBuilder();
    for (int i = 0; i < input.Length; i++)
    {
      if (input[i] == '.')
      {
        for (int a = 0; a < i + 3; a++)
        {
          ShortenedNumber.Append(input[a]);
        }
        break;
      }
    }
    return Double.Parse(ShortenedNumber.ToString());
  }
}
