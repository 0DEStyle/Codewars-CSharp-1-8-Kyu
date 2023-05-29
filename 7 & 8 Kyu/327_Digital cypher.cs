/*Challenge link:https://www.codewars.com/kata/592e830e043b99888600002d/train/csharp
Question:
Introduction
Digital Cypher assigns to each letter of the alphabet unique number. For example:

 a  b  c  d  e  f  g  h  i  j  k  l  m
 1  2  3  4  5  6  7  8  9 10 11 12 13
 n  o  p  q  r  s  t  u  v  w  x  y  z
14 15 16 17 18 19 20 21 22 23 24 25 26
Instead of letters in encrypted word we write the corresponding number, eg. The word scout:

 s  c  o  u  t
19  3 15 21 20
Then we add to each obtained digit consecutive digits from the key. For example. In case of key equal to 1939 :

   s  c  o  u  t
  19  3 15 21 20
 + 1  9  3  9  1
 ---------------
  20 12 18 30 21
  
   m  a  s  t  e  r  p  i  e  c  e
  13  1 19 20  5 18 16  9  5  3  5
+  1  9  3  9  1  9  3  9  1  9  3
  --------------------------------
  14 10 22 29  6 27 19 18  6  12 8
Task
Write a function that accepts str string and key number and returns an array of integers representing encoded str.

Input / Output
The str input string consists of lowercase characters only.
The key input number is a positive integer.

Example
Encode("scout",1939);  ==>  [ 20, 12, 18, 30, 21]
Encode("masterpiece",1939);  ==>  [ 14, 10, 22, 29, 6, 27, 19, 18, 6, 12, 8]
*/

//***************Solution********************
//from string str, loop through each character
//offset the character by 96 (96 is `, just before 'a' in ASCII)
//by using i mod the length of n, you can iterate through the number in order
//then select n[whatever the current order is]
//offset the character by 48 (which is the same as '0')

//now add the first character offset and the second encrypted offset chacter together
//store in array and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public  class Kata{
    public static int[] Encode(string str, int n) =>  str.Select((c,i) => c - 96 + ($"{n}"[i % $"{n}".Length] - '0')).ToArray();
}

//****************Sample Test*****************
 namespace Learning {
  using NUnit.Framework;
  using NUnit.Framework.Internal;
  using System.Linq;
  using System;
  
  [TestFixture]
  public class CypherTest
  {
    [Test]
    public void BasicTest()
    {
       Assert.AreEqual(new int[] {20, 12, 18, 30, 21}, Kata.Encode("scout", 1939));
       Assert.AreEqual(new int[] {14, 10, 22, 29, 6, 27, 19, 18, 6, 12, 8}, Kata.Encode("masterpiece", 1939));      
    }
 
    [Test]
    public void RandomTest()
    {
       Random random = new Random();
       for (int i = 0; i < 200; i++)
       {
          string str = GetRandomString(i + 2);
          int n = random.Next(1, int.MaxValue); 
          Console.WriteLine($"\nMessage to encode: {str} with key: {n} \nExpected result: [{string.Join(", ",e(str, n).Select(x=>""+x))}]");
          Assert.AreEqual(e(str, n), Kata.Encode(str,n)); 
       }
    } 
    
    private static Randomizer rand = TestContext.CurrentContext.Random;
    private static string GetRandomString(int length) =>
      rand.GetString(length, "abcdefghijkmnopqrstuvwxyz");
    
     private int[] e(string str, int n)
     {
        string code = string.Concat(n.ToString());
        return str.Select((e, i)  => e - 'a' + 1 + (int)Char.GetNumericValue(code[i % code.Length])
             ).ToArray();
     }
    
   }
 }
