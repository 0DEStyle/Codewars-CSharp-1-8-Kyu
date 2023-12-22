/*Challenge link:https://www.codewars.com/kata/55edaba99da3a9c84000003b/train/csharp
Question:
Complete the function which takes two arguments and returns all numbers which are divisible by the given divisor. First argument is an array of numbers and the second is the divisor.

Example(Input1, Input2 --> Output)
[1, 2, 3, 4, 5, 6], 2 --> [2, 4, 6]
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//from the array numbers, loop through each element, check if element mod divisor is 0
//if true, add to array.
using System.Linq;

public class Kata{
  public static int[] DivisibleBy(int[] numbers, int divisor) => numbers.Where(x => x % divisor == 0).ToArray();
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

[TestFixture]
public class Tests
{
  [Test]
  [TestCase(new int[]{1,2,3,4,5,6}, 2, ExpectedResult=new int[]{2,4,6})]
  [TestCase(new int[]{1,2,3,4,5,6}, 3, ExpectedResult=new int[]{3,6})]
  [TestCase(new int[]{0,1,2,3,4,5,6}, 4, ExpectedResult=new int[]{0,4})]
  public static int[] FixedTest(int[] numbers, int divisor)
  {
    return Kata.DivisibleBy(numbers, divisor);
  }
  
  private static Random rnd = new Random();
  
  [Test, Description("Random Tests")]
  public static void RandomTest()
  {
    const int Tests = 1000;
    
    for (int i = 0; i < Tests; ++i)
    {
      int divisor = rnd.Next(1, 11);
      int[] numbers = new int[rnd.Next(10, 101)].Select(_ => rnd.Next(1, 1001)).ToArray();
      
      int[] expected = Solution(numbers, divisor);
      int[] actual = Kata.DivisibleBy(numbers, divisor);
      
      Assert.AreEqual(expected, actual);
    }
  }
  
  private static int[] Solution(int[] numbers, int divisor)
  {
    return new List<int>(numbers).Where(x => x % divisor == 0).ToArray();
  }
}
