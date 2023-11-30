/*Challenge link:https://www.codewars.com/kata/5e96332d18ac870032eb735f/train/csharp
Question:
As you may know, once some people pass their teens, they jokingly only celebrate their 20th or 21st birthday, forever. With some maths skills, that's totally possible - you only need to select the correct number base!

For example, if they turn 32, that's exactly 20 - in base 16... Already 39? That's just 21, in base 19!

Your task is to translate the given age to the much desired 20 (or 21) years, and indicate the number base, in the format specified below.

Note: input will be always > 21

Examples:
32  -->  "32? That's just 20, in base 16!"
39  -->  "39? That's just 21, in base 19!"
Hint: if you don't know (enough) about numeral systems and radix, just observe the pattern!
*/

//***************Solution********************

//n % 2 to get either 0 or 1 (because number can only be 20 or 21)
//n / 2 to get the base number.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
namespace Solution{
    using System;
    public class Kata{
       public static string WomensAge(int  n) =>  $"{n}? That's just 2{n % 2}, in base {n / 2}!";
    }
}

//solution 2
namespace Solution
{
    public class Kata
    {
        public static string WomensAge(int n)
        => $"{n}? That's just {(n % 2 == 0 ? 20 : 21)}, in base {n / 2}!";
    }
}

//solution 3
namespace Solution
{
    using System;
    
    public class Kata
    {
       public static string WomensAge(int  n)
       {
            var firstdigit = n / 2;
            var secdigit = n % firstdigit;
            return string.Format("{0}? That's just 2{1}, in base {2}!",n,secdigit,firstdigit);
       }
    }
}
//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;

  // TODO: Replace examples and use TDD by writing your own tests

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void BasicTest()
    {
      Assert.AreEqual("32? That's just 20, in base 16!", Kata.WomensAge(32));
      Assert.AreEqual("39? That's just 21, in base 19!", Kata.WomensAge(39));
      Assert.AreEqual("22? That's just 20, in base 11!", Kata.WomensAge(22));
      Assert.AreEqual("65? That's just 21, in base 32!", Kata.WomensAge(65));
      Assert.AreEqual("83? That's just 21, in base 41!", Kata.WomensAge(83));
    }
    [Test]
    public void RandomTest()
    {
      Random rnd = new Random();
      for(int x=0; x<50; x++)
      {
      int randomAge = rnd.Next(22, 100);
      Assert.AreEqual($"{randomAge}? That's just {20+randomAge%2}, in base {Math.Floor((decimal)randomAge/2)}!", Kata.WomensAge(randomAge));
      }
    }
    
  }
}
