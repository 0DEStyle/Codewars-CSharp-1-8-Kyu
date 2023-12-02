/*Challenge link:https://www.codewars.com/kata/62a611067274990047f431a8/train/csharp
Question:
Given an integer n and two other values, build an array of size n filled with these two values alternating.

Examples
5, true, false     -->  [true, false, true, false, true]
10, "blue", "red"  -->  ["blue", "red", "blue", "red", "blue", "red", "blue", "red", "blue", "red"]
0, "one", "two"    -->  []
Good luck!
*/

//***************Solution********************

//generate number from 0 up to n, x is the current element
//if x is an even number, return firstValue, else secondValue
//store as array and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public class Kata {
  public static object[] Alternate(int n, object firstValue, object secondValue) {
    return Enumerable.Range(0,n).Select(x => x % 2 == 0 ? firstValue : secondValue).ToArray();
  }
}

//solution 2
public class Kata {
  public static object[] Alternate(int n, object firstValue, object secondValue) 
  {
    var results = new object[n];
    for (var i = 0; i < results.Length; i++) 
    {
      results[i] = i % 2 == 0 ? firstValue : secondValue;
    }
    return results;
  }
}
//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using NUnit.Framework.Internal;
  using System;
  using System.Linq;
  
  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void SampleTests()
    {
      Assertion(new object[] {true, false, true, false, true}, (5, true, false));
      Assertion(new object[] {"blue", "red", "blue", "red", "blue", "red", "blue", "red", "blue", "red", "blue", "red", "blue", "red", "blue", "red", "blue", "red", "blue", "red"}, (20, "blue", "red"));
      Assertion(new object[0], (0, "lemons", "apples"));
    }
    
    [Test]
    public void RandomTests() {
      int n;
      object firstValue;
      object secondValue;
      
      Random rand = new Random();
      
      object[] Solution(int n, object firstValue, object secondValue) {
          return Enumerable.Range(0, n)
                           .Select(x => (x&1) == 0 ? firstValue : secondValue)
                           .ToArray();
      }
      
      for (int i = 0; i < 75; i++) {
        n = rand.Next(0, 50);
        firstValue = RandomObject();
        secondValue = RandomObject();
        
        Assertion(Solution(n, firstValue, secondValue), (n, firstValue, secondValue));
      }
    }
    
    private object RandomObject() {
      Random rand = new Random();
      
      switch (rand.Next(0, 4)) {
          case 0:
            return rand.Next();
          case 1:
            return (double)rand.Next() / Math.Pow(10, rand.Next(0,5));
          case 2:
            return TestContext.CurrentContext.Random.GetString(rand.Next(0, 35));
          default:
            return rand.Next(0, 2) == 0;     
      }
    }
    
    private void Assertion(object[] expected, (int, object, object) inputs) {
      object[] actual = Kata.Alternate(inputs.Item1, inputs.Item2, inputs.Item3);
      Assert.AreEqual(
        expected,
        actual,
      
        $"\n  n = {inputs.Item1}"+
        $"\n  firstValue = {inputs.Item2}"+
        $"\n  secondValue = {inputs.Item3}\n" +
        $"\n  Expected = [{string.Join(", ",expected)}]" +
        $"\n  Actual = [{string.Join(", ",actual)}]\n"
    
      );
    }
  }
}
