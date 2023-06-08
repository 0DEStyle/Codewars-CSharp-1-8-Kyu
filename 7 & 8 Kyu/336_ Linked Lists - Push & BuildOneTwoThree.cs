/*Challenge link:https://www.codewars.com/kata/55be95786abade3c71000079/train/csharp
Question:
Linked Lists - Push & BuildOneTwoThree

Write push() and buildOneTwoThree() functions to easily update and initialize linked lists. Try to use the push() function within your buildOneTwoThree() function.

Here's an example of push() usage:

Node chained = null;
chained = Node.Push(chained, 3);
chained = Node.Push(chained, 2);
chained = Node.Push(chained, 1);
Node.Push(chained, 8) => 8 -> 1 -> 2 -> 3 -> null
The push function accepts head and data parameters, where head is either a node object or null/None/nil. Your push implementation should be able to create a new linked list/node when head is null/None/nil.

The buildOneTwoThree function should create and return a linked list with three nodes: 1 -> 2 -> 3 -> null
*/

//***************Solution********************
//ඞ
 //First in first out (FIFO) where first one is null.
  //example
  //Node chained = null;
  //chained = Node.Push(chained, 3);
  //chained = Node.Push(chained, 2);
  //chained = Node.Push(chained, 1);
  //Node.Push(chained, 8) => 8 -> 1 -> 2 -> 3 -> null
  
public class Node{
  public int Data;
  public Node Next;
  
  public Node(int data)=> Data = data;
  
  public static Node Push(Node head, int data){
    Node start = null;
    if(head == null) {
      start = new Node(data);
    }
    else {
      Node newNode = new Node(data);
      newNode.Next = head;
      start = newNode;
    }
    return start;
  }
  
  public static Node BuildOneTwoThree(){
    Node start = new Node(3);
    start = Push(start, 2);
    start = Push(start, 1);
    return start; 
  }
}

//method 2
public class Node
{
  public int Data;
  public Node Next;
  
  public Node(int data, Node next = null)
  {
    Data = data;
    Next = next;
  }
  
  public static Node Push(Node head, int data) => new Node(data, head);
  public static Node BuildOneTwoThree() => new Node(1, new Node(2, new Node(3)));
}

//method 3
using System;
using System.Linq;

public class Node
{
  public int Data { get; set; }
  public Node Next { get; set; }
  
  public Node(int data, Node next = null)
  {
    this.Data = data;
    this.Next = next;
  }
  
  public static Node Push(Node head, int data) => new Node(data, head);

  public static Node Build(params int[] datas) => datas.Reverse().Aggregate((Node)null, Push);
  
  public static Node BuildOneTwoThree() => Build(1, 2, 3);

}


//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class NodeTest
  {  
    [Test, Description("tests for inserting a node before another node.")]
    public void pushTests()
    {
      Assert.AreEqual(1, Node.Push(null, 1).Data, "Should be able to create a new linked list with push().");
      Assert.AreEqual(null, Node.Push(null, 1).Next, "Should be able to create a new linked list with push().");
      Assert.AreEqual(2, Node.Push(new Node(1), 2).Data, "Should be able to prepend a node to an existing node.");
      Assert.AreEqual(1, Node.Push(new Node(1), 2).Next.Data, "Should be able to prepend a node to an existing node.");
    }
    
    [Test, Description("tests for building a linked list.")]
    public void buildTests()
    {
      Assert.AreEqual(1, Node.BuildOneTwoThree().Data, "First node should should have 1 as data.");
      Assert.AreEqual(2, Node.BuildOneTwoThree().Next.Data, "Second node should should have 2 as data.");
      Assert.AreEqual(3, Node.BuildOneTwoThree().Next.Next.Data, "Third node should should have 3 as data.");
      Assert.AreEqual(null, Node.BuildOneTwoThree().Next.Next.Next, "Third node should be the tail of the linked list");
    }
  }
}
