/*Challenge link:https://www.codewars.com/kata/53d6387b83db278202000802/train/csharp
Question:
You have an array of numbers 1 through n (where 1 <= n <= 10). The array needs to be formatted correctly for the person reading the countdown of a spaceship launch.

Unfortunately, the person reading the countdown only knows how to read strings. After the array is sorted correctly make sure it's in a format he can understand.

Between each number should be a space and after the final number (n) should be the word 'liftoff!'

Example:

Kata.Liftoff(new List<int> {2, 8, 10, 9, 1, 3, 4, 7, 6, 5}) => "10 9 8 7 6 5 4 3 2 1 liftoff!"
*/

//***************Solution********************

//order by descending, then join the string by space,
//then using string interpolation to join the string with " lifeoff!"
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Linq;
using System.Collections.Generic;

public static class Kata{
  public static string Liftoff(List<int> instructions) =>
    $"{string.Join(" ", instructions.OrderByDescending(x => x))} liftoff!";
}

//solution 2
using System.Collections.Generic;
using System.Linq;

public class Kata
{
  public static string Liftoff(List<int> instructions)
  {
    return $"{string.Join(" ", instructions.OrderBy(x => -x))} liftoff!";
  }
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;

  public static class Solution
  {
    public static string Liftoff(List<int> instructions) =>
    	$"{String.Join(" ", instructions.OrderByDescending(num => num))} liftoff!";
  }

  [TestFixture]
  public class SampleTest
  {
  	private static IEnumerable<TestCaseData> testCases
  	{
  		get
  		{
  			yield return new TestCaseData(new List<int> {2, 8, 10, 9, 1, 3, 4, 7, 6, 5}).Returns("10 9 8 7 6 5 4 3 2 1 liftoff!");
  		}
  	}

    [Test, TestCaseSource("testCases")]
    public string Test(List<int> instructions) =>
    	Kata.Liftoff(instructions);
  }

  [TestFixture]
  public class RandomTest
  {
  	private static IEnumerable<TestCaseData> testCases
  	{
  		get
  		{
  			const int Tests = 100;
  			Random rnd = new Random();

  			for (int i = 0; i < Tests; ++i)
  			{
  				List<int> arr = Enumerable.Range(1, rnd.Next(1, 10 + 1)).OrderBy(_ => rnd.Next()).ToList();

  				string expected = Solution.Liftoff(arr);

  				yield return new TestCaseData(arr).Returns(expected);
  			}
  		}
  	}

    [Test, TestCaseSource("testCases")]
    public string Test(List<int> instructions) =>
    	Kata.Liftoff(instructions);
  }
}
