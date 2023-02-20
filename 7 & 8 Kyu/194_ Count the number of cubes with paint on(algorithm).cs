/*Challenge link:https://www.codewars.com/kata/5763bb0af716cad8fb000580/train/csharp
Question:
Upon arriving at an interview, you are presented with a solid blue cube. The cube is then dipped in red paint, coating the entire surface of the cube. The interviewer then proceeds to cut through the cube in all three dimensions a certain number of times.

Your function takes as parameter the number of times the cube has been cut. You must return the number of smaller cubes created by the cuts that have at least one red face.

To make it clearer, the picture below represents the cube after (from left to right) 0, 1 and 2 cuts have been made.

(see image at https://www.codewars.com/kata/5763bb0af716cad8fb000580/train/csharp)
Examples:
countSquares(2) --> 26
countSquares(4) --> 98
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//algorithm ref: https://math.stackexchange.com/questions/1874787/puzzle-find-number-of-cubes-with-1-red-face
public static class Kata{
        public static int CountSquares(int cuts) => cuts == 0 ? 1 : (6* cuts * cuts) + 2;
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

    [TestFixture]
    public class KataTest
    {
        [Test]
        public void BasicTest()
        {
            Assert.AreEqual(1, Kata.CountSquares(0));
            Assert.AreEqual(152,Kata.CountSquares(5));
            Assert.AreEqual(1538, Kata.CountSquares(16));
            Assert.AreEqual(3176, Kata.CountSquares(23));
        }

        [Test]
        public void RandomTest([Values(1)] int a, [Random(-1, 1, 30)] double d)
        {
            RgTest rg = new RgTest((int)d * 10000);
            int input = rg.RandomNumber();
            int n = input + 1;
            int output = (int)(6*(n-2)*(n-2)+12*(n-2)+8);
            Assert.AreEqual(output, Kata.CountSquares(input));
        }
    }

    public class RgTest
    {
        static Random _random;
        private static int _counter;
        public RgTest(int seed)
        {
            _counter = _counter + 1;
            _random = new Random(seed + _counter);
        }

        public int RandomNumber()
        {
            return _random.Next(50, 1000);
        }
    }
