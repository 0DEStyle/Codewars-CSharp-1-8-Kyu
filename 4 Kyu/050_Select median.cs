/*Challenge link:https://www.codewars.com/kata/5540f0a23a2716acb6000004/train/csharp
Question:
Story
A team of five warriors needs to select one among them to represent their group in a certain tournament. Being proud and honest, they intend to send average member of their group. The only problem is, they don't know who would it be and they don't have much time...

Formal problem
Input:
IWarrior is an interface that provides only one function IsBetter. For objects implementing that interface, following conditions hold:

For any w, w.IsBetter(w) is true;
For any v, w, v.IsBetter(w) or w.IsBetter(v) is true;
For any u, v, w, if u.IsBetter(v) and v.IsBetter(w) is true, then u.IsBetter(w) is true. In other words, IsBetter is a non-strict total order, similar to >=.
Input consists of five IWarrior objects, passed as an array.
Output:
Kata.SelectMedian should return median - such IWarrior object from the input that it is better than two others and remaining two are better than it. This should be done with no more than six calls of IsBetter.

Notes and hints
-- This kata imitates a situation when comparing objects is a slow or otherwise costly operation.
-- Idea to sort an input array is a wrong one: sorting array of 5 elements with 6 comparations is mathematically impossible.

Credits
Kata is based on chapter 4 of "Elements of Programming" by Alexander Stepanov, Paul McJones.
Deeper theory behind the Kata can be found in volume 3 of "The Art of Computer Programming" by Donald E. Knuth, paragraph 5.3.3.
*/

//***************Solution********************
//chapter 4 of "Elements of Programming" by Alexander Stepanov, Paul McJones.
//ref: http://elementsofprogramming.com/eop.pdf#page=61

public interface IWarrior {bool IsBetter(IWarrior other);}

public static class Kata {
  public static IWarrior SelectMedian(IWarrior[] warriors){
  //should be done with no more than six calls of IsBetter.
  //warriors is IWarrior[5]
    var (a,b,c,d,e) = (warriors[0],warriors[1],warriors[2],warriors[3],warriors[4]);
    
    //swaping values no jutsu
    //1. a and b
    if(a.IsBetter(b)) (a , b) = (b , a);
    
    //2. c and d
    if(c.IsBetter(d)) (c , d) = (d , c);
    
    //3. a and c, b and d, median
    if(b.IsBetter(d)) (a , c,b , d) = (c , a,d , b);
    
    //4. c and e
    if(c.IsBetter(e)) (c , e) = (e , c);
    
    //5. b and e, a and c
    if(b.IsBetter(e)) (b , e,a , c) = (e , b,c , a);
    
    //final median between b and c
    return (b.IsBetter(c)) ? b : c;
  }
}


//****************Sample Test*****************
using System;
using System.Linq;
using NUnit.Framework;

public class Warrior : IWarrior {
  private int m_internal;
  
  public static int CompareCount {get; private set;}
  
  public Warrior(int rank=0){
    m_internal = rank;
  }
  
  public bool IsBetter(IWarrior other){
    ++CompareCount;
    if(other == null || !(other is Warrior)) return false;
    return m_internal >= (other as Warrior).m_internal;
  }
  
  public static void ResetCompareCount(){
    CompareCount = 0;
  }
}

[TestFixture]
public class MedianTests
{  
  [Test]
  public void SimpleTest(){
    try {
      Warrior[] input = new Warrior[]{
        new Warrior(1),
        new Warrior(4),
        new Warrior(5),
        new Warrior(3),
        new Warrior(2),
      };
      Warrior.ResetCompareCount();
      Assert.AreSame(input[3], Kata.SelectMedian(input));
      Assert.LessOrEqual(Warrior.CompareCount, 6);
    } catch(Exception ex){
      Assert.Fail(ex.Message);
    }
  }

  [Test]
  public void ExhaustiveTest(){
    try {
      Warrior[] warriors = new Warrior[]{
        new Warrior(1),
        new Warrior(2),
        new Warrior(3),
        new Warrior(4),
        new Warrior(5),
      };
      for(int i=0; i<120; ++i){
        Warrior[] input = new Warrior[5];
        int n = i;
        for(int j=5; j>0; --j) {
          input[5-j] = warriors
            .Where(w => !input.Contains(w))
            .ElementAt(n%j);
          n /= j;
        }
        
        Warrior.ResetCompareCount();
        if(warriors[2] != Kata.SelectMedian(input))
          Assert.Fail("Wrong warrior selected!");
        
        Assert.LessOrEqual(Warrior.CompareCount, 6);
      }
    } catch(Exception ex){
      Assert.Fail(ex.Message);
    }
  }
  
  [Test]
  // case of equal warriors
  public void ObscureTest(){
    try {
      Warrior[] warriors = new Warrior[]{
        new Warrior(1),
        new Warrior(2),
        new Warrior(2),
        new Warrior(4),
        new Warrior(4),
      };
      for(int i=0; i<120; ++i){
        Warrior[] input = new Warrior[5];
        int n = i;
        for(int j=5; j>0; --j) {
          input[5-j] = warriors
            .Where(w => !input.Contains(w))
            .ElementAt(n%j);
          n /= j;
        }
        
        Warrior.ResetCompareCount();
        IWarrior answer = Kata.SelectMedian(input);
        if(answer != warriors[1] && answer != warriors[2])
          Assert.Fail("Wrong warrior selected!");
        Assert.LessOrEqual(Warrior.CompareCount, 6);
      }
    } catch(Exception ex){
      Assert.Fail(ex.Message);
    }
  }
}
