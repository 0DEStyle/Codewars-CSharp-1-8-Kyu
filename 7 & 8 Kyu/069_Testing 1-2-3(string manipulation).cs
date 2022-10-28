/*Challenge link:https://www.codewars.com/kata/54bf85e3d5b56c7a05000cf9/train/csharp
Question:
Your team is writing a fancy new text editor and you've been tasked with implementing the line numbering.

Write a function which takes a list of strings and returns each line prepended by the correct number.

The numbering starts at 1. The format is n: string. Notice the colon and space in between.

Examples: (Input --> Output)

[] --> []
["a", "b", "c"] --> ["1: a", "2: b", "3: c"]
*/

//***************Solution********************
//solution 1
//create a string format, add elements into list, return list
using System.Collections.Generic;

public class LineNumbering 
{
    public static List<string> Number(List<string> lines) {
      List<string> lines2 = new List<string> {};
      
      for (int i  = 1; i < lines.Count+1; i++)
        lines2.Add(string.Format("{0:d1}: {1:d1}",i, lines[i - 1]));
      return lines2;
    }
}
//solution 2
//same as above
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Collections.Generic;
using System.Linq;

public class LineNumbering 
{
  public static List<string> Number(List<string> lines) => lines.Select((x, i) => $"{i + 1}: {x}").ToList();
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class LineNumberingTest 
{
    [TestCase]
    public void basicTests() {
        Assert.AreEqual(new List<string>(), LineNumbering.Number(new List<string>()));
        Assert.AreEqual(new List<string>{"1: a", "2: b", "3: c"}, LineNumbering.Number(new List<string>{"a", "b", "c"}));
        Assert.AreEqual(new List<string>{"1: ", "2: ", "3: ", "4: ", "5: "}, LineNumbering.Number(new List<string>{"", "", "", "", ""}));
    }
    
    private static List<string> Sol(List<string> lines) 
    {
        List<string> result = new List<string>();
        int number = 1;
        foreach(string line in lines) 
        {
            result.Add((number++) + ": " + line);
        }
        return result;
    }

    // Random length/number of tests use same iteration style as Java solution.
    [TestCase]
    public void randomTests() 
    {
        Random r = new Random();
        for (int i = 0; i < 100; i++) 
        {
            List<string> l = Enumerable.Range(0, r.Next(20)).Select(k =>
              Enumerable.Range(0, r.Next(10))
              .Aggregate("", (a,b) => a + "abcdefghijklmnopqrstuvwxyz"[r.Next(26)])
            ).ToList();
            Assert.AreEqual(Sol(l), LineNumbering.Number(l));
        }   
    }
    
}
