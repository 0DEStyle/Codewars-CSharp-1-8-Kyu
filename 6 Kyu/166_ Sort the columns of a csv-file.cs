/*Challenge link:https://www.codewars.com/kata/57f7f71a7b992e699400013f/train/csharp
Question:
#Sort the columns of a csv-file

You get a string with the content of a csv-file. The columns are separated by semicolons.
The first line contains the names of the columns.
Write a method that sorts the columns by the names of the columns alphabetically and incasesensitive.

An example:

Before sorting:
As table (only visualization):
|myjinxin2015|raulbc777|smile67|Dentzil|SteffenVogel_79|
|17945       |10091    |10088  |3907   |10132          |
|2           |12       |13     |48     |11             |

The csv-file:
myjinxin2015;raulbc777;smile67;Dentzil;SteffenVogel_79\n
17945;10091;10088;3907;10132\n
2;12;13;48;11

----------------------------------

After sorting:
As table (only visualization):
|Dentzil|myjinxin2015|raulbc777|smile67|SteffenVogel_79|
|3907   |17945       |10091    |10088  |10132          |
|48     |2           |12       |13     |11             |

The csv-file:
Dentzil;myjinxin2015;raulbc777;smile67;SteffenVogel_79\n
3907;17945;10091;10088;10132\n
48;2;12;13;11
There is no need for prechecks. You will always get a correct string with more than 1 line und more than 1 row. All columns will have different names.

Have fun coding it and please don't forget to vote and rank this kata! :-)

I have created other katas. Have a look if you like coding and challenges.
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
/*
string format:
string preSorting = "myjinxin2015;raulbc777;smile67;Dentzil;SteffenVogel_79\n"   //row[0]
                      + "17945;10091;10088;3907;10132\n"                         //row[1]
                      + "2;12;13;48;11";                                         //row[2]
                      
*/
using System.Linq;
using System;
public class Kata{
  public static string SortCsvColumns(string csvFileContent){
    //split by new line and ";", store in array;
    var row = csvFileContent.Split("\n")
                            .Select(x => x.Split(";"))
                            .ToArray();
    
    //checking stuff
    //foreach(var stuff in row) Console.WriteLine(string.Join(",",stuff));
    
    
    //to get the order after sorts the columns by the names of the columns alphabetically
    //in the first case 0,1,2,3,4 => 3,0,1,2,4 after sort
    
    //x is current element, i is index
    //from row[0], set value as x, Index as i
    //order the row's value in ascending order, then select the x's Index and store it into array.
    var items = row[0].Select((x, i) => new {Value = x, Index = i})
                     .OrderBy(x => x.Value)
                     .Select(x => x.Index)
                     .ToArray();
    
    //Order the elements(actual row) in row by using the order index we accquired from items.
    //Format the string and return the result.
    return string.Join("\n", row.Select(x => 
           string.Join(";", items.Select(i => x[i]))));
  }
}

//solution 2
using System.Linq;
using System;

public class Kata
{
  public static string SortCsvColumns(string csvFileContent)
  {
  
    var d = csvFileContent
        .Split('\n')
        .Take(1)
        .SelectMany(row => row.Split(';'))
        .Select((word, index) => Tuple.Create(word, index))
        .OrderBy(t => t.Item1)
        .Select((t,index) => Tuple.Create(t.Item1, t.Item2, index))
        .ToDictionary(t => t.Item3, t=>t.Item2);
        
    return 
    string.Join("\n",
      csvFileContent
        .Split('\n')
        .Select(row => row.Split(';'))
        .Select(row => string.Join(";", row.Select((word,index) => row[d[index]]).ToArray()))
      );
  }
  

}
//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

public class KataTests
{
  [Test]
  public void BasicTests()
  {
    string preSorting = "myjinxin2015;raulbc777;smile67;Dentzil;SteffenVogel_79\n"
                      + "17945;10091;10088;3907;10132\n"
                      + "2;12;13;48;11";
    string postSorting = "Dentzil;myjinxin2015;raulbc777;smile67;SteffenVogel_79\n"
                       + "3907;17945;10091;10088;10132\n"
                       + "48;2;12;13;11";
    Assert.AreEqual(postSorting, Kata.SortCsvColumns(preSorting));
    
    preSorting = "IronMan;Thor;Captain America;Hulk\n"
               + "arrogant;divine;honorably;angry\n"
               + "armor;hammer;shield;greenhorn\n"
               + "Tony;Thor;Steven;Bruce";
    postSorting = "Captain America;Hulk;IronMan;Thor\n"
                + "honorably;angry;arrogant;divine\n"
                + "shield;greenhorn;armor;hammer\n"
                + "Steven;Bruce;Tony;Thor";
    Assert.AreEqual(postSorting, Kata.SortCsvColumns(preSorting));
  }
  
  [Test]
  public void RandomTests()
  {
    var rand = new Random();
    
    Func<string,string> mySortCsvColumns = delegate (string csvFileContent)
    {
      var lines = csvFileContent.Split('\n').Select(a => a.Split(';')).ToArray();
      for(int i=0;i<lines[0].Length;i++)
      {
        for(int j=0;j<lines[0].Length-1;j++)
        {
          if(lines[0][j].CompareTo(lines[0][j+1]) > 0)
          {
            for(int k=0;k<lines.Length;k++)
            {
              var temp = lines[k][j];
              lines[k][j] = lines[k][j+1];
              lines[k][j+1] = temp;
            }
          }
        }
      }
    
      return string.Join("\n", lines.Select(a => string.Join(";", a)));
    };
    
    for(int r=0;r<30;r++)
    {
      var lineCount = rand.Next(2,20);
      var columnCount = rand.Next(2,10);
      var lines = new List<string>();
      for(int l=0;l<lineCount;l++)
      {
        var words = new List<string>();
        for(int w=0;w<columnCount;w++)
        {
          var letterCount = rand.Next(2,7);
          string word = "";
          for(int le=0;le<letterCount;le++)
          {
            word += (char)(rand.Next(0,5) == 0 ? rand.Next(65,91) : rand.Next(97, 123));
          }
          words.Add(word);
        }
        lines.Add(string.Join(";", words));
      }
      var preSorting = string.Join("\n", lines);
      
      Assert.AreEqual(mySortCsvColumns(preSorting), Kata.SortCsvColumns(preSorting));
    }
  }
}
