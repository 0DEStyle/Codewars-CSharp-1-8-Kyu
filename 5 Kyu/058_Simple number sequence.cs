/*Challenge link:https://www.codewars.com/kata/5a28cf591f7f7019a80000de
Question:
In this Kata, you will be given a string of numbers in sequence and your task will be to return the missing number. If there is no number missing or there is an error in the sequence, return -1.

For example:

missing("123567") = 4 
missing("899091939495") = 92
missing("9899101102") = 100
missing("599600601602") = -1 -- no number missing
missing("8990919395") = -1 -- error in sequence. Both 92 and 94 missing.
The sequence will always be in ascending order.

More examples in the test cases.

Good luck!
*/

//***************Solution********************
using static System.Math;

public class Solution{
  public static int missing(string s){
    
    //
    for (int i = 1; i <= Min(8, s.Length >> 1); i++){
      //reset after each loop
      var (n,t,m) = (int.Parse(s[..i]), s, -1);
      
      while (t.Length > 0){
        //check if t starts with n
        //if so, assign t.substring(up to n's length) to t
        if (t.StartsWith(n.ToString())) 
          t = t.Substring(n.ToString().Length);
        //set m to n if m is less than 0
        else if (m < 0) 
          m=n;
        //no missing number return -1 and break
        else{ 
          m=-1; 
          break; 
        }
        //incresed by 1 for next loop
        n++;
      }
      
      if (m>0) 
        return m;
    }
    return -1;
  }
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Collections.Generic;
 
[TestFixture]
public class SolutionTest
{
  [Test]
  public void ExampleTests()
  {
    
    Assert.AreEqual(4,Solution.missing("123567"));
    Assert.AreEqual(92,Solution.missing("899091939495"));
    Assert.AreEqual(100,Solution.missing("9899101102"));
    Assert.AreEqual(-1,Solution.missing("599600601602"));
    Assert.AreEqual(-1,Solution.missing("8990919395"));
    Assert.AreEqual(1002,Solution.missing("998999100010011003"));
    Assert.AreEqual(10000,Solution.missing("99991000110002"));
    Assert.AreEqual(-1,Solution.missing("979899100101102"));
    Assert.AreEqual(900003,Solution.missing("900001900002900004900005900006"));
  }

  private static int cvp(String s){
        int res = 0, limit = Math.Min(8,s.Length/2);
        for (int c = 1; c < limit; ++c) {
            int temp = 1;
            int m = Int32.Parse(s.Substring(0, c));
            int hold = c;
            while (hold < s.Length) {
                m++;
                String n = m.ToString();
                if (n != s.Substring(hold, n.Length)) {
                    res = m;
                    temp--;
                    if (temp < 0) break;
                }
                else hold += n.Length;
                }
            if (temp == 0 && hold == s.Length) return Convert.ToInt32(res);
        }
        return -1;
    }

  [Test]
  public void RandomTests(){
    Random random = new Random(); 
    
    for (int i = 0; i < 100; i++) {
            int len = random.Next(8,12);      
            List<int> arr1 = new List<int>();
            List<int> arr2 = new List<int>();
            int seq = random.Next(1,975000);
            arr1.Add(seq);  
            int edge = random.Next(2,5);
            int num = (int)Math.Pow(10, edge);
            int seq2 = num - len + 2;
            arr2.Add(seq2);
            for (int j = 0; j <= len; j++) {
              seq++;
              seq2++;
              arr1.Add(seq);
              arr2.Add(seq2);
            }   
            int trap = random.Next(0,20);
            String test1 = "", test2 = "";
            int exp1, exp2;
            if (trap > 7) {
                arr1.RemoveAt(random.Next(1,arr1.Count-1));
                arr2.RemoveAt(random.Next(1,arr2.Count-1));                
                  
                int checker = random.Next(0,20);
                 if (checker < 5) {
                   if (arr1[1] % 2 == 0)
                        arr1.RemoveAt(random.Next(1,arr1.Count-1));
                    else
                        arr2.RemoveAt(random.Next(1,arr2.Count-1));
                  }
                
                  foreach (int e in arr1)
                    test1 += e.ToString();           
                  foreach (int e in arr2)
                    test2 += e.ToString();
             
                  exp1 = cvp(test1);
                  exp2 = cvp(test2);
                  Assert.AreEqual(exp1, Solution.missing(test1));  
                  Assert.AreEqual(exp2, Solution.missing(test2));
                 
              
            } else {
                foreach (int e in arr1)
                  test1 += e.ToString();
          
                foreach (int e in arr2)
                  test2 += e.ToString();
                
                  exp1 = cvp(test1);
                  exp2 = cvp(test2);
                  Assert.AreEqual(exp1, Solution.missing(test1));  
                  Assert.AreEqual(exp2, Solution.missing(test2));  
              
            }   
        
        }
  }
}
