/*Challenge link:https://www.codewars.com/kata/554f76dca89983cc400000bb/train/csharp
Question:
In mathematics, a Diophantine equation is a polynomial equation, usually with two or more unknowns, such that only the integer solutions are sought or studied.

In this kata we want to find all integers x, y (x >= 0, y >= 0) solutions of a diophantine equation of the form:

x2 - 4 * y2 = n
(where the unknowns are x and y, and n is a given positive number) in decreasing order of the positive xi.

If there is no solution return [] or "[]" or "". (See "RUN SAMPLE TESTS" for examples of returns).

Examples:
solEquaStr(90005) --> "[[45003, 22501], [9003, 4499], [981, 467], [309, 37]]"
solEquaStr(90002) --> "[]"
Hint:
x2 - 4 * y2 = (x - 2*y) * (x + 2*y)
*/

//***************Solution********************

using System;
using System.Collections.Generic;
using System.Linq;

public class Dioph {
  	public static string solEquaStr(long n){
      
      //create ans list with long variables.
      //m as square root of n in int format
    		var ans = new List<(long x, long y)>();
        var m = (int)Math.Sqrt(n);
      
      // x^2 - 4y^2 = (x - 2y)(x + 2y)
      // Thus we can find all solutions to x^2 - 4y^2 = n
      //start from 1, up to i less than or equal to m
        for (var i = 1; i <= m; i++) {
          
          //set d to n / i
            var d = (double)n / i;
          
          //find x and y from (x - 2y)(x + 2y)
            var x = (d + i) / 2;
            var y = (d - i) / 4;
          
          //check validation, if conditions are met, add result to answer.
            if (d % 1 == 0 && x % 1 == 0 & y % 1 == 0)
                ans.Add(((long)x, (long)y));
        }
      //string interpolation to format the result
        return $"[{string.Join(", ", ans.Select(p => $"[{p.x}, {p.y}]"))}]";
  	}
}
//****************Sample Test*****************
using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public static class DiophTests
{

    private static void testing(long n, string expected) 
    {
        string actual = Dioph.solEquaStr(n);
        Assert.AreEqual(expected, actual);
    }
    
[Test]
    public static void test1() 
    {        
        Console.WriteLine("Basic Tests");
        Assert.AreEqual("[[3, 1]]", Dioph.solEquaStr(5));
        Assert.AreEqual("[[4, 1]]", Dioph.solEquaStr(12));   
        Assert.AreEqual("[[7, 3]]", Dioph.solEquaStr(13));
        Assert.AreEqual("[[4, 0]]", Dioph.solEquaStr(16));     
        Assert.AreEqual("[[9, 4]]", Dioph.solEquaStr(17));   
        Assert.AreEqual("[[6, 2]]", Dioph.solEquaStr(20));      
        Assert.AreEqual("[[4501, 2250]]", Dioph.solEquaStr(9001));
        Assert.AreEqual("[[2252, 1125]]", Dioph.solEquaStr(9004));
        Assert.AreEqual("[[4503, 2251], [903, 449]]", Dioph.solEquaStr(9005));
        Assert.AreEqual("[[1128, 562]]", Dioph.solEquaStr(9008));
        
        string a = "[[4505, 2252], [1503, 750], [647, 320], [505, 248], [415, 202], [353, 170], [225, 102], [153, 60], [135, 48], [103, 20], [97, 10], [95, 2]]"; 
        Assert.AreEqual(a, Dioph.solEquaStr(9009));
        Assert.AreEqual("[[45001, 22500]]", Dioph.solEquaStr(90001));
        Assert.AreEqual("[]", Dioph.solEquaStr(90002));
        Assert.AreEqual("[[22502, 11250]]", Dioph.solEquaStr(90004));
        Assert.AreEqual("[[45003, 22501], [9003, 4499], [981, 467], [309, 37]]", Dioph.solEquaStr(90005));
        Assert.AreEqual("[[45005, 22502], [15003, 7500], [5005, 2498], [653, 290], [397, 130], [315, 48]]", Dioph.solEquaStr(90009));
        Assert.AreEqual("[[112502, 56249], [56254, 28123], [37506, 18747], [22510, 11245], [18762, 9369], [12518, 6241], [11270, 5615], [7530, 3735], [6286, 3107], [4550, 2225], [3810, 1845], [2590, 1205], [2350, 1075], [1650, 675], [1430, 535], [1150, 325], [1050, 225], [950, 25]]", Dioph.solEquaStr(900000));
        Assert.AreEqual("[[450001, 225000]]", Dioph.solEquaStr(900001));
        Assert.AreEqual("[[225002, 112500], [32150, 16068]]", Dioph.solEquaStr(900004));
        Assert.AreEqual("[[450003, 225001], [90003, 44999]]", Dioph.solEquaStr(900005));
        Assert.AreEqual("[[4500001, 2250000], [73801, 36870]]", Dioph.solEquaStr(9000001));
        Assert.AreEqual("[[2250002, 1125000], [173090, 86532], [132370, 66168], [10402, 4980]]", Dioph.solEquaStr(9000004));
        Assert.AreEqual("[[4500003, 2250001], [900003, 449999], [642861, 321427], [155187, 77579], [128589, 64277], [31107, 15481], [22269, 11033], [4941, 1963]]", Dioph.solEquaStr(9000005));
        Assert.AreEqual("[[45000001, 22500000], [6428575, 3214284], [3461545, 1730766], [494551, 247230]]", Dioph.solEquaStr(90000001));
        Assert.AreEqual("[[22500002, 11250000], [252898, 126360], [93602, 46560], [22498, 10200]]", Dioph.solEquaStr(90000004));
        Assert.AreEqual("[[450000005, 225000002], [150000003, 75000000], [50000005, 24999998], [26470597, 13235290], [8823555, 4411752], [2941253, 1470550]]", Dioph.solEquaStr(900000009));
        Assert.AreEqual("[[225000004, 112500001], [75000004, 37499999], [3358276, 1679071], [1119604, 559601]]", Dioph.solEquaStr(900000012));
        Assert.AreEqual("[[4500000021, 2250000010], [155172429, 77586200]]", Dioph.solEquaStr(9000000041L));
    }
    //-----------------------
     public static string solEquaStrTE(long n) {
            string res = "[";
            for (long i = 1; i < Math.Sqrt(n) + 1; i++) {
                if (n % i == 0) {
                    long p = i + (long)(n / i);
                    long q = (long)(n / i) - i;
                    if ((p % 2 == 0) && (q % 4 == 0)) {
                        string c = "[" + ((long)(p / 2)).ToString() + ", " + ((long)(q / 4)).ToString() + "], ";
                        res += c;
                    }
                }
            }
            if (res.Equals("["))
                return "[]";
            else return res.Substring(0, res.Length - 2) + "]";
    }
    //-----------------------
    private static void wTests1() 
    {
        for (int i = 0; i < 50; i++) {
            Random rnd = new Random();        
            long a = rnd.Next(500, 2000);
            long b = rnd.Next(5, 400);
            long v = a *a - 4 * b * b;
            long u = 0;
            if (v < 0) {u = -v;} else {u = v;}
            string ans = solEquaStrTE(u);
            Console.WriteLine("n " + u);
            Console.WriteLine("sol --> " + ans);
            testing(u, ans);
        }
    }
[Test] 
    public static void RandomTests() 
    { 
        Console.WriteLine("Random Tests*******");
        wTests1();
    } 
}
