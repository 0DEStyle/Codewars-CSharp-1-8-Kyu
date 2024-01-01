/*Challenge link:https://www.codewars.com/kata/564a043fc4dd493b4900005b/train/csharp
Question:
Smoker Peter wants to buy new home
Peter is a smoker, he pays 0.5 Euro for each cigarette, and he smokes 6 cigarettes per day. His daily wage is 100 Euro, while he spend 20 Euro on life expenses.

Peter wants to buy a new home that cost 100000 Euro, please let him know how many days he has to save money to buy the home. What if the he stop smoking. (Count the days that he has to wait. You don't need to count the last day; the day he wants to buy the home)

Write a method that takes 5 arguments

public static string BuyHomeQuote(double cigarettePrice, int numberCigarettePerDay, int wagePerDay, int otherExpenses, int homePrice)
{
// your code
}
and return a string in the following format:

string.Format("it takes {0} days to buy the home, however if you stop smoking it only takes {1} days.",
NumDaysWithSmoking, NumDaysWithoutSmoking)
In case the person is not smoker, you don't need the second sentence, so the return string will be:

string.Format("it takes {0} days to buy the home.",
NumDays)
In case of Peter the return string will be:

"it takes 1298 days to buy the home, however if you stop smoking it only takes 1250 days."
P.S. Round down the result, since we don't count the last day.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

//double cigarettePrice => cigP, int numberCigarettePerDay => cigD, int wagePerDay => wage, int otherExpenses => oE, int homePrice =>hP
//apply formula, using string interpolation to format the result.
public class Kata{
        public static string BuyHomeQuote(double cigP, int cigD, int wage, int oE, int hP) =>
          $"it takes {(int) (hP / (wage - oE - (cigP * cigD)))} days to buy the home" +
          (cigD > 0 ? 
          $", however if you stop smoking it only takes {hP / (wage - oE)} days."
          : ".");
}
//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
    public class MyTest
    {
        [Test]
        public void FirstTest()
        {
            StringAssert.AreEqualIgnoringCase("it takes 1111 days to buy the home, however if you stop smoking it only takes 1000 days.", Kata.BuyHomeQuote(1, 10, 110, 10, 100000));
        }
        [Test]
        public void SecondTest()
        {
            StringAssert.AreEqualIgnoringCase("it takes 446 days to buy the home, however if you stop smoking it only takes 444 days.", Kata.BuyHomeQuote(0.5, 2, 200, 20, 80000));
        }
        [Test]
        public void ThirdTest()
        {
            StringAssert.AreEqualIgnoringCase("it takes 1000 days to buy the home.",Kata.BuyHomeQuote(0, 0, 220, 20, 200000));
        }
        [Test]
        public void RandomTest([Values(1)] int a, [Random(-1, 1, 30)] double d)
        {
            Rg rg = new Rg((int)d * 10000);
            double cigarettePrice = rg.CigarettePrice();
            int numberCigarettePerDay = rg.NumberCigarettePerDay();
            int wagePerDay = rg.WagePerDay();
            int otherExpenses = rg.OtherExpenses();
            int homePrice = rg.HomePrice();
            StringAssert.AreEqualIgnoringCase(
                BuyHomeQuote(cigarettePrice, numberCigarettePerDay, wagePerDay, otherExpenses,
                    homePrice),
                Kata.BuyHomeQuote(cigarettePrice, numberCigarettePerDay, wagePerDay,
                    otherExpenses, homePrice));
        }
        
        private static string BuyHomeQuote(double cigarettePrice, int numberCigarettePerDay, int wagePerDay, int otherExpenses, int homePrice)
        {
            int daysWithoutSmoking = homePrice / (wagePerDay - otherExpenses);
            int daysWithSmoking = (int)(homePrice / (wagePerDay - otherExpenses - cigarettePrice * numberCigarettePerDay));
            return daysWithSmoking != daysWithoutSmoking
                ? string.Format(
                    "it takes {0} days to buy the home, however if you stop smoking it only takes {1} days.",
                    daysWithSmoking, daysWithoutSmoking)
                : string.Format(
                    "it takes {0} days to buy the home.",
                    daysWithSmoking);
        }
    }
