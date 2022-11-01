/*Challenge link:https://www.codewars.com/kata/52e88b39ffb6ac53a400022e/train/csharp
Question:
Take the following IPv4 address: 128.32.10.1

This address has 4 octets where each octet is a single byte (or 8 bits).

1st octet 128 has the binary representation: 10000000
2nd octet 32 has the binary representation: 00100000
3rd octet 10 has the binary representation: 00001010
4th octet 1 has the binary representation: 00000001
So 128.32.10.1 == 10000000.00100000.00001010.00000001

Because the above IP address has 32 bits, we can represent it as the unsigned 32 bit number: 2149583361

Complete the function that takes an unsigned 32 bit number and returns a string representation of its IPv4 address.

Examples
2149583361 ==> "128.32.10.1"
32         ==> "0.0.0.32"
0          ==> "0.0.0.0"
*/

//***************Solution********************
//solution 1
//binary bit wise: 0000 0000 0000 0000 0000 0000 0000 0000
//hex: FF FF FF FF
// >> ip 24 bits bitwise right shift AND 1111
// >> ip 16 bits bitwise right shift AND 1111
// >> ip 8 bits bitwise right shift AND 1111
// >> ip  AND 1111
//join result with '.' and returnt the string as a result
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

public class Kata{
  public static string UInt32ToIP(uint ip) =>
    string.Join(".", new byte[] {
                (byte)((ip>>24) & 0xFF) ,
                (byte)((ip>>16) & 0xFF) ,
                (byte)((ip>>8)  & 0xFF) ,
                (byte)( ip & 0xFF)});
}

//solution2

using System.Net;

public class Kata
{
  public static string UInt32ToIP(uint ip) => IPAddress.Parse(ip.ToString()).ToString();
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class Sample_Test
  {
    [Test, Description("Sample Tests")]
    public void Test()
    {
      Assert.AreEqual("128.114.17.104", Kata.UInt32ToIP(2154959208));
      Assert.AreEqual("0.0.0.0", Kata.UInt32ToIP(0));
      Assert.AreEqual("128.32.10.1", Kata.UInt32ToIP(2149583361));
    }
  }
  
  [TestFixture]
  public class Random_Test
  {
    private static Random random = new Random();
    
    private static string solution(uint ip)
    {
      return (ip >> 24) % 256 + "." +
             (ip >> 16) % 256 + "." +
             (ip >> 8)  % 256 + "." +
             (ip)       % 256;
    }
    
    [Test, Description("Random Tests")]
    public void Test()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        uint thirtyBits = (uint) random.Next(1 << 30);
        uint twoBits = (uint) random.Next(1 << 2);
        uint fullRange = (thirtyBits << 2) | twoBits;
        
        string expected = solution(fullRange);
        string actual = Kata.UInt32ToIP(fullRange);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
