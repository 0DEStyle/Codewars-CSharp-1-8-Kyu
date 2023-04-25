/*Challenge link:https://www.codewars.com/kata/5803956ddb07c5c74200144e/train/csharp
Question:
Everybody knows the classic "half your age plus seven" dating rule that a lot of people follow (including myself). It's the 'recommended' age range in which to date someone.


minimum age <= your age <= maximum age

Task
Given an integer (1 <= n <= 100) representing a person's age, return their minimum and maximum age range.

This equation doesn't work when the age <= 14, so use this equation instead:

min = age - 0.10 * age
max = age + 0.10 * age
You should floor all your answers so that an integer is given instead of a float (which doesn't represent age). Return your answer in the form [min]-[max]

##Examples:

age = 27   =>   20-40
age = 5    =>   4-5
age = 17   =>   15-20
*/

//***************Solution********************
//check if age is below or equal 14, then apply formulas accordingly
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
public class Kata{
  public static string DatingRange(int age)=> age <= 14 ?
    $"{Math.Floor(age-0.10*age)}-{Math.Floor(age+0.10*age)}" :
    $"{(age/2)+7}-{(age-7)*2}";
}

//better solution
public class Kata
{
  public static string DatingRange(int age)
  {
    return age <= 14 ? $"{(int)(age - 0.10 * age)}-{(int)(age + 0.10 * age)}" : $"{age / 2 + 7}-{(age - 7) * 2}";
  }
}
//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    [Test, Description("Example Test Cases")]
    public void Test()
    {
      Assert.AreEqual("15-20", Kata.DatingRange(17));
      Assert.AreEqual("27-66", Kata.DatingRange(40));
      Assert.AreEqual("14-16", Kata.DatingRange(15));
      Assert.AreEqual("24-56", Kata.DatingRange(35));
      Assert.AreEqual("9-11", Kata.DatingRange(10));
    }

    [Test, Description("Basic Test Cases")]
    public void BasicTest()
    {
      Assert.AreEqual("33-92", Kata.DatingRange(53));
      Assert.AreEqual("16-24", Kata.DatingRange(19));
      Assert.AreEqual("10-13", Kata.DatingRange(12));
      Assert.AreEqual("6-7", Kata.DatingRange(7));
      Assert.AreEqual("23-52", Kata.DatingRange(33));
    }
    
    private static Random rnd = new Random();
    
    private static string solution(int age)
    {
      double min, max;
      
      if (age <= 14)
      {
        min = Math.Floor(age * 0.9);
        max = Math.Floor(age * 1.1);
      }
      else
      {
        min = age / 2 + 7;
        max = 2 * (age - 7);
      }
      
      return $"{min}-{max}";
    }
    
    [Test, Description("Random Test Cases")]
    public void RandomTest()
    {
      const int Tests = 1000;
      
      for (int i = 0; i < Tests; ++i)
      {
        int age = rnd.Next(1, 101);
        
        string expected = solution(age);
        string actual = Kata.DatingRange(age);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
