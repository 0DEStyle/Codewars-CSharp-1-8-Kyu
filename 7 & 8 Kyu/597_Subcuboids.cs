/*Challenge link:https://www.codewars.com/kata/5b9e29dc1d5ed219910000a7/train/csharp
Question:
You have a cuboid with dimensions x,y,z ∈ ℕ. The values of x, y, and z are between 1 and 10^9. A subcuboid of this cuboid has dimensions length, width, height ∈ ℕ where 1≤length≤x, 1≤width≤y, 1≤height≤z. If two subcuboids have the same length, width, and height, but they are at different positions within the cuboid, they are distinct. Find the total number of subcuboids for the given cuboid.

Examples
See sample tests and the image below

27 subcuboids for a 2×2×2 cuboid
subcuboids(2,2,2)
//see image in link

*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
/*
⬜⬜⬜⬜⬜⬜⬜⬛⬛⬛⬛⬛⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨⬛⬛⬜🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨⬛⬛⬛🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬛⬛🟨🟨🟨⬛⬛⬛🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬛🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬛⬛🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬛🟨🟨🟨🟨🟧🟧⬛🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬛🟧🟧🟧🟧🟧⬛⬛🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛
⬜⬜⬛⬛⬛⬛⬛🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛
⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨⬛🟨⬛⬛⬛⬛⬛⬜⬜⬜⬜⬜⬛🟨⬛
⬜⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛⬛⬛⬛🟨🟨⬛
⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛
⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛🟨🟨🟨🟨🟨🟨⬛⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨⬛⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨⬛⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜
⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛⬛⬛⬛⬛⬛⬛⬛⬛⬛⬛⬛⬜⬜⬜⬜⬜⬜⬜
*/
/*
∈ = Element of
ℕ = Natural Numbers
https://www.mathsisfun.com/sets/symbols.html
*/
using System.Numerics;

//parse x to BigInteger, then apply formula
class Kata{
  public static BigInteger Subcuboids(uint x, uint y, uint z) => new BigInteger(x) * y * z * (x + 1) * (y + 1) * (z + 1) / 8;
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Numerics;

  [TestFixture]
  public class FixedTests
  {
    [Test]
    public void Tests()
    {
      Assert.AreEqual(new BigInteger(1), Kata.Subcuboids(1, 1, 1));
      Assert.AreEqual(new BigInteger(27), Kata.Subcuboids(2, 2, 2));
      Assert.AreEqual(new BigInteger(108), Kata.Subcuboids(2, 3, 3));
      Assert.AreEqual(new BigInteger(3150), Kata.Subcuboids(4, 5, 6));
      Assert.AreEqual(new BigInteger(11088), Kata.Subcuboids(3, 7, 11));
    }
  }

  [TestFixture]
  public class RandomTests
  {
    [Test]
    public void Tests()
    {
      var r = new Random();
      for (var i = 0; i < 100; i++)
      {
        var x = (uint)r.Next(1, 1000001);
        var y = (uint)r.Next(1, 1000001);
        var z = (uint)r.Next(1, 1000001);
        Assert.AreEqual(Reference(x, y, z), Kata.Subcuboids(x, y, z));
      }
    }
    
    private static BigInteger Reference(uint w, uint h, uint d)
    {
      return new BigInteger(w) * (w + 1) * h * (h + 1) * d * (d + 1) / 8;
    }
  }
}
