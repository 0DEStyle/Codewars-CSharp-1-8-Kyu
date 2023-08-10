/*Challenge link:https://www.codewars.com/kata/52bef5e3588c56132c0003bc/train/csharp
Question:
You are given a binary tree:

public class Node
{
    public Node Left;
    public Node Right;
    public int Value;
    
    public Node(Node l, Node r, int v)
    {
        Left = l;
        Right = r;
        Value = v;
    }
}
Your task is to return the list with elements from tree sorted by levels, which means the root element goes first, then root children (from left to right) are second and third, and so on.

Return empty list if root is 'null'.

Example 1 - following tree:

                 2
            8        9
          1  3     4   5
Should return following list:

[2,8,9,1,3,4,5]
Example 2 - following tree:

                 1
            8        4
              3        5
                         7
Should return following list:

[1,8,4,3,5,7]
*/

//***************Solution********************
using System.Collections.Generic;
using System.Linq;

class Kata{
    public static List<int> TreeByLevels(Node node){
      //list of Nodes
        List<Node> nodeList = new List<Node>();
      
      //add a node if node is not null
        if(node != null) 
          nodeList.Add(node);

        for(int i = 0; i < nodeList.Count; i++){
          //if current node to the left is not null, add left node
            if(nodeList[i].Left!= null) 
              nodeList.Add(nodeList[i].Left);
          //if current node to the right is not null, add right node
            if(nodeList[i].Right != null) 
              nodeList.Add(nodeList[i].Right);
        }
      //get value from node list, conver to normal int list.
        return nodeList.Select(x => x.Value).ToList();
    }
}

//method 2
using System;
using System.Collections.Generic;

class Kata
{
  public static List<int> TreeByLevels(Node node)
  {
    //level sort a tree...
    // something like, visit(n), enqueue left, enqueue right
    var list = new List<int>();
    
    var queue = new Queue<Node>();
    if (node != null) {
      queue.Enqueue(node);
    }
    
    while (queue.Count > 0) {
      var n = queue.Dequeue();
      if (n != null) {
        list.Add(n.Value);
        queue.Enqueue(n.Left);
        queue.Enqueue(n.Right);
      }
    }
    
    return list;
  }
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  
  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void FixedTests()
    {
      Assert.AreEqual(new List<int>(), Kata.TreeByLevels(null));
      Assert.AreEqual(new List<int>(){1,2,3,4,5,6}, Kata.TreeByLevels(new Node(new Node(null, new Node(null, null, 4), 2), new Node(new Node(null, null, 5), new Node(null, null, 6), 3), 1)));
    }
    
    [Test]
    public void RandomTests()
    {
      for (int i = 0; i < 100; i++)
      {
        Node node;
        List<int> li;
        
        makeTree(out node, out li);
        
        Assert.AreEqual(li, Kata.TreeByLevels(node));
      }
    }
    
    private void makeTree(out Node node, out List<int> li)
    {
      node = null;
      li = new List<int>();
      Random r = new Random();
      if (r.NextDouble() > 0.8)
        return;
      List<Node> a = new List<Node>() { new Node(null, null, r.Next(1, 1000))};
      int maxSize = r.Next(7, 127);
      for (int i = 0; i < a.Count; i++)
      {
        if (a.Count > maxSize)
          break;
        if (r.NextDouble() > 0.25)
        {
          Node n = new Node(null, null, r.Next(1, 1000));
          a[i].Left = n;
          a.Add(n);
        }
        if (r.NextDouble() > 0.25)
        {
          Node n = new Node(null, null, r.Next(1, 1000));
          a[i].Right = n;
          a.Add(n);
        }
      }
      node = a[0];
      li = new List<int>();
      foreach (Node n in a)
      {
        li.Add(n.Value);
      }
    }
  }
}
