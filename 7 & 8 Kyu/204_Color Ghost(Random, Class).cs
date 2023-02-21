/*Challenge link:https://www.codewars.com/kata/53f1015fa9fe02cbda00111a/train/csharp
Question:
Color Ghost
Create a class Ghost

Ghost objects are instantiated without any arguments.

Ghost objects are given a random color attribute of "white" or "yellow" or "purple" or "red" when instantiated

ghost = new Ghost();
ghost.color //=> "white" or "yellow" or "purple" or "red"

*/

//***************Solution********************
//create a string array named colors
//create a string variable named color

//store random color from colors in color
//when GetColor() is called, return color
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;

public class Ghost
{
  private static string[] colors = {"white","yellow","purple","red"};
  private string color;
    
  public Ghost()=> color = colors[new Random().Next(colors.Length)];
  public string GetColor() => color;
}

//****************Sample Test*****************
using System;
using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class GhostTests
{
  private Dictionary<string, string> GhostColors = new Dictionary<string, string>();
  
  public GhostTests()
  {
    for(int i = 0; i < 10000; i++)
    {
      string c = new Ghost().GetColor();
      if(!GhostColors.ContainsKey(c))
      {
        GhostColors.Add(c, "");
      }
    }
  }
  
  private bool GhostColor(Dictionary<string, string> arr, string c)
  {
    return arr.ContainsKey(c);
  }
  
  [Test]
  public void ShouldSometimesMakeWhiteGhosts()
  {
    Assert.AreEqual(true, GhostColor(GhostColors, "white"));
  }
  
  [Test]
  public void ShouldSometimesMakeYellowGhosts()
  {
    Assert.AreEqual(true, GhostColor(GhostColors, "yellow"));
  }
  
  [Test]
  public void ShouldSometimesMakePurpleGhosts()
  {
    Assert.AreEqual(true, GhostColor(GhostColors, "purple"));
  }
  
  [Test]
  public void ShouldSometimesMakeRedGhosts()
  {
    Assert.AreEqual(true, GhostColor(GhostColors, "red"));
  }
}
