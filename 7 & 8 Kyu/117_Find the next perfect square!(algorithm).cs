/*Challenge link:
Question:
You might know some pretty large perfect squares. But what about the NEXT one?

Complete the findNextSquare method that finds the next integral perfect square after the one passed as a parameter. Recall that an integral perfect square is an integer n such that sqrt(n) is also an integer.

If the parameter is itself not a perfect square then -1 should be returned. You may assume the parameter is non-negative.

Examples:(Input --> Output)

121 --> 144
625 --> 676
114 --> -1 since 114 is not a perfect square
*/

//***************Solution********************
//find the square root of the num : r
//if r square is not the same as the original number.
//return -1, else add one and square to get the next perfect square.
using System;

public class Kata{
  public static long FindNextSquare(long num){
    long r = (long)Math.Sqrt(num);
    return r * r != num ? -1 : (r + 1) * (r + 1);
  }
}

//****************Sample Test*****************
using NUnit.Framework;
using System;

[TestFixture]
public class Tests {
  
  [Test]
  [TestCase(155, ExpectedResult=-1)]
  [TestCase(121, ExpectedResult=144)]
  [TestCase(625, ExpectedResult=676)]
  [TestCase(319225, ExpectedResult=320356)]
  [TestCase(15241383936, ExpectedResult=15241630849)]
  public static long SampleTests(long num)
  {
    return Kata.FindNextSquare(num);
  }
  
  
  [Test]
  public void FloatProof()
  {
      long n = 67108864L;

      Assertion(-1L, n*n-1);
      Assertion((n+1)*(n+1), n*n);
      Assertion(-1L, n*n+1);
  }
  [Test]
  public void RandomTests() {
    Random rand = new Random();
    long input;
    long expected;
    
    long Solution(long num)
    {
      long sqrt = (long)Math.Sqrt(num);

      return sqrt * sqrt == num ? ((long)sqrt + 1) * ((long)sqrt + 1) : -1;
    }
    
    for (int i = 0; i < 100; i++) {
      input = RandomInput();
      expected = Solution(input);
      
      Assertion(expected, input);
    }
  }
  
  private static long RandomInput() {
    Random rand = new Random();
    
    if (rand.Next(0, 3) == 0) return rand.Next();
    
    long random = (long)rand.Next();
    return random * random;
      
  }
  
  public static void Assertion(long expected, long input) {
    Assert.AreEqual(
      expected,
      Kata.FindNextSquare(input),
      
      $"num: {input}"
    );
  }
}
