/*Challenge link:https://www.codewars.com/kata/55aa075506463dac6600010d/train/csharp
Question:
1, 246, 2, 123, 3, 82, 6, 41 are the divisors of number 246. Squaring these divisors we get: 1, 60516, 4, 15129, 9, 6724, 36, 1681. The sum of these squares is 84100 which is 290 * 290.

Task
Find all integers between m and n (m and n integers with 1 <= m <= n) such that the sum of their squared divisors is itself a square.

We will return an array of subarrays or of tuples (in C an array of Pair) or a string. The subarrays (or tuples or Pairs) will have two elements: first the number the squared divisors of which is a square and then the sum of the squared divisors.

Example:
list_squared(1, 250) --> [[1, 1], [42, 2500], [246, 84100]]
list_squared(42, 250) --> [[42, 2500], [246, 84100]]
The form of the examples may change according to the language, see "Sample Tests".

Note
In Fortran - as in any other language - the returned string is not permitted to contain any redundant trailing whitespace: you can use dynamically allocated character strings.
*/

//***************Solution********************

using System;
using System.Collections.Generic;

public class SumSquaredDivisors {
	public static string listSquared(long m, long n){
            var ans = new List<string>();

            for (long number = m; number <= n; number++){
                var divisors = new List<int>();
                long sum = 0; //reset sum to 0
              
                for (int div = 1; div <= number; div++){ 
                    if (number % div == 0)  //check divisibility
                      sum += (div * div);
                }
              
                if (Math.Sqrt(sum) % 2 == 0 || sum == 1) //check if the sum is a perfect square, then add to answer list.
                    ans.Add(string.Format("[{0}, {1}]",number,sum));
            }
    
            return string.Format("[{0}]", string.Join(", ", ans));
	}
}

//****************Sample Test*****************
using System;

using NUnit.Framework;

[TestFixture]
public class SumSquaredDivisorsTests {

[Test]
  public void Test01() {
		Assert.AreEqual("[[1, 1], [42, 2500], [246, 84100]]", SumSquaredDivisors.listSquared(1, 250));
  }
[Test]
  public void Test02() {
		Assert.AreEqual("[[42, 2500], [246, 84100]]", SumSquaredDivisors.listSquared(42, 250));
  }
[Test]
  public void Test03() {
		Assert.AreEqual("[[287, 84100]]", SumSquaredDivisors.listSquared(250, 500));
  }
[Test]
  public void Test04() {
		Assert.AreEqual("[]", SumSquaredDivisors.listSquared(300, 600));
  }
[Test]
  public void Test05() {
		Assert.AreEqual("[[728, 722500], [1434, 2856100]]", SumSquaredDivisors.listSquared(600, 1500));
  }
[Test]
  public void Test06() {
		Assert.AreEqual("[[1673, 2856100]]", SumSquaredDivisors.listSquared(1500, 1800));
  }
[Test]
  public void Test07() {
		Assert.AreEqual("[[1880, 4884100]]", SumSquaredDivisors.listSquared(1800, 2000));
  }
[Test]
  public void Test08() {
		Assert.AreEqual("[]", SumSquaredDivisors.listSquared(2000, 2200));
  }
[Test]
  public void Test09() {
		Assert.AreEqual("[[4264, 24304900]]", SumSquaredDivisors.listSquared(2200, 5000));
  }
[Test]
  public void Test10() {
		Assert.AreEqual("[[6237, 45024100], [9799, 96079204], [9855, 113635600]]", SumSquaredDivisors.listSquared(5000, 10000));
  }
  
  private static long[] sumSquaredFactorsSol(long n) 
	{
    	long s = 0;
    	long nf = 0;
    	long[] res = new long[2];
    	for (long i = 1; i <= Math.Floor(Math.Sqrt(n)); i += 1)
		{
        	if (n % i == 0) 
			{
            	s += i * i;
            	nf = n / i;
            	if (nf != i)
                	s += nf * nf;
    		}
		}
    	if (Math.Pow((long)Math.Sqrt(s), 2) == s) 
		{
        	res[0] = n;
        	res[1] = s;
        	return res;
    	} else return null;
	}
	public static string listSquaredSol(long m, long n)
	{
		string res = "[";
    	for (long i = m; i <= n; i++) 
		{
        	long[] r = sumSquaredFactorsSol(i);
        	if (r != null) 
			{
            	res += "[" + r[0].ToString() + ", " + r[1].ToString() + "], ";
        	}
    	}
    	return res.TrimEnd(' ', ',') + "]";
	}
  
[Test]
    public static void Test11() {
        Random rnd = new Random();
        for (int i = 0; i < 50; i++) {
            long m = rnd.Next(200, 1000);
            long n = rnd.Next(1100, 8000);
            Console.WriteLine("listSquared with number m : " + m + " n : " + n);
            Assert.AreEqual(SumSquaredDivisorsTests.listSquaredSol(m, n), SumSquaredDivisors.listSquared(m, n));
        }
    }
    
  
}
