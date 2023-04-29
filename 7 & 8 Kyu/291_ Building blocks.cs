/*Challenge link:https://www.codewars.com/kata/55b75fcf67e558d3750000a3/train/csharp
Question:
Write a class Block that creates a block (Duh..)

Requirements
The constructor should take an array as an argument, this will contain 3 integers of the form [width, length, height] from which the Block should be created.

Define these methods:

`GetWidth()` return the width of the `Block`

`GetLength()` return the length of the `Block`

`GetHeight()` return the height of the `Block`

`GetVolume()` return the volume of the `Block`

`GetSurfaceArea()` return the surface area of the `Block`
Examples
    Block b = new Block(new int[]{2,4,6}) -> creates a `Block` object with a width of `2` a length of `4` and a height of `6`
    b.GetWidth() // -> 2
    
    b.GetLength() // -> 4
    
    b.GetHeight() // -> 6
    
    b.GetVolume() // -> 48
    
    b.GetSurfaceArea() // -> 88
Note: no error checking is needed

Any feedback would be much appreciated
*/

//***************Solution********************
//create private variables
//assign private variables using arguments
//access private variables and return result accordingly
class Block{
  private readonly int width;
  private readonly int length;
  private readonly int height;
  
  public Block(int[] args){
                width = args[0];
                length = args[1];
                height = args[2];
            }

  public int GetWidth() => width;
  public int GetLength() => length;
  public int GetHeight() => height;
  public int GetVolume() => width * length * height;
  public int GetSurfaceArea() => 2 * (width * length + length * height + height * width);
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class Tests
{
  [Test]
  public static void BasicTest()
  {
    for (int i = 1;i < 10; i++)
    {
      Block b = new Block(new int[]{i,i,i});
      Assert.AreEqual(i, b.GetWidth());
      Assert.AreEqual(i, b.GetLength());
      Assert.AreEqual(i, b.GetHeight());
      Assert.AreEqual(i*i*i, b.GetVolume());
      Assert.AreEqual(2*(3 * (i * i)), b.GetSurfaceArea());
    }
  }
  [Test]
  public static void RandomTests()
  {
    Random r = new Random();
    for (int i = 0; i < 20; i++)
    {
      int a = r.Next(1,100);
      int b = r.Next(1,100);
      int c = r.Next(1,100);
      Block block = new Block(new int[]{a,b,c});
      Assert.AreEqual(a, block.GetWidth());
      Assert.AreEqual(b, block.GetLength());
      Assert.AreEqual(c, block.GetHeight());
      Assert.AreEqual(a * b * c, block.GetVolume());
      Assert.AreEqual(2 * (a * b + a * c + b * c), block.GetSurfaceArea());
    }
  }
}
