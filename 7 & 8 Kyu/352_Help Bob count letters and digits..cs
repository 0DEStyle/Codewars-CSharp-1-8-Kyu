/*Challenge link:https://www.codewars.com/kata/5738f5ea9545204cec000155/train/csharp
Question:
Bob is a lazy man.

He needs you to create a method that can determine how many letters (both uppercase and lowercase ASCII letters) and digits are in a given string.

Example:

"hel2!lo" --> 6

"wicked .. !" --> 6

"!?..A" --> 1
*/

//***************Solution********************
//count if character is  either letter and digit
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public static class Kata{
        public static int CountLettersAndDigits(string input) => input.Count(x=> char.IsLetter(x) || char.IsDigit(x));
    }

//method 2
using System.Linq;

public class Kata
{
  public static int CountLettersAndDigits(string input) => input.Count(char.IsLetterOrDigit);
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class Helper
{
	[Test]
  public void Test1()
  {
   Assert.AreEqual(7,Kata.CountLettersAndDigits("n!!ice!!123"));
  }
  
  [Test]
  public void Test2()
  {
   Assert.AreEqual(8,Kata.CountLettersAndDigits("de?=?=tttes!!t"));
  }

  [Test]
  public void Test3()
  {
    Assert.AreEqual(1,Kata.CountLettersAndDigits("1"));
  }
  [Test]
  public void Test4()
  {
    Assert.AreEqual(0,Kata.CountLettersAndDigits("?"));
  }
  [Test]
  public void Test5()
  {
    Assert.AreEqual(10,Kata.CountLettersAndDigits("12345f%%%t5t&/6"));
  }

  
}
