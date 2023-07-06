/*Challenge link:https://www.codewars.com/kata/53d16bd82578b1fb5b00128c/train/csharp
Question:
Create a function that takes a number as an argument and returns a grade based on that number.

Score	Grade
Anything greater than 1 or less than 0.6	"F"
0.9 or greater	"A"
0.8 or greater	"B"
0.7 or greater	"C"
0.6 or greater	"D"
Examples:

grader(0)   should be "F"
grader(1.1) should be "F"
grader(0.9) should be "A"
grader(0.8) should be "B"
grader(0.7) should be "C"
grader(0.6) should be "D"
*/

//***************Solution********************
//check for condition and return result accordingly
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Kata
{
  public static char Grader(double s)
  {
    return s > 1 || s < 0 ? 'F' : s >= 0.9 ? 'A' : s >= 0.8 ? 'B' : s >= 0.7 ? 'C' : s >= 0.6 ? 'D' : 'F' ;
  }
}

//****************Sample Test*****************
namespace Solution
{
  using NUnit.Framework;
  
  [TestFixture]
  public class Tests
  {
    [Test]
    [TestCase(1, ExpectedResult='A')]
    [TestCase(1.01, ExpectedResult='F')]
    [TestCase(0.2, ExpectedResult='F')]
    [TestCase(0.7, ExpectedResult='C')]
    [TestCase(0.8, ExpectedResult='B')]
    [TestCase(0.9, ExpectedResult='A')]
    [TestCase(0.6, ExpectedResult='D')]
    [TestCase(0.5, ExpectedResult='F')]
    [TestCase(0, ExpectedResult='F')]
    public static char FixedTest(double score)
    {
      return Kata.Grader(score);
    }
    
    [Test]
    public static void RandomTest([Random(0,150,100)] double score)
    {
      score /= 100;
      Assert.AreEqual(Solution(score), Kata.Grader(score), string.Format("Should work for {0}", score)); 
    }
    
    private static char Solution(double score)
    {
      if(score < 0.6) return 'F';
      if(score < 0.7) return 'D';
      if(score < 0.8) return 'C';
      if(score < 0.9) return 'B';
      if(score <= 1 ) return 'A';
      return 'F';
    }
  }
}
