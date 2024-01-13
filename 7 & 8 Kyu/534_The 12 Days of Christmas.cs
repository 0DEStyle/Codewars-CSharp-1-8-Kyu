/*Challenge link:https://www.codewars.com/kata/57dd3a06eb0537b899000a64/train/csharp
Question:
Oh No!

The song sheets have been dropped in the snow and the lines of each verse have become all jumbled up.

Task
You have to write a comparator function which can sort the lines back into their correct order, otherwise Christmas will be cancelled!

Reminder: Below is what the final verse should look like

On the 12th day of Christmas my true love gave to me
12 drummers drumming,
11 pipers piping, 
10 lords a leaping, 
9 ladies dancing, 
8 maids a milking,
7 swans a swimming, 
6 geese a laying, 
5 golden rings, 
4 calling birds,
3 French hens, 
2 turtle doves and 
a partridge in a pear tree.
Background
A Java comparator function is described as below. Other languages are similar:

int compare(T o1, T o2) Compares its two arguments for order. Returns a negative integer, zero, or a positive integer as the first argument is less than, equal to, or greater than the second.
*/

//***************Solution********************
using System;
using System.Collections.Generic;

public class Dinglemouse{
    public class HelpSaveChristmas : IComparer<string>{
      
      //From the song, the verse order: "On 12 11 10 9 8 7 6 5 4 3 2 a", so On is 13, and a is 1
      //subtract 13 to sort the number in descending order. 
      //substring(0, 2), for the first 2 characters
      private int startingNumber(string str) =>
        13 - int.Parse(str.Substring(0, 2).Replace("On", "13").Replace("a" , "1"));
      
      //https://learn.microsoft.com/en-us/dotnet/api/system.string.compareto?view=net-8.0#system-string-compareto(system-string)
      //compare the starting number of line1 and line 2, 
      //If the strings match, then CompareTo() gives 0. 
      //If they don't match, it gives a positive(1) or negative number(-1) depending on which string comes first.
      
        public int Compare(string line1, string line2){
          //Console.WriteLine(startingNumber(line1).CompareTo(startingNumber(line2)));
          return startingNumber(line1).CompareTo(startingNumber(line2));
        }
    }
}

//solution 2
using System;
using System.Collections.Generic;

public class Dinglemouse
{
  public class HelpSaveChristmas : IComparer<string>
  {
    public int Compare(string line1, string line2)
    {
      string[] order = {"a ", "2 ", "3 ", "4 ", "5 ", "6 ", "7 ", "8 ", "9 ", "10", "11", "12", "On"};
      return Array.IndexOf(order, line2[..2]) - Array.IndexOf(order, line1[..2]);
    }
  }
}

//****************Sample Test*****************
//the test case from java version
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
public class Tests
{
    // Show
    private string ForDisplay(List<string> lines) => string.Join("\n", lines.Select(x => $"\t{x}"));

    // Common testing code
    private void DoTest(int verse, string[] linesOrig)
    {
        Console.WriteLine("Verse " + verse);
        var lines = new List<string>(linesOrig);
        Shuffle(lines);
        Console.WriteLine("Jumbled:\n" + ForDisplay(lines));
        lines.Sort(new Dinglemouse.HelpSaveChristmas());
        Console.WriteLine("Sorted:\n" + ForDisplay(lines));
        Assert.AreEqual(linesOrig, lines.ToArray());
    }

    private static void Shuffle<T>(List<T> deck)
    {
        var rnd = new Random();
        for (int n = deck.Count - 1; n > 0; --n)
        {
            int k = rnd.Next(n + 1);
            T temp = deck[n];
            deck[n] = deck[k];
            deck[k] = temp;
        }
    }

    [Test]
    public void Verse1()
    {
        var linesOrig = new[]
        {
            "On the 1st day of Christmas my true love gave to me",
            "a partridge in a pear tree."
        };
        DoTest(1, linesOrig);
    }

    [Test]
    public void Verse2()
    {
        var linesOrig = new[]
        {
            "On the 2nd day of Christmas my true love gave to me",
            "2 turtle doves and",
            "a partridge in a pear tree."
        };
        DoTest(2, linesOrig);
    }

