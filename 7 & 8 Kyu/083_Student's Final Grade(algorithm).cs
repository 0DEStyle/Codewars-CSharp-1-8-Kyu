/*Challenge link:https://www.codewars.com/kata/5ad0d8356165e63c140014d4/train/csharp
Question:
Create a function finalGrade, which calculates the final grade of a student depending on two parameters: a grade for the exam and a number of completed projects.

This function should take two arguments: exam - grade for exam (from 0 to 100); projects - number of completed projects (from 0 and above);

This function should return a number (final grade). There are four types of final grades:

100, if a grade for the exam is more than 90 or if a number of completed projects more than 10.
90, if a grade for the exam is more than 75 and if a number of completed projects is minimum 5.
75, if a grade for the exam is more than 50 and if a number of completed projects is minimum 2.
0, in other cases
Examples(Inputs-->Output):

100, 12 --> 100
99, 0 --> 100
10, 15 --> 100

85, 5 --> 90

55, 3 --> 75

55, 0 --> 0
20, 2 --> 0
*Use Comparison and Logical Operators.


*/

//***************Solution********************
//apply conditions using ternary operator 
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
namespace Solution {
  public class Kata{
    public static int FinalGrade(int exam, int projects) =>
      exam > 90 || projects > 10 ? 100 : 
      exam > 75 && projects >= 5 ? 90 :
      exam > 50 && projects >= 2 ? 75 : 0;
  }
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class Testing
  {
    private int solution(int a, int b) {
      if (a > 90 || b > 10) return 100;
      if (a > 75 && b >= 5) return 90;
      if (a > 50 && b >= 2) return 75;
      return 0;
    }

    [Test]
    public void FinalGradeTest()
    {
//       Assert.AreEqual(100, Kata.FinalGrade(100, 12));
//       Assert.AreEqual(90, Kata.FinalGrade(85, 5));
//       Assert.AreEqual(100, Kata.FinalGrade(99, 0));
//       Assert.AreEqual(100, Kata.FinalGrade(10, 15));
//       Assert.AreEqual(90, Kata.FinalGrade(85, 5));
//       Assert.AreEqual(75, Kata.FinalGrade(55, 3));
//       Assert.AreEqual(0, Kata.FinalGrade(55, 0));
//       Assert.AreEqual(0, Kata.FinalGrade(20, 2));
      for (int e = 0; e <= 100; e++)
        for (int p = 0; p <= 11; p++)
          Assert.AreEqual(solution(e, p), Kata.FinalGrade(e, p),
           $"exam = {e}, projects = {p}");
      
      Random rnd = new Random();
      for (var i = 0; i < 100; i++) {
        var a = rnd.Next(0, 100);
        var b = rnd.Next(0, 20);
        Assert.AreEqual(solution(a, b), Kata.FinalGrade(a, b)); 
      }
    }
  }
}
