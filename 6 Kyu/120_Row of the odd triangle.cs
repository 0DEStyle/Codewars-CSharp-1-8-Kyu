/*Challenge link:https://www.codewars.com/kata/5d5a7525207a674b71aa25b5/train/csharp
Question:
Given a triangle of consecutive odd numbers:

             1
          3     5
       7     9    11
   13    15    17    19
21    23    25    27    29
...
find the triangle's row knowing its index (the rows are 1-indexed), e.g.:

odd_row(1)  ==  [1]
odd_row(2)  ==  [3, 5]
odd_row(3)  ==  [7, 9, 11]
Note: your code should be optimized to handle big inputs.

The idea for this kata was taken from this kata: Sum of odd numbers
*/

//***************Solution********************

//create loop, start from 0 count up to n.
//i is the current element, convert n to long, * (n - 1) + 1 + (2 * i)
//convert to array and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public class UserSolution{
  public static long[] OddRow(int n) =>
    Enumerable.Range(0, n).Select(i => (long)n * (n - 1) + 1 + (2 * i)).ToArray();
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class FixedTests
  {
    [Test]
    public void fixed_test_1()
    {
      Assert.AreEqual(UserSolution.OddRow(1), new long[]{1});
    }
    
    [Test]
    public void fixed_test_2()
    {
      Assert.AreEqual(UserSolution.OddRow(2), new long[]{3, 5});
    }
    
    [Test]
    public void fixed_test_13()
    {
      Assert.AreEqual(UserSolution.OddRow(13), new long[]{
        157, 159, 161, 163, 165, 167, 169, 171, 173, 175, 177, 179, 181
      });
    }
    
    [Test]
    public void fixed_test_19()
    {
      Assert.AreEqual(UserSolution.OddRow(19), new long[]{
        343, 345, 347, 349, 351, 353, 355, 357, 359, 361, 363, 365, 367, 369, 371, 373, 375, 377, 379
      });
    }
    
    [Test]
    public void fixed_test_41()
    {
      Assert.AreEqual(UserSolution.OddRow(41), new long[]{
        1641, 1643, 1645, 1647, 1649, 1651, 1653, 1655, 1657, 1659, 1661, 1663, 1665, 1667, 1669,
        1671, 1673, 1675, 1677, 1679, 1681, 1683, 1685, 1687, 1689, 1691, 1693, 1695, 1697, 1699,
        1701, 1703, 1705, 1707, 1709, 1711, 1713, 1715, 1717, 1719, 1721
      });
    }
    
    [Test]
    public void fixed_test_93()
    {
      Assert.AreEqual(UserSolution.OddRow(93), new long[]{
        8557, 8559, 8561, 8563, 8565, 8567, 8569, 8571, 8573, 8575, 8577, 8579, 8581, 8583, 8585,
        8587, 8589, 8591, 8593, 8595, 8597, 8599, 8601, 8603, 8605, 8607, 8609, 8611, 8613, 8615,
        8617, 8619, 8621, 8623, 8625, 8627, 8629, 8631, 8633, 8635, 8637, 8639, 8641, 8643, 8645,
        8647, 8649, 8651, 8653, 8655, 8657, 8659, 8661, 8663, 8665, 8667, 8669, 8671, 8673, 8675,
        8677, 8679, 8681, 8683, 8685, 8687, 8689, 8691, 8693, 8695, 8697, 8699, 8701, 8703, 8705,
        8707, 8709, 8711, 8713, 8715, 8717, 8719, 8721, 8723, 8725, 8727, 8729, 8731, 8733, 8735,
        8737, 8739, 8741
      });
    }
  }

  [TestFixture]
  public class RandomTests
  {
    [Test]
    public void small_random_tests()
    {
      Random r = new Random();
      for (int i = 0; i < 50; i++)
      {
        int n = r.Next(1, 51);
        Assert.AreEqual(UserSolution.OddRow(n), solution(n));
      }
    }

    [Test]
    public void big_random_tests()
    {
      Random r = new Random();
      for (int i = 0; i < 50; i++)
      {
        int n = r.Next(2000000, 3000001);
        string result = compare(UserSolution.OddRow(n), solution(n));
        Assert.True(result == "Success", result);
      }
    }
    
    private static string compare(long[] a, long[] b)
    {
      if (a.Length != b.Length)
        return "Wrong array length: " + a.Length + " != " + b.Length;
      for (int i = 0; i < a.Length; i++)
        if (a[i] != b[i])
          return "Elements differ at index " + i + ": " + a[i] + " != " + b[i];
      return "Success";
    }
    
    private static long[] solution(int n)
    {
      long m = (long)n * (n - 1) + 1;
      long[] r = new long[n];
      for (int i = 0; i < n; i++)
        r[i] = m + i * 2;
      return r;
    }
  }
}
