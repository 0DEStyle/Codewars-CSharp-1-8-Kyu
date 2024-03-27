/*Challenge link:https://www.codewars.com/kata/58a369fa5b3daf464200006c/train/csharp
Question:
Every day we can send from the server a certain limit of e-mails.

Task:
Write a function that will return the integer number of e-mails sent in the percentage of the limit.

Example:

limit       - 1000;
emails sent - 101;
return      - 10%; // because integer from 10,1 = 10
Arguments:
sent: number of e-mails sent today (integer)
limit: number of e-mails you can send today (integer)
When:
the argument sent = 0, then return the message: "No e-mails sent";
the argument sent >= limit, then return the message: "Daily limit is reached";
the argument limit is empty, then default limit = 1000 emails;
Good luck!
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//set argu limit to 1000 default value
//if sent is 0, return "No e-mails sent"
//if sent is greater or equal to limit, retrun "Daily limit is reached"
//else get percentage, and use string interpolation to format the result.
namespace CountEmails{
  public static class Program{
    public static string CountEmails(int sent, int limit = 1000) => 
             sent == 0 ? "No e-mails sent" : 
             sent >= limit ? "Daily limit is reached": 
             $"{100 * sent / limit}%";
  }
}

//****************Sample Test*****************
namespace CountEmails
{
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
        [Test]
        public void ShoulddProvideLimitReached()
        {              
            Assert.AreEqual("Daily limit is reached", Program.CountEmails(101,100));
        }

        [Test]
        public void ShouldProvideNoEmailsSent()
        {
            Assert.AreEqual("No e-mails sent", Program.CountEmails(0,1000));           
        }

        [Test]
        public void ShouldProvideFiftyPc()
        {
            Assert.AreEqual("50%", Program.CountEmails(100,200));
        }

        [Test]
        public void ShouldRoundUp()
        {
            Assert.AreEqual("10%", Program.CountEmails(101));
        }
    

  }
}
