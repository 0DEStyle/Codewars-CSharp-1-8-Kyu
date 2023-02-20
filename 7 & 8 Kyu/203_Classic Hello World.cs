/*Challenge link:https://www.codewars.com/kata/57036f007fd72e3b77000023/train/csharp
Question:
You are given a method called main, make it print the line Hello World!, (yes, that includes a new line character at the end) and don't return anything

Note that for some languages, the function main is the entry point of the program.

Here's how it will be tested:

   Solution.Main("parameter1", "parameter2","parametern")
Hints:

Check your references
Think about the scope of your method
For prolog you can use write but there are better ways
If you still don't get it probably you can define main as an attribute of the Solution class that accepts a single argument, and that only prints "Hello World!" without any return.
*/

//***************Solution********************
//return "Hello World!"
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
public static class Solution{
  public static void Main(string[] args) => Console.WriteLine("Hello World!");
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.IO;
 
[TestFixture]
public class StringToNumberTest
{
    [Test]
    public void test1()
    {
      var originalConsoleOut = Console.Out; // preserve the original stream
      var writer = new StringWriter();
      Console.SetOut(writer);
      //ready to listen to console
      Solution.Main(new string[]{"Greetings from Javatlacati"});
      writer.Flush(); // when you're done, make sure everything is written out

      var myString = writer.GetStringBuilder().ToString();
      Console.SetOut(originalConsoleOut); // restore Console output
      Assert.AreEqual("Hello World!\n" , myString);
    }
    
    [Test]
    public void test2()
    {
      var originalConsoleOut = Console.Out; // preserve the original stream
      var writer = new StringWriter();
      Console.SetOut(writer);
      //ready to listen to console
      Solution.Main(new string[]{"Greetings from Javatlacati", "For a basic hello world you should'nt process arguments at all"});
      writer.Flush(); // when you're done, make sure everything is written out

      var myString = writer.GetStringBuilder().ToString();
      Console.SetOut(originalConsoleOut); // restore Console output
      Assert.AreEqual("Hello World!\n" , myString);
    }
    
    [Test]
    public void test3()
    {
      var originalConsoleOut = Console.Out; // preserve the original stream
      var writer = new StringWriter();
      Console.SetOut(writer);
      //ready to listen to console
      Solution.Main(new String[0]);
      writer.Flush(); // when you're done, make sure everything is written out

      var myString = writer.GetStringBuilder().ToString();
      Console.SetOut(originalConsoleOut); // restore Console output
      Assert.AreEqual("Hello World!\n" , myString);
    }
}
