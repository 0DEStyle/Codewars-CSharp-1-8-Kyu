/*Challenge link:https://www.codewars.com/kata/5226eb40316b56c8d500030f/train/csharp
Question:
In mathematics, Pascal's triangle is a triangular array of the binomial coefficients expressed with formula


(nk)=n!k!(n−k)!\lparen {n \atop k} \rparen = \frac {n!} {k!(n-k)!}( 
k
n
​
 )= 
k!(n−k)!
n!
​

 
where n denotes a row of the triangle, and k is a position of a term in the row.

//please check the formula and image from the link above

Pascal's Triangle


You can read Wikipedia article on Pascal's Triangle for more information.

Task
Write a function that, given a depth n, returns n top rows of Pascal's Triangle flattened into a one-dimensional list/array.

Example:
n = 1: [1]
n = 2: [1,  1, 1]
n = 4: [1,  1, 1,  1, 2, 1,  1, 3, 3, 1]
Note
Beware of overflow. Requested terms of a triangle are guaranteed to fit into the returned type, but depending on seleced method of calculations, intermediate values can be larger.
*/

//***************Solution********************
using System.Collections.Generic;

public static class Kata{
    public static List<int> PascalsTriangle(int n){    
      //result list start with 1  
      List<int> res = new List<int>() { 1 };
      
      //if j is 0 or j is i-1, meaning first and last
      //add 1 to result
      //else res[res.Count - i] + res[res.Count - i + 1]
        for (int i = 2; i < n + 1; i++)
            for (int j = 0; j < i; j++)
                    res.Add(j == 0 || j == i - 1 ? 1 : res[res.Count - i] + res[res.Count - i + 1]);
        return res;
    }
} 

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class PascalsTriangleTests
{
    private static readonly int MAX_ROW = 30;
    private static readonly int[] TRIANGLE = new int[MAX_ROW * (MAX_ROW + 1) / 2];

    [OneTimeSetUp]
    public static void Precalculate()
    {
        Func<int, int, int> asLinear = (n, k) => n * (n + 1) / 2 + k;
        for (int i = 0; i < MAX_ROW; ++i)
        {
            for (int j = 0; j <= i; ++j)
            {
                int pos = asLinear(i, j);
                TRIANGLE[pos] = j == 0 || j == i ? 1 : TRIANGLE[asLinear(i - 1, j)] + TRIANGLE[asLinear(i - 1, j - 1)];
            }
        }
    }

    private static List<int> SliceUpToRow(int n)
    {
        return TRIANGLE.Take(n * (n + 1) / 2).ToList();
    }

    [Test]
    public void Level1()
    {
        CollectionAssert.AreEqual(
          new List<int> { 1 },
          Kata.PascalsTriangle(1));
    }

    [Test]
    public void Level2()
    {
        CollectionAssert.AreEqual(
          new List<int> { 1, 1, 1 },
          Kata.PascalsTriangle(2));
    }

    [Test]
    public void Level4()
    {
        CollectionAssert.AreEqual(
          new List<int> { 1, 1, 1, 1, 2, 1, 1, 3, 3, 1 },
          Kata.PascalsTriangle(4));
    }

    [Test]
    public void Level30()
    {
        CollectionAssert.AreEqual(SliceUpToRow(30), Kata.PascalsTriangle(30));
    }

    [Test]
    public void RandomTests([ValueSource("TestCases")]  int n)
    {
        CollectionAssert.AreEqual(SliceUpToRow(n), Kata.PascalsTriangle(n));
    }

    private static List<int> TestCases
    {
        get
        {
            Random rnd = new Random();
            return Enumerable.Range(1, 30).OrderBy(n => rnd.Next()).ToList();
        }
    }

}
