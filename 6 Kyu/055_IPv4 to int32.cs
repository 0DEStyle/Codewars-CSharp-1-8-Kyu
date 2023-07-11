/*Challenge link:https://www.codewars.com/kata/52ea928a1ef5cfec800003ee/train/csharp
Question:
Take the following IPv4 address: 128.32.10.1. This address has 4 octets where each octet is a single byte (or 8 bits).

1st octet 128 has the binary representation: 10000000
2nd octet 32 has the binary representation: 00100000
3rd octet 10 has the binary representation: 00001010
4th octet 1 has the binary representation: 00000001
So 128.32.10.1 == 10000000.00100000.00001010.00000001

Because the above IP address has 32 bits, we can represent it as the 32 bit number: 2149583361.

Write a function ip_to_int32(ip) ( JS: ipToInt32(ip) ) that takes an IPv4 address and returns a 32 bit number.

Example
"128.32.10.1" => 2149583361
*/

//***************Solution********************
//split the string by '.'
//convert each element to unsigned 32 bit int
//aggregate, current element x * 256 + next index
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;
public class IPConvert
{
  public static uint ToInt32(string ip) => 
    ip.Split('.').Select(n => UInt32.Parse(n)).Aggregate((x, i) => x * 256 + i);
}

//****************Sample Test*****************
using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

[TestFixture]
public class IPConverterTest
{
	[Test]
	public void FixedTests()
  {
    DoTest("128.32.10.1",  2149583361);
    DoTest("0.0.0.0",               0);
    DoTest("9.87.123.245",  156728309);
  }
  
  [Test]
	public void RandomTests()
  {
    var nibbles = 
      Shuffle(
        Enumerable
        .Range(0, 256)
        .Concat(Enumerable.Range(0, 256))
        .Select(n => (uint)n)
        .ToList());
    
    for(int i=0; i<nibbles.Count; i+=4) {
      uint a = nibbles[i+0];
      uint b = nibbles[i+1];
      uint c = nibbles[i+2];
      uint d = nibbles[i+3];
      
      // Make sure that uints with MSB set to 1 are also tested
      if(i >= 100) {
        a |= 1 << 7;
      }
      
      string input = $"{a}.{b}.{c}.{d}";
      uint expected = (a << 24) | (b << 16) | (c << 8) | d;
      DoTest(input, expected);
    }
    
    DoTest("128.32.10.1",  2149583361);
    DoTest("0.0.0.0",               0);
    DoTest("9.87.123.245",  156728309);
  }
  
  private static Random rnd = new Random();
  
  private List<T> Shuffle<T>(List<T> ns) {
    return 
      ns.Select(n => (n, rnd.Next()))
      .OrderBy(e => e.Item2)
      .Select(e => e.Item1)
      .ToList();
  }
  
  private void DoTest(string ip, uint expected) {
    Assert.AreEqual(expected, IPConvert.ToInt32(ip), $"Incorrect answer for ip = \"{ip}\"" );
  }
}
