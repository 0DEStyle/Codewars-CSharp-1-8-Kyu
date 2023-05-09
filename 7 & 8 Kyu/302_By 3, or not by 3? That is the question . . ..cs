/*Challenge link:https://www.codewars.com/kata/59f7fc109f0e86d705000043/train/csharp
Question:
A trick I learned in elementary school to determine whether or not a number was divisible by three is to add all of the integers in the number together and to divide the resulting sum by three. If there is no remainder from dividing the sum by three, then the original number is divisible by three as well.

Given a series of digits as a string, determine if the number represented by the string is divisible by three.

Example:

"123"      -> true
"8409"     -> true
"100853"   -> false
"33333333" -> true
"7"        -> false
Try to avoid using the % (modulo) operator.


*/

//***************Solution********************
//convert each character in string n into integer
//find the sum first
//if the sum modulus of 3 is equal to 0, then there is no remainder
//return the bool value accordingly.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
public static class Kata{
  public static bool DivisibleByThree(string n)=> n.Sum(x=> (int)x)%3 == 0;
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void FixedTest()
    {
      Assert.That(Kata.DivisibleByThree("19254"), Is.EqualTo(true));
      Assert.That(Kata.DivisibleByThree("9876543211234567890009"), Is.EqualTo(true));
      Assert.That(Kata.DivisibleByThree("010110101011"), Is.EqualTo(false));
      Assert.That(Kata.DivisibleByThree("6363"), Is.EqualTo(true));
      Assert.That(Kata.DivisibleByThree("9876543211234567890002"), Is.EqualTo(false));
      Assert.That(Kata.DivisibleByThree("10987654321"), Is.EqualTo(false));
      Assert.That(Kata.DivisibleByThree("1"), Is.EqualTo(false));
      Assert.That(Kata.DivisibleByThree("963210456"), Is.EqualTo(true));
      Assert.That(Kata.DivisibleByThree("0000000000004100000005400"), Is.EqualTo(false));
      Assert.That(Kata.DivisibleByThree("456465132498613521323456613654135212135876856423122135649879754132235753573543515356465648765153213546876"), Is.EqualTo(true));
      Assert.That(Kata.DivisibleByThree("0000000000004100000005400"), Is.EqualTo(false));
    }
    
    [Test]
    public void RandomTest()
    {
      Random rnd = new Random();
      Func<string, bool> solution = n => n.Select(c => Char.GetNumericValue(c)).Sum() % 3 == 0;
      
      for (int i = 0; i < 100; ++i)
      {
        // Make a string of 1 to 999 length composing of characters 0 to 9
        string n = String.Concat(new char[rnd.Next(1, 1000)].Select(_ => (char)rnd.Next(48, 58)));
        
        // Make sure string is not composed entirely of 0
        if (n.All(c => c == '0'))
        {
          // 1 to 9
          n = Char.ToString((char)rnd.Next(49, 58));
        }
        
        Assert.That(Kata.DivisibleByThree(n), Is.EqualTo(solution(n)));
      }
    } 
  }
}
