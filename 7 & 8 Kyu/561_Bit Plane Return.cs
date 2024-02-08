/*Challenge link:https://www.codewars.com/kata/5a1a00dcba2a14738a000029/train/csharp
Question:
A greyscale digital image is supplied as a matrix of values between 0 (black) and 255 (white), each being the decimal representation of an 8-bit value. For example: a mid-grey is represented as 127 in decimal and 01111111 in binary; the subsequent value 128, is 10000000 in binary; an example of a 4 pixel digital image is: [[0, 63], [127, 255]] in decimal, or [[00000000, 00111111], [01111111, 11111111]] binary.

Example of bit planes derived from 8-bit image

A bit plane is a set of bits corresponding to a given bit position for each of the binary values of an image matrix. For the 4 pixel example ([[0, 63], [127, 255]]) above, bit plane 3 would be a matrix of values corresponding to the bit value at index 5 for each value of the input matrix == [[0, 1], [1, 1]]. The binary value index is mapped to the bit plane as follows:

plane 0 => least significant bit / right-most bit == [7];

plane 1 => [6] ... 6 => [1]... ;

plane 7 => most significant bit / left-most bit == [0]

The object of this kata is to return the specified bit plane (plane) for the supplied image matrix(image). For this kata you will not be supplied an empty matrix (there will always be at least one pixel) and the values within each array will always be integers between 0 and 255 inclusive. The value specified in plane will be between 0 and 7 inclusive.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//ref: https://www.youtube.com/watch?v=IU71a3jQE3w
//x and y are cuurent elements, row and col (2d array)
//plane 0 - 7 => lsb - msb
//from img, select cell, right bitshift y by plane & 1, convert to byte
//store both x and y as array and return result.
using System.Linq;

public static class Kata{
  public static byte[][] BitSlice(byte[][] img, int plane) => 
    img.Select(x => x.Select(y => (byte)(y >> plane & 1)).ToArray())
       .ToArray();
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;
  
  public static class Solution
  {
    public static byte[][] BitSlice(byte[][] image, int plane)
    {
      return image.Select(l => l.Select(p => (byte)(p >> plane & 1)).ToArray()).ToArray();
    }
  }
  
  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void SampleTest()
    {
      Assert.That(Kata.BitSlice(new byte[][] 
                                {
                                   new byte[] {68, 69, 75, 100},
                                   new byte[] {71, 82, 106, 117},
                                   new byte[] {119, 117, 126, 132},
                                   new byte[] {116, 127, 146, 111}
                                }, 3),
                  Is.EqualTo(new byte[][] 
                                {
                                   new byte[] {0, 0, 1, 0},
                                   new byte[] {0, 0, 1, 0},
                                   new byte[] {0, 0, 1, 0},
                                   new byte[] {0, 1, 0, 1}
                                }), "Should return bit plane 3");
      
      Assert.That(Kata.BitSlice(new byte[][] 
                                {
                                   new byte[] {24, 35, 49, 51, 49},
                                   new byte[] {27, 38, 47, 50, 50},
                                   new byte[] {32, 39, 47, 50, 53},
                                   new byte[] {38, 45, 49, 51, 53},
                                   new byte[] {43, 49, 49, 50, 51}
                                }, 2),
                  Is.EqualTo(new byte[][] 
                                {
                                   new byte[] {0, 0, 0, 0, 0},
                                   new byte[] {0, 1, 1, 0, 0},
                                   new byte[] {0, 1, 1, 0, 1},
                                   new byte[] {1, 1, 0, 0, 1},
                                   new byte[] {0, 0, 0, 0, 0}
                                }), "Should return bit plane 2");
      
      Assert.That(Kata.BitSlice(new byte[][] 
                                {
                                   new byte[] {19, 27, 38, 46, 60, 63},
                                   new byte[] {19, 22, 30, 38, 55, 58},
                                   new byte[] {22, 22, 22, 39, 45, 54},
                                   new byte[] {22, 22, 21, 45, 54, 63},
                                   new byte[] {21, 19, 21, 36, 51, 64},
                                   new byte[] {21, 21, 19, 24, 45, 60}
                                }, 7),
                  Is.EqualTo(new byte[][] 
                                {
                                   new byte[] {0, 0, 0, 0, 0, 0},
                                   new byte[] {0, 0, 0, 0, 0, 0},
                                   new byte[] {0, 0, 0, 0, 0, 0},
                                   new byte[] {0, 0, 0, 0, 0, 0},
                                   new byte[] {0, 0, 0, 0, 0, 0},
                                   new byte[] {0, 0, 0, 0, 0, 0}
                                }), "Should return bit plane 7");
      
      Assert.That(Kata.BitSlice(new byte[][] 
                                {
                                   new byte[] {73, 147, 208, 216, 216, 209, 175, 158},
                                   new byte[] {66, 93, 158, 199, 206, 190, 185, 136},
                                   new byte[] {65, 71, 123, 180, 205, 189, 170, 141},
                                   new byte[] {63, 45, 76, 149, 198, 183, 153, 139},
                                   new byte[] {61, 39, 51, 120, 185, 181, 149, 130},
                                   new byte[] {58, 47, 49, 96, 161, 175, 158, 121},
                                   new byte[] {49, 46, 46, 70, 127, 158, 160, 110},
                                   new byte[] {36, 39, 42, 51, 99, 141, 141, 96}
                                }, 0),
                  Is.EqualTo(new byte[][] 
                                {
                                   new byte[] {1, 1, 0, 0, 0, 1, 1, 0},
                                   new byte[] {0, 1, 0, 1, 0, 0, 1, 0},
                                   new byte[] {1, 1, 1, 0, 1, 1, 0, 1},
                                   new byte[] {1, 1, 0, 1, 0, 1, 1, 1},
                                   new byte[] {1, 1, 1, 0, 1, 1, 1, 0},
                                   new byte[] {0, 1, 1, 0, 1, 1, 0, 1},
                                   new byte[] {1, 0, 0, 0, 1, 0, 0, 0},
                                   new byte[] {0, 1, 0, 1, 1, 1, 1, 0}
                                }), "Should return bit plane 7");
    }
    
    [Test]
    public void RandomTest()
    {
      Random rnd = new Random();
      
      for (int i = 0; i < 100; ++i)
      {
        int height = rnd.Next(1, 20);
        int width = rnd.Next(1, 20);
        int plane = rnd.Next(0, 8);
        byte[][] image = new byte[height][].Select(_ => new byte[width].Select(__ => (byte)rnd.Next()).ToArray()).ToArray();
        
        Assert.That(Kata.BitSlice(image, plane), Is.EqualTo(Solution.BitSlice(image, plane)));
      }
    }
  }
}
