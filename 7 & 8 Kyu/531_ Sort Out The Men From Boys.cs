/*Challenge link:https://www.codewars.com/kata/5af15a37de4c7f223e00012d/train/csharp
Question:
Scenario
Now that the competition gets tough it will Sort out the men from the boys .

Men are the Even numbers and Boys are the odd!alt!alt
Task
Given an array/list [] of n integers , Separate The even numbers from the odds , or Separate the men from the boys!alt!alt
Notes
Return an array/list where Even numbers come first then odds

Since , Men are stronger than Boys , Then Even numbers in ascending order While odds in descending .

Array/list size is at least 4 .

Array/list numbers could be a mixture of positives , negatives .

Have no fear , It is guaranteed that no Zeroes will exists .!alt
Repetition of numbers in the array/list could occur , So (duplications are not included when separating).

Input >> Output Examples:
menFromBoys ({7, 3 , 14 , 17}) ==> return ({14, 17, 7, 3}) 
Explanation:
Since , { 14 } is the even number here , So it came first , then the odds in descending order {17 , 7 , 3} .

menFromBoys ({-94, -99 , -100 , -99 , -96 , -99 }) ==> return ({-100 , -96 , -94 , -99})
Explanation:
Since , { -100, -96 , -94 } is the even numbers here , So it came first in *ascending order *, then the odds in descending order { -99 }

Since , (Duplications are not included when separating) , then you can see only one (-99) was appeared in the final array/list .

menFromBoys ({49 , 818 , -282 , 900 , 928 , 281 , -282 , -1 }) ==> return ({-282 , 818 , 900 , 928 , 281 , 49 , -1})
Explanation:
Since , {-282 , 818 , 900 , 928 } is the even numbers here , So it came first in ascending order , then the odds in descending order { 281 , 49 , -1 }

Since , (Duplications are not included when separating) , then you can see only one (-282) was appeared in the final array/list .
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//distinct to remove duplication
//x is current element, if x is even, x - a.Max(), else a.Max() - x, then order the numbers in ascending order.
//store in array and return the result.
using System.Linq;

public class Kata {
  public static int[] MenFromBoys(int[] a) => 
    a.Distinct().OrderBy(x => x % 2 == 0 ? x - a.Max() : a.Max() - x).ToArray();
}

//solution 2
//
using System.Linq;

public class Kata {
  public static int[] MenFromBoys(int[] a)
  {
    return a.Where(x => x % 2 == 0)
            .OrderBy(x => x)
            .Concat(a.Where(x => x % 2 != 0)
            .OrderByDescending(x => x))
            .Distinct().ToArray();
  }
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class SolutionTest {
    [Test]
    public void BasicTests() {
      Assert.AreEqual(new int[] { 14, 17, 7, 3 }, Kata.MenFromBoys(new int[] { 7, 3, 14, 17 }));
      Assert.AreEqual(new int[] { 2, 90, 95, 43, 37 }, Kata.MenFromBoys(new int[] { 2, 43, 95, 90, 37 }));
      Assert.AreEqual(new int[] { 20, 34, 46, 50, 43, 33 }, Kata.MenFromBoys(new int[] { 20, 33, 50, 34, 43, 46 }));
      Assert.AreEqual(new int[] { 72, 76, 82, 100, 91, 85 }, Kata.MenFromBoys(new int[] { 82, 91, 72, 76, 76, 100, 85 }));
      Assert.AreEqual(new int[] { 2, 10, 17, 15, 1 }, Kata.MenFromBoys(new int[] { 2, 15, 17, 15, 2, 10, 10, 17, 1, 1 }));
      Assert.AreEqual(new int[] { -32, -35, -39, -41 }, Kata.MenFromBoys(new int[] { -32, -39, -35, -41 }));
      Assert.AreEqual(new int[] { -66, -64, -63, -65, -71 }, Kata.MenFromBoys(new int[] { -64, -71, -63, -66, -65 }));
      Assert.AreEqual(new int[] { -100, -96, -94, -99 }, Kata.MenFromBoys(new int[] { -94, -99, -100, -99, -96, -99 }));
      Assert.AreEqual(new int[] { -26, -14, -27, -49, -51, -53 }, Kata.MenFromBoys(new int[] { -53, -26, -53, -27, -49, -51, -14 }));
      Assert.AreEqual(new int[] { -86, -56, -30, -15, -17, -33, -45, -85 }, Kata.MenFromBoys(new int[] { -17, -45, -15, -33, -85, -56, -86, -30 }));
      Assert.AreEqual(new int[] { -78, -38, 12, 89 }, Kata.MenFromBoys(new int[] { 12, 89, -38, -78 }));
      Assert.AreEqual(new int[] { -90, 2, 95, 37, -43 }, Kata.MenFromBoys(new int[] { 2, -43, 95, -90, 37 }));
      Assert.AreEqual(new int[] { -12, 82, 21, 1, -61, -87 }, Kata.MenFromBoys(new int[] { 82, -61, -87, -12, 21, 1 }));
      Assert.AreEqual(new int[] { -28, 2, 76, 88, 63, -57, -85 }, Kata.MenFromBoys(new int[] { 63, -57, 76, -85, 88, 2, -28 }));
      Assert.AreEqual(new int[] { -282, 818, 900, 928, 281, 49, -1 }, Kata.MenFromBoys(new int[] { 49, 818, -282, 900, 928, 281, -282, -1 }));
    }
    
    private Random r = new Random();
    private int[] Sol(int[] a) => a.Where(x => x % 2 == 0).OrderBy(x => x).Concat(a.Where(x => x % 2 != 0).OrderBy(x => -x)).Distinct().ToArray();
    private int Rand(int a, int b) => r.Next(b - a + 1) + a;
    
    [Test]
    public void RandomTests() {
      for (int i = 0; i < 100; i++) {
        int[] arr = Enumerable
          .Range(1, Rand(4, 40))
          .Select(_ => Rand(-Convert.ToInt32(Math.Pow(10, Rand(1, 3))), Convert.ToInt32(Math.Pow(10, Rand(1, 3)))))
          .ToArray();
        Assert.AreEqual(Sol(arr), Kata.MenFromBoys(arr));
      }
    }
  }
}
