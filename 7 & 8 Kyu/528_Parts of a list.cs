/*Challenge link:https://www.codewars.com/kata/56f3a1e899b386da78000732/train/csharp
Question:
Write a function partlist that gives all the ways to divide a list (an array) of at least two elements into two non-empty parts.

Each two non empty parts will be in a pair (or an array for languages without tuples or a structin C - C: see Examples test Cases - )
Each part will be in a string
Elements of a pair must be in the same order as in the original array.
Examples of returns in different languages:
a = ["az", "toto", "picaro", "zone", "kiwi"] -->
[["az", "toto picaro zone kiwi"], ["az toto", "picaro zone kiwi"], ["az toto picaro", "zone kiwi"], ["az toto picaro zone", "kiwi"]] 
or
 a = {"az", "toto", "picaro", "zone", "kiwi"} -->
{{"az", "toto picaro zone kiwi"}, {"az toto", "picaro zone kiwi"}, {"az toto picaro", "zone kiwi"}, {"az toto picaro zone", "kiwi"}}
or
a = ["az", "toto", "picaro", "zone", "kiwi"] -->
[("az", "toto picaro zone kiwi"), ("az toto", "picaro zone kiwi"), ("az toto picaro", "zone kiwi"), ("az toto picaro zone", "kiwi")]
or 
a = [|"az", "toto", "picaro", "zone", "kiwi"|] -->
[("az", "toto picaro zone kiwi"), ("az toto", "picaro zone kiwi"), ("az toto picaro", "zone kiwi"), ("az toto picaro zone", "kiwi")]
or
a = ["az", "toto", "picaro", "zone", "kiwi"] -->
"(az, toto picaro zone kiwi)(az toto, picaro zone kiwi)(az toto picaro, zone kiwi)(az toto picaro zone, kiwi)"
Note
You can see other examples for each language in "Your test cases"
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
/*
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣤⣤⣤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣀⠀⠀⠀⢀⣴⠟⠉⠀⠀⠀⠈⠻⣦⡀⠀⠀⠀⣤⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣷⣀⢀⣾⠿⠻⢶⣄⠀⠀⣠⣶⡿⠶⣄⣠⣾⣿⠗⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠉⢻⣿⣿⡿⣿⠿⣿⡿⢼⣿⣿⡿⣿⣎⡟⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⡟⠉⠛⢛⣛⡉⠀⠀⠙⠛⠻⠛⠑⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⣧⣤⣴⠿⠿⣷⣤⡤⠴⠖⠳⣄⣀⣹⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⣿⣀⣟⠻⢦⣀⡀⠀⠀⠀⠀⣀⡈⠻⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣼⡿⠉⡇⠀⠀⠛⠛⠛⠋⠉⠉⠀⠀⠀⠹⢧⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣾⡟⠀⢦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠃⠀⠈⠑⠪⠷⠤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣾⣿⣿⣿⣦⣼⠛⢦⣤⣄⡀⠀⠀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠑⠢⡀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⢀⣠⠴⠲⠖⠛⠻⣿⡿⠛⠉⠉⠻⠷⣦⣽⠿⠿⠒⠚⠋⠉⠁⡞⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⢦⠀⠀⠀⠀
⠀⠀⠀⠀⠀⢀⣾⠛⠁⠀⠀⠀⠀⠀⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠤⠒⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢣⠀⠀⠀
⠀⠀⠀⠀⣰⡿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣑⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⡇⠀⠀
⠀⠀⠀⣰⣿⣁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⣧⣄⠀⠀⠀⠀⠀⠀⢳⡀⠀
⠀⠀⠀⣿⡾⢿⣀⢀⣀⣦⣾⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡰⣫⣿⡿⠟⠻⠶⠀⠀⠀⠀⠀⢳⠀
⠀⠀⢀⣿⣧⡾⣿⣿⣿⣿⣿⡷⣶⣤⡀⠀⠀⠀⠀⠀⠀⠀⢀⡴⢿⣿⣧⠀⡀⠀⢀⣀⣀⢒⣤⣶⣿⣿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇
⠀⠀⡾⠁⠙⣿⡈⠉⠙⣿⣿⣷⣬⡛⢿⣶⣶⣴⣶⣶⣶⣤⣤⠤⠾⣿⣿⣿⡿⠿⣿⠿⢿⣿⣿⣿⣿⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇
⠀⣸⠃⠀⠀⢸⠃⠀⠀⢸⣿⣿⣿⣿⣿⣿⣷⣾⣿⣿⠟⡉⠀⠀⠀⠈⠙⠛⠻⢿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇
⠀⣿⠀⠀⢀⡏⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⠿⠿⠛⠛⠉⠁⠀⠀⠀⠀⠀⠉⠠⠿⠟⠻⠟⠋⠉⢿⣿⣦⡀⢰⡀⠀⠀⠀⠀⠀⠀⠁
⢀⣿⡆⢀⡾⠀⠀⠀⠀⣾⠏⢿⣿⣿⣿⣯⣙⢷⡄⠀⠀⠀⠀⠀⢸⡄⠀⠀⠀⠀⠀⠀⠀⠀⢀⣤⣿⣻⢿⣷⣀⣷⣄⠀⠀⠀⠀⢸⠀
⢸⠃⠠⣼⠃⠀⠀⣠⣾⡟⠀⠈⢿⣿⡿⠿⣿⣿⡿⠿⠿⠿⠷⣄⠈⠿⠛⠻⠶⢶⣄⣀⣀⡠⠈⢛⡿⠃⠈⢿⣿⣿⡿⠀⠀⠀⠀⠀⡀
⠟⠀⠀⢻⣶⣶⣾⣿⡟⠁⠀⠀⢸⣿⢅⠀⠈⣿⡇⠀⠀⠀⠀⠀⣷⠂⠀⠀⠀⠀⠐⠋⠉⠉⠀⢸⠁⠀⠀⠀⢻⣿⠛⠀⠀⠀⠀⢀⠇
⠀⠀⠀⠀⠹⣿⣿⠋⠀⠀⠀⠀⢸⣧⠀⠰⡀⢸⣷⣤⣤⡄⠀⠀⣿⡀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡆⠀⠀⠀⠀⡾⠀⠀⠀⠀⠀⠀⢼⡇
⠀⠀⠀⠀⠀⠙⢻⠄⠀⠀⠀⠀⣿⠉⠀⠀⠈⠓⢯⡉⠉⠉⢱⣶⠏⠙⠛⠚⠁⠀⠀⠀⠀⠀⣼⠇⠀⠀⠀⢀⡇⠀⠀⠀⠀⠀⠀⠀⡇
⠀⠀⠀⠀⠀⠀⠻⠄⠀⠀⠀⢀⣿⠀⢠⡄⠀⠀⠀⣁⠁⡀⠀⢠⠀⠀⠀⠀⠀⠀⠀⠀⢀⣐⡟⠀⠀⠀⠀⢸⡇⠀⠀⠀⠀⠀⠀⢠⡇⠀⠀⠀⠀⠀
*/
//x is the current element, i is the index,
//join the elements from arr start from arr 0 upto i,
////join the elements from arr start from arr i upto the end,
//skip the first 1 index because it's empty, convert to array and return the result.
using System.Linq;
public class PartList{
    public static string[][] Partlist(string[] arr)  => 
      arr.Select((x,i) => new[]{
          string.Join(" ",arr[0..i]) ,
          string.Join(" ", arr[i..])
          }).Skip(1).ToArray();
}

