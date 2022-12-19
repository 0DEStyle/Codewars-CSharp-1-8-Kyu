/*Challenge link:https://www.codewars.com/kata/5552101f47fc5178b1000050/train/csharp
Question:
Some numbers have funny properties. For example:

89 --> 8¹ + 9² = 89 * 1

695 --> 6² + 9³ + 5⁴= 1390 = 695 * 2

46288 --> 4³ + 6⁴+ 2⁵ + 8⁶ + 8⁷ = 2360688 = 46288 * 51

Given a positive integer n written as abcd... (a, b, c, d... being digits) and a positive integer p

we want to find a positive integer k, if it exists, such that the sum of the digits of n taken to the successive powers of p is equal to k * n.
In other words:

Is there an integer k such as : (a ^ p + b ^ (p+1) + c ^(p+2) + d ^ (p+3) + ...) = n * k

If it is the case we will return k, if not return -1.

Note: n and p will always be given as strictly positive integers.

digPow(89, 1) should return 1 since 8¹ + 9² = 89 = 89 * 1
digPow(92, 1) should return -1 since there is no k such as 9¹ + 2² equals 92 * k
digPow(695, 2) should return 2 since 6² + 9³ + 5⁴= 1390 = 695 * 2
digPow(46288, 3) should return 51 since 4³ + 6⁴+ 2⁵ + 8⁶ + 8⁷ = 2360688 = 46288 * 51
*/

//***************Solution********************

//solution 1

using System;
using System.Collections.Generic;

public class DigPow {
	public static long digPow(int n, int p) {
    double sum = 0;
    int temp = n;

    List<int> listOfInts = new List<int>(); //store each digit into list
    while (temp > 0){
        listOfInts.Add(temp % 10);
        
        temp = temp / 10;
    }
    listOfInts.Reverse();

    for(int i = 0; i < n.ToString().Length; i++){ //apply algorithm, perform calculation
    Console.WriteLine(listOfInts[i]);
    sum += Math.Pow(listOfInts[i], p+i);
    }

    return (sum / n) %1 == 0 ? (long)sum/n : -1; //check if the answer is a whole number, if true return the number else -1
	}
}

//solution 2
using System.Linq;
using System;

public class DigPow {
	public static long digPow(int n, int p) {
		var sum = Convert.ToInt64(n.ToString().Select(s => Math.Pow(int.Parse(s.ToString()), p++)).Sum());
		return sum % n == 0 ? sum / n : -1;
	}
}
//****************Sample Test*****************
using System;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class DigPowTests {

[Test]
  public void Test1() {
    Assert.AreEqual(1, DigPow.digPow(89, 1));
  }
[Test]
  public void Test2() {
    Assert.AreEqual(-1, DigPow.digPow(92, 1));
  }
[Test]
  public void Test3() {
    Assert.AreEqual(51, DigPow.digPow(46288, 3));
  }
[Test]
  public void Test4() {
    Assert.AreEqual(9, DigPow.digPow(114, 3));
  }
[Test]
  public void Test5() {
    Assert.AreEqual(-1, DigPow.digPow(46288, 5));
  }
[Test]
  public void Test6() {
    Assert.AreEqual(1, DigPow.digPow(135, 1));
  }
[Test]
  public void Test7() {
    Assert.AreEqual(1, DigPow.digPow(175, 1));
  }
[Test]
  public void Test8() {
    Assert.AreEqual(1, DigPow.digPow(518, 1));
  }
[Test]
  public void Test9() {
    Assert.AreEqual(1, DigPow.digPow(63761, 3));
  }
[Test]
  public void Test10() {
    Assert.AreEqual(1, DigPow.digPow(598, 1));
  }
[Test]
  public void Test11() {
    Assert.AreEqual(1, DigPow.digPow(1306, 1));
  }
[Test]
  public void Test12() {
    Assert.AreEqual(1, DigPow.digPow(2427, 1));
  }
[Test]
  public void Test13() {
    Assert.AreEqual(1, DigPow.digPow(2646798, 1));
  }
[Test]
  public void Test14() {
    Assert.AreEqual(-1, DigPow.digPow(3456789, 1));
  }
[Test]
  public void Test15() {
    Assert.AreEqual(-1, DigPow.digPow(3456789, 5));
  }
[Test]
  public void Test16() {
    Assert.AreEqual(3, DigPow.digPow(198, 1));
  }
[Test]
  public void Test17() {
    Assert.AreEqual(3, DigPow.digPow(249, 1));
  }
[Test]
  public void Test18() {
    Assert.AreEqual(2, DigPow.digPow(1377, 1));
  }
[Test]
  public void Test19() {
    Assert.AreEqual(1, DigPow.digPow(1676, 1));
  }
[Test]
  public void Test20() {
    Assert.AreEqual(2, DigPow.digPow(695, 2));
  }
[Test]
  public void Test21() {
    Assert.AreEqual(19, DigPow.digPow(1878, 2));
  }
[Test]
  public void Test22() {
    Assert.AreEqual(5, DigPow.digPow(7388, 2));
  }
[Test]
  public void Test23() {
    Assert.AreEqual(1, DigPow.digPow(47016, 2));
  }
[Test]
  public void Test24() {
    Assert.AreEqual(1, DigPow.digPow(542186, 2));
  }
[Test]
  public void Test25() {
    Assert.AreEqual(5, DigPow.digPow(261, 3));
  }
[Test]
  public void Test26() {
    Assert.AreEqual(35, DigPow.digPow(1385, 3));
  }
[Test]
  public void Test27() {
    Assert.AreEqual(66, DigPow.digPow(2697, 3));
  }
[Test]
  public void Test28() {
    Assert.AreEqual(10, DigPow.digPow(6376, 3));
  }
[Test]
  public void Test29() {
    Assert.AreEqual(1, DigPow.digPow(6714, 3));
  }
[Test]
  public void Test30() {
    Assert.AreEqual(1, DigPow.digPow(63760, 3));
  }
[Test]
  public void Test31() {
    Assert.AreEqual(4, DigPow.digPow(132921, 3));
  }
[Test]
  public void Test32() {
    Assert.AreEqual(12933, DigPow.digPow(10383, 6));
  }
}
