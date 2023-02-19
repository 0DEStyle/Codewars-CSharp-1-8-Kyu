/*Challenge link:https://www.codewars.com/kata/577a6e90d48e51c55e000217/train/csharp
Question:
The Collatz conjecture (also known as 3n+1 conjecture) is a conjecture that applying the following algorithm to any number we will always eventually reach one:

[This is writen in pseudocode]
if(number is even) number = number / 2
if(number is odd) number = 3*number + 1
#Task

Your task is to make a function hotpo that takes a positive n as input and returns the number of times you need to perform this algorithm to get n = 1.

#Examples

hotpo(1) returns 0
(1 is already 1)

hotpo(5) returns 5
5 -> 16 -> 8 -> 4 -> 2 -> 1

hotpo(6) returns 8
6 -> 3 -> 10 -> 5 -> 16 -> 8 -> 4 -> 2 -> 1

hotpo(23) returns 15
23 -> 70 -> 35 -> 106 -> 53 -> 160 -> 80 -> 40 -> 20 -> 10 -> 5 -> 16 -> 8 -> 4 -> 2 -> 1
*/

//***************Solution********************
//apply algorithm
//if ans is even number, n/2
//if ans is odd number, (n*3)+1
//until the ans becomes 1, increase the counter i by 1
//after the ans becomes 1, return the counter i
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Kata{
  public static uint Hotpo(uint n){
    uint ans = n, i = 0;
    while(ans != 1){
      ans = magic(ans);
      i++;
    }
    return i;
  }
  
  public static uint magic(uint n) => n%2==0 ? n/2 : (n*3)+1;
}

//recursive method
public class Kata
{
  public static uint Hotpo(uint n)
  {
    return n == 1 ? 0 : n % 2 == 0 ? Hotpo(n / 2) + 1 : Hotpo(3 * n + 1) + 1;
  }
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
    private static Random rnd = new Random();
    
    private static uint solution(uint n)
    {
      uint count = 0;
      
      while (n != 1)
      {
        if (n % 2 == 0)
        {
          n /= 2;
        }
        else
        {
          n = n * 3 + 1;
        }
        ++count;
      }
      
      return count;
    }
  
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        yield return new TestCaseData(1u).Returns(0u);
        yield return new TestCaseData(5u).Returns(5u);
        yield return new TestCaseData(6u).Returns(8u);
        yield return new TestCaseData(23u).Returns(15u);
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public uint SampleTest(uint n) => Kata.Hotpo(n);
    
    [Test, Description("Random Tests")]
    public void RandomTests()
    {
      const int Tests = 1000;
      
      for (int i = 0; i < Tests; ++i)
      {
        uint n = (uint)rnd.Next(1, 10000000);
        
        uint expected = solution(n);
        uint actual = Kata.Hotpo(n);
      }
    }
  }
}
