/*Challenge link:https://www.codewars.com/kata/5877e7d568909e5ff90017e6/train/csharp
Question:
We want to generate all the numbers of three digits where:

the sum of their digits is equal to 10
their digits are in increasing order (the numbers may have two or more equal contiguous digits)
The numbers that fulfill these constraints are: [118, 127, 136, 145, 226, 235, 244, 334]. There're 8 numbers in total with 118 being the lowest and 334 being the greatest.

Task
Implement a function which receives two arguments:

the sum of digits (sum)
the number of digits (count)
This function should return three values:

the total number of values which have count digits that add up to sum and are in increasing order
the lowest such value
the greatest such value
Note: if there're no values which satisfy these constaints, you should return an empty value (refer to the examples to see what exactly is expected).

Examples
// The output type is List<long>
HowManyNumbers.FindAll(10, 3)  =>  [8, 118, 334]
HowManyNumbers.FindAll(27, 3)  =>  [1, 999, 999]
HowManyNumbers.FindAll(84, 4)  =>  []
Features of the random tests:

Number of tests: 112
Sum of digits value between 20 and 65
Amount of digits between 2 and 17
*/

//***************Solution********************
using System.Collections.Generic;
using System.Linq;
class HowManyNumbers{
        //global list.
        static List<long> Solutions;
  
        public static void FindAllRecursive(string digitsSoFar, int minNumber, int sumDigits, int numDigits){
          //if sum of digits is less than 0 or number of digits is 0 and sum of digits is greater than 1
          //return empty
            if (sumDigits < 0 || (numDigits == 0 && sumDigits > 0))
                return;
          //if sum of digits is 0 and number of digits is 0
          //add solution, parse string digitsSofar into long.
          //return empty.
            if (sumDigits == 0 && numDigits == 0){
                Solutions.Add(long.Parse(digitsSoFar));
                return;
            }
          //start from min number up to 9, recurisively add solution into the solution list.
          //by adding i, it increasing the digit in order
          //return empty.
            for (int i = minNumber; i <= 9; i++)
                FindAllRecursive(digitsSoFar + i.ToString(), i, sumDigits - i, numDigits - 1); ;
            return;
        }
        //main function
        public static List<long> FindAll(int sumDigits, int numDigits){
            Solutions = new List<long>();
          //pass data into recursive function.
            FindAllRecursive("", 1, sumDigits, numDigits);
          
          //if number of solution is 0, return empty list, 
          //else return result in format number of solutions, min(), max();
            return Solutions.Count() == 0 ? new List<long>() :
                              new List<long> {Solutions.Count(), Solutions.Min(), Solutions.Max()};
        }
}

//****************Sample Test*****************
//the test case from java version
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
public class SolutionTest
{
    [Test]
    public void ExampleTests()
    {
        Assert.AreEqual(new List<long> { 8L, 118L, 334L }, HowManyNumbers.FindAll(10, 3));
        Assert.AreEqual(new List<long> { 1L, 999L, 999L }, HowManyNumbers.FindAll(27, 3));
        Assert.AreEqual(new List<long> { }, HowManyNumbers.FindAll(84, 4));
        Assert.AreEqual(new List<long> { 123L, 116999L, 566666L }, HowManyNumbers.FindAll(35, 6));
    }

    private Random rand = new Random();
    private int[][] param = new int[][]
    {
        new int[] {80, 20, 21, 2, 7 },
        new int[] {27,   40, 21, 7, 5 },
        new int[] {2,   60, 6,  12, 2},
        new int[] {2,   60, 6,  14, 2}
    };
    private List<string>.Enumerator nameTestIter =
        new List<string> { "Not too large random tests", "    Large random tests    ", "     Huge random tests    " }.GetEnumerator();

    [Test]
    public void RandomTests()
    {
        var count = 0;
        foreach (var p in param)
        {
            int nTests = p[0],
                sdLow = p[1],
                sdHigh = p[2],
                ndDelta = p[3],
                ndHigh = p[4];

            for (int x = 0; x < nTests; x++)
            {
                var sd = sdLow + rand.Next(sdHigh);
                var nd = ndDelta + rand.Next(ndHigh);
                var actual = HowManyNumbers.FindAll(sd, nd);
                var expected = FindTheseNumbers(sd, nd);
                var actual2 = string.Join(" ", actual.Select(x1 => x1));
                var expected2 = string.Join(" ", expected.Select(x1 => x1));
                Console.WriteLine(string.Format("-------\nTest #{0}\nTest for sum_digits = {1} and amount of digits = {2}\nActual: {3}\nExpected: {4}", 
                                                count, sd, nd, actual2, expected2));
                Console.WriteLine("\n\n\n");
                Assert.AreEqual(expected, actual);
                count++;
            }
        }
    }

    private static List<long> FindTheseNumbers(int sd, int nd)
    {
        if (sd > nd * 9 || sd < nd) return new List<long>();
        int d = sd / nd, r = sd % nd;
        var arrMax = new int[nd];
        for (int x = 0; x < nd; x++)
            arrMax[nd - 1 - x] = x < r ? d + 1 : d;
        var s = new HashSet<long> { GetNumFromArr(arrMax) };
        s = GenerateNumbers(arrMax, s, 0);
        return new List<long> { s.Count, s.Min(), GetNumFromArr(arrMax) };
    }

    private static HashSet<long> GenerateNumbers(int[] arr, HashSet<long> s, int n)
    {
        for (int i = n; i < arr.Length - 1; i++)
        {
            if (arr[i] > 1 && (i == 0 || arr[i] > arr[i - 1]))
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < 9 && (j == arr.Length - 1 || arr[j] < arr[j + 1]))
                    {
                        var newArr = new int[arr.Length];
                        Array.Copy(arr, newArr, arr.Length);
                        newArr[i] -= 1;
                        newArr[j] += 1;
                        long newNum = GetNumFromArr(newArr);
                        if (!s.Contains(newNum))
                        {
                            s.Add(newNum);
                            var nums = GenerateNumbers(newArr, s, i);
                            foreach (var item in nums) s.Add(item);
                        }
                    }
                }
            }
        }
        return s;
    }

    private static long GetNumFromArr(int[] arr)
    {
        long tot = 0L;
        for (int x = 0; x < arr.Length; x++)
            tot += arr[arr.Length - 1 - x] * (long)Math.Pow(10, x);
        return tot;
    }
}
