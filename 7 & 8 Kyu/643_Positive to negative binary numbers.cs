/*Challenge link:https://www.codewars.com/kata/5becace7063291bebf0001d5/train/csharp
Question:
Given an array of ones and zero(e)s that represents a positive binary number, convert the number to two's complement value.

Two's complement is the way most computers represent positive or negative integers. The most significant bit is 1 if the number is negative, and 0 otherwise.

Examples:

[1,1,1,1] = -1

[1,0,0,0] = -8

[1,1,0,1] = -3

To get the two's complement negative notation of an integer, you take the number in binary.

You then flip the bits, and add one (with carry) to the result.

For example:

[0,0,1,0] = 2 in base 10

[1,1,0,1] <- Flip the bits

Add 1 (with carry):

[1,1,1,0] = -2

The output array must have the same length as the input array.
*/

//***************Solution********************
namespace Solution{
  class Kata{
        public static int[] positive2Negative(int[] bin){
          //xor 1
          for(int i = 0; i < bin.Length; i++)
            bin[i] ^= 1;
          
          for(int j = bin.Length - 1; j >= 0; j--){
            bin[j] = (bin[j] ^ 1) & 1;
            if(bin[j]==1)
              break;
          }
           return bin;
        }
    }
}


//linq
using System.Linq;

namespace Solution
{
  class Kata
  {
    public static int[] positive2Negative(int[] binaryArray)
    {
      return binaryArray.Select((n, i) => binaryArray[(i + 1)..].Sum() > 0 ? 1 - n : n).ToArray();
    }
  }
}
//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  [TestFixture]
  public class SolutionTest
  {
    int[] Test1 = new int[] {0,0,0,0};
    int[] Test2 = new int[] {0,0,1,0};
    int[] Test3 = new int[] {0,0,1,1};
    int[] Test4 = new int[] {0,1,0,0};
    int[] Test5 = new int[] {0, 1, 0, 0, 1};


    [Test]
    public void BasicTesting()
    {
      Assert.AreEqual(Test1 , Kata.positive2Negative(Test1));
      Assert.AreEqual(new int[] {1,1,1,0} , Kata.positive2Negative(Test2));
      Assert.AreEqual(new int[] {1,1,0,1} , Kata.positive2Negative(Test3));
      Assert.AreEqual(new int[] {1,1,0,0} , Kata.positive2Negative(Test4));
      Assert.AreEqual(new int[] {1, 0, 1, 1, 1} , Kata.positive2Negative(Test5));
    }
	[Test]
    public void RandomTesting()
    {
      Random rnd = new Random();
      for (int i = 0; i < 25; i++)
      {
        int[] rndBin = randomBinary(rnd);
        Assert.AreEqual(positive2Negative(rndBin), Kata.positive2Negative(rndBin));
      }
    }
        public int[] randomBinary(Random rnd)
        {
            int[] binary = new int[rnd.Next(10)];
            if(binary.Length==0) return binary;
            binary[0] = 0;
            for (int i = 1; i < binary.Length; i++)
            {
                if (rnd.Next(10)%2==0)
                {
                    binary[i] = 0;
                }
                else
                {
                    binary[i] = 1;
                }
            }
            return binary;
        }
        
        public static int[] positive2Negative(int[] binaryArray)
        {
            int[] rtnInts = new int[binaryArray.Length];
            for (int i = 0; i < binaryArray.Length; i++)
            {
                if (binaryArray[i]==0)
                {
                    rtnInts[i] = 1;
                }
                else
                {
                    rtnInts[i] = 0;
                }
            }
            for (int i = rtnInts.Length -1; i >=0; i--)
            {
                if (rtnInts[i] == 0)
                {
                    rtnInts[i] = 1;
                    break;
                }
                else
                {
                    rtnInts[i] = 0;
                }
            }
            return rtnInts;
        }
    
  }
}
