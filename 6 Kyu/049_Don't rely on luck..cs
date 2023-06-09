/*Challenge link:https://www.codewars.com/kata/5268af3872b786f006000228/train/csharp
Question:
The test fixture I use for this kata is pre-populated.

It will compare your guess to a random number generated using:

new Random().Next(1, 100 + 1);
You can pass by relying on luck or skill but try not to rely on luck.

"The power to define the situation is the ultimate power." - Jerry Rubin

Good luck!
*/

//***************Solution********************
//hijack the class Random from namespace Solution, and change the answer to 69

namespace Solution{
    public class Random{
        public int Next(int min, int max) => 69;
    }
}

public class KataClass {
  public static int Guess = 69;
}

//****************Sample Test*****************
// This is exactly what the real test fixture looks like
namespace Solution {
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void Test()
    {
      var random = new Random().Next(1, 100 + 1);
      Assert.AreEqual(random, KataClass.Guess);
    }
  }
}
