/*Challenge link:https://www.codewars.com/kata/5a58d889880385c2f40000aa/train/csharp
Question:
Definition
A number is called Automorphic number if and only if its square ends in the same digits as the number itself.

Task
Given a number determine if it Automorphic or not .

Warm-up (Highly recommended)
Playing With Numbers Series
Notes
The number passed to the function is positive
Input >> Output Examples
autoMorphic (25) -->> return "Automorphic" 
Explanation:
25 squared is 625 , Ends with the same number's digits which are 25 .

autoMorphic (13) -->> return "Not!!"
Explanation:
13 squared is 169 , Not ending with the same number's digits which are 69 .

autoMorphic (76) -->> return "Automorphic"
Explanation:
76 squared is 5776 , Ends with the same number's digits which are 76 .

autoMorphic (225) -->> return "Not!!"
Explanation:
225 squared is 50625 , Not ending with the same number's digits which are 225 .

autoMorphic (625) -->> return "Automorphic"
Explanation:
625 squared is 390625 , Ends with the same number's digits which are 625 .

autoMorphic (1) -->> return "Automorphic"
Explanation:
1 squared is 1 , Ends with the same number's digits which are 1 .

autoMorphic (6) -->> return "Automorphic"
Explanation:
6 squared is 36 , Ends with the same number's digits which are 6

Playing with Numbers Series
Playing With Lists/Arrays Series
For More Enjoyable Katas
ALL translations are welcomed
Enjoy Learning !!
Zizou
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Linq;
class Kata{
    public static string Automorphic(int n) => (n*n).ToString().EndsWith(n.ToString()) ? "Automorphic" : "Not!!";
}
//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
class Tests
{
    [TestCase(1, "Automorphic")]
    [TestCase(3, "Not!!")]
    [TestCase(6, "Automorphic")]
    [TestCase(9, "Not!!")]
    [TestCase(25, "Automorphic")]
    [TestCase(53, "Not!!")]
    [TestCase(76, "Automorphic")]
    [TestCase(95, "Not!!")]
    [TestCase(625, "Automorphic")]
    [TestCase(225, "Not!!")]
    public void BasicTests(int n, string expected)
    {
        Assert.That(Kata.Automorphic(n), Is.EqualTo(expected));
    }
    [Test]
    public void RandomTest()
    {
        for (int i = 0; i < 100; i++)
        {
            var n = FindNumber();
            var expected = SolutionAutomorphic(n);
            Assert.That(Kata.Automorphic(n), Is.EqualTo(expected));
        }
    }

    int FindNumber()
    {
        var rnd = new Random();
        var a = new[] { 1, 5, 6, 25, 76, 376, 625, 9376 };
        return rnd.Next(0, 2) == 0 ? a[rnd.Next(0, 8)] : rnd.Next(0, 1000);
    }

    string SolutionAutomorphic(int n) => (n * n).ToString().EndsWith(n.ToString()) ? "Automorphic" : "Not!!";
}
