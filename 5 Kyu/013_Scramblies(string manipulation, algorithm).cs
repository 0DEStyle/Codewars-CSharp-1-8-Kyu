/*Challenge link:https://www.codewars.com/kata/55c04b4cc56a697bb0000048/train/csharp
Question:
Complete the function scramble(str1, str2) that returns true if a portion of str1 characters can be rearranged to match str2, otherwise returns false.

Notes:

Only lower case letters will be used (a-z). No punctuation or digits will be included.
Performance needs to be considered.
Examples
scramble('rkqodlw', 'world') ==> True
scramble('cedewaraaossoqqyt', 'codewars') ==> True
scramble('katas', 'steak') ==> False
*/

//***************Solution********************
//solution 1
//performance 18ms 1600ms
//check if length of str2 is longer than str1, if true, return false
//for each character appears in str1, if str2 contains that character, remove it from str2 by that index.
//loop until nothing is left.
//return true if the length of str2 is 0, else return false.

public class Scramblies {
    public static bool Scramble(string str1, string str2) {
      if (str1.Length < str2.Length)
        return false;
      
      foreach (char ch in str1.ToCharArray()){
         if (str2.Contains(ch.ToString())) 
           str2 = str2.Remove(str2.IndexOf(ch.ToString()), 1);
      }
     return str2.Length == 0;
    }
}

//solution 2
//performance 29.7ms 2985ms
//using Linq
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Linq;
public class Scramblies 
{
    
    public static bool Scramble(string str1, string str2) 
    {
       return str2.GroupBy(c => c).All(g => str1.Where(c => c == g.Key).Count() >= g.Count());
    }

}

//solution 3
//performance 20ms 1202ms
//this method check letters condition based on count
//if letter count in str1 is greater than str2 and str1 contrain the letter in str2, then continue
//else return false

using System.Linq;
public class Scramblies {
    public static bool Scramble(string str1, string str2){
        foreach (var letter in str2){
                var str2count = str2.Count(x => x == letter);
                var str1count = str1.Count(x => x == letter);
          
                if(str1.Contains(letter) && str2count <= str1count)
                    continue;
                else
                    return false;
            }
            return true;
    }  
}

//solution 4
//performance 26ms optimized solution 3 
//low time, by comparing letter count and checking distinct character, if only unquestr1 = 0 faster,that characters are not stuck at the end.
using System.Linq;
using System;
public class Scramblies {
    public static bool Scramble(string str1, string str2){
      string uniquestr1 = new String(str1.Distinct().ToArray());         //find all distinct character in str1
      
        foreach (var letter in str2){
          var str2count = str2.Count(x => x == letter);                  //count character appeared in string
          var str1count = str1.Count(x => x == letter);
          
          if(str1.Contains(letter) && str2count <= str1count){           //comparing character count of each string
            uniquestr1 = str1.Remove(str1.IndexOf(letter.ToString()), 1);//remove distinct character each time it appears
            if(uniquestr1.Length == 0)                                   //if there's no more distinct character, stop the loop
              return true;                                               //return true
            continue;                                                    //continue the loop
          }
          else                                                           //str2count is greater than str1count,or doesn't contain the letter
            return false;                                                //return false
        }
      return true;
    }  
}
//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public static class ScrambliesTests 
{

    private static Random rnd = new Random();
    private static void testing(bool actual, bool expected) 
    {
        Assert.AreEqual(expected, actual);
    }

[Test]
    public static void test1() 
    {
        testing(Scramblies.Scramble("rkqodlw","world"), true);
        testing(Scramblies.Scramble("cedewaraaossoqqyt","codewars"),true);
        testing(Scramblies.Scramble("katas","steak"),false);
        testing(Scramblies.Scramble("scriptjavx","javascript"),false);
        testing(Scramblies.Scramble("scriptingjava","javascript"),true);
        testing(Scramblies.Scramble("scriptsjava","javascripts"),true);
        testing(Scramblies.Scramble("javscripts","javascript"),false);
        testing(Scramblies.Scramble("aabbcamaomsccdd","commas"),true);
        testing(Scramblies.Scramble("commas","commas"),true);
        testing(Scramblies.Scramble("sammoc","commas"),true);
    }
    
    //-----------------------
    private static bool ScrambleSol(string str1, string str2) 
    {
        
        //if (str1.Length < str2.Length) return false;
        
        int[] alpha1 = new int[26];
        for(int i = 0 ; i < alpha1.Length ; i++) alpha1[i] = 0;
        int[] alpha2 = new int[26];
        for(int i = 0 ; i < alpha2.Length ; i++) alpha2[i] = 0;
        for(int i = 0; i < str1.Length; i++) 
        {
            int c = (int)str1[i];
            alpha1[c - 97]++;
        }
        for(int i = 0; i < str2.Length; i++) 
        {
            int c = (int)str2[i];
            alpha2[c - 97]++;
        }
        for(int i = 0; i < 26; i++) 
        {
            if(alpha1[i] < alpha2[i])
              return false;
        }
          return true;
    }    
    
    private static String DoEx(int l, int c) 
    {
        string res = ""; int n = -1;
        for (int i = 0; i < l; i++) 
        {
            do 
            {
                n = rnd.Next(97, 122);
            } while (n == c);
            res += (char)n;
        }
        return res;
    }
    //-----------------------
[Test]    
    public static void RandomTest1() 
    {
        Console.WriteLine("Basic Random Tests");
        for (int i = 0; i < 10; i++) 
        { 
            int n = rnd.Next(0, 1000);
            string s1 = DoEx(n, -1);
            int m = rnd.Next(0, 400);
            String s2 = DoEx(m, -1);
            bool r = ScrambleSol(s1, s2);
            //Console.WriteLine("s1 " + s1 + " s2 " + s2 + " --> " + r);
            //Console.WriteLine("****");
            testing(Scramblies.Scramble(s1,s2),r);
        }
    }  
[Test]    
    public static void RandomTest2() 
    {
        Console.WriteLine("Random Tests: performance 1");
        for (int i = 0; i < 2; i++) 
        {
            String s1 = "";
            int m = rnd.Next(0, 80000);
            String s2 = DoEx(m, -1);
            int n = rnd.Next(1, 2);
            if (n % 2 == 0) {
                s1 = s2 + s2;
            } else {
                s1 = s2;
                s2 = s1 + "abmosr";
            }
            bool r = ScrambleSol(s1, s2);
            //Console.WriteLine("s1 " + s1 + " s2 " + s2 + " --> " + r);
            //Console.WriteLine("****");
            testing(Scramblies.Scramble(s1,s2),r);
        }       
    }
[Test]    
    public static void RandomTest3() 
    {
        Console.WriteLine("Random Tests: performance 2");
        for (int i = 0; i < 1; i++) 
        {
            int n = rnd.Next(0, 80000);
            String s1 = DoEx(n, 97);
            int m = rnd.Next(0, 100);
            String s2 = DoEx(m, 120);
            bool r = ScrambleSol(s1, s2);
            //Console.WriteLine("s1 " + s1 + " s2 " + s2 + " --> " + r);
            //Console.WriteLine("****");
            testing(Scramblies.Scramble(s1,s2),r);
        }    
    }
}
