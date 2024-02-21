/*Challenge link:https://www.codewars.com/kata/6129095b201d6b000e5a33f0/train/csharp
Question:
Boxlines
Given a X*Y*Z box built by arranging 1*1*1 unit boxes, write a function f(X,Y,Z) that returns the number of edges (hence, boxlines) of length 1 (both inside and outside of the box)

Notes
Adjacent unit boxes share the same edges, so a 2*1*1 box will have 20 edges, not 24 edges
X,Y and Z are strictly positive, and can go as large as 2^16 - 1
Interactive Example
The following is a diagram of a 2*1*1 box. Mouse over the line segments to see what should be counted!

Interactive diagram made by @awesomead

This is my first kata, so I hope every one will enjoy it <3
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
/*
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨⬛⬜🟨🟨🟨🟨🟨⬛⬜🟨
🟨⬛⬛🟨🟨🟨🟨🟨⬛⬛🟨
🟨⬛⬛🟨🟨⬛🟨🟨⬛⬛🟨
🟥🟨🟨🟨🟨🟨🟨🟨🟨🟨🟥
🟥🟥🟨🟨🟨⬛🟨🟨🟨🟥🟥
🟥🟥🟨🟨⬛🟨⬛🟨🟨🟥🟥
🟥🟨🟨🟨🟨🟨🟨🟨🟨🟨🟥
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
*/
//apply formula and parse to ulong
public static class Kata{
    public static ulong F(ushort x, ushort y, ushort z) => 
      x * (y + 1UL) * (z + 1UL) +
      y * (x + 1UL) * (z + 1UL) +
      z * (x + 1UL) * (y + 1UL);
}

//****************Sample Test*****************
namespace Solution 
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
  
    [TestFixture]
    public class SolutionTest
    {
        private static void Act(ushort x, ushort y, ushort z, ulong expected)
        {
            var msg = $"Invalid answer for x: {x}, y: {y}, z: {z}";
            var actual = Kata.F(x, y, z);
            Assert.AreEqual(expected, actual, msg);
        }
      
        [TestCase(2, 1, 1, 20UL)]
        [TestCase(1, 2, 3, 46UL)]
        [TestCase(2, 2, 2, 54UL)]
        public void FixedTests(int x, int y, int z, ulong expected)
        {
            Act((ushort)x, (ushort)y, (ushort)z, expected);
        }
      
        [TestCaseSource(nameof(GenerateTestCases))]
        public void RandomTests((ushort, ushort, ushort, ulong) testCase)
        {
            var (x, y, z, expected) = testCase;
            Act(x, y, z, expected);
        }
    
        private static IEnumerable<TestCaseData> GenerateTestCases()
        {
            var rnd = new Random();
            for (var i = 0; i < 1000; ++i) 
                yield return GenerateTestCase(rnd, i+1);
        }
    
        private static TestCaseData GenerateTestCase(Random rnd, int n)
        {
            // reference solution
            ulong ReferenceSolution(ushort _x, ushort _y, ushort _z)
            {
                return (ulong)(_x+1)*(ulong)(_y+1)*(ulong)_z + (ulong)(_x+1)*(ulong)_y*(ulong)(_z+1) + (ulong)_x*(ulong)(_y+1)*(ulong)(_z+1);
            }
    
            // test case data generation
            ushort RandomUInt16() => (ushort)(rnd.Next(ushort.MaxValue));
            var x = RandomUInt16();
            var y = RandomUInt16();
            var z = RandomUInt16();
            var expected = ReferenceSolution(x, y, z);
            return new TestCaseData((x, y, z, expected))
            {
                HasExpectedResult = false
            }.SetDescription($"Test {n}: x = {x}, y = {y}, z = {z}");
        }
    }
}
