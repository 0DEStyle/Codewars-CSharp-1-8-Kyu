/*Challenge link:https://www.codewars.com/kata/515e188a311df01cba000003/train/csharp
Question:
The function is not returning the correct values. Can you figure out why?

Example (Input --> Output ):

3 --> "Earth"

*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//added break and initiated name
public class Kata
{
  public static string GetPlanetName(int id)
  {
    string name = "";
    switch(id)
    {
      case 1:
        name = "Mercury"; break;
      case 2:
        name = "Venus"; break;
      case 3:
        name = "Earth"; break;
      case 4:
        name = "Mars"; break;
      case 5:
        name = "Jupiter"; break;
      case 6:
        name = "Saturn"; break;
      case 7:
        name = "Uranus"; break;
      case 8:
        name = "Neptune"; break;
    }
    
    return name;
  }
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    private static Random rnd = new Random();
  
    private static string solution(int id) => new string[] {"Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune"}[--id];
  
    [Test, Description("Random Tests")]
    public void Test()
    {
      for (int i = 0; i < 100; ++i)
      {
        int test = rnd.Next(1, 9);
        string expected = solution(test);
        string actual = Kata.GetPlanetName(test);
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
