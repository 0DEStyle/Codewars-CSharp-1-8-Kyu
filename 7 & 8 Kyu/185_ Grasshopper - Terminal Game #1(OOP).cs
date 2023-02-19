/*Challenge link:https://www.codewars.com/kata/55e8aba23d399a59500000ce/train/csharp
Question:
Terminal Game - Create Hero Class
In this first kata in the series, you need to define a Hero class to be used in a terminal game. The hero should have the following attributes:

attribute	type	value
Name	string	user argument or "Hero"
Position	string	"00"
Health	float	100
Damage	float	5
Experience	int	0
*/

//***************Solution********************
//create a class name Hero
//then create getters and setters for Position, Health, Damage, Experience and Name
//the default value for Hero is "Hero", and it can take 1 argument from user

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Hero{
  public string Position {get; set;} = "00";
  public float Health {get; set;} = 100;
  public float Damage {get; set;} = 5;
  public int Experience {get; set;} = 0;
  public string Name {get; set;}
  
  public Hero(string name = "Hero") => this.Name = name;
}


//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class Hero_Class
  {
    [Test, Description("Hero should create a Hero")]
    public void InitTest()
    {
      Hero myHero = new Hero();
      Assert.AreEqual("Hero", myHero.Name);
      Assert.AreEqual(0, myHero.Experience);
      Assert.AreEqual(100, myHero.Health);
      Assert.AreEqual("00", myHero.Position);
      Assert.AreEqual(0, myHero.Experience);
    }
    
    #pragma warning disable CS0183
    [Test, Description("Hero should have appropriate types for its properties")]
    public void TypeTest()
    {
      Hero myHero = new Hero();
      Assert.That(myHero.Damage is float, "Damage should be a float");
      Assert.That(myHero.Health is float, "Health should be a float");
      Assert.That(myHero.Experience is int, "Experience should be an int");
    }
    #pragma warning restore CS0183
    
    [Test, Description("Hero should use a name argument")]
    public void ArgTest()
    {
      Hero myHero = new Hero("Keith Helm");
      Assert.AreEqual("Keith Helm", myHero.Name);
    }
  }
}
