/*Challenge link:https://www.codewars.com/kata/588a3c3ef0fbc9c8e1000095/train/csharp
Question:
You must implement a function that returns the difference between the largest and the smallest value in a given list / array (lst) received as the parameter.

lst contains integers, that means it may contain some negative numbers
if lst is empty or contains a single element, return 0
lst is not sorted
[1, 2, 3, 4]   //  returns 3 because 4 -   1  == 3
[1, 2, 3, -4]  //  returns 7 because 3 - (-4) == 7
Have fun!
*/

//***************Solution********************
//check if array's length is greater or equal to 2, if so, find the difference between max and min
//else return 0
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
public class Kata{
  public static int MaxDiff(int[] lst) => lst.Length >= 2 ? lst.Max() - lst.Min() : 0;
}

//****************Sample Test*****************
namespace Tester {
  using NUnit.Framework;
  using System.Reflection;
  using System.Linq;
  using System;
  [TestFixture]
  public class TestingMaxDiff
  {
    private static int MaxDiffTest(int[] lst)
    {
      Type kataType = Type.GetType("Kata");
      string methodName = "MaxDiff";
      if(String.Format("{0}", kataType).Length == 0)
      {
        kataType = Type.GetType("kata");
        methodName = "maxDiff";
      }
      ConstructorInfo confo = kataType.GetConstructor(Type.EmptyTypes);
      object classObj = confo.Invoke(new object[]{});
      MethodInfo methfo = kataType.GetMethod(methodName);
      object submitted = methfo.Invoke(classObj, new object[]{lst});
      return (int)submitted;
    }
    [Test]
    public void FixedTests()
    {
      Assert.AreEqual( 6, MaxDiffTest(new[]{ 0, 1, 2, 3, 4, 5, 6 }));
      Assert.AreEqual(11, MaxDiffTest(new[] {-0, 1, 2, -3, 4, 5, -6}));
      Assert.AreEqual(16, MaxDiffTest(new[] {0, 1, 2, 3, 4, 5, 16}));
      Assert.AreEqual( 0, MaxDiffTest(new[] {16}));
      Assert.AreEqual( 0, MaxDiffTest(new int[] {}));
    }
    [Test]
    public void RandomTests()
    {
      Random rand = new Random();
      for(int i=0; i<100; i++)
      {
        int[] lst = Enumerable.Repeat(0, rand.Next(0, 100)).Select(a => rand.Next(-100, 100)).ToArray();
        int expected = lst.Length == 0 ? 0 : lst.Max() - lst.Min();
        int submitted = MaxDiffTest(lst);
        Assert.AreEqual(expected, submitted);
      }
    }
  }
}
