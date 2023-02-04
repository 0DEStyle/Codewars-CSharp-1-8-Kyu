/*Challenge link:https://www.codewars.com/kata/56dbe0e313c2f63be4000b25/train/csharp
Question:
This kata is the first of a sequence of four about "Squared Strings".

You are given a string of n lines, each substring being n characters long: For example:

s = "abcd\nefgh\nijkl\nmnop"

We will study some transformations of this square of strings.

Vertical mirror: vert_mirror (or vertMirror or vert-mirror)
vert_mirror(s) => "dcba\nhgfe\nlkji\nponm"
Horizontal mirror: hor_mirror (or horMirror or hor-mirror)
 hor_mirror(s) => "mnop\nijkl\nefgh\nabcd"
or printed:

vertical mirror   |horizontal mirror   
abcd --> dcba     |abcd --> mnop 
efgh     hgfe     |efgh     ijkl 
ijkl     lkji     |ijkl     efgh 
mnop     ponm     |mnop     abcd 
Task:
Write these two functions
and

high-order function oper(fct, s) where

fct is the function of one variable f to apply to the string s (fct will be one of vertMirror, horMirror)

Examples:
s = "abcd\nefgh\nijkl\nmnop"
oper(vert_mirror, s) => "dcba\nhgfe\nlkji\nponm"
oper(hor_mirror, s) => "mnop\nijkl\nefgh\nabcd"
Note:
The form of the parameter fct in oper changes according to the language. You can see each form according to the language in "Sample Tests".

Bash Note:
The input strings are separated by , instead of \n. The output strings should be separated by \r instead of \n. See "Sample Tests".
*/

//***************Solution********************
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.


using System;
using System.Linq;
public class Opstrings{

//split string by every new line(\n), select each character and reverse it. Then join it back together with new line
    public  static string VertMirror(string strng) =>
      string.Join("\n", strng.Split("\n").Select(x => new String(x.Reverse().ToArray())));

//split string by every new line(\n), select each word and reverse it. Then join it back together with new line
    public  static string HorMirror(string strng)=> 
      string.Join("\n",strng.Split("\n").Reverse());
  
    public static string Oper(Func<string,string>fct, string s) => fct(s);
}
//****************Sample Test*****************
using System;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public static class OpstringsTests 
{
    private static void testing(string actual, string expected) 
    {
        Assert.AreEqual(expected, actual);
    }
[Test]
    public static void test1() 
    {        
        Console.WriteLine("Fixed Tests VertMirror");
        testing(Opstrings.Oper(Opstrings.VertMirror, "hSgdHQ\nHnDMao\nClNNxX\niRvxxH\nbqTVvA\nwvSyRu"), 
            "QHdgSh\noaMDnH\nXxNNlC\nHxxvRi\nAvVTqb\nuRySvw");
        testing(Opstrings.Oper(Opstrings.VertMirror, "IzOTWE\nkkbeCM\nWuzZxM\nvDddJw\njiJyHF\nPVHfSx"), 
            "EWTOzI\nMCebkk\nMxZzuW\nwJddDv\nFHyJij\nxSfHVP");
        testing(Opstrings.Oper(Opstrings.VertMirror, "cuQW\nxOuD\nfZwp\neqFx"), 
            "WQuc\nDuOx\npwZf\nxFqe");
        testing(Opstrings.Oper(Opstrings.VertMirror, "CDGIdolo\nUstXfrIg\ntMqjvxWL\nBEyuCnAm\nxsxaEERa\nxZsvOiZS\nLutlBRXE\ntxshhbqE"), 
            "olodIGDC\ngIrfXtsU\nLWxvjqMt\nmAnCuyEB\naREEaxsx\nSZiOvsZx\nEXRBltuL\nEqbhhsxt");
        Console.WriteLine("Fixed Tests HorMirror");
        testing(Opstrings.Oper(Opstrings.HorMirror, "lVHt\nJVhv\nCSbg\nyeCt"), "yeCt\nCSbg\nJVhv\nlVHt");
        testing(Opstrings.Oper(Opstrings.HorMirror, "njMK\ndbrZ\nLPKo\ncEYz"), "cEYz\nLPKo\ndbrZ\nnjMK");
        testing(Opstrings.Oper(Opstrings.HorMirror, "QMxo\ntmFe\nWLUG\nowoq"), "owoq\nWLUG\ntmFe\nQMxo");
        testing(Opstrings.Oper(Opstrings.HorMirror, "FYvi\ndZQn\nuGef\nQoSy"), "QoSy\nuGef\ndZQn\nFYvi");
    }
    //-----------------------
    private static string RevStrSol(String s)
    {
        char[] arr = s.ToCharArray(); Array.Reverse(arr); return new string(arr);
    }
    private  static string VertMirrorSol(string strng)
    {
        string[] arr = strng.Split('\n');
        string[] newarr = arr.Select(x => RevStrSol(x)).ToArray();
        return string.Join("\n", newarr);
    }
    private  static string HorMirrorSol(string strng)
    {
        string[] arr = strng.Split('\n');
        Array.Reverse(arr);
        return string.Join("\n", arr);
    }
    
    private static Random rnd = new Random();

    private static string DoEx(int k) 
    {
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
    public static void test2() 
    {
        Console.WriteLine("Random Tests **** VertMirror");
        for (int i = 0; i < 100; i++) 
        {
            string v = DoEx(rnd.Next(8, 20));
            //Console.WriteLine("Input String \n" + v);
            testing(Opstrings.Oper(Opstrings.VertMirror, v), VertMirrorSol(v));
        }
    }
[Test]
    public static void test3() 
    {
        Console.WriteLine("Random Tests **** HorMirror");
        for (int i = 0; i < 100; i++) 
        {
            string v = DoEx(rnd.Next(8, 20));
            //Console.WriteLine("Input String \n" + v);
            testing(Opstrings.Oper(Opstrings.HorMirror, v), HorMirrorSol(v));
        }
    }
}
