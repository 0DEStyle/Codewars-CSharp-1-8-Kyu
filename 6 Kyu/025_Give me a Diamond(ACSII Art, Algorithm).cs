/*Challenge link:https://www.codewars.com/kata/5503013e34137eeeaa001648/train/csharp
Question:
Jamie is a programmer, and James' girlfriend. She likes diamonds, and wants a diamond string from James. Since James doesn't know how to make this happen, he needs your help.

Task
You need to return a string that looks like a diamond shape when printed on the screen, using asterisk (*) characters. Trailing spaces should be removed, and every line must be terminated with a newline character (\n).

Return null/nil/None/... if the input is an even number or negative, as it is not possible to print a diamond of even or negative size.

Examples
A size 3 diamond:

 *
***
 *
...which would appear as a string of " *\n***\n *\n"

A size 5 diamond:

  *
 ***
*****
 ***
  *
...that is:

"  *\n ***\n*****\n ***\n  *\n"
*/

//***************Solution********************

//solution 1
using System;

public class Diamond
{
	public static string print(int n){
    
    string str = "";
    int space = n/2;
    if (n%2 == 0 || n < 0) return null; // check event and negative
    
    for (int i = 0; i <= n / 2; i++) {  //upper pyramid
        for (int j = 0; j < space; j++)//space
          str += " ";
        for (int j = 0; j <= i; j++) {  //star
          if(j==0) str += "*";
          if(j != 0) str += "**";
        }
      str += "\n";
      space--;
    }

    int botSpace = n / 2 - 1; // bottom pyramid start at n - 1
      for (int i = 0; i <= n / 2 - 1; i++) {  //bottom pyramid
        for (int j = 0; j <= i; j++) //space
          str += " ";
        for (int j = 0; j <= botSpace; j++){ //star
          if(j== 0) str += "*";
          if (j != botSpace) str += "**";
        }
        str += "\n";
        botSpace--;
      }

    return str;
	}
}

//solution 2
//recursion
//if n is 1, return str
//else return str + recursion(replace "\n" with "**\n") + str
public class Diamond
{
  public static string print(int n)
  {
    if(n <= 0 || n % 2 == 0) return null;
    var str = new string(' ', (n - 1) / 2) + "*\n";
    return n == 1 ? str : str + Diamond.print(n - 2).Replace("\n", "**\n") + str;
  }
}

//****************Sample Test*****************
using System;
using System.Text;
using NUnit.Framework;

[TestFixture]
public class DiamondTest
{
  private readonly Random random = new Random();

  [Test]
  public void TestZero()
  {
    Assert.IsNull(Diamond.print(0));
  }

  [Test]
  public void TestNegativeInput()
  {
    for (int i = 0; i < 10; i++)
    {
      int n = -random.Next(20);
      Assert.IsNull(Diamond.print(n));
    }
  }

  [Test]
  public void TestEvenInput()
  {
    for (int i = 0; i < 10; i++)
    {
      int n = random.Next(20) * 2;
      Assert.IsNull(Diamond.print(n));
    }
  }

  [Test]
  public void TestDiamond3()
  {
    var expected = new StringBuilder();
    expected.Append(" *\n");
    expected.Append("***\n");
    expected.Append(" *\n");

    Assert.AreEqual(expected.ToString(), Diamond.print(3));
  }

  [Test]
  public void TestDiamond5()
  {
    var expected = new StringBuilder();
    expected.Append("  *\n");
    expected.Append(" ***\n");
    expected.Append("*****\n");
    expected.Append(" ***\n");
    expected.Append("  *\n");

    Assert.AreEqual(expected.ToString(), Diamond.print(5));
  }

  [Test]
  public void TestDiamond15()
  {
    var expected = new StringBuilder();
    expected.Append("       *\n");
    expected.Append("      ***\n");
    expected.Append("     *****\n");
    expected.Append("    *******\n");
    expected.Append("   *********\n");
    expected.Append("  ***********\n");
    expected.Append(" *************\n");
    expected.Append("***************\n");
    expected.Append(" *************\n");
    expected.Append("  ***********\n");
    expected.Append("   *********\n");
    expected.Append("    *******\n");
    expected.Append("     *****\n");
    expected.Append("      ***\n");
    expected.Append("       *\n");

    Assert.AreEqual(expected.ToString(), Diamond.print(15));
  }
}
