/*Challenge link:https://www.codewars.com/kata/54f9c37106098647f400080a/train/csharp
Question:
Yet another staple for the functional programmer. You have a sequence of values and some predicate for those values. You want to remove the longest prefix of elements such that the predicate is true for each element. We'll call this the dropWhile function. It accepts two arguments. The first is the sequence of values, and the second is the predicate function. The function does not change the value of the original sequence.

Func<int, bool> isEven = (value) => value % 2 == 0;

dropWhile(new int[] { 2, 4, 6, 8, 1, 2, 5, 4, 3, 2 }, isEven) // -> { 1, 2, 5, 4, 3, 2 }
Your task is to implement the dropWhile function. If you've got a span function lying around, this is a one-liner! Alternatively, if you have a takeWhile function on your hands, then combined with the dropWhile function, you can implement the span function in one line. This is the beauty of functional programming: there are a whole host of useful functions, many of which can be implemented in terms of each other.


*/

//***************Solution********************
//loop through each element in arr,
//if current element is false within the pred condition, break the loop
// then return that number and all the other numbers after it
// result from i until the end.
using System;
using System.Linq;

public class Kata{
    public static int[] DropWhile(int[] arr, Func<int, bool> pred){
      int i;
      for(i = 0; i < arr.Length; i++)
        if(!pred(arr[i])) break;
      return arr[i..];
    }
}

//solution 2
using System;
using System.Linq;

public class Kata
{
    public static int[] DropWhile(int[] arr, Func<int, bool> pred)
    {
        return arr.SkipWhile(pred).ToArray();
    }
}
//****************Sample Test*****************
namespace Solution
{
    using NUnit.Framework;
    
    using System;
    using System.Linq;
    
    [TestFixture]
    public class SolutionTest
    {
        private Func<int, bool> isEven = (value) => value % 2 == 0;
        
        private Func<int, bool> isOdd = (value) => value % 2 != 0;
    
        [Test]
        public void BasicTest1()
        {
            var expected = new int[] { 1, 5, 4, 3 };
            var actual = Kata.DropWhile(new int[] { 2, 6, 4, 10, 1, 5, 4, 3 }, isEven);
        
            Assert.AreEqual(string.Join(", ", expected), string.Join(", ", actual));
        }
        
        [Test]
        public void BasicTest2()
        {
            var expected = new int[] { 5, 3, 4, 6 };
            var actual = Kata.DropWhile(new int[] { 2, 100, 1000, 10000, 5, 3, 4, 6 }, isEven);
        
            Assert.AreEqual(string.Join(", ", expected), string.Join(", ", actual));
        }
        
        [Test]
        public void BasicTest3()
        {
            var expected = new int[] { };
            var actual = Kata.DropWhile(new int[] { 2, 4, 10, 100, 64, 78, 92 }, isEven);
        
            Assert.AreEqual(string.Join(", ", expected), string.Join(", ", actual));
        }
        
        [Test]
        public void ExtendedTest1()
        {
            var expected = new int[] { 1, 1, 1 };
            var actual = Kata.DropWhile(new int[] { 998, 996, 12, -1000, 200, 0, 1, 1, 1 }, isEven);
        
            Assert.AreEqual(string.Join(", ", expected), string.Join(", ", actual));
        }
        
        [Test]
        public void ExtendedTest2()
        {
            var expected = new int[] { 1, 4, 2, 3, 5, 4, 5, 6, 7 };
            var actual = Kata.DropWhile(new int[] { 1, 4, 2, 3, 5, 4, 5, 6, 7 }, isEven);
        
            Assert.AreEqual(string.Join(", ", expected), string.Join(", ", actual));
        }
        
        [Test]
        public void ExtendedTest3()
        {
            var expected = new int[] { 2, 4, 6, 4, 5 };
            var actual = Kata.DropWhile(new int[] { 1, 5, 111, 1111, 2, 4, 6, 4, 5 }, isOdd);
        
            Assert.AreEqual(string.Join(", ", expected), string.Join(", ", actual));
        }
        
        [Test]
        public void ExtendedTest4()
        {
            var expected = new int[] { 86, 902, 2, 1 };
            var actual = Kata.DropWhile(new int[] { -1, -5, 127, 86, 902, 2, 1 }, isOdd);
        
            Assert.AreEqual(string.Join(", ", expected), string.Join(", ", actual));
        }
        
        [Test]
        public void ExtendedTest5()
        {
            var expected = new int[] { 2, 1, 2, 4, 3, 5, 4, 6, 7, 8, 9, 0 };
            var actual = Kata.DropWhile(new int[] { 2, 1, 2, 4, 3, 5, 4, 6, 7, 8, 9, 0 }, isOdd);
        
            Assert.AreEqual(string.Join(", ", expected), string.Join(", ", actual));
        }
        
        [Test]
        public void ExtendedTest6()
        {
            var expected = new int[] { };
            var actual = Kata.DropWhile(new int[] { 1, 3, 5, 7, 9, 111 }, isOdd);
        
            Assert.AreEqual(string.Join(", ", expected), string.Join(", ", actual));
        }
        
        [Test]
        public void RandomTests()
        {
            var rand = new Random();
            
            Func<int[], Func<int, bool>, int[]> solution = (arr, pred) => 
            {
                for(int i = 0; i < arr.Length; i++)
                {
                    if (!pred(arr[i]))
                    {
                        return arr.Skip(i).ToArray();
                    }
                }
                
                return new int[] {  };
            };
            
            for(int i = 0; i < 100; i++)
            {
                var arr = Enumerable.Range(0, rand.Next(0, 20)).Select(a => rand.Next(-200, 201)).ToArray();
            
                var expected = solution(arr, isEven);
                var actual = Kata.DropWhile(arr, isEven);
            
                Assert.AreEqual(string.Join(", ", expected), string.Join(", ", actual));
                
                expected = solution(arr, isOdd);
                actual = Kata.DropWhile(arr, isOdd);
            
                Assert.AreEqual(string.Join(", ", expected), string.Join(", ", actual));
            }
        }
    }
