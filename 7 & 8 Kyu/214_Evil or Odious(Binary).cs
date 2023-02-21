/*Challenge link:https://www.codewars.com/kata/56fcfad9c7e1fa2472000034/train/csharp
Question:
The number n is Evil if it has an even number of 1's in its binary representation.
The first few Evil numbers: 3, 5, 6, 9, 10, 12, 15, 17, 18, 20

The number n is Odious if it has an odd number of 1's in its binary representation.
The first few Odious numbers: 1, 2, 4, 7, 8, 11, 13, 14, 16, 19

You have to write a function that determine if a number is Evil of Odious, function should return "It's Evil!" in case of evil number and "It's Odious!" in case of odious number.

good luck :)
*/

//***************Solution********************
//convert n to binary, check if the number of '1' is odd or even, return a string accordingly
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;

public class Kata{
  public static string Evil(int n){
    string nBinary = Convert.ToString(n, 2);
    return nBinary.Contains('1') && nBinary.Count(x => x == '1') % 2 != 0 ? "It's Odious!" :  "It's Evil!";
  }
}

//solution 2
using System;
using System.Linq;
public class Kata
{
  public static string Evil(int n)
    => Convert.ToString(n,2).Count(e=> e == '1')% 2 == 1 ? "It's Odious!" : "It's Evil!";
}
//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void FixedTest()
    {
      Assert.AreEqual("It's Odious!", Kata.Evil(1));
      Assert.AreEqual("It's Odious!", Kata.Evil(2));
      Assert.AreEqual("It's Evil!", Kata.Evil(3));
    }
    
    private static Random rng = new Random();
    
    private static string Solution(int n)
    {
      int count = 0;
      while (n != 0)
      {
        if ((n & 1) == 1) { ++count; }
        n >>= 1;
      }
      return ((count & 1) == 1) ? "It's Odious!" : "It's Evil!";
    }
    
    [Test]
    public void RandomTest()
    {
      for (int i = 0; i < 100; ++i)
      {
        int test = rng.Next(1, 400001);
        string expected = Solution(test);
        string actual = Kata.Evil(test);
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
