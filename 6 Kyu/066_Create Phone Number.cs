/*Challenge link:https://www.codewars.com/kata/525f50e3b73515a6db000b83/train/csharp
Question:
Write a function that accepts an array of 10 integers (between 0 and 9), that returns a string of those numbers in the form of a phone number.

Example
Kata.CreatePhoneNumber(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 0}) // => returns "(123) 456-7890"
The returned format must be correct in order to complete this challenge.

Don't forget the space after the closing parentheses!
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Kata{
  public static string CreatePhoneNumber(int[] n) =>
    $"({n[0]}{n[1]}{n[2]}) {n[3]}{n[4]}{n[5]}-{n[6]}{n[7]}{n[8]}{n[9]}";
}

//better solution
public class Kata
{
  public static string CreatePhoneNumber(int[] numbers)
  {
    return long.Parse(string.Concat(numbers)).ToString("(000) 000-0000");
  }
}

//more
using System.Linq;
public class Kata
{
  public static string CreatePhoneNumber(int[] numbers)
  {
    return string.Format("({0}{1}{2}) {3}{4}{5}-{6}{7}{8}{9}",numbers.Select(x=>x.ToString()).ToArray());
  }
}

//even more
using System;
using System.Text.RegularExpressions;

public class Kata
{
  public static string CreatePhoneNumber(int[] numbers) =>
    new Regex("(...)(...)(....)").Replace(String.Concat(numbers), "($1) $2-$3");
}
//****************Sample Test*****************
namespace Solution
{
  using NUnit.Framework;
  using System.Collections.Generic;
  using System;
  
  [TestFixture]
  public class Tests
  {
    [Test]
    [TestCase(new int[]{1,2,3,4,5,6,7,8,9,0}, ExpectedResult="(123) 456-7890")]
    [TestCase(new int[]{1,1,1,1,1,1,1,1,1,1}, ExpectedResult="(111) 111-1111")]
    public static string FixedTest(int[] numbers)
    {
      return Kata.CreatePhoneNumber(numbers);
    }
    
    private static string Solution(int[] numbers)
    {
      string result = "";
      for(int i = 0; i < numbers.Length; i++) 
      {
        if(i == 0) result += "(";
        result += numbers[i];
        if(i == 2) result += ") ";
        if(i == 5) result += "-";
      }
      return result;
    }
    
    [Test]
    public static void RandomTest([Random(0,9,50)]int num)
    {
      List<int> list = new List<int>();
      Random r = new Random();
      for(int i = 0; i < 10; i++) list.Add(r.Next(10));
      //list.Add(num); What was this for?
      int[] numbers = list.ToArray();
      Assert.AreEqual(Solution(numbers), Kata.CreatePhoneNumber(numbers));
    }
  }
}
