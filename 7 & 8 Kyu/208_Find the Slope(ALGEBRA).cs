/*Challenge link:https://www.codewars.com/kata/55a75e2d0803fea18f00009d/train/csharp
Question:
Given an array of 4 integers
[a,b,c,d] representing two points (a, b) and (c, d), return a string representation of the slope of the line joining these two points.

For an undefined slope (division by 0), return undefined . Note that the "undefined" is case-sensitive.

   a:x1
   b:y1
   c:x2
   d:y2
Assume that [a,b,c,d] and the answer are all integers (no floating numbers!). Slope: https://en.wikipedia.org/wiki/Slope


*/

//***************Solution********************
//try find the slope using the slope formula, return the result in string.
//catch if the slope formula is trying to divide by zero, return underfined.
using System;
public class Slope{
  public String slope(int[] p){
    try{
      return ((p[1] - p[3]) / (p[0] - p[2])).ToString();
      }
    catch (DivideByZeroException){
      return "undefined";
    }
    }
}
//solution 2
//check if points index 2 is equal to points index 0, if so return "undefined" else return the slope in string.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System;
public class Slope
{

  public String slope(int[] points)
    {
    return points[2]==points[0] ? "undefined" : ((points[3]-points[1])/(points[2]-points[0])).ToString();
    }

}
//****************Sample Test*****************
using System;
using NUnit.Framework;
[TestFixture]
public class SlopeTest
{
[Test]
	public void test1() 
  {
  
    Slope s=new Slope();

    int[] test1={12,-18,-15,-18};
    int[] test2={3,-20,5,8};
    int[] test3={17,-3,17,8};
    int[] test4={1,-19,-2,-7};
    int[] test5={19,3,20,3};
    int[] test6={6,-12,15,-3};
    int[] test7={15,-3,15,-3};
    int[] test8={9,3,19,-17};
    
    int[] test9={1,24,2,88};
    int[] test10={4,384,8,768};
    int[] test11={4,16,4,18};
    int[] test12={7,28,9,64};
    int[] test13={18,-36,12,36};
    int[] test14={36,580,42,40};
    int[] test15={1,2,2,6};
    int[] test16={-6,57,-6,84};
    int[] test17={92,12,96,64};
    int[] test18={1,2,2,6};
    int[] test19={90,54,90,2};
    int[] test20={3,6,4,9};
    int[] test21={-2,-5,2,3};
    int[] test22={3,3,2,0};
    int[] test23={6,-12,15,-3};
    int[] test24={36,80,36,42};
    int[] test25={16,8,32,8};
    
	 Assert.AreEqual("0",s.slope(test1));
   Assert.AreEqual("14",s.slope(test2));
   Assert.AreEqual("undefined",s.slope(test3));
   Assert.AreEqual("-4",s.slope(test4));
   Assert.AreEqual("0",s.slope(test5));
   Assert.AreEqual("1",s.slope(test6));
   Assert.AreEqual("undefined",s.slope(test7));
   Assert.AreEqual("-2",s.slope(test8));
   
   Assert.AreEqual("64",s.slope(test9));
	 Assert.AreEqual("96",s.slope(test10));
	 Assert.AreEqual("undefined",s.slope(test11));
 	 Assert.AreEqual("18",s.slope(test12));
	 Assert.AreEqual("-12",s.slope(test13));
	 Assert.AreEqual("-90",s.slope(test14));
	 Assert.AreEqual("4",s.slope(test15));
	 Assert.AreEqual("undefined",s.slope(test16));
	 Assert.AreEqual("13",s.slope(test17));
 	 Assert.AreEqual("4",s.slope(test18));
	 Assert.AreEqual("undefined",s.slope(test19));
	 Assert.AreEqual("3",s.slope(test20));
	 Assert.AreEqual("2",s.slope(test21));
   Assert.AreEqual("3",s.slope(test22));
	 Assert.AreEqual("1",s.slope(test23));
   Assert.AreEqual("undefined",s.slope(test24));
	 Assert.AreEqual("0",s.slope(test25));

	}
  
}
