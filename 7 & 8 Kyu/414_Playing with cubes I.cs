/*Challenge link:https://www.codewars.com/kata/55c0a79e20be94c91400014b/train/csharp
Question:
Create a public class called Cube without a constructor which gets one single private integer variable Side, a getter GetSide() and a setter SetSide(int num) method for this property. Actually, getter and setter methods are not the common way to write this code in C#. In the next kata of this series, we gonna refactor the code and make it a bit more professional...

Notes:

There's no need to check for negative values!
initialise the side to 0.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//get and set side of a cube
public class Cube{
  private int side = 0;
  public int GetSide() => side;
  public void SetSide(int n) => side = n; 
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class Test
{
  [Test]
  public static void FixedTest()
  {
    Cube c = new Cube();
    Assert.AreEqual(0, c.GetSide(), "when not set before, Side should be 0");
    c.SetSide(5);
    Assert.AreEqual(5, c.GetSide(), "Should return 5");
    c.SetSide(-1);
    Assert.AreEqual(-1, c.GetSide(), "Should return -1");
  }
  
  [Test]
  public static void RandomTest()
  {
    Random r = new Random();
    for(int i = 0; i < 100; i++)
    {
      int num = r.Next(1000)-500;
      Cube c = new Cube();
      c.SetSide(num);
      Assert.AreEqual(num, c.GetSide(), "Should return " +num);
    }
  }
}