//solution 2
  using System.Linq;

public class PartList
{
  public static string[][] Partlist(string[] arr)
  {
    return arr.Select((s, i) => new[] {string.Join(" ", arr.Take(i)), string.Join(" ", arr.Skip(i))}).Skip(1).ToArray();
  }
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public static class PartListTests 
{
    private static void testing(string actual, string expected) 
    {
        Assert.AreEqual(expected, actual);
    }
[Test]
    public static void test0() 
    {        
        Console.WriteLine("Fixed Tests Partlist");

        String[] s1 = new String[] {"cdIw", "tzIy", "xDu", "rThG"};
        String a = "[[cdIw, tzIy xDu rThG], [cdIw tzIy, xDu rThG], [cdIw tzIy xDu, rThG]]";
        testing(cdecode.Helper.Array2DToString(PartList.Partlist(s1)), a); 
        
        s1 = new String[] {"I", "wish", "I", "hadn't", "come"};
        a = "[[I, wish I hadn't come], [I wish, I hadn't come], [I wish I, hadn't come], [I wish I hadn't, come]]";
        testing(cdecode.Helper.Array2DToString(PartList.Partlist(s1)), a); 
        
        s1 = new String[] {"vJQ", "anj", "mQDq", "sOZ"};
        a = "[[vJQ, anj mQDq sOZ], [vJQ anj, mQDq sOZ], [vJQ anj mQDq, sOZ]]";
        testing(cdecode.Helper.Array2DToString(PartList.Partlist(s1)), a); 
        
        s1 = new String[] {"mkC", "WoiP", "pCHh", "mkv"};
        a = "[[mkC, WoiP pCHh mkv], [mkC WoiP, pCHh mkv], [mkC WoiP pCHh, mkv]]";
        testing(cdecode.Helper.Array2DToString(PartList.Partlist(s1)), a); 
        
        s1 = new String[] {"vHW", "bPq", "pme", "jJr", "HGHV"};
        a = "[[vHW, bPq pme jJr HGHV], [vHW bPq, pme jJr HGHV], [vHW bPq pme, jJr HGHV], [vHW bPq pme jJr, HGHV]]";
        testing(cdecode.Helper.Array2DToString(PartList.Partlist(s1)), a); 
        
        s1 = new String[] {"YZd", "ptUD", "IXr"};
        a = "[[YZd, ptUD IXr], [YZd ptUD, IXr]]";
        testing(cdecode.Helper.Array2DToString(PartList.Partlist(s1)), a);
        
        s1 = new String[] {"UQB", "aIfC", "eVB", "aCL", "bWoU"};
        a = "[[UQB, aIfC eVB aCL bWoU], [UQB aIfC, eVB aCL bWoU], [UQB aIfC eVB, aCL bWoU], [UQB aIfC eVB aCL, bWoU]]";
        testing(cdecode.Helper.Array2DToString(PartList.Partlist(s1)), a); 
        
    }
    //-----------------------
    private static Random rnd = new Random(); 
    public static string[] DoEx(int k) {
        int j = 0;
        string[] a1 = new string[k];
        while (j < k) 
        {
            string res = "";
            int n = -1;
            int u = rnd.Next(3, 7);
            for (int i = 0; i < u ; i++) 
            {
                if (rnd.Next(0, 100) % 2 == 0) n = rnd.Next(97, 122); 
                else n = rnd.Next(65, 90);
                res += (char)n;
            }
            a1[j] = res;
            j++;
        }
        return a1;
    }
    private static string[][] PartlistSol(string[] arr) 
    {
        string[][] bigres = new string[arr.Length - 1][];
        int i = 0;
        while (i < arr.Length - 1) 
        {
            string[] res = new string[2];
            string s = "";
            for (int u = 0; u < i + 1; u++) s += arr[u] + " ";
            res[0] = s.Trim();
            
            s = "";
            for (int u = i+1; u < arr.Length; u++) s += arr[u] + " ";
            res[1] = s.Trim();
            bigres[i] = res;
            i++;
        }
        return bigres;
    }    
    //-----------------------
[Test]
    public static void test4() {
        Console.WriteLine("Random Tests **** Partlist");
        for (int i = 0; i < 200; i++) 
        {
            string[] a = DoEx(rnd.Next(6, 12));
            //Console.WriteLine("Input \n" + a);
            string[][] r = PartlistSol(a);
            string[][] op = PartList.Partlist(a);
            testing(cdecode.Helper.Array2DToString(op), cdecode.Helper.Array2DToString(r));
        }
    }  
}
