/*Challenge link:https://www.codewars.com/kata/525d9b1a037b7a9da7000905/train/csharp
Question:
While developing a website, you detect that some of the members have troubles logging in. Searching through the code you find that all logins ending with a "_" make problems. So you want to write a function that takes an array of pairs of login-names and e-mails, and outputs an array of all login-name, e-mails-pairs from the login-names that end with "_".

If you have the input-array:

[ [ "foo", "foo@foo.com" ], [ "bar_", "bar@bar.com" ] ]
it should output

[ [ "bar_", "bar@bar.com" ] ]
You have to use the filter-method which returns each element of the array for which the filter-method returns true.

https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Array/filter
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

//x is the current element, from logins, get first, check if it ends with '_'
//convert the elements to array and return the result.
using System.Linq;

public class Kata{
        public static string[][] search_names(string[][] logins) =>
          logins.Where(x => x.First().EndsWith('_')).ToArray();
}

//solution 2
using System;
using System.Linq;

public class Kata
{
  public static string[][] search_names(string[][] logins)
  {
    return logins.Where(x => x[0][^1] == '_').ToArray();
  }
}
//****************Sample Test*****************
using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

    [TestFixture]
    public class Test
    {
        [Test]
        public void Test1()
        {
            string[][] a = { new[] { "foo", "foo@foo.com" }, new[] { "bar_", "bar@bar.com" } };
            string[][] b = { new[] { "bar_", "bar@bar.com" } };
            Assert.That(b,Is.EquivalentTo(Kata.search_names(a)));
        }

        [Test]
        public void Test2()
        {
            string[][] a = { new[] { "foo_", "foo@foo.com" }, new[] { "bar_", "bar@bar.com" } };
            string[][] b = { new[] { "foo_", "foo@foo.com" }, new[] { "bar_", "bar@bar.com" } };
            Assert.That(b, Is.EquivalentTo(Kata.search_names(a)));
        }

        [Test]
        public void Test3()
        {
            string[][] a = { new[] { "foo", "foo@foo.com" }, new[] { "bar", "bar@bar.com" } };
            string[] b = new string[0];
            Assert.That(b, Is.EquivalentTo(Kata.search_names(a)));
        }

        [Test]
        public void RandomTest([Values(1)] int a, [Random(-1, 1, 10)] double d)
        {
            RG rg = new RG((int)d * 10000);
            string[][] myArray = rg.MyArray();
            Assert.That(Kata12Feb.search_names(myArray), Is.EquivalentTo(Kata.search_names(myArray)));
        }
    }
