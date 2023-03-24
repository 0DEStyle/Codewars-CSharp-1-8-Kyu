/*Challenge link:https://www.codewars.com/kata/5a34b80155519e1a00000009/train/csharp
Question:
Return a new array consisting of elements which are multiple of their own index in input array (length > 1).

Some cases:
[22, -6, 32, 82, 9, 25] =>  [-6, 32, 25]

[68, -1, 1, -7, 10, 10] => [-1, 10]

[-56,-85,72,-26,-14,76,-27,72,35,-21,-67,87,0,21,59,27,-92,68] => [-85, 72, 0, 68]
*/

//***************Solution********************
//skip the first element, because division by 0 problem
//check if current element mod next element equals to 0
//if so, it is a multiple, store in a list and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;
using System.Collections.Generic;

public static class Kata
{
  public static List<int> MultipleOfIndex(List<int> xs)=>
    xs.Skip(1).Where((x, i) => x % (i + 1) == 0).ToList();
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
    [Test]
    public void BasicTest()
    {
      Assert.That(Kata.MultipleOfIndex(new List<int> {22, -6, 32, 82, 9, 25}), Is.EqualTo(new List<int> {-6, 32, 25}));
      Assert.That(Kata.MultipleOfIndex(new List<int> {68, -1, 1, -7, 10, 10}), Is.EqualTo(new List<int> {-1, 10}));
      Assert.That(Kata.MultipleOfIndex(new List<int> {11, -11}), Is.EqualTo(new List<int> {-11}));
      Assert.That(Kata.MultipleOfIndex(new List<int> {-56,-85,72,-26,-14,76,-27,72,35,-21,-67,87,0,21,59,27,-92,68}), Is.EqualTo(new List<int> {-85, 72, 0, 68}));
      Assert.That(Kata.MultipleOfIndex(new List<int> {28,38,-44,-99,-13,-54,77,-51}), Is.EqualTo(new List<int> {38, -44, -99}));
      Assert.That(Kata.MultipleOfIndex(new List<int> {-1,-49,-1,67,8,-60,39,35}), Is.EqualTo(new List<int> {-49, 8, -60, 35}));
    }
    
    [Test]
    public void RandomTest()
    {
      Random rnd = new Random();
      Func<List<int>, List<int>> sol = xs => xs.Where((v, i) => i != 0 && v % i == 0).ToList();
      
      for (int i = 0; i < 100; ++i)
      {
        List<int> xs = new int[rnd.Next(2, 21)].Select(_ => rnd.Next(-100, 100)).ToList();
        Assert.That(Kata.MultipleOfIndex(xs), Is.EqualTo(sol(xs)));
      }
    }
  }
}
