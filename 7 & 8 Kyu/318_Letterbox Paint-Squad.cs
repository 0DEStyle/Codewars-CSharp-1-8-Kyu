/*Challenge link:https://www.codewars.com/kata/597d75744f4190857a00008d/train/csharp
Question:
Story
You and a group of friends are earning some extra money in the school holidays by re-painting the numbers on people's letterboxes for a small fee.

Since there are 10 of you in the group each person just concentrates on painting one digit! For example, somebody will paint only the 1's, somebody else will paint only the 2's and so on...

But at the end of the day you realise not everybody did the same amount of work.

To avoid any fights you need to distribute the money fairly. That's where this Kata comes in.

Kata Task
Given the start and end letterbox numbers, write a method to return the frequency of all 10 digits painted.

Example
For start = 125, and end = 132

The letterboxes are

125 = 1, 2, 5
126 = 1, 2, 6
127 = 1, 2, 7
128 = 1, 2, 8
129 = 1, 2, 9
130 = 1, 3, 0
131 = 1, 3, 1
132 = 1, 3, 2
The digit frequencies are:

0 is painted 1 time
1 is painted 9 times
2 is painted 6 times
etc...
and so the method would return [1,9,6,3,0,1,1,1,1,1]

Notes
0 < start <= end
In C, the returned value will be free'd.
*/

//***************Solution********************
//create a string to store all number starting from start to end using Linq Enumerable
//then count each letter, store in the respective location in the array and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Collections.Generic;
using System.Linq;

public class Kata{
  public static IEnumerable<int> PaintLetterBoxes(int start, int end){
    string s = string.Concat(Enumerable.Range(start,end-start+1));
    return new int[10] {s.Count(x => x == '0')
      , s.Count(x => x == '1'), s.Count(x => x == '2'), s.Count(x => x == '3')
      , s.Count(x => x == '4'), s.Count(x => x == '5'), s.Count(x => x == '6')
      , s.Count(x => x == '7'), s.Count(x => x == '8'), s.Count(x => x == '9')};
  }
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;

  [TestFixture]
  public class SolutionTest
  {
    private static Random rnd = new Random();
    
    private static IEnumerable<int> solution(int start, int end)
    {
        // Initialize array with 10 spaces, filled with 0
        int[] result = Enumerable.Repeat(0, 10).ToArray();
        
        // Iterate over each letter box
        for (int i = start; i <= end; ++i)
        {
            // Get "length" of a positive number
            int length = (int)Math.Floor(Math.Log10(i) + 1);
            
            // Iterate over number
            for (int j = 0; j < length; ++j)
            {
                // Mathematically get digit from number
                int digit = i / (int)Math.Pow(10, j) % 10;
                
                // Increment that digit in our result array
                ++result[digit];
            }
        }

        return result;
    }
  
    [Test, Description("Sample Test")]
    public void ExampleTest()
    {
      Assert.AreEqual(new int[] {1,9,6,3,0,1,1,1,1,1}, Kata.PaintLetterBoxes(125, 132).ToArray());
    }
    
    [Test, Description("Just One Box")]
    public void OneBoxTest()
    {
      Assert.AreEqual(new int[] {2,2,0,0,0,0,0,0,0,0}, Kata.PaintLetterBoxes(1001, 1001).ToArray());
    }
    
    [Test, Description("Just One Box (Random)")]
    public void OneBoxRandomTest()
    {
      for (int i = 0; i < 500; ++i)
      {
        int start = rnd.Next(1, 1001);
        int end = start;
        int[] expected = solution(start, end).ToArray();
        int[] actual = Kata.PaintLetterBoxes(start, end).ToArray();
        Console.WriteLine($"{start} - {end} : {{{String.Join(", ", expected.Select(v => v.ToString()))}}}");
        Assert.AreEqual(expected, actual);
      }
    }
    
    [Test, Description("Random Range Tests")]
    public void RandomRangeTest()
    {
      for (int i = 0; i < 500; ++i)
      {
        int start = rnd.Next(1, 1001);
        int end = rnd.Next(1, 101) + start;
        int[] expected = solution(start, end).ToArray();
        int[] actual = Kata.PaintLetterBoxes(start, end).ToArray();
        Console.WriteLine($"{start} - {end} : {{{String.Join(", ", expected.Select(v => v.ToString()))}}}");
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
