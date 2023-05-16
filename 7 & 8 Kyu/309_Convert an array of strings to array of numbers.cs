/*Challenge link:https://www.codewars.com/kata/5783d8f3202c0e486c001d23/train/csharp
Question:
Oh no!
Some really funny web dev gave you a sequence of numbers from his API response as an sequence of strings!

You need to cast the whole array to the correct type.

Create the function that takes as a parameter a sequence of numbers represented as strings and outputs a sequence of numbers.

ie:["1", "2", "3"] to [1, 2, 3]

Note that you can receive floats as well.


*/

//***************Solution********************
//using Linq, convert each element to double, then store in array and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
using System;
public class stringArrayMethods{
  public static double[] ToDoubleArray(string[] stringArray) => stringArray.Select(x=>Convert.ToDouble(x)).ToArray();
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;
  
  [TestFixture]
  public class stringArrayMethodsTest
  {
    [Test]
    public void ExampleTest()
    {
      Console.WriteLine("Running ToDoubleArray(\"1.1\",\"2.2\",\"3.3\")...");
      Assert.AreEqual(new double[] { 1.1, 2.2, 3.3 }, stringArrayMethods.ToDoubleArray(new string[] { "1.1","2.2","3.3" }));
    }
    
    [Test]
    public void RandomTest()
    {
      Random rand = new Random();
      var n = rand.Next(1,50);
      
      Console.WriteLine("Generating "+ n + " random test cases...");
      
      for(int i=0; i < n; i++)
      {
        var m = rand.Next(1,10);
        var testArray = new string[m];
        for(int j=0; j < m; j++)
        {
          testArray[j] = (rand.NextDouble() * 9 + 1).ToString("F2");
        }
      
        Console.WriteLine("Running toNumberArray(" + string.Join(", ", testArray.Select(s => "\"" + s + "\"")) + ")...");
        Assert.AreEqual(testArray.Select(double.Parse).ToArray(), stringArrayMethods.ToDoubleArray(testArray));
      }      
    }
  }
}
