/*Challenge link:https://www.codewars.com/kata/563301d00656afb8a600009d/train/csharp
Question:
Write

public static object[] DeepSort(object[] arr, bool asc = false)
that, given an array of any depth, sorts it in the order given by asc.
When asc === true then sort ascending, otherwise descending.

For example:

Kata.DeepSort(new object[] {1, new object[] {2, 4}, 3, 8}) === new object[] {8,new object[] {4,2},3,1}
// When a number is compared to an array or an array to another array,
// you need to get the sum of the array. In this case {2,4} === 6. 6 is the second highest
// value in the entire array and thus  {2,4} is second when sorting descending. The array {2,4}
// is also sorted based on asc argument, hence {4,2}

Kata.DeepSort(new object[] {1, 2, 3, 4, new object[] {-5,-4}}, true)) === new object[] {new object[] {-5,-4},1,2,3,4}
Kata.DeepSort(new object[] {1, new object[] {2, 3, new object[] {4, 5, new object[] {9, 11}, 1, 8}, 6}, new object[] {20, 7, 8}}, false) === new object[] {new object[] {new object[] {new object[] {11, 9}, 8, 5, 4, 1}, 6, 3, 2}, new object[] {20, 8, 7}, 1}
Kata.DeepSort(new object[] {2, new object[] {1, 1}, new object[] {1, 1}, 2}, true) === new object[] {2, new object[] {1, 1}, new object[] {1, 1}, 2} // already sorted, this is equivalent to new object[] {2, 2, 2, 2}
*/

//***************Solution********************
/*
//sum the inner array
1, (2,4), 3, 8 => 1, (6), 3, 8 
//sort in decending order
8, (6), 3, 1 => 8, (4, 2), 3, 1

example 1
1, 2, 3, 4, (-5,-4) => 1, 2, 3, 4, (-9)
sort ascending
(-9), 1, 2, 3, 4 => (-5, -4), 1, 2, 3, 4 

example 2
1, (2, 3, 6, (1, 4, 5, 8 (9, 11))), (20, 7, 8) => 1,(11, (18, (20))), (35) => 1, 49, 35
sort descending
49, 35, 1 => (((11, 9), 8, 5, 4, 1), 6, 3, 2), (20, 8, 7), 1

*/
using System;
using System.Linq;

public class Kata{
  //x is cuurrent element
  //check if x is an array, if true find the sum, else return x
  private static int Sum(object[] arr) => arr.Sum(x => x.GetType().IsArray ? Sum((object[])x) : (int)x);
  
  public static object[] DeepSort(object[] arr, bool asc = false){
    
    //i is the current element, if i is an array
    //call DeepSort method recurrsively, else return i
    //store the elements in array temp.
    var temp = arr.Select(i => i.GetType().IsArray ? DeepSort((object[])i, asc) : i);
    
    //check for asc flag
    //if true sort by ascending, false sort by descending
    //x is the current element, if element is an array, pass array into Sum() method , else return x
    //store in array and return the result.
    return asc ? 
              temp.OrderBy(x => x.GetType().IsArray ? Sum((object[])x) : x).ToArray() :
    temp.OrderByDescending(x => x.GetType().IsArray ? Sum((object[])x) : x).ToArray();
  }
}

//solution 2 (better)
using System;
using System.Linq;

