/*Challenge link:https://www.codewars.com/kata/59f4a0acbee84576800000af/train/csharp
Question:
Suppose you have 4 numbers: 0, 9, 6, 4 and 3 strings composed with them:

s1 = "6900690040"
s2 = "4690606946"
s3 = "9990494604"
Compare s1 and s2 to see how many positions they have in common: 0 at index 3, 6 at index 4, 4 at index 8 : 3 common positions out of ten.

Compare s1 and s3 to see how many positions they have in common: 9 at index 1, 0 at index 3, 9 at index 5 : 3 common positions out of ten.

Compare s2 and s3. We find 2 common positions out of ten.

So for the 3 strings we have 8 common positions out of 30 ie 0.2666... or 26.666...%

Given n substrings (n >= 2) in a string s our function pos_average will calculate the average percentage of positions that are the same between the (n * (n-1)) / 2 sets of substrings taken amongst the given n substrings. It can happen that some substrings are duplicate but since their ranks are not the same in s they are considered as different substrings.

The function returns the percentage formatted as a float with 10 decimals but the result is tested at 1e.-9 (see function assertFuzzy in the tests).

Example:
Given string s = "444996, 699990, 666690, 096904, 600644, 640646, 606469, 409694, 666094, 606490" composing a set of n = 10 substrings (hence 45 combinations), pos_average returns 29.2592592593.

In a set the n substrings will have the same length ( > 0 ).

Notes
You can see other examples in the "Sample tests".
*/

//***************Solution********************
using System.Linq;

public class PositionAverage{
	public static double PosAverage(string s){
    //split string by ", " store in array str
    var str = s.Split(", ");
    
    //a,b are current elements, i,j,k are index
    //from str select many, skip index + 1 each iteration
    //then from current element a, selectmany, 
    //zip current number b if index j and k are the same.
    var common = str.SelectMany((a,i) => str.Skip(i + 1)
                    .SelectMany(b => a.Zip(b, (j,k) => j == k)));
                                                                    
    //common.count * 100.0 to get decimal, and find the percentage out of total.                                             
		return (100.0 * common.Count(x => x)) / common.Count();
	}
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public static class PositionAverageTests {

    private static Random rnd = new Random();
	
	private static void assertFuzzy(string s, double exp)
	{
		Console.WriteLine("Testing " + s);
		bool inrange;
		double merr = 1e-9;
		double actual = PositionAverage.PosAverage(s);
		inrange = Math.Abs(actual - exp) <= merr;
		if (inrange == false)
		{
			Console.WriteLine("Expected mean must be near " + exp + ", got " + actual);
		}
		Assert.AreEqual(true, inrange);    
	}

[Test]
    public static void test1() {
        Console.WriteLine("Fixed Tests");
        assertFuzzy("466960, 069060, 494940, 060069, 060090, 640009, 496464, 606900, 004000, 944096", 26.6666666667);
        assertFuzzy("444996, 699990, 666690, 096904, 600644, 640646, 606469, 409694, 666094, 606490", 29.2592592593);
        assertFuzzy("449404, 099090, 600999, 694460, 996066, 906406, 644994, 699094, 064990, 696046", 24.4444444444);
        assertFuzzy("660999, 969060, 044604, 009494, 609009, 640090, 994446, 949940, 046999, 609444", 22.9629629630);
        assertFuzzy("996060, 606494, 964494, 460409, 609449, 969600, 960944, 960006, 666049, 090996", 24.8148148148);

        assertFuzzy("40664064, 60460960, 00669664, 94040464, 04006499, 00466666, 90966460, 64494990", 29.0178571429);
        assertFuzzy("64040600, 64464440, 60006040, 49609906, 46664409, 99464446, 90446964, 96940090", 20.5357142857);
        assertFuzzy("99494909, 60004094, 60090496, 64664669, 49909604, 49999064, 46009964, 44494444", 25.4464285714);
        assertFuzzy("46904946, 60996660, 64040460, 40449469, 46440460, 96090699, 06600440, 44046966", 27.6785714286);
        assertFuzzy("46099969, 64096999, 44949949, 06409969, 09064604, 90490494, 04600696, 94469969", 25.8928571429);
        assertFuzzy("4444444, 4444444, 4444444, 4444444, 4444444, 4444444, 4444444, 4444444", 100);
        assertFuzzy("0, 0, 0, 0, 0, 0, 0, 0", 100);
        assertFuzzy("0, 0, 1", 33.3333333333);
    }

  //-----------------------
	private static double pairPercentage(string s1, string s2)
	{
		int lg = s1.Length;
		int count = 0;
		for (int pos = 0; pos < lg; pos++)
		{
			if (s1[pos] == s2[pos])
			{
				count += 1;
			}
		}
		return (double)count / lg;
	}
	private static double PosAverageKP(string s)
	{
		string[] strings = s.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
		double result = 0.0;
		int cnt = 0;
		int lg = strings.Length;
		for (int k = 0; k < lg; k++)
		{
			for (int i = k + 1; i < lg; i++)
			{
				result += pairPercentage(strings[k], strings[i]);
				cnt += 1;
			}
		}
		result = 100.0 * result / cnt;
		return Math.Floor(result * Math.Pow(10.0, 10)) / Math.Pow(10.0, 10);
	}
	
  private static string doOne1(int k)
	{
		string[] t = new string[] {"9", "6", "4"};
		int i = 0;
		string res = "";
        int n = rnd.Next(0, 2);
		while (i < k)
		{			
			res += t[n];
			i += 1;
		}
		return res;
	}
	private static string doOne(int k)
	{
		string[] t = new string[] {"0", "9", "6", "4"};
		int i = 0;
		string res = "";
		while (i < k)
		{
			int n = rnd.Next(0, 3);
			res += t[n];
			i += 1;
		}
		return res;
	}
	private static string doEx(int lgset, int one)
	{
		int i = 0;
		string res = "";
        int n = rnd.Next(0, 100);
        if (n % 5 == 0) {
            String ss = doOne1(one);
            while (i < lgset) {
                res += ss + ", ";
                i += 1;
            }
        } else {
            while (i < lgset) {
                String r = doOne(one);
                res += r + ", ";
                i += 1;
            }
        }
		return res.Substring(0, res.Length - 2);
	}
  //-----------------------
[Test]    
	public static void test2()
	{
		Console.WriteLine("Random Tests ****");
		for (int i = 0; i < 200; i++)
		{
			int m = rnd.Next(15, 25);
			int k = rnd.Next(10, 20);
			string s = doEx(m, k);
			double sol = PosAverageKP(s);
			assertFuzzy(s, sol);
		}
	}
}
