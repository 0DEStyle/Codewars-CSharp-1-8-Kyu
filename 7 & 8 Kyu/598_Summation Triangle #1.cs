/*Challenge link:https://www.codewars.com/kata/6357825a00fba284e0189798/solutions/csharp
Question:
The task
You have to make a program capable of returning the sum of all the elements of a triangle with side of size 
�
+
1
n+1.

The problem
Your solution has to support 
0
≤
�
≤
1
0
6
0≤n≤10 
6
 . Brute-forcing will not work!

The definition
A triangle element 
�
�
�
a 
ij
​
  where 
�
i is the column and 
�
j is the row can be defined as 
�
�
�
=
2
�
+
�
+
1
a 
ij
​
 =2j+i+1 where 
0
≤
�
≤
�
≤
�
0≤j≤i≤n

Examples
For n = 2:

1  2  3      \
   4  5       \__ 1+2+3+4+5+7 sums to: 22
      7       /
sum(2) = 22
For n = 3:

1  2  3  4   \
   4  5  6    \__ 1+2+3+4+4+5+6+7+8+10 sums to: 50
      7  8    /
        10   /
sum(3) = 50
Hints
Euler transform (Optional)
Sums of powers
*/

//***************Solution********************
/*
⬜⬜⬜⬜⬜⬜⬜⬛⬛⬛⬛⬛⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨⬛⬛⬜🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨⬛⬛⬛🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬛⬛🟨🟨🟨⬛⬛⬛🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬛🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬛⬛🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬛🟨🟨🟨🟨🟧🟧⬛🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬛🟧🟧🟧🟧🟧⬛⬛🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛
⬜⬜⬛⬛⬛⬛⬛🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛
⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨⬛🟨⬛⬛⬛⬛⬛⬜⬜⬜⬜⬜⬛🟨⬛
⬜⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛⬛⬛⬛🟨🟨⬛
⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛
⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛🟨🟨🟨🟨🟨🟨⬛⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨⬛⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨⬛⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜
⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛⬛⬛⬛⬛⬛⬛⬛⬛⬛⬛⬛⬜⬜⬜⬜⬜⬜⬜
*/

using System.Linq;
//start from 1, count up to n+1
//long parse 2, then accumulate sum.
public static class Kata {
  public static long GetSum(int n) => 
    Enumerable.Range(1, n + 1)
              .Sum(x => x * (x * 2L - 1));
}

//better solution
public static class Kata
{
  public static long GetSum(int n)
  {
    return (n + 1L) * (n + 2) * (4 * n + 3) / 6;
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
        private static void Act(int n, long expected)
        {
            var actual = Kata.GetSum(n);
            var msg = $"  n = {n}\n";
            Assert.AreEqual(expected, actual, msg);
        }
      
        [TestCase(1L, 0)]
        [TestCase(7L, 1)]
        [TestCase(22L, 2)]
        [TestCase(50L, 3)]
        [Test(Description = "Small tests")]
        public void FixedTestsSmall(long expected, int n)
        {
            Act(n, expected);
        }
      
        [TestCase(691951L, 100)]
        [TestCase(83959751L, 500)]
        [TestCase(669169501L, 1000)]
        [Test(Description = "Medium tests")]
        public void FixedTestsMedium(long expected, int n)
        {
            Act(n, expected);
        }
      
        [TestCase(666916695001L, 10000)]
        [TestCase(666691666950001L, 100000)]
        [TestCase(666669166669500001L, 1000000)]
        [Test(Description = "Large tests")]
        public void FixedTestsLarge(long expected, int n)
        {
            Act(n, expected);
        }
      
        [TestCaseSource(nameof(GenerateTestCases))]
        public void RandomTests((int, long) testCase)
        {
            var (n, expected) = testCase;
            Act(n, expected);
        }
    
        private static IEnumerable<TestCaseData> GenerateTestCases()
        {
            var rnd = new Random();
            for (var i = 0; i < 500; ++i) 
                yield return GenerateTestCase(rnd, i+1);
        }
    
        private static TestCaseData GenerateTestCase(Random rnd, int i)
        {
            long ReferenceSolution(int n) => (n*(n*(4*(long)n+15)+17)+6)/6;
            var n = rnd.Next(0, 1000000);
            var expected = ReferenceSolution(n);
            return new TestCaseData((n, expected))
            {
                HasExpectedResult = false
            }.SetDescription($"Test {i}: n:{n}");
        }
    }
}
