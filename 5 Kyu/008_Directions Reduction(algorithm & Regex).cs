/*Challenge link:https://www.codewars.com/kata/550f22f4d758534c1100025a/train/csharp
Question:
Once upon a time, on a way through the old wild mountainous west,…
… a man was given directions to go from one point to another. The directions were "NORTH", "SOUTH", "WEST", "EAST". Clearly "NORTH" and "SOUTH" are opposite, "WEST" and "EAST" too.

Going to one direction and coming back the opposite direction right away is a needless effort. Since this is the wild west, with dreadful weather and not much water, it's important to save yourself some energy, otherwise you might die of thirst!

How I crossed a mountainous desert the smart way.
The directions given to the man are, for example, the following (depending on the language):

["NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "WEST"].
or
{ "NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "WEST" };
or
[North, South, South, East, West, North, West]
You can immediately see that going "NORTH" and immediately "SOUTH" is not reasonable, better stay to the same place! So the task is to give to the man a simplified version of the plan. A better plan in this case is simply:

["WEST"]
or
{ "WEST" }
or
[West]
Other examples:
In ["NORTH", "SOUTH", "EAST", "WEST"], the direction "NORTH" + "SOUTH" is going north and coming back right away.

The path becomes ["EAST", "WEST"], now "EAST" and "WEST" annihilate each other, therefore, the final result is [] (nil in Clojure).

In ["NORTH", "EAST", "WEST", "SOUTH", "WEST", "WEST"], "NORTH" and "SOUTH" are not directly opposite but they become directly opposite after the reduction of "EAST" and "WEST" so the whole path is reducible to ["WEST", "WEST"].

Task
Write a function dirReduc which will take an array of strings and returns an array of strings with the needless directions removed (W<->E or S<->N side by side).

The Haskell version takes a list of directions with data Direction = North | East | West | South.
The Clojure version returns nil when the path is reduced to nothing.
The Rust version takes a slice of enum Direction {North, East, West, South}.
See more examples in "Sample Tests:"
Notes
Not all paths can be made simpler. The path ["NORTH", "WEST", "SOUTH", "EAST"] is not reducible. "NORTH" and "WEST", "WEST" and "SOUTH", "SOUTH" and "EAST" are not directly opposite of each other and can't become such. Hence the result path is itself : ["NORTH", "WEST", "SOUTH", "EAST"].
if you want to translate, please ask before translating.

*/

//***************Solution********************

/*
Convert arr into string and perform pattern check to eliminate redundant direction using regex.Replace
return the result in string array form
*/
using System;
using System.Text.RegularExpressions;

public class DirReduction {
  
    public static string[] dirReduc(String[] arr) {
      string temp = string.Join(" ", arr);
      int redundancyCheck = temp.Length;
      
      while (redundancyCheck != 0){
        temp = Regex.Replace(temp, "NORTH SOUTH |NORTH SOUTH", "");  //pattern check
        temp = Regex.Replace(temp, "SOUTH NORTH |SOUTH NORTH", "");
        temp = Regex.Replace(temp, "EAST WEST |EAST WEST", "");
        temp = Regex.Replace(temp, "WEST EAST |WEST EAST", "");
        
        if(redundancyCheck == temp.Length){ //If length remains the same
          if(temp.EndsWith(' '))
            temp = temp.TrimEnd();    //remove the empty space at the end
          break;
        }
        else
        redundancyCheck = temp.Length; //More to check
      }
      
      return arr = temp.Split(' ');
    }
}

//****************Sample Test*****************
using System;
using System.Collections;
using NUnit.Framework;

[TestFixture]
public class DirReductionTests {

[Test]
  public void Test1() {
    string[] a = new string[] {"NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "WEST"};
    string[] b = new string[] {"WEST"};
    Assert.AreEqual(b, DirReduction.dirReduc(a));
  }
[Test]
  public void Test2() {
    string[] a = new string[] {"NORTH","SOUTH","SOUTH","EAST","WEST","NORTH", "NORTH"};
    string[] b = new string[] {"NORTH"};
    Assert.AreEqual(b, DirReduction.dirReduc(a));
  }
[Test]
  public void Test3() {
    string[] a = new string[] {"NORTH","SOUTH","SOUTH","EAST","WEST","NORTH","NORTH"};
    string[] b = new string[] {"NORTH"};
    Assert.AreEqual(b, DirReduction.dirReduc(a));
  }
[Test]
  public void Test4() {
    string[] a = new string[] {"EAST", "EAST", "WEST", "NORTH", "WEST", "EAST", "EAST", "SOUTH", "NORTH", "WEST"};
    string[] b = new string[] {"EAST", "NORTH"};
    Assert.AreEqual(b, DirReduction.dirReduc(a));
  }
[Test]
  public void Test5() {
    string[] a = new string[] {"NORTH", "EAST", "NORTH", "EAST", "WEST", "WEST", "EAST", "EAST", "WEST", "SOUTH"};
    string[] b = new string[] {"NORTH", "EAST"};
    Assert.AreEqual(b, DirReduction.dirReduc(a));
  }
[Test]
  public void Test6() {
    string[] a = new string[] {"NORTH", "WEST", "SOUTH", "EAST"};
    string[] b = new string[] {"NORTH", "WEST", "SOUTH", "EAST"};
    Assert.AreEqual(b, DirReduction.dirReduc(a));
  }

  public static string[] randDir(int n) {
      Random rnd = new Random();
      string[] dirs = new string[]{"NORTH", "SOUTH", "EAST", "WEST"};
      string[] result = new string[n];
      for (int i = 0; i < n; i++) {
          result[i] = dirs[(int) (rnd.Next(0, 3))];
      }
      return result;
  }

  public static string[] dirReducTest(String[] arr) {
        System.Collections.ArrayList pairs = new ArrayList();
        pairs.Add("NORTHSOUTH");
        pairs.Add("SOUTHNORTH");
        pairs.Add("EASTWEST");
        pairs.Add("WESTEAST");
        System.Collections.ArrayList result = new ArrayList();
        for (int i = arr.Length - 1; i >= 0; --i) {
            if ((result != null) && (result.Count > 0) && (pairs.Contains(arr[i] + result[0]))) {
                result.RemoveAt(0);
            } else {
                result.Insert(0, arr[i]);
            }
        }
        return result.ToArray(typeof(string)) as string[];
    }  

  [Test]
  public void Test7() {
    string[] a = DirReductionTests.randDir(8);
    string[] b = DirReductionTests.dirReducTest(a);
    Assert.AreEqual(b, DirReduction.dirReduc(a));
  }
  [Test]
  public void Test8() {
    string[] a = DirReductionTests.randDir(10);
    string[] b = DirReductionTests.dirReducTest(a);
    Assert.AreEqual(b, DirReduction.dirReduc(a));
  }
  [Test]
  public void Test9() {
    string[] a = DirReductionTests.randDir(10);
    string[] b = DirReductionTests.dirReducTest(a);
    Assert.AreEqual(b, DirReduction.dirReduc(a));
  }
[Test]
  public void Test10() {
    string[] a = DirReductionTests.randDir(15);
    string[] b = DirReductionTests.dirReducTest(a);
    Assert.AreEqual(b, DirReduction.dirReduc(a));
  }

}


