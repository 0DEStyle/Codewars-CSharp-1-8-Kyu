/*Challenge link:https://www.codewars.com/kata/54eb33e5bc1a25440d000891/train/csharp
Question:
My little sister came back home from school with the following task: given a squared sheet of paper she has to cut it in pieces which, when assembled, give squares the sides of which form an increasing sequence of numbers. At the beginning it was lot of fun but little by little we were tired of seeing the pile of torn paper. So we decided to write a program that could help us and protects trees.

Task
Given a positive integral number n, return a strictly increasing sequence (list/array/string depending on the language) of numbers, so that the sum of the squares is equal to n².

If there are multiple solutions (and there will be), return as far as possible the result with the largest possible values:

Examples
decompose(11) must return [1,2,4,10]. Note that there are actually two ways to decompose 11², 11² = 121 = 1 + 4 + 16 + 100 = 1² + 2² + 4² + 10² but don't return [2,6,9], since 9 is smaller than 10.

For decompose(50) don't return [1, 1, 4, 9, 49] but [1, 3, 5, 8, 49] since [1, 1, 4, 9, 49] doesn't form a strictly increasing sequence.

Note
Neither [n] nor [1,1,1,…,1] are valid solutions. If no valid solution exists, return nil, null, Nothing, None (depending on the language) or "[]" (C) ,{} (C++), [] (Swift, Go).

The function "decompose" will take a positive integer n and return the decomposition of N = n² as:

[x1 ... xk] or
"x1 ... xk" or
Just [x1 ... xk] or
Some [x1 ... xk] or
{x1 ... xk} or
"[x1,x2, ... ,xk]"
depending on the language (see "Sample tests")

Note for Bash
decompose 50 returns "1,3,5,8,49"
decompose 4  returns "Nothing"
Hint
Very often xk will be n-1.
*/

//***************Solution********************
using System.Collections.Generic;
using System.Linq;
using System;

public class Decompose {
  public string decompose(long n) {
      long goal = 0;
    //long stack to store result, push n to result.
      var result = new Stack<long>();
      result.Push(n);
    
    //while result.Count is greater than 0
    //set current to result.Pop, accumulate goal by adding current ^ 2
      while (result.Count > 0){
          long current = result.Pop();
          goal += current * current;
        
        //loop start rom current - 1, up to i greater than 0, i--
          for (long i = current - 1; i > 0; i--){
            //if goal - i ^2 is greater or equal to 0, and result doesn't contain i
              if (goal - (i * i) >= 0 && !result.Contains(i)){
                //subtract i^2 from goal, then push i into result.
                  goal -= i * i;
                  result.Push(i);
                
                //if goal is equal to 0
                  if (goal == 0){
                    //order result in ascending order, convert to array.
                      var ar = result.OrderBy(x => x).ToArray();
                    //string formatting and return result
                      return string.Join(" ", ar);
                  }
              }
          }
      }
    //return null if result.Count is not greater than 0
      return null;
  }
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class DecomposeTests {

[Test]
  public void Test1() {
    Decompose d = new Decompose();
    long n = 11;
    Assert.AreEqual("1 2 4 10", d.decompose(n));
  }
[Test]
  public void Test2() {
    Decompose d = new Decompose();
    long n = 12;
    Assert.AreEqual("1 2 3 7 9", d.decompose(n));
  }
[Test]
  public void Test3() {
    Decompose d = new Decompose();
    long n = 625;
    Assert.AreEqual("2 5 8 34 624", d.decompose(n));
  }
[Test]
  public void Test4() {
    Decompose d = new Decompose();
    long n = 7100;
    Assert.AreEqual("2 3 5 119 7099", d.decompose(n));
  }
[Test]
  public void Test5() {
    Decompose d = new Decompose();
    long n = 12345;
    Assert.AreEqual("2 6 157 12344", d.decompose(n));
  }
[Test]
  public void Test6() {
    Decompose d = new Decompose();
    long n = 1234567;
    Assert.AreEqual("2 8 32 1571 1234566", d.decompose(n));
  }
[Test]
  public void Test7() {
    Decompose d = new Decompose();
    long n = 4;
    Assert.AreEqual(null, d.decompose(n));
  }
[Test]
  public void Test8() {
    Decompose d = new Decompose();
    long n = 6;
    Assert.AreEqual(null, d.decompose(n));
  }
[Test]
  public void Test9() {
    Decompose d = new Decompose();
    long n = 13;
    Assert.AreEqual("5 12", d.decompose(n));
  }
[Test]
  public void Test10() {
    Decompose d = new Decompose();
    long n = 7654322;
    Assert.AreEqual("1 4 11 69 3912 7654321", d.decompose(n));
  }

}
