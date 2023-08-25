/*Challenge link:https://www.codewars.com/kata/59f08f89a5e129c543000069/train/csharp
Question:
In this Kata, you will be given an array of strings and your task is to remove all consecutive duplicate letters from each string in the array.

For example:

dup(["abracadabra","allottee","assessee"]) = ["abracadabra","alote","asese"].

dup(["kelless","keenness"]) = ["keles","kenes"].

Strings will be lowercase only, no spaces. See test cases for more examples.

Good luck!

If you like this Kata, please try:

Alternate capitalization

Vowel consonant lexicon
*/

//***************Solution********************

//replace element with pattern "(.)\\1+", capture group . and \ if appeared more than once.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Linq;
using System.Text.RegularExpressions;

public class Solution{
    public static string[] dup(string[] arr) => arr.Select(x => Regex.Replace(x,"(.)\\1+", "$1")).ToArray();    
}

//method 2
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static IEnumerable<string> dup(IEnumerable<string> arr)
      => arr.Select(x => x.Aggregate("", (c,n) => c.EndsWith(n) ? c : c+n));     
}
//****************Sample Test*****************
using NUnit.Framework;
using System;
 
[TestFixture]
public class SolutionTest
{
  [Test]
  public void ExampleTests()
  {
    Assert.AreEqual(new String[]{"codewars","picaniny","hubububo"}, Solution.dup(new String[]{"ccooddddddewwwaaaaarrrrsssss","piccaninny","hubbubbubboo"}));
    Assert.AreEqual(new String[]{"abracadabra","alote","asese"}, Solution.dup(new String[]{"abracadabra","allottee","assessee"}));       
    Assert.AreEqual(new String[]{"keles","kenes"}, Solution.dup(new String[]{"kelless","keenness"}));
  }

  private static string unDup1(string s){
        string res = "" + s[0];
        for (int i = 1; i < s.Length; i++)        
            if (s[i-1] != s[i]) res += s[i]; 
        return res;
    }

   private static string[] zxy8(string[] arr){
        string [] res = new string[arr.Length]; 
        for (int i = 0; i < res.Length; ++i)
          res[i] = unDup1(arr[i]);
        return res;        
    }

  [Test]
  public void RandomTests(){
    Random random = new Random(); 
    string abc = "abcdefghijklmnopqrstuvwxyzabcd";
    for (int k = 0; k < 100; k++){    
      int arrLen = random.Next(10,20);
      int len = random.Next(10,20);
      int i = 0;
      string [] res = new string[arrLen];
      while (i < arrLen){
        String st = "";
        int j = 0;
        while (j < len){
          int ch  = random.Next(0,26);
          st += abc[ch];
          if (ch % 2 == 0) st+=abc[ch];
          j++;
        }  
        res[i] = st;
        i++;
      }      
      string[] exp = zxy8(res);
      Assert.AreEqual(exp,Solution.dup(res));
    }
  }
}
