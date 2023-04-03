/*Challenge link:https://www.codewars.com/kata/5a523566b3bfa84c2e00010b/train/csharp
Question:
Task
Given an array of integers , Find the minimum sum which is obtained from summing each Two integers product .

Notes
Array/list will contain positives only .
Array/list will always have even size
Input >> Output Examples
minSum({5,4,2,3}) ==> return (22) 
Explanation:
The minimum sum obtained from summing each two integers product ,  5*2 + 3*4 = 22
minSum({12,6,10,26,3,24}) ==> return (342)
Explanation:
The minimum sum obtained from summing each two integers product ,  26*3 + 24*6 + 12*10 = 342
minSum({9,2,8,7,5,4,0,6}) ==> return (74)
Explanation:
The minimum sum obtained from summing each two integers product ,  9*0 + 8*2 +7*4 +6*5 = 74

*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;
class Kata{
    public static int MinSum(int[] a){
      a = a.OrderBy(x=>x).ToArray();
        return Enumerable.Range(0,a.Length/2).Select((x,i) =>a[i]*a[a.Length-1-i]).Sum();
    }
}

//solution 2
//doing all in one line
using System.Linq;

class Kata
{
    public static int MinSum(int[] a)
        => a.OrderByDescending(x => x).Take(a.Length / 2)
            .Zip(a.OrderBy(x => x).Take(a.Length / 2), (f, s) => f * s)
            .Sum();
}

//****************Sample Test*****************
