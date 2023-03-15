/*Challenge link:https://www.codewars.com/kata/55b051fac50a3292a9000025/train/csharp
Question:
Filter the number
Oh, no! The number has been mixed up with the text. Your goal is to retrieve the number from the text, can you return the number back to its original state?

Task
Your task is to return a number from a string.

Details
You will be given a string of numbers and letters mixed up, you have to return all the numbers in that string in the order they occur.
*/

//***************Solution********************
//select all digit character, convert to array, then convert to string, and convert to int.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;
public class Kata{
  public static int FilterString(string s) => int.Parse(new String(s.Where(Char.IsDigit).ToArray()));
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class Tests
{
  [Test]
  public static void FixedTests()
  {
    Assert.AreEqual(123, Kata.FilterString("123"), "Just return the numbers");
    Assert.AreEqual(123, Kata.FilterString("a1b2c3"), "Just return the numbers");
    Assert.AreEqual(123, Kata.FilterString("aa1bb2cc3dd"), "Just return the numbers");
  }
  
  [Test]
   public static void RandomTests()
  {
    for(int i=0; i<50;i++){
      string a = System.Guid.NewGuid().ToString().Substring(0, 8);
      Assert.AreEqual(fs(a), Kata.FilterString(a), "Just return the numbers");
    }
  }
  
  public static int fs(string s)
  {
    string str = "";
    foreach(char c in s)
    {
       if(Char.IsDigit(c))
         str += c;
    }
    return int.Parse(str);
  }
}
