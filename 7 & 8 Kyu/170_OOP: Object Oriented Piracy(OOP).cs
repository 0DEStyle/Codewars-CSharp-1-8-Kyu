/*Challenge link:https://www.codewars.com/kata/54fe05c4762e2e3047000add/train/csharp
Question:
Ahoy matey!

You are a leader of a small pirate crew. And you have a plan. With the help of OOP you wish to make a pretty efficient system to identify ships with heavy booty on board!

Unfortunately for you, people weigh a lot these days, so how do you know if a ship is full of gold and not people?

You begin with writing a generic Ship class / struct:

public class Ship
{
  public int Draft;
  public int Crew;
  
  public Ship(int draft, int crew)
  {
    Draft = draft;
    Crew = crew;
  }
}
Every time your spies see a new ship enter the dock, they will create a new ship object based on their observations:

draft - an estimate of the ship''s weight based on how low it is in the water
crew - the count of crew on board
Ship titanic = new Ship(15, 10);
Task
You have access to the ship "draft" and "crew". "Draft" is the total ship weight and "crew" is the number of humans on the ship.

Each crew member adds 1.5 units to the ship draft. If after removing the weight of the crew, the draft is still more than 20, then the ship is worth looting. Any ship weighing that much must have a lot of booty!

Add the method

IsWorthIt
to decide if the ship is worthy to loot. For example:

titanic.IsWorthIt() => false
Good luck and may you find GOOOLD!


*/

//***************Solution********************
public class Ship{
  public int Crew;
  public int Draft;
  
  public Ship(int draft, int crew){
    Draft = draft;
    Crew = crew;
  }
  public bool IsWorthIt() => Draft - Crew * 1.5f > 20;
  
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  
  public class MyShip
  {
    public int Draft;
    public int Crew;
    
    public MyShip(int draft, int crew)
    {
      Draft = draft;
      Crew = crew;
    }
    
    public bool IsWorthIt() => this.Draft - (this.Crew * 1.5) > 20;
  }

  [TestFixture]
  public class Sample_Test
  {
    [Test]
    public void SampleTest()
    {
      Ship titanic = new Ship(15, 10);
    
      Assert.AreEqual(false, titanic.IsWorthIt());
      
      // Mutation tests
      Assert.AreEqual(15, titanic.Draft, "Do you need two eyepatches, mate? That ship is clearly 15 draft deep.");
      Assert.AreEqual(10, titanic.Crew, "Do you need two eyepatches, mate? That ship clearly has a crew of 10 people.");
    }
  }
  
  [TestFixture]
  public class A_Small_Grouping_Of_Fixed_Ships
  {
    private static int[][] testCases = new int[][]
    {
      new int[] {0, 0},
      new int[] {15, 20},
      new int[] {35, 20},
      new int[] {55, 20}
    };
    
    [Test, TestCaseSource("testCases")]
    public void Test(int[] test)
    {
      int draft = test[0];
      int crew = test[1];
      
      Ship ship = new Ship(draft, crew);
      MyShip myShip = new MyShip(draft, crew);
      
      Assert.AreEqual(myShip.IsWorthIt(), ship.IsWorthIt());
      
      Assert.AreEqual(myShip.Draft, ship.Draft, String.Format("Do you need two eyepatches, mate? That ship is clearly {0} draft deep.", myShip.Draft));
      Assert.AreEqual(myShip.Crew, ship.Crew, String.Format("Do you need two eyepatches, mate? That ship clearly has a crew of {0} {1}.", myShip.Crew, myShip.Crew == 1 ? "person" : "people"));
    }
  }
  
  [TestFixture]
  public class A_Large_Fleet_Of_Random_Ships
  {
    private static Random rnd = new Random();
    
    [Test, Description("Random Tests")]
    public void RandomTests()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        int draft = rnd.Next(50, 150);
        int crew = rnd.Next(20, 120);
        
        Ship ship = new Ship(draft, crew);
        MyShip myShip = new MyShip(draft, crew);
        
        Assert.AreEqual(myShip.IsWorthIt(), ship.IsWorthIt());
        
        Assert.AreEqual(myShip.Draft, ship.Draft, String.Format("Do you need two eyepatches, mate? That ship is clearly {0} draft deep.", myShip.Draft));
        Assert.AreEqual(myShip.Crew, ship.Crew, String.Format("Do you need two eyepatches, mate? That ship clearly has a crew of {0} {1}.", myShip.Crew, myShip.Crew == 1 ? "person" : "people"));
      }
    }
  }
} 
