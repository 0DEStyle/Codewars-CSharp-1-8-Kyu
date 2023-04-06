/*Challenge link:https://www.codewars.com/kata/5a87449ab1710171300000fd/train/csharp
Question:
Definition
A Tidy number is a number whose digits are in non-decreasing order.

Task
Given a number, Find if it is Tidy or not .

Warm-up (Highly recommended)
Playing With Numbers Series
Notes
Number passed is always Positive .

Return the result as a Boolean

Input >> Output Examples
tidyNumber (12) ==> return (true)
Explanation:
The number's digits { 1 , 2 } are in non-Decreasing Order (i.e) 1 <= 2 .

tidyNumber (32) ==> return (false)
Explanation:
The Number's Digits { 3, 2} are not in non-Decreasing Order (i.e) 3 > 2 .

tidyNumber (1024) ==> return (false)
Explanation:
The Number's Digits {1 , 0, 2, 4} are not in non-Decreasing Order as 0 <= 1 .

tidyNumber (13579) ==> return (true)
Explanation:
The number's digits {1 , 3, 5, 7, 9} are in non-Decreasing Order .

tidyNumber (2335) ==> return (true)
Explanation:
The number's digits {2 , 3, 3, 5} are in non-Decreasing Order , Note 3 <= 3


*/

//***************Solution********************
//check digit by using division of 10
//if remainder is greater tan previous number return false
//after checking all condition, return true.

class Kata{
    public static bool TidyNumber(int n){
      int prev = 10;
      
      while(n >0){
        int rem = n % 10;
        n /= 10;
        if(rem > prev)
          return false;
        prev = rem;
      }
        return true;
    }
}

//solution 2
//sort the chracter in n, then check if n itself si the same as the sorted string
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

class Kata
{
  public static bool TidyNumber(int n) => $"{n}" == string.Concat($"{n}".OrderBy(c => c));
}
//****************Sample Test*****************
using System;
using System.Linq;
using NUnit.Framework;

[TestFixture]
class Tests
{
    [TestCase(12)]
    [TestCase(2789)]
    [TestCase(2335)]
    public void BasicTestsTrue(int n)
    {
        Assert.IsTrue(Kata.TidyNumber(n));
    }
    [TestCase(102)]
    [TestCase(9672)]
    public void BasicTestsFalse(int n)
    {
        Assert.IsFalse(Kata.TidyNumber(n));
    }
    [Test]
    public void RandomTests()
    {
        var rnd = new Random();
        for (int i = 0; i < 40; i++)
        {
            var n = rnd.Next(1, 9999);
            var expected = TidyNumberSolution(n);
            Assert.That(Kata.TidyNumber(n), Is.EqualTo(expected));
        }
    }
    bool TidyNumberSolution(int n) => n == int.Parse(string.Concat(n.ToString().Select(x => Convert.ToInt32(x) - '0').OrderBy(x => x)));
}
