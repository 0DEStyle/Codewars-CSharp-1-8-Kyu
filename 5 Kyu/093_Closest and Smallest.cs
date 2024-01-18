/*Challenge link:https://www.codewars.com/kata/5868b2de442e3fb2bb000119/train/csharp
Question:
Input
a string strng of n positive numbers (n = 0 or n >= 2)
Let us call weight of a number the sum of its digits. For example 99 will have "weight" 18, 100 will have "weight" 1.

Two numbers are "close" if the difference of their weights is small.

Task:
For each number in strng calculate its "weight" and then find two numbers of strng that have:

the smallest difference of weights ie that are the closest
with the smallest weights
and with the smallest indices (or ranks, numbered from 0) in strng
Output:
an array of two arrays, each subarray in the following format:
[number-weight, index in strng of the corresponding number, original corresponding number in strng]

or a pair of two subarrays (Haskell, Clojure, FSharp) or an array of tuples (Elixir, C++)

or a (char*) in C or a string in some other languages mimicking an array of two subarrays or a string

or a matrix in R (2 rows, 3 columns, no columns names)

The two subarrays are sorted in ascending order by their number weights if these weights are different, by their indexes in the string if they have the same weights.

Examples:
Let us call that function closest

strng = "103 123 4444 99 2000"
the weights are 4, 6, 16, 18, 2 (ie 2, 4, 6, 16, 18)

closest should return [[2, 4, 2000], [4, 0, 103]] (or ([2, 4, 2000], [4, 0, 103])
or [{2, 4, 2000}, {4, 0, 103}] or ... depending on the language)
because 2000 and 103 have for weight 2 and 4, their indexes in strng are 4 and 0.
The smallest difference is 2.
4 (for 103) and 6 (for 123) have a difference of 2 too but they are not 
the smallest ones with a difference of 2 between their weights.
....................

strng = "80 71 62 53"
All the weights are 8.
closest should return [[8, 0, 80], [8, 1, 71]]
71 and 62 have also:
- the smallest weights (which is 8 for all)
- the smallest difference of weights (which is 0 for all pairs)
- but not the smallest indices in strng.
....................

strng = "444 2000 445 544"
the weights are 12, 2, 13, 13 (ie 2, 12, 13, 13)

closest should return [[13, 2, 445], [13, 3, 544]] or ([13, 2, 445], [13, 3, 544])
or [{13, 2, 445}, {13, 3, 544}] or ...
444 and 2000 have the smallest weights (12 and 2) but not the smallest difference of weights;
they are not the closest.
Here the smallest difference is 0 and in the result the indexes are in ascending order.
...................

closest("444 2000 445 644 2001 1002") --> [[3, 4, 2001], [3, 5, 1002]] or ([3, 4, 2001], 
[3, 5, 1002]]) or [{3, 4, 2001}, {3, 5, 1002}] or ...
Here the smallest difference is 0 and in the result the indexes are in ascending order.
...................

closest("239382 162 254765 182 485944 468751 49780 108 54")
The weights are: 27, 9, 29, 11, 34, 31, 28, 9, 9.
closest should return  [[9, 1, 162], [9, 7, 108]] or ([9, 1, 162], [9, 7, 108]) 
or [{9, 1, 162}, {9, 7, 108}] or ...
108 and 54 have the smallest difference of weights too, they also have 
the smallest weights but they don't have the smallest ranks in the original string.
..................

closest("54 239382 162 254765 182 485944 468751 49780 108")
closest should return  [[9, 0, 54], [9, 2, 162]] or ([9, 0, 54], [9, 2, 162])
or [{9, 0, 54}, {9, 2, 162}] or ...
Notes :
If n == 0 closest("") should return []

or ([], []) in Haskell, Clojure, FSharp

or [{}, {}] in Elixir or '(() ()) in Racket

or {{0,0,0}, {0,0,0}} in C++

or "[(), ()]" in Go, Nim,

or "{{0,0,0}, {0,0,0}}" in C, NULL in R

or "" in Perl.

See Example tests for the format of the results in your language.


*/

//***************Solution********************
/*
    ∧＿∧
　 (｡･ω･｡)つ━☆・*。
  ⊂/　     /　   ・゜
　しーＪ　　　     °。+ * 。　
　　　　　                      .・゜
　　　　　                      ゜｡ﾟﾟ･｡･ﾟﾟ。
　　　　                         　ﾟ。　 　｡ﾟ
                                              　ﾟ･｡･ﾟ ૮˶• ﻌ •˶ა
                                                             ./づ~ /づ🦴
weight =  sum of its digits 
e.g. 99 => 9 + 9 = 18
close if weight difference is small

str = "103 123 4444 99 2000"
index     num     weight
0         103  => 4
1         123  => 6
2         4444 => 16
3         99   => 18
4         2000 => 2

sort 2,4,6,16,18

2000 and 103
4    and 0
2    and 4

res = [[2, 4, 2000], [4, 0, 103]]



output closest 
arr[0]  => [number-weight, index in str of the corresponding number, original corresponding number in str]
arr[1] => [ , , ]

two subarrays sorted in ascending order by their number weights (if weights are different)
by their indexes in the string (if same weights)

*/
using System;
using System.Linq;


