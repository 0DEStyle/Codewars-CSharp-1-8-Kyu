/*Challenge link:https://www.codewars.com/kata/5842df8ccbd22792a4000245/train/csharp
Question:
Write Number in Expanded Form
You will be given a number and you will need to return it as a string in Expanded Form. For example:

Kata.ExpandedForm(12); # Should return "10 + 2"
Kata.ExpandedForm(42); # Should return "40 + 2"
Kata.ExpandedForm(70304); # Should return "70000 + 300 + 4"
NOTE: All numbers will be whole numbers greater than 0.
*/

//***************Solution********************
//string interpolation ${num} to get number in string form
//.Select((c, i) iterate the character through the string form 
//c = current, i start from 0
//current number + whatever amount of 0 needed
//repeat as long as x[0] is not '0'
//join string by " + " and return the result
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Linq;

public static class Kata {
    public static string ExpandedForm(long num) =>
      string.Join(" + ",$"{num}".Select((c, i) => c + new string('0', $"{num}".Length - i - 1)).Where(x => x[0] != '0'));
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Text;
  using System.Linq;
  using System.Collections.Generic;
  // TODO: Replace examples and use TDD development by writing your own tests

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual("2", Kata.ExpandedForm(2));
      Assert.AreEqual("10 + 2", Kata.ExpandedForm(12));
      Assert.AreEqual("40 + 2", Kata.ExpandedForm(42));
      Assert.AreEqual("70000 + 300 + 4", Kata.ExpandedForm(70304));
      Assert.AreEqual("4000000 + 900000 + 80000 + 2000 + 300 + 40 + 2", Kata.ExpandedForm(4982342));
    }
    
    [Test]
    public void EdgeCases()
    {
      Assert.AreEqual("400000000 + 20000000 + 300000 + 70000 + 20 + 2", Kata.ExpandedForm(420370022));
      Assert.AreEqual("70000 + 300 + 4", Kata.ExpandedForm(70304));
      Assert.AreEqual("9000000", Kata.ExpandedForm(9000000));
      Assert.AreEqual("90000000000000 + 2000000000000 + 90000000000 + 3000000000 + 400000000 + 3000000 + 30000 + 4000 + 500 + 70 + 3", Kata.ExpandedForm(92093403034573));
      Assert.AreEqual("2000000000000 + 90000000000 + 6000000000 + 30000000 + 9000000 + 400000 + 80000 + 5000 + 200 + 90 + 3", Kata.ExpandedForm(2096039485293));
    }
    
    public static string ExpandedForm(long num)
    {
        var list = new List<long>();
        var exp = 1L;
        while (num > 0)
        {
            var r = num % 10;
            list.Add(r * exp);
            num /= 10;
            exp *= 10;
        }
        list.Reverse();
        return string.Join(" + ", list.Where(x => x != 0));
    }
    
    [Test]
    public void RandomTest()
    {
      //Create random number generator object
      Random rnd = new Random();
      //Loop 100 times
      for(int i = 0; i < 100; i++){
        //Get next integer random number 1<=num<1000000
        int num = rnd.Next(1,10000000);
        //Compare my result: solution(num) with provided by user: Kata.ExpandedForm(num)
        Assert.AreEqual(ExpandedForm(num), Kata.ExpandedForm(num));
      }   
    }
    
  }
}
