/*Challenge link:https://www.codewars.com/kata/590e03aef55cab099a0002e8/train/csharp
Question:
Given an input of an array of digits, return the array with each digit incremented by its position in the array: the first digit will be incremented by 1, the second digit by 2, etc. Make sure to start counting your positions from 1 ( and not 0 ).

Your result can only contain single digit numbers, so if adding a digit with its position gives you a multiple-digit number, only the last digit of the number should be returned.

Notes:
return an empty array if your array is empty
arrays will only contain numbers so don't worry about checking that
Examples:
[1, 2, 3]  -->  [2, 4, 6]   #  [1+1, 2+2, 3+3]

[4, 6, 9, 1, 3]  -->  [5, 8, 2, 5, 8]  #  [4+1, 6+2, 9+3, 1+4, 3+5]
                                       #  9+3 = 12  -->  2
*/

//***************Solution********************
//first element +1, second element +2 and so on.. start with 1, not 0
//check if current element + index position is a double digit
//if so, return the last digit of the sum
//else return the sum as it is, store in array and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System;
using System.Linq;
public static class Kata{
    public static int[] Incrementer(int[] numbers)=> numbers.Select((x,i)=>x+i+1 >= 10 ? Math.Abs(x+i+1) % 10 : x+i+1 ).ToArray();
      
}

//solution 2
using System.Linq;

public static class Kata
{
    public static int[] Incrementer(int[] numbers)
    {
        return numbers.Select((n,i) => (n + i + 1) % 10).ToArray();
    }
}
//****************Sample Test*****************
namespace Solution
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
  
    [TestFixture]
    public class FixedTestSuite
    {
        [TestCase(new int[0], new int[0])]
        [TestCase(new int[]{1, 2, 3},new int[]{2, 4, 6})]
        [TestCase(new int[]{4, 6, 7, 1, 3},new int[]{5, 8, 0, 5, 8})]
        [TestCase(new int[]{3, 6, 9, 8, 9},new int[]{4, 8, 2, 2, 4})]
        [TestCase(new int[]{1, 2, 3, 4, 5, 6, 7, 8, 9, 9, 9, 9, 9, 8},new int[]{2, 4, 6, 8, 0, 2, 4, 6, 8, 9, 0, 1, 2, 2})]
        public void SampleTests(int[] numbers, int[] expected)
        {
            Tester.Act(numbers, expected);
        }
    }
  
    [TestFixture]
    public class RandomTestSuite
    {
        [TestCaseSource(nameof(GenerateTestCases))]
        public void RandomTests((int[], int[]) testCase)
        {
            var (numbers, expected) = testCase;
            Tester.Act(numbers, expected);
        }
      
        private static IEnumerable<TestCaseData> GenerateTestCases()
        {
            var rnd = new Random();
            for (var n = 1; n <= 100; ++n) 
            {
                var numbers = Enumerable.Range(0, rnd.Next(1, 20))
                  .Select(_ =>rnd.Next(0, 9))
                  .ToArray();
                var expected = Tester.Reference(numbers);
                yield return new TestCaseData((numbers, expected))
                {
                    HasExpectedResult = false
                }.SetDescription($"Test {n}: numbers = {Tester.ArrayToString(numbers)}");
            }
        }
    }
  
    static class Tester
    {
        internal static void Act(int[] numbers, int[] expected)
        {
            var actual = Kata.Incrementer(numbers.ToList().ToArray());
            var msg = $"Invalid answer for numbers: {ArrayToString(numbers)}\n\texpected: {ArrayToString(expected)}\n\tactual: {ArrayToString(actual)}";
            CollectionAssert.AreEqual(expected, actual, msg);
        }
      
        internal static int[] Reference(int[] numbers)
        {
            return numbers.Select((n,i) => (n + i + 1) % 10).ToArray();
        }
      
        internal static string ArrayToString(int[] array)
        {
            return $"[{string.Join(",", array)}]";
        }
    }
}
