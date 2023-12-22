/*Challenge link:https://www.codewars.com/kata/56e2f59fb2ed128081001328/train/csharp
Question:
Input: Array of elements

["h","o","l","a"]

Output: String with comma delimited elements of the array in th same order.

"h,o,l,a"

Note: if this seems too simple for you try the next level

Note2: the input data can be: boolean array, array of objects, array of string arrays, array of number arrays... 😕
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//x is the current element, from array, check if element is an object array
//if so print array x as object array, else return as it is.
//join elements inside array by ","
using System;
using System.Linq;

public class Kata{
  public static string PrintArray(object[] array) => 
    string.Join(",",array.Select(x => x is Object[] ? PrintArray(x as object[]) : x));
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class KataTests
  {
    [Test]
    public void BasicTests()
    {
      var data = new object[] { 2 };
      Assert.AreEqual("2", Kata.PrintArray(data), "single int test failed 2 !=" + Kata.PrintArray(data));

      data = new object[] { 2, 4, 5, 2 };
      Assert.AreEqual("2,4,5,2", Kata.PrintArray(data), "int test failed 2,4,5,2 != " + Kata.PrintArray(data));
      
      data = new object[] { 2.0, 4.2, 5.1, 2.2 };
      Assert.AreEqual("2,4.2,5.1,2.2", Kata.PrintArray(data), "floats test failed 2,4.2,5.1,2.2 !=" + Kata.PrintArray(data));
      
      data = new object[] { "2", "4", "5", "2" };
      Assert.AreEqual("2,4,5,2", Kata.PrintArray(data), "String test failed 2,4,5,2 != " + Kata.PrintArray(data));
      
      var array1 = new object[] { "hello", "this", "is", "an", "array!" };
      var array2 = new object[] { "a", "b", "c", "d", "e!" };
      data = new object[] { array1, array2 };
      Assert.AreEqual("hello,this,is,an,array!,a,b,c,d,e!", Kata.PrintArray(data), "Array of array test failed hello,this,is,an,array!,a,b,c,d,e! !=" + Kata.PrintArray(data));

      array1 = new object[] { "hello", "this", "is", "an", "array!" };
      array2 = new object[] { 1, 2, 3, 4, 5 };
      data = new object[] { array1, array2 };
      Assert.AreEqual("hello,this,is,an,array!,1,2,3,4,5", Kata.PrintArray(data), "arrays of different type array test failed hello,this,is,an,array!,1,2,3,4,5 !=" + Kata.PrintArray(data));

      object x = new { firstName = "John", lastName = "Doe"};
      object y = new { firstName = "Ruslan", lastName = "López"};
      data = new object[] { x, y };
      Assert.AreEqual("{ firstName = John, lastName = Doe },{ firstName = Ruslan, lastName = López }", Kata.PrintArray(data), "object test failed [object Object],[object Object] != " + Kata.PrintArray(data));
      
      data = new object[] { true, false };
      Assert.AreEqual("True,False", Kata.PrintArray(data), "boolean test failed true,false != " + Kata.PrintArray(data));
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      
      for(int r=0;r<40;r++)
      {
        var data = new object[] { rand.Next(90), rand.Next(90), rand.Next(90), rand.Next(90), rand.Next(90), rand.Next(90), rand.Next(90) };
        var expected = string.Join(",", data.Select(a => a.GetType().IsArray ? string.Join(",", (object[])a) : a));
        Assert.AreEqual(expected, Kata.PrintArray(data), "Random input failed " + expected + " != " + Kata.PrintArray(data));
      }
    }
  }
}
