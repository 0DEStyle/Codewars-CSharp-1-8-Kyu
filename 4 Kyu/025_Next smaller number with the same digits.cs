/*Challenge link:https://www.codewars.com/kata/5659c6d896bc135c4c00021e/train/csharp
Question:
Write a function that takes a positive integer and returns the next smaller positive integer containing the same digits.

For example:

nextSmaller(21) == 12
nextSmaller(531) == 513
nextSmaller(2071) == 2017
Return -1 (for Haskell: return Nothing, for Rust: return None), when there is no smaller number that contains the same digits. Also return -1 when the next smaller number with the same digits would require the leading digit to be zero.

nextSmaller(9) == -1
nextSmaller(111) == -1
nextSmaller(135) == -1
nextSmaller(1027) == -1 // 0721 is out since we don't write numbers with leading zeros
some tests will include very large numbers.
test data only employs positive integers.
The function you write for this challenge is the inverse of this kata: "Next bigger number with the same digits."
*/

//***************Solution********************
using System.Linq;
using System;

public class Kata{
  public static long NextSmaller(long n){
    
    //check validation
    if (n > 0 && (n + "").Length==1) 
      return -1;
    
      string s = n + "";
    
    //check for substring to see if string contain the same digit
      for (int i = s.Length-2; i >= 0; i--){
        if (s.Substring(i) != string.Concat(s.Substring(i).OrderBy(x => x))){
          //Order digits in string
          var t = string.Concat(s.Substring(i).OrderByDescending(x => x));
          //get first digit
          var c = t.First(x => x < s[i]);
          
          //if i is 0 and c is '0' return -1
          //else format and return the result as long.
          return i == 0 && c == '0' ? -1 :
                                  long.Parse(s.Substring(0,i) + c + string.Concat(t.Where((x,y)=> y != t.IndexOf(c))));
        }
      }
    //nothing works, return -1
      return -1;
  }
}

//****************Sample Test*****************
using System;
using System.Linq;
using System.Text;
using NUnit.Framework;
[TestFixture]
public class Tests
{
  [TestCase(100, ExpectedResult=-1)] // thanks @gavinreid2004
  [TestCase(29009, ExpectedResult=20990)] // thanks @steelblue
  [TestCase(21, ExpectedResult = 12)]
  [TestCase(907, ExpectedResult = 790)]
  [TestCase(531, ExpectedResult = 513)]
  [TestCase(513, ExpectedResult = 351)]
  [TestCase(351, ExpectedResult = 315)]
  [TestCase(315, ExpectedResult = 153)]
  [TestCase(153, ExpectedResult = 135)]
  [TestCase(135, ExpectedResult = -1)]
  [TestCase(2071, ExpectedResult = 2017)]
  [TestCase(1027, ExpectedResult = -1)]
  [TestCase(1207, ExpectedResult = 1072)]
  [TestCase(441, ExpectedResult = 414)]
  [TestCase(414, ExpectedResult = 144)]
  [TestCase(123456798, ExpectedResult = 123456789)]
  [TestCase(123456789, ExpectedResult = -1)]
  [TestCase(1234567908, ExpectedResult = 1234567890)]
  [TestCase(9999999999, ExpectedResult = -1)]
  [TestCase(59884848483559, ExpectedResult = 59884848459853)]
  [TestCase(1023456789, ExpectedResult = -1)]
  [TestCase(51226262651257, ExpectedResult = 51226262627551)]
  [TestCase(202233445566, ExpectedResult = -1)]
  [TestCase(506789, ExpectedResult = -1)]
  public long FixedTests(long n)
  {
    return Kata.NextSmaller(n);
  }
  
  private static long Solution(long n)
  {
    var a = n.ToString();
    var bigger = Enumerable.Range(1,a.Length - 1)
      .LastOrDefault(i => a[i-1] > a[i]) - 1;
    if (bigger < 0)
      return -1;
    var smaller = Enumerable.Range(bigger+1, a.Length - bigger - 1)
      .Where(i => a[bigger] > a[i])
      .Aggregate((acc,next) => a[acc] > a[next] ? acc : next);
    if (bigger == 0 && a[smaller] == '0')
      return -1;
    var sb = new StringBuilder(a);
    char temp = sb[bigger]; sb[bigger] = sb[smaller]; sb[smaller] = temp;
    a = sb.ToString();
    return long.Parse(
      a.Substring(bigger+1)
        .OrderByDescending(c => c)
        .Aggregate(new StringBuilder(a.Substring(0, bigger + 1)),
          (acc,ch) => acc.Append(ch))
        .ToString());
  }

  [Test]
  public void RandomTests()
  {
    var rnd = new Random();
    for(int i = 0; i < 200; ++i)
    {
      long n = (long)Math.Exp(43*rnd.NextDouble());
      Assert.AreEqual(Solution(n), Kata.NextSmaller(n));
    }
  }
}
