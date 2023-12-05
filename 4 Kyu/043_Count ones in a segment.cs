/*Challenge link:https://www.codewars.com/kata/596d34df24a04ee1e3000a25/train/csharp
Question:
Given two numbers: 'left' and 'right' (1 <= 'left' <= 'right' <= 200000000000000) return sum of all '1' occurencies in binary representations of numbers between 'left' and 'right' (including both)

Example:
countOnes 4 7 should return 8, because:
4(dec) = 100(bin), which adds 1 to the result.
5(dec) = 101(bin), which adds 2 to the result.
6(dec) = 110(bin), which adds 2 to the result.
7(dec) = 111(bin), which adds 3 to the result.
So finally result equals 8.
WARNING: Segment may contain billion elements, to pass this kata, your solution cannot iterate through all numbers in the segment!
*/

//***************Solution********************
using System.Numerics;

public class BitCount{
   private static BigInteger bitCount(long number, long sum = 0){
     //bit shift each iteration
     //Bitwise: & and, ~ Unary(reversing each bit), >> shift right, << shift left
        for (long bit = 1; bit <= number; bit <<= 1)
            sum += ((number >> 1) &~ (bit - 1)) + ((number & bit) != 0 ? (number & ((bit << 1) - 1)) - (bit - 1) : 0); 
        return sum;
   }
   public static BigInteger CountOnes(long left, long right) =>  bitCount(right) - bitCount(left - 1);
}

//solution 2
using System;
using System.Numerics;

public class BitCount
{
   public static BigInteger CountOnes(long left, long right)
   {
     return CountOne(right) - CountOne(left-1);
   }
  
  static BigInteger CountOne(long n)
    {
      BigInteger result = 0;
    
      while (n > 0)
      {
        int k = Convert.ToInt32(Math.Floor(Math.Log2(n)));
        result = result + new BigInteger(Math.Pow(2, k - 1) * k + 1);

        n -= Convert.ToInt64(Math.Pow(2, k));

        result = result + new BigInteger(n);
      }
    
      return result;
    }
}

//solution 3
using System.Numerics;
public class BitCount
{
   private static BigInteger Count(BigInteger n)
   {
     if(n.IsZero)
       return n;
     
     int i = (int)BigInteger.Log(n+1,2);
     BigInteger c = i*BigInteger.Pow(2,i-1);     
     if(!(n+1).IsPowerOfTwo)
       c += n-c/i*2 + 1 + Count(n-c/i*2);

     return c;
   }
   
   public static BigInteger CountOnes(long left, long right)
   {
       return Count(right) - Count(left-1);
   }
}
//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Linq;
using System.Numerics;
public class SolutionTest
{

    [Test]
    public void SampleTests()
    {
        Assert.AreEqual(new BigInteger(7), BitCount.CountOnes(5, 7));
        Assert.AreEqual(new BigInteger(51), BitCount.CountOnes(12, 29));
    }

    [Test]
    public void TestsRightLessThanMillion()
    {

        long[] left = { 193303, 11366, 239138, 284512, 313122, 121729, 133970, 513003, 7615, 13996, 4469, 44286, 254547, 180375, 112080, 141223, 432013, 125968, 870689, 164475, 163744, 109176, 85773, 86556, 563623, 152563, 140161, 684229, 235432, 354729, 679024, 100778, 235071, 280352, 197106, 560896, 498443, 473938, 512305, 320555 },
               right = { 289384, 692778, 747794, 885387, 516650, 202363, 368691, 897764, 180541, 89173, 5212, 702568, 465783, 722863, 174068, 513930, 634023, 133070, 961394, 175012, 176230, 484422, 413785, 575199, 798316, 566414, 776092, 759957, 806863, 906997, 702306, 477085, 660337, 750847, 661314, 616125, 819583, 898815, 515435, 344044 },
               result = { 916107, 6504398, 5047947, 6068268, 2083706, 734924, 2205471, 3900365, 1494008, 621221, 4716, 6345692, 2054130, 5356740, 556695, 3661109, 2020222, 69046, 996092, 91146, 108467, 3625358, 3103767, 4729088, 2391396, 4052154, 6291168, 795359, 5715404, 5649194, 234560, 3620732, 4198781, 4686608, 4567000, 522279, 3241559, 4343675, 37199, 223666 };

        for (int i = 0; i < result.Length; i++)
        {
            Assert.AreEqual(new BigInteger(result[i]), BitCount.CountOnes(left[i], right[i]));
        }
    }


