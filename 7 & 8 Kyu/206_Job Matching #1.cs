/*Challenge link:https://www.codewars.com/kata/56c22c5ae8b139416c00175d/train/csharp
Question:
Let's build a matchmaking system that helps discover jobs for developers based on a number of factors.

One of the simplest, yet most important factors is compensation. As developers we know how much money we need to support our lifestyle, so we generally have a rough idea of the minimum salary we would be satisfied with.

Let's give this a try. We'll create a function match which takes a candidate and a job, which will return a boolean indicating whether the job is a valid match for the candidate.

A candidate will have a minimum salary, so it will look like this:

Candidate candidate = 
  new Candidate(MinSalary: 120000);
A job will have a maximum salary, so it will look like this:

Job job = 
  new Job(MaxSalary: 140000);
If either the candidate's minimum salary or the job's maximum salary is not present, throw an error.

For a valid match, the candidate's minimum salary must be less than or equal to the job's maximum salary. However, let's also include 10% wiggle room (deducted from the candidate's minimum salary) in case the candidate is a rockstar who enjoys programming on Codewars in their spare time. The company offering the job may be able to work something out.
*/

//***************Solution********************
//check if the inputs are null, if so, throw exception
//else return bool values to check if min salary *0.9 is less than or equal to max salary.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using StriveObjects;
using System;

public class Strive{
  public static bool Match(Candidate c, Job j) => 
    c.MinSalary == null || j.MaxSalary == null ? throw new Exception() 
    : (c.MinSalary * 0.9 <= j.MaxSalary);
}

//****************Sample Test*****************
using NUnit.Framework;
using StriveObjects;
using System.Text;
using System;

public static class Data
{
  public static Candidate Candidate1 = new Candidate(MinSalary: 120000);
  public static Candidate Candidate2 = new Candidate(MinSalary: 190000);
  public static Job Job1 = new Job(MaxSalary: 130000);
  public static Job Job2 = new Job(MaxSalary: 80000);
  public static Job Job3 = new Job(MaxSalary: 171000);
}

[TestFixture]
public class _01_ValidMatchTests
{
  [Test]
  public void Match1()
  {
    Assert.AreEqual(true, Strive.Match(Data.Candidate1,Data.Job1));
  }
  [Test]
  public void Match2()
  {
    Assert.AreEqual(true, Strive.Match(Data.Candidate1, Data.Job3));
  }
  [Test]
  public void Match3()
  {
    Assert.AreEqual(true, Strive.Match(Data.Candidate2, Data.Job3));   
  }
}

public class _02_InvalidMatchTests
{
  [Test]
  public void NotMatch1()
  {
    Assert.AreEqual(false, Strive.Match(Data.Candidate1 ,Data.Job2));
  }
  [Test]
  public void NotMatch2()
  {
    Assert.AreEqual(false, Strive.Match(Data.Candidate2, Data.Job1));
  }
  [Test]
  public void NotMatch3()
  {
    Assert.AreEqual(false, Strive.Match(Data.Candidate2, Data.Job2));
  }
}

public class _03_InvalidParameterTests
{
  [Test]
  public void Invalid1()
  {
    Assert.That(() => { Strive.Match(new Candidate(), Data.Job1); }, Throws.Exception);
  }
  
  [Test]
  public void Invalid2()
  {
    Assert.That(() => { Strive.Match(Data.Candidate1, new Job()); }, Throws.Exception);
  }
}

public class _04_RandomTests
{
  [Test]
  public void RandomBattery40()
  {
    Console.WriteLine("\n////////////////////////////" +
                    "\n// Random Test Reporting //" +
                    "\n//////////////////////////\n");
                       
    for(int i = 0; i < 40; i++)
    {
      var t = GenerateTest();
      bool userAnswer = Strive.Match(t.Item2, t.Item3);
      string reportFormat = "C: {0:000000} <-> J: {1:000000} || Expected: {2}, Returned: {3}";
      Console.WriteLine(String.Format(reportFormat, t.Item2.MinSalary, t.Item3.MaxSalary, t.Item1, userAnswer));
      Assert.AreEqual(t.Item1, userAnswer);
    }
  }
  
  private Random random = new Random();
  private Tuple<bool,Candidate,Job> GenerateTest()
  {
    int cs = (random.Next(1,100)+75) * 1000;
    int js = (random.Next(1,75)+50) * 1000;
    var c = new Candidate(MinSalary: cs);
    var j = new Job(MaxSalary: js);
    return new Tuple<bool,Candidate,Job>(cs*0.9 <= js, c, j);
  }
}
