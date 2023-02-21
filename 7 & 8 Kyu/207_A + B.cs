/*Challenge link:https://www.codewars.com/kata/5512a0b0509063e57d0003f5/train/csharp
Question:
Vasya Pupkin just started learning Java and C#. At first, he decided to write simple program that was supposed to 
sum up two small numbers (numbers and their sum fit in a byte), but it didn't work. Vasya was too sad to find out what is wrong. Help him to correct the mistake.
*/

//***************Solution********************
//fixed bug by changing the method type to int.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
public class FirstClass {
    public static int sum (byte a, byte b) => a+b;
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;  

  [TestFixture]
  public class FirstClassTest 
  {
    [Test]
    public void testSum()
    {
        byte[] a = {1, 2, 3, 4, 5, 6, 7};
        byte[] b = {1, 3, 6, 8, 2, 5, 1};
        byte[] c = {2, 5, 9, 12, 7, 11, 8};
        for(int i = 0; i < c.Length; i++)
        {
            Assert.AreEqual(c[i], FirstClass.sum(a[i], b[i]));            
        }
    }
    
    [Test]
    public void testRandomSum()
    {
        Random rand = new Random(DateTime.Now.Second);
        byte a;
        byte b;
        for(int i = 0; i < 10; i++)
        {
            a = (byte) rand.Next(0, 128);
            b = (byte) rand.Next(0, 128 - a);
            Assert.AreEqual((byte) a + b, FirstClass.sum(a, b));
        }
    }
  }
}
