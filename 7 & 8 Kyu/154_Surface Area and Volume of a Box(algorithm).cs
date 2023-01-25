/*Challenge link:https://www.codewars.com/kata/565f5825379664a26b00007c/train/csharp
Question:
Write a function that returns the total surface area and volume of a box as an array: [area, volume]
*/

//***************Solution********************
//apply algorithm
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
    public class Kata{
        public static int[] Get_size(int w,int h,int d) => new int[] {2*(h*w + h*d + w*d), w*h*d};
    }
//****************Sample Test*****************
using System;
using NUnit.Framework;

    [TestFixture]
    public class Test
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(new[] { 88, 48 }, Kata.Get_size(4, 2, 6));
            Assert.AreEqual(new[] { 6, 1 }, Kata.Get_size(1, 1, 1));
            Assert.AreEqual(new[] { 10, 2 }, Kata.Get_size(1, 2, 1));
            Assert.AreEqual(new[] { 16, 4 }, Kata.Get_size(1, 2, 2));
            Assert.AreEqual(new[] { 600, 1000 }, Kata.Get_size(10, 10, 10));
        }


        [Test]
        public void RandomTest([Values(1)] int a, [Random(-1, 1, 30)] double d)
        {
            Rg rg = new Rg((int)d * 10000);
            int x = rg.A();
            int y = rg.B();
            int z = rg.C();
            Assert.AreEqual(Kata15Feb.Get_size(x,y,z), Kata.Get_size(x,y,z));
        }
    }
