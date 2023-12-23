/*Challenge link:https://www.codewars.com/kata/55563df50dda59adf900004d/train/csharp
Question:
A lot of goods have an International Article Number (formerly known as "European Article Number") abbreviated "EAN". EAN is a 13-digits barcode consisting of 12-digits data followed by a single-digit checksum (EAN-8 is not considered in this kata).


The single-digit checksum is calculated as followed (based upon the 12-digit data):

The digit at the first, third, fifth, etc. position (i.e. at the odd position) has to be multiplied with "1".
The digit at the second, fourth, sixth, etc. position (i.e. at the even position) has to be multiplied with "3".
Sum these results.

If this sum is dividable by 10, the checksum is 0. Otherwise the checksum has the following formula:

checksum = 10 - (sum mod 10)

For example, calculate the checksum for "400330101839" (= 12-digits data):

4·1 + 0·3 + 0·1 + 3·3 + 3·1 + 0·3 + 1·1 + 0·3 + 1·1 + 8·3 + 3·1 + 9·3
= 4 + 0 + 0 + 9 + 3 + 0 + 1 + 0 + 1 + 24 + 3 + 27
= 72
10 - (72 mod 10) = 8 ⇒ Checksum: 8

Thus, the EAN-Code is 4003301018398 (= 12-digits data followed by single-digit checksum).

Your Task
Validate a given EAN-Code. Return true if the given EAN-Code is valid, otherwise false.
Assumption
You can assume the given code is syntactically valid, i.e. it only consists of numbers and it exactly has a length of 13 characters.
Examples
EANValidator.Validate("4003301018398") // true
EANValidator.Validate("4003301018392") // false
Good Luck and have fun.
*/

//***************Solution********************
//odd * 1, even * 3, last digit is checkSum
using System;
using System.Linq;
class EANValidator{
  public static bool Validate(string n){
    //str = first 12 digits
    var str = n.Substring(0,(n.Length - 1));
    //x is current element, i is index
    //- '0' is a way to parse character into int, not into ascii value.
    //start from 0, so if number is odd, times the value by 3, else keep it the same
    //find the sum of all elements.
    var checkSum = str.Select((x,i) => i % 2 == 0 ? x - '0':  (x - '0') * 3).Sum();
    //avoiding 2 digits, because 0 will return 10 instead of 0
    var remainder = checkSum % 10;
    return (remainder == 0 ? 0 : 10) - remainder == n[^1] - '0';
  }
}

//solution 2
using System.Linq;

class EANValidator
{
  public static bool Validate(string eanCode)
  {
    return eanCode
        .Select(c => int.Parse($"{c}"))
        .Select((x, i) => i % 2 == 0 ? x : x * 3)
        .Sum() % 10 == 0;
  }
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class EANValidatorTests {

[Test]
  public void Test1() {
    Assert.AreEqual(true, EANValidator.Validate("9783815820865"));
  }
[Test]
  public void Test2() {
    Assert.AreEqual(false, EANValidator.Validate("9783815820864"));
  }
[Test]
  public void Test3() {
    Assert.AreEqual(true, EANValidator.Validate("9783827317100"));
  }
[Test]
  public void Test4() {
    Assert.AreEqual(true, EANValidator.Validate("4003301018398"));
  }
[Test]
  public void Test5() {
    Assert.AreEqual(false, EANValidator.Validate("9783827317101"));
  }
[Test]
  public void Test6() {
    Assert.AreEqual(false, EANValidator.Validate("4003301018392"));
  }
[Test]
  public void Test7() {
    Assert.AreEqual(true, EANValidator.Validate("0000000000017"));
  }
[Test]
  public void Test8() {
    Assert.AreEqual(false, EANValidator.Validate("0000000000010"));
  }
[Test]
  public void RandomTests() {
    Random rng = new Random();
    for(int x=0; x<40;x++){
      string n ="";
      int sum = 0;
      bool solution;
      for(int i=0;i<12;i++){
        n+= rng.Next(0,10);
        sum+= (int)(((int)(n[i])-48)*Math.Pow(3,i%2));
      }
      if(rng.Next(0,2)==1){
        n+= (10-sum%10)%10;
        solution=true;
      }else{
        n+= (10+1-sum%10)%10;
        solution=false;
      }
      Assert.AreEqual(solution, EANValidator.Validate(n));
    }
  }
}
