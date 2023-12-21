/*Challenge link:https://www.codewars.com/kata/55eca815d0d20962e1000106/train/csharp
Question:
Implement a function named generateRange(min, max, step), which takes three arguments and generates a range of integers from min to max, with the step. The first integer is the minimum value, the second is the maximum of the range and the third is the step. (min < max)

Task
Implement a function named

GenerateRange(2, 10, 2) == new int[]{ 2, 4, 6, 8, 10 }
GenerateRange(1, 10, 3) == new int[]{ 1, 4, 7, 10 }
Note
min < max
step > 0
the range does not HAVE to include max (depending on the step)
*/

//***************Solution********************

//No step in Enumerable.Range, so create a new method with step to yeild result.
using System.Linq;
using System.Collections.Generic;

public class Kata{
  private static IEnumerable<int> Range(int start, int end, int step){
    for(int i = start; i <= end; i+= step)
       yield return i;
  }
  public static int[] GenerateRange(int min, int max, int step) => Range(min, max, step).ToArray();
    
}

//****************Sample Test*****************
using NUnit.Framework;
using System.Linq;

[TestFixture]
public class Tests
{
  [Test]
  [TestCase(2,10,2,ExpectedResult=new int[]{2,4,6,8,10})]
  [TestCase(1,10,3,ExpectedResult=new int[]{1,4,7,10})]
  [TestCase(1,10,1,ExpectedResult=new int[]{1,2,3,4,5,6,7,8,9,10})]
  [TestCase(1,10,4,ExpectedResult=new int[]{1,5,9})]
  [TestCase(1,10,5,ExpectedResult=new int[]{1,6})]
  public static int[] FixedTest(int min, int max, int step)
  {
    return Kata.GenerateRange(min, max,step);
  }
  
  private static int[] Solution(int min, int max, int step)
  {
    return Enumerable.Range(min, max - min + 1).Where(x => (x - min) % step == 0).ToArray();
  }
  
  [Test]
  public static void RandomTest([Random(1,10,100)]int step)
  {
    int min = 0;
    int max = 100;
    Assert.AreEqual(Solution(min,max,step), Kata.GenerateRange(min, max, step), string.Format("Should work for min = {0}, max = {1} and step = {2}", min, max, step));
  }
}
