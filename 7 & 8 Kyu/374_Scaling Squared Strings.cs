/*Challenge link:https://www.codewars.com/kata/56ed20a2c4e5d69155000301/train/csharp
Question:
You are given a string of n lines, each substring being n characters long. For example:

s = "abcd\nefgh\nijkl\nmnop"

We will study the "horizontal" and the "vertical" scaling of this square of strings.

A k-horizontal scaling of a string consists of replicating k times each character of the string (except '\n').

Example: 2-horizontal scaling of s: => "aabbccdd\neeffgghh\niijjkkll\nmmnnoopp"
A v-vertical scaling of a string consists of replicating v times each part of the squared string.

Example: 2-vertical scaling of s: => "abcd\nabcd\nefgh\nefgh\nijkl\nijkl\nmnop\nmnop"
Function scale(strng, k, v) will perform a k-horizontal scaling and a v-vertical scaling.

Example: a = "abcd\nefgh\nijkl\nmnop"
scale(a, 2, 3) --> "aabbccdd\naabbccdd\naabbccdd\neeffgghh\neeffgghh\neeffgghh\niijjkkll\niijjkkll\niijjkkll\nmmnnoopp\nmmnnoopp\nmmnnoopp"
Printed:

abcd   ----->   aabbccdd
efgh            aabbccdd
ijkl            aabbccdd
mnop            eeffgghh
                eeffgghh
                eeffgghh
                iijjkkll
                iijjkkll
                iijjkkll
                mmnnoopp
                mmnnoopp
                mmnnoopp
Task:
Write function scale(strng, k, v) k and v will be positive integers. If strng == "" return "".
*/

//***************Solution********************


      //k horizontal n vertical
      //split strng by "\n", x is the current element,
      //if there is any element, from x select each char, create new string ch by k times, concat the result.
      //then repeat the string by n times using enumerable.repeat
      //if there is no element, return "".
      //finally join the result together by "\n"
      //Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Linq;

public class Scaling{
    public static string Scale(string strng, int k, int n) => 
      string.Join("\n", strng.Split("\n").Select(x => x.Any() ? 
                  string.Join("\n", Enumerable.Repeat(string.Concat(x.Select(ch => new string(ch,k))),n)) 
                  : ""));
}

//****************Sample Test*****************
using System;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public static class ScalingTests 
{
    private static void testing(string actual, string expected) 
    {
        Assert.AreEqual(expected, actual);
    }
[Test]
    public static void test1() 
    {        
        Console.WriteLine("Fixed Tests scale");
        String a ="abcd\nefgh\nijkl\nmnop";
        String r = "aabbccdd\naabbccdd\naabbccdd\neeffgghh\neeffgghh\neeffgghh\niijjkkll\n"
                + "iijjkkll\niijjkkll\nmmnnoopp\nmmnnoopp\nmmnnoopp";
        testing(Scaling.Scale(a, 2, 3), r);
     
        testing(Scaling.Scale("", 5, 5), "");

        testing(Scaling.Scale("Kj\nSH", 1, 2),"Kj\nKj\nSH\nSH");
        testing(Scaling.Scale("lxnT\nqiut\nZZll\nFElq", 1, 2), 
                "lxnT\nlxnT\nqiut\nqiut\nZZll\nZZll\nFElq\nFElq");

        r = "YYVVjjoossWW\nYYVVjjoossWW\nHHGGhhKKGGZZ\nHHGGhhKKGGZZ\nLLHHNNMMLLmm\n"
                + "LLHHNNMMLLmm\nJJttccWWCCjj\n"
                + "JJttccWWCCjj\nggVVttjjyykk\nggVVttjjyykk\nOOJJBBkkOOKK\nOOJJBBkkOOKK";
        testing(Scaling.Scale("YVjosW\nHGhKGZ\nLHNMLm\nJtcWCj\ngVtjyk\nOJBkOK", 2, 2), r);

        r = "YVjosW\nYVjosW\nHGhKGZ\nHGhKGZ\nLHNMLm\nLHNMLm\nJtcWCj\nJtcWCj\ngVtjyk\ngVtjyk\n"
                + "OJBkOK\nOJBkOK";
        testing(Scaling.Scale("YVjosW\nHGhKGZ\nLHNMLm\nJtcWCj\ngVtjyk\nOJBkOK", 1, 2), r);

        testing(Scaling.Scale("WgaB\nMmIn\nqJwv\nAhho", 2, 1), "WWggaaBB\nMMmmIInn\nqqJJwwvv\nAAhhhhoo");

        testing(Scaling.Scale("CG\nla", 2, 3), "CCGG\nCCGG\nCCGG\nllaa\nllaa\nllaa");
    }
    //-----------------------
    private static string repCharSol(int n, char ch)
    {
        return new string(ch, n);
    }
    private static string repStrSol(int n, string s)
    {
        //return string.Concat(Enumerable.Repeat(s, n).ToArray());
        return string.Join("\n", Enumerable.Repeat(s, n).ToArray());
    }
    private static string accumSol(string s, int k)
    {
        char[] a = s.ToCharArray();
        return String.Join("", a.Select(x => repCharSol(k, x)).ToArray());
    }
    public static string ScaleSol(string strng, int k, int n) 
    {
        if (strng.Length == 0) return "";
        string[] arr1 = strng.Split('\n');
        string[] newarr1 = arr1.Select(x => repStrSol(n, accumSol(x, k))).ToArray();
        return String.Join("\n", newarr1);
    }    
    
    private static Random rnd = new Random();

    private static string DoEx(int k) {
        if (k % 2 == 1) k += 1;
        int j = 0; string[] res = new string[k];
        while (j < k) 
        {
            string s = ""; int i = 0;
            while (i < k) 
            {
                if (rnd.Next(0, 100) % 2 == 0) s += Char.ToString((char)rnd.Next(97, 122));
                else s += Char.ToString((char)rnd.Next(65, 90));
                i++;
            }
            res[j] = s;
            j += 1;
        }
        return string.Join("\n", res);
    }
    //-----------------------
[Test]
    public static void test2() {
        Console.WriteLine("Random Tests **** scale");
        for (int i = 0; i < 200; i++) 
        {
            string v = DoEx(rnd.Next(3, 6));
            int k = rnd.Next(2, 3);
            int n = k + 1;
            testing(Scaling.Scale(v, k, n), ScaleSol(v, k, n));
        }
    }
}
