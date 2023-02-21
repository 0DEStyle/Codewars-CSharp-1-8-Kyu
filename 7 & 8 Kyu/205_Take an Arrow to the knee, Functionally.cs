/*Challenge link:https://www.codewars.com/kata/559f3123e66a7204f000009f/train/csharp
Question:
Arrow style Functions
Come here to practice the Arrow style functions Not much else to say good luck!
Details
You will be given an array of numbers which can be used using the String.fromCharCode() (JS), Tools.FromCharCode() (C#) method to convert the number to a character. It is recommended to map over the array of numbers and convert each number to the corresponding ascii character.

Examples
These are example of how to convert a number to an ascii Character:
Javascript => String.fromCharCode(97) // a
C# => Tools.FromCharCode(97) // a

Reference: https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Functions/Arrow_functions 
*/

//***************Solution********************
//convert elements in arr[] to char, then join the elements together to make a string, convert to array and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;

public class Kata{
  public static string ArrowFunc(int[] arr) => string.Join("", arr.Select(x => (char)(x)).ToArray());
}

//solution 2
using System;
using System.Linq;

public class Kata
{
  public static string ArrowFunc(int[] arr)
  {
    return string.Concat(arr.Select(n => (char)n));
  }
}
//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test
{
  [Test]
  public static void FixedTests()
  {
    Assert.AreEqual("Test", Kata.ArrowFunc(new int[]{84,101,115,116}));
    Assert.AreEqual("FUS ROH DAH", Kata.ArrowFunc(new int[]{70,85,83,32,82,79,72,32,68,65,72}));
  }
  
  [Test]
  public static void RandomTest()
  {
    Random r = new Random();
    for(int i = 0; i < 100; i++)
    {
      int[] randomArray = GetRandomIntArray(r.Next(9)+1);
      Assert.AreEqual(Solution(randomArray), Kata.ArrowFunc(randomArray));
    }
  }
  
  private static int[] GetRandomIntArray(int len)
  {
    List<int> ints = new List<int>();
    Random r = new Random();
    for(int i = 0; i < len; i++)
    {
      ints.Add(r.Next(100));
    }
    return ints.ToArray();
  }
  
  private static string Solution(int[] arr)
  {
    return string.Join("", arr.Select(x => Tools.FromCharCode(x)).ToArray());
  }
}
