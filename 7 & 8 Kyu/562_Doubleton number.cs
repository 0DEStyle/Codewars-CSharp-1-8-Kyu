/*Challenge link:https://www.codewars.com/kata/604287495a72ae00131685c7/train/csharp
Question:
We will call a natural number a "doubleton number" if it contains exactly two distinct digits. For example, 23, 35, 100, 12121 are doubleton numbers, and 123 and 9980 are not.

For a given natural number n (from 1 to 1 000 000), you need to find the next doubleton number. If n itself is a doubleton, return the next bigger than n.

Examples:
Doubleton(120) == 121
Doubleton(1234) == 1311
Doubleton(10) == 12
*/

//***************Solution********************
//convert num to string, find all distinct and count to see if it is not equal to 2
//add 1 each iteration
//return next doubleton num.
using System.Linq;

public static class Kata{
    public static int Doubleton(int num){
      while((++num).ToString().Distinct().Count() != 2);
       return num;
    }
}


//solution 2
using System.Linq;

public static class Kata
{
    public static int Doubleton(int num)
    {
       return (++num).ToString().Distinct().Count() == 2 ? num : Doubleton(num);
    }
}

//solution 3
using System.Linq;

public static class Kata
{
    public static int Doubleton(int num)
    {
        while ($"{++num}".Distinct().Count() != 2); return num;
    }
}
//****************Sample Test*****************
namespace Solution
{
    using NUnit.Framework;
    using System;
    using System.Linq;
  
    [TestFixture]
    public class SolutionTest 
    {
        private static void Act(int num, int expected)
        {
            var actual = Kata.Doubleton(num);
            Assert.AreEqual(expected, actual, $"Input: num = {num}");
        }
      
        [Test(Description = "Fixed Tests")]
        public void FixedTests()
        {
            Act(120, 121);
            Act(1234, 1311);
            Act(1, 10);
            Act(10, 12);
        }

        private static int solver(int num)
        {
            while ($"{++num}".Distinct().Count() != 2); return num;
        }
      
        [Test(Description = "Random Tests Medium")]
        public void RandomTestsMedium() 
        {
            var rand = new Random();
            for (var i = 0; i < 50; i++) 
            {
                var num = (int)(rand.Next(1000)) + 1; 
                var expected = solver(num);
                Act(num, expected);  
            }
        }
      
        [Test(Description = "Random Tests Large")]
        public void RandomTestsLarge() 
        {
            var rand = new Random();
            for (var i = 0; i < 50; i++) 
            {
                var num = (int)(rand.Next(1000000)) + 1000; 
                var expected = solver(num);
                Act(num, expected);  
            }
        }
    }
}
