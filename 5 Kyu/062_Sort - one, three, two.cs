/*Challenge link:https://www.codewars.com/kata/56f4ff45af5b1f8cd100067d/train/csharp
Question:
Hey You !
Sort these integers for me ...

By name ...

Do it now !

Input
Range is 0-999

There may be duplicates

The array may be empty

Example
Input: 1, 2, 3, 4
Equivalent names: "one", "two", "three", "four"
Sorted by name: "four", "one", "three", "two"
Output: 4, 1, 3, 2
Notes
Don't pack words together:
e.g. 99 may be "ninety nine" or "ninety-nine"; but not "ninetynine"
e.g 101 may be "one hundred one" or "one hundred and one"; but not "onehundredone"
Don't fret about formatting rules, because if rules are consistently applied it has no effect anyway:
e.g. "one hundred one", "one hundred two"; is same order as "one hundred and one", "one hundred and two"
e.g. "ninety eight", "ninety nine"; is same order as "ninety-eight", "ninety-nine"
*/

//***************Solution********************
using System.Linq;

public class Dinglemouse{
  
  //fixed name for numbers
    private static readonly string[] Names = new string[] {
      "zero", "one", "two", "three", "four", "five", 
      "six", "seven", "eight", "nine", "ten", 
      "eleven", "twelve", "thirteen", "fourteen", "fifteen", 
      "sixteen", "seventeen", "eighteen", "nineteen"
    };
  
  //fixed name for more numbers
    private static readonly string[] Names2 = new string[] {
      "twenty", "thirty", "forty", "fifty", "sixty", 
      "seventy", "eighty", "ninety"
    };
  
    private static string Name(int n){
      //less than 20
      if (n < 20) 
        return Names[n];
      //less than 100
      if (n < 100) 
        return Names2[n / 10 - 2] + (n % 10 > 0 ? $" {Names[n % 10]}" : "");
      
      //more than 100
      return Names[n / 100] + " hundred" + (n % 100 > 0 ? $" {Name(n % 100)}" : "");
    }
  
  //order words in alphabetic order
    public static int[] Sort(int[] array) => array.OrderBy(Name).ToArray();
}

//****************Sample Test*****************
//the test case from java version
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
public class SolutionTests
{
    [Test]
    public void Zero()
    {
        var expected = new[] { 1, 3, 2, 0 };
        Assert.AreEqual(expected, Dinglemouse.Sort(new[] { 0, 1, 2, 3 }));
    }

    [Test]
    public void Empty()
    {
        var expected = new int[0];
        Assert.AreEqual(expected, Dinglemouse.Sort(new int[0]));
    }

    [Test]
    public void Duplicates()
    {
        var expected = new[] { 8, 8, 9, 9, 10, 10 };
        Assert.AreEqual(expected, Dinglemouse.Sort(new[] { 8, 8, 9, 9, 10, 10 }));
    }

    [Test]
    public void Smaller()
    {
        var expected = new[] { 8, 18, 11, 15, 5, 4, 14, 9, 19, 1, 7, 17, 6, 16, 10, 13, 3, 12, 20, 2, 0 };
        Assert.AreEqual(expected, Dinglemouse.Sort(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }));
    }

    [Test]
    public void Bigger()
    {
        var expected = new[] { 999, 99, 100, 300, 200 };
        Assert.AreEqual(expected, Dinglemouse.Sort(new[] { 99, 100, 200, 300, 999 }));
    }

    [Test]
    public void All()
    {
        var ary = new int[1000];
        for (int i = 0; i <= 999; i++)
            ary[i] = i;
        var expected = Sort(ary);
        Assert.AreEqual(expected, Dinglemouse.Sort(ary));
    }

    private Random random = new Random();

    [Test]
    public void Random()
    {
        // 100 random test cases
        for (int r = 0; r < 100; r++)
        {
            var ary = new int[10];
            for (int i = 0; i < ary.Length; i++)
                ary[i] = random.Next(0, 999 + 1);
            var expected = Sort(ary);
            Assert.AreEqual(expected, Dinglemouse.Sort(ary));
        }
    }

    private static int[] Sort(int[] array) => array.OrderBy(x => x, Comparer<int>.Create((a, b) => IntToName(a).CompareTo(IntToName(b)))).ToArray();

    private static string IntToName(int x)
    {
        var small = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen" };
        var tens = new string[] { "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        int r10 = x % 10, r100 = x % 100;
        string result;
        if (r100 <= 15) result = small[r100];
        else if (r100 < 20) result = small[r10].EndsWith("t") ? small[r10] + "een" : small[r10] + "teen";
        else result = tens[r100 / 10] + (r10 != 0 ? "-" + small[r10] : "");
        if (x >= 100 && r100 == 0) result = small[x / 100] + " hundred";
        else if (x >= 100) result = small[x / 100] + " hundred " + result;
        return result;
    }
}
