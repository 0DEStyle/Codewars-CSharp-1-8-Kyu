/*Challenge link:https://www.codewars.com/kata/56a4872cbb65f3a610000026/train/csharp
Question:
Let us begin with an example:

Take a number: 56789. Rotate left, you get 67895.

Keep the first digit in place and rotate left the other digits: 68957.

Keep the first two digits in place and rotate the other ones: 68579.

Keep the first three digits and rotate left the rest: 68597. Now it is over since keeping the first four it remains only one digit which rotated is itself.

You have the following sequence of numbers:

56789 -> 67895 -> 68957 -> 68579 -> 68597

and you must return the greatest: 68957.

Task
Write function max_rot(n) which given a positive integer n returns the maximum number you got doing rotations similar to the above example.

So max_rot (or maxRot or ... depending on the language) is such as:

max_rot(56789) should return 68957

max_rot(38458215) should return 85821534
*/

//***************Solution********************
//localised variable n to max, and n to string as number
//create a loop start from 0 to the length of number
//concatenate (0 to i) + (i + 1) + number[i] <-----whatever is left in the number
//parse number to long, then compare n to max, if n is bigger, overwrite the value 
//and continue to the next loop.
//return result in the end.
public class MaxRotate {
    public static long MaxRot (long n) {
        long max = n;
        string number = n.ToString();
        for(int i = 0; i < number.Length - 1; i++){
            number = number.Substring(0, i) + number.Substring(i + 1) + number[i];
            n = long.Parse(number);
            if(n > max) max = n;
        }
        return max;
    }
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public static class MaxRotateTests 
{
    private static void testing(long actual, long expected) 
    {
        Assert.AreEqual(expected, actual);
    }
[Test]
    public static void test1() 
    {        
        Console.WriteLine("Basic Tests");
        testing(MaxRotate.MaxRot(38458215), 85821534);
        testing(MaxRotate.MaxRot(195881031), 988103115);
        testing(MaxRotate.MaxRot(896219342), 962193428);
        testing(MaxRotate.MaxRot(69418307), 94183076);
        testing(MaxRotate.MaxRot(257117280), 571172802);
        testing(MaxRotate.MaxRot(240522578), 452782025);
        testing(MaxRotate.MaxRot(561656824), 666824515);
        testing(MaxRotate.MaxRot(672963486), 796348662);
        testing(MaxRotate.MaxRot(48192242), 89242412);
        testing(MaxRotate.MaxRot(25053359), 55392035);
        testing(MaxRotate.MaxRot(785727925), 877925752);
        testing(MaxRotate.MaxRot(275076894), 750768942);
        testing(MaxRotate.MaxRot(507992495), 507992495);
        testing(MaxRotate.MaxRot(461358517), 638517415);
        testing(MaxRotate.MaxRot(563692037), 669203753);
        testing(MaxRotate.MaxRot(159043701), 590437011);
        testing(MaxRotate.MaxRot(896304934), 963049348);
        testing(MaxRotate.MaxRot(273293210), 732932102);
        testing(MaxRotate.MaxRot(451496516), 549651641);
        testing(MaxRotate.MaxRot(1), 1);
        testing(MaxRotate.MaxRot(16130873362142L), 63873362142110L);
        testing(MaxRotate.MaxRot(84005278654009L), 84005278654009L);
        testing(MaxRotate.MaxRot(51564279810300L), 51564279810300L);
        testing(MaxRotate.MaxRot(12364484492416L), 26484492416134L);
        testing(MaxRotate.MaxRot(63026816035764L), 63026816035764L);
        testing(MaxRotate.MaxRot(77910393341241L), 79103933412417L);
        testing(MaxRotate.MaxRot(88700243816673L), 88700243816673L);
        testing(MaxRotate.MaxRot(65879065959482L), 65879065959482L);
        testing(MaxRotate.MaxRot(88361793184682L), 88361793184682L);
        testing(MaxRotate.MaxRot(91556298303742L), 91556298303742L);
    }

    //-----------------------    
    private static long MaxRotSol (long n) 
    {
        string s = n.ToString(); string res = ""; long mx = n;
        if (s.Length == 1) return n;
        while (true) {
            string r = "";
            for (int i = 0; i < s.Length; ++i){ r = s.Substring(1) + s[0]; };
            s = r;
            res += s[0];
            s = s.Substring(1);
            long nb = (long)Convert.ToInt64(res + s);
            if (nb > mx) mx = nb;
            if (s.Length == 1) break;
        }
        return mx;
    }

    //-----------------------
    private static Random rnd = new Random();
[Test]    
    public static void RandomTest1() 
    {
        Console.WriteLine("Random Tests");
        for (int i = 0; i < 200; i++) 
        {
            long n = (long)rnd.Next(10000, 100000000) * 111 + 1;
            //Console.WriteLine(n);
            long r = MaxRotSol(n);
            testing(MaxRotate.MaxRot(n), r);
        }
    }
}
