/*Challenge link:https://www.codewars.com/kata/566dc05f855b36a031000048/train/csharp
Question:
Add an item to the list:

AddExtra method adds a new item to the list and returns the list. The new item can be any object, and it does not matter. (lets say you add an integer value, like 13)

In our test case we check to assure that the returned list has one more item than the input list. However the method needs some modification to pass this test.

P.S. You have to create a new list and add a new item to that. (This Kata is originally designed for C# language and it shows that adding a new item to the input list is not going to work, even though the parameter is passed by value, but the value is poining to the reference of list and any change on parameter will be seen by caller)


*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Collections.Generic;

public class AddMore{
        public static List<int> AddExtra(List<int> listOfNumbers) => new List<int>(listOfNumbers) { 0 };
}

//****************Sample Test*****************
using System;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
    public class AddMoreTest
    {
        [Test]
        public void FirstTest()
        {
            List<int> listOfNumbers = new List<int>() { 1, 2, 2, 2, 4, 3, 4, 5, 6, 7 };
            Assert.AreEqual((AddMore.AddExtra(listOfNumbers)).Count, listOfNumbers.Count + 1);
        }

        [Test]
        public void RandomTest([Values(1)] int a, [Random(-1, 1, 30)] double d)
        {
            AddMoreRg rg = new AddMoreRg((int)d * 10000);
            List<int> listOfNumbers = rg.GetListOfNumbers();
            Assert.AreEqual((AddMore.AddExtra(listOfNumbers)).Count,listOfNumbers.Count + 1 );
        }
    }
