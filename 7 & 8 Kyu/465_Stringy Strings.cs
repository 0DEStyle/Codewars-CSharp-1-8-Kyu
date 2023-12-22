/*Challenge link:https://www.codewars.com/kata/563b74ddd19a3ad462000054/train/csharp
Question:
write me a function stringy that takes a size and returns a string of alternating 1s and 0s.

the string should start with a 1.

a string with size 6 should return :'101010'.

with size 4 should return : '1010'.

with size 12 should return : '101010101010'.

The size will always be positive and will only use whole numbers.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//create range start from 0, count up to size.
//x is current element, generate result with x + 1 mod 2
//then concat the elements and return the string as result.
using System.Linq;
public class Kata{
  public static string Stringy(int size) => string.Concat(Enumerable.Range(0, size).Select(x => (x + 1) % 2));
}

//solution 2
using System.Text.RegularExpressions;
public class Kata
{
  public static string Stringy(int size)
  {
    return Regex.Replace(new string('1',size),"11","10");
  }
}
//****************Sample Test*****************
using NUnit.Framework;
using System;

[TestFixture]
public class Tests
{
  [Test]
  [TestCase(1, ExpectedResult="1")]
  [TestCase(2, ExpectedResult="10")]
  [TestCase(10, ExpectedResult="1010101010")]
  public static string FixedTest(int size)
  {
    return Kata.Stringy(size);
  }
  
  private static string Solution(int size)
  {
    bool one = true;
    string str = string.Empty;
    for(int i = 0; i < size; i++)
    {
      str += one ? "1" : "0";
      one = !one;
    }
    return str;
  }
  
  [Test]
  public static void RandomTest([Random(1,100,100)]int size)
  {
    Assert.AreEqual(Solution(size), Kata.Stringy(size), string.Format("Should work for {0}", size));
  }
}
