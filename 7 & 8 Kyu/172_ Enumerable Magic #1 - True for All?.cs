/*Challenge link:https://www.codewars.com/kata/54598d1fcbae2ae05200112c/train/csharp
Question:
Task
Create a method all which takes two params:

a sequence
a function (function pointer in C)
and returns true if the function in the params returns true for every element in the sequence. Otherwise, it should return false. If the sequence is empty, it should return true, since technically nothing failed the test.

Example
all((1, 2, 3, 4, 5), greater_than_9) -> false
all((1, 2, 3, 4, 5), less_than_9)    -> True
Help
Here's a (Ruby) resource if you get stuck:

http://www.rubycuts.com/enum-all
*/

//***************Solution********************
//check if all element satisfied the condition, then return a bool value.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;

public class Kata{
  public static bool All(int[] arr, Func<int, bool> fun) => arr.All(x => fun(x));
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class KataTests
  {
    [Test]
    public void BasicTest()
    {
      Assert.AreEqual(true, Kata.All(new int[] { 1,2,3,4,5 }, v => v < 9));
      Assert.AreEqual(false, Kata.All(new int[] { 1,2,3,4,5 }, v => v > 9));
    }
    
    [Test]
    public void ExtendedTests()
    {
      var list = new int[] { 2, 4, 6, 10 };
      Assert.AreEqual(true, Kata.All(list, v => v % 2 == 0), "All items are even");
      Assert.AreEqual(false, Kata.All(list, v => v < 10), "Not all items are less than ten");
      Assert.AreEqual(false, Kata.All(list, v => v % 2 != 0), "No items are odd");
      Assert.AreEqual(true, Kata.All(new int[0], v => v % 2 == 0), "An empty list should return true");
    }
  }
}
