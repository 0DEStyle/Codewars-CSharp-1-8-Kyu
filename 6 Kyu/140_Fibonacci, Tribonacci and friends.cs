/*Challenge link:https://www.codewars.com/kata/556e0fccc392c527f20000c5/train/csharp
Question:
If you have completed the Tribonacci sequence kata, you would know by now that mister Fibonacci has at least a bigger brother. If not, give it a quick look to get how things work.

Well, time to expand the family a little more: think of a Quadribonacci starting with a signature of 4 elements and each following element is the sum of the 4 previous, a Pentabonacci (well Cinquebonacci would probably sound a bit more italian, but it would also sound really awful) with a signature of 5 elements and each following element is the sum of the 5 previous, and so on.

Well, guess what? You have to build a Xbonacci function that takes a signature of X elements - and remember each next element is the sum of the last X elements - and returns the first n elements of the so seeded sequence.

xbonacci {1,1,1,1} 10 = {1,1,1,1,4,7,13,25,49,94}
xbonacci {0,0,0,0,1} 10 = {0,0,0,0,1,1,2,4,8,16}
xbonacci {1,0,0,0,0,0,1} 10 = {1,0,0,0,0,0,1,2,3,6}
xbonacci {1,1} produces the Fibonacci sequence
*/

//***************Solution********************
using System.Linq;
using System.Collections.Generic;

public class Xbonacci{
  public double[] xbonacci(double[] signature, int n){
    //double List to store signature result
    var result = new List<double>(signature);

    //while result count is less than n(n bonacci),
    //add new result: from result, take last using signature.Length, sum all the elements together.
    while (result.Count < n)
        result.Add(result.TakeLast(signature.Length).Sum());

    //returns the first n elements of the so seeded sequence.
    return result.Take(n).ToArray();
  }
}

//****************Sample Test*****************
using NUnit.Framework;
using System;

[TestFixture]
public class XbonacciTest
{
  private Xbonacci variabonacci;
  
  [SetUp]
  public void SetUp() 
  {
    variabonacci = new Xbonacci();
  }

  [TearDown]
  public void TearDown()
  {
    variabonacci = null;
  }

  [Test]
  public void BasicTests()
  {
    Assert.AreEqual(new double []{0,1,1,2,3,5,8,13,21,34}, variabonacci.xbonacci(new double []{0,1},10));
    Assert.AreEqual(new double []{1,1,2,3,5,8,13,21,34,55}, variabonacci.xbonacci(new double []{1,1},10));
    Assert.AreEqual(new double []{0,0,0,0,1,1,2,4,8,16}, variabonacci.xbonacci(new double []{0,0,0,0,1},10));
    Assert.AreEqual(new double []{1,0,0,0,0,0,1,2,3,6}, variabonacci.xbonacci(new double []{1,0,0,0,0,0,1},10));
    Assert.AreEqual(new double []{1,0,0,0,0,0,0,0,0,0,1,1,2,4,8,16,32,64,128,256}, variabonacci.xbonacci(new double []{1,0,0,0,0,0,0,0,0,0},20));
    Assert.AreEqual(new double []{0.5,0,0,0,0,0,0,0,0,0}, variabonacci.xbonacci(new double []{0.5,0,0,0,0,0,0,0,0,0},10));
    Assert.AreEqual(new double []{0.5,0,0,0,0,0,0,0,0,0,0.5,0.5,1,2,4,8,16,32,64,128}, variabonacci.xbonacci(new double []{0.5,0,0,0,0,0,0,0,0,0},20));
    Assert.AreEqual(new double []{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, variabonacci.xbonacci(new double []{0,0,0,0,0,0,0,0,0,0},20));
    Assert.AreEqual(new double []{1,2,3,4,5,6,7,8,9}, variabonacci.xbonacci(new double []{1,2,3,4,5,6,7,8,9,0},9));
    Assert.AreEqual(new double []{}, variabonacci.xbonacci(new double []{1,2,3,4,5,6,7,8,9,0},0));
  }

  [Test]
  public void RandomTests()
  {
    Random r = new Random();
    double[] sign;
    int n, signlen = r.Next(1, 20);
    for(int i = 0; i < 40; i++) {
        sign = new double[signlen];
        for(int j = 0; j < signlen; j++)
          sign[j] = r.Next(0, 20);
        n = r.Next(0, 50) + signlen;

        Console.WriteLine("Testing for signature: " + string.Join(", ", sign) + " and n: " + n);
        Assert.AreEqual(Soluzionacci(sign, n), variabonacci.xbonacci(sign, n), "It should work with random inputs too");        
    }
  }
  
  private double[] Soluzionacci(double[] s, int n)
  {
    double[] res = new double[n];
    double sum = 0;
    Array.Copy(s, res, Math.Min(s.Length, n));
    
    for(int i = s.Length; i < n; i++)
    {
      sum = 0;
      for(int j = 1; j <= s.Length; j++)
        sum += res[i - j];
      res[i] = sum;
    }
    
    return res;
  }  
}
