/*Challenge link:https://www.codewars.com/kata/5779624bae28070489000146/train/csharp
Question:
Our AAA company is in need of some software to help with logistics: you will be given the width and height of a map, a list of x coordinates and a list of y coordinates of the supply points, starting to count from the top left corner of the map as 0.

Your goal is to return a two dimensional array/list with every item having the value of the distance of the square itself from the closest supply point expressed as a simple integer.

Quick examples:

LogisticMap(3,3,{0},{0})
//returns
//{{0,1,2},
// {1,2,3},
// {2,3,4}}
LogisticMap(5,2,{0,4},{0,0})
//returns
//{{0,1,2,1,0},
// {1,2,3,2,1}}
Remember that our company is operating with trucks, not drones, so you can simply use Manhattan distance. If supply points are present, they are going to be within the boundaries of the map; if no supply point is present on the map, just return None/nil/null in every cell.

LogisticMap(2,2,{},{})
//returns
//{{-1,-1},
// {-1,-1}}
Note: this one is taken (and a bit complicated) from a problem a real world AAA company [whose name I won't tell here] used in their interview. It was done by a friend of mine. It is nothing that difficult and I assume it is their own version of the FizzBuzz problem, but consider candidates were given about 30 mins to solve it.
*/

//***************Solution********************
using System;

public class Kata
{
  public static int[,] LogisticMap(int width, int height, int[] xs, int[] ys)
  {
    //set map size
    var retArray = new int[height, width];
    
    for (int y = 0; y < height; y++)
    {
      for (int x = 0; x < width; x++)
      {
        //set all cooridinates to -1 first as default
        retArray[y, x] = -1;
        
        //Manhattan distance
        //xs.Length can either be 0, 1 or 2
        //0 means null, 1 means 1 cooridinate, 2 means 2 cooridinates
        for (int point = 0; point < xs.Length; point++)
        {
          var distance = Math.Abs(x - xs[point]) + Math.Abs(y - ys[point]);
          
          //set currentDistance to last cooridinates
          var currenDistance = retArray[y, x];
          
          //Find mid distance between cooridinates,
          //Compare result for different points, take lowest
          //point 0 is distance from starting coordinate 1(xs,ys) 
          //to target coordinate(x,y)
          //point 1 is distance from starting coordinate 2(xs,ys)
          //to target coordinate(x,y)
          if (currenDistance > distance || point == 0)
            retArray[y, x] = distance;
        }
      }
    }
    return retArray;
  }
}

//****************Sample Test*****************
  amespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void BasicTests()
    {
      var xs = new int[]{0};
      var ys = new int[]{0};
      var val = Kata.LogisticMap(3,3,xs,ys);
      var ans = new int[3,3]{{0,1,2},{1,2,3},{2,3,4}};
      Assert.AreEqual(ans, val);
      
      xs = new int[]{2};
      ys = new int[]{2};
      val = Kata.LogisticMap(3,3,xs,ys);
      ans = new int[3,3]{{4,3,2},{3,2,1},{2,1,0}};
      Assert.AreEqual(ans, val);
      
      xs = new int[]{0};
      ys = new int[]{0};
      val = Kata.LogisticMap(1,1,xs,ys);
      ans = new int[1,1]{{0}};
      Assert.AreEqual(ans, val);
      
      xs = new int[]{0,4};
      ys = new int[]{0,0};
      val = Kata.LogisticMap(5,2,xs,ys);
      ans = new int[2,5]{{0,1,2,1,0},{1,2,3,2,1}};
      Assert.AreEqual(ans, val);
      
      xs = new int[]{};
      ys = new int[]{};
      val = Kata.LogisticMap(2,2,xs,ys);
      ans = new int[2,2]{{-1, -1},{-1, -1}};
      Assert.AreEqual(ans, val);
    }
    /*

const randint=(a,b)=>~~(Math.random()*(b-a+1)+a);
const sol=(w,h,x,y)=>(s=>Array.from({length:h},(_,q)=>Array.from({length:w},(_,k)=>s.length ? s.reduce((a,b)=>Math.min(a,Math.abs(b[0]-k)+Math.abs(b[1]-q)),9999999) : null)))(x.map((a,i)=>[a,y[i]]));

for (var ih=0;ih<40;ih++){
    var [w,h]=[randint(1,10)+randint(1,10),randint(1,10)+randint(1,10)];
    var [xs,ys]=(n=>[Array.from({length:n},a=>randint(0,w-1)),Array.from({length:n},a=>randint(0,h-1))])(randint(0,Math.max(10,~~((w+h)/2))));
    Test.it(`Testing for logistic_map(${w}, ${h}, [${xs.join(", ")}], [${ys.join(", ")}])`,_=>{
    Test.assertSimilar(logisticMap(w,h,xs,ys),sol(w,h,xs,ys),"It should work for random inputs too");
    })
}
})*/
    [Test]
    public void RandomTests()
    {
      Random rand = new Random(DateTime.Now.Millisecond);
      
      for(var i = 0; i < 40; i++) 
      {
        var width = rand.Next(1,10) + rand.Next(1,10);
        var height = rand.Next(1,10) + rand.Next(1,10);
        var count = rand.Next(0,Math.Max(10, ~~((width+height) / 2) ));
        var xs = GeneratePoints(count, width);
        var ys = GeneratePoints(count, height);
        
        var ans = sol(height, width, xs, ys);
        
        var val = Kata.LogisticMap(height,width,xs,ys);
                        
        Assert.AreEqual(ans, val);
      }
    }
    
    private int[] GeneratePoints(int number, int l) 
    {
      Random rand = new Random(DateTime.Now.Millisecond);
      var points = new int[number];
      for(var i = 0; i < points.Length; i++) {
        points[i] = rand.Next(0,l-1);
      }
      return points;     
    }
    
    private int[,] sol(int width, int height, int[] xs, int[] ys)
    {
      var map = new int[height,width];
      
      for(var y=0; y<height; y++) {
        for(var x=0; x<width; x++) {
          map[y,x] = ShorterManathan(x, y, xs, ys);
        }
      }
      
      return map;
    }
  
    private int ShorterManathan(int x1, int y1, int[] xs, int[] ys)
    {
      var min = -1;
      for(var i=0; i < xs.Length; i++ )
      {
        var val = Math.Abs(x1-xs[i]) + Math.Abs(y1-ys[i]);
        min = val < min || min == -1 ? val : min;
      }
    
      return min;
    }
  }
}
