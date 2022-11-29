/*Challenge link:https://www.codewars.com/kata/55bf01e5a717a0d57e0000ec/train/csharp
Question:
Write a function, persistence, that takes in a positive parameter num and returns its multiplicative persistence, which is the number of times you must multiply the digits in num until you reach a single digit.

For example (Input --> Output):

39 --> 3 (because 3*9 = 27, 2*7 = 14, 1*4 = 4 and 4 has only one digit)
999 --> 4 (because 9*9*9 = 729, 7*2*9 = 126, 1*2*6 = 12, and finally 1*2 = 2)
4 --> 0 (because 4 is already a one-digit number)
*/

//***************Solution********************
//if number is less than 10 return 0 (because one-digit)
//else 1 + recursion, iterate the number, a * b-'0' (b - ASCII 48 to find the difference)
//Aggregate
//The Aggregate function iterates over each element of a collection. 
//In that statement, I converted n to a string. (Interpolated Strings)
//So for n = 39, n becomes "39". On the first iteration of the Aggregate function,
//n becomes "39". On the first iteration of the Aggregate function,
//a = 1 and b = '3', so the function returns 1 * ('3' - '0') [1 * 3 = 3].
//So on the second iteration, a = 3 and b = '9', and the function returns 3 * ('9' - '0') [3 * 9 = 27]. 
//Now the string is parsed, and we have effectively multiplied all the numbers of n.


//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public class Persist {
  public static int Persistence(long n) => n < 10 ? 0 : 1 + Persistence($"{n}".Aggregate(1, (a, b) => a * (b - '0')));
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class PersistTests {

[Test]
  public void Test1() {
    Console.WriteLine("****** Basic Tests");    
    Assert.AreEqual(3, Persist.Persistence(39));
    Assert.AreEqual(0, Persist.Persistence(4));
    Assert.AreEqual(2, Persist.Persistence(25));
    Assert.AreEqual(4, Persist.Persistence(999));
    Assert.AreEqual(3, Persist.Persistence(444));
  }
  //--------------------
  public static int Sol(long n) 
	{
		char[] digits = n.ToString().ToCharArray();
		if (digits.Length == 1) return 0;
    int dprod = 1;
    foreach (char d in digits) {
      int dgt = int.Parse(d.ToString());
      dprod *= dgt;
    }
		return 1 + Sol(dprod);
	}
  //--------------------
[Test]
  public static void Test2() {
    Console.WriteLine("\n 100 Random Tests ****************");
    Random rnd = new Random();
    for (int i = 0; i < 100; i++) {            
      int n = rnd.Next(10, 500000);
      //Console.WriteLine("Numbers: n " + n);
      Assert.AreEqual(PersistTests.Sol(n), Persist.Persistence(n));  
    }
  }
}