    [Test]
    public void Verse3()
    {
        var linesOrig = new[]
        {
            "On the 3rd day of Christmas my true love gave to me",
            "3 French hens,",
            "2 turtle doves and",
            "a partridge in a pear tree."
        };
        DoTest(3, linesOrig);
    }

    [Test]
    public void Verse4()
    {
        var linesOrig = new[]
        {
            "On the 4th day of Christmas my true love gave to me",
            "4 calling birds,",
            "3 French hens,",
            "2 turtle doves and",
            "a partridge in a pear tree."
        };
        DoTest(4, linesOrig);
    }

    [Test]
    public void Verse5()
    {
        var linesOrig = new[]
        {
            "On the 5th day of Christmas my true love gave to me",
            "5 golden rings,",
            "4 calling birds,",
            "3 French hens,",
            "2 turtle doves and",
            "a partridge in a pear tree."
        };
        DoTest(5, linesOrig);
    }

    [Test]
    public void Verse6()
    {
        var linesOrig = new[]
        {
            "On the 6th day of Christmas my true love gave to me",
            "6 geese a laying,",
            "5 golden rings,",
            "4 calling birds,",
            "3 French hens,",
            "2 turtle doves and",
            "a partridge in a pear tree."
        };
        DoTest(6, linesOrig);
    }

    [Test]
    public void Verse7()
    {
        var linesOrig = new[]
        {
            "On the 7th day of Christmas my true love gave to me",
            "7 swans a swimming,",
            "6 geese a laying,",
            "5 golden rings,",
            "4 calling birds,",
            "3 French hens,",
            "2 turtle doves and",
            "a partridge in a pear tree."
        };
        DoTest(7, linesOrig);
    }

    [Test]
    public void Verse8()
    {
        var linesOrig = new[]
        {
            "On the 8th day of Christmas my true love gave to me",
            "8 maids a milking,",
            "7 swans a swimming,",
            "6 geese a laying,",
            "5 golden rings,",
            "4 calling birds,",
            "3 French hens,",
            "2 turtle doves and",
            "a partridge in a pear tree."
        };
        DoTest(8, linesOrig);
    }

    [Test]
    public void Verse9()
    {
        var linesOrig = new[]
        {
            "On the 9th day of Christmas my true love gave to me",
            "9 ladies dancing,",
            "8 maids a milking,",
            "7 swans a swimming,",
            "6 geese a laying,",
            "5 golden rings,",
            "4 calling birds,",
            "3 French hens,",
            "2 turtle doves and",
            "a partridge in a pear tree."
        };
        DoTest(9, linesOrig);
    }

    [Test]
    public void Verse10()
    {
        var linesOrig = new[]
        {
            "On the 10th day of Christmas my true love gave to me",
            "10 lords a leaping,",
            "9 ladies dancing,",
            "8 maids a milking,",
            "7 swans a swimming,",
            "6 geese a laying,",
            "5 golden rings,",
            "4 calling birds,",
            "3 French hens,",
            "2 turtle doves and",
            "a partridge in a pear tree."
        };
        DoTest(10, linesOrig);
    }

    [Test]
    public void Verse11()
    {
        var linesOrig = new[]
        {
            "On the 11th day of Christmas my true love gave to me",
            "11 pipers piping,",
            "10 lords a leaping,",
            "9 ladies dancing,",
            "8 maids a milking,",
            "7 swans a swimming,",
            "6 geese a laying,",
            "5 golden rings,",
            "4 calling birds,",
            "3 French hens,",
            "2 turtle doves and",
            "a partridge in a pear tree."
        };
        DoTest(11, linesOrig);
    }

    [Test]
    public void Verse12()
    {
        var linesOrig = new[]
        {
            "On the 12th day of Christmas my true love gave to me",
            "12 drummers drumming,",
            "11 pipers piping,",
            "10 lords a leaping,",
            "9 ladies dancing,",
            "8 maids a milking,",
            "7 swans a swimming,",
            "6 geese a laying,",
            "5 golden rings,",
            "4 calling birds,",
            "3 French hens,",
            "2 turtle doves and",
            "a partridge in a pear tree."
        };
        DoTest(12, linesOrig);
    }
}
