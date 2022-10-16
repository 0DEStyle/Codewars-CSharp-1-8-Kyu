/*Challenge link:https://www.codewars.com/kata/5541f58a944b85ce6d00006a/train/csharp
Question:
The Fibonacci numbers are the numbers in the following integer sequence (Fn):

0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, ...

such as

F(n) = F(n-1) + F(n-2) with F(0) = 0 and F(1) = 1.

Given a number, say prod (for product), we search two Fibonacci numbers F(n) and F(n+1) verifying

F(n) * F(n+1) = prod.

Your function productFib takes an integer (prod) and returns an array:

[F(n), F(n+1), true] or {F(n), F(n+1), 1} or (F(n), F(n+1), True)
depending on the language if F(n) * F(n+1) = prod.

If you don't find two consecutive F(n) verifying F(n) * F(n+1) = prodyou will return

[F(n), F(n+1), false] or {F(n), F(n+1), 0} or (F(n), F(n+1), False)
F(n) being the smallest one such as F(n) * F(n+1) > prod.

Some Examples of Return:
(depend on the language)

productFib(714) # should return (21, 34, true), 
                # since F(8) = 21, F(9) = 34 and 714 = 21 * 34

productFib(800) # should return (34, 55, false), 
                # since F(8) = 21, F(9) = 34, F(10) = 55 and 21 * 34 < 800 < 34 * 55
-----
productFib(714) # should return [21, 34, true], 
productFib(800) # should return [34, 55, false], 
-----
productFib(714) # should return {21, 34, 1}, 
productFib(800) # should return {34, 55, 0},        
-----
productFib(714) # should return {21, 34, true}, 
productFib(800) # should return {34, 55, false}, 
Note:
You can see examples for your language in "Sample Tests".
*/

//***************Solution********************
//iteration from the start, shift the a and b each iteration
//if solution of product is possible, return in array format {a,b,1}, where 1 means true.
//if solution of product is not possible, return in array format {a,b,0}, where 0 means false.
//Iterative solution, not time efficient
public class ProdFib {
      public static ulong[] productFib(ulong prod) {
        ulong a = 0, b = 1, newB = 0;
        
        while(prod > a * b){
          newB = a + b;
          a = b;
          b = newB;
          
          if(prod == a * b){
            ulong[] temp = {a,b,1};
            return temp;
          }
          else if(prod < a * b){
            ulong[] temp = {a,b,0};
            return temp;
          }
        }
        return null;
      }
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class ProdFibTests {

[Test]
  public void Test1() {
    ulong[] r = new ulong[] { 55, 89, 1 };
    Assert.AreEqual(r, ProdFib.productFib(4895));
  }
[Test]
  public void Test2() {
    ulong[] r = new ulong[] { 89, 144, 0 };
    Assert.AreEqual(r, ProdFib.productFib(5895));
  }
[Test]
  public void Test3() {
    ulong[] r = new ulong[] { 6765, 10946, 1 };
    Assert.AreEqual(r, ProdFib.productFib(74049690));
  }
[Test]
  public void Test4() {
    ulong[] r = new ulong[] { 10946, 17711, 0 };
    Assert.AreEqual(r, ProdFib.productFib(84049690));
  }
[Test]
  public void Test5() {
    ulong[] r = new ulong[] { 10946, 17711, 1 };
    Assert.AreEqual(r, ProdFib.productFib(193864606));
  }
[Test]
  public void Test6() {
    ulong[] r = new ulong[] { 610, 987, 0 };
    Assert.AreEqual(r, ProdFib.productFib(447577));
  }
[Test]
  public void Test7() {
    ulong[] r = new ulong[] { 610, 987, 1 };
    Assert.AreEqual(r, ProdFib.productFib(602070));
  }
[Test]
  public void Test8() {
    ulong[] r = new ulong[] { 832040, 1346269, 0 };
    Assert.AreEqual(r, ProdFib.productFib(602070602070));
  }
[Test]
  public void Test9() {
    ulong[] r = new ulong[] { 832040, 1346269, 1 };
    Assert.AreEqual(r, ProdFib.productFib(1120149658760));
  }
[Test]
  public void Test10() {
    ulong[] r = new ulong[] { 1836311903, 2971215073, 0 };
    Assert.AreEqual(r, ProdFib.productFib(2563195080744681828));
  }
[Test]
  public void Test11() {
    ulong[] r = new ulong[] { 1346269, 2178309, 1 };
    Assert.AreEqual(r, ProdFib.productFib(2932589879121));
  }
[Test]
  public void Test12() {
    ulong[] r = new ulong[] { 1, 1, 1 };
    Assert.AreEqual(r, ProdFib.productFib(1));
  }
[Test]
  public void Test13() {
    ulong[] r = new ulong[] { 2971215073, 4807526976, 0 };
    Assert.AreEqual(r, ProdFib.productFib(5456077604922913920));
  }

[Test]
  public void RandomTests() {
    ulong[]someFibs = {55,89,144,233,377,610,987,1597,2584,4181,6765,
                       10946,17711,28657,46368,75025,121393,196418,317811,514229,
                       832040,1346269,2178309,3524578,5702887,9227465,14930352,
                       24157817,39088169,63245986};

    Random rnd = new Random();
    for (int k = 0; k < 15; k++) {
        int rn = rnd.Next(0, 28);
        ulong f1 = someFibs[rn]; 
        ulong f2 = someFibs[rn + 1];
        ulong p = f1 * f2;
        ulong[] r = new ulong[] {f1, f2, 1UL};
        Assert.AreEqual(r, ProdFib.productFib(p));
    }
  }
}