public class Kata {
  public static object[] DeepSort(object[] arr, bool asc = false) {
    return (object[]) Walk(arr, asc);
    long Weight(object obj) => obj is object[] ls ? ls.Sum(Weight) : (int)obj;
    object Walk(object obj, bool asc) => obj is object[] ls ? ls.Select(e => Walk(e, asc)).OrderBy(e => asc ? Weight(e) : -Weight(e)).ToArray() : obj;
  }
}
//****************Sample Test*****************
namespace Solution
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;

  [TestFixture]
  public class KataTests
  {
    [Test]
    public void BasicTests()
    {
      TestWithVisualization(Kata.DeepSort(new object[] { 1, 2, 3, 4 }, true), new object[] { 1, 2, 3, 4 });
      TestWithVisualization(Kata.DeepSort(new object[] { 1, 2, 3, 4 }), new object[] { 4, 3, 2, 1 });      
      TestWithVisualization(Kata.DeepSort(new object[] { 2, new object[] {1, 1}, new object[] {1, 1}, 2}, true),new object[] {2,new object[] {1,1},new object[] {1,1},2});
      TestWithVisualization(Kata.DeepSort(new object[] { 1, 2, 3, 4, new object[] {-5, -4}}, true), new object[] {new object[] {-5,-4},1,2,3,4} );
      TestWithVisualization(Kata.DeepSort(new object[] { 1, 2, 3, 4, new object[] {-5, -4}}), new object[] {4,3,2,1,new object[] {-4,-5}});
      TestWithVisualization(Kata.DeepSort(new object[] { 1, new object[] {2, 3, new object[] {4, 5, new object[] {9, 11}, 1, 8}, 6}, new object[] {20, 7, 8}}, true),new object[] {1,new object[] {7,8,20},new object[] {2,3,6,new object[] {1,4,5,8,new object[] {9,11}}}});
      TestWithVisualization(Kata.DeepSort(new object[] { 1, new object[] {2, 3, new object[] {4, 5, new object[] {9, 11}, 1, 8}, 6}, new object[] {20, 7, 8}}),new object[] {new object[] {new object[] {new object[] {11,9},8,5,4,1},6,3,2},new object[] {20,8,7},1});
      TestWithVisualization(Kata.DeepSort(new object[] { 1, new object[] {2, 4}, 3, 8, new object[] {6, 6, new object[] {3, 3, new object[] {5, new object[] {8, 9, 0, new object[] {12, new object[] {11, 11, new object[] {1}}}}}}}, -1, new object[] {80, 12}}, true),new object[] {-1,1,3,new object[] {2,4},8,new object[] {6,6,new object[] {3,3,new object[] {5,new object[] {0,8,9,new object[] {12,new object[] {new object[] {1},11,11}}}}}},new object[] {12,80}});
      TestWithVisualization(Kata.DeepSort(new object[] { 1, new object[] {2, 4}, 3, 8, new object[] {6, 6, new object[] {3, 3, new object[] {5, new object[] {8, 9, 0, new object[] {12, new object[] {11, 11, new object[] {1}}}}}}}, -1, new object[] {80, 12}}),new object[] {new object[] {80,12},new object[] {new object[] {new object[] {new object[] {new object[] {new object[] {11,11,new object[] {1}},12},9,8,0},5},3,3},6,6},8,new object[] {4,2},3,1,-1});
      TestWithVisualization(Kata.DeepSort(new object[] { new object[] {4, 2, 7}, new object[] {7, 2, 4}, new object[] {2, 4, 7}}, true),new object[] {new object[] {2,4,7},new object[] {2,4,7},new object[] {2,4,7}});
      TestWithVisualization(Kata.DeepSort(new object[] { new object[] {4, 2, 7}, new object[] {7, 2, 4}, new object[] {2, 4, 7}}),new object[] {new object[] {7,4,2},new object[] {7,4,2},new object[] {7,4,2}});
      TestWithVisualization(Kata.DeepSort(new object[] { 86, new object[] {33, 8, new object[] {9, 4, 4, 3, new object[] {1, 2, 3}}, 5, 5, new object[] {77, 1, -1, new object[] {-5, -6, -7}, new object[] {56, 65, 43}}}}, true),new object[] {86,new object[] {5,5,8,new object[] {3,4,4,new object[] {1,2,3},9},33,new object[] {new object[] {-7,-6,-5},-1,1,77,new object[] {43,56,65}}}});
      TestWithVisualization(Kata.DeepSort(new object[] { 86, new object[] {33, 8, new object[] {9, 4, 4, 3, new object[] {1, 2, 3}}, 5, 5, new object[] {77, 1, -1, new object[] {-5, -6, -7}, new object[] {56, 65, 43}}}}, false),new object[] {new object[] {new object[] {new object[] {65,56,43},77,1,-1,new object[] {-5,-6,-7}},33,new object[] {9,new object[] {3,2,1},4,4,3},8,5,5},86});
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
            
      Func<object[], bool, object[]> myDeepSort = null;
      
      myDeepSort = delegate (object[] arr, bool asc)
      {        
        for(var i=0;i<arr.Length;i++)
        {
          if(arr[i].GetType().IsArray)
          {
            arr[i] = myDeepSort((object[])arr[i], asc);
          }
        }
        return arr.OrderBy(a => a, new MyOrderComparer(asc)).ToArray(); 
      };
      
      for (var cc = 0; cc < 50; cc++) 
      {
        var a = new object[] { rand.Next(1, 100), rand.Next(1, 100), new object[] { rand.Next(1, 100), rand.Next(1, 100), new object[] { rand.Next(1, 100), new object[] { rand.Next(1, 100), rand.Next(1, 100), rand.Next(1, 100)}, rand.Next(1, 100), rand.Next(1, 100)}, rand.Next(1, 100), rand.Next(1, 100)}, rand.Next(1, 100)};
        var b = a.ToArray();
        TestWithVisualization(Kata.DeepSort(a, false), myDeepSort(b, false));
        a = new object[] { rand.Next(1, 100), new object[] { rand.Next(1, 100), new object[] { rand.Next(1, 100), new object[] { rand.Next(1, 100), rand.Next(1, 100)}, rand.Next(1, 100), rand.Next(1, 100)}, rand.Next(1, 100)}, rand.Next(1, 100), rand.Next(1, 100), new object[] { rand.Next(1, 100), new object[] { rand.Next(1, 100)}, rand.Next(1, 100)}};
        b = a.ToArray();
        TestWithVisualization(Kata.DeepSort(a, true), myDeepSort(b, true));
        a = new object[] { rand.Next(1, 100), rand.Next(1, 100), new object[] { rand.Next(1, 100), rand.Next(1, 100), new object[] { rand.Next(1, 100), new object[] { rand.Next(1, 100), rand.Next(1, 100), rand.Next(1, 100)}, rand.Next(1, 100), rand.Next(1, 100)}, rand.Next(1, 100), rand.Next(1, 100)}, rand.Next(1, 100)};
        b = a.ToArray();
        TestWithVisualization(Kata.DeepSort(a, true), myDeepSort(b, true));
        a = new object[] { rand.Next(1, 100), new object[] { rand.Next(1, 100), new object[] { rand.Next(1, 100), new object[] { rand.Next(1, 100), rand.Next(1, 100)}, rand.Next(1, 100), rand.Next(1, 100)}, rand.Next(1, 100)}, rand.Next(1, 100), rand.Next(1, 100), new object[] { rand.Next(1, 100), new object[] { rand.Next(1, 100)}, rand.Next(1, 100)}};
        b = a.ToArray();
        TestWithVisualization(Kata.DeepSort(a), myDeepSort(b, false));
      }
    }
    
    private static void TestWithVisualization(object[] actual, object[] expected)
    {      
      Assert.AreEqual(ArrayToString(expected), ArrayToString(actual));
    }
    
    private static string ArrayToString(object[] array)
    {
      List<string> list = new List<string>();
      for(int i=0;i<array.Length;i++)
      {
        if(array[i].GetType().IsArray)
        {
          list.Add(ArrayToString((object[])array[i]));
        }
        else
        {
          list.Add(array[i].ToString());
        }
      }
      return "[" + string.Join(", ", list) + "]";
    }
    
    private class MyOrderComparer : IComparer<object>
    {
      private bool _asc;
      public MyOrderComparer(bool asc)
      {
        _asc = asc;
      }
    
      public int Compare(object a, object b)
      {
        return (_asc == true ? 1 : -1) * (GetOrderIndex(a) - GetOrderIndex(b));
      }
      
      private int GetOrderIndex(object obj)
      {
        if(!obj.GetType().IsArray)
        {
          return (int)obj;
        }
  
        return (int)(((object[])obj).Aggregate((a,b) => GetOrderIndex(a) + GetOrderIndex(b)));
      }
    }
  }
