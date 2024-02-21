/*Challenge link:https://www.codewars.com/kata/5959ec605595565f5c00002b/train/csharp
Question:
Write a function that reverses the bits in an integer.

For example, the number 417 is 110100001 in binary. Reversing the binary is 100001011 which is 267.

You can assume that the number is not negative.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
/*
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨⬛⬜🟨🟨🟨🟨🟨⬛⬜🟨
🟨⬛⬛🟨🟨🟨🟨🟨⬛⬛🟨
🟨⬛⬛🟨🟨⬛🟨🟨⬛⬛🟨
🟥🟨🟨🟨🟨🟨🟨🟨🟨🟨🟥
🟥🟥🟨🟨🟨⬛🟨🟨🟨🟥🟥
🟥🟥🟨🟨⬛🟨⬛🟨🟨🟥🟥
🟥🟨🟨🟨🟨🟨🟨🟨🟨🟨🟥
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
*/
//convert long to binary string, reverse the string
//convert back to binary.
using System;
using System.Linq;

public static class Kata{
    public static long ReverseBits(long n) => 
    Convert.ToInt64(
      string.Concat(Convert.ToString(n, 2).Reverse()
                   ), 2);
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
        [Test(Description = "Sample tests")]
        public void SampleTests()
        {
            Assert.AreEqual(267, Kata.ReverseBits(417), "Incorrect answer for n=267");
            Assert.AreEqual(417, Kata.ReverseBits(267), "Incorrect answer for n=417");
            Assert.AreEqual(0, Kata.ReverseBits(0), "Incorrect answer for n=0");
            Assert.AreEqual(1087, Kata.ReverseBits(2017), "Incorrect answer for n=1087");
            Assert.AreEqual(1023, Kata.ReverseBits(1023), "Incorrect answer for n=1023");
            Assert.AreEqual(1, Kata.ReverseBits(1024), "Incorrect answer for n=1024");
            Assert.AreEqual(long.MaxValue, Kata.ReverseBits(long.MaxValue), $"Incorrect answer for n={long.MaxValue}");
        }
    
        [Test(Description = "Random tests")]
        public void RandomTests()
        {
            Random random = new Random();
            byte[] buffer = new byte[8];
            for (int i = 0; i < 200; i++)
            {
                // Generate random non-negative long
                random.NextBytes(buffer);
                long num = Math.Abs(BitConverter.ToInt64(buffer, 0));
              
                Assert.AreEqual(Solution(num), Kata.ReverseBits(num), $"Incorrect answer for n={num}");
            }
        }
    
        private long Solution(long n)
        {
            char[] binary = Convert.ToString(n, 2).ToCharArray();
            Array.Reverse(binary);
            return Convert.ToInt64(new string(binary), 2);
        }
  }
}
