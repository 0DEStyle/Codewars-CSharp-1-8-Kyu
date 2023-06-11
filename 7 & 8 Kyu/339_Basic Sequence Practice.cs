/*Challenge link:https://www.codewars.com/kata/5436f26c4e3d6c40e5000282/train/csharp
Question:
A sequence or a series, in mathematics, is a string of objects, like numbers, that follow a particular pattern. The individual elements in a sequence are called terms. A simple example is 3, 6, 9, 12, 15, 18, 21, ..., where the pattern is: "add 3 to the previous term".

In this kata, we will be using a more complicated sequence: 0, 1, 3, 6, 10, 15, 21, 28, ... This sequence is generated with the pattern: "the nth term is the sum of numbers from 0 to n, inclusive".

[ 0,  1,    3,      6,   ...]
  0  0+1  0+1+2  0+1+2+3
Your Task
Complete the function that takes an integer n and returns a list/array of length abs(n) + 1 of the arithmetic series explained above. Whenn < 0 return the sequence with negative terms.

Examples
 5  -->  [0,  1,  3,  6,  10,  15]
-5  -->  [0, -1, -3, -6, -10, -15]
 7  -->  [0,  1,  3,  6,  10,  15,  21,  28]
*/

//***************Solution********************
//start from 0 up to Math.abs(n) +1
//then apply formula to each iteration
//sign of n * i * (i + 1) / 2
//convert to array and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;
public class SequenceSum{
	public static int[] SumOfN(int n) => Enumerable.Range(0, Math.Abs(n) + 1).Select(i => Math.Sign(n) * i * (i + 1) / 2).ToArray();
}

//****************Sample Test*****************
using NUnit.Framework;

[TestFixture]
public class SequenceSumTests
{
  [Test]
  public void Test_3()
  {
    int input = 3;
    int[] expected = new int[] { 0, 1, 3, 6 };
    
    int[] actual = SequenceSum.SumOfN(input);
    
    Assert.AreEqual(expected, actual);
  }
  
  [Test]
  public void Test_Neg4()
  {
    int input = -4;
    int[] expected = new int[] { 0, -1, -3, -6, -10 };
    
    int[] actual = SequenceSum.SumOfN(input);
    
    Assert.AreEqual(expected, actual);
  }
  
  [Test]
  public void Test_1()
  {
    int input = 1;
    int[] expected = new int[] { 0, 1 };
    
    int[] actual = SequenceSum.SumOfN(input);
    
    Assert.AreEqual(expected, actual);
  }
  
  [Test]
  public void Test_0()
  {
    int input = 0;
    int[] expected = new int[] { 0 };
    
    int[] actual = SequenceSum.SumOfN(input);
    
    Assert.AreEqual(expected, actual);
  }
  
  [Test]
  public void Test_10()
  {
    int input = 10;
    int[] expected = new int[] { 0, 1, 3, 6, 10, 15, 21, 28, 36, 45, 55 };
    
    int[] actual = SequenceSum.SumOfN(input);
    
    Assert.AreEqual(expected, actual);
  }
  
  [Test]
  public void Test_Neg7()
  {
    int input = -7;
    int[] expected = new int[] { 0, -1, -3, -6, -10, -15, -21, -28 };
    
    int[] actual = SequenceSum.SumOfN(input);
    
    Assert.AreEqual(expected, actual);
  }
}
