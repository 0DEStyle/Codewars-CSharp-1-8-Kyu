/*Challenge link:https://www.codewars.com/kata/51edd51599a189fe7f000015/train/csharp
Question:
Complete the function that

accepts two integer arrays of equal length
compares the value each member in one array to the corresponding member in the other
squares the absolute value difference between those two values
and returns the average of those squared absolute value difference between each member pair.
Examples
[1, 2, 3], [4, 5, 6]              -->   9   because (9 + 9 + 9) / 3
[10, 20, 10, 2], [10, 25, 5, -2]  -->  16.5 because (0 + 25 + 25 + 16) / 4
[-1, 0], [0, -1]                  -->   1   because (1 + 1) / 2
*/

//***************Solution********************

//using a for loop to extract numbers from both array and compare them
//return num / array.Length as result.
using System;

public class Kata{
    public static double Solution(int[] firstArray, int[] secondArray){
        var num = 0.00;

        for (var i = 0; i < firstArray.Length; i++)
            num += Math.Pow(firstArray[i] - secondArray[i], 2);

        return num / firstArray.Length;
    }
}

//second method using zip
using System.Linq;
public class Kata
{
  public static double Solution(int[] xs, int[] ys) =>
    xs.Zip(ys, (x,y) => (x-y)*(x-y)).Average();
}
//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class SolutionTest
  {
    [Test, Description("Sample Tests")]
    public void SampleTest()
    {
      Assert.AreEqual(9,    Kata.Solution(new int[] {1, 2, 3}, new int[] {4, 5, 6}));
      Assert.AreEqual(16.5, Kata.Solution(new int[] {10, 20, 10, 2}, new int[] {10, 25, 5, -2}));
      Assert.AreEqual(1,    Kata.Solution(new int[] {0, -1}, new int[] {-1, 0}));
    }
    
    private static Random rnd = new Random();
    
    private static double solution(int[] firstArray, int[] secondArray) =>
      firstArray.Select((v, i) =>
        {
          int difference = Math.Abs(firstArray[i] - secondArray[i]);
          return difference * difference;
        }).Average();
    
    [Test, Description("Random Tests")]
    public void RandomTest()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        int size = rnd.Next(2, 8);
        int[] fa = new int[size].Select(_ => rnd.Next(-100, 101)).ToArray();
        int[] sa = new int[size].Select(_ => rnd.Next(-100, 101)).ToArray();
        int[] faClone = (int[])fa.Clone();
        int[] saClone = (int[])sa.Clone();
        
        double expected = solution(fa, sa);
        double actual = Kata.Solution(fa, sa);
        
        Assert.AreEqual(faClone, fa, "User mutated the input array!");
        Assert.AreEqual(saClone, sa, "User mutated the input array!");
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
