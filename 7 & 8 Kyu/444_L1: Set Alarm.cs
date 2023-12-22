/*Challenge link:https://www.codewars.com/kata/568dcc3c7f12767a62000038/train/csharp
Question:
Write a function named setAlarm/set_alarm/set-alarm/setalarm (depending on language) which receives two parameters. The first parameter, employed, is true whenever you are employed and the second parameter, vacation is true whenever you are on vacation.

The function should return true if you are employed and not on vacation (because these are the circumstances under which you need to set an alarm). It should return false otherwise. Examples:

employed | vacation 
true     | true     => false
true     | false    => true
false    | true     => false
false    | false    => false
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression
//check conditions and return result
public class Kata {
  public static bool SetAlarm(bool employed, bool vacation)  => vacation == false && employed == true;
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SetAlarmTest {
    [Test]
    public void Tests() {
      Assert.AreEqual(false, Kata.SetAlarm(true, true));
      Assert.AreEqual(false, Kata.SetAlarm(false, true));
      Assert.AreEqual(true, Kata.SetAlarm(true, false));
      Assert.AreEqual(false, Kata.SetAlarm(false, false));
    }
  }
}
