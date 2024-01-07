/*Challenge link:https://www.codewars.com/kata/5ac5e9aa3853da25d9000102/train/csharp
Question:
It started as a discussion with a friend, who didn't fully grasp some way of setting defaults, but I thought the idea was cool enough for a beginner kata: binary OR each matching element of two given arrays (or lists, if you do it in Python; vectors in c++) of integers and give the resulting ORed array [starts to sound like a tonguetwister, doesn't it?].

If one array is shorter than the other, use the optional third parameter (defaulted to 0) to OR the unmatched elements.

For example:

orArrays([1,2,3],[1,2,3]) === [1,2,3]
orArrays([1,2,3],[4,5,6]) === [5,7,7]
orArrays([1,2,3],[1,2]) === [1,2,3]
orArrays([1,2],[1,2,3]) === [1,2,3]
orArrays([1,2,3],[1,2,3],3) === [1,2,3]
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
/*
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⠤⢔⣶⣖⢂⢒⡐⠢⠤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠤⢊⠵⠒⣩⠟⠛⠙⠂⠀⠀⠉⠒⢤⣾⣖⠤⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⣀⡤⠄⣀⠀⠀⠀⠀⠀⢀⠔⡡⠊⠀⠀⠀⠁⣀⣀⠀⠀⠀⠀⠀⠀⠈⠉⠻⡆⠈⠢⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⢠⠋⠁⠀⠀⠈⠱⡄⠀⠀⡠⠃⡜⠀⠀⠀⠀⢀⣾⠗⠋⠛⢆⠀⠀⠀⣠⣤⣤⡄⠉⢢⠀⠑⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⢼⠀⠀⠀⠀⠀⠀⠱⠀⢠⠃⢠⠃⠀⠀⠀⠀⢸⠋⣠⣤⡀⠘⡆⠀⢰⡿⠋⠉⠳⣄⠈⣆⠀⠐⡄⠀⠀⢀⠔⠂⠐⠲⢄⠀⠀⠀
⠀⠀⠀⠈⢆⠀⠀⠀⠀⠀⢀⢃⠆⠀⠀⠁⠀⠀⢄⣀⣹⠀⣷⣼⣿⠀⢻⠀⢿⣖⣹⣷⡀⠈⡆⠈⠀⠀⢰⡀⠰⠃⠀⠀⠀⠀⠀⡇⠀⠀
⠀⠀⠀⠀⠈⣆⠤⠤⠤⠤⠾⣼⡀⠀⠀⠀⠀⠀⢀⡀⠂⠙⠻⡓⠋⢀⡏⠀⠀⢿⢿⡽⠃⠀⡜⠀⠀⠀⠀⡇⡇⠀⠀⠀⠀⠀⡠⠁⠀⠀
⠀⠀⢀⠔⡩⠀⠀⠀⠀⠀⠀⠀⠉⠓⢄⠀⠀⠊⠁⠙⢕⠂⠀⠘⡖⠊⠀⠀⠀⠀⠑⡤⠔⠊⡉⠐⠀⠀⢀⣰⡼⠤⠤⠤⢄⣰⠁⠀⠀⠀
⠀⡰⠁⠊⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⡇⠀⠀⠀⠀⠈⣶⡤⣀⠀⠀⠀⠀⠀⠀⠀⠁⠠⣲⠖⠤⢠⠞⠉⠀⠀⠀⠀⠀⠀⠀⠁⠢⡀⠀
⢰⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠉⠛⠒⢧⡀⠀⠀⠀⠀⠘⣷⣀⠉⠑⠒⠂⠒⢐⣦⠖⠋⠀⠀⠀⡗⠀⠀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠐⠀
⠠⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢳⠀⠀⠀⠀⠀⠸⣿⣷⣦⣤⣤⣤⣾⠇⠀⠀⠀⠀⡴⠛⠉⠀⠀⠀⠀⠉⠐⠂⠀⠀⠀⠀⢠
⢰⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⠄⣀⡀⢀⠞⢄⠀⠀⠀⠀⠀⠘⢾⣿⣻⣿⣿⡟⠀⠀⠀⠀⢸⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸
⠈⢆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠓⢎⠀⠈⠢⡀⠀⠀⠀⠀⠈⠛⠿⠿⢛⠁⠀⠀⠀⠀⠈⢆⣀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈
⠀⠈⢢⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡜⠻⢤⡀⠈⠲⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⠔⢻⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠉⠢⢄⡀⠀⠀⠀⠀⢀⡠⠔⠊⠀⠀⠀⠉⠓⠦⣀⣁⠀⠀⠀⠀⠀⢀⣀⠤⠒⠊⠀⠀⠈⠢⡀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠔⠁⠀
⠀⠀⠀⠀⠀⠀⠀⠉⢉⠉⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠉⠉⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠑⠒⠤⠤⠤⠤⠒⠊⠁⠀⠀⠀
*/


