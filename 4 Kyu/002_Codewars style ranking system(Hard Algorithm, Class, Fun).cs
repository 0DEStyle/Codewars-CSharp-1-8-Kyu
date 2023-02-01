/*Challenge link:https://www.codewars.com/kata/51fda2d95d6efda45e00004e/train/csharp
Question:
Write a class called User that is used to calculate the amount that a user will progress through a ranking system similar to the one Codewars uses.

Business Rules:
A user starts at rank -8 and can progress all the way to 8.
There is no 0 (zero) rank. The next rank after -1 is 1.
Users will complete activities. These activities also have ranks.
Each time the user completes a ranked activity the users rank progress is updated based off of the activity's rank
The progress earned from the completed activity is relative to what the user's current rank is compared to the rank of the activity
A user's rank progress starts off at zero, each time the progress reaches 100 the user's rank is upgraded to the next level
Any remaining progress earned while in the previous rank will be applied towards the next rank's progress (we don't throw any progress away). The exception is if there is no other rank left to progress towards (Once you reach rank 8 there is no more progression).
A user cannot progress beyond rank 8.
The only acceptable range of rank values is -8,-7,-6,-5,-4,-3,-2,-1,1,2,3,4,5,6,7,8. Any other value should raise an error.
The progress is scored like so:

Completing an activity that is ranked the same as that of the user's will be worth 3 points
Completing an activity that is ranked one ranking lower than the user's will be worth 1 point
Any activities completed that are ranking 2 levels or more lower than the user's ranking will be ignored
Completing an activity ranked higher than the current user's rank will accelerate the rank progression. The greater the difference between rankings the more the progression will be increased. The formula is 10 * d * d where d equals the difference in ranking between the activity and the user.
Logic Examples:
If a user ranked -8 completes an activity ranked -7 they will receive 10 progress
If a user ranked -8 completes an activity ranked -6 they will receive 40 progress
If a user ranked -8 completes an activity ranked -5 they will receive 90 progress
If a user ranked -8 completes an activity ranked -4 they will receive 160 progress, resulting in the user being upgraded to rank -7 and having earned 60 progress towards their next rank
If a user ranked -1 completes an activity ranked 1 they will receive 10 progress (remember, zero rank is ignored)
Code Usage Examples:
User user = new User();
user.rank; // => -8
user.progress; // => 0
user.incProgress(-7);
user.progress; // => 10
user.incProgress(-5); // will add 90 progress
user.progress; // => 0 // progress is now zero
user.rank; // => -7 // rank was upgraded to -7
Note: In C# some methods may throw an ArgumentException.

Note: Codewars no longer uses this algorithm for its own ranking system. It uses a pure Math based solution that gives consistent results no matter what order a set of ranked activities are completed at.


*/

//***************Solution********************
using System;
//test arug (int rank, int expectedRank, int expectedProgress)

public class User {
  public int rank = -8; //starting rank, note rank order: -8,-7,-6,-5,-4,-3,-2,-1,1,2,3,4,5,6,7,8
  public int progress; //cap at 100 per rank

