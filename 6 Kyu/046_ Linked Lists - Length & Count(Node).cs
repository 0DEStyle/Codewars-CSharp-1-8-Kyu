/*Challenge link:https://www.codewars.com/kata/55beec7dd347078289000021/train/csharp
Question:
Linked Lists - Length & Count

Implement Length() to count the number of nodes in a linked list.

Node.Length(nullptr) => 0
Node.Length(1 -> 2 -> 3 -> nullptr) => 3
Implement Count() to count the occurrences of a that satisfy a condition provided by a predicate which takes in a node's Data value.

Node.Count(null, value => value == 1) => 0
Node.Count(1 -> 3 -> 5 -> 6, value => value % 2 != 0) => 3
I've decided to bundle these two functions within the same Kata since they are both very similar.

The push()/Push() and buildOneTwoThree()/BuildOneTwoThree() functions do not need to be redefined.
*/

//***************Solution********************
//ඞ

using System;
using System.Linq;

public partial class Node{
  public int Data;
  public Node Next;
  
  public Node(int data) => Data = data;
  
  //if head is Null, return 0, else return head.Next + 1
  public static int Length(Node head) => head == null ? 0 : Length(head.Next) + 1;
  
  //if head is Null, return 0, else check the bool state of func(head.Data)
  //if true 1 + Count(head.Next, func)
  //if false 0 + Count(head.Next, func)
  public static int Count(Node head, Predicate<int> func) => 
    head == null ? 0 : (func(head.Data) ? 1  : 0) + Count(head.Next, func);
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    [Test, Description("tests for counting the length of a linked list.")]
    public void LengthTest()
    {
      Node list = Node.BuildOneTwoThree();
      Assert.AreEqual(0, Node.Length(null), "Length of null list should be zero.");
      Assert.AreEqual(1, Node.Length(new Node(99)), "Length of single node list should be one.");
      Assert.AreEqual(3, Node.Length(list), "Length of the three node list should be three.");
    }
    
    [Test, Description("tests for counting occurences of data that satisfies a condition.")]
    public void CountTest()
    {
      Node list = Node.BuildOneTwoThree();
      Assert.AreEqual(1, Node.Count(list, value => value == 1), "list should only contain one 1.");
      Assert.AreEqual(1, Node.Count(list, value => value == 2), "list should only contain one 2.");
      Assert.AreEqual(1, Node.Count(list, value => value == 3), "list should only contain one 3.");
      Assert.AreEqual(0, Node.Count(list, value => value == 99), "list should return zero for integer not found in list.");
      Assert.AreEqual(0, Node.Count(null, value => value == 1), "null list should always return count of zero.");
      
      Assert.AreEqual(2, Node.Count(list, value => value % 2 != 0), "list should contain two odd numbers.");
      Assert.AreEqual(1, Node.Count(list, value => value % 2 == 0), "list should contain one even number.");
    }
  }
}
