/*Challenge link:https://www.codewars.com/kata/643af0fa9fa6c406b47c5399/train/csharp
Question:
Task
Given a point in a Euclidean plane (x and y), return the quadrant the point exists in: 1, 2, 3 or 4 (integer). x and y are non-zero integers, therefore the given point never lies on the axes.

Examples
(1, 2)     => 1
(3, 5)     => 1
(-10, 100) => 2
(-1, -9)   => 3
(19, -56)  => 4
Reference
see image in link

QuadrantsQuadrants
There are four quadrants:

First quadrant, the quadrant in the top-right, contains all points with positive X and Y
Second quadrant, the quadrant in the top-left, contains all points with negative X, but positive Y
Third quadrant, the quadrant in the bottom-left, contains all points with negative X and Y
Fourth quadrant, the quadrant in the bottom-right, contains all points with positive X, but negative Y
More on quadrants: Quadrant (plane geometry) - Wikipedia

Task Series
Quadrants (this kata)
Quadrants 2: Segments
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression 
//check x and y coordinates location and return Euclidean plane accordingly
public static class Kata{
  public static int Quadrant(int x, int y) => 
    x > 0 && y > 0 ? 1 : 
    x < 0 && y > 0 ? 2 :
    x < 0 && y < 0 ? 3 : 4;
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
    static Random rnd = new Random();
    
    static void Act(int x, int y, int expected) 
      => Assert.AreEqual(expected, Kata.Quadrant(x, y), $"Quadrant( x = {x}, y = {y} )");
    
    [TestCase(1, 2, 1)]
    [TestCase(3, 5, 1)]
    [TestCase(-10, 100, 2)]
    [TestCase(-1, -9, 3)]
    [TestCase(19, -56, 4)]
    [TestCase(1, 1, 1)]
    [TestCase(-60, -12, 3)]
    public void FixedTests(int x, int y, int expected) => Act(x, y, expected);
    
    [Test]
    public void SmallRandomTests() => DoRandomTests(200, 10, 100);
    
    [Test]
    public void MediumRandomTests() => DoRandomTests(200, 100, 1000);
    
    private void DoRandomTests(int tests, int minValue, int maxValue)
    {
      for (int i = 0; i < tests; i++) DoRandomTest(minValue, maxValue);
    }
    
    private void DoRandomTest(int minValue, int maxValue)
    {
      bool RandomBoolean() => rnd.Next(0, 2) == 1;
      int ReferenceSolution(int x, int y) => x > 0 ? y > 0 ? 1 : 4 : y > 0 ? 2 : 3;
      int x = rnd.Next(minValue, maxValue + 1) * (RandomBoolean() ? 1 : -1);
      int y = rnd.Next(minValue, maxValue + 1) * (RandomBoolean() ? 1 : -1);
      int expected = ReferenceSolution(x, y);
      Act(x, y, expected);
    }
  }
}
