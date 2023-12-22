/*Challenge link:https://www.codewars.com/kata/5834fec22fb0ba7d080000e8/train/csharp
Question:
Story:
You are going to make toast fast, you think that you should make multiple pieces of toasts and once. So, you try to make 6 pieces of toast.

Problem:
You forgot to count the number of toast you put into there, you don't know if you put exactly six pieces of toast into the toasters.

Define a function that counts how many more (or less) pieces of toast you need in the toasters. Even though you need more or less, the number will still be positive, not negative.

Examples:
You must return the number of toast the you need to put in (or to take out). In case of 5 you can still put 1 toast in:

six_toast(5) == 1
And in case of 12 you need 6 toasts less (but not -6):

six_toast(12) == 6
Good luck!
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression w
//get the absolute value of num - 6
using static System.Math;
public class Kata{
  public static int SixToast(int num) => Abs(num - 6);
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SampleTest
  {
    [Test]
    public void Test()
    {
      Assert.AreEqual(0, Kata.SixToast(6));
      Assert.AreEqual(11, Kata.SixToast(17));
      Assert.AreEqual(3, Kata.SixToast(3));
    }
  }
  
  [TestFixture]
  public class FixedTest
  {
    [Test]
    public void Test()
    {
      Assert.AreEqual(2, Kata.SixToast(4));
      Assert.AreEqual(10, Kata.SixToast(16));
      Assert.AreEqual(5, Kata.SixToast(1));
      Assert.AreEqual(6, Kata.SixToast(0));
    }
  }
  
  [TestFixture]
  public class RandomTest
  {
    private static Random rnd = new Random();
    
    private static int solution(int num) => Math.Abs(num - 6);
    
    [Test]
    public void Test()
    {
      const int Tests = 1000;
      
      for (int i = 0; i < Tests; ++i)
      {
        int num = rnd.Next(0, 300);
        
        int expected = solution(num);
        int actual = Kata.SixToast(num);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
