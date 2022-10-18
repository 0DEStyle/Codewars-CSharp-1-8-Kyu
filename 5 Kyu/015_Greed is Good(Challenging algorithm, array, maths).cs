/*Challenge link:https://www.codewars.com/kata/5270d0d18625160ada0000e4/train/csharp
Question:
Greed is a dice game played with five six-sided dice. Your mission, should you choose to accept it, is to score a throw according to these rules. You will always be given an array with five six-sided dice values.

 Three 1's => 1000 points
 Three 6's =>  600 points
 Three 5's =>  500 points
 Three 4's =>  400 points
 Three 3's =>  300 points
 Three 2's =>  200 points
 One   1   =>  100 points
 One   5   =>   50 point
A single die can only be counted once in each roll. For example, a given "5" can only count as part of a triplet (contributing to the 500 points) or as a single 50 points, but not both in the same roll.

Example scoring

 Throw       Score
 ---------   ------------------
 5 1 3 4 1   250:  50 (for the 5) + 2 * 100 (for the 1s)
 1 1 1 3 1   1100: 1000 (for three 1s) + 100 (for the other 1)
 2 4 4 5 4   450:  400 (for three 4s) + 50 (for the 5)
In some languages, it is possible to mutate the input to the function. This is something that you should never do. If you mutate the input, you will not be able to pass all the tests.
*/

//***************Solution********************

//solution 1
//create an empty array storage for each side(total of 6)
//store the number of counst of each digit inside the diceCount array using a for loop

//apply the algorithm rules
//for example, say we have three ones, we use Math.Floor(diceCount[0] / 3) *1000 to find out if that condition is true
//if true: Math.Floor(diceCount[0] / 3) * 1000 = Math.Floor(3 / 3) *1000 = 1 *1000 = 1000
//if false: Math.Floor(diceCount[0] / 3) * 1000 = Math.Floor(1 / 3) *1000 = 0 *1000 = 0

//add result to ans and return the result(type cast back to int). 

using System;
using System.Linq;

public static class Kata
{
  public static int Score(int[] dice) {
    // Fill me in! OK!
    double[] diceCount = new double[6];
    
    for(int i = 0; i < diceCount.Length; i++)
      diceCount[i] = dice.Count(x => x == i+1); //adjust index by 1 because dice start at 1 not 0
    
    //1 5
    double ans = (Math.Floor(diceCount[0] / 3) * 1000 + (diceCount[0] % 3) * 100 + Math.Floor(diceCount[4] / 3) * 500 + (diceCount[4] % 3) * 50);
    //2 3 4 6
    ans += Math.Floor(diceCount[1] / 3) * 200 + Math.Floor(diceCount[2] / 3) * 300 + Math.Floor(diceCount[3] / 3) * 400 + Math.Floor(diceCount[5] / 3) * 600;
    
    return (int)ans;
  }
}

//solution 2
// simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;

public static class Kata
{
  public static int Score(int[] dice) =>
  Enumerable.Range(1,6).Sum(x => dice.Count(v => v == x) / 3 * (x == 1 ? 1000 : x * 100) + dice.Count(v => v == x) % 3 * (x == 1 ? 100 : (x == 5 ? 50 : 0)));
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

public static class ScoreChecker
{
  [Test]
  public static void ShouldBeWorthless()
  {
    Assert.AreEqual(0, Kata.Score(new int[] {2, 3, 4, 6, 2}));
  }
  
  [Test]
  public static void Triplets1()
  {
    Assert.AreEqual(1000, Kata.Score(new int[] {1, 1, 1, 3, 3}));
  }
  
  [Test]
  public static void Triplets2()
  {
    Assert.AreEqual(200, Kata.Score(new int[] {2, 2, 2, 3, 3}));
  }
  
  [Test]
  public static void Triplets3()
  {
    Assert.AreEqual(300, Kata.Score(new int[] {3, 3, 3, 3, 3}));
  }
  
  [Test]
  public static void Triplets4()
  {
    Assert.AreEqual(400, Kata.Score(new int[] {4, 4, 4, 3, 3}));
  }
  
  [Test]
  public static void Triplets5()
  {
    Assert.AreEqual(500, Kata.Score(new int[] {5, 5, 5, 3, 3}));
  }
  
  [Test]
  public static void Triplets6()
  {
    Assert.AreEqual(600, Kata.Score(new int[] {6, 6, 6, 3, 3}));
  }
  
  [Test]
  public static void MixedSets1()
  {
    Assert.AreEqual(1100, Kata.Score(new int[] {1, 1, 1, 1, 3}));
  }
  
  [Test]
  public static void MixedSets2()
  {
    Assert.AreEqual(1150, Kata.Score(new int[] {1, 1, 1, 1, 5}));
  }
  
  [Test]
  public static void MixedSets3()
  {
    Assert.AreEqual(450, Kata.Score(new int[] {2, 4, 4, 5, 4}));
  }
  
  [Test]
  public static void MixedSets4()
  {
    Assert.AreEqual(350, Kata.Score(new int[] {3, 4, 5, 3, 3}));
  }
  
  [Test]
  public static void MixedSets5()
  {
    Assert.AreEqual(250, Kata.Score(new int[] {1, 5, 1, 3, 4}));
  }
}
