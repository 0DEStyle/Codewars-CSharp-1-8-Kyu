/*Challenge link:https://www.codewars.com/kata/525d50d2037b7acd6e000534/train/csharp
Question:
This kata is designed to test your ability to extend the functionality of built-in classes. In this case, we want you to extend the built-in Array class with the following methods: square(), cube(), average(), sum(), even() and odd().

Explanation:

square() must return a copy of the array, containing all values squared
cube() must return a copy of the array, containing all values cubed
average() must return the average of all array values; on an empty array must return NaN (note: the empty array is not tested in Ruby!)
sum() must return the sum of all array values
even() must return an array of all even numbers
odd() must return an array of all odd numbers
Note: the original array must not be changed in any case!

Example
var numbers = new int[] { 1, 2, 3, 4, 5 };
numbers.Square(); // must return [1, 4, 9, 16, 25]
numbers.Cube(); // must return [1, 8, 27, 64, 125]
numbers.Average(); // must return 3
numbers.Sum(); // must return 15
numbers.Even(); // must return [2, 4]
numbers.Odd(); // must return [1, 3, 5]
*/

//***************Solution********************
//x is the current element.
//using Linq functions to process array,
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System;
using System.Linq;

static class Extensions {
  public static int[] Square(this int[] arr) => arr.Select(x => x * x).ToArray();
  public static int[] Cube(this int[] arr) => arr.Select(x => x * x * x).ToArray();
  public static double Average(this int[] arr) => arr.Length == 0 ? Double.NaN : Math.Truncate(arr.Average(x => x));
  public static int Sum(this int[] arr) => arr.Sum(x => x);
  public static int[] Even(this int[] arr) => arr.Where(x => x % 2 == 0).ToArray();
  public static int[] Odd(this int[] arr) => arr.Where(x => x % 2 != 0).ToArray();
}

//****************Sample Test*****************
using System;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class ExampleTests {
  int[] array = new [] { 1, 2, 3, 4, 5 };
  
  [Test]
  public void ShouldSquareCorrectly() {
    CollectionAssert.AreEqual(new [] { 1, 4, 9, 16, 25 }, array.Square(), "Square should work correctly");
    CollectionAssert.AreEqual(new [] { 1, 2, 3, 4, 5 }, array, "Original array should not be modified");
    Assert.IsTrue(array.Square() is int[], "Square should return an array");
  }
  
  [Test]
  public void ShouldCubeCorrectly() {
    CollectionAssert.AreEqual(new [] { 1, 8, 27, 64, 125 }, array.Cube(), "Cube should work correctly");
    CollectionAssert.AreEqual(new [] { 1, 2, 3, 4, 5 }, array, "Original array should not be modified");
    Assert.IsTrue(array.Cube() is int[], "Cube should return an array");
  }
  
  [Test]
  public void ShouldSumCorrectly() {
    Assert.AreEqual(15, array.Sum(), "Sum should work correctly");
    CollectionAssert.AreEqual(new [] { 1, 2, 3, 4, 5 }, array, "Original array should not be modified");
  }
  
  [Test]
  public void ShouldAverageCorrectly() {
    Assert.AreEqual(3, array.Average(), "Average should work correctly");
    CollectionAssert.AreEqual(new [] { 1, 2, 3, 4, 5 }, array, "Original array should not be modified");
  }
  
  [Test]
  public void ShouldEvenAndOddCorrectly() {
    CollectionAssert.AreEqual(new [] { 2, 4 }, array.Even(), "Even should work correctly");
    CollectionAssert.AreEqual(new [] { 1, 2, 3, 4, 5 }, array, "Original array should not be modified");
    Assert.IsTrue(array.Even() is int[], "Even should return an array");
    
    CollectionAssert.AreEqual(new [] { 1, 3, 5 }, array.Odd(), "Odd should work correctly");
    CollectionAssert.AreEqual(new [] { 1, 2, 3, 4, 5 }, array, "Original array should not be modified");
    Assert.IsTrue(array.Odd() is int[], "Odd should return an array");
  }
}

[TestFixture]
public class Robustness {
  [Test]
  public void ShouldSquareEmptyArray() {
    Assert.DoesNotThrow(() => {
      var x = (new int[] { }).Square();
    }, "Square should be able to operate on empty arrays");
  }
  
  [Test]
  public void ShouldCubeEmptyArray() {
    Assert.DoesNotThrow(() => {
      var x = (new int[] { }).Cube();
    }, "Cube should be able to operate on empty arrays");
  }
  
  [Test]
  public void ShouldOddEmptyArray() {
    Assert.DoesNotThrow(() => {
      var x = (new int[] { }).Odd();
    }, "Odd should be able to operate on empty arrays");
  }
  
  [Test]
  public void ShouldEvenEmptyArray() {
    Assert.DoesNotThrow(() => {
      var x = (new int[] { }).Even();
    }, "Even should be able to operate on empty arrays");
  }
  
  [Test]
  public void ShouldSumEmptyArray() {
    Assert.DoesNotThrow(() => {
      var x = (new int[] { }).Sum();
    }, "Sum should be able to operate on empty arrays");
  }
  
  [Test]
  public void ShouldAverageEmptyArray() {
    Assert.DoesNotThrow(() => {
      var x = (new int[] { }).Average();
    }, "Average should be able to operate on empty arrays");
  }
}

[TestFixture]
public class RandomData {
  int[] array = new int[20];
  
  [SetUp]
  public void Setup() {
    var random = new Random();
    for(var i = 0; i < array.Length; i++)
      array[i] = random.Next(1, 1000);
  }
  
  [Test]
  public void ShouldSquareCorrectly() {
    CollectionAssert.AreEqual(array.Select(x => x * x).ToArray(), array.Square(), "Square should work correctly");
    CollectionAssert.AreEqual(new int[] { }, (new int[] { }).Square(), "Square should work correctly on an empty array");
  }
  
  [Test]
  public void ShouldCubeCorrectly() {
    CollectionAssert.AreEqual(array.Select(x => x * x * x).ToArray(), array.Cube(), "Cube should work correctly");
    CollectionAssert.AreEqual(new int[] { }, (new int[] { }).Cube(), "Cube should work correctly on an empty array");
  }
  
  [Test]
  public void ShouldSumCorrectly() {
    Assert.AreEqual(array.Aggregate((x, y) => x + y), array.Sum(), "Sum should work correctly");
    Assert.AreEqual(0, (new int[] { }).Sum(), "Sum should work correctly on an empty array");
  }
  
  [Test]
  public void ShouldAverageCorrectly() {
    Assert.AreEqual(array.Aggregate((x, y) => x + y) / array.Length, array.Average(), "Average should work correctly");
    Assert.AreEqual(double.NaN, (new int[] { }).Average(), "Average should work correctly on an empty array");
  }
  
  [Test]
  public void ShouldEvenAndOddCorrectly() {
    CollectionAssert.AreEqual(new int[] { }, array.Even().Odd(), "The intersection of odd and even elements must be []");
    Assert.AreEqual(array.Length, array.Odd().Length + array.Even().Length, "The sum of odd and even elements should match the length of the array");
  }
}
