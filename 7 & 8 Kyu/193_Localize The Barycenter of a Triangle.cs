/*Challenge link:https://www.codewars.com/kata/5601c5f6ba804403c7000004/train/csharp
Question:
source: imgur.com (for image, see https://www.codewars.com/kata/5601c5f6ba804403c7000004/train/csharp)

The medians of a triangle are the segments that unit the vertices with the midpoint of their opposite sides. The three medians of a triangle intersect at the same point, called the barycenter or the centroid. Given a triangle, defined by the cartesian coordinates of its vertices we need to localize its barycenter or centroid.

The function bar_triang() or barTriang or bar-triang, receives the coordinates of the three vertices A, B and C  as three different arguments and outputs the coordinates of the barycenter O in an array [xO, yO]

This is how our asked function should work: the result of the coordinates should be expressed up to four decimals, (rounded result).

You know that the coordinates of the barycenter are given by the following formulas.

source: imgur.com (for image, see https://www.codewars.com/kata/5601c5f6ba804403c7000004/train/csharp)

For additional information about this important point of a triangle see at: (https://en.wikipedia.org/wiki/Centroid)

Let's see some cases:

bar_triang([4, 6], [12, 4], [10, 10]) ------> [8.6667, 6.6667]

bar_triang([4, 2], [12, 2], [6, 10] ------> [7.3333, 4.6667]
The given points form a real or a degenerate triangle but in each case the above formulas can be used.

Enjoy it and happy coding!!
*/

//***************Solution********************
//apply algorithm
//round the solution to 4 decimal place using Math.Round(num,4)
//return the result with data structure: new double[]{double,double}

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
public class Barycenter{
	public static double[] BarTriang(double[] x, double[] y, double[] z) => 
    new double []{Math.Round((x[0] + y[0] + z[0])/3,4),Math.Round((x[1] + y[1] + z[1])/3,4)}; 
}


//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public static class BarycenterTests {

    private static Random rnd = new Random();

[Test]
    public static void test1() {
    	Console.WriteLine("Fixed Tests");  
        Assert.AreEqual(new double[] {8.6667, 6.6667}, Barycenter.BarTriang(
        	new double[]{4,6}, new double[]{12,4}, new double[]{10,10}));
        Assert.AreEqual(new double[] {7.3333, 4.6667}, Barycenter.BarTriang(
          new double[]{4,2}, new double[]{12,2}, new double[]{6,10}));
        Assert.AreEqual(new double[] {9.3333, 5.3333}, Barycenter.BarTriang(
        	new double[]{4,8}, new double[]{8,2}, new double[]{16,6}));
        Assert.AreEqual(new double[] {0.0, 3.0}, Barycenter.BarTriang(
                new double[]{0,0}, new double[]{1,3}, new double[]{-1,6}));
        Assert.AreEqual(new double[] {3.0, 0.0}, Barycenter.BarTriang(
                new double[]{0,0}, new double[]{1,6}, new double[]{8,-6}));
    }
    
    //-----------------------
    public static double round4Sol(double d)
	  {
		  return Math.Floor(d * 10000 +.5) / 10000;
	  }
	  public static double[] BarTriangSol(double[] x, double[] y, double[] z)
	  {
		  return new double[]{round4Sol((x[0]+y[0]+z[0])/3.0), round4Sol((x[1]+y[1]+z[1])/3.0)};
	  }
    //-----------------------
[Test]    
    public static void RandomTest() {
      Console.WriteLine("100 Random Tests");
      for (int i = 0; i < 100; i++) { 
            double a = rnd.Next(1, 8);
            double b = rnd.Next(11, 15);
            double c = rnd.Next(12, 20);
            Assert.AreEqual(BarycenterTests.BarTriangSol(
                new double[]{a,0}, new double[]{c+0.25,0.5}, new double[]{20,b+0.5}), 
                Barycenter.BarTriang(new double[]{a,0}, new double[]{c+0.25,0.5}, new double[]{20,b+0.5}));
      }
    }  
}