  public void incProgress(int actRank) {
    if(actRank < -8 || actRank > 8 || actRank == 0) throw new ArgumentException(); //check rank range first
    Console.WriteLine("actRank:" + actRank + ", rank:" + rank + ", progress:" + progress);
    
    if(actRank > 0 && rank < 0){ //there is no rank 0, so skip one rank
      Console.WriteLine("actRank is positive:" + actRank);
      actRank-=1;
    }
    
    int rankDiff = actRank - rank;     //find rank difference
    Console.WriteLine("rankDiff:"+rankDiff);
    
    if(rank == 8){                   //if rank 8 is reached, cap progress back to 0
          Console.WriteLine("Max rank mate, good job");
          rank = 8;
          progress = 0;
        }
    
    else if(rankDiff <= 0){         //if activity task is negative or 0, meaning easier difficulty
      if(rankDiff == 0){            //activity is on the same rank, +3 point
        Console.WriteLine("rankDiff is 0, add 3");
        progress = progress + 3;
      }
      else                          //lower rank difference +1 point
        progress+=1;
      Console.WriteLine("progress:"+progress);
    }
    
    else if(rankDiff >= -2){       //activity is equal or more than 2 ranks difference, meaning harder difficulty
      progress += rankDiff * rankDiff * 10; 
      
      if(progress - 100 >= 0){     //if points reached over 100, level up to new rank
        int levelup = progress / 100;
        int remainder = progress % 100;
        Console.WriteLine("current progress is:" + progress +",exceeded 100, level up rank by:"+levelup + ",remainder:"+remainder);
        
        if(rankDiff >= 8){         //if rank difference is less than or equal to 8, shift the rank to positive. 
          Console.WriteLine("rank:"+rank);
           rank = levelup - 8;
          progress = remainder;
          Console.WriteLine("new level up after -8:"+levelup);
          
        }else if(levelup > 1){      //if rank is already positive, level up normally
          Console.WriteLine("rank:"+rank);
           rank += levelup;
          progress = remainder;
        }
        
        else{                       //for negative rank
          progress -= 100;
          rank++;
          
          if(rank == 8){          //special statement for ranking up from rank 7 to 8.
          Console.WriteLine("Max rank mate, good job");
          rank = 8;
          progress = 0;
        }
        }
        
        if(rank == 0)           //if rank is 0, skip it, because rank 0 is ignored.
            rank++;
        
        Console.WriteLine("final rank:"+ rank + ",final progress:"+progress);
      }
    }
  }
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  
  [TestFixture]
  public class UserTest
  {  
  
    // Assert correct rank progression
    public void assertRankProgression(int rank, User user, int expRank, int expProgress) {
      Assert.True(user.rank == expRank,
        "Applied Rank: " + rank + 
        "; Expected rank: " + expRank + 
        "; Actual: " + user.rank);
        
      Assert.True(user.progress == expProgress,
        "Applied Rank; " + rank + 
        "; Expected progress: " + expProgress + 
        ", Actual: " + user.progress);
    }
    
    [TestCase(-7, -8, 10)]
    [TestCase(-6, -8, 40)]
    [TestCase(-5, -8, 90)]
    [TestCase(-4, -7, 60)]
    [TestCase(-8, -8, 3)]
    // Check single increments
    public void testValidSingleRankProgression(int rank, int expectedRank, int expectedProgress)
    {
      User user = new User();
      
      user.incProgress(rank);
      
      assertRankProgression(rank, user, expectedRank, expectedProgress);
    }
    
    [TestCase]
    // Check multiple user increments within one scenario
    public void testValidMultipleRankProgression() 
    {
      // Setup
      User user = new User();
      
      // path to follow to check rank progression
      var path = new[]
      {
          new { rank = 1, expRank = -2, expProg = 40 },
          new { rank = 1, expRank = -2, expProg = 80 },
          new { rank = 1, expRank = -1, expProg = 20 },
          new { rank = 1, expRank = -1, expProg = 30 },
          new { rank = 1, expRank = -1, expProg = 40 },
          new { rank = 2, expRank = -1, expProg = 80 },
          new { rank = 2, expRank = 1,  expProg =20 },
          new { rank = -1,expRank =  1, expProg = 21 },
          new { rank = 3, expRank = 1,  expProg =61 },
          new { rank = 8, expRank = 6,  expProg =51 },
          new { rank = 8, expRank = 6,  expProg =91 },
          new { rank = 8, expRank = 7,  expProg =31 },
          new { rank = 8, expRank = 7,  expProg =41 },
          new { rank = 8, expRank = 7,  expProg =51 },
          new { rank = 8, expRank = 7,  expProg =61 },
          new { rank = 8, expRank = 7,  expProg =71 },
          new { rank = 8, expRank = 7,  expProg =81 },
          new { rank = 8, expRank = 7,  expProg =91 },
          new { rank = 8, expRank = 8,  expProg =0 },
          new { rank = 8, expRank = 8,  expProg =0 },
      };
      
      // Go through path specified and assert rank at each step
      foreach (var element in path) {
        user.incProgress(element.rank);
        assertRankProgression(element.rank, user, element.expRank, element.expProg);
      }
    }
    
    [TestCase(9)]
    [TestCase(-9)]
    [TestCase(0)]
    // Check invalid rank progressions
    public void testInvalidRange(int rank) 
    {
      User user = new User();
      Assert.Throws<ArgumentException>(() => user.incProgress(rank));
    }
  }
}
