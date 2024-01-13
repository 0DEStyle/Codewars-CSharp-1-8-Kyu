/*Challenge link:https://www.codewars.com/kata/5701800886306a876a001031/train/csharp
Question:
Suzuki needs help lining up his students!

Today Suzuki will be interviewing his students to ensure they are progressing in their training. He decided to schedule the interviews based on the length of the students name in descending order. The students will line up and wait for their turn.

You will be given a string of student names. Sort them and return a list of names in descending order.

Here is an example input:

string = 'Tadashi Takahiro Takao Takashi Takayuki Takehiko Takeo Takeshi Takeshi'
Here is an example return from your function:

 lst = ['Takehiko',
        'Takayuki',
        'Takahiro',
        'Takeshi',
        'Takeshi',
        'Takashi',
        'Tadashi',
        'Takeo',
        'Takao']
Names of equal length will be returned in reverse alphabetical order (Z->A) such that:

string = "xxa xxb xxc xxd xa xb xc xd"
Returns

['xxd', 'xxc', 'xxb', 'xxa', 'xd', 'xc', 'xb', 'xa']
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
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
//length of student name in descending order
//split string a by space, order by length in descending order (-x mean inverse)
//then order by descending again, store in array and return the result.
using System.Linq;
public class Kata{
  public static string[] LineupStudents(string a) => 
    a.Split().OrderBy(x => -x.Length).ThenByDescending(x => x).ToArray();
}

//****************Sample Test*****************
using System;
using System.Linq;
namespace Solution 
{
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class KataTests
  {
    [Test]
    public void BasicTest1()
    {      
      String students = "Tadashi Takahiro Takao Takashi Takayuki Takehiko Takeo Takeshi Takeshi";
      String[] expected = {"Takehiko","Takayuki", "Takahiro","Takeshi","Takeshi","Takashi","Tadashi","Takeo","Takao"};
      Assert.AreEqual(expected, Kata.LineupStudents(students));
    }
    [Test]
    public void BasicTest2()
    {      
      String students = "Michio Miki Mikio Minori Minoru Mitsuo Mitsuru Nao Naoki Naoko Noboru Nobu Nobuo Nobuyuki Nori Norio Osamu Rafu Raiden Ringo Rokuro Ronin Ryo Ryoichi Ryota Ryozo Ryuichi Ryuu Saburo Sadao Samuru Satoru Satoshi Seiichi Seiji Senichi Shichiro Shig Shigekazu Shigeo Shigeru Shima Shin Shinichi Shinji Shiro Shoichi Shoji Shuichi Shuji Shunichi Susumu Tadao Tadashi Takahiro Takao Takashi Takayuki Takehiko Takeo Takeshi Takeshi Takumi Tama Tamotsu Taro Tatsuo Tatsuya Teruo Tetsip Tetsuya Tomi Tomio Toru Toshi Toshiaki Toshihiro Toshio Toshiyuki Toyo Tsuneo Tsutomu Tsuyoshi Uyeda Yasahiro Yasuhiro Yasuo Yasushi Yemon Yogi Yoichi Yori Yoshi Yoshiaki Yoshihiro Yoshikazu Yoshimitsu Yoshinori Yoshio Yoshiro Yoshito Yoshiyuki Yuichi Yuji Yuki";
      String[] expected = {"Yoshimitsu", "Yoshiyuki", "Yoshinori", "Yoshikazu", "Yoshihiro", "Toshiyuki",
         "Toshihiro", "Shigekazu", "Yoshiaki", "Yasuhiro", "Yasahiro", "Tsuyoshi","Toshiaki",
         "Takehiko", "Takayuki", "Takahiro", "Shunichi", "Shinichi","Shichiro", 
         "Nobuyuki", "Yoshito", "Yoshiro", "Yasushi", "Tsutomu","Tetsuya", "Tatsuya",
         "Tamotsu", "Takeshi", "Takeshi", "Takashi","Tadashi", "Shuichi", "Shoichi",
         "Shigeru", "Senichi", "Seiichi","Satoshi", "Ryuichi", "Ryoichi", "Mitsuru",
         "Yuichi", "Yoshio","Yoichi", "Tsuneo", "Toshio", "Tetsip", "Tatsuo", "Takumi",
        "Susumu", "Shinji", "Shigeo", "Satoru", "Samuru", "Saburo","Rokuro", "Raiden", 
        "Noboru", "Mitsuo", "Minoru", "Minori", "Michio", "Yoshi", "Yemon", "Yasuo", 
        "Uyeda", "Toshi", "Tomio","Teruo", "Takeo", "Takao", "Tadao", "Shuji", "Shoji",
        "Shiro", "Shima", "Seiji", "Sadao", "Ryozo", "Ryota", "Ronin", "Ringo", "Osamu", 
        "Norio", "Nobuo", "Naoko", "Naoki", "Mikio", "Yuki", "Yuji", "Yori", "Yogi",
        "Toyo", "Toru", "Tomi", "Taro", "Tama", "Shin", "Shig", "Ryuu", "Rafu", "Nori", 
        "Nobu", "Miki", "Ryo", "Nao"};
      Assert.AreEqual(expected, Kata.LineupStudents(students));
    }
    public static String[] LineupStudentsTest(String students)
    {
      return students.Split(' ').OrderByDescending( x => x.Length ).ThenByDescending( x => x ).ToArray();
    }
    public static String CreateStudents(int n)
    {
        var rand = new Random();
        String[] students = {"Michio","Miki","Mikio","Minori","Minoru","Mitsuo",
        "Mitsuru","Nao","Naoki","Naoko","Noboru","Nobu","Nobuo","Nobuyuki","Nori",
        "Norio","Osamu","Rafu","Raiden","Ringo","Rokuro","Ronin","Ryo","Ryoichi",
        "Ryota","Ryozo","Ryuichi","Ryuu","Saburo","Sadao","Samuru","Satoru",
        "Satoshi","Seiichi","Seiji","Senichi","Shichiro","Shig","Shigekazu",
        "Shigeo","Shigeru","Shima","Shin","Shinichi","Shinji","Shiro","Shoichi",
        "Shoji","Shuichi","Shuji","Shunichi","Susumu","Tadao","Tadashi","Takahiro",
        "Takao","Takashi","Takayuki","Takehiko","Takeo","Takeshi","Takeshi","Takumi",
        "Tama","Tamotsu","Taro","Tatsuo","Tatsuya","Teruo","Tetsip","Tetsuya","Tomi",
        "Tomio","Toru","Toshi","Toshiaki","Toshihiro","Toshio","Toshiyuki",
        "Toyo","Tsuneo","Tsutomu","Tsuyoshi","Uyeda","Yasahiro","Yasuhiro",
        "Yasuo","Yasushi","Yemon","Yogi","Yoichi","Yori","Yoshi",
        "Yoshiaki","Yoshihiro","Yoshikazu","Yoshimitsu","Yoshinori","Yoshio",
        "Yoshiro","Yoshito","Yoshiyuki","Yuichi","Yuji","Yuki" };
        String[] a = new String[n];
        for(int i = 0; i < n; i++) {
            int k = rand.Next(0,105);
            a[i]=students[k];
        }
        String res = String.Join(" ", a);
        return res;
    }
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      for (var i = 0; i < 40; i++) {
         var n = rand.Next(0,105);
         var students = CreateStudents(n);
         var expected = LineupStudentsTest(students);
         Console.WriteLine("testing Array: {0}", string.Join(", ", students));
         Console.WriteLine("Result: {0}", string.Join(", ", Kata.LineupStudents(students)));
         Assert.AreEqual(expected, Kata.LineupStudents(students));
      }     
    }
  }
} 
