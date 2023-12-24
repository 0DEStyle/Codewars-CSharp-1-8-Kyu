/*Challenge link:https://www.codewars.com/kata/5572f7c346eb58ae9c000047/train/csharp
Question:
Task:
You have to write a function pattern which returns the following Pattern(See Pattern & Examples) upto n number of rows.

Note:Returning the pattern is not the same as Printing the pattern.
Rules/Note:
If n < 1 then it should return "" i.e. empty string.
There are no whitespaces in the pattern.
Pattern:
1
22
333
....
.....
nnnnnn
Examples:
pattern(5):

1
22
333
4444
55555
pattern(11):

1
22
333
4444
55555
666666
7777777
88888888
999999999
10101010101010101010
1111111111111111111111
Hint: Use \n in string to jump to next line
List of all my katas
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//if n is less than 1 return nothing
//else, generate number start from 1, count up to n,
//x is the current element, repeat x by x times, concat the result
//then join the string elements together with "\n" and return the result.
using System.Linq;

public class Kata{
  public string Pattern(int n) => 
    n < 1 ? "" : 
    string.Join("\n",Enumerable.Range(1, n)
          .Select(x => string.Concat(Enumerable.Repeat(x, x))));
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class Tests {
  Kata k = new Kata();
  [Test]
  public void SimpleNumbers() {
    Assert.AreEqual("1", k.Pattern(1));
    Assert.AreEqual("1\n22", k.Pattern(2));
    Assert.AreEqual("1\n22\n333\n4444\n55555", k.Pattern(5));
  }
  
  [Test]
  public void ZeroAndNegativeNumbers(){
    Assert.AreEqual("", k.Pattern(0));
    Assert.AreEqual("", k.Pattern(-25));
    Assert.AreEqual("", k.Pattern(-99));
  }
 
  
  [Test]
  public void RandomGeneratedNumbers(){
    Random r = new Random();
    for(var i = 0; i < 20; i++) {
      var n = r.Next(100);
      Assert.AreEqual(SPattern(n), k.Pattern(n));
    }
  }
  
   
  public string SPattern(int n)
        {
            var output = "";
            for (var i = 1; i <= n; i++)
            {
                for (var a = 0; a < i; a++)
                {
                    output += i;
                }
                output += "\n";
            }
            return output.TrimEnd('\n');
        }
}