public class ClosestWeight{
    public static int[][] Closest(string str){
      if(str == null || str == "") return new int[0][];
      
      //split string, sum the digits in each element to find the weight
      //format: [number-weight, str index of corresponding number, original corresponding number in str]
      //order x[0] in acending order, then x[1], store in array
      var arr = str.Split().Select((x,i) => new[]{x.Sum(y => y - '0'), i , int.Parse(x)})
                           .OrderBy(x => x[0])
                           .ThenBy(x => x[1])
                           .ToArray();
      
      /* print jank to for visualisation
      Console.WriteLine("str: " + str);
      foreach(var i in arr)
          Console.WriteLine(string.Join(",", i));
      */
      
      //set current closest two numbers as arr[0] and arr[1]
      //diff is the difference between those numbers
      var diff = arr[1][0] - arr[0][0];
      var one = arr[0]; 
      var two = arr[1];
      
      //iterate through the arr,
      //if there are even smaller number 
      //update the difference, 
      //set one to previous i, and two as current i
      for(int i = 2; i < arr.Length; i++){
        if(arr[i][0] - arr[i - 1][0] < diff){
          diff = arr[i][0] - arr[i - 1][0];
          one = arr[i - 1];
          two = arr[i];
        }
      }
        return new[] {one, two};
    }
}

//solution 2
using System;
using System.Linq;

public class ClosestWeight
{
  public static int[][] Closest(string s) 
  {
    var w = s.Split().Select((x,i) => new []{ x.Sum(c => c - '0'), i, Int32.Parse(x) }).OrderBy(x => x[0]);
    return s.Length == 0 ? new int[0][] :
           w.Zip(w.Skip(1), (a, b) => new { D = b[0] - a[0], V = new []{a, b} }).OrderBy(x => x.D).First().V;
  }
}

