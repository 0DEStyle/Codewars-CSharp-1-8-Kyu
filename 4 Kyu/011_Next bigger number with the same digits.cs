/*Challenge link:https://www.codewars.com/kata/55983863da40caa2c900004e/train/csharp
Question:
Create a function that takes a positive integer and returns the next bigger number that can be formed by rearranging its digits. For example:

  12 ==> 21
 513 ==> 531
2017 ==> 2071
If the digits can't be rearranged to form a bigger number, return -1 (or nil in Swift, None in Rust):

  9 ==> -1
111 ==> -1
531 ==> -1
*/

//***************Solution********************

//digit swap method
using System;

public class Kata{
  public static long NextBiggerNumber(long n){
    char[] num = n.ToString().ToCharArray();
    int idx; 
    
    //Find where digits decrease for the first time
    //start at index length-2
    //check if current index >= next index and idx >= 0
    for(idx=num.Length-2; idx>=0 && num[idx] >= num[idx+1]; idx--);
    //Console.WriteLine(idx);
    
    //If index is non-decreasing, this is the biggest number.
    //Reverse subarray,  Array.Reverse((T[] array, int index, int length));
    if(idx < 0) return -1;
    Array.Reverse(num, idx+1, num.Length - idx - 1);
    
    // Find least digit, until num[lst] is more than num[idx].
    int lst; 
    for(lst=idx+1; num[lst] <= num[idx]; lst++);
    
    // Swap the least digit index with the number index, then return result.
    char t = num[lst]; 
    num[lst] = num[idx]; 
    num[idx] = t;
    return long.Parse(num);
  }
}


//****************Sample Test*****************
using System;
using System.Linq;
using NUnit.Framework;
    [TestFixture]
    public class NextBiggerNumberTests
    {

        [Test]
        public void SmallNumbers()
        {
            Assert.AreEqual(21, Kata.NextBiggerNumber(12),     "Incorrect answer for n=12");
            Assert.AreEqual(531, Kata.NextBiggerNumber(513),   "Incorrect answer for n=513");
            Assert.AreEqual(2071, Kata.NextBiggerNumber(2017), "Incorrect answer for n=2017");
            Assert.AreEqual(441, Kata.NextBiggerNumber(414),   "Incorrect answer for n=414");
            Assert.AreEqual(414, Kata.NextBiggerNumber(144),   "Incorrect answer for n=144");
        }

        [Test]
        public void BiggerNumbers()
        {
            Assert.AreEqual(123456798, Kata.NextBiggerNumber(123456789), "Incorrect answer for n=123456789");
            Assert.AreEqual(1234567908, Kata.NextBiggerNumber(1234567890), "Incorrect answer for n=1234567890");
            Assert.AreEqual(-1, Kata.NextBiggerNumber(9876543210), "Incorrect answer for n=9876543210");
            Assert.AreEqual(-1, Kata.NextBiggerNumber(9999999999), "Incorrect answer for n=9999999999");
            Assert.AreEqual(59884848483559, Kata.NextBiggerNumber(59884848459853), "Incorrect answer for n=59884848459853");
        }

        [Test]
        public void RendomNumbers()
        {
            for(int i = 0; i < 140; i++)
            {
                long n = RandomNumber(100, int.MaxValue);
                Assert.AreEqual(Sol(n), Kata.NextBiggerNumber(n), $"Incorrect answer for n={n}");
            }
        }

        private static long Sol(long n)
        {
            var str = n.ToString().ToList();
            Func<char, int> toInt = Convert.ToInt32;
            int i = str.Count - 1, fail = -1;
            for (; i > 0; i--) if (toInt(str[i]) > toInt(str[i - 1])) { fail = i - 1; break; }
            if (fail < 0) return fail;
            var sorted = str.Skip(fail).OrderBy(c => c).ToList();
            var res = str.Take(fail).ToList();
            i = string.Join("", sorted).LastIndexOf(str[fail]);
            res.Add(sorted[i + 1]);
            sorted.RemoveAt(i + 1);
            res = res.Concat(sorted).ToList();
            return Convert.ToInt64(string.Join("", res));
        }
        static Random r = new Random();
        private static long RandomNumber(int min, int max)
        {
            return r.Next(min, max);
        }

    }
