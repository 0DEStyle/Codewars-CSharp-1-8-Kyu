/*Challenge link:https://www.codewars.com/kata/566dc566f6ea9a14b500007b/train/csharp
Question:
Fix the bug in Filtering method
The method is supposed to remove even numbers from the list and return a list that contains the odd numbers.

However, there is a bug in the method that needs to be resolved.
*/

//***************Solution********************

//remove index at i-- instead of i
using System.Collections.Generic;
using System.Linq;

public class Kata{
        public static List<int> FilterOddNumber(List<int> listOfNumbers){
            for (int i = 0; i < listOfNumbers.Count; i++)
                if (listOfNumbers[i] % 2 == 0)
                    listOfNumbers.RemoveAt(i--);
            return listOfNumbers;
      }
}

//****************Sample Test*****************
using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

[TestFixture]
    public class MyTest
    {
        [Test]
        public void FirstTest()
        {
            List<int> listOfNumbers = new List<int>() {1, 2, 2, 2, 4, 3, 4, 5, 6, 7};
            List<int> expectedResult = new List<int>() {1, 3, 5, 7};
            StringAssert.AreEqualIgnoringCase(string.Join(",", expectedResult), string.Join(",", Kata.FilterOddNumber(listOfNumbers)));
        }

        [Test]
        public void SecondTest()
        {
            List<int> listOfNumbers = new List<int>() { 1, 2, 2, 2, 4, 3, 4 };
            List<int> expectedResult = new List<int>() { 1, 3 };
            StringAssert.AreEqualIgnoringCase(string.Join(",", expectedResult), string.Join(",", Kata.FilterOddNumber(listOfNumbers)));
        }

        [Test]
        public void RandomTest([Values(1)] int a, [Random(-1, 1, 30)] double d)
        {
            Rg rg = new Rg((int)d*10000);
            List<int> listOfNumbers = rg.GetListOfNumbers();
            List<int> initialList = listOfNumbers.GetRange(0, listOfNumbers.Count);
            string expectedResult = string.Join(",",Kata13December.FilterOddNumber(listOfNumbers));
            string theResult = string.Join(",",Kata.FilterOddNumber(listOfNumbers));
            StringAssert.AreEqualIgnoringCase(expectedResult, theResult,
                string.Format("for list: [{0}], the expected result is [{1}], but your code return [{2}]",
                    string.Join(",", initialList), expectedResult, theResult));

        }
    }
