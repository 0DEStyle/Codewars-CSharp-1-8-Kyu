/*Challenge link:https://www.codewars.com/kata/5c44b0b200ce187106452139/train/csharp
Question:
args_count(1, 2, 3) -> 3
args_count(1, 2, 3, 10) -> 4
*/

//***************Solution********************
//using the keyword params to specify a method parameter that takes a variable number of arguments
//since arguments can be int, string and object, we define the array as object[]
//count the number of array using the keyword Lenght
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public static class Kata {
  public static int CountArgs(params object[] args) => args.Length;
}

//second solution
public static class Kata 
{
  public static int CountArgs(params dynamic[] args) => args.Length;
}

//****************Sample Test*****************

using System;
using System.Collections.Generic;

namespace Solution {
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class SolutionTest {

        private static readonly Random random = new Random();
        private static readonly Func<object>[] pool = new Func<object>[] {
            () => random.Next(int.MinValue, int.MaxValue),
            () => random.NextDouble(),
            () => (char) random.Next(32, 127),
            () => new object[] { 1, 2.3f, Math.PI, "hfjkeshfjk", "42" },
            () => new object(),
            () => new List<object>(new object[] { 1, 2.3f, Math.PI, "hfjkeshfjk", "42" })
        };

        [Test]
        public void FixedTest() {
            Assert.AreEqual(3, Kata.CountArgs(1, 2, 3));
            Assert.AreEqual(3, Kata.CountArgs(1, 2, "uhsaf uas"));
            Assert.AreEqual(1, Kata.CountArgs(1));
            Assert.AreEqual(4, Kata.CountArgs('a', 865, "asfhgajsf", new object[] { "dawdjio", null, new List<object>() }));
            Assert.AreEqual(0, Kata.CountArgs());
        }

        [Test]
        public void RandomTest() {
            var testCount = random.Next(100, 200);
            for (var t = 0; t < testCount; t++) {
                var length = random.Next(0, 100);
                var args = EnumerableUtils.Generate(pool.Random).Take(length).ToArray();
                Assert.AreEqual(length, Kata.CountArgs(args));
            }
        }
    }
}

public static class EnumerableUtils {

    public static IEnumerable<T> Generate<T>(Func<T> supplier) {
        while (true)
            yield return supplier();
    }

}

public static class ArrayExtensions {

    private static Random random = new Random();
    public static T Random<T>(this T[] arr) => arr[arr.RandomIndex()];
    public static int RandomIndex<T>(this T[] arr) => random.Next(arr.Length);

}
