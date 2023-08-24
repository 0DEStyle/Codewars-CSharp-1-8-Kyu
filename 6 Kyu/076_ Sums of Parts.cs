/*Challenge link:https://www.codewars.com/kata/5ce399e0047a45001c853c2b/train/csharp
Question:
Let us consider this example (array written in general format):

ls = [0, 1, 3, 6, 10]

Its following parts:

ls = [0, 1, 3, 6, 10]
ls = [1, 3, 6, 10]
ls = [3, 6, 10]
ls = [6, 10]
ls = [10]
ls = []
The corresponding sums are (put together in a list): [20, 20, 19, 16, 10, 0]

The function parts_sums (or its variants in other languages) will take as parameter a list ls and return a list of the sums of its parts as defined above.

Other Examples:
ls = [1, 2, 3, 4, 5, 6] 
parts_sums(ls) -> [21, 20, 18, 15, 11, 6, 0]

ls = [744125, 935, 407, 454, 430, 90, 144, 6710213, 889, 810, 2579358]
parts_sums(ls) -> [10037855, 9293730, 9292795, 9292388, 9291934, 9291504, 9291414, 9291270, 2581057, 2580168, 2579358, 0]
Notes
Take a look at performance: some lists have thousands of elements.
Please ask before translating.
*/

//***************Solution********************


//reverse array l, then aggregate
//Enumerable.Repeat 0 one time
//x current element, i index
//x prepend(add to beginning) the first of current element plus i
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

class SumParts{
    public static int[] PartsSums(int[] l) =>
      l.Reverse().Aggregate(Enumerable.Repeat(0, 1), (x, i) => x.Prepend(x.First() + i)).ToArray();
}

