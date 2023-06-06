/*Challenge link:https://www.codewars.com/kata/545af3d185166a3dec001190/train/csharp
Question:
Create a method each_cons that accepts a list and a number n, and returns cascading subsets of the list of size n, like so:

each_cons([1,2,3,4], 2)
  #=> [[1,2], [2,3], [3,4]]

each_cons([1,2,3,4], 3)
  #=> [[1,2,3],[2,3,4]]
  
As you can see, the lists are cascading; ie, they overlap, but never out of order.


*/

//***************Solution********************
//find out how many element in the list first by using Enumerable.Range(0, Math.Max(0, list.Length - n + 1))
//then from the rangee, skip the current element in list, and take n
//return the result as a list.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;
using System.Collections.Generic;

static class Kata{
  public static IEnumerable<IEnumerable<int>> EachCons(int[] list, int n) =>
    Enumerable.Range(0, Math.Max(0, list.Length - n + 1)).Select(x => list.Skip(x).Take(n));
}

//****************Sample Test*****************
namespace Solution 
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
  
    public class SolutionTest
    {
        static int[] Clone(int[] xs) => xs.Select(x => x).ToArray();
        static int[][] Materialise(IEnumerable<IEnumerable<int>> xss) => xss.Select(xs => xs.ToArray()).ToArray();
        static IEnumerable<IEnumerable<int>> Empty() { yield break; }
      
        private static void Act(int[] list, int n, IEnumerable<IEnumerable<int>> expected)
        {
            var xs = Clone(list);
            var xssExpected = Materialise(expected);
            var xssActual = Materialise(Kata.EachCons(xs, n));
            var msg = new StringBuilder();
            msg.AppendLine($"Invalid answer for list: [{string.Join(",", xs)}] and n: {n}");
            msg.AppendLine($"  Expected: [{string.Join(",", xssExpected.Select(ys => $"[{string.Join(",", ys)}]"))}]");
            msg.AppendLine($"    Actual: [{string.Join(",", xssActual.Select(ys => $"[{string.Join(",", ys)}]"))}]");
            CollectionAssert.AreEqual(xssExpected, xssActual, msg.ToString());
        }
      
        [TestFixture]
        public class FixedTests
        {
            [Test(Description = "List: [3, 5, 8, 13] n: 1")]
            public void Test1() => Act(new[] {3, 5, 8, 13}, 1, new[] { new[] {3}, new[] {5}, new[] {8}, new[] {13} });
          
            [Test(Description = "List: [3, 5, 8, 13] n: 2")]
            public void Test2() => Act(new[] {3, 5, 8, 13}, 2, new[] { new[] {3, 5}, new[] {5, 8}, new[] {8, 13} });
          
            [Test(Description = "List: [3, 5, 8, 13] n: 3")]
            public void Test3() => Act(new[] {3, 5, 8, 13}, 3, new[] { new[] {3, 5, 8}, new[] {5, 8, 13} });
          
            [Test(Description = "List: [3, 5, 8, 13] n: 4")]
            public void Test4() => Act(new[] {3, 5, 8, 13}, 4, new[] { new[] {3, 5, 8, 13} });
          
            [Test(Description = "List: [3, 5, 8, 13] n: 5")]
            public void Test5() => Act(new[] {3, 5, 8, 13}, 5, Empty());
        }
      
        [TestFixture]
        public class RandomTests
        {
            [TestCaseSource(nameof(GenerateTestCases))]
            public void RandomTest((int[], int, IEnumerable<IEnumerable<int>>) testCase)
            {
                var (list, n, expected) = testCase;
                Act(list, n, expected);
            }
        
            private static IEnumerable<TestCaseData> GenerateTestCases()
            {
                var rnd = new Random();
                for (var i = 0; i < 100; ++i) 
                    yield return GenerateTestCase(rnd, i+1);
            }
        
            private static TestCaseData GenerateTestCase(Random rnd, int i)
            {
                IEnumerable<IEnumerable<int>> ReferenceSolution(int[] refList, int refN) 
                    => Enumerable.Range(0, Math.Max(0, refList.Length - refN + 1)).Select(i => refList[i..(i+refN)]);
                int[] Range(int n) => Enumerable.Range(0, n).ToArray();
                var list = Range(rnd.Next(0, 10)).Select(_ => rnd.Next(0, 20)).ToArray();
                var n = rnd.Next(1, 12);
                var expected = ReferenceSolution(list, n);
                return new TestCaseData((list, n, expected))
                {
                    HasExpectedResult = false
                }.SetDescription($"Test {i} for list: [{string.Join(",", list)}] and n: {n}");
            }
        }
    }
}
