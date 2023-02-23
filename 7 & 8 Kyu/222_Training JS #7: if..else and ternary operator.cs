/*Challenge link:https://www.codewars.com/kata/57202aefe8d6c514300001fd/train/csharp
Question:
In JavaScript, if..else is the most basic conditional statement, it consists of three parts:condition, statement1, statement2, like this:

if (condition) { doThis(); } 
else           { doThat(); } // Note: This code is valid with or without brackets, but it is strongly recommended to use brackets.
It means that if the condition is true, then execute the statementa, otherwise execute the statementb. If the statementa or statementb are more than one line, you need to add { and } at the head and tail of statements in JS, to keep the same indentation on Python and to put an end in Ruby where it indeed ends.

For example, if we want to judge whether a number is odd or even, we can write code like this:

public static string OddEven(int n)
{
  if (n % 2 == 0) { return "even number"; }
  else            { return "odd number"; }
}
If there is more than one condition to judge, we can use the compound if...else statement. For example:

public static string OldYoung(int age)
{
  if (age < 16)      { return "children"; }
  else if (age < 50) { return "young man"; } // use "else if" if needed
  else               { return "old man"; }
}
This function returns a different value depending on the parameter age.

Looks very complicated? Well, JS and Ruby also support the ternary operator and Python has something similar too:

condition ? DoThis() : DoThat();
Condition and statement separated by "?", different statement separated by ":" in both Ruby and JS; in Python you put the condition in the middle of two alternatives. The two examples above can be simplified with ternary operator:

public static int OldYoung(int age)
{
  return age < 16 ? "children" : age < 50 ? "young man" : "old man";
}
Task:
Complete function saleHotdogs/SaleHotDogs/sale_hotdogs, function accepts 1 parameter:n, n is the number of hotdogs a customer will buy, different numbers have different prices (refer to the following table), return how much money will the customer spend to buy that number of hotdogs.

number of hotdogs	price per unit (cents)
n < 5	100
n >= 5 and n < 10	95
n >= 10	90
You can use if..else or ternary operator to complete it.

When you have finished the work, click "Run Tests" to see if your code is working properly.

In the end, click "Submit" to submit your code and pass this kata.
*/

//***************Solution********************
//apply algorithm
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Kata{
  public static int SaleHotDogs(int n) => n < 5 ? n * 100 : n >= 5 && n < 10 ? n * 95 : n * 90;
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;

  [TestFixture]
  public class SolutionTest
  {
    private static bool advertisement = ((Func<bool>)(() => 
    { 
      Console.WriteLine("<font size=4><b>Thank you for attempting my Kata in C# :)</b></font>");
      Console.WriteLine("<font size=4><b>After you submit your solution, <font color='yellow'>DON'T FORGET UPVOTE & RANK THIS KATA, THANK YOU!</b></font>");
      Console.WriteLine("<img alt=\"C# (Mono) Logo\" width=\"100px\" src=\"https://developer.fedoraproject.org/static/logo/csharp.png\" />");
      return true; 
    }))();
    
    private static IEnumerable<TestCaseData> neededForGlobalLoggingNUnitOnCWIsTheHackiestThing 
    { 
      get 
      { 
        yield return new TestCaseData(1).Returns(100);
        yield return new TestCaseData(4).Returns(400); 
        yield return new TestCaseData(5).Returns(475); 
        yield return new TestCaseData(9).Returns(855); 
        yield return new TestCaseData(10).Returns(900); 
        yield return new TestCaseData(100).Returns(9000); 
      } 
    }

    [Test, TestCaseSource("neededForGlobalLoggingNUnitOnCWIsTheHackiestThing")]
    public int SampleTest(int n) => Kata.SaleHotDogs(n);
    
    private static Random rnd = new Random();
    
    private static int solution(int n) => n < 5 ? n * 100 : n < 10 ? n * 95 : n * 90;
    
    [Test]
    public void RandomTest()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        int n = rnd.Next(1, 30);
        
        int expected = solution(n);
        int actual = Kata.SaleHotDogs(n);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
