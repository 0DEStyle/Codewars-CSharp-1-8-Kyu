/*Challenge link:https://www.codewars.com/kata/55b86beb1417eab500000051/train/csharp
Question:
A binary gap within a positive number num is any sequence of consecutive zeros that is surrounded by ones at both ends in the binary representation of num.
For example:
9 has binary representation 1001 and contains a binary gap of length 2.
529 has binary representation 1000010001 and contains two binary gaps: one of length 4 and one of length 3.
20 has binary representation 10100 and contains one binary gap of length 1.
15 has binary representation 1111 and has 0 binary gaps.
Write function gap(num) that,  given a positive num,  returns the length of its longest binary gap.
The function should return 0 if num doesn't contain a binary gap.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//convert n to binary
//pattern: character 0 match once or more, from the end(cut the ending), replace it with nothing
//split string by 1 (now left with only 0 or 00s)
//from the elements, select the one with the longest length

using System;
using System.Linq;
using System.Text.RegularExpressions;

public class Kata{
  public static int Gap(int n) => Regex.Split(Regex.Replace(Convert.ToString(n, 2), @"0+\z",""),"1+").Max(x => x.Length);
}

//linq method
using System;
using System.Linq;

public class Kata
{
  public static int Gap(int num)
  {
     var binary = Convert.ToString(num, 2);
     return binary.Trim('0').Split('1').Select(s => s.Length).Max();
  }
}
//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class Tests
{
  [Test]
  public static void FixedTests()
  {
    Assert.AreEqual(2, Kata.Gap(9), "Not working for 9");
    Assert.AreEqual(4, Kata.Gap(529), "Not working for 529");
    Assert.AreEqual(1, Kata.Gap(20), "Not working for 20");
    Assert.AreEqual(0, Kata.Gap(15), "Not working for 15");
  }
  
  [Test]
  public static void RandomTests()
  {
    Random ran = new Random();
    for(int i = 0; i < 100; i++)
    {
      int num = ran.Next(1000)+1;
      Assert.AreEqual(Solution(num), Kata.Gap(num), "Not working for "+num);
    }
    
  }
  
  private static int Solution(int num)
  {
    string bin = Convert.ToString(num, 2);
    int longest = 0;
    int current = 0;
    for(int i = 0; i < bin.Length; i++)
    {
      if(bin[i].Equals('0')) current++;
      else
      {
        if(current > longest)
          longest = current;
          current = 0;
      }
    }
    return longest;
  }
}
