/*Challenge link:https://www.codewars.com/kata/54e320dcebe1e583250008fd/train/csharp
Question:
Coding decimal numbers with factorials is a way of writing out numbers in a base system that depends on factorials, rather than powers of numbers.

In this system, the last digit is always 0 and is in base 0!. The digit before that is either 0 or 1 and is in base 1!. The digit before that is either 0, 1, or 2 and is in base 2!, etc. More generally, the nth-to-last digit is always 0, 1, 2, ..., n and is in base n!.

Read more about it at: http://en.wikipedia.org/wiki/Factorial_number_system

Example
The decimal number 463 is encoded as "341010", because:

463 = 3×5! + 4×4! + 1×3! + 0×2! + 1×1! + 0×0!

If we are limited to digits 0..9, the biggest number we can encode is 10!-1 (= 3628799). So we extend 0..9 with letters A..Z. With these 36 digits we can now encode numbers up to 36!-1 (= 3.72 × 1041)

Task
We will need two functions. The first one will receive a decimal number and return a string with the factorial representation.

The second one will receive a string with a factorial representation and produce the decimal representation.

Given numbers will always be positive.
*/

//***************Solution********************
v//ref: http://en.wikipedia.org/wiki/Factorial_number_system

using System; 
public class Dec2Fact{
		public static string dec2FactString(long number){
      //initialize variables, radix start at base 1
			var result = "0";
			int radix = 1;
      
      //increase radix by 1 each iteration
      //newDigitValue is the remainder of num mod radix.
			while (number > 0){
				radix++;
				var newDigitValue = number % radix;
        
        //if newDigitalValue is less than or equal to 9, append result to newDigitalValue 
        //else subtract newDigitalValue by 10 and add char 'A', then add result.
				if (newDigitValue <= 9)
					result = newDigitValue + result;
				else
					result = (char)((newDigitValue - 10) + 'A') + result;
        //divide number by radix for next iteration
				number /= radix;
			}
			return result;
		}

		public static long factString2Dec(string factorial){
      //initialize variables, radix start at base 1
			long result = 0;
			long radixValue = 1;
      
      //radix start at 1, index stat at factorial's length -2
      //while index is less than or equal to 0
      //increase radix by 1 and subtract index by 1
			for (int radix = 1, index = factorial.Length - 2; index >= 0; radix++, index--){
        //if the index of factorial is less than or equal to char '9'
        //accumulate value for result by - char '0'
        //else - 'A', add 10
				if (factorial[index] <= '9')
					result += (factorial[index] - '0') * radixValue;
				else
					result += (10 + (factorial[index] - 'A')) * radixValue;
        //+1 and multiply radixValue by radix for next iteration
				radixValue *= radix + 1;
			}
			return result;
		}
	}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class Dec2FactTests {

[Test]
  public void Test1() {
    Assert.AreEqual("341010", Dec2Fact.dec2FactString(463));
  }
[Test]
  public void Test2() {
    Assert.AreEqual("4041000", Dec2Fact.dec2FactString(2982));
  }
[Test]
  public void Test3() {
    Assert.AreEqual("A0000000000", Dec2Fact.dec2FactString(36288000));
  }
[Test]
  public void Test4() {
    Assert.AreEqual("311E55B5544150121110", Dec2Fact.dec2FactString(371993326789901217));
  }

[Test]
  public void Test5() {
    Assert.AreEqual(463, Dec2Fact.factString2Dec("341010"));
  }
[Test]
  public void Test6() {
    Assert.AreEqual(36288000, Dec2Fact.factString2Dec("A0000000000"));
  }
[Test]
  public void Test7() {
    Assert.AreEqual(37, Dec2Fact.factString2Dec("12010"));
  }
[Test]
  public void Test8() {
    Assert.AreEqual(371993326789901217, Dec2Fact.factString2Dec("311E55B5544150121110"));
  }
}
