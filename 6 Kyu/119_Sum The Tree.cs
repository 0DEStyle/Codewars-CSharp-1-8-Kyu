/*Challenge link:https://www.codewars.com/kata/5800580f8f7ddaea13000025/train/csharp
Question:
Given a node object representing a binary tree:

public class Node
{  
    public int Value;  
    public Node Left;  
    public Node Right;
    
    public Node(int value, Node left = null, Node right = null)
    {
      Value = value;
      Left = left;
      Right = right;
    }
}  
write a function that returns the sum of all values, including the root. Absence of a node will be indicated with a null value.

Examples:

10
| \
1  2
=> 13

1
| \
0  0
    \
     2
=> 3
*/

//***************Solution********************

//if root is null return 0
//else root.value + recurrsive accumulation of root left + recurrsive accumulation of root right 
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

public static class Kata{
  public static int SumTree(Node root) =>  root == null ? 0 : root.Value + SumTree(root.Left) + SumTree(root.Right);
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
    
  public static class Solution
  {
    public static int SumTree(Node root) =>
      (root == null) ? 0 : root.Value + SumTree(root.Left) + SumTree(root.Right);
  }

  [TestFixture]
  public class BasicTest
  {
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        yield return new TestCaseData(new Node(10, new Node(1), new Node(2))).Returns(13).SetDescription("Simple Test");
        yield return new TestCaseData(new Node(11, new Node(0), new Node(0, null, new Node(1)))).Returns(12).SetDescription("Handles unbalanced trees");
        yield return new TestCaseData(new Node(1)).Returns(1).SetDescription("Handles childless roots");
        yield return new TestCaseData(new Node(-1, null, new Node(-2, null, new Node(-3)))).Returns(-6).SetDescription("Correctly sums negative numbers");
        yield return new TestCaseData(new Node(1, null, new Node(1, null, new Node(1, null, new Node(1, null, new Node(1, null, new Node(1, null, new Node(1)))))))).Returns(7).SetDescription("Handles deep nodes");
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public int Test(Node root) =>
      Kata.SumTree(root);
  }

  [TestFixture]
  public class RandomTest
  {
    private static Random rnd = new Random();
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        const int Tests = 100;
        
        for (int i = 0; i < Tests; ++i)
        {
          TreeData test = getRandomTree(1, 100);
          yield return new TestCaseData(test.Root).Returns(test.Sum).SetDescription(String.Format("Expected sum of {0} for a tree of {1} nodes", test.Sum, test.NodeCount));
        }
      }
    }
    
    private struct TreeData
    {
      public int NodeCount;
      public int Sum;
      public Node Root;
      
      public TreeData(int nodeCount, int sum, Node root)
      {
        NodeCount = nodeCount;
        Sum = sum;
        Root = root;
      }
    }
    
    private static Node getRandomNode()
    {
      return new Node(rnd.Next(-100, 101));
    }
    
    private static TreeData getRandomTree(int min, int max)
    {
      int nodeCount = rnd.Next(min, max + 1);
      Node root = getRandomNode();
      int sum = root.Value;
      
      Node currentNode = root;
      for (int i = 0; i < nodeCount; ++i)
      {
        bool goLeft = rnd.Next(0, 2) == 1;
        if (goLeft)
        {
          currentNode.Left = getRandomNode();
          currentNode = currentNode.Left;
        }
        else
        {
          currentNode.Right = getRandomNode();
          currentNode = currentNode.Right;
        }
        sum += currentNode.Value;
      }
      
      return new TreeData(nodeCount, sum, root);
    }
    
    [Test, TestCaseSource("testCases")]
    public int Test(Node root) =>
      Kata.SumTree(root);
  }
}
