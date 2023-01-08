/*Challenge link:https://www.codewars.com/kata/569d488d61b812a0f7000015/train/csharp
Question:
A stream of data is received and needs to be reversed.

Each segment is 8 bits long, meaning the order of these segments needs to be reversed, for example:

11111111  00000000  00001111  10101010
 (byte1)   (byte2)   (byte3)   (byte4)
should become:

10101010  00001111  00000000  11111111
 (byte4)   (byte3)   (byte2)   (byte1)
The total number of bits will always be a multiple of 8.

The data is given in an array as such:

[1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,0,1,0,1,0,1,0]
Note: In the C and NASM languages you are given the third parameter which is the number of segment blocks.
*/

//***************Solution********************
//solution 1
using System.Linq;
public class Kata{
  public static int[] DataReverse(int[] data){
    var str = string.Concat(data);                        //join data elements together
    
    return  Enumerable
            .Range(0, str.Length / 8)
            .Select(i => str.Substring(i * 8, 8))         //split string into 8 bits/character element
            .Reverse()                                    //reverse the elements
            .Aggregate((current, next) => current + next) //join the elements together 
            .Select(a => a - '0')                         //convert char array to int using ASCII
            .ToArray();
  }
}

//solution 2
using System.Linq;
  public class Kata
  {
    public static int[] DataReverse(int[] data) =>
       Enumerable.Range(0,data.Length/8)
         .Select(i => data
           .Skip(i*8)
           .Take(8))
         .Reverse()
         .SelectMany(i => i)
         .ToArray();
  }
  
  //solution 3
  using System;
public class Kata
{
  public static int[] DataReverse(int[] data)
  {
     int[] bits = data;

     for(int i = 0; i < data.Length; i+=8)
     {
       Array.Reverse(bits, i, 8);
     }
     
     Array.Reverse(bits);
     
     return bits;
  }
}

//****************Sample Test*****************
namespace Main{

using System;
using NUnit.Framework;

[TestFixture]
public static class Tests {

[Test]
    public static void test1() {
        int[] data1= new int [32] {1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,0,1,0,1,0,1,0};
        int[] data2= new int [32] {1,0,1,0,1,0,1,0,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1};
        Assert.AreEqual(data2,Kata.DataReverse(data1));
    }
[Test]
    public static void test2() {
        int[] data1= new int [8] {1,0,1,1,1,0,1,0};
        int[] data2= new int [8] {1,0,1,1,1,0,1,0};
        Assert.AreEqual(data2,Kata.DataReverse(data1));
    }
[Test]
    public static void test3() {
        int[] data1= new int [400];
        int[] data2= new int [400];
        Random rnd1 = new Random();
        for(int i=0;i<400;i++)
        {
          data1[i]=rnd1.Next()%2;
        }
        int segments=400/8;
        for(int i=0;i<segments;i++)
        {
          for(int k=0;k<8;k++)
          {
             data2[k+(i*8)]=data1[k+((segments-i-1)*8)]; 
          } 
        }
        
        Assert.AreEqual(data2,Kata.DataReverse(data1));
    }
[Test]
    public static void test4() {
        int[] data1= new int [400];
        int[] data2= new int [400];
        Random rnd1 = new Random();
        for(int i=0;i<400;i++)
        {
          data1[i]=rnd1.Next()%2;
        }
        int segments=400/8;
        for(int i=0;i<segments;i++)
        {
          for(int k=0;k<8;k++)
          {
             data2[k+(i*8)]=data1[k+((segments-i-1)*8)]; 
          } 
        }
        
        Assert.AreEqual(data2,Kata.DataReverse(data1));
    }
[Test]
    public static void test5() {
        int[] data1= new int [400];
        int[] data2= new int [400];
        Random rnd1 = new Random();
        for(int i=0;i<400;i++)
        {
          data1[i]=rnd1.Next()%2;
        }
        int segments=400/8;
        for(int i=0;i<segments;i++)
        {
          for(int k=0;k<8;k++)
          {
             data2[k+(i*8)]=data1[k+((segments-i-1)*8)]; 
          } 
        }
        
        Assert.AreEqual(data2,Kata.DataReverse(data1));
    }
[Test]
    public static void test6() {
        int[] data1= new int [400];
        int[] data2= new int [400];
        Random rnd1 = new Random();
        for(int i=0;i<400;i++)
        {
          data1[i]=rnd1.Next()%2;
        }
        int segments=400/8;
        for(int i=0;i<segments;i++)
        {
          for(int k=0;k<8;k++)
          {
             data2[k+(i*8)]=data1[k+((segments-i-1)*8)]; 
          } 
        }
        
        Assert.AreEqual(data2,Kata.DataReverse(data1));
    }
  }
}
