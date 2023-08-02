/*Challenge link:https://www.codewars.com/kata/555624b601231dc7a400017a/train/csharp
Question:
In this kata you have to correctly return who is the "survivor", ie: the last element of a Josephus permutation.

Basically you have to assume that n people are put into a circle and that they are eliminated in steps of k elements, like this:

n=7, k=3 => means 7 people in a circle
one every 3 is eliminated until one remains
[1,2,3,4,5,6,7] - initial sequence
[1,2,4,5,6,7] => 3 is counted out
[1,2,4,5,7] => 6 is counted out
[1,4,5,7] => 2 is counted out
[1,4,5] => 7 is counted out
[1,4] => 5 is counted out
[4] => 1 counted out, 4 is the last element - the survivor!
The above link about the "base" kata description will give you a more thorough insight about the origin of this kind of permutation, but basically that's all that there is to know to solve this kata.

Notes and tips: using the solution to the other kata to check your function may be helpful, but as much larger numbers will be used, using an array/list to compute the number of the survivor may be too slow; you may assume that both n and k will always be >=1.
*/

//***************Solution********************

//n: number of people, k: skip index for elimination
//if n is 1, return 1, else using reversive method to remove index until one left.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

public class JosephusSurvivor{
    public static int JosSurvivor(int n, int k) => n == 1 ? 1 : (JosSurvivor(n - 1, k) + k-1) % n + 1;
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public static class JosephusSurvivorTests 
{

    private static void testing(int actual, int expected) 
    {
        Assert.AreEqual(expected, actual);
    }
[Test]
    public static void test1() 
    {        
        Console.WriteLine("Basic Tests JosSurvivor");
        testing(JosephusSurvivor.JosSurvivor(7,3),4);
        testing(JosephusSurvivor.JosSurvivor(11,19),10);
        testing(JosephusSurvivor.JosSurvivor(40,3),28);
        testing(JosephusSurvivor.JosSurvivor(14,2),13);
        testing(JosephusSurvivor.JosSurvivor(100,1),100);
        testing(JosephusSurvivor.JosSurvivor(1,300),1);
        testing(JosephusSurvivor.JosSurvivor(2,300),1);
        testing(JosephusSurvivor.JosSurvivor(5,300),1);
        testing(JosephusSurvivor.JosSurvivor(7,300),7);
        testing(JosephusSurvivor.JosSurvivor(300,300),265);
    }
    //-----------------------
    private static Random rnd = new Random();

    public static int JosSurvivorSol(int n, int k) 
    {
        if(n == 1)
            return 1; 
        return (JosSurvivorSol(n - 1, k) + k - 1) % n + 1;
    }  
    //-----------------------
    private static void test2() 
    {
        for (int i = 0; i < 40; i++) 
        {
            int n = rnd.Next(1, 5000);
            int k = rnd.Next(1, 5000);
            testing(JosephusSurvivor.JosSurvivor(n, k), JosSurvivorSol(n, k));
        }
    }
[Test] 
    public static void RandomTests() 
    { 
        Console.WriteLine("Random Tests******* JosSurvivor");
        test2();
    } 
}
