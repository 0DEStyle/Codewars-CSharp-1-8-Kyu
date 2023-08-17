/*Challenge link:https://www.codewars.com/kata/573992c724fc289553000e95/train/csharp
Question:
You have a positive number n consisting of digits. You can do at most one operation: Choosing the index of a digit in the number, remove this digit at that index and insert it back to another or at the same place in the number in order to find the smallest number you can get.

Task:
Return an array or a tuple or a string depending on the language (see "Sample Tests") with

the smallest number you got
the index i of the digit d you took, i as small as possible
the index j (as small as possible) where you insert this digit d to have the smallest number.
Examples:
smallest(261235) --> [126235, 2, 0] or (126235, 2, 0) or "126235, 2, 0"
126235 is the smallest number gotten by taking 1 at index 2 and putting it at index 0

smallest(209917) --> [29917, 0, 1] or ...

[29917, 1, 0] could be a solution too but index `i` in [29917, 1, 0] is greater than 
index `i` in [29917, 0, 1].
29917 is the smallest number gotten by taking 2 at index 0 and putting it at index 1 which gave 029917 which is the number 29917.

smallest(1000000) --> [1, 0, 6] or ...
Note
Have a look at "Sample Tests" to see the input and output in each language


*/

//***************Solution********************
using System;

public class ToSmallest {
  public static long[] Smallest (long n){
    //tuple format
    var ans = new long[] {n, 0, 0};
    var str = n.ToString();
    
    for (int i = 0; i < str.Length; i++){
      var d = str.Substring(i, 1);
      var s = str.Remove(i, 1);
      
      for (int j = 0; j < str.Length; j++){
        var m = Convert.ToInt64(s.Insert(j, d));
        //change and insert
        if (m < ans[0]) {
          ans[0] = m; 
          ans[1] = i; 
          ans[2] = j; 
          }
      }
    }
    return ans;
  }
}
//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public static class ToSmallestTests 
{

    private static void testing(long n, string res) 
    {
        Assert.AreEqual(res, Array2String(ToSmallest.Smallest(n)));
    }
    private static string Array2String( long[] list )
    {
        return "[" + string.Join(", ", list) + "]";
    }
[Test]
    public static void test1() 
    {        
        Console.WriteLine("Basic Tests smallest");
        testing(261235, "[126235, 2, 0]");
        testing(209917, "[29917, 0, 1]");
        testing(285365, "[238565, 3, 1]");
        testing(269045, "[26945, 3, 0]");
        testing(296837, "[239687, 4, 1]");

        testing(187863002809, "[18786300289, 10, 0]");
        testing(199819884756, "[119989884756, 4, 0]");
        testing(94883608842, "[9488368842, 6, 0]");
        testing(256687587015, "[25668758715, 9, 0]");
        testing(935855753, "[358557539, 0, 8]");
        testing(111111111, "[111111111, 0, 0]");
    }
    //-----------------------
    private static Random rnd = new Random();
    private static long RLong(long min, long max)
    {
        return min + (long)(rnd.NextDouble() * (max - min));
    }
    private static long[] SmallestSol (long n)
    {
        string s = n.ToString(), tmp = s; long [] mem = new long[] {-1, -1, -1};
        int l = s.Length;
        for (int i = 0; i < l; i++)
        {
            char c = s[i];
            for (int j = 0; j < l; j++)
            {
                String newtmp = s.Remove(i, 1);
                newtmp = newtmp.Insert(j, c.ToString());
                int cmp = String.Compare(newtmp, tmp);
                if (cmp < 0)
                {
                    tmp = newtmp;
                    mem[0] = Convert.ToInt64(tmp);  mem[1] = i; mem[2] = j;
                }
            }
        }
        if (mem[0] == -1) 
        {
          mem[0] = n;  mem[1] = 0; mem[2] = 0;
        }
        return mem;
    }
    //-----------------------
    private static void test2() 
    {
        int i = 0;
        while (i < 200) {
            long nmx = RLong(4000, 1000000000000000000);
            string ans = Array2String(SmallestSol(nmx));
            //Console.WriteLine("number " + nmx + " --> " + ans);
            testing(nmx, ans);
            i++;
        }
    }
[Test] 
    public static void RandomTests() 
    { 
        Console.WriteLine("Random Tests******* smallest");
        test2();
    } 
}
