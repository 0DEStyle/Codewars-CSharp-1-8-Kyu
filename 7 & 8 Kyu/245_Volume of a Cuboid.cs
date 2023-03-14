/*Challenge link:https://www.codewars.com/kata/58261acb22be6e2ed800003a/train/csharp
Question:
Bob needs a fast way to calculate the volume of a cuboid with three values: the length, width and height of the cuboid. Write a function to help Bob with this calculation.
*/

//***************Solution********************
//apply formula
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Kata {
  public static double GetVolumeOfCuboid(double l, double w, double h) => l * w * h;
}

//****************Sample Test*****************
namespace Tester {
  using NUnit.Framework;
  using System.Reflection;
  using System.Linq;
  using System;

  [TestFixture]
  public class TestingGetVolumeOfCuboid
  {
    private static double GetVolumeOfCuboidTest(double length, double width, double height)
    {
      Type kataType = Type.GetType("Kata");
      object classObj = kataType.GetConstructor(Type.EmptyTypes).Invoke(new object[]{});
      object submitted;
      try
      {
        submitted = kataType.GetMethod("GetVolumeOfCuboid").Invoke(classObj, new object[]{length, width, height});
      }
      catch(NullReferenceException)
      {
        submitted = kataType.GetMethod("getVolumeOfCuboid").Invoke(classObj, new object[]{length, width, height});
      }
      return (double)submitted;
    }
    [Test]
    public void FixedTests() {
      Assert.AreEqual(60, GetVolumeOfCuboidTest(2,5,6), 0.00001, "Length: 2, Width: 5, Height: 6");
      Assert.AreEqual(94.5, GetVolumeOfCuboidTest(6.3,3,5), 0.00001, "Length: 6.3, Width: 3, Height: 5");
    }
    
    [Test]
    public void RandomTests() {
      Random rand = new Random();
      double[] lwh = new double[3];
      double answer = 0;
      
      for (int i = 0; i < 125; i++) {
        // Set length, width, and height to random numbers, then divide by one hundred
        
        lwh[0] = (double)rand.Next(0, 100000) / 100;
        lwh[1] = (double)rand.Next(0, 100000) / 100;
        lwh[2] = (double)rand.Next(0, 100000) / 100;
        
        answer = lwh[0] * lwh[1] *  lwh[2];
        
        Assert.AreEqual(answer, GetVolumeOfCuboidTest(lwh[0],lwh[1],lwh[2]), 0.00001, $"Length: {lwh[0]}, Width: {lwh[1]}, Height: {lwh[2]}");
      }
    }
  }
}
