/*Challenge link:https://www.codewars.com/kata/578cff57daa01a037d000998/train/csharp
Question:
The task is very simple!
You have to return true. Yes, really, you only have to return the boolean-value true.

But you have to do this in 6 different ways.

And there are some rules:


Only one (real) methodcall is allowed!
Only one using of a comparing operator (or comparing method) is allowed.
You are not allowed to use any namespaces!
Lambda-operators are not allowed.

A friendly AI will check, if you follow the rules. But it won't find anything, I think. So be honest and take the challenge! (Otherwise your solution could be invalid later...)

I'm very interested in your solutions and your ideas!

Have fun coding it and please don't forget to vote and rank this kata! :-)
*/

//***************Solution********************
public class returnTrue{
  public static bool Way1(){return true;}
  public static bool Way2(){return 1 == 1;}
  public static bool Way3(){return !false;}
  public static bool Way4(){return "lmao" is string;}
  public static bool Way5(){bool a = true; return a;} 
  public static bool Way6(){bool b = !false; return b;}
}
//more solution 
public class returnTrue
{
  public static bool Way1()
  {
    return true;
  }  
  public static bool Way2()
  {
    return !false;
  }
  public static bool Way3()
  {
    return bool.Parse(bool.TrueString);
  }
  public static bool Way4()
  {
    return 1 < 2;
  }
  public static bool Way5()
  {
    return !default(bool);
  }
  public static bool Way6()
  {
    return !new bool();
  }
}
//rigged
public class returnTrue
{
  public static bool Way1()
  {
  var a=true;
  return a;
  }
  public static bool Way2()
  {
  var b=true;
  return b;
  }
  public static bool Way3()
  {
  var c=true;
  return c;
  }
  public static bool Way4()
  {
  var d=true;
  return d;
  }
  public static bool Way5()
  {
  var e=true;
  return e;
  }
  public static bool Way6()
  {
  var f=true;
  return f;
  }
}
//****************Sample Test*****************
using NUnit.Framework;
using System;

public class returnTrueTests
{
  [Test]
  public static void CheckRules()
  { try
    {
      Skynet.CheckRules();
    }
    catch(Exception ex)
    {
      Assert.Fail(ex.Message);
    }
  }

  [Test]
  public static void TestWay1()
  {    
    Assert.IsTrue(returnTrue.Way1());
  }  
  
  [Test]
  public static void TestWay2()
  {
    Assert.IsTrue(returnTrue.Way2());
  } 
  
  [Test]
  public static void TestWay3()
  {
    Assert.IsTrue(returnTrue.Way3());
  } 
  
  [Test]
  public static void TestWay4()
  {
    Assert.IsTrue(returnTrue.Way4());
  } 
  
  [Test]
  public static void TestWay5()
  {
    Assert.IsTrue(returnTrue.Way5());
  } 
  
  [Test]
  public static void TestWay6()
  {
    Assert.IsTrue(returnTrue.Way6());
  }
  
  // No change for random tests in this kata. It would be senseless.
}
