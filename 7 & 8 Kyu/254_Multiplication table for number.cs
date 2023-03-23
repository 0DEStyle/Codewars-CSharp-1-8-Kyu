/*Challenge link:https://www.codewars.com/kata/5a2fd38b55519ed98f0000ce/train/csharp
Question:
Your goal is to return multiplication table for number that is always an integer from 1 to 10.

For example, a multiplication table (string) for number == 5 looks like below:

1 * 5 = 5
2 * 5 = 10
3 * 5 = 15
4 * 5 = 20
5 * 5 = 25
6 * 5 = 30
7 * 5 = 35
8 * 5 = 40
9 * 5 = 45
10 * 5 = 50
P. S. You can use \n in string to jump to the next line.

Note: newlines should be added between rows, but there should be no trailing newline at the end. If you're unsure about the format, look at the sample tests.
*/

//***************Solution********************
//create a list to store all the string for multiplication table
//join the string together with \n
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;
using System.Collections.Generic;

public static class Kata
{
    public static string MultiTable(int number){
      List<string> str = new List<string>();
      int ans = 0;
      for (int i = 1; i <= 10; i++){
        ans = i * number;
        str.Add($"{i} * {number} = {ans}");
      }
      return string.Join("\n",str);
    }
}

//solution 2
using System.Linq;

public static class Kata
{
  public static string MultiTable(int number)
  {
    return string.Join("\n", Enumerable.Range(1, 10).Select(i => $"{i} * {number} = {i * number}"));
  }
}

//****************Sample Test*****************
using System;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class KataTests
{
    [Test]
    public void BasicTest()
    {
        var one =
            "1 * 1 = 1\n2 * 1 = 2\n3 * 1 = 3\n4 * 1 = 4\n5 * 1 = 5\n6 * 1 = 6\n7 * 1 = 7\n8 * 1 = 8\n9 * 1 = 9\n10 * 1 = 10";
        Assert.AreEqual(one, Kata.MultiTable(1));

        var five =
            "1 * 5 = 5\n2 * 5 = 10\n3 * 5 = 15\n4 * 5 = 20\n5 * 5 = 25\n6 * 5 = 30\n7 * 5 = 35\n8 * 5 = 40\n9 * 5 = 45\n10 * 5 = 50";
        Assert.AreEqual(five, Kata.MultiTable(5));
    }

    private static string Solution(int number)
    {
        return string.Join("\n", Enumerable.Range(1, 10).Select(i => $"{i} * {number} = {i * number}"));
    }


    [Test]
    public void MultiTableTest()
    {
        for (var i = 1; i <= 10; i++)
        {
            var actual = Kata.MultiTable(i);
            var message = FailureMessage(i);
            var expected = Solution(i);

            Assert.AreEqual(expected, actual, message);
        }
    }

    private static readonly Random Rand = new Random();

    [Test]
    public void RandomTest()
    {
        for (var i = 0; i < 50; i++)
        {
            int n = Rand.Next(1, 11); //1..10
            var expected = Kata.MultiTable(n);
            var message = FailureMessage(n);
            var actual = Solution(n);

            Assert.AreEqual(expected, actual, message);
        }
    }

    private static string FailureMessage(int value)
    {
        return $"Incorrect answer for {value}";
    }
}
