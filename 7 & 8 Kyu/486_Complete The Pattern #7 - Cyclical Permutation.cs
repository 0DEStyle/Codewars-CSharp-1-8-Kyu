/*Challenge link:https://www.codewars.com/kata/557592fcdfc2220bed000042/train/csharp
Question:
Task:
You have to write a function pattern which creates the following pattern (See Examples) upto desired number of rows.

If the Argument is 0 or a Negative Integer then it should return "" i.e. empty string.

Examples:
pattern(9):

123456789
234567891
345678912
456789123
567891234
678912345
789123456
891234567
912345678
pattern(5):

12345
23451
34512
45123
51234
Note: There are no spaces in the pattern

Hint: Use \n in string to jump to next line
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//start from 1, count up to n
//x and y are current elements, i is index.
//start from x, count up to i
//if y is less than n, return y - n, else return y
//join elements together, then join each string with "\n"
using System.Linq;

public class CyclicalPermutation{
  public static string Pattern(int n) => 
    n < 1 ? "" : 
  string.Join("\n", 
  Enumerable.Range(1, n)
	          .Select(x => string.Concat(Enumerable.Range(x,n)
                                                 .Select(y => y>n ? y-n : y))));
}


//****************Sample Test*****************
namespace Solution
{
  using NUnit.Framework;
  using System;
  using System.Linq;
  
  [TestFixture]
  public class CyclicalPermutationTests
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual("1234567\n2345671\n3456712\n4567123\n5671234\n6712345\n7123456", CyclicalPermutation.Pattern(7));
      Assert.AreEqual("1", CyclicalPermutation.Pattern(1));
      Assert.AreEqual("1234\n2341\n3412\n4123", CyclicalPermutation.Pattern(4));
      Assert.AreEqual("", CyclicalPermutation.Pattern(0));
      Assert.AreEqual("", CyclicalPermutation.Pattern(-25));
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
    
        var output = "";
        for(var i = 1; i <= n; i++)
        {        
          output += string.Concat(Enumerable.Range(0, n).Select((a,b) => ((i + b - 1) % n) + 1));
      
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
        
        Assert.AreEqual(myPattern(n), CyclicalPermutation.Pattern(n));
      }
    }
  }
}
