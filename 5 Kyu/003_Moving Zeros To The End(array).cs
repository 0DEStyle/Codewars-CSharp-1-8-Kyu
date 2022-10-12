/*Challenge link:https://www.codewars.com/kata/52597aa56021e91c93000cb0/train/csharp
Question:
Write an algorithm that takes an array and moves all of the zeros to the end, preserving the order of the other elements.

Kata.MoveZeroes(new int[] {1, 2, 0, 1, 0, 1, 0, 3, 0, 1}) => new int[] {1, 2, 1, 1, 3, 1, 0, 0, 0, 0}
*/

//***************Solution********************
/*Solution 1
create a list, so that you can add element to the end.
count the number of 0 appeared in the array,
remove all the 0 from array
copy array into the list

loop the number of "zero appeared in array" amount of time
add 0 to the end

conver the list to array and return the result.
*/

using System.Linq;
using System.Collections.Generic;


public class Kata
{
  public static int[] MoveZeroes(int[] arr){
    List<int> a = new List<int>();
    int numOfZeroInArr = arr.Where(x => x== 0).Count();
    
    arr = arr.Where(x=> x != 0).ToArray();
    a = arr.ToList();
    
    for(int i = 0; i < numOfZeroInArr; i++)
    a.Add(0);
    
    return a.ToArray();
  }
}

//solution 2
//order array by 0 to the end
//return result.
using System.Linq;
public class Kata
{
  public static int[] MoveZeroes(int[] arr) =>
      arr.OrderBy(x => x==0).ToArray();
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class Sample_Test
  {
    [Test]
    public void Test()
    {
      Assert.AreEqual(new int[] {1, 2, 1, 1, 3, 1, 0, 0, 0, 0}, Kata.MoveZeroes(new int[] {1, 2, 0, 1, 0, 1, 0, 3, 0, 1}));
    }
  }
  
  [TestFixture]
  public class Random_Test
  {
    private static Random rnd = new Random();
    
    private static int[] solution(int[] arr) => arr.Where(v => v != 0).Concat(arr.Where(v => v == 0)).ToArray();
    
    [Test, Description("Random Tests")]
    public void Test()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        int[] test = new int[rnd.Next(4, 100)].Select(_ => rnd.Next(0, 6)).ToArray();
        
        int[] expected = solution(test);
        int[] actual = Kata.MoveZeroes(test);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
