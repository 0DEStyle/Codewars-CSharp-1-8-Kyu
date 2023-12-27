/*Challenge link:https://www.codewars.com/kata/63a31f7d66ad15f77d5358b9/train/csharp
Question:
Task
"Given a positive integer n, return a string representing the pyramid associated with it."
Pyramids can get huge, so range of n is 1 - 100. Rows are delimited by a newline '\n' and all rows have same length. Make sure to include the corrrect amount of leading and trailing whitespace where necessary. Be aware there is also a recurring pattern of whitespace inside the pyramid.

Characters used in pyramid: '/', '\', ' ', '_', ':', '|', '.', '´'.
Code length limited to 1000 (C#: 2000) characters to prevent hardcoding.

'*' shows whitespace to give a better impression how to render the pyramid

 n = 3      *******./\*****
            ****.´\/__\****
            *.´\´\/__:_\***
            \*\´\/_|__|_\**
            *\´\/|__|__|_\*
            **\/__|__|__|_\
Puzzle
"Can you figure out the pattern and extend pyramids for n > 5?"
--------------------------------------------------
 pyramid                    n     properties
--------------------------------------------------

 ./\                        1     height: 2
\/__\                             width:  5
           
    ./\                     2     height: 4
 .´\/__\                          width: 10
\´\/__:_\ 
 \/_|__|_\
            
       ./\                  3     height: 6
    .´\/__\                       width: 15
 .´\´\/__:_\   
\ \´\/_|__|_\  
 \´\/|__|__|_\ 
  \/__|__|__|_\
             
          ./\               4     height: 8     
       .´\/__\                    width: 20
    .´\´\/__:_\     
 .´\ \´\/_|__|_\    
\´\´\´\/|__|__|_\   
 \´\´\/__|__|__|_\  
  \´\/_|__|__|__|_\ 
   \/|__|__|__|__|_\
               
             ./\            5     height: 10     
          .´\/__\                 width: 25  
       .´\´\/__:_\       
    .´\ \´\/_|__|_\      
 .´\´\´\´\/|__|__|_\     
\ \´\´\´\/__|__|__|_\    
 \´\´\´\/_|__|__|__|_\   
  \´\´\/|__|__|__|__|_\  
   \´\/__|__|__|__|__|_\ 
    \/_|__|__|__|__|__|_\
               
 ...
 
 
                      ./\                   8     height: 16      
                   .´\/__\                        width: 40
                .´\´\/__:_\             
             .´\ \´\/_|__|_\            
          .´\´\´\´\/|__|__|_\           
       .´\ \´\´\´\/__|__|__|_\          
    .´\´\´\´\´\´\/_|__|__|__|_\         
 .´\ \´\´\´\´\´\/|__|__|__|__|_\        
\´\´\´\´\´\´\´\/__|__|__|__|__|_\       
 \´\´\´\´\´\´\/_|__|__|__|__|__|_\      
  \´\´\´\´\´\/|__|__|__|__|__|__|_\     
   \´\´\´\´\/__|__|__|__|__|__|__|_\    
    \´\´\´\/_|__|__|__|__|__|__|__|_\   
     \´\´\/|__|__|__|__|__|__|__|__|_\  
      \´\/__|__|__|__|__|__|__|__|__|_\ 
       \/_|__|__|__|__|__|__|__|__|__|_\
       
 ...
       
Good luck!

Too easy for you, try code golfing it.
*/

//***************Solution********************
/*⠀⠀⠀⠀⠀
  /\_/\   no way   /\_/\     Code length limited to 1000 (C#: 2000) characters to prevent hardcoding.
=(  o.o)=        =(0.0⸝⸝ )= /
ʕ(   ა૮)           (ა૮   )ʔ
           ./\               
        .´\/__\                 
     .´\´\/__:_\   
    \ \´\/_|__|_\  
     \´\/|__|__|_\ 
      \/__|__|__|_\
*/

using System;
using System.Linq;
using System.Collections.Generic;

public static class Kata {
  public static string DrawPyramid(int n) {
    Console.WriteLine($"n:{n}");
    //return fixed string if n is 1.
    if(n==1) return " ./\\ \n\\/__\\";
    
    //str to store patterns
    var str = new char[2*n][];
    
    //pattern generator
    void gen(string s, int a, int b, int c, int d){
      //info checking
      //Console.WriteLine($"s{s},a{a},b{b},c{c},d{d}");
      for(int i=b;i<=c;i++) 
        str[a][i] = s[(i-b+d)%s.Length];
    }
    
    //top side, top front, top back
    var ts=0; var tf=0; var tb=0;
    
    for(int i=0; i<2*n; i++){
      str[i] = new char[5*n];
      //top
      ts = (i<n) ? 3*(n-i)-2 : i-n;
      tf = (n*3)-i-1;
      tb = (n*3)+i;
      
      //Left side pyramide
      str[i][ts] = (i < n) ? '.' : '\\';
      gen(@"´\",i,ts+1,tf,0);
      
      //front view pyramide, edge and middle
      str[i][tf] = '/';
      gen("_|_",i,tf+1,tb-1,i);
      str[i][tb] = '\\';
    }
    //the space at the start of left side pyramide
    for(int i=3; i<=n; i+=2) 
      str[i][(n-i)*3+1]=' ';
    
    //inside front view pyramide
    gen("__",1,(n*3)-1,n*3,0);
    //3rd row replacement
    gen("__:_",2,(n*3)-2,(n*3)+1,0);
    
    //print result, comment below out because "Max Buffer Size Reached (1.5 MiB)"
    //Console.WriteLine(string.Join("\n", str.Select(x => new string(x).Replace('\0',' '))));
    //join elements inside str with "\n", but frist replace nul character with empty space.
    return string.Join("\n", str.Select(x => new string(x).Replace('\0',' ')));
  }
}
//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.IO;
  using System.Linq;

