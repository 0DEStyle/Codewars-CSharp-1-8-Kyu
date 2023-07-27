/*Challenge link:https://www.codewars.com/kata/541af676b589989aed0009e7/train/csharp
Question:
Write a function that counts how many different ways you can make change for an amount of money, given an array of coin denominations. For example, there are 3 ways to give change for 4 if you have coins with denomination 1 and 2:

1+1+1+1, 1+1+2, 2+2.
The order of coins does not matter:

1+1+2 == 2+1+1
Also, assume that you have an infinite amount of coins.

Your function should take an amount to change and an array of unique denominations for the coins:

  CountCombinations(4, new[] {1,2}) // => 3
  CountCombinations(10, new[] {5,2,3}) // => 4
  CountCombinations(11, new[] {5,7}) //  => 0
*/

//***************Solution********************

//if money is less than 0 or coins is not empty, return 0
//if money is 0, return 1
//else using recursive method to accumulate the total combination, current count + next combination count by skiping 1.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;
public static class Kata{
    public static int CountCombinations(int money, int[] coins)=>
      (money < 0 || !coins.Any()) ? 0 : 
      (money == 0) ? 1 : 
      CountCombinations(money - coins[0], coins) + CountCombinations(money, coins.Skip(1).ToArray());
}

//faster method
using System;
public static class Kata
{
   public static int CountCombinations(int money, int[] coins)
   {
            int[] ways = new int[money + 1];
            ways[0] = 1;

            for (int i = 0; i < coins.Length; i++)
            {
                for (int j = coins[i]; j <= money; j++)
                {
                    ways[j] += ways[j - coins[i]];
                }
            }
     return ways[money];
   }
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class CodeWarsTest
{
        [Test]
        public static void SimpleCase()
        {
            Assert.AreEqual(3, Kata.CountCombinations(4, new[] { 1, 2 }));
        }
        
        [Test]
        public static void AnotherSimpleCase()
        {
            Assert.AreEqual(4, Kata.CountCombinations(10, new[] { 5, 2, 3 }));
        }
        
        [Test]
        public static void NoChange()
        {
            Assert.AreEqual(0, Kata.CountCombinations(11, new[] { 5, 7 }));
        }
        
        [Test]
        public static void Case1022()
        {
            Assert.AreEqual(1022, Kata.CountCombinations(300, new[] { 5,10,20,50,100,200,500}));
        }
        
        [Test]
        public static void Anther1022Case()
        {
            Assert.AreEqual(1022, Kata.CountCombinations(300, new[] { 500,5,50,100,20,200,10 }));
        }
        
        [Test]
        public static void Case0()
        {
            Assert.AreEqual(0, Kata.CountCombinations(301, new[] { 5,10,20,50,100,200,500 }));
        }
        
        [Test]
        public static void Case760()
        {
            Assert.AreEqual(760, Kata.CountCombinations(199, new[] { 3,5,9,15 }));
        }
        
        [Test]
        public static void Case19()
        {
            Assert.AreEqual(19, Kata.CountCombinations(98, new[] { 3,14,8 }));
        }
        
        [Test]
        public static void CaseTooMany()
        {
            Assert.AreEqual(18515, Kata.CountCombinations(419, new[] { 2,5,10,20,50 }));
        }
    }