    [Test]
    public void TestsSmallSegments()
    {

        long[] left = { 476744280L, 944170099L, 780302205L, 491202753L, 751780356L, 53904873L, 410556309L, 943737728L, 854937641L, 469050556L, 35660226L, 39691057L, 317030867L, 376097196L, 330002826L, 687665897L, 959437022L, 402514846L, 194524177L, 363881826L, 220813712L, 63849915L, 113832327L, 468943807L, 609421783L, 630926712L, 254307145L, 326977622L, 268490624L, 352377596L, 159718658L, 112756904L, 377879485L, 712894903L, 409472994L, 372708192L, 200047074L, 117140374L, 149629396L, 990649367L },
               right = { 477171088L, 945117277L, 780695789L, 491705404L, 752392755L, 53999933L, 411549677L, 943947740L, 855636227L, 469348095L, 36140796L, 40651435L, 317097468L, 376710098L, 330573318L, 687926653L, 959997302L, 402724287L, 194953866L, 364228445L, 221558441L, 63958032L, 114738098L, 469834482L, 610120710L, 631704568L, 255179498L, 327254587L, 269455307L, 352406220L, 160051529L, 112805733L, 378409504L, 713258271L, 409959709L, 373226341L, 200747797L, 117142619L, 150122847L, 990892922L },
               result = { 6676768L, 13601496L, 5838166L, 7714112L, 9541272L, 1409074L, 13912387L, 2720694L, 12215839L, 5349512L, 5480447L, 12444240L, 997462L, 9524617L, 8861694L, 4128212L, 8679970L, 3412027L, 6574107L, 5271104L, 10755601L, 1691150L, 13111062L, 15800295L, 9816960L, 11668816L, 13425528L, 4314779L, 10659492L, 328391L, 4322838L, 702233L, 7549748L, 5291552L, 7003298L, 7969261L, 11629712L, 39313L, 7155096L, 3888454L };

        for (int i = 0; i < result.Length; i++)
        {
            Assert.AreEqual(new BigInteger(result[i]), BitCount.CountOnes(left[i], right[i]));
        }
    }

    [Test]
    public void TestsRightLessThanBilion()
    {

        long[] left = { 4250829L, 4274934L, 143852667L, 269441501L, 116087765L, 155324915L, 7201509L, 111972748L, 140503910L, 799572077L, 415301119L, 238949915L, 213975408L, 87359897L, 170387819L, 211409028L, 138757322L, 8512230L, 408498724L, 33967672L },
               right = { 231192380L, 111537765L, 147469842L, 911165194L, 142757035L, 869470125L, 8936988L, 275373744L, 350322228L, 960709860L, 771151433L, 244316438L, 476153276L, 139901475L, 653468859L, 239036030L, 605908236L, 76065819L, 789366144L, 875335929L },
               result = { 3131546184L, 1425202312L, 47992140L, 9646649502L, 379752831L, 10680285147L, 21235101L, 2364504130L, 3012886682L, 2500917820L, 5369360706L, 79644685L, 3877107778L, 745609346L, 7150149324L, 409001532L, 6881850118L, 886138167L, 5757719216L, 12433723523L };

        for (int i = 0; i < result.Length; i++)
        {
            Assert.AreEqual(new BigInteger(result[i]), BitCount.CountOnes(left[i], right[i]));
        }
    }

    [Test]
    public void TestsOneBilionElementsSegment()
    {
        Assert.AreEqual(new BigInteger(14846928141), BitCount.CountOnes(1, 1000000000L));
    }
    
    [Test]
    public void TestsMaxElementsSegment()
    {
        Assert.AreEqual(new BigInteger(4712825299386385), BitCount.CountOnes(1, 200000000000000L));
    }

    private Random rnd = new Random();

    [Test]
    public void RandomTestsSmallSegments()
    {
        //190000L, 910000000L
        long[] lngs = Enumerable.Repeat(0, 100).Select(x => RandomLong(190000L, 910000000L)).ToArray();
        for (int i = 0; i < 100; i += 2)
        {
            long l = lngs[i], r = lngs[i + 1] % l + l + 25;
            Assert.AreEqual(CountOnesSol(l, r), BitCount.CountOnes(l, r));
        }
    }
    [Test]
    public void RandomTestsLargeSegments()
    {
        //89000000000L, 191000000000000L
        long[] lngs = Enumerable.Repeat(0, 100).Select(x => RandomLong(89000000000L, 191000000000000L)).ToArray();
        for (int i = 0; i < 100; i += 2)
        {
            long l = lngs[i], r = lngs[i + 1] % l + l + 25;
            Assert.AreEqual(CountOnesSol(l, r), BitCount.CountOnes(l, r));
        }
    }

    private long RandomLong(long min, long max) => (long)(rnd.NextDouble() * (max - min) + min);

    private BigInteger CountOnesSol(long left, long right)
    {
        return CountUpTo(right) - CountUpTo(left - 1);
    }

    private static BigInteger CountUpTo(BigInteger n)
    {
        if (n <= 0) return 0;
        if (n == 1) return 1;
        var nb = (int)BigInteger.Log(n, 2) + 1;
        n -= BigInteger.Pow(2, nb - 1);
        return n + 1 + BigInteger.Pow(2, nb - 2) * (nb - 1) + CountUpTo(n);
    }
}
