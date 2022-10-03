/*Challenge link:https://www.codewars.com/kata/576bb71bbbcf0951d5000044/train/csharp
Question:
Given an array of integers.

Return an array, where the first element is the count of positives numbers and the second element is sum of negative numbers. 0 is neither positive nor negative.

If the input is an empty array or is null, return an empty array.

Example
For input [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, -11, -12, -13, -14, -15], you should return [10, -65].
*/

//***************Solution********************

//Solution 1
//if array is 0 or empty
//create an empty array and return the result

//if element in array is positive, sum the positive number, store at index 0
//if element in array is negative, count the negative number, store at index 1
//return the array as result.

using System;
using System.Linq;

public class Kata
{
    public static int[] CountPositivesSumNegatives(int[] input)
    {
      
      if(input?.Any() != true){
        int[] emptyArray = new int[] {};
        return emptyArray;
      }
        
      
      
       int[] temp = new int[] { 0, 0 };
       temp[0] = input.Where(x => x > 0).Count();
       temp[1] = input.Where(x => x < 0).Sum();
      
      return temp;
    }
}

//Solution 2 Linq
using System;
using System.Linq;

public class Kata
{
    public static int[] CountPositivesSumNegatives(int[] input)    
    {   
        return (input == null || input.Length ==0) ? new int[0] : new int[] { input.Count(o => o > 0), input.Where(o => o < 0).Sum() };
    }
}

//****************Sample Test*****************

using System;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class SumTests
{
    private static Random random = new Random();

    private int[] Sol(int[] input)
    {
        if(input == null || !input.Any())
        {
            return new int[] {};
        }
        
        int countPositives = input.Count(n => n > 0);
        int sumNegatives = input.Where(n => n < 0).Sum();

        return new int[] { countPositives, sumNegatives };
    }

    [Test]
    public void CountPositivesSumNegatives_BasicTest()
    {
        int[] expectedResult = new int[] {10, -65};
    
        Assert.AreEqual(expectedResult, Kata.CountPositivesSumNegatives(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, -11, -12, -13, -14, -15}));
    }
    
    [Test]
    public void CountPositivesSumNegatives_InputWithZeroes()
    {
        int[] expectedResult = new int[] {8, -50};
    
        Assert.AreEqual(expectedResult, Kata.CountPositivesSumNegatives(new[] {0, 2, 3, 0, 5, 6, 7, 8, 9, 10, -11, -12, -13, -14}));
    }
    
    [Test]
    public void CountPositivesSumNegatives_InputNull()
    {
        int[] expectedResult = new int[] {};
    
        Assert.AreEqual(expectedResult, Kata.CountPositivesSumNegatives(null));
    }
    
    [Test]
    public void CountPositivesSumNegatives_InputEmpty()
    {
        int[] expectedResult = new int[] {};
    
        Assert.AreEqual(expectedResult, Kata.CountPositivesSumNegatives(new int[] {}));
    }
    
    [Test]
    public void CountPositivesSumNegatives_RandomTests()
    {
        for(int i = 0; i < 20; i++)
        {
            int elementsNumber = random.Next(0, 100);
            int[] input = new int[elementsNumber];
            for(int j = 0; j < elementsNumber; j++)
            {
                input[j] = random.Next(-500, 500);
            }
            
            Assert.AreEqual(Sol(input), Kata.CountPositivesSumNegatives(input));
        }
    }
}
