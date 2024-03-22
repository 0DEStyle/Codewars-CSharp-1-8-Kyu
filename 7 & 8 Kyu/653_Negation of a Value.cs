/*Challenge link:https://www.codewars.com/kata/58f6f87a55d759439b000073/train/csharp
Question:
In programming you know the use of the logical negation operator (!), it reverses the meaning of a condition.

!false = true
!!false = false
Your task is to complete the function 'negationValue()' that takes a string of negations with a value and returns what the value would be if those negations were applied to it.

negationValue("!", false); //=> true
negationValue("!!!!!", true); //=> false
negationValue("!!", []); //=> true
Do not use the eval() function or the Function() constructor in JavaScript.

Note: Always return a boolean value, even if there're no negations.
*/

//***************Solution********************
//loop through each character in str, if c is '1', invert the bool value
//return value at the end
public class Kata{
  public static bool NegationValue(string str, bool value){
    foreach(char c in str)
      if(c == '!') value = !value;
    return value;
  }
}

//method 2
public class Kata
{
  public static bool NegationValue(string str, bool value) => value == (str.Length % 2 == 0);
}

//linq method
using System.Linq;

public class Kata
{
  public static bool NegationValue(string s, bool val) => s.Aggregate(val, (r,_) => !r);
}
//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;

  [TestFixture]
  public class SolutionTest
  {
    private static Random rnd = new Random();
    
    private static bool solution(string str, bool value) => (str.Length % 2 == 0) ? value : !value;
  
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        yield return new TestCaseData("!", false).Returns(true).SetDescription("Basic Test");
        yield return new TestCaseData("!", true).Returns(false).SetDescription("Basic Test");
        yield return new TestCaseData("!!!", false).Returns(true).SetDescription("Basic Test");
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public bool Test(string str, bool value) => Kata.NegationValue(str, value);
    
    [Test, Description("Random Tests")]
    public void RandomTests()
    {
      for (int i = 0; i < 100; ++i)
      {
        string str = new String('!', rnd.Next(1, 100));
        bool v = Convert.ToBoolean(rnd.Next(0, 2));
        bool expected = solution(str, v);
        bool actual = Kata.NegationValue(str, v);
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
