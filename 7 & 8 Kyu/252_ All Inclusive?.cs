/*Challenge link:https://www.codewars.com/kata/5700c9acc1555755be00027e/train/csharp
Question:
Input:

a string strng
an array of strings arr
Output of function contain_all_rots(strng, arr) (or containAllRots or contain-all-rots):

a boolean true if all rotations of strng are included in arr
false otherwise
Examples:
contain_all_rots(
  "bsjq", ["bsjq", "qbsj", "sjqb", "twZNsslC", "jqbs"]) -> true

contain_all_rots(
  "Ajylvpy", ["Ajylvpy", "ylvpyAj", "jylvpyA", "lvpyAjy", "pyAjylv", "vpyAjyl", "ipywee"]) -> false)
Note:
Though not correct in a mathematical sense

we will consider that there are no rotations of strng == ""
and for any array arr: contain_all_rots("", arr) --> true
Ref: https://en.wikipedia.org/wiki/String_(computer_science)#Rotations
*/

//***************Solution********************
//create a string, which is s + s, so that it contains all rotation
//check each combination inside s+s, by using .Substring(i, s.Length)
//if any combination is missing, return false.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;
using System.Collections.Generic;

public class Rotations{
  public static Boolean ContainAllRots(string s, List<string> arr) =>
    !s.Where((c, i) => !arr.Contains((s + s).Substring(i, s.Length))).Any();
}

//****************Sample Test*****************
using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public static class RotationsTests 
{

    private static void testing(Boolean actual, Boolean expected) 
    {
        Assert.AreEqual(expected, actual);
    }
[Test]
    public static void test1() 
    {        
        Console.WriteLine("Basic Tests ContainAllRots");     
        List<string> a = new List<string>(){ "bsjq", "qbsj", "sjqb", "twZNsslC", "jqbs" };
        testing(Rotations.ContainAllRots("bsjq", a), true);
        a = new List<string>(){ "TzYxlgfnhf", "yqVAuoLjMLy", "BhRXjYA", "YABhRXj", "hRXjYAB", "jYABhRX", "XjYABhR", "ABhRXjY" };
        testing(Rotations.ContainAllRots("XjYABhR", a), false);
        a = new List<string>(){ "hQmSQJA", "QJAhQmS", "QmSQJAh", "yUgUXoQE", "AhQmSQJ", "mSQJAhQ", "SQJAhQm", "JAhQmSQ" };
        testing(Rotations.ContainAllRots("QJAhQmS", a), true);
        a = new List<string>(){ "nVOETcaxdvuk", "shpEts", "hpEtss", "Etsshp", "OuIiQ", "sXrDdPXIaW", "tsshpE", "pEtssh" };
        testing(Rotations.ContainAllRots("Etsshp", a), false);
        a = new List<string>(){ "Ajylvpy", "ylvpyAj", "jylvpyA", "lvpyAjy", "pyAjylv", "vpyAjyl" };
        testing(Rotations.ContainAllRots("Ajylvpy", a), false);
        a = new List<string>(){ "numMfygcH", "HFMqhWv", "qhWvHFM", "ZJKKxM", "hWvHFMq", "MqhWvHF", "hfZWYSqk", "BTcSoEdchPlL", "WvHFMqh", "vHFMqhW", "FMqhWvH" };
        testing(Rotations.ContainAllRots("MqhWvHF", a), true);
        a = new List<string>(){ "vGUD", "UDvG", "GUDv", "DvGU" };
        testing(Rotations.ContainAllRots("UDvG", a), true);
        a = new List<string>(){ "ObPfws", "Cofuhqrmmzq", "wFvfcqU", "sObPfw", "bPfwsO", "PfwsOb", "wsObPf", "fwsObP" };
        testing(Rotations.ContainAllRots("sObPfw", a), true);
        a = new List<string>(){ "MKUck", "EDjfbQB", "GUPwzk", "SKZvilwnL", "UckMK", "KUckM", "kMKUc" };
        testing(Rotations.ContainAllRots("KUckM", a), false);
        a = new List<string>(){ "DIeF", "IeFD", "FDIe", "eFDI" };
        testing(Rotations.ContainAllRots("FDIe", a), true);
        a = new List<string>(){ "DIeF", "IeFD", "12341234", "41234123", "34123412", "23412341" };
        testing(Rotations.ContainAllRots("12341234", a), true);
    }
    //-----------------------
    private static List<string> RotationsArraySol(string strng) 
    {
        List<string> result = new List<string>();
        for (int index = 0; index < strng.Length; index++) 
        {
            string rotatedString = strng.Substring(index) + strng.Substring(0, index);
            if (result.Contains(rotatedString) == false)
                result.Add(rotatedString);
        }
        return result;
    }
    private static Boolean ContainAllRotsSol(string strng, List<string> arr) 
    {
        List<string> r = RotationsArraySol(strng);
        for (var i = 0; i < r.Count; i++)
            if (arr.IndexOf(r[i]) == -1)
                return false;
        return true;
    }
  
    private static Random rnd = new Random();
  
    private static string DoStr(int k) 
    {
        int i = 0; string s = "";
        while (i < k) 
        { 
            if (rnd.Next(0, 100) % 2 == 0) 
                s += (char)rnd.Next(97, 122);
            else s += (char)rnd.Next(65, 90);
            i++;
        }
        return s;
    }
    private static List<string> DoEx(string s) 
    {
        List<string> rot = RotationsArraySol(s);
        int k = rnd.Next(0, 100);
        if (k % 2 == 0) 
        {
            int u = rnd.Next(0, rot.Count-1);
            rot.RemoveAt(u);
        }
        int n = rnd.Next(0, 5);
        int i = 0;
        while (i < n) 
        {
            rot.Add(DoStr(rnd.Next(5, 12)));
            i++;
        }
        var rda = new Random();
        var result = rot.OrderBy(item => rda.Next());
        return result.ToList<string>();
    }    
    //-----------------------
    private static void test2() 
    {
        for (int i = 0; i < 200; i++) 
        {
            string a = DoStr(rnd.Next(8, 15));
            List<string> r = DoEx(a);
            Boolean sol = ContainAllRotsSol(a, r);
            testing(Rotations.ContainAllRots(a, r), sol);
        }
    }
[Test] 
    public static void RandomTests() 
    { 
        Console.WriteLine("Random Tests******* ContainAllRots");
        test2();
    } 
}
