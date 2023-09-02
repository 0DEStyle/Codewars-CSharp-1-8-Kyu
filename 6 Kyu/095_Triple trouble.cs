/*Challenge link:https://www.codewars.com/kata/55d5434f269c0c3f1b000058/train/csharp
Question:
Write a function

TripleDouble(long num1, long num2)
which takes numbers num1 and num2 and returns 1 if there is a straight triple of a number at any place in num1 and also a straight double of the same number in num2.

If this isn't the case, return 0

Examples
TripleDouble(451999277, 41177722899) == 1 // num1 has straight triple 999s and 
                                          // num2 has straight double 99s

TripleDouble(1222345, 12345) == 0 // num1 has straight triple 2s but num2 has only a single 2

TripleDouble(12345, 12345) == 0

TripleDouble(666789, 12345667) == 1
*/

//***************Solution********************


//in "0123456789", if any
//number is the current element/character, convert num1 and num2 to string
//if num1 contains any current element 3 times and num2 2 times
//return 1, else 0.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System;
using System.Linq;

public class Kata{
  public static int TripleDouble(long num1, long num2) =>
    "0123456789".Any(number => num1.ToString()
                                   .Contains(new string(number, 3)) && num2.ToString()
                                   .Contains(new string(number, 2))) ? 1 : 0; 
}
//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Collections.Generic;

[TestFixture]
public class Tests
{
  [Test]
  [TestCase(451999277, 41177722899, ExpectedResult=1)]
  [TestCase(1222345, 12345, ExpectedResult=0)]
  [TestCase(12345, 12345, ExpectedResult=0)]
  [TestCase(666789, 12345667, ExpectedResult=1)]
  [TestCase(10560002, 100, ExpectedResult=1)]
  [TestCase(1112, 122, ExpectedResult=0)]
  public static int FixedTest(long s1, long s2)
  {
    return Kata.TripleDouble(s1, s2);
  }
  
  [Test]
  public static void RandomTest(
    [Random(0, 1000000000,10)] long n1,
    [Random(0, 1000000000,10)] long n2
  )
  {
    Assert.AreEqual(Sol(n1,n2),Kata.TripleDouble(n1,n2), String.Format("Should work for {0} and {1}",n1,n2));
  }
  
  private static int Sol(long num1, long num2)
  {
    string s1 = num1.ToString();
    string s2 = num2.ToString();
    int count = 1;
    int max = 0;
    List<char> memory = new List<char>();
    for(int i = 1; i < s1.Length; i++)
    {
      if(s1[i] == s1[i-1]) 
        count++;
      else 
        count = 1;
      max = count > max ? count : max;
      if(count == 3)
        memory.Add(s1[i]);
    }
    if(max < 3)
      return 0;
  
    max = 0;
    count = 1;
    for(int i = 1; i < s2.Length; i++) 
    {
      if(s2[i] == s2[i-1] && memory.Contains(s2[i]))
        count++;
      else 
        count = 1;
      max = (count > max) ? count : max;
      if(max == 2) {
        break;
      }
    }
    if(max != 2)
      return 0;
    return 1;
  }
}