//****************Sample Test*****************
using System;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public static class SumPartsTests 
{
    private static void dotest(int[] ls, int[] exp) { 
        int[] ans = SumParts.PartsSums(ls);
        Assert.AreEqual(exp, ans);
    }
[Test]
    public static void atest0() 
    {        
        Console.WriteLine("Basic Tests");
        dotest(new int[] {}, new int[] {0});
        dotest(new int[] {0, 1, 3, 6, 10}, new int[] {20, 20, 19, 16, 10, 0});
        dotest(new int[] {1, 2, 3, 4, 5, 6}, new int[] {21, 20, 18, 15, 11, 6, 0});
        
        dotest(new int[] {744125, 935, 407, 454, 430, 90, 144, 6710213, 889, 810, 2579358}, 
                new int[] {10037855, 9293730, 9292795, 9292388, 9291934, 9291504, 9291414, 9291270, 2581057, 2580168, 2579358, 0});
            
        dotest(new int[] {30350, 76431, 156228, 78043, 98977, 80169, 32457, 182875, 162323, 17508, 57971, 171907}, 
                new int[] {1145239, 1114889, 1038458, 882230, 804187, 705210, 625041, 592584, 409709, 247386, 229878, 171907, 0});
        
        dotest(new int[] {158077, 143494, 196531, 26272, 35656, 68756, 109861, 36958, 83895, 134127, 81618, 193758, 143422}, 
                new int[] {1412425, 1254348, 1110854, 914323, 888051, 852395, 783639, 673778, 636820, 552925, 418798, 337180, 143422, 0});
        
        dotest(new int[] {3222, 77013, 124436, 117798, 28186, 183610, 121600, 20879, 44142, 23446, 154918, 54969, 94492}, 
                new int[] {1048711, 1045489, 968476, 844040, 726242, 698056, 514446, 392846, 371967, 327825, 304379, 149461, 94492, 0});
        
        dotest(new int[] {170110, 139570, 171544, 71770, 167818, 133006, 33628, 81872, 3143, 136857, 70720, 122107, 91191, 80135}, 
                new int[] {1473471, 1303361, 1163791, 992247, 920477, 752659, 619653, 586025, 504153, 501010, 364153, 293433, 171326, 80135, 0});
        
        dotest(new int[] {14231, 137542, 173347, 19792, 63830, 87040, 15621, 56268, 65441, 193264, 153828, 97321, 179116, 182144}, 
                new int[] {1438785, 1424554, 1287012, 1113665, 1093873, 1030043, 943003, 927382, 871114, 805673, 612409, 458581, 361260, 182144, 0});
        
        dotest(new int[] {198767, 63752, 180571, 115882, 199207, 3149, 151101, 91556, 39382, 117150}, 
                new int[] {1160517, 961750, 897998, 717427, 601545, 402338, 399189, 248088, 156532, 117150, 0});
        
        dotest(new int[] {19694, 183614, 199521, 155065, 6882, 125181, 130176, 105687, 47992, 81493}, 
                new int[] {1055305, 1035611, 851997, 652476, 497411, 490529, 365348, 235172, 129485, 81493, 0});
        
        dotest(new int[] {119450, 11268, 170483, 64155, 150893, 5826, 25660, 121156}, 
                new int[] {668891, 549441, 538173, 367690, 303535, 152642, 146816, 121156, 0});
        
        dotest(new int[] {129494, 8661, 83278, 157882, 71700, 176108, 140992, 46034, 43763, 33163, 11459, 30943, 27364, 44541, 166148}, 
                new int[] {1171530, 1042036, 1033375, 950097, 792215, 720515, 544407, 403415, 357381, 313618, 280455, 268996, 238053, 210689, 166148, 0});
        
        dotest(new int[] {7461, 88792, 18254, 13036, 187505, 49921, 48327, 169546, 163058, 187330, 160768, 165043, 35777, 140508, 147381}, 
                new int[] {1582707, 1575246, 1486454, 1468200, 1455164, 1267659, 1217738, 1169411, 999865, 836807, 649477, 488709, 323666, 287889, 147381, 0});
            
        int[] u = new int[] {654379,430,3358426,885,902,96,933,672,895,7310034,6749922,905,1319962,4238020,722,565,558,133,48,217,5450103,3383902,966,7294724,686,3700414,4961574,278149,245,598,381};
        int[] sol = new int[] {48710446,48056067,48055637,44697211,44696326,44695424,44695328,44694395,44693723,44692828,37382794,30632872,30631967,29312005,25073985,25073263,25072698,
                                        25072140,25072007,25071959,25071742,19621639,16237737,16236771,8942047,8941361,5240947,279373,1224,979,381,0};
        dotest(u, sol);
    }
    //-----------------------
    private static int[] PartsSumsFA(int[] ls)
        {
          int[] res = new int[ls.Length + 1];
          int t = ls.Sum();
          res[0] = t;
          for (int i = 1; i < res.Length; i++)
          {
              t -= ls[i - 1];
              res[i] = t;
          }
          return res;
        }
    //-----------------------
    private static Random rnd = new Random();
    private static int[] doEx1(int k)
    {
        int i = 0;
        int[] res = new int[k];
        while (i < k)
        {
            res[i] = rnd.Next(2, 25);
            i++;
        }
        return res;
    }
    private static void test1()
    {
        for (int i = 0; i < 20; i++)
        {
            int[] v = doEx1(rnd.Next(15, 30));
            int[] exp = PartsSumsFA(v);
            dotest(v, exp);
        }
    }
    
    private static void test2()
    {
        for (int i = 0; i < 5; i++)
        {
            int[] v = doEx1(rnd.Next(150000, 200000));
            int[] exp = PartsSumsFA(v);
            int[] ans = SumParts.PartsSums(v);
            Assert.AreEqual(exp, ans);
        }
    }
    
    private static void test3()
    {
        for (int i = 0; i < 4; i++)
        {
            int[] v = doEx1(rnd.Next(500000, 550000));
            int[] exp = PartsSumsFA(v);
            int[] ans = SumParts.PartsSums(v);
            Assert.AreEqual(exp, ans);
        }
    }
    
[Test] 
    public static void RandomTests0() 
    { 
        Console.WriteLine("Random Tests **** PartsSums short arrays");
        test1();
    } 
[Test] 
    public static void RandomTests1() 
    { 
        Console.WriteLine("Random Tests **** PartsSums bigger arrays");
        test2();
    } 
    [Test] 
    public static void RandomTests2() 
    { 
        Console.WriteLine("Random Tests **** PartsSums still bigger arrays");
        test3();
    } 

}
