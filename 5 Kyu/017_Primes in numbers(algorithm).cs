/*Challenge link:https://www.codewars.com/kata/54d512e62a5e54c96200019e/train/csharp
Question:
Given a positive number n > 1 find the prime factor decomposition of n. The result will be a string with the following form :

 "(p1**n1)(p2**n2)...(pk**nk)"
with the p(i) in increasing order and n(i) empty if n(i) is 1.

Example: n = 86240 should return "(2**5)(5)(7**2)(11)"
*/

//***************Solution********************
using System;

public class PrimeDecomp {

	public static String factors(int lst) {
    int modNum = 2, numCount = 0;
    string str = "";
    
    while (lst > modNum){
      
      if(0 == lst % modNum){                              //check remainder = 0
        lst /= modNum;
        numCount++;
      }
      else{                                               //remainder is not 0, reset number count, and increase mod by 1
        if(numCount == 1){
            str += "(" + modNum +")";                     // append string "(number)" if only 1 number
        }else if(numCount > 1){
            str += "(" + modNum + "**" + numCount + ")";  // append string "(number ** count)" if more than 1 number
        }
        numCount = 0;
        modNum++;
      }
    }
    return str + "(" + lst + ")";                          //append last string "(number)" to str
  }
}

//****************Sample Test*****************

using System;
using NUnit.Framework;

[TestFixture]
public class PrimeDecompTests {

[Test]
  public void Test1() { 
    int lst = 7775460;
    Assert.AreEqual("(2**2)(3**3)(5)(7)(11**2)(17)", PrimeDecomp.factors(lst));
}
[Test]
  public void Test2() { 
    int lst = 7919;
    Assert.AreEqual("(7919)", PrimeDecomp.factors(lst));
}
[Test]
  public void Test3() {
    int lst = 17*17*93*677;
    Assert.AreEqual("(3)(17**2)(31)(677)", PrimeDecomp.factors(lst));
}
[Test]
  public void Test4() {
    int lst = 933555431;
    Assert.AreEqual("(7537)(123863)", PrimeDecomp.factors(lst));
}
[Test]
  public void Test5() {
    int lst = 342217392;
    Assert.AreEqual("(2**4)(3)(11)(43)(15073)", PrimeDecomp.factors(lst));
}
[Test]
  public void Test6() {
    int lst = 123456789;
    Assert.AreEqual("(3**2)(3607)(3803)", PrimeDecomp.factors(lst));
}
[Test]
  public void Test7() {
    int lst = 987654321;
    Assert.AreEqual("(3**2)(17**2)(379721)", PrimeDecomp.factors(lst));
  }
}
