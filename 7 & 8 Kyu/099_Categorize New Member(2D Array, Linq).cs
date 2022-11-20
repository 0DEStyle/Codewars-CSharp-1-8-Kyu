/*Challenge link:https://www.codewars.com/kata/5502c9e7b3216ec63c0001aa/train/csharp
Question:
The Western Suburbs Croquet Club has two categories of membership, Senior and Open. They would like your help with an application form that will tell prospective members which category they will be placed.

To be a senior, a member must be at least 55 years old and have a handicap greater than 7. In this croquet club, handicaps range from -2 to +26; the better the player the lower the handicap.

Input
Input will consist of a list of pairs. Each pair contains information for a single potential member. Information consists of an integer for the person's age and an integer for the person's handicap.

Output
Output will consist of a list of string values (in Haskell and C: Open or Senior) stating whether the respective member is to be placed in the senior or open category.

Example
input =  [[18, 20], [45, 2], [61, 12], [37, 6], [21, 21], [78, 9]]
output = ["Open", "Open", "Senior", "Open", "Open", "Senior"]
*/

//***************Solution********************
//check member age array[0] is greater or equal to 55, and member handicap is greater than 7
//return senior if true, else open.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Collections.Generic;
using System.Linq;

public class Kata{
    public static IEnumerable<string> OpenOrSenior(int[][] data) =>
      data.Select(member => member[0] >= 55 && member[1] > 7 ? "Senior" : "Open");
}

//****************Sample Test*****************
namespace Solution
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    
    [TestFixture]
    public class KataOpenOrSeniorTests
    {
        [Test]
        public void SampleTest()
        {
            Assert.AreEqual(new[] { "Open", "Senior", "Open", "Senior" }, Kata.OpenOrSenior(new[] { new[] { 45, 12 }, new[] { 55, 21 }, new[] { 19, 2 }, new[] { 104, 20 } }));
            Assert.AreEqual(new[] { "Open", "Open", "Open", "Open" }, Kata.OpenOrSenior(new[] { new[] { 3, 12 }, new[] { 55, 1 }, new[] { 91, -2 }, new[] { 54, 23 } }));
            Assert.AreEqual(new[] { "Senior", "Open", "Open", "Open" }, Kata.OpenOrSenior(new[] { new[] { 59, 12 }, new[] { 45, 21 }, new[] { -12, -2 }, new[] { 12, 12 } }));
        }
    
        [Test]
        public void EdgeTest()
        {
            Assert.AreEqual(new List<string>().ToArray() , Kata.OpenOrSenior(new int[0][]),"Empty array");
            Assert.AreEqual(new[] { "Open", "Senior" }, Kata.OpenOrSenior(new[] { new[] { 54, 9 }, new[] { 55, 9 } }), "age for 'Senior' should be > 54");
            Assert.AreEqual(new[] { "Open", "Senior" }, Kata.OpenOrSenior(new[] { new[] { 55, 7 }, new[] { 55, 9 } }), "handicap for 'Senior' should be > 7");
        }
    
        [Test]
        public void SomeRandomTest()
        {
            var values = new List<Tuple<int[], string>>
            {
                new Tuple<int[], string>(new[] {1, 1}, "Open"),
                new Tuple<int[], string>(new[] {54, 9}, "Open"),
                new Tuple<int[], string>(new[] {90, 7}, "Open"),
                new Tuple<int[], string>(new[] {21, 21}, "Open"),
                new Tuple<int[], string>(new[] {0, 0}, "Open"),
                new Tuple<int[], string>(new[] {55, 10}, "Senior"),
                new Tuple<int[], string>(new[] {90, 8}, "Senior"),
                new Tuple<int[], string>(new[] {90, 9}, "Senior"),
                new Tuple<int[], string>(new[] {60, 12}, "Senior"),
                new Tuple<int[], string>(new[] {75, 11}, "Senior"),
            };
    
            Random r = new Random();
            for (int t = 0; t < 5; t++)
            {
                var input = new List<int[]>();
                var output = new List<string>();
                for (int k = 0; k < 10; k++)
                {
                    var index = r.Next(0, 9);
                    input.Add(values[index].Item1);
                    output.Add(values[index].Item2);
                }
                Assert.AreEqual(output.ToArray(), Kata.OpenOrSenior(input.ToArray()));
            }
    
        }
        
    }
}
