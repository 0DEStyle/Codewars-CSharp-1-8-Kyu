/*Challenge link:https://www.codewars.com/kata/50ee6b0bdeab583673000025/train/csharp
Question:
This code should store "codewa.rs" as a variable called name but it's not working. Can you figure out why?


*/

//***************Solution********************
//added field type string to fix the code.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Kata{
  public static string Name = "codewa.rs";
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void Test()
    {
      Assert.AreEqual("codewa.rs", Kata.Name);
    }
  }
}
