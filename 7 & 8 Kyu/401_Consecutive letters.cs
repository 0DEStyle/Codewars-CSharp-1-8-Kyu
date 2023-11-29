/*Challenge link:https://www.codewars.com/kata/5ce6728c939bf80029988b57/train/csharp
Question:
In this Kata, we will check if a string contains consecutive letters as they appear in the English alphabet and if each letter occurs only once.

Rules are: (1) the letters are adjacent in the English alphabet, and (2) each letter occurs only once.

For example: 
solve("abc") = True, because it contains a,b,c
solve("abd") = False, because a, b, d are not consecutive/adjacent in the alphabet, and c is missing.
solve("dabc") = True, because it contains a, b, c, d
solve("abbc") = False, because b does not occur once.
solve("v") = True
All inputs will be lowercase letters.

More examples in test cases. Good luck!
*/

//***************Solution********************
//sort string s in alphabetic order
//then check if the pattern is contained inside the string a-z
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public class Solution{
    public static bool solve(string s) => 
      "abcdefghijklmnopqrstuvwxyz".Contains(string.Concat(s.OrderBy(ch => ch)));
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Linq;
 
[TestFixture]
public class SolutionTest
{
  [Test]
  public void ExampleTests()
  {
    Assert.AreEqual(true, Solution.solve("abc"));
    Assert.AreEqual(false, Solution.solve("abd")); 
    Assert.AreEqual(true, Solution.solve("dabc"));
    Assert.AreEqual(false, Solution.solve("abbc"));
    Assert.AreEqual(false, Solution.solve("adda"));
  }

  private bool mu1(string s){  
        return "abcdefghijklmnopqrstuvwxyz".Contains(new string (s.OrderBy(c => c).ToArray()));
    }

  [Test]
  public void RandomTests(){
    Random random = new Random();     
    String alph = "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabc";        
    for (int i = 0; i < 100; i++) {        
       int a = random.Next(0,26);
       int b = random.Next(5,20);
       int c = random.Next(0,6);   
       String s = alph.Substring(a,b);           
       bool exp = mu1(s); 
       Assert.AreEqual(exp,Solution.solve(s));
    }
  }
}
