/*Challenge link:https://www.codewars.com/kata/55caef80d691f65cb6000040/train/csharp
Question:
In your class, you have started lessons about geometric progression. Since you are also a programmer, you have decided to write a function that will print first n elements of the sequence with the given constant r and first element a.

Result should be separated by comma and space.

Example
Kata.GeometricSequenceElements(2, 3, 5); // => "2, 6, 18, 54, 162"
More info: https://en.wikipedia.org/wiki/Geometric_progression
*/

//***************Solution********************

//create loop, start from 0 up to n, (for calculating power), x is the current element
//for each iteration, perform r to the power of x, times a.
//join elements together with ", "
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;

public class Kata{
  public static string GeometricSequenceElements(int a, int r, int n) => 
    string.Join(", ", Enumerable.Range(0, n).Select(x => Math.Pow(r, x) * a));
}

//solution 2
using System;
using System.Text;

public class Kata
{
  public static string GeometricSequenceElements(int a, int r, int n)
  {
     StringBuilder sb = new StringBuilder();
     
     sb.Append(a);
     int sum = a;
     for (int i = 1; i < n; i++) {
       sum *= r;
       sb.Append(", ").Append(sum);
     }
     
     return sb.ToString();
  }
}

//solution 3
using System;
using System.Collections.Generic;
using System.Linq;

public class Kata
{
  public static string GeometricSequenceElements(int a, int r, int n)
  {
    List<int> output = new List<int>();
    
    while(output.Count < n)
    {
       output.Add(a);
       a *= r;  
    }
    
    return String.Join(", ", output.ToArray());
  }
}
//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class GeometricSequenceElementsTest
  {
    [Test]
    public void FixedTests()
    {
      Assert.AreEqual("2, 6, 18, 54, 162", Kata.GeometricSequenceElements(2, 3, 5));
      Assert.AreEqual("2, 4, 8, 16, 32, 64, 128, 256, 512, 1024", Kata.GeometricSequenceElements(2, 2, 10));
      Assert.AreEqual("1, -2, 4, -8, 16, -32, 64, -128, 256, -512", Kata.GeometricSequenceElements(1, -2, 10));
    }
    protected static Random Rng = new Random();
    protected static string Solution(int a, int r, int n) => String.Join(", ", Enumerable.Range(0, n).ToArray().Select(i => (a * (int)Math.Pow(r, i)).ToString()).ToArray());
    [Test]
    public void RandomTests()
    {
      int a, r, n;
      for (int i = 0; i < 100; i++)
      {
        a = Rng.Next(1, 11);
        r = Rng.Next(1, 11);
        n = Rng.Next(1, 10);
        Console.WriteLine("Testing for a = " + a + ", r = " + r + ", n = " + n);
        Assert.AreEqual(Solution(a, r, n), Kata.GeometricSequenceElements(a, r, n));
      }
    }
  }
}
