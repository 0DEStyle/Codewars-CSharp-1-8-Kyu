/*Challenge link:https://www.codewars.com/kata/5544c7a5cb454edb3c000047/train/csharp
Question:
A child is playing with a ball on the nth floor of a tall building. The height of this floor, h, is known.

He drops the ball out of the window. The ball bounces (for example), to two-thirds of its height (a bounce of 0.66).

His mother looks out of a window 1.5 meters from the ground.

How many times will the mother see the ball pass in front of her window (including when it's falling and bouncing?

Three conditions must be met for a valid experiment:
Float parameter "h" in meters must be greater than 0
Float parameter "bounce" must be greater than 0 and less than 1
Float parameter "window" must be less than h.
If all three conditions above are fulfilled, return a positive integer, otherwise return -1.

Note:
The ball can only be seen if the height of the rebounding ball is strictly greater than the window parameter.

Examples:
- h = 3, bounce = 0.66, window = 1.5, result is 3

- h = 3, bounce = 1, window = 1.5, result is -1 

(Condition 2) not fulfilled).

*/

//***************Solution********************

//check if condition met, if not return -1
//if height is greater than window, count +1
//on the second bounce, if height is greater than window, count +1
//return the result
public class BouncingBall {
	
	public static int bouncingBall(double h, double bounce, double window) {
    int ans = 0;
    if (h > 0 && bounce > 0 && bounce < 1 && window < h){
      while (h > window){
        ans++;
        h = h * bounce;
        if(h > window)
        ans++;
    }
    }
    else
      return -1;
    return ans;
	}
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class BouncingBallTests {

[Test]
  public void Test0() {
    Assert.AreEqual(1, BouncingBall.bouncingBall(2.0, 0.5, 1));
  }
[Test]
  public void Test1() {
    Assert.AreEqual(3, BouncingBall.bouncingBall(3.0, 0.66, 1.5));
  }
[Test]
  public void Test2() {
    Assert.AreEqual(15, BouncingBall.bouncingBall(30.0, 0.66, 1.5));
  }
[Test]
  public void Test3() {
    Assert.AreEqual(21, BouncingBall.bouncingBall(30, 0.75, 1.5));
  }
[Test]
  public void Test4() {
    Assert.AreEqual(3, BouncingBall.bouncingBall(30, 0.4, 10));
  }
[Test]
  public void Test5() {
    Assert.AreEqual(3, BouncingBall.bouncingBall(40, 0.4, 10));
  }
[Test]
  public void Test6() {
    Assert.AreEqual(-1, BouncingBall.bouncingBall(10, 0.6, 10));
  }
[Test]
  public void Test7() {
    Assert.AreEqual(-1, BouncingBall.bouncingBall(40, 1, 10));
  }
[Test]
  public void Test8() {
    Assert.AreEqual(-1, BouncingBall.bouncingBall(-5, 0.66, 1.5));
  }
[Test]
  public void Test9() {
    Assert.AreEqual(-1, BouncingBall.bouncingBall(5, -1, 1.5));
  }

public static int bouncingBallTest(double h, double bounce, double window) {
    if ((h <= 0) || (window >= h) || (bounce <= 0) || (bounce >= 1))
        return -1;
    int seen = -1;
    while (h > window) {
        seen += 2;
        h = h * bounce;
    }
    return seen;
  }
    
[Test]
  public void RandomTests() {
    Random rnd = new Random();
    double[] someheights = new double[] {12, 10.5, 144, 233, 15.25, 61, 98, 15.9, 25.8, 41.8, 67,
                            109, 17, 28, 46, 7.5, 12.20, 19, 3, 5,
                            83, 13, 21, 35.5, 57, 92, 14,
                            24, 39, 6.5};
    double[] someBounces = new double[] {0.6, 0.6, 0.6, 0.6, 0.6, 1.1, 9, 1, 0.6, 0.6, 0.6,
                          0.75, 0.75, 0.75, 0.75, 0.75, 12.20, 0.75, 0.75,
                          0.83, 0.13, 0.21, 0.35, 0.57, 0.9, 0.14,
                          0.24, 0.39, 0.65, 0.65};
    double[] somewin     = new double[] {1.5, 1.5, 1.44, 2.33, 1, 6.1, 9.8, 1.9, 2.8, 4.8, 3,
                          1.09, 1.7, 2.8, 46, 7.5, 12.20, 1.9, 3, 5,
                          0.83, 1.3, 2.1, 3.5, 0.57, 0.92, 1.4,
                          2.4, 3.9, 6.5};
                         
    for (int k = 0; k < 10; k++) {
        int rn = rnd.Next(0, someheights.Length - 1);
        double f1 = someheights[rn]; 
        double f2 = someBounces[rn];
        double f3 = somewin[rn];
        Console.WriteLine("Random test " + k);
        Assert.AreEqual(BouncingBallTests.bouncingBallTest(f1, f2, f3), BouncingBall.bouncingBall(f1, f2, f3));
    }
  }
}
