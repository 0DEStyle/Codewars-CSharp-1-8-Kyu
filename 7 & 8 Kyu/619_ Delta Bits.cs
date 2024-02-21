/*Challenge link:https://www.codewars.com/kata/538948d4daea7dc4d200023f/train/csharp
Question:
Complete the function to determine the number of bits required to convert integer A to integer B (where A and B >= 0)

The upper limit for A and B is 216, int.MaxValue or similar.

For example, you can change 31 to 14 by flipping the 4th and 0th bit:

 31  0 0 0 1 1 1 1 1
 14  0 0 0 0 1 1 1 0
---  ---------------
bit  7 6 5 4 3 2 1 0
Thus 31 and 14 should return 2.
*/

//***************Solution********************
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
//count the number of bit needed to change a to b
using System;
using System.Collections;

public class DeltaBits {
    public static int ConvertBits(int a, int b) {
      //create new Bit Array with result a XOR b(10 or 01 makes 1)
      var arr = new BitArray(new [] {a ^ b});
      var count = 0;
      
      //loop through each bit and check bit in arr
      //count number of difference
      foreach(bool bit in arr)
        if(bit)
          count++;
      return count;
    }
}

//solution 2
using System;
using System.Numerics;

public class DeltaBits
{
    public static int ConvertBits(int a, int b)
        => BitOperations.PopCount((uint) (a ^ b));
}
//****************Sample Test*****************
using NUnit.Framework;
using System;

[TestFixture]
public class DeltaBitsTest 
{
  
  [Test]
  public void TestFixedValues()
  {
    Assert.AreEqual(2, DeltaBits.ConvertBits(31, 14), "ConvertBits(31, 14)");
    Assert.AreEqual(3, DeltaBits.ConvertBits(7, 17), "ConvertBits(7, 17)");
    Assert.AreEqual(5, DeltaBits.ConvertBits(31, 0), "ConvertBits(31, 0)");
    Assert.AreEqual(0, DeltaBits.ConvertBits(0, 0), "ConvertBits(0, 0)");
    Assert.AreEqual(0, DeltaBits.ConvertBits(127681, 127681), "ConvertBits(127681, 127681)");
    Assert.AreEqual(13, DeltaBits.ConvertBits(312312312, 5645657), "ConvertBits(312312312, 5645657)");
    Assert.AreEqual(17, DeltaBits.ConvertBits(43, 2009989843), "ConvertBits(43, 2009989843)");
  }
  
  [Test]
  public void TestRandomValues()
  {
    Random r = new Random();
    for (int i = 0; i < 20; i++) 
    {   
      int a = r.Next(int.MaxValue);
      int b = r.Next(int.MaxValue);
      Assert.AreEqual(ConvertBits(a, b), DeltaBits.ConvertBits(a, b), string.Format("ConvertBits({0}, {1})", a, b));
    }
  }

  private int ConvertBits(int a, int b) 
  {
    int c = 0, n = a ^ b;
    for(; n > 0; c += n & 1, n >>= 1);
    return c;
  }  
}
