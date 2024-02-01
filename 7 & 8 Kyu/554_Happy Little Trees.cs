/*Challenge link:https://www.codewars.com/kata/56a8f83d96d99a315a0000a0/train/csharp
Question:
Create a Tree class so I can grow a happy little tree. The tree has a trunk and branches which grow in unit sizes. Branches can start at the current trunk height. All branches grow simultaneously,

Methods to include:

Tree() - Constructor (trunk starts with height of 1 and no branches)
GrowTrunk() - Increase trunk height by 1 (add a new level on top of the tree similar to adding layers to a cake)
NewBranch() - Add a new branch at the current height (multiple separate branches can be added at each level)
GrowBranches() - All existing branches increase in length by 1
Ouch(int n) - The nth oldest branch is removed (the input is 1-indexed, and must be validated: if a branch does not exist or the input is not positive, do nothing)
Description() - Returns a string describing all the properties of the tree as seen below (replace the _ with appropiate values, )
"The tree trunk is {HEIGHT} unit(s) tall! There are {BRANCHES_COUNT} branch(es) that have position(s): {POSITIONS...} and length(s): {LENGTHS...}!"
Where HEIGHT and BRANCHES_COUNT are integers, POSITIONS... and LENGTHS... are comma-separated lists.

If there are no branches, the following string should be returned instead:

"The tree trunk is {HEIGHT} unit(s) tall! There are 0 branch(es)!"
Preloaded code for class structure:

public interface ITree
{
  void GrowTrunk();
  void GrowBranches();
  void NewBranch();
  void Ouch(int n);
  string Description();
}
*/

//***************Solution********************
using System;
using System.Linq;
using System.Collections.Generic;

/*
functions:
  void GrowTrunk();
  void GrowBranches();
  void NewBranch();
  void Ouch(int n);
  string Description();
*/

public class Tree : ITree{
  //initilise size and branches list
  private int size {get; set;} = 1;
  private List<(int,int)> branches = new List<(int,int)>();
  
  //growth trunk and branches and store in list
  public void GrowTrunk() => size++;
  public void NewBranch() => branches.Add((size,1));
  public void GrowBranches() => branches = branches.Select(x => (x.Item1, x.Item2 + 1)).ToList();
  
  //remove olddest branches
  public void Ouch(int n){
    if(n >= 1 && n <= branches.Count)
      branches.RemoveAt(n - 1);
  }
  
  //format string and return description
  public string Description(){
    var position = string.Join(",",branches.Select(x => x.Item1));
    var len = string.Join(",",branches.Select(x => x.Item2));
    return branches.Count == 0 ?
    $"The tree trunk is {size} unit(s) tall! There are {branches.Count} branch(es)!" :
    $"The tree trunk is {size} unit(s) tall! There are {branches.Count} branch(es) that have position(s): {position} and length(s): {len}!";
}
}

//****************Sample Test*****************
using System;
using System.Collections.Generic;
using NUnit.Framework;



[TestFixture]
public static class Tests
{
[Test]
    public static void emptytree()
    {
      Pre sol = new Pre();
      Tree happy = new Tree();
      Assert.AreEqual(sol.sol1,happy.Description());
    }
[Test]
    public static void badtree()
    {
      Pre sol = new Pre();
      Tree happy = new Tree();
      happy.GrowBranches();
      happy.Ouch(1);
      happy.GrowTrunk();
      Assert.AreEqual(sol.sol2,happy.Description());
    }
[Test]
    public static void test1()
    {
      Pre sol = new Pre();
      Tree happy = new Tree();
      happy.NewBranch();
      happy.GrowTrunk();
      happy.GrowBranches();
      happy.GrowTrunk();
      happy.NewBranch();
      happy.NewBranch();
      happy.NewBranch();
      happy.NewBranch();
      happy.GrowBranches();
      happy.Ouch(3);
      happy.GrowTrunk();
      happy.GrowTrunk();
      happy.NewBranch();
      happy.GrowBranches();
      Assert.AreEqual(sol.sol3,happy.Description());
    }
[Test]
    public static void test2()
    {
      Pre sol = new Pre();
      Tree happy = new Tree();
      for(int i=0;i<1000;i++)
      {
      happy.GrowTrunk();
      happy.NewBranch();
      happy.GrowBranches();
      }
      Assert.AreEqual(sol.sol4,happy.Description());
    }
[Test]
    public static void test3()
    {
      Pre sol = new Pre();
      Tree happy = new Tree();
      happy.Ouch(-2);
      happy.Ouch(500);
      happy.GrowBranches();
      for(int i=0; i<100000;i++)
      {
        happy.GrowTrunk();
      }
      Assert.AreEqual(sol.sol5,happy.Description());
    }
[Test]
    public static void test4()
    {
      Pre sol = new Pre();
      Tree happy = new Tree();
      for(int i=0; i<100;i++)
      {
        happy.NewBranch();
      }
      happy.GrowBranches();
      for(int i=0; i<100;i++)
      {
        happy.GrowTrunk();
      }
      happy.GrowBranches();
      for(int i=0; i<100;i++)
      {
        happy.NewBranch();
      }
      for(int i=0; i<100;i++)
      {
        happy.GrowTrunk();
      }for(int i=0; i<100;i++)
      {
        happy.GrowBranches();
      }
      for(int i=-3; i<100;i++)
      {
        happy.Ouch(i);
      }
      Assert.AreEqual(sol.sol6,happy.Description());
    }
 [Test]
    public static void test5()
    {
      Pre sol = new Pre();
      Tree happy = new Tree();
      happy.NewBranch();
      happy.GrowBranches();
      happy.GrowTrunk();
      happy.NewBranch();
      happy.GrowBranches();
      happy.Ouch(1);
      Assert.AreEqual(sol.sol7,happy.Description());
    }
}
