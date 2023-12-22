/*Challenge link:https://www.codewars.com/kata/5612a42e746aa62de100001a/train/csharp
Question:
The following formula is called the Decibel Scale:

Decibel Scale Formula
//see image in link

The Decibel Scale is used to determine the loudness of a sound, measured in dB:

β is the result we want, defined in dB;
We multiply the result of the logarithmic operation by 10, otherwise it'll be called "Bel Scale";
We provide I, the intensity of the sound wave we need to find the loudness of, which is, for the purposes of this Kata, measured in 2D space and, hence, in Watts per square meter;
Finally, we divide the intensity by the threshold of human hearing, also measured in Watts per square meter. This is the softest possible sound a human ear can hear;
Since the threshold of human hearing involves an extremely small, long number, we need to utilize a logarithmic operation that will provide us the result in a convenient way.
Your task is to simply calculate the loudness of a sound wave, given its intensity as a parameter to the dBScale/db_scale function.

Results are automatically rounded to the nearest integer by the test cases.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression 

//apply formula
using static System.Math;

public static class Kata{
  public static double DbScale(double i) =>
    10 * Log((i / Pow(10,-12)), 10);
}

//solution 2
using System;

public static class Kata
{
  public static double DbScale(double intensity)
  {
    double answer = 10 * Math.Log10(intensity/1e-12);
    return answer;
    
  }
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;

  public static class Solution
  {
    public static double DbScale(double intensity) =>
      10 * Math.Log10(intensity/1e-12);
  }

  [TestFixture]
  public class BasicTest
  {
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        yield return new TestCaseData(1e-12).Returns(0);
        yield return new TestCaseData(1e-9).Returns(30);
        yield return new TestCaseData(1e-5).Returns(70);
        yield return new TestCaseData(10).Returns(130);
        yield return new TestCaseData(100).Returns(140);
        yield return new TestCaseData(10000).Returns(160);
        yield return new TestCaseData(2.48794569 * 1e+173).Returns(1854);
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public double Test(double intensity) =>
      Math.Round(Kata.DbScale(intensity), MidpointRounding.AwayFromZero);
  }

  [TestFixture]
  public class RandomTest
  {
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        const int Tests = 100;
        Random rnd = new Random();
        
        for (int i = 0; i < Tests; ++i)
        {
          double intensity = rnd.NextDouble() * (1e-9 - 1e-12) + 1e-12;
          double expected = Math.Round(Solution.DbScale(intensity));
          
          yield return new TestCaseData(intensity).Returns(expected);
        }
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public double Test(double intensity) =>
      Math.Round(Kata.DbScale(intensity), MidpointRounding.AwayFromZero);
  }
}
