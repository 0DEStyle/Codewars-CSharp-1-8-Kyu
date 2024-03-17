/*Challenge link:https://www.codewars.com/kata/5519e930cd82ff8a9a000216/train/csharp
Question:
The Hamming weight of a string is the number of symbols that are different from the zero-symbol of the alphabet used. There are several algorithms for efficient computing of the Hamming weight for numbers. In this Kata, speaking technically, you have to find out the number of '1' bits in a binary representation of a number. Thus,

hamming_weight(10) # 1010  => 2
hamming_weight(21) # 10101 => 3
The interesting part of this task is that you have to do it without string operation (hey, it's not really interesting otherwise)

;)
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//convert x to binary string, count the '1' in the string and return the result
using System;
using System.Linq;

public class Kata{
  public static int HammingWeight(int x) => Convert.ToString(x, 2).Count(c => c == '1');
}

//normal way
public class Kata
{
  public static int HammingWeight(int x)
  {
    return x == 0 ? 0 : 1 + HammingWeight(x & (x - 1));
  }
}
//****************Sample Test*****************
using NUnit.Framework;
[TestFixture]
public class Tests
{
  [TestCase(0,     ExpectedResult=0)]
  [TestCase(1,     ExpectedResult=1)]
  [TestCase(2,     ExpectedResult=1)]
  [TestCase(10,    ExpectedResult=2)]
  [TestCase(21,    ExpectedResult=3)]
  [TestCase(2048,  ExpectedResult=1)]
  [TestCase(-1,    ExpectedResult=32)]
  [TestCase(-2,    ExpectedResult=31)]
  [TestCase(-10,   ExpectedResult=30)]
  [TestCase(-21,   ExpectedResult=30)]
  [TestCase(-2048, ExpectedResult=21)]
  public int Example(int x) => Kata.HammingWeight(x);
  
  private static int Expected(int x) => x == 0 ? 0 : 1 + Expected(x & (x - 1));

  [Test]
  public void RandomTests()
  {
     var rnd = new System.Random();
     for(int i = 0; i < 50; ++i)
     {
       var val = rnd.Next(20000) - 10000;
       Assert.AreEqual(Expected(i), Kata.HammingWeight(i));
     }
  }
}
