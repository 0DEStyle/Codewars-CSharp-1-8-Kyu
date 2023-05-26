/*Challenge link:https://www.codewars.com/kata/58e0f0bf92d04ccf0a000010/train/csharp
Question:
Every Friday and Saturday night, farmer counts amount of sheep returned back to his farm (sheep returned on Friday stay and don't leave for a weekend).

Sheep return in groups each of the days -> you will be given two arrays with these numbers (one for Friday and one for Saturday night). Entries are always positive ints, higher than zero.

Farmer knows the total amount of sheep, this is a third parameter. You need to return the amount of sheep lost (not returned to the farm) after final sheep counting on Saturday.

Example 1: Input: {1, 2}, {3, 4}, 15 --> Output: 5

Example 2: Input: {3, 1, 2}, {4, 5}, 21 --> Output: 6

Good luck! :-)
*/

//***************Solution********************
//find the sum for friday and saturday, then subtract from total to find the amount of lost sheep.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
namespace CodeWars{
    public class Kata{
        public int lostSheep(int[] friday, int[] saturday, int total) => total - (friday.Sum() + saturday.Sum());
    }
}

//****************Sample Test*****************
using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CodeWars
{
    [TestFixture]
    class KataTestClass
    {
        [TestCase]
        public void BasicTest1()
        {
            Kata kata = new Kata();
            int[] friday   = new int[] { 1, 2 };
            int[] saturday = new int[] { 3, 4 };
            Assert.AreEqual(5, kata.lostSheep(friday, saturday, 15));
        }

        [TestCase]
        public void BasicTest2()
        {
            Kata kata = new Kata();
            int[] friday = new int[] { 3, 1, 2 };
            int[] saturday = new int[] { 4, 5 };
            Assert.AreEqual(6, kata.lostSheep(friday, saturday, 21));
        }

        [TestCase]
        public void BasicTest3()
        {
            Kata kata = new Kata();
            int[] friday = new int[] { 5, 1, 4 };
            int[] saturday = new int[] { 5, 4 };
            Assert.AreEqual(10, kata.lostSheep(friday, saturday, 29));
        }

        [TestCase]
        public void AdvancedTest1()
        {
            Kata kata = new Kata();
            int[] friday = new int[] { 11, 23, 3, 4, 15 };
            int[] saturday = new int[] { 7, 14, 9, 21, 15 };
            Assert.AreEqual(178, kata.lostSheep(friday, saturday, 300));
        }
        [TestCase]
        public void AdvancedTest2()
        {
            Kata kata = new Kata();
            int[] friday = new int[] { 2, 7, 13, 17 };
            int[] saturday = new int[] { 23, 56, 44, 12, 1, 2, 1 };
            Assert.AreEqual(77, kata.lostSheep(friday, saturday, 255));
        }
        [TestCase]
        public void AdvancedTest3()
        {
            Kata kata = new Kata();
            int[] friday = new int[] { 2, 5, 8 };
            int[] saturday = new int[] { 11, 23, 3, 4, 15, 112, 12, 4 };
            Assert.AreEqual(156, kata.lostSheep(friday, saturday, 355));
        }
        [TestCase]
        public void AdvancedTest4()
        {
            Kata kata = new Kata();
            int[] friday = new int[] { 1, 1, 1, 2, 1, 2 };
            int[] saturday = new int[] { 2, 1, 2, 1, 2, 1 };
            Assert.AreEqual(13, kata.lostSheep(friday, saturday, 30));
        }
        [TestCase]
        public void AdvancedTest5()
        {
            Kata kata = new Kata();
            int[] friday = new int[] { 5, 10, 15 };
            int[] saturday = new int[] { 11, 23, 3, 4, 15 };
            Assert.AreEqual(3, kata.lostSheep(friday, saturday, 89));
        }
        [TestCase]
        public void AdvancedTest6()
        {
            Kata kata = new Kata();
            int[] friday = new int[] { 3, 6, 9, 12 };
            int[] saturday = new int[] { 3, 2, 1, 2, 3, 1 };
            Assert.AreEqual(2, kata.lostSheep(friday, saturday, 44));
        }

        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        public void RandomTest()
        {
            Kata kata = new Kata();
            Random ran = new Random();
            int n1 = ran.Next(1, 50);
            int n2 = ran.Next(1, 50);
            int lost = ran.Next(1, 40);
            int[] friday = new int[n1];
            int[] saturday = new int[n2];
            for(int iii = 0; iii < n1; iii++)
            {
                friday[iii] = ran.Next(1, 50);
            }
            for (int iii = 0; iii < n2; iii++)
            {
                saturday[iii] = ran.Next(1, 50);
            }
            int total = friday.Sum() + saturday.Sum() + lost;
            Assert.AreEqual(lost, kata.lostSheep(friday, saturday, total));
        }
    }
}
