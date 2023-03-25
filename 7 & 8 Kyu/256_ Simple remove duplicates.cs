/*Challenge link:https://www.codewars.com/kata/5ba38ba180824a86850000f7/train/csharp
Question:
Remove the duplicates from a list of integers, keeping the last ( rightmost ) occurrence of each element.

Example:
For input: [3, 4, 4, 3, 6, 3]

remove the 3 at index 0
remove the 4 at index 1
remove the 3 at index 3
Expected output: [4, 6, 3]

More examples can be found in the test cases.

Good luck!
*/

//***************Solution********************
//reverse the array, find the distinct, then reverse it again
//store in array and return the result
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public class Solution{
    public static int [] solve (int [] arr)=> arr.Reverse().Distinct().Reverse().ToArray(); 
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Linq;
 
[TestFixture]
public class SolutionTest
{
  [Test]
  public void ExampleTests()
  {
    Assert.AreEqual(new int[]{4,6,3},Solution.solve(new int[]{3,4,4,3,6,3}));
    Assert.AreEqual(new int[]{1,2,3},Solution.solve(new int[]{1,2,1,2,1,2,3}));     
    Assert.AreEqual(new int[]{1,2,3,4},Solution.solve(new int[]{1,2,3,4}));
    Assert.AreEqual(new int[]{4,5,2,1},Solution.solve(new int[]{1,1,4,5,1,2,1}));
  }

  private static int [] mj9 (int [] arr){
     return arr.Reverse().Distinct().Reverse().ToArray();            
  }

  [Test]
  public void RandomTests(){
    Random random = new Random(); 
    for (int i = 0; i < 100; i++){
      int len = random.Next(10, 500);  
      int [] arr = new int[len];
      int limit = (int)len/2;
      for (int j = 0; j < len; ++j)
          arr[j] = random.Next(1, limit);         
      int [] exp = mj9(arr);
      Assert.AreEqual(exp,Solution.solve(arr));
    }
  }
}
