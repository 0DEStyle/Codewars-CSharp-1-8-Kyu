/*Challenge link:https://www.codewars.com/kata/5539fecef69c483c5a000015/train/csharp
Question:
Backwards Read Primes are primes that when read backwards in base 10 (from right to left) are a different prime. (This rules out primes which are palindromes.)

Examples:
13 17 31 37 71 73 are Backwards Read Primes
13 is such because it's prime and read from right to left writes 31 which is prime too. Same for the others.

Task
Find all Backwards Read Primes between two positive given numbers (both inclusive), the second one always being greater than or equal to the first one. The resulting array or the resulting string will be ordered following the natural order of the prime numbers.

Examples (in general form):
backwardsPrime(2, 100) => [13, 17, 31, 37, 71, 73, 79, 97] backwardsPrime(9900, 10000) => [9923, 9931, 9941, 9967] backwardsPrime(501, 599) => []

See "Sample Tests" for your language.

Notes
Forth Return only the first backwards-read prime between start and end or 0 if you don't find any
Ruby Don't use Ruby Prime class, it's disabled.
*/

//***************Solution********************
using System;
using System.Linq;

public class BackWardsPrime {
  //check if number is prime
  private static bool checkPrime(long n){
    for(long i = 2; i * i <= n; i++)
      if(n % i == 0) return false;
    return true;
  }
  
  //reverse number
  private static long numRev(long n) => Convert.ToInt64(new string(n.ToString().Reverse().ToArray()));
  
	public static string backwardsPrime(long start, long end, string str = "") {
    //append valid numbers to str
    for(long i = start; i <= end; i++)
      if(checkPrime(i) && checkPrime(numRev(i)) && i != numRev(i) ) str += i + " ";
    
    //Trim last " " and return result.
  return str.Trim();
	}
}

//****************Sample Test*****************
using System;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class backwardsPrimeTests {

[Test]
  public void Test1() {
    Assert.AreEqual("7027 7043 7057", BackWardsPrime.backwardsPrime(7000, 7100));
  }
[Test]
  public void Test2() {
    Assert.AreEqual("70001 70009 70061 70079 70121 70141 70163 70241", BackWardsPrime.backwardsPrime(70000, 70245));
  }
[Test]
  public void Test3() {
    Assert.AreEqual("70489 70529 70573 70589", BackWardsPrime.backwardsPrime(70485, 70600));
  }
[Test]
  public void Test4() {
    Assert.AreEqual("", BackWardsPrime.backwardsPrime(60000, 70000));
  }
[Test]
  public void Test5() {
    Assert.AreEqual("109537 109579 109583 109609 109663", BackWardsPrime.backwardsPrime(109500, 109700));
  }
[Test]
  public void Test6() {
    Assert.AreEqual("1095047 1095209 1095319 1095403", BackWardsPrime.backwardsPrime(1095000, 1095403));
  }
[Test]
  public void Test7() {
    Assert.AreEqual("107 113 149 157 167 179 199 311 337 347 359 389", BackWardsPrime.backwardsPrime(100, 403));
  }
[Test]
  public void Test8() {
    Assert.AreEqual("", BackWardsPrime.backwardsPrime(400, 503));
  }
[Test]
  public void Test9() {
    Assert.AreEqual("7048519 7048579", BackWardsPrime.backwardsPrime(7048500, 7048600));
  }
[Test]
  public void Test10() {
    Assert.AreEqual("1048571 1048583", BackWardsPrime.backwardsPrime(1048500, 1048600));
  }
[Test]
  public void Test11() {
    Assert.AreEqual("1000033 1000037 1000039", BackWardsPrime.backwardsPrime(1000001, 1000100));
  }
[Test]
  public void Test12() {
    Assert.AreEqual("700000031", BackWardsPrime.backwardsPrime(700000008, 700000050));
  }
[Test]
  public void Test13() {
    Assert.AreEqual("13 17 31 37 71 73 79 97", BackWardsPrime.backwardsPrime(1, 100));
  }
[Test]
  public void Test14() {
    Assert.AreEqual("13 17 31", BackWardsPrime.backwardsPrime(1, 31));
  }
[Test]
  public void Test15() {
    Assert.AreEqual("107 113 149 157 167 179 199", BackWardsPrime.backwardsPrime(101, 199));
  }
[Test]
  public void Test16() {
    Assert.AreEqual("311 337 347 359 389", BackWardsPrime.backwardsPrime(301, 399));
  }
[Test]
  public void Test17() {
    Assert.AreEqual("", BackWardsPrime.backwardsPrime(501, 599));
  }
[Test]
  public void Test18() {
    Assert.AreEqual("701 709 733 739 743 751 761 769", BackWardsPrime.backwardsPrime(701, 799));
  }
[Test]
  public void Test19() {
    Assert.AreEqual("1009 1021 1031 1033 1061 1069 1091 1097", BackWardsPrime.backwardsPrime(1001, 1099));
  }
[Test]
  public void Test20() {
    Assert.AreEqual("1103 1109 1151 1153 1181 1193 1201 1213 1217 1223 1229 1231 1237 1249 1259 1279 1283", BackWardsPrime.backwardsPrime(1099, 1299));
  }
[Test]
  public void Test21() {
    Assert.AreEqual("9923 9931 9941 9967", BackWardsPrime.backwardsPrime(9900, 10000));
  }
  
}
