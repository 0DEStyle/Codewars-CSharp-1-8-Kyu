/*Challenge link:https://www.codewars.com/kata/5b1cd19fcd206af728000056/train/csharp
Question:
Consider the sequence U(n, x) = x + 2x**2 + 3x**3 + .. + nx**n where x is a real number and n a positive integer.

When n goes to infinity and x has a correct value (ie x is in its domain of convergence D), U(n, x) goes to a finite limit m depending on x.

Usually given x we try to find m. Here we will try to find x (x real, 0 < x < 1) when m is given (m real, m > 0).

Let us call solve the function solve(m) which returns x such as U(n, x) goes to m when n goes to infinity.

Examples:
solve(2.0) returns 0.5 since U(n, 0.5) goes to 2 when n goes to infinity.

solve(8.0) returns 0.7034648345913732 since U(n, 0.7034648345913732) goes to 8 when n goes to infinity.

Note:
You pass the tests if abs(actual - expected) <= 1e-12
*/

//***************Solution********************
//apply formula
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using static System.Math;

public class S{
    public static double Solve(double m) =>  1/((1+2*m+Sqrt(1+4*m))/(2*m));
}
//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public static class STests {

    private static Random rnd = new Random();
    public static void assertFuzzy(double m, double expect)
    {
        double merr = 1e-12;
        Console.WriteLine("Testing " + m);
        double actual = S.Solve(m);
        Console.WriteLine("Actual: " + actual);
        Console.WriteLine("Expect: " + expect);
        bool inrange = Math.Abs(actual - expect) <= merr;
        if (inrange == false)
            Console.WriteLine("Expected must be near " + expect + ", got " + actual);
        Console.WriteLine("-");
        Assert.AreEqual(true, inrange);
    }

[Test]
    public static void test() {
        Console.WriteLine("Fixed Tests: solve"); 
        assertFuzzy(2.00, 5.000000000000e-01);
        assertFuzzy(4.00, 6.096117967978e-01);
        assertFuzzy(5.00, 6.417424305044e-01);
        assertFuzzy(6.00, 6.666666666667e-01);
        assertFuzzy(8.00, 7.034648345914e-01);
        assertFuzzy(10.00, 7.298437881284e-01);
        assertFuzzy(12.00, 7.500000000000e-01);
        assertFuzzy(13.00, 7.584573119507e-01);
        assertFuzzy(14.00, 7.660773415975e-01);
        assertFuzzy(17.00, 7.850992981495e-01);
        assertFuzzy(20.00, 8.000000000000e-01);
        assertFuzzy(50.00, 0.868225531212422);
        assertFuzzy(500000.00, 0.9985867860840736);
    }
    private static double solvePEQO(double m)
    {
        double s = Math.Sqrt(4 * m + 1);
        return (2 * m + 1 - s) / (2 * m);
    }
    
[Test]    
    public static void randomtesting()
    {
        Console.WriteLine("Random Tests: solve");
        for (int i = 0; i < 200; i++)
        {
            double m = rnd.Next(3, 500000);
            double exp = solvePEQO(m);
            assertFuzzy(m, exp);
        }
    }
}
