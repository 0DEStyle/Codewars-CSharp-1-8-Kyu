/*Challenge link:https://www.codewars.com/kata/5865cff66b5699883f0001aa/train/csharp
Question:
This Kata is intended as a small challenge for my students

All Star Code Challenge #22

Create a function that takes an integer argument of seconds and converts the value into a string describing how many hours and minutes comprise that many seconds.

Any remaining seconds left over are ignored.

Note:
The string output needs to be in the specific form - "X hour(s) and X minute(s)"

For example:

3600 --> "1 hour(s) and 0 minute(s)"
3601 --> "1 hour(s) and 0 minute(s)"
3500 --> "0 hour(s) and 58 minute(s)"
323500 --> "89 hour(s) and 51 minute(s)"
*/

//***************Solution********************
//apply algorithm
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

public static class Kata {
    public static string ToTime(int s) => $"{(s-(s%60))/3600} hour(s) and {(s%3600)/60} minute(s)" ;
}
//****************Sample Test*****************
namespace Solution
{
    using NUnit.Framework;
    using System;
  
    [TestFixture]
    public class SolutionTest 
    {
        private static void Act(int seconds, string expected)
        {
            var actual = Kata.ToTime(seconds);
            Console.WriteLine($"   Input: seconds = {seconds}\nExpected: {expected}\n  Actual: {actual}\n");
            Assert.AreEqual(expected, actual, $"Input: seconds = {seconds}");
        }
      
        [Test(Description = "Fixed Tests")]
        public void FixedTests()
        {
            Act(3600, "1 hour(s) and 0 minute(s)");
            Act(3601, "1 hour(s) and 0 minute(s)");
            Act(3500, "0 hour(s) and 58 minute(s)");
            Act(323500, "89 hour(s) and 51 minute(s)");
            Act(0, "0 hour(s) and 0 minute(s)");
        }

        [Test(Description = "Random Tests")]
        public void RandomTests() 
        {
            string solver(int seconds) => $"{seconds / 3600} hour(s) and {(seconds % 3600) / 60} minute(s)";
            var rand = new Random();
            for (var i = 0; i < 100; i++) 
            {
                var seconds = (int)(rand.Next(999999)); 
                var expected = solver(seconds);
                Act(seconds, expected);  
            }
        }
    }
}
