/*Challenge link:https://www.codewars.com/kata/6446c0fe4e259c006511b75e/train/csharp
Question:
Given 8 byte variable (Uint64) extract length of bits starting from least significant bit* and skipping offset of bits.

All input values will be non-negative.

Examples

input	offset	length	result
0xAF	4	0	0x0
0xAF	0	4	0xF
0xAF	4	4	0xA
0xAB00EF	4	16	0xB00E
0xAA00BB00CC	0xF0000000	0x64	0x0
*LSb - Least Significant bit - bit denoting smallest value in the number i.e. 0 or 1.
*/

//***************Solution********************
/*
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨⬛⬜🟨🟨🟨🟨🟨⬛⬜🟨
🟨⬛⬛🟨🟨🟨🟨🟨⬛⬛🟨
🟨⬛⬛🟨🟨⬛🟨🟨⬛⬛🟨
🟥🟨🟨🟨🟨🟨🟨🟨🟨🟨🟥
🟥🟥🟨🟨🟨⬛🟨🟨🟨🟥🟥
🟥🟥🟨🟨⬛🟨⬛🟨🟨🟥🟥
🟥🟨🟨🟨🟨🟨🟨🟨🟨🟨🟥
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
*/
//ref: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators

using System;
public static class Kata {
  public static ulong ExtractBits(ulong field, uint offset, uint length){
    //unsigned long for mask
    ulong mask = 0;
    
    //if offset is less than 64, 
    //field bit shift to right by offset
    if(offset < 64)
      mask = field >> (int) offset;
    
    //if length is less than 64, mask AND with (ulong)((1 << (int) length) - 1)
    //else just return mask;
    return length < 64 ? mask & (ulong)((1 << (int) length) - 1) :
                         mask;
  }
}

//solution 2
using System;
public static class Kata
{
    public static ulong ExtractBits(ulong field, uint offset, uint length)
        => (offset >= 64 ? 0ul : (field >> (int) offset)) & (length >= 64 ? ulong.MaxValue : (1UL << (int)length) - 1);
}
//****************Sample Test*****************
using System;
using System.Security.Cryptography;
using NUnit.Framework;

[TestFixture]
public class Tests {

  [Test]
  [TestCase(0xAFul, 0u, 0u, 0x0ul)]
  [TestCase(0xFF00FFul, 0x0u, 0u, 0x0ul )]
  public void TestZeroOffsetAndLength(ulong input, uint offset, uint length, ulong expectedValue) {
    AssertEqualWithFormatting(expectedValue, Kata.ExtractBits(input, offset, length));
  }
  
  [Test]
  [TestCase(0xAA00BB00CC00DD00UL, 0x00U, 8U, 0x00UL )]
  [TestCase(0xAA00BB00CC00DD00UL, 0x04U, 8U, 0xD0UL )]
  [TestCase(0xAA00BB00CC00DD00UL, 0x08U, 8U, 0xDDUL )]
  [TestCase(0xAA00BB00CC00DD00UL, 0x0CU, 8U, 0x0DUL )]
  [TestCase(0xAA00BB00CC00DD00UL, 0x10U, 8U, 0x00UL )]
  public void TestDifferentOffsetsPartialLength(ulong input, uint offset, uint length, ulong expectedValue) {
    AssertEqualWithFormatting(expectedValue, Kata.ExtractBits(input, offset, length));
  }