//check default method, if array length is greater than i, return arr[i], else return def

//generate sequence, start from 0, count up to which ever length is higher between arr1 and arr2
//x is current element of the generated sequence, pass the values of arr1 and arr2 into checkDefault
//OR the elements inside both array, store in array and return the result.

using System.Linq;
using static System.Math;

class Kata{
    private static int checkDefault(int[] arr, int i, int def) => arr.Length > i ? arr[i] : def;
    
    public static int[] OrArrays(int[] arr1, int[] arr2, int d = 0) => 
               Enumerable.Range(0, Max(arr1.Length, arr2.Length))
                         .Select(x => checkDefault(arr1, x, d) | checkDefault(arr2, x, d))
                         .ToArray();
}

//solution 2
using System;
using System.Linq;

class Kata
{
  public static int[] OrArrays(int[] arr1, int[] arr2, int d = 0)
  {
    return new int[Math.Max(arr1.Length, arr2.Length)]
        .Select((_, i) => (arr1.Length > i ? arr1[i] : d) | (arr2.Length > i ? arr2[i] : d)).ToArray();
  }
}
//****************Sample Test*****************
//the test case from javascript version
using NUnit.Framework;
using System;
using System.Linq;
class SolutionTest
{
    [Test]
    public void FixedTest()
    {
        Assert.AreEqual(new[] { 1, 2, 3 }, Kata.OrArrays(new[] { 1, 2, 3 }, new[] { 1, 2, 3 }));
        Assert.AreEqual(new[] { 5, 7, 7 }, Kata.OrArrays(new[] { 1, 2, 3 }, new[] { 4, 5, 6 }));
        Assert.AreEqual(new[] { 1, 2, 3 }, Kata.OrArrays(new[] { 1, 2, 3 }, new[] { 1, 2 }));
        Assert.AreEqual(new[] { 1, 2, 3 }, Kata.OrArrays(new[] { 1, 0 }, new[] { 1, 2, 3 }));
        Assert.AreEqual(new[] { 1, 2, 3 }, Kata.OrArrays(new[] { 1, 0, 3 }, new[] { 1, 2, 3 }, 3));
    }

    [Test]
    public void RandomTest()
    {
        for (int i = 0; i < 100; i++)
        {
            var arr1 = MakeArr();
            var arr2 = MakeArr();
            if (random.NextDouble() < 0.5)
            {
                var d = random.Next(-255, 256);
                var expected = OrArrays(arr1, arr2, d);
                var actual = Kata.OrArrays(arr1, arr2, d);
                Assert.AreEqual(expected, actual, $"arr1 = [{string.Join(", ", arr1)}]\narr1 = [{string.Join(", ", arr1)}]\nd= {d}\nexpected = [{string.Join(", ", arr1)}]");
            }
            else
            {
                var expected = OrArrays(arr1, arr2);
                var actual = Kata.OrArrays(arr1, arr2);
                Assert.AreEqual(expected, actual, $"arr1 = [{string.Join(", ", arr1)}]\narr1 = [{string.Join(", ", arr1)}]\nexpected = [{string.Join(", ", arr1)}]");
            }
        }
    }

    private Random random = new Random();

    private int[] MakeArr()
    {
        var len = random.Next(1, 36);
        var arr = new int[len];
        for (int i = 0; i < len; i++)
            arr[i] = random.Next(-255, 256);
        return arr;
    }

    private static int[] OrArrays(int[] arr1, int[] arr2, int d = 0) => Enumerable.Range(0, Math.Max(arr1.Length, arr2.Length)).Select(x => x < arr1.Length && x < arr2.Length ? arr1[x] | arr2[x] : x < arr1.Length ? d | arr1[x] : d | arr2[x]).ToArray();
}
