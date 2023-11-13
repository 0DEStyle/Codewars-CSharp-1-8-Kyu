/*Challenge link:https://www.codewars.com/kata/562f91ff6a8b77dfe900006e/train/csharp
Question:
My friend John likes to go to the cinema. He can choose between system A and system B.

System A : he buys a ticket (15 dollars) every time
System B : he buys a card (500 dollars) and a first ticket for 0.90 times the ticket price, 
then for each additional ticket he pays 0.90 times the price paid for the previous ticket.
Example:
If John goes to the cinema 3 times:

System A : 15 * 3 = 45
System B : 500 + 15 * 0.90 + (15 * 0.90) * 0.90 + (15 * 0.90 * 0.90) * 0.90 ( = 536.5849999999999, no rounding for each ticket)
John wants to know how many times he must go to the cinema so that the final result of System B, when rounded up to the next dollar, will be cheaper than System A.

The function movie has 3 parameters: card (price of the card), ticket (normal price of a ticket), perc (fraction of what he paid for the previous ticket) and returns the first n such that

ceil(price of System B) < price of System A.
More examples:
movie(500, 15, 0.9) should return 43 
    (with card the total price is 634, with tickets 645)
movie(100, 10, 0.95) should return 24 
    (with card the total price is 235, with tickets 240)
*/

//***************Solution********************
//change from int to double (temp)
//while ceil rounding of temp is greater or equal to ticket * count
//accumulate temp by adding ticket * perc to the power of count(count increase each iteration)
//return count as result.
using System;

public class MovieC {
    
    public static int Movie(int card, int ticket, double perc, int count = 0) {   
      double temp = card;
      while (Math.Ceiling(temp) >= ticket * count)
        temp += ticket * Math.Pow(perc,++count);
      return count;
    }
}

//solution 2
using System;
public class MovieC {
    public static int Movie(int c, int t, double p) {
       int i=0;
       for (double x=t,y=c;Math.Ceiling(y)>=t*i;i++,x*=p,y+=x){}
       return i;
    }
}
//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public static class MovieCTests {

    private static Random rnd = new Random();

    private static void testing(long actual, long expected) {
        Assert.AreEqual(expected, actual);
    }

[Test]
    public static void test1() {
        Console.WriteLine("Fixed Tests: Movie");
        testing(MovieC.Movie(500, 15, 0.9), 43);
        testing(MovieC.Movie(100, 10, 0.95), 24);
        testing(MovieC.Movie(0, 10, 0.95), 2);
        testing(MovieC.Movie(250, 20, 0.9), 21);
        testing(MovieC.Movie(500, 20, 0.9), 34);
        testing(MovieC.Movie(2500, 20, 0.9), 135);
    }
    
    //-----------------------
    public static int MovieSol6776(int card, int ticket, double perc) {
        int i = 0; double sb = card; int sa = 0; double prev = ticket;
        while (true) { 
            i++;
            double nou = prev * perc;
            sb += nou;
            prev = nou;
            sa += ticket;
            if (Math.Ceiling(sb) < sa)
                return i; 
        }
    }
    //-----------------------
[Test]    
    public static void RandomTest() {
      Console.WriteLine("Random Tests");
      for (int i = 0; i < 100; i++) { 
        int card = rnd.Next(10, 1000000);   
        int tck = rnd.Next(2, 50);
        double perc = rnd.Next(40,98) / 100.0;
        testing(MovieC.Movie(card, tck, perc), MovieSol6776(card, tck, perc)); 
      }
    }  
}
