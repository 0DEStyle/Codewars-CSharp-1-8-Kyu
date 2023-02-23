/*Challenge link:https://www.codewars.com/kata/5a34af40e1ce0eb1f5000036/train/csharp
Question:
Create a function that returns the CSV representation of a two-dimensional numeric array.

Example:

input:
   [[ 0, 1, 2, 3, 4 ],
    [ 10,11,12,13,14 ],
    [ 20,21,22,23,24 ],
    [ 30,31,32,33,34 ]] 
    
output:
     '0,1,2,3,4\n'
    +'10,11,12,13,14\n'
    +'20,21,22,23,24\n'
    +'30,31,32,33,34'
Array's length > 2.

More details here: https://en.wikipedia.org/wiki/Comma-separated_values

FUNDAMENTALSARRAYSSTRINGS
*/

//***************Solution********************
//join each elemenets in x with ","
//then join second array with "\n"
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public static class Kata{
  public static string ToCsvText(int[][] array) => string.Join("\n",array.Select(x=> string.Join(",",x)));
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Linq;

[TestFixture]
public class SolutionTest
{
    [Test]
    public void SampleTest()
    {
        Assert.AreEqual("0,1,2,3,45\n10,11,12,13,14\n20,21,22,23,24\n30,31,32,33,34",
            Kata.ToCsvText(new[]
            {
                new[] {0, 1, 2, 3, 45},
                new[] {10, 11, 12, 13, 14},
                new[] {20, 21, 22, 23, 24},
                new[] {30, 31, 32, 33, 34}
            })
        );

        Assert.AreEqual("-25,21,2,-33,48\n30,31,-32,33,-34",
            Kata.ToCsvText(new[]
            {
                new[] {-25, 21, 2, -33, 48},
                new[] {30, 31, -32, 33, -34}
            })
        );

        Assert.AreEqual("5,55,5,5,55\n6,6,66,23,24\n666,31,66,33,7",
            Kata.ToCsvText(new[]
            {
                new[] {5, 55, 5, 5, 55},
                new[] {6, 6, 66, 23, 24},
                new[] {666, 31, 66, 33, 7}
            })
        );
    }

    private static readonly Random Rand = new();

    [Test]
    public void RandomTest()
    {
        for (var i = 0; i < 100; i++)
        {
            var randomArray = RandomArray();

            var expected = string.Join("\n", randomArray.Select(x => string.Join(",", x)));
            var message = FailureMessage(randomArray, expected);
            var actual = Kata.ToCsvText(randomArray);

            Assert.AreEqual(expected, actual, message);
        }
    }

    private static int[][] RandomArray()
    {
        var length = Rand.Next(2, 10);
        var lengthElement = Rand.Next(2, 10);

        return Enumerable.Range(1, length)
            .Select(x => Enumerable.Range(1, lengthElement)
                .Select(i => Rand.Next(0, 10)).ToArray()).ToArray();
    }

    private static string FailureMessage(int[][] array, string value)
    {
        var arrayStr = string.Join("\n", array.Select(x => "[" + string.Join(",", x) + "]"));
        return $"Should return\n{value}\nwith\n{arrayStr}";
    }
}
