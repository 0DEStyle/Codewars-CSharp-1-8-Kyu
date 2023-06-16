/*Challenge link:https://www.codewars.com/kata/55955a48a4e9c1a77500005a/train/csharp
Question:
Say hello!

Write a function to greet a person. Function will take name as input and greet the person by saying hello. Return null/nil/None if input is empty string or null/nil/None.

Example:

greet("Niks") == "hello Niks!"
greet("") == null; // Return null if input is empty string
greet(null) == null; // Return null if input is null
*/

//***************Solution********************
//check if string is null or empty, if so return null, else return name with string interpolation
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
public class Greetings
  {
    public static string greet(string name) => String.IsNullOrEmpty(name) ? null : $"hello {name}!";
  }

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void MyTest()
    {
      Assert.AreEqual(Greetings.greet("Niks"), "hello Niks!");
      Assert.AreEqual(Greetings.greet(""), null);
      Assert.AreEqual(Greetings.greet(null), null);
      Assert.AreEqual(Greetings.greet("Frank Underwood"), "hello Frank Underwood!");
      Assert.AreEqual(Greetings.greet(" "), "hello  !");
      Assert.AreEqual(Greetings.greet("!!"), "hello !!!");
      Assert.AreEqual(Greetings.greet("asdawidsaiodfwiodaosdp[awfodskawdsoafkwad@"), "hello asdawidsaiodfwiodaosdp[awfodskawdsoafkwad@!");
    }
  }
}
