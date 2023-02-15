/*Challenge link:https://www.codewars.com/kata/547274e24481cfc469000416/train/csharp
Question:
According to the creation myths of the Abrahamic religions, Adam and Eve were the first Humans to wander the Earth.

You have to do God's job. The creation method must return an array of length 2 containing objects (representing Adam and Eve).
The first object in the array should be an instance of the class Man. The second should be an instance of the class Woman. 
Both objects have to be subclasses of Human. Your job is to implement the Human, Man and Woman classes.

*/

//***************Solution********************
//Create a class Human
//and from Human create 2 subclasses, Man and Woman

//Create new Human Array where [0] is Man and [1] is Woman
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class God{
  public static Human[] Create() => new Human[] {new Man(), new Woman()};
}
public class Human {}
public class Man : Human {}
public class Woman : Human {}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void SampleTest()
    {
      Human[] humans = God.Create();
      Assert.That(humans[0] is Man, "The first object in the array should be a Man");
      Assert.That(humans[1] is Woman, "The second object in the array should be a Woman");
      Assert.That(humans[0] is Human, "The first object in the array should be a Human");
      Assert.That(humans[1] is Human, "The second object in the array should be a Human");
      Assert.AreEqual(2, humans.Length, "The array should only contain two humans"); 
    }
  }
}
