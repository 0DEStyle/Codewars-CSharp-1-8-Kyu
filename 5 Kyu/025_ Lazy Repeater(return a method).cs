/*Challenge link:https://www.codewars.com/kata/51fc3beb41ecc97ee20000c3/train/csharp
Question:
The makeLooper() function (make_looper in Python) takes a string (of non-zero length) as an argument. It returns a function. The function it returns will return successive characters of the string on successive invocations. It will start back at the beginning of the string once it reaches the end.

For example:

Func<char> abc = Kata.MakeLooper("abc");
abc(); // should return 'a' on this first call
abc(); // should return 'b' on this second call
abc(); // should return 'c' on this third call
abc(); // should return 'a' again on this fourth call
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;

public class Kata{
  public static Func<char> MakeLooper(string str){
    int idx = 0;
    // () => means empty parameter 
    //idx plus 1 whenever the function return a value, then mod the str length to get the index.
    return () => str[idx++ % str.Length];
  }
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class Sample_Tests
  {
    [Test]
    public void SampleTest()
    {
      Func<char> abc = Kata.MakeLooper("abc");
      // Two iterations of looper
      // 1
      Assert.AreEqual('a', abc());
      Assert.AreEqual('b', abc());
      Assert.AreEqual('c', abc());
      // 2
      Assert.AreEqual('a', abc());
      Assert.AreEqual('b', abc());
      Assert.AreEqual('c', abc());
    }
  }
  
  [TestFixture]
  public class Random_Tests
  {
    private static Random rnd = new Random();
    
    private static Func<char> solution(string str)
    {
      int idx = 0;
      
      return () => str[idx++ % str.Length];
    }
    
    [Test, Description("Random Tests")]
    public void RandomTest()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        string testStr = String.Concat(new char[rnd.Next(3, 200)].Select(_ => (char)rnd.Next(97, 123)));
        
        Func<char> expected = solution(testStr);
        Func<char> actual = solution(testStr);
        
        for (int j = 0; j < 250; ++j)
        {
          Assert.AreEqual(expected(), actual());
        }
      }
    }
  }
}
