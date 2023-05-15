/*Challenge link:https://www.codewars.com/kata/5f0ed36164f2bc00283aed07/train/csharp
Question:
Task
You've just moved into a perfectly straight street with exactly n identical houses on either side of the road. Naturally, you would like to find out the house number of the people on the other side of the street. The street looks something like this:

Street
1|   |6
3|   |4
5|   |2
  you
Evens increase on the right; odds decrease on the left. House numbers start at 1 and increase without gaps. When n = 3, 1 is opposite 6, 3 opposite 4, and 5 opposite 2.

Example (address, n --> output)
Given your house number address and length of street n, give the house number on the opposite side of the street.

1, 3 --> 6
3, 3 --> 4
2, 3 --> 5
3, 5 --> 8
Note about errors
If you are timing out, running out of memory, or get any kind of "error", read on. Both n and address could get upto 500 billion with over 200 random tests. If you try to store the addresses of 500 billion houses in a list then you will run out of memory and the tests will crash. This is not a kata problem so please don't post an issue. Similarly if the tests don't complete within 12 seconds then you also fail.

To solve this, you need to think of a way to do the kata without making massive lists or huge for loops. Read the discourse for some inspiration :)
*/

//***************Solution********************
//apply algorithm
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class CodeWars {
  public static long OverTheRoad(long address, long n) => 2 * n + 1 - address;
}

//****************Sample Test*****************
using NUnit.Framework;
using System;

[TestFixture]
public class Basic_Tests {
  [Test]
  public void basic_test_cases() {
    Assert.AreEqual(6, CodeWars.OverTheRoad(1, 3));
    Assert.AreEqual(4, CodeWars.OverTheRoad(3, 3));
    Assert.AreEqual(5, CodeWars.OverTheRoad(2, 3));
    Assert.AreEqual(8, CodeWars.OverTheRoad(3, 5));
    Assert.AreEqual(16, CodeWars.OverTheRoad(7, 11));
  }
}

[TestFixture]
public class Static_Tests {
  [Test]
  public void static_test_cases() {
    Assert.AreEqual(35, CodeWars.OverTheRoad(10, 22));
    Assert.AreEqual(6781, CodeWars.OverTheRoad(20, 3400));
    Assert.AreEqual(44, CodeWars.OverTheRoad(9, 26));
    Assert.AreEqual(1, CodeWars.OverTheRoad(20, 10));
  }
}

[TestFixture]
public class Random_Tests {
  private Random random = new Random();
  
  private long reference(long address, long n) {
    return 2*n-address+1;
  }
  
  private void doTest(long max) {
    long street = (long) (random.NextDouble()*(max-1)+1);
    long address = (long) (random.NextDouble()*(2*street-1)+1);
    long expected = reference(address, street);
    Assert.AreEqual(expected, CodeWars.OverTheRoad(address, street));
  }

  [Test]
  public void random_test_cases() {
    for (int i = 0; i < 300; i++) {
      doTest(1000);
    }
  }
  
  [Test]
  public void massive_random_tests() {
    for (int i = 0; i < 150; i++) {
      doTest(500000000000);
    }
  }
}
