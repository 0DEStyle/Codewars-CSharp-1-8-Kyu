/*Challenge link:https://www.codewars.com/kata/5a805d8cafa10f8b930005ba/train/csharp
Question:
Your task is to find the nearest square number, nearest_sq(n) or nearestSq(n), of a positive integer n.

For example, if n = 111, then nearest\_sq(n) (nearestSq(n)) equals 121, since 111 is closer to 121, the square of 11, than 100, the square of 10.

If the n is already the perfect square (e.g. n = 144, n = 81, etc.), you need to just return n.

Good luck :)

Check my other katas:

Alphabetically ordered

Case-sensitive!

Not prime numbers


*/

//***************Solution********************
//square root the number n, round to the nearest even number, then calculate the number to the power of 2
//convert double to int and returnt the result
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;

public static class Kata
{
  public static int NearestSq(int n)=> Convert.ToInt32(Math.Pow(Math.Round(Math.Sqrt(n)), 2));
}

//****************Sample Test*****************
namespace Solution
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void SampleTest()
        {
            Assert.That(Kata.NearestSq(1), Is.EqualTo(1));
            Assert.That(Kata.NearestSq(2), Is.EqualTo(1));
            Assert.That(Kata.NearestSq(10), Is.EqualTo(9));
            Assert.That(Kata.NearestSq(111), Is.EqualTo(121));
            Assert.That(Kata.NearestSq(9999), Is.EqualTo(10000));
        }

        [Test]
        public void RandomTest()
        {
            var rnd = new Random();
            for (var i = 0; i < 1000; i++)
            {
                var n = rnd.Next(0, 2000000);
                var expected = (int) Math.Pow(Math.Round(Math.Sqrt(n)), 2);
                var message = FailureMessage(n, expected);
                var actual = Kata.NearestSq(n);

                Assert.AreEqual(expected, actual, message);
            }
        }

        private static string FailureMessage(int n, int value)
        {
            return $"Should return {value} with n={n}";
        }
    }
}
