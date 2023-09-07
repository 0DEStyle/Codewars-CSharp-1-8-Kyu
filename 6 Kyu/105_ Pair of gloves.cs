/*Challenge link:https://www.codewars.com/kata/58235a167a8cb37e1a0000db/train/csharp
Question:
Pair of gloves
Winter is coming, you must prepare your ski holidays. The objective of this kata is to determine the number of pair of gloves you can constitute from the gloves you have in your drawer.

Given an array describing the color of each glove, return the number of pairs you can constitute, assuming that only gloves of the same color can form pairs.

Examples:
input = ["red", "green", "red", "blue", "blue"]
result = 2 (1 red pair + 1 blue pair)

input = ["red", "red", "red", "red", "red", "red"]
result = 3 (3 red pairs)
*/

//***************Solution********************

//group gloves, find the sum of current element g.count /2
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public class Kata{
  public static int NumberOfPairs(string[] gloves) => gloves.GroupBy(s => s).Sum(g => g.Count() / 2);
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;
  using System.Collections.Generic;
  
  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void SampleTests()
    {
      Assertion(0, new string[] {"Green", "Blue", "Purple", "Gray"});
      Assertion(0, new string[] {});
      Assertion(0, new string[] {"Purple"});
      
      Assertion(1, new string[] {"Blue", "Purple", "Blue", "Gray", "Lime", "Black"});
      Assertion(1, new string[] {"Blue", "Aqua", "Blue", "Teal", "Blue", "Black"});
      
      Assertion(2, new string[] {"Blue", "Aqua", "Blue", "Brown", "Blue", "Orange", "Aqua"});
    }
    
    private static string[] Colors = new string[] {
      "Red", "Orange", "Yellow", "Green", "Blue", "Indigo", "Violet", "Purple", "Gray", "Lime",
      "Black", "Aqua", "Teal", "Brown", "Orange", "Olive", "Pink"
    };
    
    [Test]
    public static void RandomTests() {
      Random rand = new Random();
      int Solution(string[] gloves) {
        int count = 0;
        List<string> pairs = new List<string>();

        foreach (string glove in gloves) {
          if (pairs.Contains(glove)) {
            pairs.Remove(glove);
            count++;
          }

          else {
            pairs.Add(glove);
          }
        }

        return count;
      }
      string[] RandArray(int length) { 
        return Enumerable.Range(0, length)
                         .Select(x => Colors[rand.Next(0, Colors.Length)])
                         .ToArray(); 
      }
      
      string[] array;
      int expected;
      
      for (int i = 0; i < 75; i++) {
        array = RandArray(rand.Next(0, 50));
        expected = Solution(array);
        
        Assertion(expected, array);
      }
    }
    
    private static void Assertion(int expected, string[] input) =>
      Assert.AreEqual(
        expected,
        Kata.NumberOfPairs(input),
      
        $"Input: [{string.Join(", ", input)}]\n"
      
      );
  }
}
