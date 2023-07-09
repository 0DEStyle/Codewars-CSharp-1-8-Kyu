/*Challenge link:https://www.codewars.com/kata/5a9e86705ee396d6be000091/train/csharp
Question:
Given an array with exactly 5 strings "a", "b" or "c" (chars in Java, characters in Fortran), check if the array contains three and two of the same values.

Examples
["a", "a", "a", "b", "b"] ==> true  // 3x "a" and 2x "b"
["a", "b", "c", "b", "c"] ==> false // 1x "a", 2x "b" and 2x "c"
["a", "a", "a", "a", "a"] ==> false // 5x "a" 
*/

//***************Solution********************
//check if distinct character in array is 2
//then check if the character in the array only appeared 2 or 3 times.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public class Kata{
    public static bool CheckThreeAndTwo(string[] array)=>
      array.Distinct().Count() == 2 && (array.Count(s => s == array[0]) == 2 || array.Count(s => s == array[0]) == 3);
}

//solution 2
using System.Linq;

public class Kata
{
  public static bool CheckThreeAndTwo(string[] array)
  {
    return array.GroupBy(s => s).All(g => new[] {2, 3}.Contains(g.Count()));
  }
}

//solution 3
using System.Linq;

public class Kata
{
  public static bool CheckThreeAndTwo(string[] array)
  {
    return array.GroupBy(s => s).All(g => g.Count() == 2 || g.Count() == 3);
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
        public static bool CheckThreeAndTwoTest(string[] array)
        {
            Dictionary<string, int> letters = new Dictionary<string, int>();
            foreach (string s in array)
            {
                if (letters.ContainsKey(s))
                    letters[s]++;
                else
                    letters.Add(s, 1);
            }

            if (letters.Count == 2)
            {
                bool hasTwo = false;
                bool hasThree = false;
                foreach (var item in letters)
                {
                    if (item.Value == 2) hasTwo = true;
                    if (item.Value == 3) hasThree = true;
                }
                return hasTwo && hasThree;
            }

            return false;
        }

        [Test]
        public void BasicTests()
        {
            RunTest(true, new string[] { "a", "a", "a", "b", "b" });
            RunTest(false, new string[] { "a", "c", "a", "c", "b" });
            RunTest(false, new string[] { "a", "a", "a", "a", "a" });
        }

        [Test]
        public void RandomTests()
        {
            string[] deck = new string[] { "a", "b", "c" };
            const int arraySize = 5;
            Random rand = new Random();

            for (int i = 0; i < 100; i++)
            {
                string[] array = new string[arraySize];
                for (int j = 0; j < arraySize; j++)
                {
                    array[j] = deck[rand.Next(0, deck.Length)];
                }

                RunTest(CheckThreeAndTwoTest(array), array);
            }
        }

        private void RunTest(bool expected, string[] array)
        {
            Console.WriteLine(string.Join(", ", array) + ": expect " + expected.ToString());
            Assert.AreEqual(expected, Kata.CheckThreeAndTwo(array));
        }
    }
}
