/*Challenge link:https://www.codewars.com/kata/5641b3f737b248b8840000b0/train/csharp
Question:
you have a string in the following format:

"654968    - 987  + 564+         9-6549836126"
It contains some integers with plus or minus operator between. There are plenty of white spaces in between. your task is to trim the string input, and calculate the result and return it as an integer.


*/

//***************Solution********************

//create new datatable and compute the string, with null filter.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//ref: https://learn.microsoft.com/en-us/dotnet/api/system.data.datatable.compute?view=net-8.0
//public object Compute (string? expression, string? filter);

using System.Data;
namespace SolveIt {
  public class Kata{
        public static int result(string s) => (int)new DataTable().Compute(s, null);
    }
}

//solution 2
using System.Linq;
using System.Text.RegularExpressions;

namespace SolveIt
{
  public class Kata
  {
    public static int result(string stringInput)
    {
      return Regex.Split(stringInput.Replace(" ", ""), "(?=[+-])").Sum(int.Parse);
    }
  }
}

//solution 3
namespace SolveIt {
using System;
using System.Linq;
using System.Text.RegularExpressions;
  public class Kata
    {
        public static int result(string s)
        {
          return Regex.Matches(s.Replace(" ",""),"[-]?[0-9]+").OfType<Match>().Select(x=>int.Parse(x.Value)).Sum();
        }
    }
}

//solution 4
namespace SolveIt {
using System;

  public class Kata
    {
        public static int result(string stringInput)
        {
            stringInput = stringInput.Replace(" ", "");

            var sum = 0;
            var buffer = "";
            foreach (var c in stringInput)
            {
                if (c is '+' or '-')
                {
                    sum += int.Parse(buffer);
                    buffer = "";
                }

                buffer += c;
            }          
            sum += int.Parse(buffer);

            return sum;
        }
    }
}
//****************Sample Test*****************
namespace SolveIt {
  using NUnit.Framework;
  using System;
  [TestFixture]
  public class Test
  {
    [Test]
    public void PlusTest()
    {
        Assert.AreEqual(957737, Kata.result("854+584   + 956201   +98+0"), string.Format("Expect {0}, but it was {1}", 957737, Kata.result("854+584   + 956201   +98+0")));
    }

    [Test]
    public void MinusTest()
    {
        Assert.AreEqual(-956029, Kata.result("854-584   - 956201   -98-0"), string.Format("Expect {0}, but it was {1}", -956029, Kata.result("854-584   - 956201   -98-0")));
    }

    [Test]
    public void PlusMinusTest()
    {
        Assert.AreEqual(-954665, Kata.result("854+584   - 956201   +98-0"), string.Format("Expect {0}, but it was {1}", -954665, Kata.result("854+584   - 956201   +98-0")));
    }

    [Test]
    public void RandomTest([Values(1)] int x, [Random(-1, 1, 30)] double d)
    {
        string MyString = RandomGenerator.StringGenerator();
        Assert.AreEqual(KataTest.resultTest(MyString), Kata.result(MyString), string.Format("The input was '{0}', the result expects {1}, but it was {2}", MyString,KataTest.resultTest(MyString),Kata.result(MyString)));
    }
  }
}
