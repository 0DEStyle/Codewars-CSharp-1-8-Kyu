/*Challenge link:https://www.codewars.com/kata/566be96bb3174e155300001b/train/csharp
Question:
You throw a ball vertically upwards with an initial speed v (in km per hour). The height h of the ball at each time t is given by h = v*t - 0.5*g*t*t where g is Earth's gravity (g ~ 9.81 m/s**2). A device is recording at every tenth of second the height of the ball. For example with v = 15 km/h the device gets something of the following form: (0, 0.0), (1, 0.367...), (2, 0.637...), (3, 0.808...), (4, 0.881..) ... where the first number is the time in tenth of second and the second number the height in meter.

Task
Write a function max_ball with parameter v (in km per hour) that returns the time in tenth of second of the maximum height recorded by the device.

Examples:
max_ball(15) should return 4

max_ball(25) should return 7

Notes
Remember to convert the velocity from km/h to m/s or from m/s in km/h when necessary.
The maximum height recorded by the device is not necessarily the maximum height reached by the ball.
*/

//***************Solution********************


/*
v0 velocity (km per hour)
g ~= 9.81 (m/s^2)

Simplification 
  ((v0 * 1000) / (3600 * 9.81)) * 10 
= v0 * 10000 / 35316 
= v0 / 3.5316

Rounds a value to the nearest integer, convert to int and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
*/
using static System.Math;

public class Ball {
    public static int MaxBall(int v0)  => (int)Round(v0 / 3.5316);
}

//solution 2
using System;

public class Ball 
{
	
    public static int MaxBall(int v0) 
    {
        double v = v0/3.6;
        double g = 9.81/10.0;
        return (int)Math.Round(v/g);
    }
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public static class BallTests {

    private static Random rnd = new Random();
    private static void testing(int actual, int expected) 
    {
        Assert.AreEqual(expected, actual);
    }

[Test]
    public static void test1() 
    {
        testing(Ball.MaxBall(37), 10);
        testing(Ball.MaxBall(45), 13);
        testing(Ball.MaxBall(99), 28);
        testing(Ball.MaxBall(85), 24);
        testing(Ball.MaxBall(136), 39);
        testing(Ball.MaxBall(52), 15);
        testing(Ball.MaxBall(16), 5);
        testing(Ball.MaxBall(127), 36);
        testing(Ball.MaxBall(137), 39);
        testing(Ball.MaxBall(14), 4);   
    }
    
    //-----------------------
    private static int MaxBallSol(int v0) 
    {
        double g = 9.81, mx = -1, t = 0, t1 = 0, v = v0 * 1000 / 3600.0;
        while (true) 
        {
            double h = v*t - 0.5*g*t*t;
            if (h > mx) 
            {
                mx = h;
                t1 = t;
            } else
                break;
            t += 0.1;
        }
        return (int)Math.Round(t1*10);
        // function could have directly returned : round(v0 / 3.5316)
    }
    
    //-----------------------
[Test]    
    public static void RandomTest() 
    {
        Console.WriteLine("100 Random Tests: MaxBall");
        for (int i = 0; i < 100; i++) 
        { 
            int n = rnd.Next(2, 250); 
            testing(Ball.MaxBall(n), MaxBallSol(n));
        }
    }  
    
}