  [Test]
  [TestCase(0xAA00BB00CC00DD00UL, 0x00U, 64U, 0xAA00BB00CC00DD00UL )]
  [TestCase(0xAA00BB00CC00DD00UL, 0x04U, 64U, 0xAA00BB00CC00DD0UL )]
  [TestCase(0xAA00BB00CC00DD00UL, 0x08U, 64U, 0xAA00BB00CC00DDUL )]
  [TestCase(0xAA00BB00CC00DD00UL, 0x0CU, 64U, 0xAA00BB00CC00DUL )]
  [TestCase(0xAA00BB00CC00DD00UL, 0x10U, 64U, 0xAA00BB00CC00UL )]
  [TestCase(0xAA00BB00CC00DD00UL, 0x14U, 64U, 0xAA00BB00CC0UL )]
  [TestCase(0xAA00BB00CC00DD00UL, 0x18U, 64U, 0xAA00BB00CCUL )]
  [TestCase(0xAA00BB00CC00DD00UL, 0x1CU, 64U, 0xAA00BB00CUL )]
  [TestCase(0xAA00BB00CC00DD00UL, 0x20U, 64U, 0xAA00BB00UL )]
  [TestCase(0xAA00BB00CC00DD00UL, 0x24U, 64U, 0xAA00BB0UL )]
  [TestCase(0xAA00BB00CC00DD00UL, 0x28U, 64U, 0xAA00BBUL )]
  [TestCase(0xAA00BB00CC00DD00UL, 0x2CU, 64U, 0xAA00BUL )]
  [TestCase(0xAA00BB00CC00DD00UL, 0x30U, 64U, 0xAA00UL )]
  [TestCase(0xAA00BB00CC00DD00UL, 0x34U, 64U, 0xAA0UL )]
  [TestCase(0xAA00BB00CC00DD00UL, 0x38U, 64U, 0xAAUL )]
  [TestCase(0xAA00BB00CC00DD00UL, 0x3CU, 64U, 0xAUL )]
  [TestCase(0xAA00BB00CC00DD00UL, 0x40U, 64U, 0x0UL )]
  [TestCase(0xAA00BB00CC00DD00UL, 0x44U, 64U, 0x0UL )]
  [TestCase(0xAA00BB00CC00DD00UL, 0x48U, 64U, 0x0UL )]
  [TestCase(0xAA00BB00CC00DD00UL, 0x50U, 64U, 0x0UL )]
  [TestCase(0xAA00BB00CC00DD00UL, 0x60U, 64U, 0x0UL )]
  [TestCase(0xAA00BB00CC00DD00UL, 0x70U, 64U, 0x0UL )]
  [TestCase(0xAA00BB00CC00DD00UL, 0x80U, 64U, 0x0UL )]
  [TestCase(0xAA00BB00CC00DD00UL, 0x84U, 64U, 0x0UL )]
  [TestCase(0xAA00BB00CC00DD00UL, 0x88U, 64U, 0x0UL )]
  [TestCase(0xAA00BB00CC00DD00UL, 0x90U, 64U, 0x0UL )]
  public void TestDifferentOffsetsFullLength(ulong input, uint offset, uint length, ulong expectedValue) {
    AssertEqualWithFormatting(expectedValue, Kata.ExtractBits(input, offset, length));
  }
  
  [Test]
  [TestCase(0xAA00BB00CCUL, 0x0U,  0U, 0x0UL )]
  [TestCase(0xAA00BB00CCUL, 0x4U,  0U, 0x0UL )]
  [TestCase(0xAA00BB00CCUL, 0x32U, 0U, 0x0UL )]
  [TestCase(0xAA00BB00CCUL, 0x64U, 0U, 0x0UL )]
  public void TestZeroLength(ulong input, uint offset, uint length, ulong expectedValue) {
    AssertEqualWithFormatting(expectedValue, Kata.ExtractBits(input, offset, length));
  }
  
  [Test]
  [TestCase(0xAA00BB00CCUL, 0xF0000000U, 0x64U, 0x0UL )]
  public void TestOffsetWithSignBitSet(ulong input, uint offset, uint length, ulong expectedValue) {
    AssertEqualWithFormatting(expectedValue, Kata.ExtractBits(input, offset, length));
  }
  
  [Test]
  [TestCase(0xAA00BB00CCUL, 0xF0U, 0xF0000000U, 0x0UL )]
  public void TestVeryLargeLength(ulong input, uint offset, uint length, ulong expectedValue) {
    AssertEqualWithFormatting(expectedValue, Kata.ExtractBits(input, offset, length));
  }
  
  [Test]
  public void TestRandom() {
    for(int i = 0; i < 100; i++){
      var longBytes = RandomNumberGenerator.GetBytes(8);    
      var input = BitConverter.ToUInt64(longBytes, 0);
      var expected = input & 0xFFUL;
      var result = Kata.ExtractBits(input, 0, 8);
      Assert.AreEqual(expected, result,
        $"Expected: 0x{expected:X}, Received value: 0x{result:X}");
    }
    
    for(int i = 0; i < 100; i++){
      var longBytes = RandomNumberGenerator.GetBytes(8);    
      var input = BitConverter.ToUInt64(longBytes, 0);
      var expected = (input >> 8) & 0xFFUL;
      var result = Kata.ExtractBits(input, 8, 8);
      Assert.AreEqual(expected, result,
        $"Expected: 0x{expected:X}, Received value: 0x{result:X}");
    }
  }
  
  public void AssertEqualWithFormatting(ulong expectedValue, ulong result) {
    Assert.AreEqual(expectedValue, result, $"Expected: 0x{expectedValue:X}, Received value: 0x{result:X}");
  }
}
