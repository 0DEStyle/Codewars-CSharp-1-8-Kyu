/*Challenge link:https://www.codewars.com/kata/57c6c2e1f8392d982a0000f2/train/csharp
Question:
Kata in this series

Histogram - H1
Histogram - H2
Histogram - V1
Histogram - V2
Background
A 6-sided die is rolled a number of times and the results are plotted as a character-based histogram.

Example:

    10
    #
    #
7   #
#   #
#   #     5
#   #     #
# 3 #     #
# # #     #
# # # 1   #
# # # #   #
-----------
1 2 3 4 5 6
Task
You will be passed all the dice roll results, and your task is to write the code to return a string representing a histogram, so that when it is printed it has the same format as the example.

Notes
There are no trailing spaces on the lines
All lines (including the last) end with a newline \n
A count is displayed above each bar (unless the count is 0)
The number of rolls may vary but is always less than 100
*/

//***************Solution********************
using System;
using System.Collections.Generic;
using System.Linq;

public class Dinglemouse  {
  public static string Histogram(int[] xs) {
    //get max value of xs, create new list s 
    var t = xs.Max();
    var s = new List<string>();
    
    //loop from t down to 0, add string.
    //loop from 0 up to 6, j is the curret element,
    //if xs[j] is equal to i and xs[j] is not 0, then if xs[j] is less than 10, return string interpolation result of {xs[j]}
    //else if xs[j] is less than i or xs[j] is equal to 0, return a space " ", else "# "
    //select the matched elements and join the string, then trim the ending space.
    for (var i = t; i >= 0; i--)
      s.Add(string.Join("", Enumerable.Range(0,6).Select(j =>
        xs[j] == i && xs[j] != 0
           ? (xs[j] < 10 ? $"{xs[j]} " : $"{xs[j]}") 
           : xs[j] < i || xs[j] == 0
           ? "  " 
           : "# "
      )).TrimEnd());
    
    //the bottom of the histogram
    s.Add("-----------");
    s.Add("1 2 3 4 5 6");
    
    //join string with new space, in list s, select element were string is not null or empty, add new space at the end.
    return string.Join("\n",s.Where(r => !string.IsNullOrEmpty(r)))+"\n";
  }  
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;
  using System.Text;

  [TestFixture]
  public class KataTests
  {
    [Test]
    public void BasicTest()
    { 
      string expected = 
      "    10\n"+
      "    #\n"+
      "    #\n"+
      "7   #\n"+
      "#   #\n"+
      "#   #     5\n"+
      "#   #     #\n"+
      "# 3 #     #\n"+
      "# # #     #\n"+
      "# # # 1   #\n"+
      "# # # #   #\n"+
      "-----------\n"+
      "1 2 3 4 5 6\n";
      Assert.AreEqual(expected, show(new int[] {7,3,10,1,0,5}));
    }
    
    [Test]
    public void ZeroTest()
    { 
      string expected = 
      "-----------\n"+
      "1 2 3 4 5 6\n";
      Assert.AreEqual(expected, show(new int[]{0,0,0,0,0,0}));
    }
    
    private string show (int[] results)
    {
      Console.WriteLine(string.Join(",", results));
      string hist = Dinglemouse.Histogram(results);
      Console.WriteLine(hist);
      return hist;        
    }
    
    [Test]
    public void RandomTest()
    {
      var rand = new Random();
      
      Func<int[], string> myHistogram = delegate (int[] results)
      {
        StringBuilder sb = new StringBuilder();
        int max = results.Max();
        for (int height = max+1; height > 0; height--) 
        {
          StringBuilder line = new StringBuilder();
          for (int i = 0; i < 6; i++) 
          {
            if (results[i] != 0 && results[i] == height-1) 
            {
              line.Append(results[i]);
              line.Append(results[i] < 10 ? " " : ""); // number above bar
            }
            else
            {
              if (results[i] >= height) 
              {
                line.Append("# "); 
              }
              else 
              {
                line.Append("  ");
              }
            }
          }
          var trimmed = line.ToString().TrimEnd();
          if (trimmed.Length != 0)
          {
            sb.Append(trimmed);
            sb.AppendLine();
          }
        }
        sb.Append("-----------\n");
        sb.Append("1 2 3 4 5 6\n");
        return sb.ToString();
      };
      
      for (int n = 0; n < 10; n++)
      {
        int[] results = new int[] {0,0,0,0,0,0};
        for (int t = 0; t < 50; t++) 
        {
          int result = rand.Next(1,7);
          results[result-1]++;
        }
      
        Assert.AreEqual(myHistogram(results), show(results));
        Console.WriteLine("<hr>");          
      }
    }
  }
}
