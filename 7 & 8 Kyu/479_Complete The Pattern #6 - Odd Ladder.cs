/*Challenge link:https://www.codewars.com/kata/5574940eae1cf7d520000076/train/csharp
Question:
###Task:

You have to write a function pattern which creates the following pattern (see examples) up to the desired number of rows.

If the Argument is 0 or a Negative Integer then it should return "" i.e. empty string.

If any even number is passed as argument then the pattern should last upto the largest odd number which is smaller than the passed even number.

###Examples:

pattern(9):

1
333
55555
7777777
999999999
pattern(6):

1
333
55555
Note: There are no spaces in the pattern

Hint: Use \n in string to jump to next line


*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

//if n is less than 1, return empty string.
//x and y are current elements
//else generate number start from 1, count up to n
//get elements that is odd, concat the result by repeating character y by y times.
//join the element strings by "\n" and return the result.
using System;
using System.Linq;

public static class Kata{
  public static string OddLadder(int n) =>
        n < 1 ? "" : 
        string.Join("\n", Enumerable.Range(1,n)
              .Where(x => x % 2 == 1)
              .Select(y => string.Concat(Enumerable.Repeat(y,y))));
}
//****************Sample Test*****************
using System;
using System.Text;
using NUnit.Framework;

[TestFixture]
public class OddLadderTests
{
  [Test]
  public void Test_4()
  {
    Assert.AreEqual("1\n333", Kata.OddLadder(4), "Nope!");
  }

  [Test]
  public void Test_1()
  {
    Assert.AreEqual("1", Kata.OddLadder(1), "Nope!");
  }

  [Test]
  public void Test_5()
  {
    Assert.AreEqual("1\n333\n55555", Kata.OddLadder(5), "Nope!");
  }

  [Test]
  public void Test_0()
  {
    Assert.AreEqual("", Kata.OddLadder(0), "Nope!");
  }

  [Test]
  public void Test_Negative25()
  {
    Assert.AreEqual("", Kata.OddLadder(-25), "Nope!");
  }
  
  [Test]
  public void Test_Random([Random(1, 100, 40)] int randInt)
  {
    randInt -= 10;
    
    Console.WriteLine("Test_Random ({0})", randInt);
    for (int i = 0; i < 40; i++) {
      Assert.AreEqual(OddLadder(randInt), Kata.OddLadder(randInt), "Nope!");
    }
  }
  
  private static string OddLadder(int n)
  {
    var stringBuilder = new StringBuilder();
    
    if (n <= 0) {
      return "";
    }
    
    if (IsEven(n)) { n--; }
    for (int i = 1; i <= n; i++) {
      if (IsEven(i)) continue;
      for (int j = 0; j < i; j++) {
        stringBuilder.Append(i);
      }
      if (i < n) { stringBuilder.Append("\n"); }
    }
    
    return stringBuilder.ToString();
  }
  
  private static bool IsEven(int n)
  {
    return (n % 2 == 0);
  }
}
