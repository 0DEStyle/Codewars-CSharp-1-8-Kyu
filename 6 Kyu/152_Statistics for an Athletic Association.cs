/*Challenge link:https://www.codewars.com/kata/55b3425df71c1201a800009c/train/csharp
Question:
You are the "computer expert" of a local Athletic Association (C.A.A.). Many teams of runners come to compete. Each time you get a string of all race results of every team who has run. For example here is a string showing the individual results of a team of 5 runners:

"01|15|59, 1|47|6, 01|17|20, 1|32|34, 2|3|17"

Each part of the string is of the form: h|m|s where h, m, s (h for hour, m for minutes, s for seconds) are positive or null integer (represented as strings) with one or two digits. Substrings in the input string are separated by ,  or ,.

To compare the results of the teams you are asked for giving three statistics; range, average and median.

Range : difference between the lowest and highest values. In {4, 6, 9, 3, 7} the lowest value is 3, and the highest is 9, so the range is 9 − 3 = 6.

Mean or Average : To calculate mean, add together all of the numbers and then divide the sum by the total count of numbers.

Median : In statistics, the median is the number separating the higher half of a data sample from the lower half. The median of a finite list of numbers can be found by arranging all the observations from lowest value to highest value and picking the middle one (e.g., the median of {3, 3, 5, 9, 11} is 5) when there is an odd number of observations. If there is an even number of observations, then there is no single middle value; the median is then defined to be the mean of the two middle values (the median of {3, 5, 6, 9} is (5 + 6) / 2 = 5.5).

Your task is to return a string giving these 3 values. For the example given above, the string result will be

"Range: 00|47|18 Average: 01|35|15 Median: 01|32|34"

of the form: "Range: hh|mm|ss Average: hh|mm|ss Median: hh|mm|ss"`

where hh, mm, ss are integers (represented by strings) with each 2 digits.

Remarks:
if a result in seconds is ab.xy... it will be given truncated as ab.
if the given string is "" you will return ""
*/

//***************Solution********************
/*                             `-:/+++++++/++:-.                                          
                            .odNMMMMMMMMMMMMMNmdo-`                                      
                           +mMMNmdhhhhhhhhhdmNMMMNd/`                                    
                          sMMMmhyyyyyyyyyyyyyyhmNMMMh-                                   
                         +MMMdyyyyyyyhhhhdddddddmMMMMN/                                  
                        `NMMmyyyyyymNNMMNNNmmmmmmmNNMMMy`                                
                        :MMMhyyyyyNMMMho+//:-.....-:omMMd-                               
                    ```:mMMNhyyyyhMMMh+::::-        `:sNMN:                              
                 -oyhdmMMMMmhyyyyhMMNyy+::::---------::yMMm                              
                +MMMMNNNMMMdhyyyyhMMNyyyso/::::::://+oshMMM`                             
                NMMNhyyyMMMhhyyyyyNMMmyyyyyyssssyyyyyyymMMd                              
                MMMdyyyhMMNhhyyyyyhNMMNdyyyyyyyyyyyhdmMMMN-                              
                MMMdhhhdMMNhhhyyyyyymMMMMNmmmmmmNNMMMMMMN.                               
                MMMhhhhdMMNhhhyyyyyyyhdmNNNMMNNNmmdhhdMMd                                
               `MMMhhhhdMMNhhhhyyyyyyyyyyyyyyyyyyyyyydMMM.                               
               .MMMhhhhdMMNhhhhyyyyyyyyyyyyyyyyyyyyyydMMM:                               
               .MMNhhhhdMMNhhhhhyyyyyyyyyyyyyyyyyyyyhhMMM+                               
               -MMNhhhhdMMNhhhhhyyyyyyyyyyyyyyyyyyyyhdMMM/                               
               -MMMhhhhdMMNhhhhhhhyyyyyyyyyyyyyyyyyhhdMMM-                               
               `MMMhhhhhMMNhhhhhhhhhhyyyyyyyyyyyhhhhhmMMN                                
                hMMmhhhhMMNhhhhhhhhhhhhhhhhhhhhhhhhhhNMMy                                
                :MMMNmddMMMhhhhhhhhhhddddhhhhhhhhhhhdMMM/                                
                 :hNMMMMMMMdhhhhhhhhdMMMMMMNNNNNdhhhNMMN`                                
                   .-/+oMMMmhhhhhhhhmMMmyhMMMddhhhhdMMMy                                 
                        hMMNhhhhhhhhmMMd :MMMhhhhhhdMMM+                                 
                        sMMNhhhhhhhhNMMm .MMMdhhhhhdMMN.                                 
                        /MMMdhhhhhhdMMM+  oNMMNNNNNMMm:                                  
                        `dMMMNmmmNNMMMh`   -syyyyhhy/`                                   
                         `/hmNNNNNmdh/`                                                  
                            `.---..`
*/
//time ref: https://learn.microsoft.com/en-us/dotnet/api/system.timespan.parse?view=net-8.0
using System;
using System.Linq;

