/*Challenge link:https://www.codewars.com/kata/65ba420888906c1f86e1e680/train/csharp
Question:Theoretical Material
You are given two vectors starting from the origin (x=0, y=0) with coordinates (x1,y1) and (x2,y2). Your task is to find out if these vectors are collinear. Collinear vectors are vectors that lie on the same straight line. They can be directed in the same or opposite directions. One vector can be obtained from another by multiplying it by a certain number. In terms of coordinates, vectors (x1, y1) and (x2, y2) are collinear if (x1, y1) = (k*x2, k*y2) , where k is any number acting as a coefficient.

//see image in link

For more information, check out this article on collinearity.

Problem Description
Write the function collinearity(x1, y1, x2, y2), which returns a Boolean type depending on whether the vectors are collinear or not.

all coordinates are integers
-1000 <= any coordinate <= 1000
Notes
All vectors start from the origin (x=0, y=0).
Be careful when handling cases where x1, x2, y1, or y2 are zero to avoid division by zero errors.
A vector with coordinates (0, 0) is collinear to all vectors.
Examples
(1,1,1,1) ➞ true
(1,2,2,4) ➞ true
(1,1,6,1) ➞ false
(1,2,-1,-2) ➞ true
(1,2,1,-2) ➞ false
(4,0,11,0) ➞ true
(0,1,6,0) ➞ false
(4,4,0,4) ➞ false
(0,0,0,0) ➞ true
(0,0,1,0) ➞ true
(5,7,0,0) ➞ true
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//check x1 * y2 == y1 * x2 and returna bool value.
public class Kata{
    public static bool Collinearity(int x1, int y1, int x2, int y2) => x1 * y2 == y1 * x2;
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;

  [TestFixture]
 public class SolutionTest
 {
         private static Random rnd = new Random();

        [TestCase(1, 1, 1, 1, ExpectedResult = true)]
        [TestCase(1, 2, 2, 4, ExpectedResult = true)]
        public bool Vectors_Directed_SameDirections(int x1, int x2, int y1, int y2) => Kata.Collinearity(x1, x2, y1, y2);

        [TestCase(1, 1, -1, -1, ExpectedResult = true)]
        [TestCase(1, -2, -2, 4, ExpectedResult = true)]
        public bool Vectors_Directed_OppositeDirections(int x1, int x2, int y1, int y2) => Kata.Collinearity(x1, x2, y1, y2);

        [TestCase(1, 1, 6, 1, ExpectedResult = false)]
        [TestCase(1, 2, 1, -2, ExpectedResult = false)]
        public bool Vectors_Directed_DifferentDirections(int x1, int x2, int y1, int y2) => Kata.Collinearity(x1, x2, y1, y2);

        [TestCase(4, 0, 11, 0, ExpectedResult = true)]
        [TestCase(0, 1, 6, 0, ExpectedResult = false)]
        [TestCase(4, 4, 0, 4, ExpectedResult = false)]
        [TestCase(0, 0, 0, 0, ExpectedResult = true)]
        [TestCase(0, 0, 1, 0, ExpectedResult = true)]
        [TestCase(5, 7, 0, 0, ExpectedResult = true)]
        public bool Vectors_Contains_Zeros(int x1, int x2, int y1, int y2) => Kata.Collinearity(x1, x2, y1, y2);
       
        [Test]
        public void RandomTest()
        {
            var Vectors = new List<List<int>>();
            Vectors.AddRange(AddRandomVectors());
            Vectors.AddRange(AddVectorsWithZeros());
            Vectors.AddRange(AddCollinearVectors());
            Shuffle(Vectors);
            foreach(var Vector in Vectors)
            {
                bool actual = Kata.Collinearity(Vector[0], Vector[1], Vector[2], Vector[3]);
                bool expected = Vector[0] * Vector[3] == Vector[1] * Vector[2];
                Assert.That(actual, Is.EqualTo(expected), $"x1 = {Vector[0]}, x2 = {Vector[1]}, y1 = {Vector[2]}, y2 = {Vector[3]}");
            }
        }

        private List<List<int>> AddRandomVectors()
        {
            var Vectors = new List<List<int>>();
            for (int i = 0; i < 20; i++)
            {
                Vectors.Add(new List<int>());
                for (int j = 0; j < 4; j++)
                    Vectors[i].Add(rnd.Next(-100, 100));
            }
            return Vectors;
        }

        private List<List<int>> AddVectorsWithZeros()
        {
            var Vectors = AddRandomVectors();
            for (int i = 0; i < Vectors.Count; i++)
            {
                for (int j = 0; j < 4; j++)
                    Vectors[i][rnd.Next(0, 4)] = 0;
            }
            return Vectors;
        }

        private List<List<int>> AddCollinearVectors()
        {
            var Vectors = AddRandomVectors();
            for (int i = 0; i < Vectors.Count; i++)
            {
                var nr = rnd.Next(1, 10);
                Vectors[i][2] = Vectors[i][0] * nr;
                Vectors[i][3] = Vectors[i][1] * nr;
            }
            return Vectors;
        }
        private void Shuffle(List<List<int>> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
