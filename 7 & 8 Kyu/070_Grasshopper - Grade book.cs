/*Challenge link:https://www.codewars.com/kata/55cbd4ba903825f7970000f5/train/csharp
Question:
Grade book
Complete the function so that it finds the average of the three scores passed to it and returns the letter value associated with that grade.

Numerical Score	Letter Grade
90 <= score <= 100	'A'
80 <= score < 90	'B'
70 <= score < 80	'C'
60 <= score < 70	'D'
0 <= score < 60	'F'
Tested values are all between 0 and 100. Theres is no need to check for negative values or values greater than 100.
*/

//***************Solution********************
//find average and return the corresponding result.
//can simiplfied into one line by using an Lambda expression with Enumerable methods, but it will become hard to read.

public class Kata{
  public static char GetGrade(int s1, int s2, int s3){
    int average = (s1 + s2 + s3) / 3;

    return average >= 90 && average <= 100 ? 'A' :
           average >= 80 && average < 90 ? 'B' :
           average >= 70 && average < 80 ? 'C' :
           average >= 60 && average < 70 ? 'D' :'F';
  }
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class Tests
{
  [Test]
  [TestCase(95,90,93, ExpectedResult='A')]
  [TestCase(70,70,100, ExpectedResult='B')]
  [TestCase(70,71,72, ExpectedResult='C')]
  [TestCase(65,66,60, ExpectedResult='D')]
  [TestCase(32,15,21, ExpectedResult='F')]
  public static char FixedTests(int n1, int n2, int n3)
  {
    return Kata.GetGrade(n1,n2,n3);
  }
  
  [Test]
  [TestCase(100,100,100, ExpectedResult='A')]
  [TestCase(90,90,90, ExpectedResult='A')]
  [TestCase(89,89,89, ExpectedResult='B')]
  [TestCase(80,80,80, ExpectedResult='B')]
  [TestCase(79,79,79, ExpectedResult='C')]
  [TestCase(70,70,70, ExpectedResult='C')]
  [TestCase(69,69,69, ExpectedResult='D')]
  [TestCase(60,60,60, ExpectedResult='D')]
  [TestCase(59,59,59, ExpectedResult='F')]
  [TestCase(0,0,0, ExpectedResult='F')]
  public static char SpecialTests(int n1, int n2, int n3)
  {
    return Kata.GetGrade(n1,n2,n3);
  }
  
  [Test]
  public static void RandomTests(
    [Random(0,100,10)] int n1,
    [Random(0,100,10)] int n2,
    [Random(0,100,10)] int n3
  )
  {  
    Assert.AreEqual(Solution(n1,n2,n3), Kata.GetGrade(n1,n2,n3), String.Format("Should work for {0}, {1}, {2}",n1,n2,n3));   
  }
  
  private static char Solution(int s1, int s2, int s3)
  {
    int avg = (s1 +s2 +s3) / 3;
    if(avg < 60) return 'F';
    if(avg < 70) return 'D';
    if(avg < 80) return 'C';
    if(avg < 90) return 'B';
    return 'A';
  }
}
