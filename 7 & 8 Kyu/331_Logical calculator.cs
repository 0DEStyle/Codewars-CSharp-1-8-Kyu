/*Challenge link:https://www.codewars.com/kata/57096af70dad013aa200007b/train/csharp
Question:
Your Task
Given an array of Boolean values and a logical operator, return a Boolean result based on sequentially applying the operator to the values in the array.

Examples
booleans = [True, True, False], operator = "AND"
True AND True -> True
True AND False -> False
return False
booleans = [True, True, False], operator = "OR"
True OR True -> True
True OR False -> True
return True
booleans = [True, True, False], operator = "XOR"
True XOR True -> False
False XOR False -> False
return False
Input
an array of Boolean values (1 <= array_length <= 50)
a string specifying a logical operator: "AND", "OR", "XOR"
Output
A Boolean value (True or False).
*/

//***************Solution********************
//AND check if all are true
//OR check if any is true
//iterate through the array, xor current element x with next element y
//_ empty input
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Linq;

public class Kata{
  public static bool LogicalCalc(bool[] array, string op) =>op switch{
                "AND" => array.All(x=>x),
                "OR" => array.Any(x=>x),
                "XOR" => array.Aggregate((x,y) => x^y),
                 _ => false
            };
}

//method 2
using System.Linq;

public class Kata
{
  public static bool LogicalCalc(bool[] array, string op)
  {
    return array.Aggregate((a, b) => op == "AND" ? a && b : op == "OR" ? a || b : a != b);
  }
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class KataTests
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual(false, Kata.LogicalCalc(new bool[] { true, true, true, false }, "AND"));
      Assert.AreEqual(true, Kata.LogicalCalc(new bool[] { true, true, true, false }, "OR"));
      Assert.AreEqual(true, Kata.LogicalCalc(new bool[] { true, true, true, false }, "XOR"));
      Assert.AreEqual(false, Kata.LogicalCalc(new bool[] { true, true, false, false }, "AND"));
      Assert.AreEqual(true, Kata.LogicalCalc(new bool[] { true, true, false, false }, "OR"));
      Assert.AreEqual(false, Kata.LogicalCalc(new bool[] { true, true, false, false }, "XOR"));
      Assert.AreEqual(false, Kata.LogicalCalc(new bool[] { true, false, false, false }, "AND"));
      Assert.AreEqual(true, Kata.LogicalCalc(new bool[] { true, false, false, false }, "OR"));
      Assert.AreEqual(true, Kata.LogicalCalc(new bool[] { true, false, false, false }, "XOR"));
      Assert.AreEqual(true, Kata.LogicalCalc(new bool[] { true, true }, "AND"));
      Assert.AreEqual(true, Kata.LogicalCalc(new bool[] { true, true }, "OR"));
      Assert.AreEqual(false, Kata.LogicalCalc(new bool[] { true, true }, "XOR"));
      Assert.AreEqual(false, Kata.LogicalCalc(new bool[] { false, false }, "AND"));
      Assert.AreEqual(false, Kata.LogicalCalc(new bool[] { false, false }, "OR"));
      Assert.AreEqual(false, Kata.LogicalCalc(new bool[] { false, false }, "XOR"));
      Assert.AreEqual(false, Kata.LogicalCalc(new bool[] { false }, "AND"));
      Assert.AreEqual(false, Kata.LogicalCalc(new bool[] { false }, "OR"));
      Assert.AreEqual(false, Kata.LogicalCalc(new bool[] { false }, "XOR"));
      Assert.AreEqual(true, Kata.LogicalCalc(new bool[] { true }, "AND"));
      Assert.AreEqual(true, Kata.LogicalCalc(new bool[] { true }, "OR"));
      Assert.AreEqual(true, Kata.LogicalCalc(new bool[] { true }, "XOR"));
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      var ops = new [] { "AND", "OR", "XOR" };
      
      Func<bool[], string, bool> myLogicalCalc = delegate (bool[] arr, string op)
      {
        return arr.Aggregate((a,b) => op == "AND" ? a && b : op == "OR" ? a || b : a!=b);
      };
      
      for (int i=0;i<40;i++)
      {
        var arr = Enumerable.Range(3,20).Select(a => rand.Next(0,2) == 0 ? true : false).ToArray();
        foreach(var op in ops)
        {
          Console.WriteLine("Testing for { " + string.Join(", ", arr) + " } with \"" + op + "\"...");
          Assert.AreEqual(myLogicalCalc(arr, op), Kata.LogicalCalc(arr, op), "It should work for random inputs too");       
        }
      }
    }
  }
}
