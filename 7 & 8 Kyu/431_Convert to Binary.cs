/*Challenge link:https://www.codewars.com/kata/59fca81a5712f9fa4700159a/train/csharp
Question:
Task Overview
Given a non-negative integer n, write a function to_binary/ToBinary which returns that number in a binary format.

Documentation:
Kata.ToBinary Method (Int32)
Returns the binary representation of a non-negative integer as an integer.

Syntax

public static int ToBinary(
int n
  )

Parameters
n
Type: System.Int32
The integer to convert.

Return Value
Type: System.Int32
The binary representation of the argument as an integer.
to_binary(1)  /* should return 1 */
to_binary(5)  /* should return 101 */
to_binary(11) /* should return 1011 */
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression
using System;

public static class Kata{
  public static int ToBinary(int n) => Convert.ToInt32(Convert.ToString(n, 2));
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;

  [TestFixture]
  public class BasicTests
  {
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        yield return new TestCaseData(1).Returns(1)
                                        .SetDescription("Arguments: (n: 1)\n      Expected: 1");
        yield return new TestCaseData(2).Returns(10)
                                        .SetDescription("Arguments: (n: 2)\n      Expected: 10");
        yield return new TestCaseData(3).Returns(11)
                                        .SetDescription("Arguments: (n: 3)\n      Expected: 11");
        yield return new TestCaseData(5).Returns(101)
                                        .SetDescription("Arguments: (n: 5)\n      Expected: 101");
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public int Test(int n) =>
      Kata.ToBinary(n);
  }
  
  [TestFixture]
  public class RandomTests
  {
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        Random rnd = new Random();
      
        foreach (int n in Enumerable.Range(0, 256).OrderBy(_ => rnd.Next()))
        {
          yield return new TestCaseData(n).Returns(Int32.Parse(Convert.ToString(n, 2)))
                                          .SetDescription($"Arguments: (n: {n})\n      Expected: {Convert.ToString(n, 2)}");
        }
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public int Test(int n) =>
      Kata.ToBinary(n);
  }
}
