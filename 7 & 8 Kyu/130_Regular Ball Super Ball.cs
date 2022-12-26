/*Challenge link:https://www.codewars.com/kata/53f0f358b9cb376eca001079/train/csharp
Question:
Create a class Ball. Ball objects should accept one argument for "ball type" when instantiated.

If no arguments are given, ball objects should instantiate with a "ball type" of "regular."

ball1 = new Ball();
ball2 = new Ball("super");

ball1.ballType     //=> "regular"
ball2.ballType     //=> "super"
*/

//***************Solution********************
//set default ballType as "regular", then set ballType to whatever the user enters.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Ball {
  public string ballType { get; set; }
  public Ball(string ballType = "regular")=> this.ballType = ballType;
}


//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class FactorialTests {
  [Test]
  public void DefaultConstructorShouldSetBallTypeToRegular() {
    Assert.AreEqual("regular", new Ball().ballType);
  }
  
  [Test]
  public void ConstructorWithArgumentShouldSetBallTypeAsExpected() {
    Assert.AreEqual("super", new Ball("super").ballType);
  }
}
