/*Challenge link:https://www.codewars.com/kata/5bb904724c47249b10000131/train/csharp
Question:
Our football team has finished the championship.

Our team's match results are recorded in a collection of strings. Each match is represented by a string in the format "x:y", where x is our team's score and y is our opponents score.

For example: ["3:1", "2:2", "0:1", ...]

Points are awarded for each match as follows:

if x > y: 3 points (win)
if x < y: 0 points (loss)
if x = y: 1 point (tie)
We need to write a function that takes this collection and returns the number of points our team (x) got in the championship by the rules given above.

Notes:

our team always plays 10 matches in the championship
0 <= x <= 4
0 <= y <= 4
*/

//***************Solution********************
//solution 1
//select from element, first character x[0] and third character x[2]
//apply conditions and return the corresponding result and sum.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;

public static class Kata {
    public static int TotalPoints(string[] games) => 
      games.Select(x => (int)Char.GetNumericValue(x[0]) > (int)Char.GetNumericValue(x[2]) ? 3 :
                        (int)Char.GetNumericValue(x[0]) == (int)Char.GetNumericValue(x[2]) ? 1 : 0).Sum();
}

//soluiton 2
using System.Linq;
public static class Kata {
    public static int TotalPoints(string[] games) => games.Select(x => x[0] == x[2] ? 1 : x[0] > x[2] ? 3 : 0).Sum();
}


//****************Sample Test*****************
namespace Solution {
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class SolutionTest {

        [Test]
        public void Test1() =>
            Test(new[] { "1:0", "2:0", "3:0", "4:0", "2:1", "3:1", "4:1", "3:2", "4:2", "4:3" }, 30);

        [Test]
        public void Test2() =>
            Test(new[] { "1:1", "2:2", "3:3", "4:4", "2:2", "3:3", "4:4", "3:3", "4:4", "4:4" }, 10);

        [Test]
        public void Test3() =>
            Test(new[] { "0:1", "0:2", "0:3", "0:4", "1:2", "1:3", "1:4", "2:3", "2:4", "3:4" }, 0);

        [Test]
        public void Test4() =>
            Test(new[] { "1:0", "2:0", "3:0", "4:0", "2:1", "1:3", "1:4", "2:3", "2:4", "3:4" }, 15);

        [Test]
        public void Test5() =>
            Test(new[] { "1:0", "2:0", "3:0", "4:4", "2:2", "3:3", "1:4", "2:3", "2:4", "3:4" }, 12);
        
        private void Test(string[] input, int expectedOutput) =>
            Assert.AreEqual(expectedOutput, Kata.TotalPoints(input));

        [Test]
        public void RandomTests() {
            for (var i = 0; i < 100; i++)
                RandomTest();
        }

        private void RandomTest() {
            var randomGames = RandomGame().Take(10).ToArray();
            Test(randomGames, Solution(randomGames));

            IEnumerable<string> RandomGame() {
                var random = new Random();
                while (true)
                    yield return $"{random.Next(0, 5)}:{random.Next(0, 5)}";
            }

            int Solution(string[] games) =>
                games.Select(e => (x: e[0], y: e[2])).Select(e => e.x > e.y ? 3 : e.x == e.y ? 1 : 0).Sum();
        }

    }
}