//****************Sample Test*****************
using System;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public static class ClosestWeightTests 
{

    private static void testing(String actual, String expected) 
    {
        Assert.AreEqual(expected, actual);
    }
[Test]
    public static void test1() 
    {        
        Console.WriteLine("Basic Tests Closest");
        string s = "239382 162 254765 182 485944 134 468751 62 49780 108 54";
        string r = "[[8, 5, 134], [8, 7, 62]]";
        testing(cdecode.Helper.Array2DToString(ClosestWeight.Closest(s)), r);
        s = "456899 50 11992 176 272293 163 389128 96 290193 85 52";
        r = "[[13, 9, 85], [14, 3, 176]]";
        testing(cdecode.Helper.Array2DToString(ClosestWeight.Closest(s)), r);
        s = "241259 154 155206 194 180502 147 300751 200 406683 37 57";
        r = "[[10, 1, 154], [10, 9, 37]]";
        testing(cdecode.Helper.Array2DToString(ClosestWeight.Closest(s)), r);
        s = "89998 187 126159 175 338292 89 39962 145 394230 167 1";
        r = "[[13, 3, 175], [14, 9, 167]]";
        testing(cdecode.Helper.Array2DToString(ClosestWeight.Closest(s)), r);
        s = "462835 148 467467 128 183193 139 220167 116 263183 41 52";
        r = "[[13, 1, 148], [13, 5, 139]]";
        testing(cdecode.Helper.Array2DToString(ClosestWeight.Closest(s)), r);

        s = "403749 18 278325 97 304194 119 58359 165 144403 128 38";
        r = "[[11, 5, 119], [11, 9, 128]]";
        testing(cdecode.Helper.Array2DToString(ClosestWeight.Closest(s)), r);
        s = "28706 196 419018 130 49183 124 421208 174 404307 60 24";
        r = "[[6, 9, 60], [6, 10, 24]]";
        testing(cdecode.Helper.Array2DToString(ClosestWeight.Closest(s)), r);
        s = "189437 110 263080 175 55764 13 257647 53 486111 27 66";
        r = "[[8, 7, 53], [9, 9, 27]]";
        testing(cdecode.Helper.Array2DToString(ClosestWeight.Closest(s)), r);
        s = "79257 160 44641 146 386224 147 313622 117 259947 155 58";
        r = "[[11, 3, 146], [11, 9, 155]]";
        testing(cdecode.Helper.Array2DToString(ClosestWeight.Closest(s)), r);
        s = "315411 165 53195 87 318638 107 416122 121 375312 193 59";
        r = "[[15, 0, 315411], [15, 3, 87]]";
        testing(cdecode.Helper.Array2DToString(ClosestWeight.Closest(s)), r);

        s = "121182 136 271641 158 426559 8 208538 100 314653 161 16";
        r = "[[8, 5, 8], [8, 9, 161]]";
        testing(cdecode.Helper.Array2DToString(ClosestWeight.Closest(s)), r);
        s = "15474 142 219499 53 317449 192 250542 97 187560 63 26";
        r = "[[8, 3, 53], [8, 10, 26]]";
        testing(cdecode.Helper.Array2DToString(ClosestWeight.Closest(s)), r);
        s = "240695 7 300451 98 13433 148 166540 17 36236 128 51";
        r = "[[13, 2, 300451], [13, 5, 148]]";
        testing(cdecode.Helper.Array2DToString(ClosestWeight.Closest(s)), r);
        s = "353574 14 61847 25 451179 70 58901 75 229007 60 99";
        r = "[[7, 3, 25], [7, 5, 70]]";
        testing(cdecode.Helper.Array2DToString(ClosestWeight.Closest(s)), r);
        s = "221161 198 242445 166 463297 56 332326 179 250617 54 17";
        r = "[[13, 0, 221161], [13, 3, 166]]";
        testing(cdecode.Helper.Array2DToString(ClosestWeight.Closest(s)), r);

        s = "202174 186 177039 94 189002 66 94235 112 326314 66 48";
        r = "[[12, 5, 66], [12, 9, 66]]";
        testing(cdecode.Helper.Array2DToString(ClosestWeight.Closest(s)), r);
        s = "294748 92 236912 86 185687 30 233059 2 87792 154 8";
        r = "[[2, 7, 2], [3, 5, 30]]";
        testing(cdecode.Helper.Array2DToString(ClosestWeight.Closest(s)), r);
        s = "220489 190 161764 5 484420 14 181644 173 252343 86 35";
        r = "[[5, 3, 5], [5, 5, 14]]";
        testing(cdecode.Helper.Array2DToString(ClosestWeight.Closest(s)), r);
        s = "466874 170 333771 177 44791 15 80369 166 361158 116 16";
        r = "[[8, 1, 170], [8, 9, 116]]";
        testing(cdecode.Helper.Array2DToString(ClosestWeight.Closest(s)), r);
        s = "171595 73 449051 66 243548 56 24997 76 240264 86 17";
        r = "[[10, 1, 73], [11, 5, 56]]";
        testing(cdecode.Helper.Array2DToString(ClosestWeight.Closest(s)), r);        
    }
    //-----------------------
  
    private static Random rnd = new Random();
  
    private static string DoEx() 
    {
        string res = "";
        for (int i =  0; i < 30; i++) {
            int n = rnd.Next(1, 500000);
            res += n.ToString() + " ";
        }
        int u = rnd.Next(1, 100);
        return res + u.ToString();
    }

    private static int cmp(int[] x, int[] y) 
    {
        int cp =  x[0] - y[0];
        if (cp == 0) 
            return x[1].CompareTo(y[1]);
        if (cp < 0) return -1; else return 1;
    }
    private static int[][] ClosestSol(string strng) 
    {
        if (strng.Equals("")) return new int[][] {};
        string[] nums = strng.Split(' ');
        int[][] l = Enumerable.Range(0, nums.Length)
            .Select(v => new int[] { nums[v].Sum(x => (int)Char.GetNumericValue(x)), v, Convert.ToInt32(nums[v]) })
            .ToArray();
        Array.Sort(l, cmp);
        int[][] k = Enumerable.Range(1, l.Length-1).Select(u => new int[] { l[u][0] - l[u-1][0], u }).ToArray();
        Array.Sort(k, cmp);
        int ndx = k[0][1];
        int[][] result = new int[2][]{ l[ndx - 1], l[ndx] };
        return result;
    }
     
    //-----------------------
    private static void test2() 
    {
        for (int i = 0; i < 200; i++) 
        {
            string a = DoEx();
            //Console.WriteLine(cdecode.Helper.Array2DToString(ClosestSol(a)));
            testing(cdecode.Helper.Array2DToString(ClosestWeight.Closest(a)), cdecode.Helper.Array2DToString(ClosestSol(a)));
        }
    }
[Test] 
    public static void RandomTests() 
    { 
        Console.WriteLine("Random Tests******* Closest");
        test2();
    } 
}
