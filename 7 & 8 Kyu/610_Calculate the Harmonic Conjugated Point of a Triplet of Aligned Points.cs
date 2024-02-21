/*Challenge link:https://www.codewars.com/kata/5600e00e42bcb7b9dc00014e/train/csharp
Question:
source: imgur.com
(see image in link)
The image shows how we can obtain the Harmonic Conjugated Point of three aligned points A, B, C.

We choose any point L, that is not in the line with A, B and C. We form the triangle ABL

Then we draw a line from point C that intersects the sides of this triangle at points M and N respectively.

We draw the diagonals of the quadrilateral ABNM; they are AN and BM and they intersect at point K

We unit, with a line L and K, and this line intersects the line of points A, B and C at point D

The point D is named the Conjugated Harmonic Point of the points A, B, C. You can get more knowledge related with this point at: (https://en.wikipedia.org/wiki/Projective_harmonic_conjugate)

If we apply the theorems of Ceva (https://en.wikipedia.org/wiki/Ceva%27s_theorem) and Menelaus (https://en.wikipedia.org/wiki/Menelaus%27_theorem) we will have this formula:

source: imgur.com

AC, in the above formula is the length of the segment of points A to C in this direction and its value is:

AC = xA - xC

Transform the above formula using the coordinates xA, xB, xC and xD

The task is to create a function harmon_pointTrip(), that receives three arguments, the coordinates of points xA, xB and xC, with values such that : xA < xB < xC, this function should output the coordinates of point D for each given triplet, such that

xA < xD < xB < xC, or to be clearer

let's see some cases:

HarmPoints(xA, xB, xC) ------> xD # the result should be expressed up to four
 decimals (rounded result)
HarmPoints(2, 10, 20) -----> 7.1429 # (2 < 7.1429 < 10 < 20, satisfies the constraint)
HarmPoints(3, 9, 18) -----> 6.75
Enjoy it and happy coding!!
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
/*
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨⬛⬜🟨🟨🟨🟨🟨⬛⬜🟨
🟨⬛⬛🟨🟨🟨🟨🟨⬛⬛🟨
🟨⬛⬛🟨🟨⬛🟨🟨⬛⬛🟨
🟥🟨🟨🟨🟨🟨🟨🟨🟨🟨🟥
🟥🟥🟨🟨🟨⬛🟨🟨🟨🟥🟥
🟥🟥🟨🟨⬛🟨⬛🟨🟨🟥🟥
🟥🟨🟨🟨🟨🟨🟨🟨🟨🟨🟥
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
*/
//ABL, CM & CN on AL & BL, MB intersection NA, LK intersection AC 
//(a-c)(b-d) / (a-d)(b-c) = -1
//rearrange
//d = (ac + bc - 2ab) / (2c - a - b);

//apply formula and round to 4dps
using static System.Math;

public class HarmonicPoints {
    public static double HarmPoints(double a, double b, double c) =>
      Round((a * c + b * c - 2 * a * b) / (2 * c - a - b), 4);
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public static class HarmonicPointsTests {

[Test]
    public static void test1() {
        Assert.AreEqual(9.3333, HarmonicPoints.HarmPoints(6, 10, 11));
        Assert.AreEqual(7.1429, HarmonicPoints.HarmPoints(2, 10, 20));
        Assert.AreEqual(6.75, HarmonicPoints.HarmPoints(3, 9, 18));
        Assert.AreEqual(9.00, HarmonicPoints.HarmPoints(4, 12, 24));
        Assert.AreEqual(15.00, HarmonicPoints.HarmPoints(5, 17, 20));
    }
 
    //-----------------------
    public static double HarmPointsSol(double a, double b, double c) {
        double d = (a*c +c*b - 2.0*a*b) / (2.0*c -b - a);
        return Math.Floor(d * 10000 +.5) / 10000;
    }
    //-----------------------
[Test]    
    public static void RandomTest() {
        Console.WriteLine("100 Random Tests");
        Random random = new Random();
        for (int i = 0; i < 100; i++) {
            int a = random.Next(1, 1000);     
            int b = random.Next(1001, 2500);   
            int c = random.Next(2501, 5000); 
            Assert.AreEqual(HarmPointsSol(a, b, c), HarmonicPoints.HarmPoints(a, b, c));
        }
    }    
    
}
