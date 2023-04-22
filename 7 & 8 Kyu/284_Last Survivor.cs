/*Challenge link:https://www.codewars.com/kata/609eee71109f860006c377d1/train/csharp
Question:
You are given a string of letters and an array of numbers.
The numbers indicate positions of letters that must be removed, in order, starting from the beginning of the array.
After each removal the size of the string decreases (there is no empty space).
Return the only letter left.

Example:

let str = "zbk", arr = [0, 1]
    str = "bk", arr = [1]
    str = "b", arr = []
    return 'b'
Notes
The given string will never be empty.
The length of the array is always one less than the length of the string.
All numbers are valid.
There can be duplicate letters and numbers.
If you like this kata, check out the next one: Last Survivors Ep.2
*/

//***************Solution********************
//aggregate the numbers in coords
//start removing from the string "letters" at index by the length of 1
//return whatever is left as the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public static class Kata{
    public static string LastSurvivor(string letters, int[] coords)=>
       coords.Aggregate(letters, (current, index) => current.Remove(index, 1));
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
        private static void Act(string letters, int[] coords, string expected)
        {
            var msg = $"Invalid answer for letters: \"{letters}\" and coords: [{string.Join(",", coords)}]";
            var actual = Kata.LastSurvivor(letters, coords);
            Assert.AreEqual(expected, actual, msg);
        }
      
        [TestCase("abc", new int[]{1, 1}, "a", Description = "letters: \"abc\"  coords: [1, 1]")]
        [TestCase("kbc", new int[]{0, 1}, "b", Description = "letters: \"kbc\"  coords: [0, 1]")]
        [TestCase("zbk", new int[]{2, 1}, "z", Description = "letters: \"zbk\"  coords: [2, 1]")]
        [TestCase("c", new int[0], "c", Description = "letters: \"c\"  coords: []")]
        [TestCase("foiflxtpicahhkqjswjuyhmypkrdbwnmwbrrvdycqespfvdviucjoyvskltqaqirtjqulprjjoaiagobpftywabqjdmiofpsr", new int[]{8, 59, 52, 93, 21, 40, 88, 85, 59, 10, 82, 18, 74, 59, 51, 47, 75, 49, 23, 56, 1, 33, 39, 33, 34, 44, 25, 0, 51, 25, 36, 32, 57, 10, 57, 12, 51, 55, 24, 55, 31, 49, 6, 15, 10, 48, 27, 29, 38, 30, 35, 42, 23, 32, 9, 39, 39, 36, 8, 29, 2, 33, 14, 3, 13, 25, 9, 25, 18, 10, 1, 2, 20, 8, 2, 11, 5, 7, 0, 10, 10, 8, 12, 3, 5, 1, 7, 7, 5, 1, 4, 0, 4, 0, 0, 1}, "d", Description = "long example")]
        public void FixedTests(string letters, int[] coords, string expected)
        {
            Act(letters, coords, expected);
        }
      
        [TestCaseSource(nameof(GenerateTestCases))]
        public void RandomTests((string, int[], string) testCase)
        {
            var (letters, coords, expected) = testCase;
            Act(letters, coords, expected);
        }
      
        private static IEnumerable<TestCaseData> GenerateTestCases()
        {
            var rnd = new Random();
            for (var i = 0; i < 100; ++i) yield return GenerateTestCase(rnd, i+1);
        }
      
        private static TestCaseData GenerateTestCase(Random rnd, int n)
        {
            string ReferenceSolution(string refLetters, int[] refCoords)
            {
                var xs = refLetters.ToArray();
                foreach (var p in refCoords) xs = xs.Take(p).Concat(xs.Skip(p + 1)).ToArray();
                return new string(xs);
            }
    
            int RandomInt(int a, int b) => (int)(rnd.Next(b - a)) + a;
            string Join<T>(T[] src, string delim="") => string.Join(delim, src);
            T[] Shuffle<T>(T[] src) => src.OrderBy(_=>RandomInt(-1,2)).ToArray();
            T[] Choices<T>(T[] src, int k) => Shuffle(src).Take(k).ToArray();
          
            var alphaLower = "abcdefghijklmnopqrstuvwxyz".ToArray();
            string RandomWord(char[] options=null, int mini=1, int maxi=100) 
                => Join(Choices(options ?? alphaLower, RandomInt(mini, maxi)));
            int[] RandomCoords(string s)
                => s.Skip(1).Select((c,i) => RandomInt(0, s.Length - i)).ToArray();
          
            var letters = RandomWord();
            var coords = RandomCoords(letters);
            var expected = ReferenceSolution(letters, coords);
          
            return new TestCaseData((letters, coords, expected))
            {
                HasExpectedResult = false
                  
            }.SetDescription($"Test {n}");
        }
    }
}
