/*Challenge link:https://www.codewars.com/kata/51e0007c1f9378fa810002a9/train/csharp
Question:
Write a simple parser that will parse and run Deadfish.

Deadfish has 4 commands, each 1 character long:

i increments the value (initially 0)
d decrements the value
s squares the value
o outputs the value into the return array
Invalid characters should be ignored.

Deadfish.Parse("iiisdoso") => new int[] {8, 64};
*/

//***************Solution********************
using System.Linq;
using System.Collections.Generic;

public class Deadfish{
  //create new int list and aggregate the string data with a(current element) and c(character)
  //perform function accordingly and update i, return the result to a
  //convert final result to array
  public static int[] Parse(string data, int i = 0) =>
     data.Aggregate(new List<int>(), (a, c) =>{
        if (c == 'i') i++;
        else if (c == 'd') i--;
        else if (c == 's') i *= i;
        else if (c == 'o') a.Add(i);
        return a;
    }).ToArray();
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;

  [TestFixture]
  public class SolutionTest
  {
    private static object[] sampleTestCases = new object[]
    {
      new object[] {"iiisdoso", new int[] {8, 64}},
      new object[] {"iiisdosodddddiso", new int[] {8, 64, 3600}},
    };
  
    [Test, TestCaseSource("sampleTestCases")]
    public void SampleTest(string data, int[] expected)
    {
      Assert.AreEqual(expected, Deadfish.Parse(data));
    }
    
    private static Random rnd = new Random();
    
    private static int[] solution(string data)
    {
      List<int> output = new List<int>();
      int value = 0;
      
      foreach (char op in data)
      {
        if (op == 'i') { ++value; }
        else if (op == 'd') { --value; }
        else if (op == 's') { value *= value; }
        else if (op == 'o') { output.Add(value); }
      }
      
      return output.ToArray();
    }
    
    private static string getRandomDeadfish()
    {
      string deadfish = "";
      for (int i = 0; i < 7; ++i)
      {
        deadfish += "idso"[rnd.Next(0, 4)];
      }
      return deadfish + 'o';
    }
    
    [Test]
    public void RandomTests()
    {
      for (int i = 0; i < 100; ++i)
      {
        string test = getRandomDeadfish();
        int[] expected = solution(test);
        int[] actual = Deadfish.Parse(test);
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
