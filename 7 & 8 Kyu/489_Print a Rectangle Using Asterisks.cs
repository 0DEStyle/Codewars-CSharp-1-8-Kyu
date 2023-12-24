/*Challenge link:https://www.codewars.com/kata/5937ae46377144bb2f000029/train/csharp
Question:
Write a method that, given two arguments, width and height, returns a string representing a rectangle with those dimensions.

The rectangle should be filled with spaces, and its borders should be composed of asterisks (*).

For example, the following call:

GetRectangleString(3, 3);
Should return the following string:

***
* *
***
End each line of the string (including the last one) with a carriage return-line feed combination.

Note: You may assume that width and height will always be greater than zero.
*/

//***************Solution********************
/*
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣤⣤⣤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣀⠀⠀⠀⢀⣴⠟⠉⠀⠀⠀⠈⠻⣦⡀⠀⠀⠀⣤⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣷⣀⢀⣾⠿⠻⢶⣄⠀⠀⣠⣶⡿⠶⣄⣠⣾⣿⠗⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠉⢻⣿⣿⡿⣿⠿⣿⡿⢼⣿⣿⡿⣿⣎⡟⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⡟⠉⠛⢛⣛⡉⠀⠀⠙⠛⠻⠛⠑⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⣧⣤⣴⠿⠿⣷⣤⡤⠴⠖⠳⣄⣀⣹⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⣿⣀⣟⠻⢦⣀⡀⠀⠀⠀⠀⣀⡈⠻⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣼⡿⠉⡇⠀⠀⠛⠛⠛⠋⠉⠉⠀⠀⠀⠹⢧⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣾⡟⠀⢦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠃⠀⠈⠑⠪⠷⠤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣾⣿⣿⣿⣦⣼⠛⢦⣤⣄⡀⠀⠀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠑⠢⡀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⢀⣠⠴⠲⠖⠛⠻⣿⡿⠛⠉⠉⠻⠷⣦⣽⠿⠿⠒⠚⠋⠉⠁⡞⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⢦⠀⠀⠀⠀
⠀⠀⠀⠀⠀⢀⣾⠛⠁⠀⠀⠀⠀⠀⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠤⠒⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢣⠀⠀⠀
⠀⠀⠀⠀⣰⡿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣑⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⡇⠀⠀
⠀⠀⠀⣰⣿⣁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⣧⣄⠀⠀⠀⠀⠀⠀⢳⡀⠀
⠀⠀⠀⣿⡾⢿⣀⢀⣀⣦⣾⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡰⣫⣿⡿⠟⠻⠶⠀⠀⠀⠀⠀⢳⠀
⠀⠀⢀⣿⣧⡾⣿⣿⣿⣿⣿⡷⣶⣤⡀⠀⠀⠀⠀⠀⠀⠀⢀⡴⢿⣿⣧⠀⡀⠀⢀⣀⣀⢒⣤⣶⣿⣿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇
⠀⠀⡾⠁⠙⣿⡈⠉⠙⣿⣿⣷⣬⡛⢿⣶⣶⣴⣶⣶⣶⣤⣤⠤⠾⣿⣿⣿⡿⠿⣿⠿⢿⣿⣿⣿⣿⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇
⠀⣸⠃⠀⠀⢸⠃⠀⠀⢸⣿⣿⣿⣿⣿⣿⣷⣾⣿⣿⠟⡉⠀⠀⠀⠈⠙⠛⠻⢿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇
⠀⣿⠀⠀⢀⡏⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⠿⠿⠛⠛⠉⠁⠀⠀⠀⠀⠀⠉⠠⠿⠟⠻⠟⠋⠉⢿⣿⣦⡀⢰⡀⠀⠀⠀⠀⠀⠀⠁
⢀⣿⡆⢀⡾⠀⠀⠀⠀⣾⠏⢿⣿⣿⣿⣯⣙⢷⡄⠀⠀⠀⠀⠀⢸⡄⠀⠀⠀⠀⠀⠀⠀⠀⢀⣤⣿⣻⢿⣷⣀⣷⣄⠀⠀⠀⠀⢸⠀
⢸⠃⠠⣼⠃⠀⠀⣠⣾⡟⠀⠈⢿⣿⡿⠿⣿⣿⡿⠿⠿⠿⠷⣄⠈⠿⠛⠻⠶⢶⣄⣀⣀⡠⠈⢛⡿⠃⠈⢿⣿⣿⡿⠀⠀⠀⠀⠀⡀
⠟⠀⠀⢻⣶⣶⣾⣿⡟⠁⠀⠀⢸⣿⢅⠀⠈⣿⡇⠀⠀⠀⠀⠀⣷⠂⠀⠀⠀⠀⠐⠋⠉⠉⠀⢸⠁⠀⠀⠀⢻⣿⠛⠀⠀⠀⠀⢀⠇
⠀⠀⠀⠀⠹⣿⣿⠋⠀⠀⠀⠀⢸⣧⠀⠰⡀⢸⣷⣤⣤⡄⠀⠀⣿⡀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡆⠀⠀⠀⠀⡾⠀⠀⠀⠀⠀⠀⢼⡇
⠀⠀⠀⠀⠀⠙⢻⠄⠀⠀⠀⠀⣿⠉⠀⠀⠈⠓⢯⡉⠉⠉⢱⣶⠏⠙⠛⠚⠁⠀⠀⠀⠀⠀⣼⠇⠀⠀⠀⢀⡇⠀⠀⠀⠀⠀⠀⠀⡇
⠀⠀⠀⠀⠀⠀⠻⠄⠀⠀⠀⢀⣿⠀⢠⡄⠀⠀⠀⣁⠁⡀⠀⢠⠀⠀⠀⠀⠀⠀⠀⠀⢀⣐⡟⠀⠀⠀⠀⢸⡇⠀⠀⠀⠀⠀⠀⢠⡇⠀⠀⠀⠀⠀
*/
using System;
using System.Linq;

