/*Challenge link:https://www.codewars.com/kata/57d29ccda56edb4187000052/train/csharp
Question:
In this kata, your task is to implement an extended version of the famous rock-paper-scissors game. The rules are as follows:

Scissors cuts Paper
Paper covers Rock
Rock crushes Lizard
Lizard poisons Spock
Spock smashes Scissors
Scissors decapitates Lizard
Lizard eats Paper
Paper disproves Spock
Spock vaporizes Rock
Rock crushes Scissors
Task:
Given two values from the above game, return the Player result as an Ordering ( GT, LT or EQ ).

Inputs
Values will be given as one of Rock, Paper, Scissors, Lizard, Spock.

//see image in link
*/

//***************Solution********************
public static class Kata {
   // * PRELOADED:
  //Value sort in this order
  // public enum Value { Scissors, Paper, Rock, Lizard, Spock }
  
  // public enum Ordering { LT, EQ, GT }
  
  public static Ordering Rpsls(Value a, Value b) {
    switch((a - b + 4)  % 5){
      case 0 or 2:
        return Ordering.LT;
      case 1 or 3:
        return Ordering.GT;
      case 4:
        return Ordering.EQ;
    }
    return Ordering.EQ; 
  }
}
//solution 2
using System.Collections.Generic;

public static class Kata
{
  private static readonly List<List<Value>> Gc = new()
  {
    new List<Value> {Value.Paper, Value.Lizard},
    new List<Value> {Value.Rock, Value.Spock},
    new List<Value> {Value.Scissors, Value.Lizard},
    new List<Value> {Value.Paper, Value.Spock},
    new List<Value> {Value.Rock, Value.Scissors}
  };

  public static Ordering Rpsls(Value a, Value b)
  {
    return Gc[(int) a].Contains(b) ? Ordering.GT : Gc[(int) b].Contains(a) ? Ordering.LT : Ordering.EQ;
  }
}
//****************Sample Test*****************
namespace Solution 
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
  
    [TestFixture]
    public class SolutionTest
    {
        [TestCase(Value.Rock, Value.Lizard, Ordering.GT)]
        [TestCase(Value.Paper, Value.Rock, Ordering.GT)]
        [TestCase(Value.Scissors, Value.Lizard, Ordering.GT)]
        [TestCase(Value.Lizard, Value.Paper, Ordering.GT)]
        [TestCase(Value.Spock, Value.Rock, Ordering.GT)]
        public void Player1Wins(Value a, Value b, Ordering expected)
        {
            Act(a, b, expected);
        }
      
        [TestCase(Value.Rock, Value.Lizard, Ordering.LT)]
        [TestCase(Value.Paper, Value.Rock, Ordering.LT)]
        [TestCase(Value.Scissors, Value.Lizard, Ordering.LT)]
        [TestCase(Value.Lizard, Value.Paper, Ordering.LT)]
        [TestCase(Value.Spock, Value.Rock, Ordering.LT)]
        public void Player2Wins(Value a, Value b, Ordering expected)
        {
            // note that a and b are swapped
            Act(b, a, expected);
        }
      
        [TestCase(Value.Rock, Value.Rock, Ordering.EQ)]
        [TestCase(Value.Spock, Value.Spock, Ordering.EQ)]
        public void Draw(Value a, Value b, Ordering expected)
        {
            Act(a, b, expected);
        }
      
        [TestCaseSource(nameof(GenerateTestCases))]
        public void RandomTests((Value, Value, Ordering) testCase)
        {
            var (a, b, expected) = testCase;
            Act(a, b, expected);
        }
    
        private static IEnumerable<TestCaseData> GenerateTestCases()
        {
            var rnd = new Random();
            for (var i = 1; i <= 100; ++i) 
                yield return GenerateTestCase(rnd, i);
        }
    
        private static TestCaseData GenerateTestCase(Random rnd, int i)
        {
            // reference solution
            Ordering ReferenceSolution(Value refA, Value refB)
            {
                var hs = new Dictionary<Value, Value[]>() {
                   { Value.Scissors, new[] { Value.Paper, Value.Lizard } }
                  ,{ Value.Paper,    new[] { Value.Rock, Value.Spock } }
                  ,{ Value.Rock,     new[] { Value.Lizard, Value.Scissors } }
                  ,{ Value.Lizard,   new[] { Value.Spock, Value.Paper } }
                  ,{ Value.Spock,    new[] { Value.Scissors, Value.Rock } }
                };
                if (hs[refA].Contains(refB)) return Ordering.GT;
                if (hs[refB].Contains(refA)) return Ordering.LT;
                return Ordering.EQ;
            }
    
            // test case data generation
            Array values = Enum.GetValues(typeof(Value));
            var a = (Value) values.GetValue(rnd.Next(values.Length));
            var b = (Value) values.GetValue(rnd.Next(values.Length));
            var expected = ReferenceSolution(a, b);
            return new TestCaseData((a, b, expected))
            {
                HasExpectedResult = false
                  
            }.SetDescription($"Test {i}: a = {a}, b = {b}");
        }
      
        private static void Act(Value a, Value b, Ordering expected)
        {
            var msg = $"Invalid answer for a: {a}, b = {b}";
            var actual = Kata.Rpsls(a, b);
            Assert.AreEqual(expected, actual, msg);
        }
    }
}
