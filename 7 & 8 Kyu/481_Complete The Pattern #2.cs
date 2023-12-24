/*Challenge link:https://www.codewars.com/kata/55733d3ef7c43f8b0700007c/train/csharp
Question:
Task:
You have to write a function pattern which returns the following Pattern (See Pattern & Examples) upto n number of rows.

Note: Returning the pattern is not the same as Printing the pattern.
Rules/Note:
If n < 1 then it should return "" i.e. empty string.
There are no whitespaces in the pattern.
Pattern:
(n)(n-1)(n-2)...4321
(n)(n-1)(n-2)...432
(n)(n-1)(n-2)...43
(n)(n-1)(n-2)...4
...............
..............
(n)(n-1)(n-2)
(n)(n-1)
(n)
Examples:
pattern(4):

4321
432
43
4
pattern(11):

1110987654321
111098765432
11109876543
1110987654
111098765
11109876
1110987
111098
11109
1110
11
Hint: Use \n in string to jump to next line
*/

//***************Solution********************
using System;

public class Kata{
   public string Pattern(int n){
     string res = "", pattern = "";
     for(int i = n; i > 0; i--){
       //generate pattern
       pattern += i;
       //Console.WriteLine("str: " + str);
       //if i equal to n (last row), don't add "\n", else add "\n"
       res = i == n ? res + pattern : pattern + "\n" + res ;
    }
     return res;
   }
}

//solution 2
using System;
using System.Linq;

public class Kata
{
   public string Pattern(int n)
   {
     if (n <= 0) return string.Empty;

     return string.Join("\n", Enumerable
       .Range(1, n)
       .Select(x =>
         string.Concat(Enumerable
           .Range(x, n - x + 1)
           .Reverse()
           .Select(y => y.ToString()))));
   }
}

//solution 3
using System;
using static System.Linq.Enumerable;

public class Kata
{
  public string Pattern(int n)
  {
    return string.Join("\n", Range(0, Math.Max(0, n)).Select(x => string.Concat(Range(0, n - x).Select(i => n - i))));
  }
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class Tests {
	Kata k = new Kata();
  [Test]
  public void SimpleNumbers(){
	  Assert.AreEqual("1", k.Pattern(1));
    Assert.AreEqual("21\n2", k.Pattern(2));
    Assert.AreEqual("54321\n5432\n543\n54\n5", k.Pattern(5));
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
            for (var i = 0; i < n; i++)
            {
                for (var a = n; a > i; a--)
                {
                    output += a;
                }
                output += "\n";
            }
            return output.TrimEnd('\n');
        }
}
