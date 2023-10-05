/*Challenge link:https://www.codewars.com/kata/557e8a141ca1f4caa70000a6/train/csharp
Question:
Description:
A triangle number is a number where n objects form an equilateral triangle (it's a bit hard to explain). For example, 6 is a triangle number because you can arrange 6 objects into an equilateral triangle:

  1
 2 3
4 5 6
8 is not a triangle number because 8 objects do not form an equilateral triangle:

   1
  2 3
 4 5 6
7 8
In other words, the nth triangle number is equal to the sum of the n natural numbers from 1 to n.

Your task:
Check if a given input is a valid triangle number. Return true if it is, false if it is not (note that any non-integers, including non-number types, are not triangle numbers).

You are encouraged to develop an effective algorithm: test cases include really big numbers.

Assumptions:
You may assume that the given input, if it is a number, is always positive.

Notes:
0 and 1 are triangle numbers.
*/

//***************Solution********************

//algorithme square root(1 + 8 * number) 
//mod 1 to see if reminder is 0, return boolean value accordingly;
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using static System.Math;

public class TriangleNumbers {
	public static bool isTriangleNumber(long number) =>Sqrt(1 + 8 * number) % 1 == 0 ;
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class TriangleNumbersTests {
    
    public static bool solution(long number) {
		  long currentTriangle = 0;
  		long i = 0;
 		   while (currentTriangle < number) {
    		  currentTriangle += i;
    		  i += 1;
		  }
  		return (currentTriangle == number);
	  }
    public static void rtests() {
      Random r = new Random();
       for (int i = 0; i < 20; i++) {
         int x = r.Next(0, 2500);
         int y = r.Next(0, 2);
         long n = x * (x + 1) /2 + y;
         Console.WriteLine("Is triangle number n: " + n);
         Assert.AreEqual(TriangleNumbersTests.solution(n), TriangleNumbers.isTriangleNumber(n));
       }
    }

[Test]
  public void Test1() {
    Assert.AreEqual(true, TriangleNumbers.isTriangleNumber(125250));
  }
[Test]
  public void Test2() {
    Assert.AreEqual(true, TriangleNumbers.isTriangleNumber(3126250));
  }
[Test]
  public void Test3() {
    Assert.AreEqual(true, TriangleNumbers.isTriangleNumber(312537501));
  }
[Test]
  public void Test4() {
    Assert.AreEqual(false, TriangleNumbers.isTriangleNumber(617717));
  }
[Test]
  public void Test5() {
    Assert.AreEqual(true, TriangleNumbers.isTriangleNumber(61721605));
  }
[Test]
    public void Test6() {
    TriangleNumbersTests.rtests();
  }  
}
