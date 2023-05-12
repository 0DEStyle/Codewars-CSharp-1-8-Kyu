/*Challenge link:https://www.codewars.com/kata/51c89385ee245d7ddf000001/train/csharp
Question:
Complete the solution so that it returns a formatted string. The return value should equal "Value is VALUE" where value is a 5 digit padded number.

Example:

solution(5); // should return "Value is 00005"
*/

//***************Solution********************
//string interpolation to format the string
//convert value to string, and use PadLeft to format '0' to 5 characters length.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class PaddedNumbers{
  public static string Solution(int value) => $"Value is {value.ToString().PadLeft(5, '0')}";
}

//solution 2
public class PaddedNumbers
{
  public static string Solution(int value)
  {
    return $"Value is {value:D5}";
  }
}

//solution 3
public class PaddedNumbers
{
  public static string Solution(int value)
  {
    return string.Format("Value is {0:00000}", value);
  }
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;  

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void BasicTest()
    {
      Assert.AreEqual("Value is 00005", PaddedNumbers.Solution(5));
      Assert.AreEqual("Value is 01204", PaddedNumbers.Solution(1204));
      Assert.AreEqual("Value is 00109", PaddedNumbers.Solution(109));
      Assert.AreEqual("Value is 00000", PaddedNumbers.Solution(0));
    }
    
    [Test]
    public void RandomTest()
    {
      var rand = new Random();
      
      for(int i=0;i<10;i++)
      {
        Assert.AreEqual("Value is " + i.ToString().PadLeft(5, '0'), PaddedNumbers.Solution(i));
      }
    }
  }
}
