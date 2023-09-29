/*Challenge link:https://www.codewars.com/kata/5a5f9f80f5dc3f942b002309/train/csharp
Question:
Can a value be both true and false?

Define omniBool so that it returns true for the following:

omniBool == true && omniBool == false
If you enjoyed this kata, be sure to check out my other katas.


*/

//***************Solution********************
//inverse variable each time, store in public variable x.
public class Kata {
  public static bool x = false;
  public static bool omnibool {
    get => x = !x;
  }
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest {
    [Test]
    public void FinalTest() {
      Assert.IsTrue(Kata.omnibool == true && Kata.omnibool == false, @"
▄██████████████▄▐█▄▄▄▄█▌
██████▌▄▌▄▐▐▌███▌▀▀██▀▀
████▄█▌▄▌▄▐▐▌▀███▄▄█▌
▄▄▄▄▄██████████████▀
Your wizard powers fail.
");
    }
  }
}
