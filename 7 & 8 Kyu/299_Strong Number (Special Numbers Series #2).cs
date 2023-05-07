/*Challenge link:https://www.codewars.com/kata/5a4d303f880385399b000001/train/csharp
Question:
Definition
Strong number is the number that the sum of the factorial of its digits is equal to number itself.

For example, 145 is strong, since 1! + 4! + 5! = 1 + 24 + 120 = 145.

Task
Given a number, Find if it is Strong or not and return either "STRONG!!!!" or "Not Strong !!".

Notes
Number passed is always Positive.
Return the result as String
Input >> Output Examples
strong_num(1) ==> return "STRONG!!!!"
Since, the sum of its digits' factorial (1) is equal to number itself, then its a Strong.

strong_num(123) ==> return "Not Strong !!"
Since the sum of its digits' factorial of 1! + 2! + 3! = 9 is not equal to number itself, then it's Not Strong .

strong_num(2)  ==>  return "STRONG!!!!"
Since the sum of its digits' factorial of 2! = 2 is equal to number itself, then its a Strong.

strong_num(150) ==> return "Not Strong !!"
Since the sum of its digits' factorial of 1! + 5! + 0! = 122 is not equal to number itself, Then it's Not Strong .

Playing with Numbers Series
Playing With Lists/Arrays Series
For More Enjoyable Katas
ALL translations are welcomed
Enjoy Learning !!
Zizou
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;
using System.Collections.Generic;
class Kata{
    public static string StrongNumber(int num) => 
     GetIntArray(num).Sum(x => fac(int.Parse(x.ToString()))) == num ? "STRONG!!!!" : "Not Strong !!";
  
    //split int
    static int[] GetIntArray(int num){
    List<int> listOfInts = new List<int>();
    while(num > 0){
        listOfInts.Add(num % 10);
        num = num / 10;
    }
    listOfInts.Reverse();
    return listOfInts.ToArray();
    }
    
    //factorial
    static int fac (int n)=> (n == 1 || n == 0) ? 1 : n * fac(n - 1);
}

//better solution!!!
using System.Linq;

class Kata
{
  private static int Factorial(int n) => n == 0 ? 1 : n * Factorial(n - 1);
  
  public static string StrongNumber(int number)
  {
      return number == number.ToString().Sum(n => Factorial(int.Parse(n.ToString())))
          ? "STRONG!!!!"
          : "Not Strong !!";
  }
}

//****************Sample Test*****************
using System;
using System.Linq;
using NUnit.Framework;

[TestFixture]
class Tests
{
    [TestCase(1, "STRONG!!!!")]
    [TestCase(2, "STRONG!!!!")]
    [TestCase(145, "STRONG!!!!")]
    [TestCase(7, "Not Strong !!")]
    [TestCase(93, "Not Strong !!")]
    [TestCase(185, "Not Strong !!")]
    public void BasicTests(int input, string expected)
    {
        Assert.That(Kata.StrongNumber(input), Is.EqualTo(expected));
    }
    [Test]
    public void RandomTests()
    {
        var rnd = new Random();
        for (int i = 0; i < 100; i++)
        {
            var input = rnd.Next(1, 10000);
            var expected = SolutionStrongNumber(input);
            Assert.That(Kata.StrongNumber(input), Is.EqualTo(expected));
        }
    }
    static string SolutionStrongNumber(int number)
    {
        var s = number.ToString().Select(x => Convert.ToInt32(x) - '0').ToArray();
        return SumUp(s) == number ? "STRONG!!!!" : "Not Strong !!";
    }

    static int SumUp(int[] s, int sum = 0)
    {
        if (s.Length == 0) return sum;
        return SumUp(s.Skip(1).ToArray(), sum += Fac(s.First()));
    }

    static int Fac(int n, int sum = 1)
    {
        if (n == 0) return sum;
        sum *= n--;
        return Fac(n, sum);
    }
}
