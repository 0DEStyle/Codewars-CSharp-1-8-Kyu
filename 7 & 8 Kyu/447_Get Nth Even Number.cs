/*Challenge link:https://www.codewars.com/kata/5933a1f8552bc2750a0000ed/train/csharp
Question:
Return the Nth Even Number

Example(Input --> Output)

1 --> 0 (the first even number is 0)
3 --> 4 (the 3rd even number is 4 (0, 2, 4))
100 --> 198
1298734 --> 2597466
The input will not be 0.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression 
//apply formula
public class Kata{
  public static int NthEven(int n) => (2 * n) - 2;
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    [TestCase(1, ExpectedResult=0)]
    [TestCase(3, ExpectedResult=4)]
    [TestCase(100, ExpectedResult=198)]
    [TestCase(1298734, ExpectedResult=2597466)]
    public int FixedTest(int n)
    {
      return Kata.NthEven(n);
    }
    
    [Test]
    public void RandomTest([Random(1,1000000,100)]int n)
    {
      Assert.AreEqual(Solution(n), Kata.NthEven(n));
    }
    
    private int Solution(int n) => n*2-2;
  }
}
