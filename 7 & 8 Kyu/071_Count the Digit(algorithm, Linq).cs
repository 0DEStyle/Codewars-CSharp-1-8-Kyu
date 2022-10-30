/*Challenge link:
Question:
Take an integer n (n >= 0) and a digit d (0 <= d <= 9) as an integer.

Square all numbers k (0 <= k <= n) between 0 and n.

Count the numbers of digits d used in the writing of all the k**2.

Call nb_dig (or nbDig or ...) the function taking n and d as parameters and returning this count.

Examples:
n = 10, d = 1 
the k*k are 0, 1, 4, 9, 16, 25, 36, 49, 64, 81, 100
We are using the digit 1 in: 1, 16, 81, 100. The total count is then 4.

nb_dig(25, 1) returns 11 since
the k*k that contain the digit 1 are:
1, 16, 81, 100, 121, 144, 169, 196, 361, 441.
So there are 11 digits 1 for the squares of numbers between 0 and 25.
Note that 121 has twice the digit 1.
*/

//***************Solution********************
//from 0 to n+1
//select x * x
//convert the result x*x to string, and count the character d in the string (d is still int, so subtract 48 becomes the number in char)
//sum the count and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
public class CountDig 
{
    public static int NbDig(int n, int d) =>
       Enumerable.Range(0,n+1).Select(x=>(x*x).ToString().Count(y=>y-48==d)).Sum();
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public static class NbDigTests 
{

    private static Random rnd = new Random();
    private static void testing(int actual, int expected) 
    {
        Assert.AreEqual(expected, actual);
    }

[Test]
    public static void test1() 
    {
        Console.WriteLine("Fixed Tests NbDig");
        testing(CountDig.NbDig(5750, 0), 4700);
        testing(CountDig.NbDig(11011, 2), 9481);
        testing(CountDig.NbDig(12224, 8), 7733);
        testing(CountDig.NbDig(11549, 1), 11905);
        testing(CountDig.NbDig(14550, 7), 8014);
        testing(CountDig.NbDig(8304, 7), 3927);
        testing(CountDig.NbDig(10576, 9), 7860);
        testing(CountDig.NbDig(12526, 1), 13558);
        testing(CountDig.NbDig(7856, 4), 7132);
        testing(CountDig.NbDig(14956, 1), 17267);   
    }
    
    //-----------------------
    private static int NbDigSol(int n, int d) 
    {
        int k = 0, cnt = 0;
        char c = d.ToString()[0];
        while (k <= n) 
        {
            int a = 0;
            string s = (k*k).ToString();
            for(int i = 0; i < s.Length; i++)
                if(s[i] == c)
                    a++;
            if (a > 0)
                cnt += a;
            k++;
        }
        return cnt;
    }    
    
    //-----------------------
[Test]    
    public static void RandomTest() 
    {
        Console.WriteLine("100 Random Tests");
        for (int i = 0; i < 100; i++) 
        { 
            int n = rnd.Next(2000, 15000); 
            int d = rnd.Next(0,9);
            int r = NbDigSol(n, d);
            //Console.WriteLine("n " + n + " d " + d + " --> " + r);
            testing(CountDig.NbDig(n, d), r);
        }
    }  
    
}