  [TestFixture]
  public class SolutionTest
  {
    // also available in PRELOADED section for sample tests
    internal static class Helper {
      public static Lazy<int> CodeLength = new Lazy<int>(() => File.ReadAllText("/workspace/solution.txt").Length);
    }
    
    public void Act(int n, string expected) {
      var userSolution = Kata.DrawPyramid(n);
      if (n > 10) Assert.IsTrue(expected == userSolution, $"Invalid solution for n = {n} (verify your solution works for smaller test cases)");
      else Assert.AreEqual(expected, userSolution, $"Invalid solution for n = {n}");
    }
    
    // Code Golf requirement
    
    [Test(Description = "[Code length requirement] (max 2000)")]
    public void TestCodeLength() {
      var codeLength = Helper.CodeLength.Value;
      const int limit = 2000;
      Assert.IsTrue(codeLength < limit, $"Oops, code length is {codeLength} but should be less than or equal to {limit}");
    }
    
    // Fixed tests
    
    public static string[] pyramids = new[] {
      string.Join("\n", new[]{
         " ./\\ ", 
        "\\/__\\"}),
      string.Join("\n", new[]{
         "    ./\\   ",
        " .´\\/__\\  ",
       "\\´\\/__:_\\ ",
        " \\/_|__|_\\"}),
      string.Join("\n", new[]{
         "       ./\\     ",
        "    .´\\/__\\    ",
       " .´\\´\\/__:_\\   ",
      "\\ \\´\\/_|__|_\\  ",
       " \\´\\/|__|__|_\\ ",
        "  \\/__|__|__|_\\"}),
      string.Join("\n", new[]{
         "          ./\\       ",
        "       .´\\/__\\      ",
       "    .´\\´\\/__:_\\     ",
      " .´\\ \\´\\/_|__|_\\    ",
     "\\´\\´\\´\\/|__|__|_\\   ",
      " \\´\\´\\/__|__|__|_\\  ",
       "  \\´\\/_|__|__|__|_\\ ",
        "   \\/|__|__|__|__|_\\"}),
      string.Join("\n", new[]{
         "             ./\\         ",
        "          .´\\/__\\        ",
       "       .´\\´\\/__:_\\       ",
      "    .´\\ \\´\\/_|__|_\\      ",
     " .´\\´\\´\\´\\/|__|__|_\\     ",
    "\\ \\´\\´\\´\\/__|__|__|_\\    ",
     " \\´\\´\\´\\/_|__|__|__|_\\   ",
      "  \\´\\´\\/|__|__|__|__|_\\  ",
       "   \\´\\/__|__|__|__|__|_\\ ",
        "    \\/_|__|__|__|__|__|_\\"}),
    };
    
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    [TestCase(5)]
    [Test(Description = "Fixed Tests")]
    public void Pyramid(int n) {
      Act(n, pyramids[n - 1]);
    }
    
    // Random tests
    
    private void DoTest(int n) {
      var expected = Reference(n);
      Act(n, expected);
      string Reference(int n) {
        string Repeat(string s, int k) => string.Concat(Enumerable.Repeat(s, k));
        int w = n * 5, h = n << 1;
        int yc = h >> 1;
        return string.Join("\n", Enumerable.Range(0, h).Select(y => {
          var a = Repeat(" ", y < n ? (n - y - 1) * 3 + 1 : 0);
          var b = y < n ? "." : "";
          var c = y == 0 ? "" : y < n ? (y == 1 ? "´\\" : y % 2 != 0 ? "´\\ \\" + Repeat("´\\", y - 2) : Repeat("´\\", y)) : "";
          var d = y != n ? "" : n == 1 ? "\\" : n % 2 != 0 ? "\\ \\" + Repeat("´\\", n - 2) : "\\" + Repeat("´\\", n - 1);
          var e = y <= n ? "" : Repeat(" ", y - n) + "\\" + Repeat("´\\", n - (y - n) - 1);
          var f = y == 0 ? "" : y == 1 ? "__" : y == 2 ? "__:_" : (Repeat(y % 3 == 0 ? "_|_" : y % 3 == 1 ? "|__" : "__|", (int)Math.Ceiling((y << 1) / 3.0))).Substring(0, y << 1);
          var g = Repeat(" ", h - 1 - y);
          return a + b + c + d + e + "/" + f + "\\" + g; 
        }));
      }
    }
    
    private void BatchTest(int a, int b, bool shuffle) {
      var rnd = new Random((int)(DateTime.Now.Ticks%int.MaxValue));
      int RandInt(int a, int b) => (int)(rnd.Next(b - a)) + a;
      int RandRange(int a, int b) => RandInt(a, b + 1);
      void Shuffle<T>(T[] arr) { // Fisher-Yates
        for (int i = arr.Length - 1; i > 0; i--) {
          int j = RandRange(0, i);
          (arr[i], arr[j]) = (arr[j], arr[i]);
        }
      }
      var ns = Enumerable.Range(0, b - a).Select(n => n + a).ToArray();
      if (shuffle) Shuffle(ns);
      foreach (var n in ns) {
        DoTest(n);
      }
    }
    
    [Test(Description = "Random Tests - small")]
    public void RandomTestsSmall() {
      BatchTest(1, 11, false);
    }
    
    [Test(Description = "Random Tests")]
    public void RandomTests() {
      BatchTest(11, 101, true);
    }
  }
}
