/*Challenge link:https://www.codewars.com/kata/589577f0d1b93ae32a000001/train/csharp
Question:
Task
Some people are standing in a row in a park. There are trees between them which cannot be moved.

Your task is to rearrange the people by their heights in a non-descending order without moving the trees.

Example
For a = [-1, 150, 190, 170, -1, -1, 160, 180], the output should be

[-1, 150, 160, 170, -1, -1, 180, 190].

Input/Output
[input] integer array a

If a[i] = -1, then the ith position is occupied by a tree. Otherwise a[i] is the height of a person standing in the ith position.

Constraints:

5 ≤ a.length ≤ 30,

-1 ≤ a[i] ≤ 200.

[output] an integer array

Sorted array a with all the trees untouched.
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
//-1 is tree, the rest are people

using System.Linq;

namespace myjinxin{
    public class Kata{
        public int[] SortByHeight(int[] a){
          
          //take the human out from the queue
          var human = a.Where(x => x != -1).OrderBy(x => x).ToList();
          
          //loop through each element
          //if element is not a tree(-1)
          //insert a[i] into index i of human
          for(int i = 0; i < a.Length; i++)
            if(a[i] < 0)
              human.Insert(i , a[i]);
              
          //convert to array and return the result.
          return human.ToArray();
        }
    }
}

//solution 2
using System.Linq;
using System.Collections.Generic;

public class Kata
{
  public int[] SortByHeight(int[] a)
  {
    var row = new Queue<int>(a.Where(i => i != -1).OrderBy(i => i));
    return a.Select(i => i == -1 ? -1 : row.Dequeue()).ToArray();
  }
}

//solution 3
namespace myjinxin
{
    using System.Linq;
    using System.Collections.Generic;
    
    public class Kata
    {
        public int[] SortByHeight(int[] a){

            var sortedHeightStack = new Stack<int>(a.Where(i=> i>-1).OrderByDescending(i=>i));         
            for(int i=0;i<a.Length;i++)
                if(a[i] != -1) a[i]=sortedHeightStack.Pop(); 
            
            return a;
        }
    }
}

//****************Sample Test*****************
namespace myjinxin
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    //using System.Text;
    using System.Linq;
    using System.Text.RegularExpressions;
    [TestFixture]
    public class CsharpTest
    {
public int[] An(int[] a){
  var b=a.Where(x=>x>-1).OrderBy(y=>y).ToArray();
  var k=0;
  var r=a.Select(x=>x).ToArray();
  for(var i=0;i<r.Length;i++) if(r[i]>-1) r[i]=b[k++];
  return r;
} 
public int[] rndtest(){
  var r=new List<int>();
  int len=rand(5,30),sum=0;
  for(int i=0;i<len;i++) r.Add(rand(80,200));
  var tree=rand(0,5);
  while(tree-->0){
    var idx=rand(0,r.Count-1);
    while(r[idx]==-1) idx=rand(0,r.Count-1);
    r[idx]=-1;
  }
  return r.ToArray();
}
public string rndsx(int n){
  int len= n;
  var c=rand(0,2)>0?"abc":"abcdefg";
  var rs=new List<char>();
  for (int i=0;i<len;i++) rs.Add(c[rand(0,c.Length-1)]);
  return string.Join("",rs);
}
public void shuff(List<int> r){
  for(int i=0;i<50;i++){
    int idx1=rand(0,r.Count-1),idx2=rand(0,r.Count-1);
    var tt=r[idx1];
    r[idx1]=r[idx2];
    r[idx2]=tt;
  }
}

        public int[] rndtest1(){
          var r=new List<int>();
          int len=rand(500,3000);
          for(var i=0;i<len;i++) r.Add(rand(1,1000));
          return r.ToArray();
        }
        Random rndnum=new Random(unchecked((int)DateTime.Now.Ticks));
        public int rand(int a,int b){
          return a>b?rand(b,a):rndnum.Next(a,b+1);
        }
        public string rnds(){
          var len= rand(1,100);
          var rs=new List<char>();
          for (int i=0;i<len;i++) rs.Add(rndcl());
          return string.Join("",rs);
        }
        public string rndss(){
          var len= rand(3,7);
          var rs=new List<string>();
          for (int i=0;i<len;i++) rs.Add(rnds());
          return string.Join(" ",rs);
        }
        public string rnds2(int n){
          var len= n;
          var rs=new List<char>();
          for (int i=0;i<len;i++) rs.Add(rndch());
          return string.Join("",rs);
        }
        public char rndcl(){
          var allc="abcdefghijklmnopqrstuvwxyz";
          return allc[rand(0,allc.Length-1)];
        }
        public char rndchl(){
          var allc="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
          return allc[rand(0,allc.Length-1)];
        }
        public char rndch(){
          var allc="ABCDEFGHIJKLMNOPQRSTUVWXYZ";
          return allc[rand(0,allc.Length-1)];
        }
        [Test]
        public void Test1__Basic_Tests(){
            var kata=new Kata();
            var passed="<font size=2 color='#8FBC8F'>Test Passed!</font>\n";
            
            Assert.AreEqual(new int[]{-1, 150, 160, 170, -1, -1, 180, 190},kata.SortByHeight(new int[]{-1, 150, 190, 170, -1, -1, 160, 180}));
            Console.WriteLine(passed);
            Assert.AreEqual(new int[]{-1, -1, -1, -1, -1},kata.SortByHeight(new int[]{-1, -1, -1, -1, -1}));
            Console.WriteLine(passed);
            Assert.AreEqual(new int[]{2, 2, 4, 9, 11, 16},kata.SortByHeight(new int[]{4, 2, 9, 11, 2, 16}));
            Console.WriteLine(passed);
            Console.WriteLine(" ");
            
        }
        
        [Test]
        public void Test2__100_Random_Tests(){
          var kata=new Kata();
          var passed="<font size=2 color='#8FBC8F'><b>Test Passed!</b></font>";
            
          for (int i=0;i<100;i++){
              var ab=rndtest();
              Console.WriteLine("<font size=2 color='#CFB53B'>Testing for: "+
              "\na = new int[]{"+string.Join(", ",ab)+"}"
              //+"\ncell2 = \""+ab[1]+"\""
              //+", numberOfDigits = "+ab[1]
              //+", loved = "+ab[2]
              //+", s = "+ab[3]
              +"</font>");
              var answer=An(ab);
              Assert.AreEqual(answer, kata.SortByHeight(ab));
              Console.WriteLine("<font size=2 color='#8FBC8F'>"+
              "Pass Value = new int[]{"+string.Join(", ",answer)+"}"+"</font>\n");
              Console.WriteLine(" ");
            }
          
          Console.WriteLine("<div style='width:360px;background-color:gray'><br><font size=2 color='#3300dd'><b>Happy Coding ^_^</b></font>");
          Console.WriteLine("<br><font size=2 color='#5500ee'><b>Thanks for solve this kata,\nI'm waiting for your:<font color='993300'>\nfeedback, voting and ranking ;-)</b></font></div>");
          
        }
    }
}	