namespace Kata{
  public class PrintRectangleWithAsterisks{
    public string GetRectangleString(int width, int height){
      //print jank
      //Console.WriteLine(width + " " + height);
      
      //less than 3
      if(width < 3 || height < 3) 
        return string.Concat(Enumerable.Repeat(new string('*', width) + "\r\n",height));
      
      //create first and end
      //mid will start and end with '*' with space in the middle
      //repeat space height - 2 amount of times.
      string firstAndEnd = new string('*', width) + "\r\n";
      string mid = "*" + new string(' ',width - 2) + "*\r\n";
      var res = Enumerable.Repeat(mid,height - 2);
      
      //format string and return the resul.t
      return firstAndEnd + string.Concat(res) + firstAndEnd ;
    }
  }
}

//solution 2
using System.Linq;

namespace Kata
{
  public class PrintRectangleWithAsterisks
  {
    public string GetRectangleString(int width, int height)
    {
      return string.Join("\r\n", Enumerable.Range(0, height).Select(i => i == 0 || i == height - 1
          ? new string('*', width)
          : "*" + new string(' ', width - 2) + "*")) + "\r\n";
    }
  }
}

//solution 3
namespace Kata
{
  using System;
  using System.Collections.Generic;
  
  public class PrintRectangleWithAsterisks
  {
    public string GetRectangleString(int width, int height)
    {
      List<string> lines = new List<string>();
      for(int i=0;i<height;i++)
      {
        string line = string.Empty;
        if(i == 0 || i == height - 1) line = new String('*', width);
        else line = "*" + new String(' ', width - 2) + "*";
        lines.Add(line);
      }
      return string.Join("\r\n", lines.ToArray()) + "\r\n";
    }
  }
}
//****************Sample Test*****************
using System;
using System.Text;
using NUnit.Framework;

namespace Kata
{
  [TestFixture]
  public class PrintRectangleWithAsterisksTests
  {
    [Test]
    public void Test3x3()
    {
      string rectangle = new PrintRectangleWithAsterisks().GetRectangleString(3, 3);
      string expected = "***\r\n" +
                        "* *\r\n" +
                        "***\r\n";
      Assert.AreEqual(expected, rectangle);
    }

    [Test]
    public void Test5x7()
    {
      string rectangle = new PrintRectangleWithAsterisks().GetRectangleString(5, 7);
      string expected = "*****\r\n" +
                        "*   *\r\n" +
                        "*   *\r\n" +
                        "*   *\r\n" +
                        "*   *\r\n" +
                        "*   *\r\n" +
                        "*****\r\n";
      Assert.AreEqual(expected, rectangle);
    }

    [Test]
    public void Test1x1()
    {
      string rectangle = new PrintRectangleWithAsterisks().GetRectangleString(1, 1);
      string expected = "*\r\n";
      Assert.AreEqual(expected, rectangle);
    }

    [Test]
    public void Test1x2()
    {
      string rectangle = new PrintRectangleWithAsterisks().GetRectangleString(1, 2);
      string expected = "*\r\n" +
                        "*\r\n";
      Assert.AreEqual(expected, rectangle);
    }

    [Test]
    public void Test2x2()
    {
      string rectangle = new PrintRectangleWithAsterisks().GetRectangleString(2, 2);
      string expected = "**\r\n" +
                        "**\r\n";
      Assert.AreEqual(expected, rectangle);
    }

    [Test]
    public void Test8000x8000()
    {
      int randomWidth = 8000;
      int randomHeight = 8000;
      string rectangle = new PrintRectangleWithAsterisks().GetRectangleString(randomWidth, randomHeight);
      string expected = GetRectangleString(randomWidth, randomHeight);
      Assert.AreEqual(expected, rectangle);
    }

    [Test]
    public void TestRandomHeightAndWidth()
    {
      int randomWidth = new Random().Next(1, 8000);
      int randomHeight = new Random().Next(1, 8000);
      string rectangle = new PrintRectangleWithAsterisks().GetRectangleString(randomWidth, randomHeight);
      string expected = GetRectangleString(randomWidth, randomHeight);
      Assert.AreEqual(expected, rectangle);
    }

    private static string GetRectangleString(int width, int height)
    {
      StringBuilder result = new StringBuilder();
      for (int i = 0; i < height; i++)
      {
        result.Append("*");
        for (int j = 1; j < width - 1; j++)
          result.Append(IsFirstOrLastLine(height, i) ? "*" : " ");
        if (width > 1)
          result.Append("*");
        result.Append("\r\n");
      }
      return result.ToString();
    }

    private static bool IsFirstOrLastLine(int height, int lineIndex)
    {
      return lineIndex == 0 || lineIndex == height - 1;
    }
  }
}
