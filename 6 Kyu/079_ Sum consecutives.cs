/*Challenge link:https://www.codewars.com/kata/55eeddff3f64c954c2000059/train/csharp
Question:
You are given a list/array which contains only integers (positive and negative). Your job is to sum only the numbers that are the same and consecutive. The result should be one list.

Extra credit if you solve it in one line. You can assume there is never an empty list/array and there will always be an integer.

Same meaning: 1 == 1

1 != -1

#Examples:

[1,4,4,4,0,4,3,3,1] # should return [1,12,0,4,6,1]

"""So as you can see sum of consecutives 1 is 1 
sum of 3 consecutives 4 is 12 
sum of 0... and sum of 2 
consecutives 3 is 6 ..."""

[1,1,7,7,3] # should return [2,14,3]
[-5,-5,7,7,12,0] # should return [-10,14,12,0]

*/

//***************Solution********************

//from list s, v current elemenet, i index
//check if i is less than 0 and s[index - 1] is equal to current element
//if so return nullable int
//else skip current index, 
//take while current element that is equal to v, then sum the result.
//get all element that has value, select those value and conver to list
//return the result
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Collections.Generic;
using System.Linq;

public class Consecutives{
	public static List<int> SumConsecutives(List<int> s) =>
    	 s.Select((v, i) => (i > 0 && s[i - 1] == v) ? 
                          (int?)null : s.Skip(i)
                                        .TakeWhile(vi => vi == v).Sum())
                                        .Where(r => r.HasValue)
                                        .Select(r => r.Value).ToList();
}

//****************Sample Test*****************
using System;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public static class ConsecutivesTests {

[Test]
    public static void test1() {
        List<int> i = new List<int> {1,4,4,4,0,4,3,3,1};
        List<int> o = new List<int> {1,12,0,4,6,1};
        Console.WriteLine("Input: {1,4,4,4,0,4,3,3,1}");
        Assert.AreEqual(o, Consecutives.SumConsecutives(i));
        i = new List<int> {-5,-5,7,7,12,0};
        o = new List<int> {-10,14,12,0};
        Console.WriteLine("Input: {-5,-5,7,7,12,0}");
        Assert.AreEqual(o, Consecutives.SumConsecutives(i));
        i = new List<int> {1,1,7,7,3};
        o = new List<int> {2,14,3};
        Console.WriteLine("Input: {1,1,7,7,3}");
        Assert.AreEqual(o, Consecutives.SumConsecutives(i));
        i = new List<int> {3,3,3,3,1};
        o = new List<int> {12, 1};
        Console.WriteLine("Input: {3,3,3,3,1}");
        Assert.AreEqual(o, Consecutives.SumConsecutives(i));
        i = new List<int> {2,2,-4,4,5,5,6,6,6,6,6,1};
        o = new List<int> {4, -4, 4, 10, 30, 1};
        Console.WriteLine("Input: {2,2,-4,4,5,5,6,6,6,6,6,1}");
        Assert.AreEqual(o, Consecutives.SumConsecutives(i));
        i = new List<int> {1,1,1,1,1,3};
        o = new List<int> {5, 3};
        Console.WriteLine("Input: {1,1,1,1,1,3}");
        Assert.AreEqual(o, Consecutives.SumConsecutives(i));
        i = new List<int> {1,-1,-2,2,3,-3,4,-4};
        o = new List<int> {1, -1, -2, 2, 3, -3, 4, -4};
        Console.WriteLine("Input: {1,-1,-2,2,3,-3,4,-4}");
        Assert.AreEqual(o, Consecutives.SumConsecutives(i));
    }
}
