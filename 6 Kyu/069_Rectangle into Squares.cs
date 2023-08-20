/*Challenge link:https://www.codewars.com/kata/55466989aeecab5aac00003e/train/csharp
Question:
The drawing below gives an idea of how to cut a given "true" rectangle into squares ("true" rectangle meaning that the two dimensions are different).

//see image in the link above

alternative text

Can you translate this drawing into an algorithm?

You will be given two dimensions

a positive integer length
a positive integer width
You will return a collection or a string (depending on the language; Shell bash, PowerShell, Pascal and Fortran return a string) with the size of each of the squares.

Examples in general form:
(depending on the language)

  sqInRect(5, 3) should return [3, 2, 1, 1]
  sqInRect(3, 5) should return [3, 2, 1, 1]
  
  You can see examples for your language in **"SAMPLE TESTS".**
Notes:
lng == wdth as a starting case would be an entirely different problem and the drawing is planned to be interpreted with lng != wdth. (See kata, Square into Squares. Protect trees! http://www.codewars.com/kata/54eb33e5bc1a25440d000891 for this problem).

When the initial parameters are so that lng == wdth, the solution [lng] would be the most obvious but not in the spirit of this kata so, in that case, return None/nil/null/Nothing or return {} with C++, Array() with Scala, [] with Perl, Raku.

In that case the returned structure of C will have its sz component equal to 0.

Return the string "nil" with Bash, PowerShell, Pascal and Fortran.
*/

//***************Solution********************
using System.Collections.Generic;
using System.Linq;

public class SqInRect{
  //check if length is the same as width, if so return null, else go to EnumerateSquares
	public static List<int> sqInRect(int lng, int wdth) => lng == wdth ? null : EnumerateSquares(lng, wdth).ToList();
  
  public static IEnumerable<int> EnumerateSquares(int length, int width){
    //check until length is equal to width
    //if length is greater than width return width, then subtract by 1 for next iteration
    //else return length, and subtract by 1 for next iteration.
    while (length != width){
      if (length > width){
        yield return width;
        length -= width;
      }
      else{
        yield return length;
        width -= length;
      }
    }
    yield return length;
  }
}

//****************Sample Test*****************
using System;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class SqInRectTests {

[Test]
  public void Test1() {
    List<int> r = new List<int>{3,2,1,1};
    Assert.AreEqual(r, SqInRect.sqInRect(5, 3));
  }
[Test]
  public void Test2() {
    List<int> r = new List<int> {3,2,1,1};
    Assert.AreEqual(r, SqInRect.sqInRect(3, 5));
  }
[Test]
  public void Test3() {
    Assert.AreEqual(null, SqInRect.sqInRect(5, 5));
  }
[Test]
  public void Test4() {
    List<int> r = new List<int> {14, 6, 6, 2, 2, 2};
    Assert.AreEqual(r, SqInRect.sqInRect(20, 14));
  }
[Test]
  public void Test5() {
    List<int> r = new List<int> {14, 6, 6, 2, 2, 2};
    Assert.AreEqual(r, SqInRect.sqInRect(14, 20));
  }
[Test]
  public void Test6() {
    List<int> r = new List<int> {32, 32, 32, 32, 32, 32, 32, 16, 16};
    Assert.AreEqual(r, SqInRect.sqInRect(240, 32));
  }
[Test]
  public void Test7() {
    List<int> r = new List<int> {230, 230, 165, 65, 65, 35, 30, 5, 5, 5, 5, 5, 5};
    Assert.AreEqual(r, SqInRect.sqInRect(625, 230));
  }
[Test]
  public void Test8() {
    List<int> r = new List<int> {230, 230, 230, 41, 41, 41, 41, 41, 25, 16, 9, 7, 2, 2, 2, 1, 1};
    Assert.AreEqual(r, SqInRect.sqInRect(731, 230));
  }
[Test]
  public void Test9() {
    List<int> r = new List<int> {14, 14, 9, 5, 4, 1, 1, 1, 1};
    Assert.AreEqual(r, SqInRect.sqInRect(37, 14));
  }
[Test]
  public void Test10() {
    List<int> r = new List<int> {1, 1};
    Assert.AreEqual(r, SqInRect.sqInRect(2, 1));
  }

public static List<int> sqInRectTest(int lng, int wdth) {
    if (lng == wdth) return null;
    if (lng < wdth) {
        int tmp = lng;
        lng = wdth;
        wdth = tmp;
    }
    List<int> res = new List<int>();
    while (lng != wdth) {
        res.Add(wdth);
        lng -= wdth;
        if (lng < wdth) {
            int tmp = lng;
            lng = wdth;
            wdth = tmp;
        }
    }
    res.Add(wdth);
    return res;
}
    
[Test]
  public void RandomTests() {
    Random rnd = new Random();
    int[] someLengths = new int[] {
				55,89,144,233,377,610,987,1597,2584,418,
        676,41,99,56,78,907,561,453,32,12,
        24,13,59,90,21,66,77,88,62,11};
    int[] someWidths = new int[] {
				22,75,121,340,52,78,157,88,55,102,
        120,73,37,44,565,1002,43,90,72,10,
        24,13,59,32,34,51,12,68,34,100};
	                		   
    for (int k = 0; k < 20; k++) {
        int rn = rnd.Next(0, someLengths.Length - 1);
        int f1 = someLengths[rn]; 
        int f2 = someWidths[rn];
        Console.WriteLine("Random test " + k);
        Assert.AreEqual(SqInRectTests.sqInRectTest(f1, f2), SqInRect.sqInRect(f1, f2));
    }
  }
}
