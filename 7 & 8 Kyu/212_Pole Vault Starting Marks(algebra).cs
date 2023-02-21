/*Challenge link:https://www.codewars.com/kata/5786f8404c4709148f0006bf/train/csharp
Question:For a pole vaulter, it is very important to begin the approach run at the best possible starting mark. This is affected by numerous factors and requires fine-tuning in practice. But there is a guideline that will help a beginning vaulter start at approximately the right location for the so-called "three-step approach," based on the vaulter's body height.

This guideline was taught to me in feet and inches, but due to the international nature of Codewars, I am creating this kata to use metric units instead.

You are given the following two guidelines to begin with: (1) A vaulter with a height of 1.52 meters should start at 9.45 meters on the runway. (2) A vaulter with a height of 1.83 meters should start at 10.67 meters on the runway.

You will receive a vaulter's height in meters (which will always lie in a range between a minimum of 1.22 meters and a maximum of 2.13 meters). Your job is to return the best starting mark in meters, rounded to two decimal places.

Hint: Based on the two guidelines given above, you will want to account for the change in starting mark per change in body height. This involves a linear relationship. But there is also a constant offset involved. If you can determine the rate of change described above, you should be able to determine that constant offset.
*/

//***************Solution********************
//apply algorithm, and round answer to 2 decimal places.
using System;

class PoleVault
{
    public static double StartingMark(double bodyHeight)
    {
      // Remember: Body height of 1.52 m --> starting mark: 9.45 m
      //           Body height of 1.83 m --> starting mark: 10.67 m
      //slope intercept formula : y = mx + b; b = y - mx 
      //slope formula m = (y2 - y1) / (x2 - x1)
      
      var m = (10.67 - 9.45) / (1.83 - 1.52);
      var y = m * bodyHeight + 9.45;
      var b = y - m * 1.52;
      return Math.Round(b,2);
    }
}

//****************Sample Test*****************
namespace Solution
{
    using NUnit.Framework;
    using System;
    
    [TestFixture]
    public class SolutionTest
    {
        private delegate double Solution(double bodyHeight);
    
        private static Random random = new Random();
    
        [Test]
        public void ExampleTests()
        {
            Assert.AreEqual(9.45, PoleVault.StartingMark(1.52));
            Assert.AreEqual(10.67, PoleVault.StartingMark(1.83));
            Assert.AreEqual(8.27, PoleVault.StartingMark(1.22));
            Assert.AreEqual(11.85, PoleVault.StartingMark(2.13));
        }
        
        [Test]
        public void MoreTests()
        {
            Assert.AreEqual(10.36, PoleVault.StartingMark(1.75));
            Assert.AreEqual(11.34, PoleVault.StartingMark(2.00));
            Assert.AreEqual(11.10, PoleVault.StartingMark(1.94));
        }
        
        [Test]
        public void RandomTests()
        {
            Solution solution = (bodyHeight) =>
            {
                double m = (10.67 - 9.45)/(1.83 - 1.52);
                double b = 10.67 - 1.83*m;
          
                return Math.Round(bodyHeight*m + b, 2);
            };
        
        
            for(int i = 0; i < 100; i++)
            {
                double randomInput = random.Next(122, 214)/100.0;
                
                Assert.AreEqual(solution(randomInput), PoleVault.StartingMark(randomInput));
            }
        }
    }
}
