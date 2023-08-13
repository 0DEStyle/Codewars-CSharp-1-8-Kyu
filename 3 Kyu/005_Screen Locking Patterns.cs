/*Challenge link:https://www.codewars.com/kata/585894545a8a07255e0002f1/train/csharp
Question:
Screen Locking Patterns
You might already be familiar with many smartphones that allow you to use a geometric pattern as a security measure. To unlock the device, you need to connect a sequence of dots/points in a grid by swiping your finger without lifting it as you trace the pattern through the screen.

The image below has an example pattern of 7 dots/points: (A -> B -> I -> E -> D -> G -> C).

//see image in the challenge link

For this kata, your job is to implement a function that returns the number of possible patterns starting from a given first point, that have a given length.

More specifically, for a function countPatternsFrom(firstPoint, length), the parameter firstPoint is a single-character string corresponding to the point in the grid (e.g.: 'A') where your patterns start, and the parameter length is an integer indicating the number of points (length) every pattern must have.

For example, countPatternsFrom("C", 2), should return the number of patterns starting from 'C' that have 2 two points. The return value in this case would be 5, because there are 5 possible patterns:

(C -> B), (C -> D), (C -> E), (C -> F) and (C -> H).

Bear in mind that this kata requires returning the number of patterns, not the patterns themselves, so you only need to count them. Also, the name of the function might be different depending on the programming language used, but the idea remains the same.

Rules
In a pattern, the dots/points cannot be repeated: they can only be used once, at most.
In a pattern, any two subsequent dots/points can only be connected with direct straight lines in either of these ways:
Horizontally: like (A -> B) in the example pattern image.
Vertically: like (D -> G) in the example pattern image.
Diagonally: like (I -> E), as well as (B -> I), in the example pattern image.
Passing over a point between them that has already been 'used': like (G -> C) passing over E, in the example pattern image. This is the trickiest rule. Normally, you wouldn't be able to connect G to C, because E is between them, however when E has already been used as part the pattern you are tracing, you can connect G to C passing over E, because E is ignored, as it was already used once.

The sample tests have some examples of the number of combinations for some cases to help you check your code.

Haskell Note: A data type Vertex is provided in place of the single-character strings. See the solution setup code for more details.

Fun fact:

In case you're wondering out of curiosity, for the Android lock screen, the valid patterns must have between 4 and 9 dots/points. There are 389112 possible valid patterns in total; that is, patterns with a length between 4 and 9 dots/points.


*/

//***************Solution********************

/* Lock pattern order
A B C
D E F
G H I
*/
public static class Kata{
  
  
  // Rule 1,2,3,4,5 Connects middle or side
  // Rule 6, doesnt cross center OR jumps a taken point 
  private static bool CanGo(int cur, int m, int next) =>
    (cur == 4 || next == 4 || (cur|next) % 2 > 0 && cur+next != 8) || (1<<(cur+next>>1) &m) > 0;
  
  //fd = firstDot, l = length
  public static int CountPatternsFrom(char fd, int l, int m = 0){
    
    //length less than 1 return length
    if (l <= 1) 
      return l;
    
    //avoid calculation
    if (l > 9) 
      return 0;
    
    // mark this bit as taken, shift bit to the left by 1
    // |= is the same as m = m | (1 << fd-'A')
    m |= (1 << fd-'A'); 
     
    int sum = 0;
    for (int i = 0; i < 9; i++)
      //recursive pattern check using CountPatternsFrom function.
      if ((m& 1<<i) == 0 && CanGo(fd-'A', m, i))
        sum+= CountPatternsFrom((char)('A'+i), l-1, m);
    return sum;
  }
}

//****************Sample Test*****************
using System;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class TestFixture
{
  [Test, Description("Example Tests")]   
  [TestCase('A', 0, ExpectedResult=0)]
  [TestCase('A', 10, ExpectedResult=0)]
  [TestCase('B', 1, ExpectedResult=1)]
  [TestCase('C', 2, ExpectedResult=5)]
  [TestCase('D', 3, ExpectedResult=37)]
  [TestCase('E', 4, ExpectedResult=256)]
  [TestCase('E', 8, ExpectedResult=23280)]
  public int ExampleTests(char firstDot, int length)
  {
    return Kata.CountPatternsFrom(firstDot, length);
  }
  
  [Test, Description("Random Tests")]
  public void RandomTests()
  {
    var rng = new Random();
    for (var i = 0; i < 25; i++)
    {
      var fromDot = "ABCDEFGHI"[rng.Next(9)];
      var length = rng.Next(10);
      var expected = Solver.CountPatternsFrom(fromDot, length);
      var actual = Kata.CountPatternsFrom(fromDot, length);
      Assert.AreEqual(expected, actual);
    }
  }
  
  [Test, Description("Calculating all valid combinations for a typical Android device's lockscreen")]
  public void RealWorldTest()
  {
    var sum = 0;
    foreach (var letter in "ABCDEFGHI")
    {
      sum += new[] { 4, 5, 6, 7, 8, 9 }.Select(a => Kata.CountPatternsFrom(letter, a)).Sum();
    }
    Assert.AreEqual(sum, 389112);
  }
  
  private static class Solver
  {
    private static int paths = 0;
  
    internal static int CountPatternsFrom(char firstDot, int length)
    {
      paths = 0;
      Flood(firstDot, firstDot.ToString(), 1, length);
      return paths;
    }
    
    private static void Flood(char fromDot, string path, int step, int max)
    {
      if (step == max)
      {
        paths++;
        return;
      }
      foreach (var letter in ValidFrom(fromDot, path))
      {
        Flood(letter, path + fromDot, step + 1, max);
      }    
    }
    
    private static string ValidFrom(char fromDot, string path)
    {
      var potential = "";
      switch (fromDot)
      {
        case 'A': potential = "BDEFH"   + IncludeFlying(new[] { "BC", "DG", "EI" }, path); break;
        case 'C': potential = "BDEFH"   + IncludeFlying(new[] { "BA", "EG", "FI" }, path); break;
        case 'G': potential = "BDEFH"   + IncludeFlying(new[] { "DA", "EC", "HI" }, path); break;    
        case 'I': potential = "BDEFH"   + IncludeFlying(new[] { "EA", "FC", "HG" }, path); break;   
        case 'B': potential = "ACDEFGI" + IncludeFlying(new[] { "EH" }, path); break;    
        case 'D': potential = "ABCEGHI" + IncludeFlying(new[] { "EF" }, path); break;  
        case 'F': potential = "ABCEGHI" + IncludeFlying(new[] { "ED" }, path); break;   
        case 'H': potential = "ACDEFGI" + IncludeFlying(new[] { "EB" }, path); break;
        case 'E': potential = "ABCDFGHI"; break;
      }
      return RemoveUsed(potential, path);
    }
    
    private static string IncludeFlying(string[] pairs, string path)
    {
      return string.Join("", pairs.Where(a => path.Contains(a[0])).Select(a => a[1]));
    }
    
    private static string RemoveUsed(string letters, string path)
    {
      return string.Join("", letters.ToCharArray().Where(a => !path.Contains(a)));
    }  
  }  
}
