/*Challenge link:https://www.codewars.com/kata/5648b12ce68d9daa6b000099/train/csharp
Question:
There is a bus moving in the city, and it takes and drop some people in each bus stop.

You are provided with a list (or array) of integer pairs. Elements of each pair represent number of people get into bus (The first item) and number of people get off the bus (The second item) in a bus stop.

Your task is to return number of people who are still in the bus after the last bus station (after the last array). Even though it is the last bus stop, the bus is not empty and some people are still in the bus, and they are probably sleeping there :D

Take a look on the test cases.

Please keep in mind that the test cases ensure that the number of people in the bus is always >= 0. So the return integer can't be negative.

The second value in the first integer array is 0, since the bus is empty in the first bus stop.
*/

//***************Solution********************
//find the sum of difference between each stop, return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Collections.Generic;
using System.Linq;

public class Kata{
  public static int Number(List<int[]> L) =>L.Sum(x => x[0] - x[1]);
}

//****************Sample Test*****************

  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  
  
    [TestFixture]
    public class MyTest
    {
        [Test]
        public void FirstTest()
        {
            List<int[]> peopleList = new List<int[]>(){new []{10,0},new []{3,5}, new []{5,8}};
            Assert.AreEqual(5,Kata.Number(peopleList));
        }
        [Test]
        public void SecondTest()
        {
            List<int[]> peopleList = new List<int[]>() { new[] { 3, 0 }, new[] { 9, 1 }, new[] { 4, 10 }, new[] { 12, 2 }, new[] { 6, 1 }, new[] { 7, 10 } };
            Assert.AreEqual(17, Kata.Number(peopleList));
        }
        [Test]
        public void ThirdTest()
        {
            List<int[]> peopleList = new List<int[]>() { new[] { 3, 0 }, new[] { 9, 1 }, new[] { 4, 8 }, new[] { 12, 2 }, new[] { 6, 1 }, new[] { 7, 8 } };
            Assert.AreEqual(21, Kata.Number(peopleList));
        }
        [Test]
        public void RandomTest([Values(1)] int a, [Random(-1, 1, 30)] double d)
        {
            Rg rg = new Rg((int)d*10000);
            List<int[]> objectList = rg.PeopleListInOut();
            Assert.AreEqual(KataTest.Number(objectList),Kata.Number(objectList),string.Format("The output expect {0} but it returns {1}", KataTest.Number(objectList),Kata.Number(objectList)));
        }
    }
