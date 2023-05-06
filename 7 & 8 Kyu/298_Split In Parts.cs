/*Challenge link:https://www.codewars.com/kata/5650ab06d11d675371000003/train/csharp
Question:
The aim of this kata is to split a given string into different strings of equal size (note size of strings is passed to the method)

Example:

Split the below string into other strings of size #3

'supercalifragilisticexpialidocious'

Will return a new string
'sup erc ali fra gil ist ice xpi ali doc iou s'
Assumptions:

String length is always greater than 0
String has no spaces
Size is always positive
*/

//***************Solution********************
//in order to split the string by partLength, we need to know if the length of s is divisible by partLength
//by using Math.Ceiling to round up the value
//by using s.Length - (s.Length % partLength) to find out if there is any reminder (overflow)
//if there is no overflow, split the substring from index (i*partLength) by size (partLength)
//else split substring from index (i*partLength) by size (reminder)
//join the string together and returnt the result
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;

public class Kata{
  public static string SplitInParts(string s, int partLength) =>
    string.Join(" ",Enumerable.Range(0, (int)Math.Ceiling((double)s.Length / (double)partLength))
          .Select(i => i* partLength < s.Length - (s.Length %partLength) ? 
           s.Substring(i * partLength, partLength) :
           s.Substring(i * partLength, (s.Length %partLength))));
}  

//better solution
using System.Linq;

public class Kata{
    public static string SplitInParts(string s, int partLength)=>
      string.Join(" ",s.Chunk(partLength).Select(c => string.Concat(c)));
}

//clever solution
public class Kata
{
    public static string SplitInParts(string s, int partLength)
    {  
        for(int i = partLength; i < s.Length; i += partLength + 1)
            s = s.Insert(i, " ");
        return s;    
    }
}  


//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Collections.Generic;

[TestFixture]
public class SplitIt
{   

    [TestCase]
    //Fixed values
    public void splitString0()  
    {
       string str = "supercalifragilisticexpialidocious";       
       Assert.AreEqual(SplitInParts(str,3), Kata.SplitInParts(str,3));
    }   
   
    [Test]
    public static void RandomTest([Random(1,5,20)]int x)
    {
      string testStr = string.Empty;
      for(int i = 0; i < x; i++)
      {
        testStr += " " + GetRandomString();
      }
      testStr = testStr.Trim();      
      Random r = new Random();
      int rInt = r.Next(1, 6);      
      Assert.AreEqual(SplitInParts(testStr,rInt), Kata.SplitInParts(testStr,rInt), string.Format("Should work for \"{0}\"", testStr));
    }
    
    
    private static string GetRandomString()
    {
      Random r = new Random();
      int length = r.Next(9)+1;
      string alpha = "abcdefghijklmnopqrstuvwxyz";
      string result = string.Empty;
      for(int i = 0; i < length; i++)
      {
        result += alpha[r.Next(26)];
      }
      return result;
    }    

    private static string SplitInParts(string s, int partLength) {        
       var lst = new List<string>();   
        for (var i = 0; i < s.Length; i += partLength)
          lst.Add(s.Substring(i, Math.Min(partLength, s.Length - i)));      
          string newString = string.Join(" ", lst);      
          return newString;         
      }

}