public class Stat{		
        public static string stat(string str){
          //if str is nothing, return nothing
          if(str == "") return "";
          //replace '|' to ':' for time format, split by ','
          //Parse into TimeSpan format, order by ascending and store in array.
          var arr = str.Replace('|', ':')
                         .Split(',')
                         .Select(TimeSpan.Parse)
                         .OrderBy(x => x).ToArray();
          
          //highest subtract lowest
          var range = arr.Max() - arr.Min();
          //convert to seconds and get average
          var average = TimeSpan.FromSeconds(arr.Average(x => x.TotalSeconds));
          
          //find median, if length is even, return (arr[mid] + arr[mid - 1]) / 2, else return arr[mid]
          var mid = arr.Length / 2;
          var median = arr.Length % 2 == 0 ? (arr[mid] + arr[mid - 1]) / 2 : arr[mid];
          
          //string interpolation to format the string
          return $"Range: {range:hh\\|mm\\|ss} Average: {average:hh\\|mm\\|ss} Median: {median:hh\\|mm\\|ss}";
        }		
    }

//****************Sample Test*****************
using System;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class StatTests {
    
    //-----------------------
    private static int time2snd13411(string s)
        {
            int[] arr = s.Split('|').Select(x => int.Parse(x)).ToArray();
            return 3600 * arr[0] + 60 * arr[1] + arr[2];
        }
        private static string snd2time13411(int n)
        {
            int h = n / 3600;
            int re = n % 3600;
            int mn = re / 60;
            int s = re % 60;
            return string.Format("{0:00}|{1:00}|{2:00}", h, mn, s);
        }
        public static string stat13411(string strg)
        {
            if (strg == "") return "";
            int[] r = strg.Split(',').Select(x => time2snd13411(x)).ToArray();
            Array.Sort(r);
            int lg = r.Length;
            int avg = (int)(r.Sum() / lg);
            int rge = r[lg - 1] - r[0];
            int md = (int)((r[(int)((lg - 1) / 2)] + r[(int)(lg / 2)]) / 2.0);
            return string.Format("Range: {0} Average: {1} Median: {2}", snd2time13411(rge), snd2time13411(avg), snd2time13411(md));
        }
		  public static string comb13411(Random rnd) 
		  {
			  string a = "01|15|59, 1|47|16, 01|17|20, 1|32|34, 2|17|17";
			  string b = "02|15|59, 2|47|16, 02|17|20, 2|32|34, 2|17|17, 2|22|00, 2|31|41";
			  string c = "02|15|59, 2|47|16, 02|17|20, 2|32|34, 2|32|34, 2|17|17";
			  string d = "00|15|59, 00|16|16, 00|17|20, 00|22|34, 00|19|34, 00|15|17";
			  string e = "11|15|59, 10|16|16, 12|17|20, 9|22|34, 13|19|34, 11|15|17, 11|22|00, 10|26|37, 12|17|48, 9|16|30, 12|20|14, 11|25|11";
			  string f = "1|15|59, 1|16|16, 1|17|20, 1|22|34, 1|19|34, 1|15|17, 1|22|00, 1|26|37, 1|17|48, 1|16|30, 1|20|14, 1|25|11";
			  string k = a + ", " + b + ", " + c + ", " + d + ", " + e + ", " + f;
			  string[] v = k.Split(',');
			  int l = v.Length;
			  string res = "";
			  int n = rnd.Next(0, 20);
			  //Console.WriteLine(n);
			  for (int i = 0; i < n; i++) {
				  int rr = rnd.Next(0, l); 
				  res += v[rr];
				  if (i < n - 1) res += ", ";
			  }
			  return res;
		  }
    
    //-----------------------

[Test]
    public static void BasicTest() {		
        Assert.AreEqual("Range: 01|01|18 Average: 01|38|05 Median: 01|32|34", 
				Stat.stat("01|15|59, 1|47|16, 01|17|20, 1|32|34, 2|17|17"));
		    Assert.AreEqual("Range: 00|31|17 Average: 02|26|18 Median: 02|22|00", 
				Stat.stat("02|15|59, 2|47|16, 02|17|20, 2|32|34, 2|17|17, 2|22|00, 2|31|41"));
		    Assert.AreEqual("Range: 00|31|17 Average: 02|27|10 Median: 02|24|57", 
				Stat.stat("02|15|59, 2|47|16, 02|17|20, 2|32|34, 2|32|34, 2|17|17"));
		    Assert.AreEqual("Range: 00|07|34 Average: 00|17|47 Median: 00|16|48", 
				Stat.stat("0|15|59, 0|16|16, 0|17|20, 0|22|34, 0|19|34, 0|15|0"));		
		    Assert.AreEqual("Range: 04|03|04 Average: 11|14|36 Median: 11|18|59", 
				Stat.stat("11|15|59, 10|16|16, 12|17|20, 9|22|34, 13|19|34, 11|15|17, 11|22|00, 10|26|37, 12|17|48, 9|16|30, 12|20|14, 11|25|11"));
		    Assert.AreEqual("Range: 00|11|20 Average: 01|19|36 Median: 01|18|41", 
				Stat.stat("1|15|59, 1|16|16, 1|17|20, 1|22|34, 1|19|34, 1|15|17, 1|22|00, 1|26|37, 1|17|48, 1|16|30, 1|20|14, 1|25|11"));
        Assert.AreEqual("", 
				Stat.stat(""));
    }
    [Test]
    public static void RandomTest() {
        Random random = new Random();
        for (int i = 0; i < 50; i++) {
            string lst = comb13411(random);
            Console.WriteLine("stat test number: " + i);
            Assert.AreEqual(StatTests.stat13411(lst), Stat.stat(lst));
        }
    }
}
