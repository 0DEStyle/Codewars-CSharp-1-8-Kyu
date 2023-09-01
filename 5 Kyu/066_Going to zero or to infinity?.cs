/*Challenge link:https://www.codewars.com/kata/55a29405bc7d2efaff00007c/train/csharp
Question:
Consider the following numbers (where n! is factorial(n)):

u1 = (1 / 1!) * (1!)
u2 = (1 / 2!) * (1! + 2!)
u3 = (1 / 3!) * (1! + 2! + 3!)
...
un = (1 / n!) * (1! + 2! + 3! + ... + n!)
Which will win: 1 / n! or (1! + 2! + 3! + ... + n!)?

Are these numbers going to 0 because of 1/n! or to infinity due to the sum of factorials or to another number?

Task
Calculate (1 / n!) * (1! + 2! + 3! + ... + n!) for a given n, where n is an integer greater or equal to 1.

To avoid discussions about rounding, return the result truncated to 6 decimal places, for example:

1.0000989217538616 will be truncated to 1.000098
1.2125000000000001 will be truncated to 1.2125
Remark
Keep in mind that factorials grow rather rapidly, and you need to handle large inputs.

Hint
You could try to simplify the expression.
*/

//***************Solution********************
using System;

public class Suite {
	public static double going(int n) {
		double running = 1.0, term = 1.0;
    
    //accumulation
    for(int i = n; i > 1; i--) {
      running += (term *= 1.0 / i);
      //Console.WriteLine(running + " " + term);
      }
    
    //truncate to 6 decimal places
    return Math.Truncate(running * 1000000) / 1000000;
	}
}

//****************Sample Test*****************
using System;

using NUnit.Framework;

[TestFixture]
[DefaultFloatingPointTolerance(.000002)]
public class SuiteTests {
// public SuiteTests() {
//   GlobalSettings.DefaultFloatingPointTolerance = .000002;
// }	

  [Test]
  public void Test01() {
		Assert.AreEqual(1.275, Suite.going(5));
  }
  [Test]
  public void Test02() {
		Assert.AreEqual(1.2125, Suite.going(6));
  }
[Test]
  public void Test03() {
		Assert.AreEqual(1.173214, Suite.going(7));
  }
[Test]
  public void Test04() {
		Assert.AreEqual(1.146651, Suite.going(8));
  }
[Test]
  public void Test05() {
		Assert.AreEqual(1.052786, Suite.going(20));
  }
[Test]
  public void Test06() {
		Assert.AreEqual(1.034525, Suite.going(30));
  }
[Test]
  public void Test07() {
		Assert.AreEqual(1.020416, Suite.going(50));
  }
[Test]
  public void Test08() {
		Assert.AreEqual(1.008929, Suite.going(113));
  }
[Test]
  public void Test09() {
		Assert.AreEqual(1.005025, Suite.going(200));
  }
[Test]
  public void Test10() {
		Assert.AreEqual(1.001915, Suite.going(523));
  }
[Test]
  public void Test11() {
		Assert.AreEqual(1.00099, Suite.going(1011));
  }
[Test]
  public void Test12() {
		Assert.AreEqual(1.000098, Suite.going(10110));
  }
  
  public static double solution(int n) 
  {        
    double res = 1.0; double inter = 1.0;
    	for (int i = n; i >=2; i--) 
		{
        	inter = inter * (1.0 / i);
        	res += inter;
		}
    return Math.Floor(res * Math.Pow(10, 6)) / Math.Pow(10, 6);
  }
  
[Test]
    public static void Test14() {
        Random rnd = new Random();
        for (int i = 0; i < 50; i++) {
            int n = rnd.Next(2, 200);
            //Console.WriteLine("Going with number : " + n);
            Assert.AreEqual(SuiteTests.solution(n), Suite.going(n));
        }
    }
    
  
}
