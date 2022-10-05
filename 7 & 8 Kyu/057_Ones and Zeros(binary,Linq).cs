/*Challenge link:https://www.codewars.com/kata/578553c3a1b8d5c40300037c/train/csharp
Question:
Given an array of ones and zeroes, convert the equivalent binary value to an integer.

Eg: [0, 0, 0, 1] is treated as 0001 which is the binary representation of 1.

Examples:

Testing: [0, 0, 0, 1] ==> 1
Testing: [0, 0, 1, 0] ==> 2
Testing: [0, 1, 0, 1] ==> 5
Testing: [1, 0, 0, 1] ==> 9
Testing: [0, 0, 1, 0] ==> 2
Testing: [0, 1, 1, 0] ==> 6
Testing: [1, 1, 1, 1] ==> 15
Testing: [1, 0, 1, 1] ==> 11
However, the arrays can have varying lengths, not just limited to 4.
*/

//***************Solution********************
//convert int to binary using base 2.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
namespace Solution
{
  class Kata
    {
      public static int binaryArrayToNumber(int[] BinaryArray) =>
         Convert.ToInt32(String.Join("", BinaryArray), 2);
    }
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;
  [TestFixture]
  public class SolutionTests
  {
    private static Random rnd = new Random();
    public static int binaryArrayToNumberSolution(int[] BinaryArray)
        {
            BinaryArray = BinaryArray.Reverse().ToArray();
            for (int i = 1; i < BinaryArray.Length; i++) BinaryArray[0] += (BinaryArray[i] == 1) ? (int)Math.Pow(2, i) : 0;
            return BinaryArray[0];
        } 
    int[] Test1 = new int[] {0,0,0,0};
    int[] Test2 = new int[] {1,1,1,1};
    int[] Test3 = new int[] {0,1,1,0};
    int[] Test4 = new int[] {0,1,0,1};
    [Test]
    public void BasicTesting()
    {
      Assert.AreEqual(0 , Kata.binaryArrayToNumber(Test1));
      Assert.AreEqual(15 , Kata.binaryArrayToNumber(Test2));
      Assert.AreEqual(6 , Kata.binaryArrayToNumber(Test3));
      Assert.AreEqual(5 , Kata.binaryArrayToNumber(Test4));
    }
    int[] Test5 = new int[] {1,0,1,1};
    int[] Test6 = new int[] {1,0,0,1};
    int[] Test7 = new int[] {0,0,0,1};
    int[] Test8 = new int[] {1,0,1,0};
    int[] Test9 = new int[] {1,0,0,0};
    int[] Test10 = new int[] {0,1,0,0};
    [Test]
    public void MoreTests()
    {
      Assert.AreEqual(11 , Kata.binaryArrayToNumber(Test5));
      Assert.AreEqual(9 , Kata.binaryArrayToNumber(Test6));
      Assert.AreEqual(1 , Kata.binaryArrayToNumber(Test7));
      Assert.AreEqual(10 , Kata.binaryArrayToNumber(Test8));
      Assert.AreEqual(8 , Kata.binaryArrayToNumber(Test9));
      Assert.AreEqual(4 , Kata.binaryArrayToNumber(Test10));
    }
    [Test]
    public void RandomTest()
    {
      int[] arr = new int[rnd.Next(0, 5) + 4];
      for (int i = 0; i < arr.Length; i++) arr[i] = rnd.Next(0, 2);
      int expected = binaryArrayToNumberSolution(arr);
      Assert.AreEqual(expected,Kata.binaryArrayToNumber(arr));    
    }
  }
}
