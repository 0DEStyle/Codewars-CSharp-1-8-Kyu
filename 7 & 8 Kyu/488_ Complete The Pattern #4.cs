/*Challenge link:https://www.codewars.com/kata/55736129f78b30311300010f/train/csharp
Question:
Task:
You have to write a function pattern which creates the following pattern upto n number of rows. If the Argument is 0 or a Negative Integer then it should return "" i.e. empty string.

Examples:
pattern(4):

1234
234
34
4
pattern(6):

123456
23456
3456
456
56
6
Note: There are no blank spaces

Hint: Use \n in string to jump to next line
*/

//***************Solution********************
using System;
using System.Linq;
using System.Collections.Generic;

public class Pattern4{
  public static string Pattern(int n){
    //return nothing is n is less than or equal to 0
    if (n <= 0) return "";
    
    //generate an array of numbers from 1 count up to n
    var numStr = Enumerable.Range(1,n);
    //x is current element
    //start from 0, count up to n, 
    //from numStr, skip index x, concat the number elements
    //then join the string elements with "\n" and return the result.
    return string.Join("\n", Enumerable.Range(0,n)
                                       .Select(x => string.Concat(numStr.Skip(x))));
    
  }

  //solution 2
  using System.Linq;

public class Pattern4
{
  public static string Pattern(int n)
  {
    return string.Join("\n", Enumerable.Range(0, n < 1 ? 0 : n).Select(i => string.Concat(Enumerable.Range(1, n).Skip(i))));
  }
}

  //solution 3
  public class Pattern4
{
  public static string Pattern(int n)
  {
    string prev = "";
    string pattn = "";
    
    for(int i=n;i>0;i--)
    {
        pattn = "\n" + i + prev + pattn;
        prev = i + prev;
    }
    pattn = n > 0 ? pattn.Substring(1) : pattn;
    return pattn;
  }
}
  //solution 4
  public class Pattern4
{
  public static string Pattern(int n)
  {
    string output = "";
    
    for(int i = 0; i < n; i++)
      {
        if(i != 0) {output += "\n";}
        
        for(int j = i+1; j <= n; j++) {output += j;}
      }
    
    return output;
  }
}

//****************Sample Test*****************
  namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class Pattern4Tests
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual("1", Pattern4.Pattern(1));
      Assert.AreEqual("12\n2", Pattern4.Pattern(2));
      Assert.AreEqual("12345\n2345\n345\n45\n5", Pattern4.Pattern(5));
      Assert.AreEqual("", Pattern4.Pattern(0));
      Assert.AreEqual("", Pattern4.Pattern(-25));
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      
      Func<int,string> myPattern = delegate (int n)
      {
        if(n < 1)
        {
          return "";
        }
    
        var output="";
        for(var i = 1; i <= n; i++)
        {
          output += string.Concat(Enumerable.Range(0, n - i + 1).Select((a,b) => (b + i)));
      
          if(i != n)
          {
            output += '\n';
          }
        }
        return output;
      };
      
      for(int i = 0; i < 20; i++)
      {
        var n = rand.Next(-2, 100);
        
        Console.WriteLine("Random test for " + n);
        
        Assert.AreEqual(myPattern(n), Pattern4.Pattern(n));
      }      
    }
  }
}
