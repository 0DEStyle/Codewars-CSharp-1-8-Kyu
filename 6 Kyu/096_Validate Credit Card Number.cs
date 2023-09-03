/*Challenge link:https://www.codewars.com/kata/5418a1dd6d8216e18a0012b2/train/csharp
Question:
In this Kata, you will implement the Luhn Algorithm, which is used to help validate credit card numbers.

Given a positive integer of up to 16 digits, return true if it is a valid credit card number, and false if it is not.

Here is the algorithm:

Double every other digit, scanning from right to left, starting from the second digit (from the right).

Another way to think about it is: if there are an even number of digits, double every other digit starting with the first; if there are an odd number of digits, double every other digit starting with the second:

1714 ==> [1*, 7, 1*, 4] ==> [2, 7, 2, 4]

12345 ==> [1, 2*, 3, 4*, 5] ==> [1, 4, 3, 8, 5]

891 ==> [8, 9*, 1] ==> [8, 18, 1]
If a resulting number is greater than 9, replace it with the sum of its own digits (which is the same as subtracting 9 from it):

[8, 18*, 1] ==> [8, (1+8), 1] ==> [8, 9, 1]

or:

[8, 18*, 1] ==> [8, (18-9), 1] ==> [8, 9, 1]
Sum all of the final digits:

[8, 9, 1] ==> 8 + 9 + 1 = 18
Finally, take that sum and divide it by 10. If the remainder equals zero, the original credit card number is valid.

18 (modulus) 10 ==> 8 , which is not equal to 0, so this is not a valid credit card number
For F# and C# users:

The input will be a string of spaces and digits 0..9
*/

//***************Solution********************

using System.Linq;

//from n, get all character that is a digit
//convert character to string and int parse
//reverse the numbers
//x is the current element, i is index
//if index mod 2 is 0, return x
//else if x * 2 is greater than 9
//return x * 2 - 9
//else return x * 2
//check if sum mod 10 is 0, then return bool value
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class solution{
  public bool validate(string n) =>
       n.Where(char.IsDigit)
        .Select(x => int.Parse(x.ToString()))
        .Reverse()
        .Select((x, i) => i % 2 == 0 ? x : x * 2 > 9 ? x * 2 - 9 : x * 2)
        .Sum() % 10 == 0;
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;

  // TODO: Replace examples and use TDD development by writing your own tests



    public class my_solution
    {
        static Predicate<int> even = (idx) => idx % 2 == 0;
        static Predicate<int> odd = (idx) => idx % 2 == 1;

        public bool validate(string n)
        {
            var a = n.Replace(" ", "");
            var pred = a.Count() % 2 == 0 ? even : odd;
            return a.Select((e, i) =>
            {
                var num = Convert.ToInt32(Char.GetNumericValue(e));
                if (pred(i))
                    return num * 2 > 9 ? (num * 2) - 9 : (num * 2);
                else
                    return num;

            }).Sum() % 10 == 0;
        }
    }




  [TestFixture]
  public class SolutionTest
  {
        public static solution _ = new solution();

        static Predicate<int> even = (x) => x % 2 == 0;
        static Predicate<int> odd = (x) => x % 2 == 1;
        static Func<int, Predicate<int>> predicate = (len) => len % 2 == 1 ? even : odd;

        public my_solution my_validate = new my_solution();
        public static Random rnd = new Random();
        static Func<int, IEnumerable<int>> genArray = (len) => Enumerable.Range(0, len).Select(x => rnd.Next(0, 9));
        static Func<string, IEnumerable<int>> getNumbers = (str) => str.Split(' ')
                                                                       .SelectMany(x => x.ToCharArray()
                                                                                         .Select(y => (int)Char.GetNumericValue(y)));
                                                                                         
                                                                                         
        
        public static string determineCase()
        {
            var val = rnd.Next(0, 2);
            if (val == 1)
                return validCase();
            else
                return invalidCase();
        }

        private static string validCase()
        {
            var val = rnd.Next(0, 7);
            switch (val)
            {
                case 0: return validCase0();
                case 1: return validCase1();
                case 2: return validCase2();
                case 3: return validCase3();
                case 4: return validCase4();
                case 5: return validCase5();
                case 6: return validCase6();
                case 7: return validCase7();
                default: return validCase0();
            }
        }

        private static string invalidCase()
        {
            var _ = new solution();
            string numbs = validCase();
            var lastDigit = (int)Char.GetNumericValue(numbs[numbs.Length - 1]);
            lastDigit = lastDigit == 9 ? lastDigit - 2 : lastDigit + 1;
            if (_.validate(numbs + lastDigit) == false)
                return numbs + lastDigit;
            else
                return invalidCase();
        }

        public static string validCase0()
        {
            var sum = 0;
            var result = genArray(15).ToList();     // I have a array of numbers I want to  calculate the check sum number
            Console.WriteLine("[{0}]", String.Join(", ", result));
            for (int i = result.Count() - 1, j = 0; i >= 0; i--, j++) sum += (j % 2 == 0 && result[i] != 9 ? (result[i] * 2) % 9 : result[i]);
            Console.WriteLine("[{0}]", String.Join(", ", result));
            var checkSumDigit = (10 - sum % 10) % 10;
            var ar = result.Select(x => x.ToString()).ToList();
            ar[3] += " "; ar[7] += " "; ar[11] += " ";
            return ar.Aggregate("", (acc, cur) => acc + cur) + checkSumDigit;
        }

        public static string validCasex(int len, int sep)
        {
            var sum = 0;
            var pred = predicate(len);
            var result = genArray(len).ToList();
            Console.WriteLine("[{0}]", String.Join(", ", result));
            for (int i = result.Count() - 1, j = 0; i >= 0; i--, j++) sum += (pred(j) && result[i] != 9 ? (result[i] * 2) % 9 : result[i]);
            Console.WriteLine("[{0}]", String.Join(", ", result));
            var checkSumDigit = (10 - sum % 10) % 10;
            var ar = result.Select(x => x.ToString()).ToList();
            ar.Add(checkSumDigit.ToString());
            for (int i = sep - 1; i < len - 1; i += sep) ar[i] += " ";
            return ar.Aggregate("", (acc, cur) => acc + cur) + checkSumDigit;
        }

        public static string validCase1() => validCasex(12, 4);
        public static string validCase2() => validCasex(11, 4);
        public static string validCase3() => validCasex(9, 3);
        public static string validCase4() => validCasex(8, 3);
        public static string validCase5() => validCasex(6, 3);
        public static string validCase6() => validCasex(5, 3);
        public static string validCase7() => validCase0();    
        
        
        
        
        [Test]
        public void TestMethod1()
        {
            Assert.AreEqual(false,_.validate("477 073 360"));
            Assert.AreEqual(true,_.validate("5422 0148 5514"));
            Assert.AreEqual(true,_.validate("8314 7046 0245"));
            Assert.AreEqual(false,_.validate("6654 6310 43044"));
            Assert.AreEqual(true,_.validate("0768 2757 5685 6340"));
            Assert.AreEqual(false,_.validate("7164 6207 74042"));
            Assert.AreEqual(true,_.validate("8383 7332 3570 8514"));
            Assert.AreEqual(true,_.validate("481 135"));
            Assert.AreEqual(true,_.validate("355 032 5363"));
        }

        [Test]
        public void RandomTests()
        {
            var my_sol = new my_solution();
            for (int i = 0; i < 100; i++)
            {
                var _case = determineCase();
                Assert.AreEqual(my_sol.validate(_case), _.validate(_case));
            }
        }
        
        
  }
}
