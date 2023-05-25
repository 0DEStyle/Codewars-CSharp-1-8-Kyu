/*Challenge link:https://www.codewars.com/kata/52829c5fe08baf7edc00122b/train/csharp
Question:
Write a function that returns the number of occurrences of an element in an array.

Examples
var sample = { 1, 0, 2, 2, 3 };
NumberOfOccurrences(0, sample) == 1;
NumberOfOccurrences(4, sample) == 0;
NumberOfOccurrences(2, sample) == 2;
NumberOfOccurrences(3, sample) == 1;
*/

//***************Solution********************
//count the number of x appeared in xs, using equals as bool value.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public class OccurrencesKata{
	public static int NumberOfOccurrences(int x, int[] xs) => xs.Count(x.Equals);
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Linq;

[TestFixture]
public class OccurrencesKataTests
{
	[Test]
  public void Should_Work_On_Empty_List()
  {
  	Assert.AreEqual(0, 
    	OccurrencesKata.NumberOfOccurrences(2, new int[0]));
  }
  
  [Test]
  public void Should_Work_On_Examples()
  {
  	var example = new int[] { 4, 0, 4 };
    
    Assert.AreEqual(2, 
    	OccurrencesKata.NumberOfOccurrences(4, example));
    
    Assert.AreEqual(0, 
    	OccurrencesKata.NumberOfOccurrences(1, example));
    
    Assert.AreEqual(1, 
    	OccurrencesKata.NumberOfOccurrences(0, example));
  }
  
	[Test]
	public void NumberOfOccurrencesOf_5()
	{
		int[] xs = { 1, 5, 5, 8, 7, 3, 4, 5 };
    int x = 5;
		int expected = 3;

		int actual = OccurrencesKata.NumberOfOccurrences(x, xs);

		Assert.AreEqual(expected, actual);
	}
  
	[Test]
	public void NumberOfOccurrencesOf_3()
	{
		int[] xs = { 1, 2, 3 };
    int x = 3;
		int expected = 1;

		int actual = OccurrencesKata.NumberOfOccurrences(x, xs);

		Assert.AreEqual(expected, actual);
	}
  
	[Test]
	public void NumberOfOccurrencesOf_10()
	{
		int[] xs = { 10, 10, 2, 3, 11 };
    int x = 10;
		int expected = 2;

		int actual = OccurrencesKata.NumberOfOccurrences(x, xs);

		Assert.AreEqual(expected, actual);
	}
  
  [Test]
  public void NumberOfOccurrencesOf_GeneratedRandomly()
  {
    var random = new Random(Guid.NewGuid().GetHashCode());
  	var xs = Enumerable.Range(1, 3000).Select(_ => random.Next()).ToArray();
    int x = random.Next();
    var expected = xs.Count(y => y == x);
    
    int actual = OccurrencesKata.NumberOfOccurrences(x, xs);
    
    Assert.AreEqual(expected, actual);
  }
}
