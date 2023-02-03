/*Challenge link:https://www.codewars.com/kata/56484848ba95170a8000004d/train/csharp
Question:
In John''s car the GPS records every s seconds the distance travelled from an origin (distances are measured in an arbitrary but consistent unit). For example, below is part of a record with s = 15:

x = [0.0, 0.19, 0.5, 0.75, 1.0, 1.25, 1.5, 1.75, 2.0, 2.25]
The sections are:

0.0-0.19, 0.19-0.5, 0.5-0.75, 0.75-1.0, 1.0-1.25, 1.25-1.50, 1.5-1.75, 1.75-2.0, 2.0-2.25
We can calculate John's average hourly speed on every section and we get:

[45.6, 74.4, 60.0, 60.0, 60.0, 60.0, 60.0, 60.0, 60.0]
Given s and x the task is to return as an integer the *floor* of the maximum average speed per hour obtained on the sections of x. If x length is less than or equal to 1 return 0 since the car didn't move.

Example:
With the above data your function gps(s, x) should return 74

Note
With floats it can happen that results depends on the operations order. To calculate hourly speed you can use:

 (3600 * delta_distance) / s.

Happy coding!
*/

//***************Solution********************

// check if length is less than or equal to 1, if true return 0
// loop each element in x, find the difference between the next index of x and the current index of x, apply formula
// find the max value in the list, then floor the result and return it.
using System;
using System.Linq;
using System.Collections.Generic;

public class GpsSpeed {
    
    public static int Gps(int s, double[] x) {
      if(x.Length <=1) return 0;
      var values = new List<double>{ };
      
      for(int i = 0; i < x.Length-1; i++){
        values.Add((x[i+1] - x[i]) * 3600 / s);
      }
      return (int)Math.Floor(values.Max());
    }
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public static class GpsSpeedTests {

    private static Random rnd = new Random();

    private static void testing(long act, long exp)
    {
        long r = Math.Abs(act - exp);
        bool inrange = r <= 1;
        if (inrange == false) {
            string specifier = "#.0";
            Console.WriteLine("abs(actual - expected) must be <= 1 but was " + r.ToString(specifier));
        }
        Assert.AreEqual(true, inrange);         
    }
[Test]
    public static void test1() {
        Console.WriteLine("Testing Gps");
        double[] x = new double[] {0.0, 0.23, 0.46, 0.69, 0.92, 1.15, 1.38, 1.61};
        testing(GpsSpeed.Gps(20, x), 41);
        x = new double[] {0.0, 0.11, 0.22, 0.33, 0.44, 0.65, 1.08, 1.26, 1.68, 1.89, 2.1, 2.31, 2.52, 3.25};
        testing(GpsSpeed.Gps(12, x), 219);
        x = new double[] {0.0, 0.18, 0.36, 0.54, 0.72, 1.05, 1.26, 1.47, 1.92, 2.16, 2.4, 2.64, 2.88, 3.12, 3.36, 3.6, 3.84};
        testing(GpsSpeed.Gps(20, x), 80);
        x = new double[] {0.0, 0.01, 0.36, 0.6, 0.84, 1.05, 1.26, 1.47, 1.68, 1.89, 2.1, 2.31, 2.52, 2.73, 2.94, 3.15};
        testing(GpsSpeed.Gps(14, x), 90);
        x = new double[] {0.0, 0.02, 0.36, 0.54, 0.72, 0.9, 1.08, 1.26, 1.44, 1.62, 1.8};
        testing(GpsSpeed.Gps(17, x), 72);
        x = new double[] {0.0, 0.24, 0.48, 0.72, 0.96, 1.2, 1.44, 1.68, 1.92, 2.16, 2.4};
        testing(GpsSpeed.Gps(12, x), 72);
        x = new double[] {0.0, 0.02, 0.44, 0.66, 0.88, 1.1, 1.32, 1.54, 1.76};
        testing(GpsSpeed.Gps(17, x), 88);
        x = new double[] {0.0, 0.2, 0.4, 0.6, 0.8, 1.0, 1.32, 1.54, 1.76, 1.98, 2.2, 2.42, 2.76, 2.99, 3.22, 3.45};
        testing(GpsSpeed.Gps(16, x), 76);
        x = new double[] {0.0, 0.01, 0.36, 0.75, 1.0, 1.25, 1.5, 1.75, 2.0, 2.25, 2.5, 2.75, 3.0, 3.25, 3.5, 3.75, 4.0, 4.25, 4.5, 4.75};
        testing(GpsSpeed.Gps(17, x), 82);
        x = new double[] {0.0, 0.2, 0.4, 0.69, 0.92, 1.15, 1.38, 1.61, 1.92, 2.16, 2.4, 2.64, 2.88, 3.12, 3.36};
        testing(GpsSpeed.Gps(19, x), 58);
        x = new double[] {};
        testing(GpsSpeed.Gps(19, x), 0);
        x = new double[] {0.0};
        testing(GpsSpeed.Gps(19, x), 0);
    }
    //-----------------------
    private static double[] CalcX(int n) {
        double[] x = new double[n];
        x[0] = 0.0; int prev = 0;
        for (int i = 1; i < n; i++) {
            int v = rnd.Next(1, 25);
            while (v < prev) {
                v++;
            }
            prev = v;
            x[i] = i * v / 100.0;
        }
        return x;
    }
    
    public static int GpsSol(int s, double[] x) {
        if (x.Length <= 1) return 0;
        double mx = 1; double v = 0;
        for (int k = 0; k < x.Length - 1; k++) {
            v = (3600 * (x[k + 1] - x[k]) / s);
            if (v > mx) mx = v;
        }
        return (int)Math.Floor(mx);
    }
    //-----------------------
[Test]    
    public static void RandomTest() {
        Console.WriteLine("200 Random Tests");
        for (int i = 0; i < 200; i++) { 
            int n = rnd.Next(10, 25);
            double[] x = CalcX(n);
            int s = rnd.Next(12, 50);
            testing(GpsSpeed.Gps(s, x), GpsSol(s, x)); 
        }
    }
}  
